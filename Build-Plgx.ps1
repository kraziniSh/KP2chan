Write-Output @"
KP2chan PLGX Build Script - (C) 2022 L9CRO1XX

"@

$solutionDir = Resolve-Path .\
$keepassExecutable = Get-ChildItem .\packages\KeePass*\lib\net*\KeePass.exe

if (!(Test-Path .\KP2chan.sln) -or !(Test-Path .\KP2chan.csproj)) {
    Write-Error 'Not a plugin directory. Exiting.'
    exit 1
}

Write-Output @"
Compilation has started and will finish soon.
Goodbye!
"@

Start-Process $keepassExecutable -ArgumentList "--plgx-create $solutionDir"
