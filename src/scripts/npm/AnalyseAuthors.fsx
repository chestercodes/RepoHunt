open System.Text
#load "../CommonImports.fsx"

open FSharp.Data.Sql
open System.IO

[<Literal>]
let dbDir = "C:\\Dev\\Data\\RepoHunt"
let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm\\results"

[<Literal>]
let connectionString = "Data Source=" + dbDir + "\\RepoHunt.db;Version=3;foreign keys=true"
[<Literal>]
let resolutionPath = "C:\\Users\\cburbidge\\.nuget\\packages\\system.data.sqlite.core\\1.0.106\\lib\\net46"

type sql = SqlDataProvider<
                Common.DatabaseProviderTypes.SQLITE,
                SQLiteLibrary = Common.SQLiteLibrary.SystemDataSQLite,
                ConnectionString = connectionString,
                ResolutionPath = resolutionPath,
                CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>

let ctx = sql.GetDataContext()

type AuthorRow = {Author: string; Package: string}

let authorRows =
    query { 
        for ed in ctx.Main.NpmAuthors do
        select (ed.Author, ed.Package)
    }
    |> Seq.toList
    |> List.map (fun x -> {Author = fst x; Package = snd x})

let packageCountByAuthor = authorRows 
                            |> List.groupBy (fun x -> x.Author)
                            |> List.filter (fun x -> fst x <> "npm")
                            |> List.map (fun x -> fst x, (snd x).Length)
                            |> List.sortByDescending snd

let counts = packageCountByAuthor |> List.map snd
let above limit =
    let num = counts |> List.filter (fun x -> x >= limit) |> List.length
    printfn "There are %i authors with more than %i packages" num limit

for n in [50 .. 50 .. 1000] do
    above n
