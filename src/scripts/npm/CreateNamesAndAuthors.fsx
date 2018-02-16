#load "../CommonImports.fsx"
open FSharp.Data
open System.IO

let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm"
let inputDir = Path.Combine(dataDir, "input")
let authorsViewUrl = "http://localhost:5984/registry/_design/getVersionsByAuthor/_view/getVersionsByAuthor"
let json = JsonValue.Load(authorsViewUrl)
let rows = json.GetProperty("rows")
type PackageAndAuthor = {Package: string; Author: string}

let values = match rows with
                | JsonValue.Array a -> a 
                                        |> Array.toList 
                                        |> List.collect (fun x -> 
                                            let packageName = x.GetProperty("id").AsString()
                                            let author = x.GetProperty("value").AsArray()
                                            if author.Length = 0 then printfn "ERROR - package has no author %s" packageName
                                            author
                                            |> Array.map (fun x -> 
                                                let v = x.AsString()
                                                {Package = packageName; Author = v}
                                            )
                                            |> Array.toList
                                        )
                | _ -> []

let names = values 
            |> List.map (fun x -> x.Package)
            |> List.distinct
            |> List.sort

let namesFile = Path.Combine(inputDir, "Names.txt")
if File.Exists namesFile then File.Delete namesFile
File.WriteAllLines(namesFile, names)

let authorsCsvFile = Path.Combine(dataDir, "Authors.csv")
if File.Exists authorsCsvFile then File.Delete authorsCsvFile

let toCsvLine x =
    let escapedAuthor = x.Author.Replace("\"", "\"\"")
    sprintf "\"%s\",\"%s\"" x.Package escapedAuthor
let lines = values |> List.map toCsvLine

File.WriteAllLines(authorsCsvFile, lines) |> ignore