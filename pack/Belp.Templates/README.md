# Belp.Templates
[![Project License](https://img.shields.io/badge/license-MIT-green?style=flat-square "License")](https://github.com/Arthri/Belp/blob/02b63f4be263d747f3078a0568bf235bf021d0cd/LICENSE) [![Latest NuGet Release](https://img.shields.io/nuget/v/Belp.Templates?style=flat-square "Latest NuGet Release")](https://www.nuget.org/packages/Belp.Templates/latest)

Provides templates for MSBuild projects and other files.

## Available Templates

### Directory.Build.props
Short Name: `dbprops`

#### Parameters
None

### Directory.Build.targets
Short Name: `dbtargets`

#### Parameters
None

### MSBuild Project
Short Names: `proj`, `msbuildproj`

#### Parameters
- `--sdk <sdk>` (Optional): Specifies the SDK to put in `<Project Sdk="...">`.

## Installation

### Prequisites
- Install .NET 6 SDK or above.

### Install using .NET CLI(NuGet)
1. Open a terminal.
1. Run `dotnet new install Belp.Templates`.

### Install using .NET CLI(GitHub)
1. Download the `.nupkg` from [GitHub Releases](https://github.com/Arthri/Belp/releases/latest).
1. Open a terminal.
1. Locate and navigate to the package.
1. Run `dotnet new install Belp.Templates.VERSION.nupkg`.

### Uninstallation
1. Open a terminal.
1. Run `dotnet new uninstall Belp.Templates`.

## Usage

### Use from .NET CLI
1. Open a terminal.
1. Navigate to the desired directory.
1. Run `dotnet new <Desired Template>`. For example, `dotnet new dbprops` to create a new Directory.Build.props file.

### Use from Visual Studio
Not supported and not available.

## License
This work is licensed under [MIT](https://github.com/Arthri/Belp/blob/02b63f4be263d747f3078a0568bf235bf021d0cd/LICENSE).
