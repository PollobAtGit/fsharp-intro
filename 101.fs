module OnHundreOne

let r =
    let isOdd x = x % 2 <> 0
    let square x = x * x
    let isGreaterThen x = x > 1000

    List.filter isOdd [ 0 .. 99 ]
    |> List.map square
    |> List.filter isGreaterThen

let addOneAndSquareOnOdds n =
    let isOdd x = x % 2 <> 0
    let square x = x * x
    let addOne x = x + 1


    List.filter isOdd [ 0 .. n ]
    |> List.map (fun x -> x |> square |> addOne)

addOneAndSquareOnOdds 18 |> ignore

let double x = x * 2
let qube x = x * 3
let result = 23 |> double |> qube

printfn $"Arithmetic operation result is {result}"

let mul x y = x * y
let mulByFive x = mul x 5

let rr =
    5 |> fun x -> double x |> fun x -> qube x

let anotherResult = 5 |> double |> qube |> mul 10

printfn $"arithmetic result {rr}"
printfn $"arithmetic result {anotherResult}"

let combineDoubleAndSquare = double >> qube

printfn $"Result {combineDoubleAndSquare 10}"

let operated =
    let doubleThenQubed = [ 0 .. 99 ] |> List.map (double >> qube)

    let qubeThenDoubled =
        [ 0 .. 99 ]
        |> List.map (qube >> double >> fun x -> x + 9)

    (doubleThenQubed, qubeThenDoubled)

printfn $"Result {operated}"

let emptySeq = []

let squares = [ for i in [ 1 .. 99 ] -> i * 5 ]

let matrix =
    [ for i in [ 1 .. 10 ] do
          for j in [ 31 .. 40 ] do
              yield (i, j) ]

let sumByResult = [ 1 .. 10 ] |> List.sumBy (fun x -> x)
let sequence = [ 1 .. 10 ]

[ 55 .. 123 ].Head |> ignore
[ 55 .. 123 ].Tail |> ignore
[ 55 .. 123 ].Tail.Head |> ignore
[ 55 .. 123 ].Item(5) |> ignore
[].IsEmpty |> ignore

let rec summation seq =
    match seq with
    | head :: tail -> head + summation tail
    | [] -> 0

summation [ 1 .. 5 ] |> ignore

[| 1 .. 5 |].Length |> ignore
let words = [| "hello"; "world" |]

[ for w in words do
      if w.Contains("h") then yield w ]
|> ignore

let q = [ for w in words -> w ]

[ for x in [ 1 .. 99 ] do
      if x % 5 = 0 then yield x ]
|> ignore

let nums = [| 1 .. 22 |]
nums.[1] <- -99

let greetings =
    seq {
        yield "hello"
        yield "ola"
    }

let _nums = seq { 1 .. 10 }

[ for i in _nums -> i + i ] |> ignore

List.init 100 (fun x -> x + 2) |> ignore

type Person =
    { Name: string
      Phone: string
      Id: int }

let person =
    { Name = "john"
      Phone = "0122"
      Id = 5 }

let anotherPerson =
    { Name = "john"
      Phone = "0122"
      Id = 5 }

type PersonWithVerification =
    { Name: string
      Phone: string
      Id: int
      Verified: bool }

let alsoAnotherPerson =
    { Name = "john"
      Phone = "0122"
      Id = 5
      Verified = false }

printfn $"Defined person {alsoAnotherPerson}"

let personFromAnother =
    { person with
          Name = "Another Person"
          Id = 89 }

printfn $"Defined person {personFromAnother}"

let decorate (person: Person) =
    let isNewPersonRepresentation = if person.Id = 0 then "Y" else "N"

    $"Name: {person.Name}; Is new person? {isNewPersonRepresentation}"

decorate { person with Id = 0 } |> ignore
decorate person |> ignore

[<Struct>]
type Player = { Team: string; PlaysFor: string }

let player = { Team = "new jursey"; PlaysFor = "BD" }

type NID = NID of string
let unWrapNId (NID nId) = nId
let nid = NID "568-(x)"
printfn $"NID -> {nid}"
printfn $"NID -> {nid |> unWrapNId}"
