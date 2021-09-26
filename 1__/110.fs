module OneHundredTen

open System
open System.IO
open FSharp.Data

let print v = printfn $"{v}"

type Conference(code) =

    let title = ""

    member val Title = title with get, set

    // multiple constructors
    new() = Conference(Guid.NewGuid().ToString())

    member __.GetCode = code

    static member Print = print "from static member [Print]"

Conference().GetCode |> print
Conference("dummy code").GetCode |> print

Conference.Print

let conf = Conference()

conf.Title |> print

conf.Title <- "Introduction to F#"

conf.Title |> print

"C:/me-repo/fsharp/Program.fs"
|> File.ReadAllText
|> print

type IReader =
    abstract member Read : string -> string

type FileReader(path) =
    member __.Content = path |> File.ReadAllText |> print

type IWriter =
    abstract member Write : string -> string -> unit

type CsvReader() =
    interface IReader with
        member __.Read path = path |> File.ReadAllText

    interface IWriter with
        member __.Write path content = File.WriteAllText(path, content)

let r = CsvReader()

"C:/me-repo/fsharp/TEST.fs"
|> (r :> IReader).Read
|> print

(r :> IWriter).Write "C:/me-repo/fsharp/TEST.fs" "TESTING"

type IWebClient =
    abstract member LoadHtml : string -> HtmlDocument

type WebClient() =
    interface IWebClient with
        member __.LoadHtml url = HtmlDocument.Load url

    member __.LoadHtml url = url |> (__ :> IWebClient).LoadHtml


// "https://www.google.com/" |> WebClient().LoadHtml
