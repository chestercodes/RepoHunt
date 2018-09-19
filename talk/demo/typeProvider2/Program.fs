
[<EntryPoint>]
let main argv =

    printfn "\n  Hello world!\n"

    0














(*

open FSharp.Data
let [<Literal>] CsvUrl = "https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201801.csv"    // let [<Literal>] CsvUrl = __SOURCE_DIRECTORY__ + "\\DCCSpendingOver500_201801.csv"
type SupplierAmount = {SupplierName: string; Amount: decimal}

type Grants = CsvProvider<CsvUrl>
let grants = new Grants()



let [<Literal>] CsvSchema = ",,Date=String,,,,,,,,,Expense Code=String,"
type Grants = CsvProvider<CsvUrl, Schema=CsvSchema>


*)