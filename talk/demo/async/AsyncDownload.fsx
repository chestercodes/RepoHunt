open System.Net
// string -> Async<string option>
let fetchAsync url = async {
    try
      let uri = new System.Uri(url)
      let webClient = new WebClient()
      let! html = webClient.AsyncDownloadString(uri)
      return Some html
    with
        | ex -> return None
    }
let urlList = [ "http://www.microsoft.com/"; 
    "http://msdn.microsoft.com/"]
let results = 
        urlList                   // string list
        |> List.map fetchAsync    // Async<string option> list
        |> Async.Parallel         // Async<string option []>
        |> Async.RunSynchronously // string option []
for result in results do
  match result with
  | Some html -> printfn "%s" html
  | None      -> printfn "Failed :("