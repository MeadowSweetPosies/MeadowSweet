#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "../../packages/System.Net.Http/lib/net46/System.Net.Http.dll"
open FSharp.Data
open System.Text
open System.Net.Http
open System.Text
open System.Security.Cryptography

type orderCreation = JsonProvider<"../data/order_creation_body.json">
let doc = orderCreation.GetSample()

//let getHmac (req: HttpRequestMessage) = 

let getHMACSHA256 (key: byte array) (data: byte array) = 
    use md256 = HMACSHA256.Create()
    md256.Key <- key
    (StringBuilder(), md256.ComputeHash(data))
    ||> Array.fold (fun sb b -> sb.Append(b.ToString("x2")))
    |> string

let hsh = getHMACSHA256 ASCII.Encoding.GetBytes("hello") "thisismymessage"
