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
Cleans up the KP2chan project.

.Description
Cleans up the project manually, without going through MSBuild/devenv.
Automatically called by .\BuildPLGX.ps1.

.Inputs
None.

.Outputs
int: 0 if succedded.
Non-0 in other cases.

.Example
(Automatically called by .\BuildPlgx.ps1)

.Example
.\CleanUpSrcDir.ps1 Optimize-project

.Example
.\CleanUpSrcDir.ps1 Optimize-projectTest
# Does not actually optimize, but shows what would happen if it did.
#>
$projectPath = Resolve-Path .\src\KP2chan

function Optimize-Project {
    Write-Output 'Optimizing...'

    $ErrorActionPreference = 'SilentlyContinue'

    Remove-Item $projectPath -Include *.suo -Recurse 
    Remove-Item $projectPath -Include *.user -Recurse
    Remove-Item $projectPath\bin -Recurse
    Remove-Item $projectPath\obj -Recurse

    $ErrorActionPreference = 'Continue'

    Write-Output 'Optimized.'
}
