open System.Net
let fetchAsync url = async {
        try
            let uri = new System.Uri(url)
            let webClient = new WebClient()
            let! html = webClient.AsyncDownloadString(uri)
            return Some html
        with
            | ex -> return None
    }
let urlList = [ "http://www.microsoft.com/"; "http://msdn.microsoft.com/"; 
                "http://www.bing.com"]
let fetchAsyncs = urlList |> List.map fetchAsync
let asParallel = fetchAsyncs |> Async.Parallel
let results = asParallel |> Async.RunSynchronously
for result in results do
    match result with
    | Some html -> printfn "%s" html
    | None      -> printfn "Failed :("


