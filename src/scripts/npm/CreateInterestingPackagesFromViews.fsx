#load "../CommonImports.fsx"
open FSharp.Data
open System.IO

let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm"
type PackageAndDescription = {Package: string; Description: string}
let readAppView appName viewName viewDescription = 
    let viewUrl = sprintf "http://localhost:5984/registry/_design/%s/_view/%s" appName viewName
    
    let json = JsonValue.Load(viewUrl)
    let rows = json.GetProperty("rows")
    match rows with
    | JsonValue.Array a -> a 
                            |> Array.toList 
                            |> List.map (fun x -> 
                                let packageName = x.GetProperty("id").AsString()
                                {Package = packageName; Description = viewDescription}
                            )
    | _ -> []
let readView viewName viewDescription = 
    readAppView viewName viewName viewDescription
let interestingPackagesCsvFile = Path.Combine(dataDir, "InterestingPackages.csv")
if File.Exists interestingPackagesCsvFile then File.Delete interestingPackagesCsvFile

let values = [
                readView "frequentlyReleased" "Released5InHourAfterCreation"
                //readView "depLev" "DependencyWithLowLev"
                readAppView "repoHunt" "containsScriptNodeCall" "ContainsScriptCall"
                readAppView "repoHunt" "depLevLte1" "DepLevLte1"
                readAppView "repoHunt" "depLevLte2" "DepLevLte2"
                readAppView "repoHunt" "depLevLte3" "DepLevLte3"
                readAppView "repoHunt" "majorVersionJump" "MajorVersionJump"
             ] 
             |> List.collect id

let toCsvLine x =
    sprintf "\"%s\",\"%s\"" x.Package x.Description
let lines = values |> List.map toCsvLine

File.WriteAllLines(interestingPackagesCsvFile, lines) |> ignore