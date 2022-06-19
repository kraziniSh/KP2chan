# KP2chan

## Build

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
  - When you click "Browse...", you should be in the solution directory.
  - Browse to: packages\KeePass[...]\lib\net[...];
  - Select KeePass.exe;
- Add "--debug" in the command line arguments when in the debug configuration;
- Keep the working directory field empty.

### Building

**Before building:** Delete unnecessary files! It will reduce the PLGX's final size.

Side note: I have attempted to create a PowerShell script to automate cleaning. It resulted in me
having to reinstall my chipset drivers. Hopefully I'll be able reboot after this.

Run the PLGX build script:

```Batchfile
powershell -File .\Build-Plgx.ps1
```

Alternatively, add this to the post-build event command line field in Visual Studio:

```Batchfile
cd $(ProjectDir)
powershell -File .\Build-Plgx.ps1
```

The PLGX will be automatically built after the project has been successfully built.
