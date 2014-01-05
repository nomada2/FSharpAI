#light

open System


let rec quickSort (data:int list) = 
    match data with
    | [] -> []
    | [a] -> [a]
    | head::tail -> 
            let l0 = tail |> List.filter ((<=) head) // using (<) will remove duplicate
            let l1 = tail |> List.filter ((>) head)
            quickSort(l0) @ [head] @ quickSort(l1)

let rec merge ls0 ls1 = 
    match ls0, ls1 with
    | [], [] -> []
    | [], ls | ls, [] -> ls
    | h0::t0, h1::t1 -> 
        if h0 < h1 then [h0] @ merge t0 ls1
        else [h1] @ merge ls0 t1

let rec mergeSort ls =
    match ls with
    | [] -> []
    | [a] -> [a]
    | [a; b] -> [min a b; max a b]
    | _ ->  let firstHalf = ls |> Seq.take (ls.Length /2) |> Seq.toList
            let seconfHalf = ls |> Seq.skip (ls.Length /2) |> Seq.toList
            let sortedFirstHalf = mergeSort firstHalf
            let sortedSeconfHalf = mergeSort seconfHalf
            merge sortedFirstHalf sortedSeconfHalf

let findElement (ls:int list) start target =
    ls |> Seq.skip start |> Seq.tryFind((=) target)

let findSum sum (ls:int list) =
    [ for i in [0..ls.Length - 4] do
        for j in [i + 1..ls.Length-3] do
            for k in [ j + 1..ls.Length-2] do
                let rest = sum - (ls.[i] + ls.[j] + ls.[k])
                let result = findElement ls (k+1) rest
                match result with
                | Some n -> yield (ls.[i], ls.[j], ls.[k], n)
                | None -> () ]

