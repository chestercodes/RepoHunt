open FSharp.Data
let [<Literal>] CsvUrl = "https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201801.csv"    //let [<Literal>] CsvUrl = __SOURCE_DIRECTORY__ + "\\DCCSpendingOver500_201801.csv"
type SupplierAmount = {SupplierName: string; Amount: decimal}
let [<Literal>] CsvSchema = ",,Date=String,,,,,,,,,Expense Code=String,"
type Grants = CsvProvider<CsvUrl, Schema=CsvSchema>
let grants = Grants()

[<EntryPoint>]
let main argv =
    let top10  = grants.Rows 
                |> Seq.groupBy (fun x -> x.``Supplier Name``)
                |> Seq.map (fun g -> 
                    let name = fst g
                    let totes = (snd g) |> Seq.sumBy (fun x -> x.Amount)
                    {SupplierName = name; Amount = totes}
                    )
                |> Seq.sortByDescending (fun x -> x.Amount)
                |> Seq.take 10
    for x in top10 do 
        printfn "%s - %f" x.SupplierName x.Amount

    0
