module FindBySearching

    let SENTINEL_VALUE = -3

    let numbers = [ 1 .. 2 .. 10 ]
    
    let numbersWithDescription = [ (1, "ONE") ; (2, "TWO") ; (1, "THREE") ; (4, "FOUR") ; (5, "FIVE") ] 

    let getByNumber sequence valueToSearch = 
        try
            sequence |> List.find ( fun (x) -> x = valueToSearch )
        with
            | :? System.Collections.Generic.KeyNotFoundException as e -> SENTINEL_VALUE

    let getByKey dictionary ky = 
        try
            dictionary |> List.find ( fun ( x, y ) -> x = ky )
        with
            | :? System.Collections.Generic.KeyNotFoundException as e -> ( SENTINEL_VALUE, "SENTINEL_VALUE" )

