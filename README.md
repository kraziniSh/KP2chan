# KP2chan <\=**=\>

## TCATO swiftly

The **t**wo **c**hannel **A**uto-**T**ype **o**bfuscation is an interesting
feature; shame that it is awfully difficult and tedious to enable. Either go
through one by one, or XML edit, potentially bricking the database.

KP2chan gives you the power to quickly enable those for many at once.

Unfortunately, auto-activation isn't implemented yet, as it is very difficult to
listen for new entries being created. Sorry, but better than nothing, eh?

## Build

### Dependencies

- (For building) *PowerShell* 5.1
- (Optional) *License Header Manager* Visual Studio extension

### Preparation

Beforehand, download a [portable KeePass ZIP package](https://keepass.info/download.html).

For the project to compile, you must add a reference to the portable KeePass in
your newly cloned project. From the Plugin Development (2.x) page of the KeePass
Help Center:

> [...] add a reference to KeePass: go to the references dialog and select the
> KeePass.exe file (from the portable ZIP package). After you added the
> reference, the namespaces KeePass and KeePassLib should be available.

And now, to easily debug the plugin:

  1. Build the project in each configuration;
  2. Go to the project's properties;
  3. Go to the Debug section;
  4. Select "Start external program";
  5. Set it to the KeePass executable in the output folder, respective to the
  current configuration (setting it to your portable KeePass will *not* work);

### Building

*Before building:* You may delete unnecessary files such as .csproj.user files.
It reduces the PLGX's final size.

To automatically build the PLGX file after the project, add this in the
post-build event command line field:
```Batchfile
cd $(SolutionDir)
powershell -File .\Build-Plgx.ps1 "$(ConfigurationName)"
```

Alternatively, you can manually run the PLGX build script:

```Batchfile
powershell -File .\Build-Plgx.ps1
```

The PowerShell script fetches the output KeePass resulting from a building, and
uses it compile the project (located at [.\KP2chan]). The resulting PLGX file
will be generated in the solution directory.
