using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

//------------------------------------------------------------------------------------------------
//alla items
//------------------------------------------------------------------------------------------------
Random random = new Random();

Item item = new();





// Item boll = new();




//------------------------------------------------------------------------------------------------
//ints och allt där imällan
//------------------------------------------------------------------------------------------------
// int prutchans = 10;
// bool end = false;
Random tärning = new Random();
int nummer = tärning.Next(1, 21);
int stor = 200;

Item item1 = new Item();


int width = 1920;
int height = 1080;

Raylib.InitWindow(width, height, "wassa");


while (!Raylib.WindowShouldClose())
{

    //------------------------------------------------------------------------------------------------
    //PRUT KOD
    //------------------------------------------------------------------------------------------------


    // tärning
    // while (!end)


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
        nummer = tärning.Next(0, 21);
    }





    //    PRUTCHANS







    //------------------------------------------------------------------------------------------------
    // visiols
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);

    Raylib.DrawText(item.rank,200,100,100,Color.BLACK);

    Raylib.DrawText(nummer.ToString(), width / 2 - stor / 2, height / 2 - stor / 2, stor, Color.BEIGE);
    Raylib.EndDrawing();
}











Console.ReadLine();



public class Item
{

    List<string> ranks = new() { "grå", "blå", "gul" };
    public string rank;

    public Item()
    {
        rank = ranks[Random.Shared.Next(ranks.Count)];
    }

}




