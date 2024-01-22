using System.Dynamic;
using Raylib_cs;




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
// apperp
//------------------------------------------------------------------------------------------------


string[] paper = { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor", "1Par", "2Par", "Tretal", "Fyrtal", "Liten Straight", "Stor Straight", "Kåk", "Chans", "YATZY" };



//------------------------------------------------------------------------------------------------
//Variablar
//------------------------------------------------------------------------------------------------

int Size = 200;


int Width = 1920;
int Height = 1080;

Raylib.InitWindow(Width, Height, "wassa");

// ---------------------------------------------------------------------------------------------

Rectangle textBox = new Rectangle(Width / 3 - 100, 180, 150, 50);
bool mouseOnText = false;

// char[] Name = new char[MAX_INPUT_CHARS];

// List<char> Text = new List<char>();

List<char>[,] points = new List<char>[4, 15];

points[0, 0] = new List<char>();
for (int y = 0; y < points.GetLength(1); y++)
{
    for (int x = 0; x < points.GetLength(0); x++)
    {
        points[x, y] = new List<char>();
    }
}

int writingX = 0;
int writingY = 0;



int writing = 1;
// ---------------------------------------------------------------------------------------------


Raylib.SetTargetFPS(30);
while (!Raylib.WindowShouldClose())
{

// ----------------------------------slå---------------------------------------------------------------
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

    // -----------------------------------ztärningarna---------------------------------

    KeyboardKey[] keyboardKeys = {KeyboardKey.KEY_ONE, KeyboardKey.KEY_TWO, KeyboardKey.KEY_THREE, KeyboardKey.KEY_FOUR, KeyboardKey.KEY_FIVE, KeyboardKey.KEY_SIX};

    for (int i = 0; i < dice.Count; i++)
    {
        if (Raylib.IsKeyPressed(keyboardKeys[i]) && !dice[i].Lock && dice[i].number > 0) { dice[i].Lock = true; }
        else if (Raylib.IsKeyPressed(keyboardKeys[i]) && dice[i].Lock) { dice[i].Lock = false; }

        int b = i + 1;
        if (!dice[i].Lock) Raylib.DrawRectangle(Width * b / 6 - 75, Height / 2 - Size / 2, 150, 175, Color.WHITE);
        else Raylib.DrawRectangle(Width * b / 6 - 75, Height / 2 - Size / 2, 150, 175, Color.GRAY);
       
        int diceSize = Raylib.MeasureText(dice[i].number.ToString(), Size);
        tärning tärn = dice[i];
        
        Raylib.DrawText(tärn.number.ToString(), Width / 6 * b - diceSize / 2, Height / 2 - Size / 2, Size, Color.BLACK);
    }

    // --------------------------------------------------------------------------------------------------



    // ------------------------------------------sifror--------------------------------------------------
  
    // --------------------------------------------------------------------------------------------------

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
    {
        writing *= -1;
    }
    if (writing == -1)
    {
        int key = Raylib.GetCharPressed();
        while (key > 0)
        {
            // NOTE: Only allow keys in range [32..125]
            if ((key >= 32) && (key <= 125) && (points[writingX, writingY].Count < 2))
            {
                points[writingX, writingY].Add((char)key);
                // Name[letterCount] = (char)key;
                // name[letterCount+1] = '\0'; // Add null terminator at the end of the string.
                // letterCount++;
            }

            key = Raylib.GetCharPressed();  // Check next character in the queue
        }
        Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_ARROW);
        Raylib.DrawRectangle(Width / 3 - Raylib.MeasureText(paper[10], 50) - 20, 70, 1000, 760, Color.WHITE);
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                int paaperPosition = Raylib.MeasureText(paper[y], 50);

                int b = 1 + y;
                Raylib.DrawText(paper[y], Width / 3 - paaperPosition - 20, y * 50 + 75, 50, Color.BLACK);

                textBox = new Rectangle(x * 150 + Width / 3, y * 50 + 75, 150, 50);
                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), textBox)) mouseOnText = true;
                else mouseOnText = false;

                if (mouseOnText)
                {
                    // Set the window's cursor to the I-Beam
                    Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_IBEAM);

                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    {
                        writingX = x;
                        writingY = y;
                    }

                    // Get char pressed (unicode character) on the queue


                    // Check if more characters have been pressed on the same frame


                    // Check if more characters have been pressed on the same frame
                }       

                Raylib.DrawRectangleRec(textBox, Color.LIGHTGRAY);
                if (mouseOnText) Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.RED);
                else Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.DARKGRAY);

                Raylib.DrawText(new String(points[x, y].ToArray()), (int)textBox.X + 5, (int)textBox.Y + 8, 40, Color.MAROON);
            }
        }
    }



    Raylib.EndDrawing();
}


public class tärning
{
    Random Random = new Random();

    public int number = 0;

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
            number = Random.Next(1, 7);
            ChangeCount--;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO))
        {
            Toses = 3;
            number = 0;
            Lock = false;
        }
    }
}