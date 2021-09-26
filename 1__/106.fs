module OneHundredSix

[<AbstractClassAttribute>]
type BaseShape() =
    member __.ShapeDescriptor = "FROM BASE DESCRIPTOR"
    abstract Area : float -> float

type Square() =
    inherit BaseShape()
    override __.Area v = v * 89.0

type Circle() =
    inherit BaseShape()
    override __.Area v = v + 78.9

type Rectangle() =
    inherit BaseShape()
    override __.Area v = v + 56.667

let s = Square()

printfn $"{s.Area 4.8}"
printfn $"{s.ShapeDescriptor}"

type BasePerson() =
    let mutable salary = 0.0

    member __.ChangeSalary
        with get () = salary
        and set newSalary = salary <- newSalary

let p = BasePerson()

p.ChangeSalary <- 90.99

printfn $"Current Salary: {p.ChangeSalary}"

p.ChangeSalary <- 56.67

printfn $"Current Salary: {p.ChangeSalary}"

let shapes : list<BaseShape> =
    [ (Circle() :> BaseShape)
      (Square() :> BaseShape)
      (Rectangle() :> BaseShape) ]

List.iter (fun (x: BaseShape) -> printfn $"AREA => {x.Area 10.89}") shapes
