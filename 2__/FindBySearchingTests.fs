module Tests

    open FindBySearching
    open System
    open Xunit

    let getFromNumbers x = getByNumber numbers x
    let getFromDic ky = getByKey numbersWithDescription ky

    [<Fact>]
    let ``Return numbers list which should not be empty`` () =
        Assert.True(numbers.Length > 0)
    
    [<Fact>]
    let ``Must not contain 2`` () =
        Assert.True( (getFromNumbers 2) = SENTINEL_VALUE )

    [<Fact>]
    let ``Must contain 3`` () =
        Assert.True( (getFromNumbers 3) = 3 )
        Assert.True( (getFromNumbers 3) <> SENTINEL_VALUE )

    [<Fact>]
    let ``Must not contain tuple with key=1 and value=THREE`` () =
        let ( _, v ) = getFromDic 1
        let isOne = v = "ONE"
        Assert.True( isOne )

