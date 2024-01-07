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
Item item2 = new Item();
item2.beskrivning = "fgdgbbbbbbdf";
Item item3 = new Item();
item3.beskrivning = "fgdgbbbbbbdf";


// List<Item> ite =new(){item,item1};
//------------------------------------------------------------------------------------------------
//ints och allt där imällan
//------------------------------------------------------------------------------------------------

Random tärning = new Random();
int nummer = tärning.Next(1, 7);
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




int slag = 3;

int tärning1 = 0;
int tärning2 = 0;
int tärning3 = 0;
int tärning4 = 0;
int tärning5 = 0;

bool lås1 = false;
bool lås2 = false;
bool lås3 = false;
bool lås4 = false;
bool lås5 = false;
//------------------------------------------------------------------------------------------------
//PRUT KOD
//------------------------------------------------------------------------------------------------
Raylib.SetTargetFPS(60);
while (!Raylib.WindowShouldClose())
{

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && !lås1)
    {
        lås1 = true;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && lås1)
    {
        lås1 = false;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && !lås2)
    {
        lås2 = true;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && lås2)
    {
        lås2 = false;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && !lås3)
    {
        lås3 = true;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && lås3)
    {
        lås3 = false;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && !lås4)
    {
        lås4 = true;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && lås4)
    {
        lås4 = false;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && !lås5)
    {
        lås5 = true;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && lås5)
    {
        lås5 = false;
    }




    timermimmer++;
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && slag > 0)
    {
        spin = true;


        if (spin)
        {
            nummer = tärning.Next(1, 7);
            TimesSpin++;
            timermimmer = 0;
            if (!lås1)
            {
                tärning1 = tärning.Next(1, 7);
            }
            if (!lås2)
            {
                tärning2 = tärning.Next(1, 7);
            }
            if (!lås3)
            {
                tärning3 = tärning.Next(1, 7);
            }
            if (!lås4)
            {
                tärning4 = tärning.Next(1, 7);
            }
            if (!lås5)
            {
                tärning5 = tärning.Next(1, 7);
            }
            slag--;
            if (timermimmer > 100)
            {

            }
        }
        if (TimesSpin > 20)
        {
            spin = false;
        }
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO))
    {
        slag = 3;
        lås1 = false;
        lås2 = false;
        lås3 = false;
        lås4 = false;
        lås5 = false;

        tärning1 = 0;
        tärning2 = 0;
        tärning3 = 0;
        tärning4 = 0;
        tärning5 = 0;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && spins == 0)
    {
        rullning = true;
        spins = 1;
        nummer = 20;
    }

    // if (rullning == true)
    // {

    //     timermimmer++;
    //     if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !spin && spins > -1)
    //     {
    //         spins = -1;
    //         spin = true;
    //         TimesSpin = 0;
    //     }
    //     if (spin)
    //     {
    //         if (timermimmer > 100)
    //         {
    //             nummer = tärning.Next(1, 7);
    //             TimesSpin++;
    //             timermimmer = 0;
    //         }
    //     }

    //     if (TimesSpin > 20)
    //     {
    //         spin = false;
    //     }

    //     if (spins == -1)
    //     {
    //         if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
    //         {
    //             rullning = false;
    //             spins = 0;
    //         }
    //     }




    // }




    int föf1 = Raylib.MeasureText(tärning1.ToString(), stor);
    int föf2 = Raylib.MeasureText(tärning2.ToString(), stor);
    int föf3 = Raylib.MeasureText(tärning3.ToString(), stor);
    int föf4 = Raylib.MeasureText(tärning4.ToString(), stor);
    int föf5 = Raylib.MeasureText(tärning5.ToString(), stor);

    //    PRUTCHANS







    if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
    {
        test = true;
    }

     int yatzy=Raylib.MeasureText("YATZY!!",300);

    //------------------------------------------------------------------------------------------------
    // visiols
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BROWN);

    // for (int i = 0; i < 5; i++)
    // {
    //     //1920/3
    //     Raylib.DrawRectangle(i * width / 6 + width / 6, height / 2, 20, 20, Color.BLACK);
    //     Raylib.DrawText(nummer.ToString(), i * width / 6 + width / 6 - föf / 2, height / 2 - stor / 2, stor, Color.BLACK);

    // }

    if (!lås1)
    {
        Raylib.DrawRectangle(width / 6 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);
    }
    else
    {
        Raylib.DrawRectangle(width / 6 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);
    }

    if (!lås2)
    {
        Raylib.DrawRectangle(width / 6 * 2 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);
    }
    else
    {
        Raylib.DrawRectangle(width / 6 * 2 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);
    }

    if (!lås3)
    {
        Raylib.DrawRectangle(width / 6 * 3 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);
    }
    else
    {
        Raylib.DrawRectangle(width / 6 * 3 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);
    }

    if (!lås4)
    {
        Raylib.DrawRectangle(width / 6 * 4 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);
    }
    else
    {
        Raylib.DrawRectangle(width / 6 * 4 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);
    }

    if (!lås5)
    {
        Raylib.DrawRectangle(width / 6 * 5 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);
    }
    else
    {
        Raylib.DrawRectangle(width / 6 * 5 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);
    }


    Raylib.DrawText(tärning1.ToString(), width / 6 - föf1 / 2, height / 2 - stor / 2, stor, Color.BLACK);
    Raylib.DrawText(tärning2.ToString(), width / 6 * 2 - föf2 / 2, height / 2 - stor / 2, stor, Color.BLACK);
    Raylib.DrawText(tärning3.ToString(), width / 6 * 3 - föf3 / 2, height / 2 - stor / 2, stor, Color.BLACK);
    Raylib.DrawText(tärning4.ToString(), width / 6 * 4 - föf4 / 2, height / 2 - stor / 2, stor, Color.BLACK);
    Raylib.DrawText(tärning5.ToString(), width / 6 * 5 - föf5 / 2, height / 2 - stor / 2, stor, Color.BLACK);


if (tärning1==tärning2&&tärning2==tärning3&&tärning3==tärning4&&tärning4==tärning5&&tärning1>0)
{
    Raylib.DrawText("YATZY!!",width/2-yatzy/2,700,300,Color.BLACK);
}

    if (test)
    {

        Raylib.DrawRectangle(0, height - height / 5, width-yatzy/2, height / 5, Color.BROWN);
    }


    if (rullning)
    {
        Raylib.DrawRectanglePro(r, new Vector2(r.Width / 2, r.Height / 2), 180, Color.LIME);
        Raylib.DrawText(nummer.ToString(), width / 2 / 2, height / 2 - stor / 2, stor, Color.BLACK);
        Raylib.DrawText(item1.rank, 200, 100, 100, Color.BLACK);
        Raylib.DrawText(item1.nödrull, 200, 200, 100, Color.BLACK);

        Raylib.DrawText(item2.rank, 200, 300, 100, Color.BLACK);
        Raylib.DrawText(item2.nödrull, 200, 400, 100, Color.BLACK);

        Raylib.DrawText(item3.rank, 200, 500, 100, Color.BLACK);
        Raylib.DrawText(item3.nödrull, 200, 600, 100, Color.BLACK);



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
        ranks.RemoveAt(nivå);

    }

}

public class tärning
{

}




