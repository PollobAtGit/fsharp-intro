let print v = $"{v}"

// use multiple
type Office(address) as __ =

    let mutable officeTitle = ""

    // standard approach to mutate private variable
    let mutable address = address

    do
        // perform random work other then defining let bindings
        printfn "hello from ctor"
        printfn "hello from ctor"

    do address <- "sneaky"

    // accessing this in 'do' code block
    do printfn $"{__.GetAddress}"

    member __.ChangeAddress newAddress = address <- newAddress

    member __.GetAddress = address

    member __.Title
        with get () = officeTitle
        and set (title) =
            printfn "TITLE"
            printfn $"{title}"
            officeTitle <- title

let o = Office("dhanmondi") // , "awesome office"

o.GetAddress |> print
// o.Title |> print

o.ChangeAddress("basabo")
// o.Title = $"very {o.Title}"

o.GetAddress |> print
// o.Title |> print

// interesting. pipe goes on both sides
printfn "%s" <| o.GetAddress

open System

o.Title |> print

// property setter
o.Title <- Guid.NewGuid().ToString()

type Calculator() as __ =

    member __.Add x y = x + y

    member __.Sub(x, y) = x - y

let addWithFive x = x |> Calculator().Add 5

[ 1 .. 10 ] |> List.map addWithFive

addWithFive 10 |> print
addWithFive 9 |> print

type Employee(nid, email, name) as __ =

    let print v = $"{v}"

    let getValueOrEmpty v =
        match (String.IsNullOrWhiteSpace v) with
        | true -> ""
        | false -> $"{v.Trim()} "

    new(nid) = Employee(nid, "", "")
    new(nid, email) = Employee(nid, email, "")
    with
        override ___.ToString() =
            print $"{getValueOrEmpty nid}{getValueOrEmpty email}{getValueOrEmpty name}"

Employee(Guid.NewGuid().ToString()) |> print

Employee(Guid.NewGuid().ToString(), "email")
|> print

Employee(Guid.NewGuid().ToString(), "email", "name")
|> print
