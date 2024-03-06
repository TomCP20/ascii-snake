﻿using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace MyApp;

static class Program
{
    private static readonly Random rand = new();

    private static List<Vector2> snake = [];


    private static Vector2 direction = new Vector2(0, 0);

    private static Vector2 food = new();

    private static bool gameover = false;

    private const int xlength = 30;
    private const int ylength = 10;
    public static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();

        snake = [randomPos()];
        food = randomPos();

        while (!gameover)
        {
            Input();
            UpdatePos();

            Render();

            Thread.Sleep(300);
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
        Vector2 head = snake[snake.Count - 1] + direction;

        if (head.X >= xlength) { head.X = xlength - 1; }
        if (head.X < 0) { head.X = 0; }
        if (head.Y >= ylength) { head.Y = ylength - 1; }
        if (head.Y < 0) { head.Y = 0; }

        snake.Add(head);

        bool hasEaten = false;

        if (snake.Exists(s => s.Equals(food)))
        {
            hasEaten = true;
            food = randomPos();
        }

        if (!hasEaten)
        {
            snake.RemoveAt(0);
        }

    }

    private static void Render()
    {
        string next = NextFrame();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(next);
    }

    private static string NextFrame()
    {
        int score = snake.Count-1;
        string scoreDisplay = $"Score: {score}";

        StringBuilder output = new StringBuilder();
        output.Append(scoreDisplay);
        output.Append(new string('.', xlength+2-scoreDisplay.Length));
        output.Append("\n");
        for (int y = 0; y < ylength; y++)
        {
            output.Append(".");
            for (int x = 0; x < xlength; x++)
            {
                Vector2 pos = new Vector2(x, y);
                if (snake.Exists(s => s.Equals(pos)))
                {
                    output.Append("#");
                }
                else if (pos.Equals(food))
                {
                    output.Append("@");
                }
                else
                {
                    output.Append(" ");
                }
            }
            output.Append(".");
            output.Append("\n");
        }
        output.Append(new string('.', xlength+2));
        return output.ToString();
    }

    private static Vector2 randomPos()
    {
        return new Vector2(rand.Next(xlength), rand.Next(ylength));
    }
}
// TODO add gameover.
// TODO refactor.