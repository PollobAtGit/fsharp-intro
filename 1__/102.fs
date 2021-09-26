module HundredAndTwo

type Employee =
    { Id: int
      Company: string
      Department: string }

    member this.getDisplayData =
        $"I am [{this.Id}] working for company [{this.Company}]"

    member this.HasBeenAssignedToAnyDepartment = this.Department <> ""

let OperationOnEmployee (e: Employee) =
    printfn $"{e.getDisplayData}"
    printfn $"{e.HasBeenAssignedToAnyDepartment}"

OperationOnEmployee
    { Id = 5
      Company = "Dummy"
      Department = "Accounting" }

OperationOnEmployee
    { Id = 10
      Company = "Show Company"
      Department = "" }

type Shape =
    | Rectangle of string
    | Circle of radius: float
    | Square of length: float
    | Prism

let r =
    Rectangle("rectangle with width 2 & length 3")

let square = Square(length = 5.)

printfn $"{r}"
printfn $"{square}"

type Generic<'a> =
    | Length of 'a
    | Width of 'a

let g = Length(5)

let intOpt = Some(5)

let convertToString v =
    match v with
    | Some i -> $"Value: {i}"
    | None -> "Nothing found"

printfn $"{convertToString intOpt}"
printfn $"{convertToString None}"

let floatOpt = Some(0.23)
printfn $"{convertToString floatOpt}"

let getShapeStr (s: Shape) =
    match s with
    | Rectangle (s) -> s
    | Circle (r) -> $"Radius {r}"
    | Square (l) -> $"Length {l}"
    | _ -> "nothing found"

let c = Circle(3.23)

printfn $"Get Shape's string representation: {getShapeStr r}"
printfn $"Get Shape's string representation: {getShapeStr square}"
printfn $"Get Shape's string representation: {getShapeStr c}"

type Shader = ShaderProgram of id: int

let (ShaderProgram id) = ShaderProgram(id = 55)

printfn $"ID: {id}"

let workOnId (ShaderProgram id) = $"Unwrapped value: {id}"

let ninetyNine = ShaderProgram(id = 99)

printfn $"{workOnId ninetyNine}"

type GeomatricShape =
    | Circle of float
    | Rectangle of float * float
    | Square of float
    | Polygon of float * float * float

let area shape =
    match shape with
    | Circle (r) -> 3.1416 * r * r
    | Rectangle (w, l) -> w * l
    | Square (l) -> l * l
    | _ -> failwith "unmatched shape"

printfn $"Area: [{area (Circle(3.5))}]"
printfn $"Area: [{area (Rectangle(3.5, 5.))}]"
printfn $"Area: [{area (Square(0.5))}]"
printfn $"Area: [{area (Polygon(0.5, 0.6, 0.7))}]"

type Sport =
    | Cricket of string
    | Football of string
    | VolleyBall of string

    member this.Players = $"{this}"

let cricket = Cricket("john, johnson")
let football = Football("johnson")
let volleyBall = VolleyBall("dimitri")

printfn $"Players: {cricket.Players}"
printfn $"Players: {football.Players}"
printfn $"Players: {volleyBall.Players}"

type IPrintable =
    abstract Print : unit -> unit

type Documentation =
    | CSharp
    | FSharp
    | JavaScript

    member this.Show = $"Show: {this}"

    interface IPrintable with
        member __.Print() = printfn "From instance print"

let documentation = CSharp

printfn $"{documentation.Show}"
(documentation :> IPrintable).Print()
