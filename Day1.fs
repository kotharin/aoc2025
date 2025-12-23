namespace Day1

module Shared =
    type Direction = Left | Right

module Part1 =

    open System.IO
    open Shared

    let rotate direction length currentLocation =
        let nextLocation =
            match direction with
            | Left ->
                currentLocation - length
            | Right ->
                currentLocation + length

        if (nextLocation < 0) then
            nextLocation%100 + 100
        else
            nextLocation % 100
    let solution file =
        let moves = File.ReadAllLines file

        let _,zeroCounts =
            moves
            |> Array.fold( fun (cl, cc) move ->
                // get the direction and the length
                let dir = move.Substring(0,1)
                let len = move.Substring(1).Trim() |> int
                let direction =
                    if (dir = "L") then
                        Left
                    else Right
                let newLocation = rotate direction len cl
                let newCount = 
                    if (newLocation%100) = 0 then
                        cc + 1
                    else cc
                (newLocation, newCount)
            ) (50,0)
        zeroCounts

module Part2 =
    open System.IO
    open Shared
    let rotate direction length currentLocation =
        let nextLocation =
            match direction with
            | Left ->
                currentLocation - length
            | Right ->
                currentLocation + length

        let passThruCount = 
            if ((currentLocation%100 <> 0)) && (length > 100) then
                length/100
            else
                if (currentLocation%100 = 0) then
                    0
                elif (direction = Left) then
                    if (length > currentLocation) then
                        length/100 + 1
                    else 0
                else
                    if (nextLocation%100 <> 0) then
                        nextLocation/100
                    else
                        nextLocation/100 - 1
        if (nextLocation < 0) then
            nextLocation%100 + 100,passThruCount
        else
            nextLocation % 100,passThruCount
        (*
        if (nextLocation < 0) then
            let passThruCount = 
                if (currentLocation <> 0) then
                    (-1*nextLocation)/100 + 1
                else
                    if (length <=100) then
                        0
                    else
                        length/100
            nextLocation%100 + 100,passThruCount
        else
            let passThruCount = 

                if (nextLocation%100 = 0) then
                    if (currentLocation = 0) then
                        (length/100) - 1
                    else
                        length/100
                else
                    nextLocation/100
            
            nextLocation % 100,passThruCount
        *)
    let solution file =
        let moves = File.ReadAllLines file

        let _,zeroCounts, passTCount =
            moves
            |> Array.fold( fun (cl, cc, pc) move ->
                // get the direction and the length
                let dir = move.Substring(0,1)
                let len = move.Substring(1).Trim() |> int
                let direction =
                    if (dir = "L") then
                        Left
                    else Right
                let newLocation, ptCount = rotate direction len cl
                printfn "%s,%i" move ptCount
                let newCount = 
                    if (newLocation%100) = 0 then
                        cc + 1 
                    else cc
                let newPTCount = pc + ptCount
                (newLocation, newCount, newPTCount)
            ) (50,0,0)
        printfn "zc: %i, pc: %i" zeroCounts passTCount
        zeroCounts + passTCount
