type WriterMessage = StopWriting | WriteData of string
let writerActor = MailboxProcessor<WriterMessage>.Start(fun inbox-> 
    let stopAfter = 3
    let rec messageLoop nStopsSeen = async {
        let! msg = inbox.Receive()
        do! Async.Sleep (500)
        match msg with
        | StopWriting -> 
            let nStops = nStopsSeen + 1
            if nStops = stopAfter then
                printfn "finished writing"
                return ()
            else
                printfn "told to stop writing"
                return! messageLoop nStops
        | WriteData data -> 
            printfn "word %s" data
            return! messageLoop nStopsSeen
    }
    messageLoop 0
)

writerActor.Post (WriteData "one")
writerActor.Post (WriteData "two")
writerActor.Post (WriteData "three")
writerActor.Post StopWriting
writerActor.Post (WriteData "four")
writerActor.Post (WriteData "five")
writerActor.Post StopWriting
writerActor.Post (WriteData "six")
writerActor.Post StopWriting
writerActor.Post (WriteData "seven")