# Nuget Installer

## What is Nuget Installer
Nuget Installer is a command-line installer that installs the latest version of NuGet.exe into your system. You may notice while you use NuGet that you always need to move the NuGet.exe file every time you want to use it. To solve this problem, I wrote this software, Nuget Installer, that installs NuGet.exe directly into C:\Windows folder, so you do not need to copy it every time you want to run it.

## Building source code
### Requirements
-   Visual Studio 2019 or Microsoft .NET Framework

### Procedure
1.  `git clone` or download this repository.

2.  Open `cmd.exe` (or Developer Command Prompt if you are using Visual Studio) in the folder you have extracted the files.

3.  Run:

    ```batch
    msbuild.exe NugetInstaller.sln /m /p:Configuration=Release /p:Platform="Any CPU"
    ```

4.  Check `bin\Release` folder and enjoy Nuget Installer!

## Badges
| Github Actions | AppVeyor | Azure Pipelines | Travis CI | Codacy |
|:-:|:-:|:-:|:-:|:-:|
| [![.NET Framework (Windows)](https://github.com/LumitoLuma/NugetInstaller/workflows/.NET%20Framework%20(Windows)/badge.svg)](https://github.com/LumitoLuma/NugetInstaller/actions?query=workflow%3A%22.NET+Framework+%28Windows%29%22) | [![Build status](https://ci.appveyor.com/api/projects/status/bkdtonymj7ayhm2h?svg=true)](https://ci.appveyor.com/project/LumitoLuma/NugetInstaller) | [![Build Status](https://dev.azure.com/LumitoLuma/GitHub/_apis/build/status/LumitoLuma.NugetInstaller?branchName=master)](https://dev.azure.com/LumitoLuma/GitHub/_build/latest?definitionId=14&branchName=master) | [![Build Status](https://travis-ci.com/LumitoLuma/NugetInstaller.svg?branch=master)](https://travis-ci.com/LumitoLuma/NugetInstaller) | [![Codacy Badge](https://app.codacy.com/project/badge/Grade/8dff8f4225114d29bc7d7c31c4a0ff42)](https://www.codacy.com/manual/LumitoLuma/NugetInstaller?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=LumitoLuma/NugetInstaller&amp;utm_campaign=Badge_Grade) |
| [![.NET Framework (Mono)](https://github.com/LumitoLuma/NugetInstaller/workflows/.NET%20Framework%20(Mono)/badge.svg)](https://github.com/LumitoLuma/NugetInstaller/actions?query=workflow%3A%22.NET+Framework+%28Mono%29%22) | | | | |

## Downloading compiled version of Nuget Installer
You can download a compiled version of Nuget Installer through Releases tab.

| [![Download now!](https://img.shields.io/badge/Download-now-green.svg?style=flat-square)](https://github.com/LumitoLuma/NugetInstaller/releases) |
|:-:|

## Contributing to the project
If you want to contribute to the project, please contact me through [lumito.net/contact](https://lumito.net/contact) or open a Pull Request.

You can contribute with the following things:

-   Code improvements
-   Ideas for future programs / services.

Reporting bugs at the contact form is not allowed, unless you have reported them through [Issues](https://github.com/LumitoLuma/NugetInstaller/issues) tab and you have not received any comments for a while (minimum a week).

## Acknowledgements
I would like to thank Microsoft for developing the amazing NuGet package manager, which is available through [www.nuget.org](https://www.nuget.org).

© 2010 - 2020, Microsoft Corporation
<br><br>
**© 2020, Lumito - [www.lumito.net](https://lumito.net)**
