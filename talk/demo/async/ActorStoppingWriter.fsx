open System

type WriterMessage = StopWriting | WriteData of string

let createWriterAgent name = MailboxProcessor<WriterMessage>.Start(fun inbox-> 
    let stopAfter = 3
    printfn "Writer %s started" name
    let rec messageLoop nMessagesSeen = async {
        let! msg = inbox.Receive()
        
        match msg with
        | StopWriting -> 
            printfn "%s - finished" name
            return ()
            
        | WriteData data -> 
            let stopAfterWriting = nMessagesSeen = (stopAfter - 1)
            printfn "%s - data %s" name data
            
            if stopAfterWriting then
                printfn "%s - finished" name
                return ()
            else
                do! Async.Sleep (1000)
                return! messageLoop (nMessagesSeen + 1)

    }
    messageLoop 0
)

let stopAfterStopMessageWriter = createWriterAgent "StopAfterStopMessage"

let stopAfterThreeWriter = createWriterAgent "StopAfterThree"

stopAfterStopMessageWriter.Post (WriteData "one")
stopAfterStopMessageWriter.Post StopWriting

for msg in ["one"; "two"; "three"; "four"; "five"] do
    stopAfterThreeWriter.Post (WriteData msg)
