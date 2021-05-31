module OneHundredThree

type ZipCode = ZipCode of code: string
type Customer = { ZipCode: ZipCode option }

type IShippingCalculator =
    abstract GetState : ZipCode -> string option

type Calculator() =
    interface IShippingCalculator with
        member __.GetState(ZipCode code) = Some $"Code: {code}"

let Calculate (customer: Customer, calculator: IShippingCalculator) =
    match customer.ZipCode with
    | Some code -> calculator.GetState(code)
    | None -> failwith "unmatched zip code"

let customer =
    { ZipCode = Some(ZipCode("(XYZ)-[123]")) }

let r =
    Calculate(customer, Calculator() :> IShippingCalculator)

printfn $"{r}"

printfn "OneHundredThree"
