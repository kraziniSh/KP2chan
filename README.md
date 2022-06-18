# KP2chan

## Bulding

### Dependencies

- *KeePass* NuGet package
- (For building) *PowerShell* 5.1
- (Optional) *License Header Manager* Visual Studio extension

### Preparation

- Install the KeePass NuGet package;
- Go to the project's properties;
- Go to the Debug section;
- Set Configuration to "All Configurations";
- Select "Start external program";
- Set it to KeePass.exe:
	- When you click "Browse...", you should in the solution directory.
	- Browse to: packages\KeePass[...]\lib\net[...];
	- Select KeePass.exe;
- Add "--debug" in the command line arguments;
- Keep the working directory field empty.

### Building

Build the project. If everything goes right, you will find a lonely .plgx file in the
bin folder.
