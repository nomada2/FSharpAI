open System
open Algorithms

[<EntryPoint>]
let main argv = 

    let unsortedList = [-2; -3; 4; -1; 0; 1; 5; 7; -2]

    let sortedList = Algorithms.Test.quickSort(unsortedList)
    printfn "%A" sortedList

    Console.ReadKey(true) |> ignore

    0
