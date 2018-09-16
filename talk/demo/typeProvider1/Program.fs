let [<Literal>] pattern = @"(?<Region>^[A-Z]{1,2})\d{1,2}\s*\d{1,2}[A-Z]{1,2}$"

let parseRegion input = 
    None
    
[<EntryPoint>]
let main argv = 
    let input = "AB12 34CD"
    printfn "try to parse the input %s" input
    let result = match parseRegion input with 
                 | Some a ->  sprintf "success! region - %s" a
                 | None   -> "failed to parse"
    printfn "%s" result
    0 // return an integer exit code

    