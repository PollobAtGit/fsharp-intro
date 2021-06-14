module OneHundredAndFive

type ISprintable =
    abstract member Print : text: string -> unit

type INumeric =
    abstract member Add : x: int * y: int -> int

type Numeric() =
    interface INumeric with
        member __.Add(x, y) = x + y

type Sprintable() =

    member __.Print text = (__ :> ISprintable).Print text

    interface ISprintable with
        member __.Print text = printfn $"{text}"

// interface members can only be accessed via upcast operator
printfn $"{(Numeric() :> INumeric).Add(89, 56)}"

// using an additional member method to delegate operation ti interface to make sure upcast is not required
Sprintable().Print("FSharp")

type ISport =
    abstract member Play : unit // declare method without argument without specifiying unit

type ISound =
    abstract member MakeSound : string -> uint

type IMutator =
    abstract member Map : value: string -> string

type IUseless =
    abstract member Do : uint

type Implementor() =

    interface ISport with
        member __.Play = printfn "Play"

    interface IMutator with
        member __.Map value = value + "_MUTATED"

// interface ISound with
//     member __.MakeSound sound = printfn "Play"

let implementor = Implementor()

(implementor :> ISport).Play

let mutatedValue = (implementor :> IMutator).Map("Do")

printfn $"{mutatedValue}"

type ICombinedInterface =
    inherit ISport
    inherit IMutator

    // make return type unit and make it work
    abstract member InvokeAll : string

type CombinedInterface() =

    interface ICombinedInterface with
        member __.Play = printfn "Play"
        member __.Map value = value + "_MUTATED"
        member __.InvokeAll = "fake invoked"
        
let implementation = CombinedInterface()

(implementation :> ISport).Play

// (implementation :> IUseless).Do
