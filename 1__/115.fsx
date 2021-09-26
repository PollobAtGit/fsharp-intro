let print v = printfn $"{v}"
let printCollection v = printfn "%A" v

let emptyList = List.empty
let singleCollection = List.singleton "not - empty"

print emptyList
print singleCollection

print Map.empty
// print Map.singleton 

// Seq is IEnumerable<T> 
// ToString() prints different stuff
print Seq.empty

// It's an object array
print Array.empty

print (List.replicate 3 45)

// valid but ToString returns object name which is RepeatIterator
print (Seq.replicate 3 45)

// maybe replcate is not available for Map?
// print (Map.replicate 3 (3, 5))

// [| ... |] indicates array
printCollection (Array.create 3 0)

// following prints [| null; null; null |]
printCollection (Array.zeroCreate 3)

// casting didn't work
let numbers : int[] = Array.zeroCreate 3
printCollection numbers

// random
print ([3, 4; 5, 7] |> Map)

type Pickle = { OrderId: string }

open System

// ... Guid.NewGuid() ... will be evaluated once only
printCollection (List.replicate 3 { OrderId = Guid.NewGuid().ToString() })

// in ..init.. 1st argument is the index
printCollection (List.init 5 (fun x -> x + 10))

// starting from -10 increment to 10 by 2 at each step
printCollection [-10 .. 2 .. 10]

