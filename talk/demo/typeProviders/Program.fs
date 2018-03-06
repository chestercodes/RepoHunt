open FSharp.Data
open FSharp.Data.Sql


let [<Literal>] CsvUrl = "https://raw.githubusercontent.com/Devon-County-Council/spending/master/DCCSpendingOver500_201801.csv"
type Grants = CsvProvider<CsvUrl>


[<EntryPoint>]
let main argv =
    use grants = new Grants()
    
    // inspect grant first row




    // find top 10 expenses from 01/2018
    
    // print out top 10

    // save to ./Suppliers.sqlite db table top_10_expenses

    0












(*

let [<Literal>] CsvSchema = ",,Date=String,,,,,,,,,Expense Code=String,"
type Grants = CsvProvider<CsvUrl, Schema=CsvSchema>

let [<Literal>] ConnectionString = "Data Source=" + __SOURCE_DIRECTORY__ + "\\Suppliers.sqlite;Version=3;foreign keys=true"

type Sql = SqlDataProvider<
                Common.DatabaseProviderTypes.SQLITE,
                SQLiteLibrary = Common.SQLiteLibrary.SystemDataSQLite,
                ConnectionString = ConnectionString,
                ResolutionPath = "C:\\Users\\cburbidge\\.nuget\\packages\\system.data.sqlite.core\\1.0.106\\lib\\net46",
                CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>
let ctx = Sql.GetDataContext()

*)