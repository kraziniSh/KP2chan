param ($optimizeProject)

$TEMP_FOLDER_NAME = 'KP2chan_Building'

$solutionDir = Resolve-Path .\
$keepassExecutable = Get-ChildItem .\packages\KeePass*\lib\net*\KeePass.exe

Write-Output 'KP2chan PLGX Build Script - (C) 2022 L9CRO1XX'

if ($optimizeProject -eq 'Y') {
    Write-Output 'Optimizing...'

    $tempFolder = New-Item $env:LOCALAPPDATA\Temp -Name $TEMP_FOLDER_NAME -ItemType Directory

    Get-ChildItem *.* -Exclude *.cs, *.resx, *.ico, *.png, KP2chan.csproj, KP2chan.sln -Recurse |
    Move-Item -Destination $tempFolder
}

Write-Output 'Compiling with KeePass...'

Start-Process $keepassExecutable -ArgumentList "--plgx-create $solutionDir"

$attempts = 0
while ($attempts -lt 10) {
    $attempts += 1
    try {
        Move-Item ..\KP2chan.plgx .\out\Release -ErrorAction SilentlyContinue
    } catch {
        Write-Host . -NoNewline
        Start-Sleep -Milliseconds 500
    }
}

Get-ChildItem $tempFolder\*.* -Recurse |
    Move-Item -Destination $solutionDir

Remove-Item $tempFolder -WhatIf

if ($attempts -ge 10 -and !(Test-Path .\out\Release\KP2chan.plgx)) {
    Write-Error 'Timed out waiting for KeePass to finish.'
    exit 1
}

Write-Output Finished.
