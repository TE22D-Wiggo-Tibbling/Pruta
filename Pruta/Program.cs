using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

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

int TimesSpin = 10;
float timermimmer = 0;
bool spin = false;

bool rullning = false;
int spins = 0;


while (!Raylib.WindowShouldClose())
{

    //------------------------------------------------------------------------------------------------
    //PRUT KOD
    //------------------------------------------------------------------------------------------------


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W)&&spins==0)
    {
        rullning = true;
        spins = 1;
    }
    // tärning
    // while (!end)




    if (rullning == true)
    {

        timermimmer++;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !spin && spins > 0)
        {
            spins--;
            spin = true;
            TimesSpin = 0;
        }
        if (spin)
        {
            if (timermimmer > 100)
            {
                nummer = tärning.Next(1, 21);
                TimesSpin++;
                timermimmer = 0;
            }
        }

        if (TimesSpin > 20)
        {
            spin = false;
        }

        if (spins == 0)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                rullning = false;
            }
        }
        

        
        // {
        // }
    }




    int föf = Raylib.MeasureText(nummer.ToString(), stor);

    //    PRUTCHANS







    //------------------------------------------------------------------------------------------------
    // visiols
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);


    if (rullning)
    {
        Raylib.DrawText(item.rank, 200, 100, 100, Color.BLACK);

        Raylib.DrawText(nummer.ToString(), width / 2 - föf / 2, height / 2 - stor / 2, stor, Color.BEIGE);

    }

    Raylib.EndDrawing();

}
public class Item
{

    List<string> ranks = new() { "grå", "blå", "gul" };
    public string rank;

    public Item()
    {
        rank = ranks[Random.Shared.Next(ranks.Count)];
    }

}




