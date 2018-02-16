open System.IO
open System

let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm\\input"
let namesFile = Path.Combine(dataDir, "Names.txt")
let names = File.ReadAllLines(namesFile) |> Array.toList |> List.distinct
let getCombinationCount (x: Int64) = 
    (x * (x + int64 1)) / int64 2

let totalCount = getCombinationCount (int64 names.Length)

let sumOfLengthFiltered = names 
                            |> List.groupBy (fun x -> x.Length) 
                            |> List.map (fst >> (fun n ->
                                names 
                                |> List.filter(fun x -> x.Length >= n && x.Length < n + 4)
                                |> List.length
                                |> (fun x -> getCombinationCount(int64 x))
                            ))
                            |> List.sum

printfn "Full exhaustive search - %i" totalCount
printfn "Filtered by length     - %s" (sumOfLengthFiltered.ToString())
