namespace Day2

module Part1 =

    open System.IO

    type Range = {
        Start: int64
        End: int64
    } with 
        static member parse (s:string) =
            let parts = s.Split([|'-'|])
            {Range.Start = (int64)parts.[0]; End = (int64)parts.[1]}

    let solution file =

        let isSymmetric (num:int64) =
            let number = num.ToString()

            if (number.Length % 2 = 0) then
                let d = (int64)(10.0 ** (float)(number.Length/2))
                let a = num / d
                let b = num - (a * d)
                a = b
            else false
            
        let line = File.ReadAllText file

        let getSymmetric (range:Range) =
            [|(int64)range.Start .. (int64)range.End|]
            |> Array.filter(fun n ->
                isSymmetric n
            )

        let total =
            line.Split([|','|])
            |> Array.map Range.parse
            |> Array.map getSymmetric
            |> Array.concat
            |> Array.sum
        total