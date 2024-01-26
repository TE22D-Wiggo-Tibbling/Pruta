using System.Dynamic;
using Raylib_cs;

//------------------------------------------------------------------------------------------------
//Tärningar
//------------------------------------------------------------------------------------------------

// Gör lista med tärningar
List<tärning> dice = new();

//Gör fem tärningar
for (int i = 0; i < 5; i++)
{
    dice.Add(new tärning());
}


// En array med namn på alla typer av poäng man kan få
string[] paper = { "Ettor", "Tvåor", "Treor", "Fyror", "Femmor", "Sexor", "1Par", "2Par", "Tretal", "Fyrtal", "Liten Straight", "Stor Straight", "Kåk", "Chans", "YATZY" };



//------------------------------------------------------------------------------------------------
//Variablar
//------------------------------------------------------------------------------------------------

// Storleken av text
int Size = 200;

// Storleken av spelet
int width = 1920;
int height = 1080;
Raylib.InitWindow(width, height, "wassa");

// Rectangeln för att skriva i
Rectangle textBox = new Rectangle(width / 3 - 100, 180, 150, 50);
bool mouseOnText = false;

// Lista för att skriva vid varje låda
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

// Bool för att ändra mellan att spela och skriva
bool writing = false;

// En lugn och skön 30fps
Raylib.SetTargetFPS(30);
while (!Raylib.WindowShouldClose())
{

    //För varje tärning gör de turn funktionen
    foreach (tärning tärn in dice)
    {
        tärn.Roll();
    }

    //------------------------------------------------------------------------------------------------
    // Draw
    //------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BROWN);

    // -----------------------------------tärningarna-------------------------------------------------

    // Aray med knappar för att kunna sätta dem i forloop
    KeyboardKey[] keyboardKeys = { KeyboardKey.KEY_ONE, KeyboardKey.KEY_TWO, KeyboardKey.KEY_THREE, KeyboardKey.KEY_FOUR, KeyboardKey.KEY_FIVE, KeyboardKey.KEY_SIX };

    // Forloop för tärningarnas lås funktioner och rita ut dem
    for (int i = 0; i < dice.Count; i++)
    {
        // Låsa
        if (Raylib.IsKeyPressed(keyboardKeys[i]) && !dice[i].@lock && dice[i].number > 0) { dice[i].@lock = true; }
        // Låsa up
        else if (Raylib.IsKeyPressed(keyboardKeys[i]) && dice[i].@lock) { dice[i].@lock = false; }

        // ska följa när i höjs men ska ha ett mer värde
        int b = i + 1;
        // Ändra färg på lådan när den är låst eller uplåst
        if (!dice[i].@lock) Raylib.DrawRectangle(width * b / 6 - 75, height / 2 - Size / 2, 150, 175, Color.WHITE);
        else Raylib.DrawRectangle(width * b / 6 - 75, height / 2 - Size / 2, 150, 175, Color.GRAY);

        // Tärningens värde storlek
        int diceSize = Raylib.MeasureText(dice[i].number.ToString(), Size);
        tärning tärn = dice[i];
        Raylib.DrawText(tärn.number.ToString(), width / 6 * b - diceSize / 2, height / 2 - Size / 2, Size, Color.BLACK);
    }


    // -----------------------------------poängBlad-------------------------------------------------

    // för att ändra mellan skriva och inte
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
    {
        writing = true;
    }
    if (writing)
    {

        int key = Raylib.GetCharPressed();
        while (key > 0)
        {
            if ((key >= 32) && (key <= 125) && (points[writingX, writingY].Count < 2))
            {
                points[writingX, writingY].Add((char)key);
            }

            // Fönga vilet knapp som trycks
            key = Raylib.GetCharPressed();
        }

        Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_ARROW);
        Raylib.DrawRectangle(width / 3 - Raylib.MeasureText(paper[10], 50) - 20, 70, 1000, 760, Color.WHITE);

        // Forloop för att göra alla låder att skriva i
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                // Skriver ut alla namn på poängvertionerna
                int paaperPosition = Raylib.MeasureText(paper[y], 50);
                Raylib.DrawText(paper[y], width / 3 - paaperPosition - 20, y * 50 + 75, 50, Color.BLACK);

                // Textlådans position
                textBox = new Rectangle(x * 150 + width / 3, y * 50 + 75, 150, 50);
                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), textBox)) mouseOnText = true;
                else mouseOnText = false;

                if (mouseOnText)
                {
                    Raylib.SetMouseCursor(MouseCursor.MOUSE_CURSOR_IBEAM);
                    // om man trycker left mous button på en låda ändras skriv positionen
                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    {
                        writingX = x;
                        writingY = y;
                    }
                }

                // Ritar ut alla lådor
                Raylib.DrawRectangleRec(textBox, Color.LIGHTGRAY);
                if (mouseOnText) Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.RED);
                else Raylib.DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.Width, (int)textBox.Height, Color.DARKGRAY);

                Raylib.DrawText(new String(points[x, y].ToArray()), (int)textBox.X + 5, (int)textBox.Y + 8, 40, Color.MAROON);
            }
        }
    }
    Raylib.EndDrawing();
}

// Tärnings Class
public class tärning
{
    // Tärningens random
    Random random = new Random();

    // tärnigngens nummer
    public int number = 0;

    // Bool för att låsa tärningen. (vet inte varför det är en @)
    public bool @lock = false;

    // Antal kast
    public int toses = 3;

    // Antal gånger tärnignen ska ändras innan den stannar 
    public int changeCount = 0;

    // Tärningens Roll funktion
    public void Roll()
    {
        // Kan bara skå när man har kvar slag och tärnignen inte håller på att ändras 
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && changeCount <= 0 && toses > 0)
        {
            // Om tärningen inte är låst
            if (!@lock)
            {
                changeCount = 20;
            }
            // Antall slag ska alltid ändras även om den är låst
            toses--;
        }

        // Efter man slår kommer tärningen ändras tills changeCount når noll
        if (changeCount > 0)
        {
            number = random.Next(1, 7);
            changeCount--;
        }

        // För att starta om tärningarna
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO))
        {
            toses = 3;
            number = 0;
            @lock = false;
        }
    }
}