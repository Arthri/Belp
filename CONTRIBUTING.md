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

## Contacts
- @Arthri
    - Email: mailto://arthryxate@gmail.com
