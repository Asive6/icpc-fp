module ICPC
open System
open System.Diagnostics

let commaSprinkler (input:string) = 
    let xs = input.Split(' ')
    let res = Array.toList xs
    let tester a =
        match a = "."with
        |true-> false
        |_ -> true
    let tester2 (a:string) =
        match a.EndsWith('?') with
        |true-> false
        |_ -> true

    let a = List.exists tester res
    let b = List.exists tester2 res
    let check (text:string) =
        match res.[0].Length<=1 ||text.StartsWith(' ')||text.EndsWith(' ')||a ||b with
        |true -> None
        |_ -> Some true
    check input
    //failwith "Not implemented"

let rivers (input:string) =
    let xs = input.Split(' ')
    let result = Array.toList xs
    let tester a =
        match a = ""with
        |true-> false
        |_ -> true

    let check (text:string) =
        match List.exists tester result|| xs.Length<=2 || text.EndsWith(' ') ||text.StartsWith(' ')||text.Contains(',')||text.Contains('!') with
        |true -> None
        |false -> Some text

    check input
   // failwith "Not implemented"
   
[<EntryPoint>]
let main argv =  
    printfn "Hello World from F#!"
    0 // return an integer exit code
