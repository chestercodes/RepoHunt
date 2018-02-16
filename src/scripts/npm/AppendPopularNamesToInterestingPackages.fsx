#load "../CommonImports.fsx"
open FSharp.Data
open System.IO
open System

let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm"
type PackageAndDescription = {Package: string; Description: string}

let interestingPackagesCsvFile = Path.Combine(dataDir, "InterestingPackages.csv")
if not (File.Exists interestingPackagesCsvFile) then 
    raise(FileNotFoundException("Need to create packages from views first"))

let offsets = [0 .. 36 .. 10000]
let topNames = offsets 
                        |> List.map (fun offset -> 
                            let url = sprintf "https://www.npmjs.com/browse/depended?offset=%i" offset
                            let results = HtmlDocument.Load(url)

                            results.CssSelect("div.package-details h3 a")
                            |> List.map(fun a -> a.InnerText().Trim())
                        )
                        |> List.collect id

let description = "PopularPackageName"

let values = topNames |> List.map (fun x -> {Package = x; Description = description})
let toCsvLine x =
    sprintf "\"%s\",\"%s\"" x.Package x.Description
let lines = values |> List.map toCsvLine

File.AppendAllText(interestingPackagesCsvFile, Environment.NewLine)
File.AppendAllLines(interestingPackagesCsvFile, lines) |> ignore