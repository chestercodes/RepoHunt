open System
open System.IO
open System.Text
open Algorithm

let levMaxDistance = 3
let ensureFileExists path =
    if not(File.Exists path) then File.WriteAllText(path, "")
type LevResult = {Distance: int; First: string; FirstLength: int; Second: string; SecondLength: int}

type CsvData = {Results: LevResult list; Description: string}
type WriteData = Finish | Data of CsvData
type Process = End | Name of String
let maxParallel = Environment.ProcessorCount * 2

let mutable lastTimeWritten = DateTime.Now
let appIsStillWriting() = 
    lastTimeWritten > ((DateTime.Now).AddSeconds(-600.0))

let run dataDir = 
    let allNamesFile = Path.Combine(dataDir, "input", "Names.txt")
    let distancesFile = Path.Combine(dataDir, "Distances.csv")
    let processedFile = Path.Combine(dataDir, "Processed.txt")
    let countsFile = Path.Combine(dataDir, "Counts.csv")

    ensureFileExists distancesFile
    ensureFileExists processedFile
    
    let processed = File.ReadAllLines(processedFile) |> Set.ofArray

    let writeNameCounts names =
        let countByLength = names 
                            |> List.countBy (fun (x:string) -> x.Length)
                            |> List.sortBy fst
        let lines = countByLength |> List.map (fun x -> 
            let len = fst x
            let count = snd x
            (sprintf "%i,%i" len count)
        )
        if File.Exists(countsFile) then File.Delete(countsFile)
        File.WriteAllLines(countsFile, lines)
        ()


    let csvFileWriterAgent = MailboxProcessor<WriteData>.Start(fun inbox->
        let batchWriteCount = 1000
        let mutable written = processed.Count
        
        let toCsvLine x =
            let escapedFirst = x.First.Replace("\"", "\"\"")
            let escapedSecond = x.Second.Replace("\"", "\"\"")
            sprintf "%i,\"%s\",%i,\"%s\",%i" x.Distance escapedFirst x.FirstLength escapedSecond x.SecondLength
        
        let write batches =
            printfn "Writing batch, number written - %i" written
            let distances = StringBuilder()
            let processed = StringBuilder()
                
            for batch in batches do
                for r in batch.Results do
                    let asCsv = toCsvLine r 
                    distances.AppendLine asCsv |> ignore
                    
                processed.AppendLine(batch.Description) |> ignore
            
            File.AppendAllText(distancesFile, distances.ToString())
            File.AppendAllText(processedFile, processed.ToString())
        
        let rec messageLoop batches = async {
            let! msg = inbox.Receive()
            lastTimeWritten <-  DateTime.Now
            written <- written + 1
            //if written % 100 = 0 then printfn "Written %i" written
            match msg with
            | Finish -> write batches
                        return! messageLoop []
            | Data data ->                     
                let newBatches = data :: batches
                if newBatches.Length = batchWriteCount then  
                    write newBatches
                    return! messageLoop []
            
                return! messageLoop newBatches
        }
        
        messageLoop []
    )

    if not (File.Exists(allNamesFile)) then raise (Exception ("Needs to be file at " + allNamesFile)) |> ignore
    let names = File.ReadAllLines(allNamesFile) 
                |> Array.sort
                |> Array.toList
    
    writeNameCounts names

    // create tree with all words
    let trie = TrieNode()
    for w in names do
        trie.Insert(w)
    printfn "Created trie"

    let trieTraversalAgent() = MailboxProcessor<Process>.Start(fun inbox->
        
        let rec messageLoop() = async {
            let! processMsg = inbox.Receive()
            lastTimeWritten <-  DateTime.Now
            match processMsg with
            | End -> csvFileWriterAgent.Post Finish
            | Name word ->
                let description = sprintf "%s" word
                let alreadyProcessed = processed.Contains description
                
                if not alreadyProcessed then
                    let runResults = Search.Run(trie, word, levMaxDistance)
                    let results = runResults.Keys 
                                    |> Seq.filter (fun x -> x <> word) 
                                    |> Seq.map (fun x -> 
                                        let distance = runResults.[x]
                                        {Distance = distance; First = word; FirstLength = word.Length; Second = x; SecondLength = x.Length}
                                    )
                                    |> Seq.toList
                    csvFileWriterAgent.Post (Data {Results = results; Description = description})
                
                return! messageLoop()  
        }
        
        messageLoop()
    )
    let traversalAgents = [1 .. maxParallel] |> List.map (fun _ -> trieTraversalAgent())

    let mutable c = 0
    let nonProcessedWords = names |> List.filter(fun x -> not(processed.Contains(x))) |> List.sort
    for name in nonProcessedWords do
       let actorNum = c % maxParallel
       traversalAgents.[actorNum].Post (Name name)
       c <- c + 1
    for agent in traversalAgents do
        printfn "Posting end on agent!"
        agent.Post End

    while appIsStillWriting() do
        printfn "Something was written at %s so the application is probably still running. Currently %s" (lastTimeWritten.ToLongTimeString()) (DateTime.Now.ToLongTimeString())
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(15.0)) |> ignore

[<EntryPoint>]
let main argv =

    run "C:\\Dev\\Data\\RepoHunt\\npm"

    // run "C:\\Dev\\Data\\RepoHunt\\gem"

    // run "C:\\Dev\\Data\\RepoHunt\\nuget"

    // run "C:\\Dev\\Data\\RepoHunt\\pypi"

    0