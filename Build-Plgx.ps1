param ($optimizeProject)

$parent = Resolve-Path .\
$keepassExecutable = Get-ChildItem .\packages\KeePass*\lib\net*\KeePass.exe

Write-Output 'KP2chan PLGX Build Script - (C) 2022 L9CRO1XX'

if ($optimizeProject -eq 'Y') {
    Remove-Item .\out -WhatIf
}

Write-Output 'Compiling with KeePass...'

Start-Process $keepassExecutable -ArgumentList "--plgx-create $parent"

$attempts = 0
while ($attempts -lt 10) {
    $attempts += 1
    try {
        Move-Item ..\KP2chan.plgx .\out\Release -ErrorAction SilentlyContinue
    } catch {
        Write-Host '.' -NoNewline
        Start-Sleep -Milliseconds 500
    }
}

if ($attempts -ge 10 -and !(Test-Path .\out\Release\KP2chan.plgx)) {
    Write-Error 'Timed out waiting for KeePass to finish.'
    exit 1
}

Write-Output 'Finished.'
