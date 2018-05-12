#load "../CommonImports.fsx"
open FSharp.Data
open System
open System.IO

let dataDir = "C:\\Dev\\Data\\RepoHunt\\nuget\\temp"
if not(Directory.Exists dataDir) then Directory.CreateDirectory dataDir |> ignore

let topNamesFile = Path.Combine(dataDir, "NugetNames.txt")
let searchChars = List.concat [['a' .. 'z']; ['0' .. '9']; ['_']]
let searchTerms = searchChars
                |> List.collect (fun c -> 
                    searchChars 
                    |> List.map (fun y -> c.ToString() + y.ToString())
                )

let ignoreParts = [] 
                    // "aaaa"; "baaa"; "aabaab"; 
                    // "definitea"; "extensioa"; "framewora"; "microsofa"; "servicesaa";"servicesab"; "typescria"; 
                    // "definiteb"; "extensiob";  "frameworb"; "microsofb"; "typescrib";
                    // "definitec"; "extensioc"; "frameworc"; "microsofc"; "typescric";
                    // "definited"; "extensiod"; "frameword"; "microsofd"; 
                    // "definitee"; "extensiod"; "frameword"; "microsofd"; 
                    // "extensiod"]
let runSearch term = async {
    let textFile = Path.Combine(dataDir, sprintf "%s.txt" term)
    //printfn "Running for %s" term
    if File.Exists(textFile) then
        printfn "Already exists."
        ()
    else 
        let take = 999
        let rec getValues term =    
            //printfn "Run for %s" term
            let url = sprintf "https://api-v2v3search-0.nuget.org/autocomplete?q=%s&take=%i&prerelease=true" term take
            let json = JsonValue.Load(url)
            let hits = json.GetProperty("totalHits").AsInteger()
            if hits > take && term.Length < 5 && not( ignoreParts |> List.exists (fun x -> term.Contains(x)) ) then 
                printfn "There are more than take for %s %i" term hits
                searchChars 
                //|> List.map (fun x -> if term.Length % 2 = 0 then term + x.ToString() else x.ToString() + term)
                |> List.map (fun x -> term + x.ToString())
                |> List.collect (fun x -> getValues x)

            else
                json.GetProperty("data").AsArray() 
                |> Array.map (fun x -> x.AsString())
                |> Array.toList
        let names = getValues term
        File.WriteAllText(textFile, String.Join(Environment.NewLine, names))
}

searchTerms
|> List.map runSearch
|> Async.Parallel
|> Async.RunSynchronously 


let allNames = searchTerms 
                |> List.collect (fun x ->
                    let textFile = Path.Combine(dataDir, sprintf "%s.txt" x)
                    File.ReadAllLines(textFile) |> Array.toList
                )
                |> List.distinctBy id
                |> List.sort

File.WriteAllText(Path.Combine(dataDir, "../NugetNames.txt"), String.Join(Environment.NewLine, allNames))
printfn "There are %i unique names" (allNames.Length)

Console.ReadKey()