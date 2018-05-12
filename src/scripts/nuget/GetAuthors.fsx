#load "../CommonImports.fsx"
open FSharp.Data
open System
open System.IO
open System.Net

let download (url: string) (path: string) =        
    use client = new WebClient()
    client.DownloadFile(url, path)
type NameAuthor = { Package: string; Author: string }
let dataDir = "C:\\Dev\\Data\\RepoHunt\\nuget\\temp"
if not(Directory.Exists dataDir) then Directory.CreateDirectory dataDir |> ignore
let namesPath = Path.Combine(dataDir, "../NugetNames.txt")
let written = Path.Combine(dataDir, "../NugetAuthors.csv")
if not (File.Exists(written)) then File.WriteAllText (written, "")  else ()
let error = Path.Combine(dataDir, "../NugetErrors.csv")
if not (File.Exists(error)) then File.WriteAllText (error, "")  else ()
let alreadyWritten = File.ReadAllLines(written) 
                        |> Array.map (fun x -> x.Split('|').[0])
                        |> Set.ofArray 
let names = File.ReadAllLines(namesPath) |> Array.toList

let writeActor = MailboxProcessor<NameAuthor>.Start(fun inbox->
    let rec messageLoop () = async {
        let! msg = inbox.Receive()
        
        let csv = sprintf "%s|%s" msg.Package msg.Author
        File.AppendAllText(written, Environment.NewLine + csv)
        return! messageLoop ()
    }
    
    messageLoop ()
)

let runSearch name = async {
    
    if alreadyWritten.Contains name then
        //printfn "Already exists."
        ()
    else 
        let asLower = name.ToLower()
        let url = sprintf "https://api.nuget.org/v3/registration3/%s/index.json" asLower
        try        
            let json = JsonValue.Load(url)
            let authorOrNull = match json.TryGetProperty("items") with
                                | None -> None
                                | Some x -> 
                                    match x with                           
                                    | JsonValue.Array itemsOuterArr -> 
                                        match itemsOuterArr with
                                        | x when x.Length < 1 -> None
                                        | itemsOuter ->
                                            match itemsOuter.[0].TryGetProperty("items") with
                                                | None -> None
                                                | Some x ->
                                                    match x with
                                                    | JsonValue.Array itemsInnerArr -> 
                                                        match itemsInnerArr with
                                                        | x when x.Length < 1 -> None
                                                        | itemsInner ->
                                                            match itemsInner.[0].GetProperty("catalogEntry") with
                                                            | JsonValue.Record r ->
                                                                let mapped = r 
                                                                                |> Map.ofArray
                                                                                |> fun x -> x.["authors"]
                                                                match mapped with
                                                                | JsonValue.String s -> Some {Package = name; Author = s}
                                                                | _ -> None
                                                            | _ -> None                                             
                                                    | _ -> None                                        
                                    | _ -> None                                            
            if authorOrNull.IsSome then
                writeActor.Post authorOrNull.Value
        with
            | :? System.Exception -> 
                File.AppendAllText(error, Environment.NewLine + name)
                ()

}



let enumerateOver = names //|> List.take 50

enumerateOver
|> List.map runSearch
|> Async.Parallel
|> Async.RunSynchronously 

Console.ReadKey()