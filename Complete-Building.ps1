<#
KP2chan; 2CATO empowered.
    Copyright (C) 2022  1A3CROIXX

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

.Synopsis
Calls the compiler for KP2chan (KeePass basically).
This script must not be manually called. Use .\Build-Plugin.ps1 instead.

.Description
Calls KeePass for building the KP2chan PLGX.
This script must not be manually called. Use .\Build-Plugin.ps1 instead.

.Parameter Configuration
Specifies the configuration. Only serves for copying the respective directories.
'Debug'/'Release'. Automatically specified by .\Build-Plugin.ps1.

.Example
(Automatically called by .\Build-Plugin.ps1)
#>
param ($configuratiom)

$keepass = Get-ChildItem .\packages\KeePass*\lib\net*\KeePass.exe
$projectPath = Resolve-Path .\src\KP2chan

function Complete-Building {
    Write-Output 'Calling KeePass for building...'

    Start-Process "$keepass" -ArgumentList "--plgx-create $projectPath"

    if (!(Test-Path $projectPath\bin)) {
        New-Item $projectPath -Name bin -ItemType Directory > $null
    }

    # Timeouts at 5 seconds
    $timeout = 0.0
    while (!(Test-Path ".\src\KP2chan.plgx")) {
        if ($timeout -eq 5) {
            Write-Error 'ERROR: KP2chan PLGX file could not be found.'
            exit 4
        }
        $timeout += 0.5
        Start-Sleep -Milliseconds 500
    }

    Write-Output 'Moving PLGX file...'

    Move-Item .\src\KP2chan.plgx $projectPath\bin

    Write-Output 'Restoring files...'

    Move-Item .\temp $projectPath\bin\$configuration
    Remove-Item .\temp -Recurse

    Write-Output 'KP2chan PLGX successfully generated. Navigate to .\src\KP2chan\bin to find it.'
}
