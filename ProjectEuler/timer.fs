#light
open System

let runTimed f = 
    let start = System.DateTime.Now
    let value = f ()
    (value, (System.DateTime.Now - start))