using System;
using System.Numerics;
using System.Text;
using System.Threading;

namespace MyApp;

static class Program
{
    static Vector2 pos = new Vector2(5, 5);

    static Vector2 direction = new Vector2(0, 1);

    static bool gameover = false;
    static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();
        while (!gameover)
        {
            Input();
            UpdatePos();

            Render();

            Thread.Sleep(1000);
        }
        Console.WriteLine("Thanks for playing!");
        Console.CursorVisible = true;
    }

    private static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.W:
                    direction = new Vector2(0, -1);
                    break;
                case ConsoleKey.A:
                    direction = new Vector2(-1, 0);
                    break;
                case ConsoleKey.S:
                    direction = new Vector2(0, 1);
                    break;
                case ConsoleKey.D:
                    direction = new Vector2(1, 0);
                    break;
                case ConsoleKey.X:
                    gameover = true;
                    break;
                default:
                    break;
            }
        }

    }


    private static void UpdatePos()
    {
        pos += direction;

        if (pos.X > 8) { pos.X = 8; }
        if (pos.X < 0) { pos.X = 0; }
        if (pos.Y > 8) { pos.Y = 8; }
        if (pos.Y < 0) { pos.Y = 0; }
    }

    private static void Render()
    {
        string next = NextFrame();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(next);
    }

    private static string NextFrame()
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == pos.Y && j == pos.X)
                {
                    output.Append("#");
                }
                else
                {
                    output.Append(".");
                }
            }
            output.Append("\n");

        }
        return output.ToString();
    }
}
