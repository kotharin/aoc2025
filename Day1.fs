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