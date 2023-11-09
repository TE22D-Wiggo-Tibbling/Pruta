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
int nummer = tärning.Next(0, 20);


item item1 = new item();



//------------------------------------------------------------------------------------------------
//PRUT KOD
//------------------------------------------------------------------------------------------------


// tärning
while (!end)
{
    nummer = tärning.Next(0, 21);
    System.Console.WriteLine(nummer);

    if (nummer > prutchans && nummer != 20)
    {
        System.Console.WriteLine("ja");
    }
    else if (nummer < prutchans && nummer != 1)
    {
        System.Console.WriteLine("nej");
    }
    else if (nummer == 20)
    {
        System.Console.WriteLine("bäst");
    }
    else if (nummer == 1)
    {
        System.Console.WriteLine("skit");
    }

    string svar = Console.ReadLine();


    if (svar == "a")
    {
        end = true;
    }


    //    PRUTCHANS



}







Console.ReadLine();



public class item{
    public string rank = "";
}



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