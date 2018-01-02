#I "../../packages/Deedle"
#load "Deedle.fsx"

open System
open Deedle

let getPwk (matchWhat:string) (matchIn:ObjectSeries<string>) = 
    let obs:seq<string * Object> = matchIn |> Series.observations
    let pwk = obs |> 
                Seq.map(fun s -> (snd s).ToString().Split([|'\n'|]) |>
                                    Array.filter(fun b -> b.Contains(matchWhat)))
    pwk |> Seq.head         // possibly no element so head will fail but ho hum


let sales = Frame.ReadCsv(__SOURCE_DIRECTORY__ + "\data\sales.csv")
let memos = sales |> Frame.filterRows(fun k v -> v.GetAs<decimal>("Total") > 0m) |> Frame.sliceCols ["Memo"]
let pwkOnly:Series<int, string[]> = memos |> 
                                        Frame.rows |> 
                                        Series.mapValues(fun v -> getPwk "PWK" v)

let wksOnly = pwkOnly   |> Series.values
let wksTogether = wksOnly |> Seq.map(fun s -> (s.[0].Split([|':'|])).[1])
let wksApart = wksTogether |> Seq.map(fun s -> s.Split([|';'|]))