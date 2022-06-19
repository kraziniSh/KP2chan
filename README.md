# KP2chan

## !!! WARNING !!!

### **DO NOT RUN THE PLGX BUILD SCRIPT (.\Build-Plgx.ps1). THERE IS A CRITICAL BUG.**

It will endlessly copy files from your partition root and place them in the
solution directory.

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

Run the PLGX build script:

```Batchfile
powershell -File .\Build-Plgx.ps1 "Y"
```

Alternatively, add this to the post-build event command line field in Visual Studio:

```Batchfile
cd $(ProjectDir)
powershell -File .\Build-Plgx.ps1 "Y"
```

The PLGX will automatically build after the project has been successfully built.

If everything goes right, you will find a .plgx file in the
out/Release folder.

The script automatically optimizes the project. That means that it temporarily
moves unnecessary files before restoring them.
