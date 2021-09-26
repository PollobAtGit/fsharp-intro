module Tests

    open FindBySearching
    open System
    open Xunit

    [<Fact>]
    let ``My test`` () =
        Assert.True(true)

    [<Fact>]
    let ``This should fail for no reason`` () =
        Assert.True(false)

    [<Fact>]
    let ``Return numbers list which should not be empty`` () =
        Assert.True(numbers.Length > 0)


