open System
open System.Net
open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators
open Suave.RequestErrors
open Cards

let someTest x y z =
    match x, y with
    | triple when fst triple <> snd triple -> true
    | _ -> false

let optionTest o =
    match o with
    | Some(1) -> "This is one"
    | Some(x) -> "I don't know, what is this"
    | None -> "This is nothing"

let cardDeckStr = Utils.CardDeckGenerator |> List.map (sprintf "%A") |> fun listTmp -> String.Join (", ", listTmp)

[<EntryPoint>]
let main argv =
    let cfg =
        { defaultConfig with
            bindings =
                [ HttpBinding.create HTTP IPAddress.Loopback 80us
                  HttpBinding.createSimple HTTP "127.0.0.1" 9000 ]
            listenTimeout = TimeSpan.FromMilliseconds 3000. }
    let webPart =    
        choose [
            path "/" >=> (OK "Hello world project")
            path "/about" >=> (OK "This is desctiption of F# project")
            path "/cards" >=> (OK cardDeckStr)
            path "/cards/%s" >=> (OK "Will be soon")
            NOT_FOUND "Page not found"
        ]    
    startWebServer cfg webPart
    0
