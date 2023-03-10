# Contributing

## New Issues
1. Choose an appropriate template for the issue, if none are applicable, choose "Other".
1. Fill out the required fields.

## New Pull Requests
Not accepted at the moment.

## Commit Flow
1. Do the work.
1. Add or update relevant documentation sections(if any).
1. Add or update tests(if any).
1. Add your name to the `<Authors>...</Authors>` section in the appropriate projects.

## Development

### Creating Temporary NuGet Source
The project uses a temporary NuGet source named `tmp` to push and pull development versions of packages.

1. Create a new folder for the source.
1. `dotnet nuget add source <SOURCE_PATH> -name tmp`.

### Pushing to Temporary NuGet Source
All of the following builds the specified project(s) and pushes their NuGet package to `tmp`.
- `dotnet build <PROJECT> -p:DevelopmentNuGet=true`.
- `DevelopmentNuGet=true dotnet build <PROJECT>`.
- (sh)Run `export DevelopmentNuGet=true` once, then `dotnet build <PROJECT>`.
- (cmd)Run `set DevelopmentNuGet=true` once, then `dotnet build <PROJECT>`.

> **Note**: The version of the temporary package must not be a published version. And after the development session, be sure to clear the temporary packages from the global cache.

### Global Build Configuration
The root-level `Directory.Build.props` and `Directory.Build.targets` apply configuration to all projects. A few examples are listed below.
- `PackageLicenseExpression` = `MIT`
- `PackageProjectUrl` = `https://github.com/Arthri/Belp/`
- `Product` = `Belp`

There are more Directory.Build.* files across the repository. It is recommended to read them before changing any build files.

### Package Assets

#### Assets Folder
A project may have an Assets folder inside the same directory as the project file. Any files inside the assets folder are packed into the resulting NuGet package. For example, `Assets/build/Example.targets` results in a NuGet package with a directory `build/` and a file inside that directory named `Example.targets`.

#### README.md
By default, if a `README.md` file exists beside the project, it is packed into the package so that it can be displayed on NuGet GUIs, so do not put `README.md` inside the `Assets` folder.

#### _Package.*
Any file with the name `_Package` will be packed with `$(PackageId)` instead. For example, in the project `Belp.Build.Autoasmver`, the file `_Package.targets` is packed as `Belp.Build.Autoasmver.targets`; in other words, it's packed as a build extension. Additionally, `_Package.*` will show up as `$(PackageId).*` in the project system or IDEs such as Visual Studio.

`_Package` files must have an extension. If the file lacks an extension, then there will be no changes to it.

#### TFM Placeholder
A target framework-moniker(TFM) placeholder refers to a file named `_._` in the NuGet package under the directories `lib/**/_._`. The purpose of this file is indicate a package supports a particular target framework, but does not have any binaries for that target framework. This file can be added automatically by setting the MSBuild property `AddTFMPlaceholder` to true in the project file.

### Pack-Only Projects
Pack-only projects are projects that generate NuGet packages with no assemblies and usually don't use compilation. These include packages that deliver build configuration, packages that add static source files, and packages that contain templates.

#### Creation
All pack-only projects must be under `src/pack`, so create a folder for the pack-only project under `src/pack`. Then add a C# project file* at `src/pack/<PROJECT_NAME>/<PROJECT_NAME>.csproj` with the following contents:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <!-- Package Information -->
  <PropertyGroup>
    <Authors>Arthri</Authors>
    <Description>Automatically sets the assembly version to the last major version.</Description>
    <DevelopmentDependency>true</DevelopmentDependency>
    <InitialPublication>2023</InitialPublication>
    <PackageTags>msbuild;semver;semantic;version;versioning</PackageTags>
    <Title>Auto Assembly Version</Title>
    <Version>1.0.0.0</Version>
  </PropertyGroup>

</Project>
```
Add or remove package information as needed.

An example of an exception to the standard pack-only project is `src/pack/Belp.Build.PseudoKeywords`, which uses compilation for verification, but does not pack output binaries for the NuGet package.

*: It is easier to use C# projects than to engineer a new project format.

#### Configuration
`src/pack/Directory.Build.props` and `src/pack/Directory.Build.targets` specifies the default configuration options to make pack-only projects as simple as possible. The following are the configuration options automatically set
- `AddTFMPlaceholder` = `true`
- `BuildDependsOn` = `` (cleared out; blank)
- `Configuration` = `Release`
- `Configurations` = `Release`
- `EnableDefaultItems` = `false`
- `IncludeBuildOutput` = `false`
- `TargetFramework` = `netstandard2.0`

## Contacts
- @Arthri
    - Email: mailto://arthryxate@gmail.com
