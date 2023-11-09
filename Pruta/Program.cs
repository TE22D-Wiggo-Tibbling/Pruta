using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
//------------------------------------------------------------------------------------------------
//ints och allt där imällan
//------------------------------------------------------------------------------------------------
int prutchans = 10;
bool end = false;
Random tärning = new Random();
int nummer = tärning.Next(0,20);


//------------------------------------------------------------------------------------------------
//PRUT KOD
//------------------------------------------------------------------------------------------------

while(!end){
    nummer = tärning.Next(0,20);
    System.Console.WriteLine(nummer);
   string svar= Console.ReadLine();
  
  if(nummer > prutchans){
    System.Console.WriteLine("ja");
  }
  
  
  
   if(svar == "a"){
    end = true;
   }
}





Console.ReadLine();



//------------------------------------------------------------------------------------------------
//GAME LOGIC
//------------------------------------------------------------------------------------------------




//---------------------------------------------------------------------------------------------------
//RENDER
//---------------------------------------------------------------------------------------------------
// Raylib.InitWindow(800, 600, "wassa");


// while (!Raylib.WindowShouldClose()){
//     Raylib.BeginDrawing();
//     Raylib.ClearBackground(Color.BLUE);
//     Raylib.EndDrawing();
// }