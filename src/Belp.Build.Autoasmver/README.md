# Belp.Build.Autoasmver
[![Project License](https://img.shields.io/badge/license-MIT--0-green?style=flat-square "License")](https://github.com/Arthri/Belp/blob/35dc43df571de970e89f186f14b2ada33b1b956c/LICENSE) [![NuGet](https://img.shields.io/nuget/v/Belp.Build.Autoasmver?style=flat-square "Latest NuGet Release")](https://www.nuget.org/packages/Belp.Build.Autoasmver/latest)

Autoasmver automatically sets the assembly version to the latest major version. For example,

| Package Version | Assembly Version |
|-----------------|------------------|
| 1.4.2           | 1.0.0.0          |
| 2.6.9           | 2.0.0.0          |
| 3.0.9           | 3.0.0.0          |
| 4.0.0           | 4.0.0.0          |

## Why?
https://codingforsmarties.wordpress.com/2016/01/21/how-to-version-assemblies-destined-for-nuget/

## Installation

### Requirements
- A project written in SDK-style. This includes any project for .NET Core(or newer) or .NET 5(or newer)

### Install using Visual Studio Package Manager
1. Open Visual Studio
1. Right click the project in the Solution Explorer
1. Click on "Manage NuGet Packages"
1. Go to the "Browse" tab
1. Search for `Belp.Build.Autoasmver`
1. Install

### Install using .NET CLI
1. Open a terminal
1. Navigate to the project file; for example, `Project.csproj`, `Project.vbproj`, etc.
1. Run `dotnet add package Belp.Build.Autoasmver`

## Usage
No input required

## License
This work is licensed under [MIT-0](https://github.com/Arthri/Belp/blob/35dc43df571de970e89f186f14b2ada33b1b956c/LICENSE)
