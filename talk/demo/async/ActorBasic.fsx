
let printerAgent = MailboxProcessor<string>.Start(fun inbox-> 
    // the message processing function
    let rec messageLoop() = async {
        // read a message
        let! msg = inbox.Receive()
        // process a message
        printfn "message is: %s" msg
        // recurse to top
        return! messageLoop ()
    }
    // start the loop 
    messageLoop()
)

printerAgent.Post "hello world!"
printerAgent.Post "hello world! again..."












let printerAgentWithState = MailboxProcessor<string>.Start(fun inbox-> 
    // the message processing function with lastMessage state
    let rec messageLoop lastMessage = async {
        // read a message
        let! msg = inbox.Receive()
        
        // process a message
        printfn "message is: %s" msg

        match lastMessage with
            | None -> ()
            | Some last -> printfn "previous message was: %s" last
        
        // loop to top
        return! messageLoop (Some msg)
        }
    // start the loop 
    messageLoop None
)
