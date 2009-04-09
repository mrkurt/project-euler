#light

type Guess = { Value : string; Correct : int; }

// 16 digits
let guesses = 
    [
        { Value = "5616185650518293"; Correct = 2 };
        { Value = "3847439647293047"; Correct = 1 };
        { Value = "5855462940810587"; Correct = 3 };
        { Value = "9742855507068353"; Correct = 3 };
        { Value = "4296849643607543"; Correct = 3 };
        { Value = "3174248439465858"; Correct = 1 };
        { Value = "4513559094146117"; Correct = 2 };
        { Value = "7890971548908067"; Correct = 3 };
        { Value = "8157356344118483"; Correct = 1 };
        { Value = "2615250744386899"; Correct = 2 };
        { Value = "8690095851526254"; Correct = 3 };
        { Value = "6375711915077050"; Correct = 1 };
        { Value = "6913859173121360"; Correct = 1 };
        { Value = "6442889055042768"; Correct = 2 };
        { Value = "2321386104303845"; Correct = 0 };
        { Value = "2326509471271448"; Correct = 2 };
        { Value = "5251583379644322"; Correct = 2 };
        { Value = "1748270476758276"; Correct = 3 };
        { Value = "4895722652190306"; Correct = 1 };
        { Value = "3041631117224635"; Correct = 3 };
        { Value = "1841236454324589"; Correct = 3 };
        { Value = "2659862637316867"; Correct = 2 };
    ]
//let prob    
 
let digits = [ '0'..'9' ]

let options = Array.create 16 digits

let nonMatching x y = x <> y

let filter_options (s : string) (options : char list array) = 
    let chars = s.ToCharArray()
    chars |> Array.iteri (fun i c ->
        let l = options.[i]
        options.[i] <- List.filter (nonMatching c) l)  
        
let weight_options (g : Guess) (options : char list array) = 
    let chars = g.Value.ToCharArray()
    let weight = [1..g.Correct]
    chars |> Array.iteri (fun i c ->
        let l = (weight |> List.map (fun i -> c)) @ options.[i]
        options.[i] <- l)

let sum_weights (l : char list) =
    let results = digits |> List.map (fun c -> (c,0)) |> Array.of_list
    l |> List.iter (fun c ->
        let i = results |> Array.find_index (fun (c1,w) -> c = c1)
        let char, current = results.[i]
        let weight = current + 1
        let final = (char, weight)
        results.[i] <- final
        )
    results |> List.of_array |> List.sort (fun (x, wx) (y, wy) -> wy.CompareTo(wx))

guesses 
    |> List.filter (fun x -> x.Correct = 0) 
        |> List.iter (fun g -> filter_options g.Value options)
        
guesses |> List.map (fun g -> weight_options g options) |> ignore

let weighted = options |> Array.map (fun e -> sum_weights e)

let guess = weighted |> Array.map (fun l -> List.hd l)

(*guess |>
    Array.fold_left (fun acc (x,w) -> acc + (x.ToString())) ""
    |> print_any

System.Console.ReadLine()*)