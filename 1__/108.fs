module OneHundredEight

open System

type CustomerName(firstName, middleName, lastName) =

    let prependWhiteSpce v =
        match (String.IsNullOrWhiteSpace v) with
        | true -> ""
        | false -> $" {v}"

    // constructor variables are accessible here because they are automatically immutable (readonly) private fields
    member __.FirstName = firstName

    member __.Name =
        $"{firstName}{prependWhiteSpce middleName}{prependWhiteSpce lastName}"

CustomerName("John", "Clerk", "Sina")
CustomerName("John", "Clerk", "").Name
CustomerName("John", "", "").Name
CustomerName("", "", "").Name

CustomerName("John", "Clerk", "Sina").FirstName

type Grid =
    new(rowbyColumn: int * int) =
        printfn "using tuple"
    
        // object initializer
        // mandatory in ctor
        { }

    new(row: int, column: int) =
        printfn "using constructor with seperate arguments"

        // object initializer
        // mandatory in ctor
        {  }

Grid(2, 3)
Grid((2, 3))
