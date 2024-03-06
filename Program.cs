using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace MyApp;

static class Program
{
    private static Vector2[] snake = [new Vector2(5, 5)];

    private static Vector2 direction = new Vector2(1, 0);

    private static bool gameover = false;

    private const int xlength = 30;
    private const  int ylength = 10;
    public static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();
        while (!gameover)
        {
            Input();
            UpdatePos();

            Render();

            Thread.Sleep(500);
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
        snake[0] += direction;

        if (snake[0].X >= xlength) { snake[0].X = xlength - 1; }
        if (snake[0].X < 0) { snake[0].X = 0; }
        if (snake[0].Y >= ylength) { snake[0].Y = ylength - 1; }
        if (snake[0].Y < 0) { snake[0].Y = 0; }
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
        for (int y = 0; y < ylength; y++)
        {
            for (int x = 0; x < xlength; x++)
            {
                if (snake.Any(s => y == s.Y && x == s.X ))
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
