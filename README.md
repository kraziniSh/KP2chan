# KP2chan

## Build

### Dependencies

- (For building) *PowerShell* 5.1
- (Optional) *License Header Manager* Visual Studio extension

### Preparation

Beforehand, download a [portable KeePass ZIP package](https://keepass.info/download.html).

Go to the project's properties, then set Configuration to "All Configurations".

First, we will configure the output directory:

  1. Go to the Build section
  2. Set the output directory to a folder (e.g. "out") in solution directory,
  *not* the project (or plugin) directory.

  This prevents packaging unnecessary files in the final PLGX file.

Finally, to easily debug the plugin:

  1. Go to the Debug section;
  2. Select "Start external program";
  3. Set it to your portable KeePass executable;
  4. Add "--debug" in the command line arguments when in the debug configuration;

### Building

**Before building:** Delete unnecessary files such as .csproj.user files! It
will reduce the PLGX's final size.

Run the PLGX build script:

```Batchfile
powershell -File .\Build-Plgx.ps1
```

Alternatively, add this to the post-build event command line field in Visual Studio:

```Batchfile
cd $(ProjectDir)
powershell -File .\Build-Plgx.ps1
```

This automatically builds the PLGX file after the project has been successfully
built.
