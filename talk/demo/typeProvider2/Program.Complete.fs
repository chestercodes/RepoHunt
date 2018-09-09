open FSharp.Data
open FSharp.Data.Sql

let [<Literal>] CsvSchema = """,,Date=String,,,,,,,,,Expense Code=String,"""
let [<Literal>] CsvUrl = "https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201801.csv"
type Grants = CsvProvider<CsvUrl, Schema=CsvSchema>
let [<Literal>] ConnectionString = "Data Source=" + __SOURCE_DIRECTORY__ + "\\Suppliers.sqlite;Version=3;foreign keys=true"

type Sql = SqlDataProvider<
                Common.DatabaseProviderTypes.SQLITE,
                SQLiteLibrary = Common.SQLiteLibrary.SystemDataSQLite,
                ConnectionString = ConnectionString,
                ResolutionPath = "C:\\Users\\cburbidge\\.nuget\\packages\\system.data.sqlite.core\\1.0.106\\lib\\net46",
                CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>
let ctx = Sql.GetDataContext()

[<EntryPoint>]
let main argv =
    use grants = new Grants()
    let first = grants.Rows |> Seq.head
    
    let top10 = grants.Rows 
                |> Seq.groupBy (fun x -> x.``Supplier Name``)
                |> Seq.map (fun x -> 
                    let name = fst x
                    let totalAmount = snd x |> Seq.sumBy (fun y -> y.Amount)
                    name, totalAmount
                )
                |> Seq.sortByDescending snd
                |> Seq.take 10

    for supplier in top10 do
        let name = fst supplier
        let amount = float (snd supplier)
        printfn "supplier - %s, amount - %s" name (amount.ToString("0.00"))

        ctx.Main.Top10Expenses.``Create(supplier_name, total)``(name, amount) |> ignore

    ctx.SubmitUpdates() |> ignore
                
    
    0


