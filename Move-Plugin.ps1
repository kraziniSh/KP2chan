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
    Copies the plugin to the NuGet KeePass for debugging with it.
    Called automatically by Visual Studio after successful building if set up.

    .Description
    Copies newly generated PLGXs to the NuGet KeePass Plugins directory.
    Makes it possible to debug it using local KeePass.

    .Parameter Type
    Whether it is PLGX or DLL to move. Defaults to plgx.
    'both'/'dll'/'plgx'

    .Parameter Configuration
    Specifies the configuration. Only serves for copying the respective directories.
    'Debug'/'Release'. Defaults to 'Debug'.
#>
param ($type, $configuration)
$keepassPath = Resolve-Path .\packages\KeePass*\lib\net*

if (!$type) { $type = 'plgx' }
if (!$configuration) { $configuration = 'Debug' }

if (!(Test-Path $keepassPath\Plugins)) {
    New-Item $keepassPath -Name Plugins -ItemType Directory > $null
}

Copy-Item -Path ".\src\KP2chan\bin\$configuration\KP2chan.$type" -Destination $keepassPath\Plugins -Force

Write-Output 'KP2chan copied to Plugins; now loadable by NuGet KeePass'