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

Item item1 = new Item();
item1.beskrivning = "fgdgfrdsfgrdsrfgdf";
Item item = new Item();
item.beskrivning = "fgdgbbbbbbdf";

List<Item> ite =new(){item,item1};
//------------------------------------------------------------------------------------------------
//ints och allt där imällan
//------------------------------------------------------------------------------------------------

Random tärning = new Random();
int nummer = tärning.Next(1, 21);
int stor = 200;



int width = 1920;
int height = 1080;

Raylib.InitWindow(width, height, "wassa");

int TimesSpin = 10;
float timermimmer = 0;
bool spin = false;

bool rullning = false;
int spins = 0;

Rectangle r = new(width / 2, height / 2, 300, 800);


bool test = false;

while (!Raylib.WindowShouldClose())
{

    //------------------------------------------------------------------------------------------------
    //PRUT KOD
    //------------------------------------------------------------------------------------------------


    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && spins == 0)
    {
        rullning = true;
        spins = 1;
        nummer = 20;
    }





    if (rullning == true)
    {

        timermimmer++;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !spin && spins > -1)
        {
            spins = -1;
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

        if (spins == -1)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                rullning = false;
                spins = 0;
            }
        }



        
    }




    int föf = Raylib.MeasureText(nummer.ToString(), stor);

    //    PRUTCHANS






        
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q)){
       test = true;
    }

    //------------------------------------------------------------------------------------------------
    // visiols
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);

        if (test)
        {
            
        Raylib.DrawRectangle(0,height-height/5,width,height/5,Color.BROWN);
        }


    if (rullning)
    {
        Raylib.DrawRectanglePro(r, new Vector2(r.Width / 2, r.Height / 2), 180, Color.LIME);
        Raylib.DrawText(nummer.ToString(), width / 2 - föf / 2, height / 2 - stor / 2, stor, Color.BLACK);
        Raylib.DrawText(item1.rank, 200, 100, 100, Color.BLACK);
        Raylib.DrawText(item1.nödrull, 200, 200, 100, Color.BLACK);

        Raylib.DrawText(item.rank, 200, 300, 100, Color.BLACK);
        Raylib.DrawText(item.nödrull, 200, 400, 100, Color.BLACK);

    }

    Raylib.EndDrawing();

}
public class Item
{

    List<string> ranks = new() { "grå", "blå", "gul" };
    List<int> nödvändigt = new() { 5, 10, 15 };
    public string rank;
    public string nödrull;

    public string beskrivning = "";
    public Item()
    {

        int nivå = Random.Shared.Next(ranks.Count);

        rank = ranks[nivå];
        nödrull = nödvändigt[nivå].ToString();

    }

}




