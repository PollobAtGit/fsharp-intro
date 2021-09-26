module OneHunderedAndFour

// 1st line is a constructor
type Customer(name: string, nid: string) =
    member __.NatioinalIdCard = nid
    member __.CustomerName = name
    member __.Amount = 0

    member __.Clone appendWith =
        Customer(__.CustomerName + " " + appendWith, __.NatioinalIdCard + " " + appendWith)

let c = Customer("john", "0123-(XY)")

printfn $"{c.CustomerName} || {c.NatioinalIdCard}"

let clonedCustomer = c.Clone "FAKE"

printfn $"{clonedCustomer.CustomerName} || {clonedCustomer.NatioinalIdCard}"

type Container<'T>() =
    let mutable internalContainer = []

    member __.Insert(v: 'T) =
        internalContainer <- v :: internalContainer

    member __.IsEmpty = internalContainer.Length = 0

    member __.CurrentState = internalContainer

let container = Container<int>()

printfn $"IsEmpty Container: [{container.IsEmpty}]"

container.Insert 55
container.Insert 59

printfn $"IsEmpty Container: [{container.IsEmpty}]"

printfn $"Container: {container.CurrentState}"

type Reader(file: string) =

    let reader = new System.IO.StreamReader(file)

    member __.ReadLine = reader.ReadLine()

    interface System.IDisposable with
        member __.Dispose() = reader.Close()

let r = new Reader "readme.txt"

printfn $"Lines: {r.ReadLine}"

let disposableImplementation =
    { new System.IDisposable with
        member __.Dispose() = printfn "Invoked" }

disposableImplementation.Dispose() |> ignore

// when to use paran for method invocation and when not?