let nums = [1 .. 20]

let fizzbuzz1 n = 
    match n with
    | x when x % 15 = 0 -> "FizzBuzz"
    | x when x % 3 = 0  -> "Fizz"
    | x when x % 5 = 0  -> "Buzz"
    | x                 -> x.ToString()

let fb = nums |> List.map fizzbuzz1

let (|DividesBy|_|) modN n = if n % modN = 0 then Some n else None 
let fizzbuzz2 n = 
    match n with
    | DividesBy 15 _ -> "FizzBuzz"
    | DividesBy 3  _ -> "Fizz"
    | DividesBy 5  _ -> "Buzz"
    | x              -> x.ToString()

let fb2 = nums |> List.map fizzbuzz2


