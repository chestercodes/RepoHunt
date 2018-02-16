#load "../CommonImports.fsx"

open System.Text
open FSharp.Plotly
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

let uniqueNamesForLengthAndDistance len dist =
    let firstNames = 
        query { 
            for ed in ctx.Main.NpmEditDistances do
            where(ed.Distance = dist && ed.LenFirst = len)
            select ed.First
            distinct
        }
        |> Seq.toList
    let secondNames = 
        query { 
            for ed in ctx.Main.NpmEditDistances do
            where(ed.Distance = dist && ed.LenSecond = len)
            select ed.Second
            distinct
        }
        |> Seq.toList
    let both = List.concat [firstNames; secondNames]
                |> List.distinct
                |> List.filter (fun x -> x.Length = len)
                
    both
    |> List.length

let totalNameCounts =
    query { 
        for nc in ctx.Main.NpmNameCount do
        select (nc.NumChars, nc.Count)
    }
    |> Seq.toList
    |> List.filter (fun x -> (snd x) > 40)
    
let getCountFromDistanceCount len dist = 
    let c = query { 
        for ed in ctx.Main.NpmDistanceCount do
        where(ed.Distance = dist && ed.NumChars = len)
        select(ed.Count)
    }
    c |> Seq.exactlyOne

let existsInDistanceCountTable len dist = 
    let c = query { 
        for ed in ctx.Main.NpmDistanceCount do
        where(ed.Distance = dist && ed.NumChars = len)
        count
    }
    c = 1

let addToDistanceCountTable len dist = 
    let count = uniqueNamesForLengthAndDistance len dist
    let total = totalNameCounts |> List.filter (fun x -> (fst x) = len) |> List.head |> snd
    ctx.Main.NpmDistanceCount.``Create(count, distance, num_chars, total)``(count, dist, len, total) |> ignore
    ctx.SubmitUpdates()

let processDistanceAndLength len dist =
    printfn "process %i and %i" len dist
    if not(existsInDistanceCountTable len dist) then
        printfn "need to run"
        addToDistanceCountTable len dist
    
    
for x in (totalNameCounts |> List.map fst) do
    processDistanceAndLength x 1
    processDistanceAndLength x 2
    processDistanceAndLength x 3
    

let getRatio len uniqueCount = 
    let totalCount = totalNameCounts
                        |> List.filter (fun x -> (fst x) = len) 
                        |> List.head
                        |> snd
    (((float uniqueCount) / (float totalCount)) * 100.0)

let levOne = totalNameCounts 
                |> List.map (fun x ->
                    let X = fst x
                    let Y = getCountFromDistanceCount X 1
                            |> getRatio X
                    (X, Y)
                )
let levTwo = totalNameCounts 
                |> List.map (fun x ->
                    let X = fst x
                    let Y = getCountFromDistanceCount X 2
                            |> getRatio X
                    (X, Y)
                )

let levThree = totalNameCounts 
                |> List.map (fun x ->
                    let X = fst x
                    let Y = getCountFromDistanceCount X 3
                            |> getRatio X
                    (X, Y)
                )


let getCountOfTotalForDistance (dist: int) = 
    let first = query { 
        for ed in ctx.Main.NpmEditDistances do
        where(ed.Distance <= dist)
        select (ed.First)
        distinct
    }
    
    let second = query { 
        for ed in ctx.Main.NpmEditDistances do
        where(ed.Distance <= dist)
        select (ed.Second)
        distinct
    }
    [first |> Seq.toList; second |> Seq.toList] 
    |> List.concat 
    |> List.distinct
    |> List.length
let totalsFilePath = Path.Combine(dataDir, "NpmTotals.csv")
let form (y:float):string = y.ToString("0.000")
if not(File.Exists(totalsFilePath)) then
    let totalDistinctNames =
        query { 
            for nc in ctx.Main.NpmNameCount do
            select nc.Count
        }
        |> Seq.toList
        |> List.sumBy (int)
    
    let getPercentageCountForDistance (c:int) =
        (float c) / float totalDistinctNames

    let lte1 = (getCountOfTotalForDistance 1)
    let lte2 = (getCountOfTotalForDistance 2)
    let lte3 = (getCountOfTotalForDistance 3)
    
    let per1 = (getPercentageCountForDistance lte1) |> form
    let per2 = (getPercentageCountForDistance lte2) |> form
    let per3 = (getPercentageCountForDistance lte3) |> form

    let sb = StringBuilder()
    sb.AppendLine(sprintf "Total,%i" totalDistinctNames) |> ignore
    sb.AppendLine(sprintf "1,%i,%s" lte1 per1) |> ignore
    sb.AppendLine(sprintf "2,%i,%s" lte2 per2) |> ignore
    sb.AppendLine(sprintf "3,%i,%s" lte3 per3) |> ignore
    File.WriteAllText(totalsFilePath, sb.ToString())


let percentageChartPath = Path.Combine(dataDir, "NpmPercentageChart.png")
if File.Exists(percentageChartPath) then File.Delete percentageChartPath |> ignore


let percentageChart = Chart.Combine([
        Chart.Line(levOne, Name = "dist < 2")
        Chart.Line(levTwo, Name = "dist < 3")
        Chart.Line(levThree, Name = "dist < 4")
    ])
let histogramChart = Chart.Column(totalNameCounts,Name="# packages", Color="#ccccff")

[
    histogramChart
    |> Chart.withAxisAnchor(Y=1);
    percentageChart
    |> Chart.withAxisAnchor(Y=2);
]
|> Chart.Combine
|> Chart.withX_AxisStyle("length of name (chars)")
|> Chart.withY_AxisStyle("number of packages",Side=StyleParam.Side.Right,Id=1)
|> Chart.withY_AxisStyle("% of names within distance",Side=StyleParam.Side.Left,Id=2,Overlaying=StyleParam.AxisAnchorId.Y 1)
|> Chart.Show
