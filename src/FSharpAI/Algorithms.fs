module Algorithms

open System
open System.IO

module Test = 
    
    let rec quickSort (data:int list) = 
        match data with
        | [] -> []
        | [a] -> [a]
        | head::tail ->
            let l0 = 
                tail
                |> List.filter ((<=) head)
            let l1 = 
                tail
                |> List.filter ((>) head)
            quickSort(l0) @ [head] @ quickSort(l1)
