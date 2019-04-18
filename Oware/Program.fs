module Oware



open System
open System.Collections.Immutable

type StartingPosition =
    | South
    | North


 type Player=
      {
       houses: int*int*int*int*int*int
       capturedSeeds: int
     
      }


type states=
|Draw of string
|Win of string
|Northturn 
|Southturn 

type Board={
    state : states
    northplayer : Player
    southplayer : Player
    }
    //getSeeds, which accepts a house number and a board,
    //and returns the number of
    //seeds in the specified house
let getSeeds n board = // failwith "Not implemented"
    match board.state with
    |Northturn | Southturn -> 
        let (a',b',c',d',e',f')= board.northplayer.houses 
        let (a,b,c,d,e,f) = board.southplayer.houses in
            match n with 
            |1->a
            |2->b
            |3->c
            |4->d
            |5->e
            |6->f  
            |7->a'
            |8->b'
            |9->c'
            |10->d'
            |11->e'
            |12->f'
            |_-> failwith "Not implemented"
    |_-> failwith "Not implemented"

//useHouse, which accepts a house number and a board,
//and makes a move using
//that house.

let checkhouse currhouse =
          match currhouse with
          | 13 -> 1
          | _ -> currhouse

//let rec nextHouse n =
//          match n  with 
//          |12 -> 1
//          | n -> n+1 


let setSeeds n num board =
     let (a',b',c',d',e',f') = board.northplayer.houses 
     let (a ,b ,c ,d ,e ,f ) = board.southplayer.houses in
         match n with
         |1-> {board with southplayer={board.southplayer with houses=(num,b,c,d,e,f)}}
         |2->{board with southplayer={board.southplayer with houses=(a,num,c,d,e,f)}}
         |3->{board with southplayer={board.southplayer with houses=(a,b,num,d,e,f)}}
         |4->{board with southplayer={board.southplayer with houses=(a,b,c,num,e,f)}}
         |5->{board with southplayer={board.southplayer with houses=(a,b,c,d,num,f)}}
         |6->{board with southplayer={board.southplayer with houses=(a,b,c,d,e,num)}}
         |7->{board with northplayer={board.northplayer with houses=(num,b',c',d',e',f')}}
         |8->{board with northplayer={board.northplayer with houses=(a',num,c',d',e',f')}}
         |9->{board with northplayer={board.northplayer with houses=(a',b',num,d',e',f')}}
         |10->{board with northplayer={board.northplayer with houses=(a',b',c',num,e',f')}}
         |11->{board with northplayer={board.northplayer with houses=(a',b',c',d',num,f')}}
         |12->{board with northplayer={board.northplayer with houses=(a',b',c',d',e',num)}}
         |_-> failwith "Not implemented"

 


let useHouse n board = // failwith "Not implemented"
         let (a',b',c',d',e',f') = board.northplayer.houses 
         let (a ,b ,c ,d ,e ,f ) = board.southplayer.houses in
         let numSeeds = getSeeds n board
         let nboard = setSeeds n 0 board
         let nxtHouse = (*nextHouse*) n+1
         let rec updateBoard currentHouse nSeeds newboard =
              let currhouse= checkhouse currentHouse
              let numSeeds = getSeeds currhouse newboard
              match nSeeds>0 with 
              | true -> 
                //updateBoard (nextHouse n) (getSeeds (nextHouse n) board) in
                
                let board = setSeeds currhouse (numSeeds+1) newboard
                updateBoard (currhouse + 1) (nSeeds-1) board
              | _ -> newboard
         updateBoard nxtHouse numSeeds nboard 



       
//start, which accepts a StartingPosition and returns 
//an initialized game where the person
//in the StartingPosition starts the game
let start position =  
    let reco={houses=(4,4,4,4,4,4); capturedSeeds = 0}

    match position with
    |North -> {state = Northturn ; northplayer = reco;southplayer=reco}
    |South->  {state = Southturn  ; northplayer = reco;southplayer = reco}

//score, which accepts a board and gives back a 
//tuple of (southScore , northScore)
let capture n board = 
    let seedsinHouse = getSeeds n board in
        match seedsinHouse with
        |2|3 -> setSeeds n 0 board
        |_ ->board

let changestate postion board=
    match postion with
    |South -> {board with state=Northturn}
    |North -> {board with state=Southturn}
    




let score board = failwith "Not implemented"



//gameState, which accepts a board and gives back 
//a string that tells us about the
//state of the game. Valid strings are
//“South’s turn”, “North’s turn”, “Game ended in a draw”,
//“South won”, and “North won”.
let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
