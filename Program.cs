using System;
using System.Numerics;
using System.Text;
using System.Threading;

namespace MyApp;

static class Program
{
    static string[,] board = {
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        {".", ".", ".", ".", ".", ".", ".", ".", "."},
        };

    static Vector2 pos = new Vector2(5, 5);
    static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();
        while (true)
        {
            Input();

            Render();

            Thread.Sleep(1000);
        }
        Console.CursorVisible = true;
    }

    private static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W:
                    pos.Y -= 1;
                    break;
                case ConsoleKey.A:
                    pos.X -= 1;
                    break;
                case ConsoleKey.S:
                    pos.Y += 1;
                    break;
                case ConsoleKey.D:
                    pos.X += 1;
                    break;
                
                default:
                    break;
            }
        }
    }

    private static void Render()
    {
        string next = NextFrame();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(next);
    }

    static string NextFrame()
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
                    output.Append(board[i, i]);
                }
            }
            output.Append("\n");

        }
        return output.ToString();
    }
}
