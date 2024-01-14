using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


tärning t1 = new();

List<tärning> tärningar = new();

for (int i = 0; i < 5; i++)
{
    tärningar.Add(new tärning());
}

foreach (tärning tärn in tärningar)
{
    tärn.Roll();
}




//------------------------------------------------------------------------------------------------
//alla items
//------------------------------------------------------------------------------------------------
Random random = new Random();




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





int MAX_INPUT_CHARS = 9;
Rectangle textBox = new Rectangle(width / 2 - 100, 180, 225, 50);
bool mouseOnText = false;

char[] name = new char[MAX_INPUT_CHARS];
int letterCount = 0;
//------------------------------------------------------------------------------------------------
//PRUT KOD
//------------------------------------------------------------------------------------------------
Raylib.SetTargetFPS(60);
while (!Raylib.WindowShouldClose())
{
    // -------------------------------------låsa--------------------------------------------------
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && !tärningar[0].Låsande) { tärningar[0].Låsande = true; }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && tärningar[0].Låsande) { tärningar[0].Låsande = false; }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && !tärningar[1].Låsande) tärningar[1].Låsande = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && tärningar[1].Låsande) tärningar[1].Låsande = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && !tärningar[2].Låsande) tärningar[2].Låsande = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && tärningar[2].Låsande) tärningar[2].Låsande = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && !tärningar[3].Låsande) tärningar[3].Låsande = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && tärningar[3].Låsande) tärningar[3].Låsande = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && !tärningar[4].Låsande) tärningar[4].Låsande = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && tärningar[4].Låsande) tärningar[4].Låsande = false;
    // -------------------------------------låsa-up-----------------------------------------------


    foreach (tärning tärn in tärningar)
    {
        tärn.Roll();
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


if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO))
{
    // tärning.värde
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




// int föf1 = Raylib.MeasureText(tärning1.ToString(), stor);--------------------------------------


//    PRUTCHANS







if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
{
    test = true;
}

int yatzy = Raylib.MeasureText("YATZY!!", 300);





if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), textBox)) mouseOnText = true;
else mouseOnText = false;

if (mouseOnText)
{
    // Set the window's cursor to the I-Beam
    Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_IBEAM);

    // Get char pressed (unicode character) on the queue
    int key = Raylib.GetCharPressed();

    // Check if more characters have been pressed on the same frame


    // Check if more characters have been pressed on the same frame
    while (key > 0)
    {
        // NOTE: Only allow keys in range [32..125]
        if ((key >= 32) && (key <= 125) && (letterCount < MAX_INPUT_CHARS))
        {
            name[letterCount] = (char)key;
            // name[letterCount+1] = '\0'; // Add null terminator at the end of the string.
            letterCount++;
        }

        key = Raylib.GetCharPressed();  // Check next character in the queue
    }
}

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

if (!tärningar[0].Låsande) Raylib.DrawRectangle(width / 6 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);

else Raylib.DrawRectangle(width / 6 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);


if (!tärningar[1].Låsande) Raylib.DrawRectangle(width / 6 * 2 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);

else Raylib.DrawRectangle(width / 6 * 2 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);


if (!tärningar[2].Låsande) Raylib.DrawRectangle(width / 6 * 3 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);

else Raylib.DrawRectangle(width / 6 * 3 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);


if (!tärningar[3].Låsande) Raylib.DrawRectangle(width / 6 * 4 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);

else Raylib.DrawRectangle(width / 6 * 4 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);


if (!tärningar[4].Låsande) Raylib.DrawRectangle(width / 6 * 5 - 75, height / 2 - stor / 2, 150, 175, Color.WHITE);

else Raylib.DrawRectangle(width / 6 * 5 - 75, height / 2 - stor / 2, 150, 175, Color.GRAY);





// if (tärning1 == tärning2 && tärning2 == tärning3 && tärning3 == tärning4 && tärning4 == tärning5 && tärning1 > 0)
// {
//     Raylib.DrawText("YATZY!!", width / 2 - yatzy / 2, 700, 300, Color.BLACK);
// }




for (int j = 0; j < tärningar.Count; j++)
{
    tärning tärn = tärningar[j];
    int b = 1 + j;
    Raylib.DrawText(tärn.värde.ToString(), width / 6 * b  / 2, height / 2 - stor / 2, stor, Color.BLACK);
}





Raylib.DrawRectangleRec(textBox, Color.LIGHTGRAY);
if (mouseOnText) Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, 225, 50, Color.RED);
else Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.DARKGRAY);

Raylib.DrawText(new String(name), (int)textBox.X + 5, (int)textBox.X + 8, 40, Color.MAROON);

Raylib.EndDrawing();




public class tärning
{
    Random random = new Random();
    public int värde = 0;

    public bool Låsande = false;

    public void Roll()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !Låsande)
        {
            värde = random.Next(1, 7);
        }
    }
}




