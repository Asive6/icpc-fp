module ICPC
open System

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
        let VerifiedText = IsText words
        match VerifiedText with   //if input follows all the rules of what is a valid text
        | false -> None        
        |true -> 
             let xs = words.Split(' ')
             let lst = MySplitter xs 0
             match lst with
             |[] -> None// end of list
             |curr :: tail -> 
                match curr.EndsWith(','),curr with
                |true,c ->
                    let xs = c.Substring(1)
                    Some (FindAndAdd tail xs 0 )
                |_ -> None
                
        
        |_ -> None
    
    failwith "Not implemented"
    

    
let rivers input =
    failwith "Not implemented"
   
[<EntryPoint>]
let main argv =  
    printfn "Hello World from F#!"
    0 // return an integer exit code
