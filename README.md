# RepoHunt
A repo for code relating to package manager typosquatting searching

This has only been run on windows (but should be able to be built to netstandard2.0 and run on other platforms with the directory paths changed) and currently involves:

- Having a couchdb database with the Views loaded into it and data replicated from npmjs.com
- Restoring the packages in the processing project (`dotnet restore`)
- Changing the abs path in src/scripts/CommonImports to point to the current user's nuget directory.
- Creating the directory C:\Dev\Data\RepoHunt\npm\input
- Running the scripts in order, changing the couchdb view urls where necessary
- - src/scripts/npm/CreateNamesAndAuthors.fsx
- - src/scripts/npm/CreateInterestingPackagesFromViews.fsx
- - src/scripts/npm/AppendJsConventionNamesToInterestingPackages.fsx
- - src/scripts/npm/AppendPopularNamesToInterestingPackages.fsx
- Running the processing project `dotnet build`, `dotnet run`
- Loading the produced .csv files into sqlite, steps are in src/scripts/ImportDataIntoSqlite.ps1
- Run the script
- - src/scripts/npm/

## Talks

F# bristol - f9ae67921f14ee3ce152d98b48c1103c1361da5b