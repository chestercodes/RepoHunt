open System
//open FSharp.Text.RegexProvider

let [<Literal>] postcodePattern = @"(?<Region>^[A-Z]{1,2})\d{1,2}\s*\d{1,2}[A-Z]{1,2}$"

let parseRegion input = 
    None
    
[<EntryPoint>]
let main argv = 
    
    let input = "AB12 34CD"
    
    let region = parseRegion input
    
    printfn "%s" (if region.IsSome then region.Value else "failed to parse")
    
    0 // return an integer exit code

    