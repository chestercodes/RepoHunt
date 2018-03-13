[<EntryPoint>]
let main argv =

    printfn "\n  Hello world!\n"

    0














(*

open FSharp.Data
let [<Literal>] CsvUrl = "https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201801.csv"
type Grants = CsvProvider<CsvUrl>
let grants = new Grants()
type SupplierAmount = {SupplierName: string; Amount: decimal}



let [<Literal>] CsvSchema = ",,Date=String,,,,,,,,,Expense Code=String,"
type Grants = CsvProvider<CsvUrl, Schema=CsvSchema>



open FSharp.Data.Sql
let [<Literal>] ConnectionString = "Data Source=" + __SOURCE_DIRECTORY__ + "\\Suppliers.sqlite;Version=3;foreign keys=true"
type Sql = SqlDataProvider<
                Common.DatabaseProviderTypes.SQLITE,
                SQLiteLibrary = Common.SQLiteLibrary.SystemDataSQLite,
                ConnectionString = ConnectionString,
                ResolutionPath = "C:\\Users\\cburbidge\\.nuget\\packages\\system.data.sqlite.core\\1.0.106\\lib\\net46",
                CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>
let ctx = Sql.GetDataContext()

*)