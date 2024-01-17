using System.Dynamic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;




//------------------------------------------------------------------------------------------------
//Tärningar
//------------------------------------------------------------------------------------------------

List<tärning> dice = new();

for (int i = 0; i < 5; i++)
{
    dice.Add(new tärning());
}

foreach (tärning turn in dice)
{
    turn.Roll();
}


//------------------------------------------------------------------------------------------------
//Variablar
//------------------------------------------------------------------------------------------------

int Size = 200;


int Width = 1920;
int Height = 1080;

Raylib.InitWindow(Width, Height, "wassa");

// ---------------------------------------------------------------------------------------------
int MAX_INPUT_CHARS = 2;
Rectangle textBox = new Rectangle(Width / 3 - 100, 180, 150, 50);
bool mouseOnText = false;

char[] Name = new char[MAX_INPUT_CHARS];
int letterCount = 0;
int writing = 1;
// ---------------------------------------------------------------------------------------------


Raylib.SetTargetFPS(30);
while (!Raylib.WindowShouldClose())
{
    // -------------------------------------låsa--------------------------------------------------
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && !dice[0].Lock && dice[0].Count > 0) { dice[0].Lock = true; }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && dice[0].Lock) { dice[0].Lock = false; }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && !dice[1].Lock && dice[1].Count > 0) dice[1].Lock = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && dice[1].Lock) dice[1].Lock = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && !dice[2].Lock && dice[2].Count > 0) dice[2].Lock = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && dice[2].Lock) dice[2].Lock = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && !dice[3].Lock && dice[3].Count > 0) dice[3].Lock = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && dice[3].Lock) dice[3].Lock = false;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && !dice[4].Lock && dice[4].Count > 0) dice[4].Lock = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) && dice[4].Lock) dice[4].Lock = false;
    // ------------------------------------------------------------------------------------------

    foreach (tärning tärn in dice)
    {
        tärn.Roll();
    }

    int yatzy = Raylib.MeasureText("YATZY!!", 300);

    //------------------------------------------------------------------------------------------------
    // visiols
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BROWN);

    // --------------------------------------rectanglar-bakom-sifror---------------------------------
    if (!dice[0].Lock) Raylib.DrawRectangle(Width / 6 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
    else Raylib.DrawRectangle(Width / 6 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);

    if (!dice[1].Lock) Raylib.DrawRectangle(Width / 6 * 2 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
    else Raylib.DrawRectangle(Width / 6 * 2 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);

    if (!dice[2].Lock) Raylib.DrawRectangle(Width / 6 * 3 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
    else Raylib.DrawRectangle(Width / 6 * 3 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);

    if (!dice[3].Lock) Raylib.DrawRectangle(Width / 6 * 4 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
    else Raylib.DrawRectangle(Width / 6 * 4 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);

    if (!dice[4].Lock) Raylib.DrawRectangle(Width / 6 * 5 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
    else Raylib.DrawRectangle(Width / 6 * 5 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);
    // --------------------------------------------------------------------------------------------------



    // ------------------------------------------sifror--------------------------------------------------
    for (int j = 0; j < dice.Count; j++)
    {
        int diceSize = Raylib.MeasureText(dice[j].Count.ToString(), Size);
        tärning tärn = dice[j];
        int b = 1 + j;
        Raylib.DrawText(tärn.Count.ToString(), Width / 6 * b - diceSize / 2, Height / 2 - Size / 2, Size, Color.BLACK);
    }
    // --------------------------------------------------------------------------------------------------





    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
    {
        writing *= -1;
    }
    if (writing == -1)
    {

        for (int q = 0; q < 4; q++)
        {
            for (int p = 0; p < 16; p++)
            {

                textBox = new Rectangle(q * 150 + Width / 3, p * 50 + 75, 150, 50);
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
                            Name[letterCount] = (char)key;
                            // name[letterCount+1] = '\0'; // Add null terminator at the end of the string.
                            letterCount++;
                        }

                        key = Raylib.GetCharPressed();  // Check next character in the queue
                    }
                }

                Raylib.DrawRectangleRec(textBox, Color.LIGHTGRAY);
                if (mouseOnText) Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.RED);
                else Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.DARKGRAY);

                Raylib.DrawText(new String(Name), (int)textBox.X + 5, (int)textBox.Y + 8, 40, Color.MAROON);
            }
        }
    }



    Raylib.EndDrawing();
}


public class tärning
{
    Random Random = new Random();

    public int Count = 0;

    public bool Lock = false;

    public int Toses = 3;

    public int ChangeCount = 0;

    public void Roll()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && ChangeCount <= 0 && Toses > 0)
        {
            if (!Lock)
            {
                ChangeCount = 20;
            }
            Toses--;
        }

        if (ChangeCount > 0)
        {
            Count = Random.Next(1, 7);
            ChangeCount--;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO))
        {
            Toses = 3;
            Count = 0;
            Lock = false;
        }
    }
}