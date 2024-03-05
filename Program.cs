﻿using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace MyApp;

static class Program
{
    private static Vector2 pos = new Vector2(5, 5);

    private static Vector2 direction = new Vector2(0, 1);

    private static bool gameover = false;

    private const int xlength = 9;
    private const  int ylength = 9;
    public static void Main()
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

        if (pos.X >= xlength) { pos.X = xlength - 1; }
        if (pos.X < 0) { pos.X = 0; }
        if (pos.Y >= ylength) { pos.Y = xlength - 1; }
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
        for (int y = 0; y < ylength; y++)
        {
            for (int x = 0; x < xlength; x++)
            {
                if (y == pos.Y && x == pos.X)
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
