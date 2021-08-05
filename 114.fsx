open System

let print v = printfn $"{v}"

// like C# in all interface members has to be implemented
type ICalculator =
    abstract member Multiply : int -> int -> int

type ILoanCalcualtor =
    abstract member CalcualteLoan : float -> float

let calculator =
    { new ICalculator with
        member __.Multiply x y = x * y }

// casting is not required while with class casting is required
print (calculator.Multiply 6 5)

type Employee = { NationalId: string }

let getLoanCalculator (employee: Employee) =
    { new ILoanCalcualtor with
        member __.CalcualteLoan x =

            print $"Employee Id: {employee.NationalId}" 

            x * float 10 }

let c = getLoanCalculator { NationalId = Guid.NewGuid().ToString() }
c.CalcualteLoan (float 230) |> print

// in this cases (where object expression has been used)
// the variable name is used when ToString() is invoked

print calculator
print c

type Calculator() as __ =
    interface ICalculator with
        member __.Multiply x y = x * y * 10

print (Calculator())

// for the following ICalculator is not the type eve though it's casted to ICalculator
// rather ToString() returns Calculator

print (Calculator() :> ICalculator)

