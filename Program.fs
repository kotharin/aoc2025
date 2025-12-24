
module Program =
    
    open System.Diagnostics
    let [<EntryPoint>] main _ =

        let s = Stopwatch.StartNew()
        let answer = Day2.Part1.solution "Day2-1.txt"
        s.Stop()
        printfn "answer: %A, time:%A" answer s.Elapsed
        0