# KP2chan

## Bulding

### Dependencies

- KeePass NuGet package
- PowerShell 6+

### Preparation

Install the KeePass NuGet package;
Go to the project's properties;
Go to the Debug section;
Set Configuration to "All Configurations";
Tick "Start external program";
Set it to KeePass.exe:
When click "Browse...", you should in the solution directory.
Browse to: packages\KeePass[...]\lib\net[...];
Select KeePass.exe;
Set the working directory the solution directory (just click "Browse..." essentially).
Add "--debug" in the command line arguments.

### Building

Build the project. If everything goes right, you will find a lonely .plgx file in the
bin folder.
