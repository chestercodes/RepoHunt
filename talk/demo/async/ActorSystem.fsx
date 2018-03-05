open System

type WriterMessage = StopWriting | WriteData of string
type ProcessorMessage = Finished | Word of string
let numberParallel = 3
let writerAgent = MailboxProcessor<WriterMessage>.Start(fun inbox-> 
    let rec messageLoop nStopsSeen = async {
        let! msg = inbox.Receive()
        
        match msg with
        | StopWriting -> 
            let nStops = nStopsSeen + 1
            if nStops = numberParallel then
                printfn "finished"
                return ()
            else
                printfn "stop writing received"
                return! messageLoop nStops            
        | WriteData data -> 
            do! Async.Sleep (330)
            printfn "Writer - word %s" data
            return! messageLoop nStopsSeen

    }
    // start the loop 
    messageLoop 0
)
let r = new Random()
let createProcessorAgent agentNumber = MailboxProcessor<ProcessorMessage>.Start(fun inbox-> 
    let rec messageLoop () = async {
        let! msg = inbox.Receive()
        do! Async.Sleep(r.Next(50, 100))
        match msg with
        | Finished -> 
            printfn "Agent %i - finished" agentNumber
            writerAgent.Post StopWriting
            return()
        | Word word -> 
            printfn "Agent %i - word %s" agentNumber word
            writerAgent.Post (WriteData word)
            return! messageLoop()
    }
    messageLoop ()
)
let agentNumbers = [0 .. (numberParallel - 1)]
let agents = agentNumbers |> List.map createProcessorAgent

["one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"; "ten"]
|> List.mapi (fun i word -> 
    let agentIndex = i % numberParallel
    agents.[agentIndex].Post(Word word) 
)
for agent in agents do
    agent.Post Finished