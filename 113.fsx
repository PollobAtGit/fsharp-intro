type IWebClient = 
    abstract member Download : string -> string
    abstract member BaseUrl : string with get,set

type IHttpClient =
    abstract member Download : string -> string
    abstract member BaseUrl : string with get,set

// WebClient explicitly implements both IHttpClient and IWebClient
// in essence WebClient has multiple implementations of Download and BaseUrl property

type WebClient() as __ =
    
    let mutable baseUrl = ""

    interface IWebClient with
        member __.Download url = 
            // download content
            
            "from download method :> IWebClient"

        member __.BaseUrl 
            with get() = baseUrl + " from getter :> IWebClient"
            and set(v) = baseUrl <- v

    interface IHttpClient with
        member __.Download url = 
            // download content
            
            "from download method"

        member __.BaseUrl 
            with get() = baseUrl + " from getter"
            and set(v) = baseUrl <- v

let print v = printfn $"{v}"

let webClient = WebClient() :> IWebClient

webClient.Download "" |> print
webClient.BaseUrl |> print

let httpClient = WebClient() :> IHttpClient

httpClient.Download "" |> print
httpClient.BaseUrl |> print

let printWebClientInformation (v : IWebClient) = 
    v.Download "" |> print
    v.BaseUrl |> print

let v = WebClient()

// auto conversion
printWebClientInformation v

// printWebClientInformation accepts only IWebClient not IHttpClient
// printWebClientInformation httpClient

