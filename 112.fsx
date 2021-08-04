let print v = printfn $"{v}"

type Os =
    | Windows
    | Linux

type Computer(ram, os) as __ =

    let mutable curentRam = ram
    let mutable currentOs = os

    member __.Ram
        with get () = curentRam
        and set (v) = curentRam <- v

    member __.OperatingSystem
        with get () = currentOs
        and set (v) = currentOs <- v

type DellXPS() as __ =
    inherit Computer(32, Windows)

    member __.HandleKeyPress key = printfn $"Pressed key {key}"
    with
        override __.ToString() =
            $"OS: {__.OperatingSystem}; RAM: {__.Ram}"

DellXPS().ToString() |> print

type IWebClient =
    abstract member Perform : unit -> unit

[<AbstractClassAttribute>]

// same as interface?
type WebClient() =
    abstract member Perform : unit -> unit

type HttpWebClient() =

    abstract member Perform : unit -> unit

    // because we have a default implementation we didn't need [<AbstractClassAttribute>] attribute
    default __.Perform() = printfn ""

type ICalculator =
    abstract member Add : int -> int -> int

type Calculator() as __ =
    interface ICalculator with
        member __.Add x y = x + y

    abstract Add : int -> int -> int
    default __.Add x y = (__ :> ICalculator).Add x y

type LoanCalculator() as __ =
    inherit Calculator()

    // override Calculator.Add which is abstract (default is part of the abstract definition) not ICalculator implementation
    override __.Add x y = x * y

6 |> Calculator().Add 5
6 |> LoanCalculator().Add 5

type Boxer() as __ =
    abstract member LeftHook : unit -> unit
    default __.LeftHook() = printfn "Punched"

type MayWeather() as __ =
    inherit Boxer()

    // overridden properties and methods are not members
    override __.LeftHook() = printfn "mayWeather punches"

type Freezer() as __ =
    inherit Boxer()

    // getting base.LeftHook

Boxer().LeftHook()
MayWeather().LeftHook()
Freezer().LeftHook()
