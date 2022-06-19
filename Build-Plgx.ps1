param ($configuration)

Write-Output @"
KP2chan PLGX Build Script

"@

$pluginDir = Resolve-Path .\KP2chan

$keepassDebugExecutable
$keepassReleaseExecutable
$plgxCompiler
if (Test-Path .\out\Debug\KeePass.exe) {
    $plgxCompiler = Get-ChildItem .\out\Debug\KeePass.exe
} elseif (Test-Path .\out\Release\KeePass.exe) {
    $keepassExecutable = Get-ChildItem .\out\Release\KeePass.exe
} else {
    Write-Warning "Can't build PLGX because the output KeePass was not found!"

    $keepassExecutable = Read-Host -Prompt "Please specify a path to a KeePass executable" |
    Resolve-Path
}

Write-Output "Compiling..."

# The safe way. No arguments redirects.
if ($configuration -eq "Debug") {
    Start-Process $keepassExecutable -ArgumentList "--plgx-create $pluginDir --debug"
} else {
    Start-Process $keepassExecutable -ArgumentList "--plgx-create $pluginDir"
}

Write-Output "Finished. Until next time!"
