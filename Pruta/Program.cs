using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;


// Raylib.InitWindow(800, 600, "wassa");

//------------------------------------------------------------------------------------------------
//PRUT KOD
//------------------------------------------------------------------------------------------------
bool end = false;
Random tärning = new Random();
int nummer = tärning.Next(0,20);
while(!end){
    nummer = tärning.Next(0,20);
    System.Console.WriteLine(nummer);
   string svar= Console.ReadLine();
   if(svar == "a"){
    end = true;
   }
}







//------------------------------------------------------------------------------------------------
//GAME LOGIC
//------------------------------------------------------------------------------------------------


Console.ReadLine();

//---------------------------------------------------------------------------------------------------
//RENDER
//---------------------------------------------------------------------------------------------------

// while (!Raylib.WindowShouldClose()){
//     Raylib.BeginDrawing();
//     Raylib.ClearBackground(Color.BLUE);
//     Raylib.EndDrawing();
// }