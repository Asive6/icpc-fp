module ICPC
open System
open System.Diagnostics

let commaSprinkler (input:string) = 
    let xs = input.Split(' ')
    let res = Array.toList xs
    let NoFullstop a =
        match a = "."with
        |true-> false
        |_ -> true
    let NoPunc (a:string) =
        match a.EndsWith('?') with
        |true-> false
        |_ -> true

    let a = List.exists NoFullstop res
    let b = List.exists NoPunc res
    let check (text:string) =
        match res.[0].Length<=1 ||text.StartsWith(' ')||text.EndsWith(' ') ||a || b with
        |true -> None
        |_ ->Some true
    
    //function to add commas before or after 
    let AddComma input indicator =
        match indicator with
        |0 -> sprintf "%s%s" "," input
        |_ -> sprintf "%s%s" input ","
    let rec FindAndAdd (list:string list) word x =
        match list with 
        |[] -> "" //not sure what to return yet
        |curr::tail ->
            let xs = curr.Substring(0,curr.Length-1)
            match curr.EndsWith('.'), curr=word  with
            |false,true -> AddComma curr x
            |false,_ -> FindAndAdd tail word x
            |true,_ ->curr //if the next matching word is followed by a full stop then
        |_-> ""
   // check input
            
    let IsValidInput = check input
    match IsValidInput with
    |None -> None
    |Some true -> 
        Some(
         let rec Sprinkler (lst:string list) acc =
            match lst with
            |[] -> ""
            |curr::tail -> 
                match curr.ToString().StartsWith(','),curr with 
                | true,c -> FindAndAdd tail curr 0 //look for other occurences of curr and add , before them
                |_-> 
                    let curr= string curr
                    match curr.EndsWith(',')&&curr.Length<>1,curr with
                    |true,c-> FindAndAdd tail curr 1 //look for other occurences of curr and add , before them
                    |_,_ ->  Sprinkler tail (acc+1)       // compare the next word
                //look for occurences of curr and add comma
         let ans =Sprinkler res
         ans.ToString 
        )
       

    |_ -> None
    
   //check
   // failwith "Not implemented"

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
    let a =commaSprinkler "to be, or not to be? that is the question."
    0 // return an integer exit code
