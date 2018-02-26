open FSharp.Data
open System

type Grants = CsvProvider<"https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201101.csv">

[<EntryPoint>]
let main argv =
    use grants = new Grants()
    
    0
