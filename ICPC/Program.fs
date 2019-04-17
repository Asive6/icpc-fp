module ICPC
open System
open System.Diagnostics

let commaSprinkler (input:string) = 
    let text = string input 
    let InputArray = text.Split()
    let IsText (text:string) = 
        match text.Length>=1 with 
        |true -> 
            let rec checkchar (txt:string) idx =
                match idx< txt.Length ,(Char.IsLetter(txt.[idx])||txt.[idx]='.'||txt.[idx]=',') with
                |true,true -> checkchar txt (idx+1)
                |true,false -> false
                |false,_-> true
            match checkchar text 0 with
            |true -> true       
            |_ -> false
        |_ -> false

    //let text = string input 
    let InputArray = input.Split()

    let rec MySplitter (words:string []) acc =  //function for spliting text into array
                 // should return an list (char list )
            let wordslength = words.Length
            match acc<wordslength with
            |false -> []
            |true -> 
                match acc<wordslength,words.[acc] with
                | true,x ->x::MySplitter words (acc+1)
                |_ -> []
            
    
    //function to add commas before or after 
    let AddComma input indicator =
        match indicator with
        |0 -> sprintf "%s%s" "," input
        |_ -> sprintf "%s%s" input ","
    
    //look for repeated words and addcomma 
    let rec FindAndAdd (list:string list) word x =
        match list with 
        |[] -> "" //not sure what to return yet
        |curr::tail ->
            match curr.EndsWith('.'), curr=word  with
            |false,true -> AddComma curr x
            |false,_ -> FindAndAdd tail word x
            |true,_ ->curr //if the next matching word is followed by a full stop then

    //something like for int i=0;i<words.length;i++
    let rec f words  acc=
        match words with
        |[]-> None   //base case
        |curr::tail->  // the idea is to compare curr with everything in tail
            match curr.ToString().StartsWith(','),curr with 
            | true,c -> Some (FindAndAdd tail curr 0) //look for other occurences of curr and add , before them
            |_-> 
                let curr= string curr
                match curr.EndsWith(',')&&curr.Length<>1,curr with
                |true,c-> Some (FindAndAdd tail curr 1) //look for other occurences of curr and add , before them
                |_,_ ->  f tail (acc+1)       // compare the next word
                
                 
    let TF = MySplitter InputArray 0
    let results =f TF 0
    results
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
    let ans = commaSprinkler "one, two. one tree. four tree. four four. five four. six five."
    
    0 // return an integer exit code
