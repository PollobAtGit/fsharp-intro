module OneHundresNine

open System

type Bed(shape) =
    member __.GetShape = shape

let displayShapes (bed: Bed) = bed.GetShape

let isShapeDefined =
    Bed("random shape")
    |> displayShapes
    |> String.IsNullOrWhiteSpace
    |> not

// let add x y = x + y
// let sub x y = x - y
// let v = add >> sub
// fst (2, 4)
// snd (4,5)

type Browser =
    { OperatingSystem: string
      RamUSage: int }

let defaultBrowser = { OperatingSystem = ""; RamUSage = 0 }

let print x = printfn $"{x}"

let modifiedBrowser =
    { defaultBrowser with
          OperatingSystem = "Windows 10" }

let linuxBrowser =
    { defaultBrowser with
          OperatingSystem = "Linux" }

print defaultBrowser
print modifiedBrowser
print linuxBrowser

type ChromeBrowser =
    { BrowserVersion: string }

    member __.Get option =
        match option with
        | "-v" -> $"Current version: {__.BrowserVersion}"
        | _ -> failwith "option not recognized"

let browser = { BrowserVersion = "1.3" }

browser.Get "-v" |> print
browser.Get "-t" |> print

type Member = { Name: string }
type Developer = { Id: string; Name: string }
type Qa = { Id: string; Name: string }

type BacklogItemState =
    | Todo
    | InProgress of Developer
    | Done
    | Verify of Qa

type ProductBacklogItem =
    { Id: string
      Description: string
      State: BacklogItemState }

    member __.IsDone =
        match __.State with
        | Done -> true
        | _ -> false

    member __.GetAssignedTo =
        match __.State with
        | InProgress (dev) -> Some { Name = dev.Name }
        | Verify (qa) -> Some { Name = qa.Name }
        | _ -> None

let getGuid () = Guid.NewGuid().ToString()

let pbi =
    { Id = getGuid ()
      Description = getGuid ()
      State = InProgress({ Id = getGuid (); Name = "Pollob" }) }

let pbiInVerifyState =
    { Id = getGuid ()
      Description = getGuid ()
      State = Verify({ Id = getGuid (); Name = "Pollob QA" }) }

let pbiInDoneState =
    { Id = getGuid ()
      Description = getGuid ()
      State = Done }

pbi |> print
pbi.GetAssignedTo |> print
pbiInVerifyState.GetAssignedTo |> print
pbiInDoneState.GetAssignedTo |> print
