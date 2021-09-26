module OneHundredSeven

type Player() =
    abstract member Play : unit
    default __.Play = printfn "I am a player"

type FootbalPlayer() =
    inherit Player()
    override __.Play = printfn "I am a football player" // with override we don't need 'member' keyword

FootbalPlayer().Play
Player().Play

type Game(game: string) =
    let mutable name = game
    member __.ChangeName n = name <- n
    member __.Name = name

let g = Game("random name")

printfn $"{g.Name}"

g.ChangeName "football"

printfn $"{g.Name}"

type Editor =
    val PreferredLanguage: string // what is this? not instance member apparently
    new(lang) = { PreferredLanguage = lang }
    new() = { PreferredLanguage = "C#" }

let cSharpEditor = Editor()

printfn $"{cSharpEditor.PreferredLanguage}"

let editor = Editor("JS")

printfn $"{editor.PreferredLanguage}"
printfn $"{cSharpEditor.PreferredLanguage}"

type JSEditor =
    inherit Editor
    new() = { inherit Editor("JS") }

let jsEditor = JSEditor()

printfn $"{jsEditor.PreferredLanguage}"

type Browser =
    { OperatingSystem: string
      RamUsage: int }
