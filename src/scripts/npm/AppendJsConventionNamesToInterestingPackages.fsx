open System
open System.IO

let dataDir = "C:\\Dev\\Data\\RepoHunt\\npm"
let inputDir = Path.Combine(dataDir, "input")
type PackageAndDescription = {Package: string; Description: string}

let interestingPackagesCsvFile = Path.Combine(dataDir, "InterestingPackages.csv")
if not (File.Exists interestingPackagesCsvFile) then 
    raise(FileNotFoundException("Need to create packages from views first"))

let namesFile = Path.Combine(inputDir, "Names.txt")
if not (File.Exists namesFile) then 
    raise(FileNotFoundException("Need to create Names.txt first"))


(*    
    Patterns to detect:
    <Pop> = <PopularPackageName>
    
    <Pop>cli
    <Pop>.Replace("-", "")
    <Pop>.Replace("_", "")
    <Pop>.Replace(".", "")
    <Pop>.js
    <Pop>-js
    <Pop>_js
    <Pop>js
    <Pop>-node
    node<Pop>
    node-<Pop>
    node_<Pop>
*)

let allPackageNames = File.ReadAllLines(namesFile) |> Set.ofArray

let findSimilarToEndsWith (test: string) (suf: string) =
    let similarToPackageName =  if test.EndsWith(suf) then 
                                    test.Substring(0, test.Length - suf.Length) 
                                else (test + suf)
    if allPackageNames.Contains(similarToPackageName) then
        Some similarToPackageName
    else 
        None

let findSimilarToStartsWith (test: string) (pre: string) =
    let similarToPackageName = if test.StartsWith(pre) then test.Substring(pre.Length) else (pre + test)
    if allPackageNames.Contains(similarToPackageName) then
        Some similarToPackageName
    else 
        None

let findSimilarToReplaced (test: string) (c: string) =
    let similarToPackageName = test.Replace(c, "")
    if allPackageNames.Contains(similarToPackageName) then
        Some similarToPackageName
    else 
        None

let isSuffixFuncs suf =
    [
        (fun (test: string) -> findSimilarToEndsWith test (suf))
        (fun (test: string) -> findSimilarToEndsWith test ("-" + suf))
        (fun (test: string) -> findSimilarToEndsWith test ("." + suf))
        (fun (test: string) -> findSimilarToEndsWith test ("_" + suf))
    ]
let isPrefixFuncs pre =
    [
        (fun (test: string) -> findSimilarToStartsWith test pre)
        (fun (test: string) -> findSimilarToStartsWith test (pre + "-"))
        (fun (test: string) -> findSimilarToStartsWith test (pre + "."))
        (fun (test: string) -> findSimilarToStartsWith test (pre + "_"))
    ]

let isReplaceFuncs =
    [
        (fun (test: string) -> findSimilarToReplaced test "-")
        (fun (test: string) -> findSimilarToReplaced test "_")
        (fun (test: string) -> findSimilarToReplaced test ".")
    ]

let findingFuncs = [ isPrefixFuncs "node"; isSuffixFuncs "node"; isSuffixFuncs "js"; 
                        isSuffixFuncs "cli"; isReplaceFuncs ] 
                        |> List.fold (fun agg el -> List.concat [agg; el]) []
let findSimilarPackages name =
    findingFuncs 
    |> List.map (fun x -> x(name))
    |> List.choose id
    |> List.filter (fun x -> x <> name)

let dubiousPackages = allPackageNames 
                        |> Set.toList
                        |> List.map (fun x -> x, findSimilarPackages x)
                        |> List.collect (fun x ->
                            let name = fst x
                            (snd x) |> List.map (fun x -> name, x)
                        )
                        |> List.collect (fun x -> [fst (x); snd (x)])
                        |> List.distinct

let description = "NpmNamingConvention"

let values = dubiousPackages |> List.map (fun x -> {Package = x; Description = description})
let toCsvLine x =
    sprintf "\"%s\",\"%s\"" x.Package x.Description
let lines = values |> List.map toCsvLine

File.AppendAllText(interestingPackagesCsvFile, Environment.NewLine)
File.AppendAllLines(interestingPackagesCsvFile, lines) |> ignore