#light
open System

let divisibleBy value divisor = value % divisor = 0
let not flag = flag = false
let notDivisibleBy x y = not (divisibleBy x y)

let values = Seq.unfold (fun x -> Some(x, x + 20)) 20

let divisors = List.rev [2 .. 19]

let divisibleByAll divisors value = 
    let notDivisibleByX = notDivisibleBy value
    let exists = divisors |> List.exists notDivisibleByX 
    not exists

let finder = Seq.find (fun x -> divisibleByAll divisors x)

let result = values |> finder

print_any result