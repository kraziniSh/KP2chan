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
Cleans up the KP2chan project, for preparing the building.
Automatically called by .\BuildPLGX.ps1.

.Description
Cleans up the project manually, without going through MSBuild/devenv.
Automatically called by .\BuildPLGX.ps1.

.Example
(Automatic call by .\BuildPlgx.ps1)

.Example
.\Optimize-Project.ps1 Optimize-Project
#>
$projectPath = Resolve-Path .\src\KP2chan

function Optimize-Project {
    Write-Output 'Optimizing...'

    # Prevents complaints for directories not existing; we don't care 'bout that
    $ErrorActionPreference = 'SilentlyContinue'

    Remove-Item $projectPath -Include *.suo -Recurse 
    Remove-Item $projectPath -Include *.user -Recurse
    Remove-Item $projectPath\bin -Recurse
    Remove-Item $projectPath\obj -Recurse

    $ErrorActionPreference = 'Continue'

    Write-Output 'Optimized.'
}
