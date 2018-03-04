
let waitAndPrint milliseconds = async { 
    printfn "%i" milliseconds
    do! Async.Sleep milliseconds
    printfn "Waited %i ms" milliseconds
}

[1000 .. 250 .. 2000]
|> List.map waitAndPrint
|> Async.Parallel
|> Async.RunSynchronously 
