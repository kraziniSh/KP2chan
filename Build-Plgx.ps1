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
Builds KP2chan to PLGX format. Deletes output directories before building.

.Description
All scripts are self-signed.
Builds KP2chan to PLGX format using locally downloaded KeePass NuGet
package. Will require confirmation to delete output directories unless
-IgnoreWarning $true is specified.

.Parameter SkipWarnings
Specifies if warnings should be ignored, such as before optimizing the project
(destructive action). Y/N

.Inputs
None.

.Outputs
An integer:
0 if succedded.
2 if user cancelled building.
3 if the KeePass NuGet package could not be retrieved.
4 if the generated PLGX file could not be found.
Non-0 in other cases.

.Example
# 
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
.\Build-PLGX.ps1
#>
param ($skipWarnings)

. ".\Complete-building.ps1"
. ".\Optimize-project.ps1"

$keepassExists = Test-Path .\packages\KeePass*\lib\net*\KeePass.exe


Write-Output 'KP2chan Build Script - (c) 2022 1A3CROIXX'

if (!$keepassExists) {
    Write-Error "FATAL: KeePass NuGet package could not be found! Make sure that it's installed."
    exit 3
}

if ($skipWarnings -ne 'Y') {
    $confirmOptimization = Read-Host @"
    WARNING: project will be optimized and output binaries/objects/plgx will be deleted! Are you sure you
    want to continue? (Y/N)
"@.Trim()
    if ($confirmOptimization -eq 'Y') {
        Optimize-Project
        Complete-Building
    } else {
        Write-Output 'PLGX building aborted: optimization cancelled.'
        exit 2
    }
} else {
    Write-Output 'Warnings skipped.'

    Optimize-Project
    Complete-Building
}
