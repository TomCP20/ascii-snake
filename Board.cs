using System.Numerics;
using System.Text;

namespace AsciiSnake;

class Board
{
    private readonly Random rand = new();

    private readonly List<Vector2> snake;


    private Vector2 direction = new Vector2(0, 0);

    private Vector2 food;

    public bool gameover = false;

    private readonly int xlength;
    private readonly int ylength;
    public Board(int x, int y)
    {
        xlength = x;
        ylength = y;
        snake = [randomPos()];
        food = randomPos();
    }

    public void Update()
    {
        HandleInput();
        UpdatePos();
    }

    private void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = GetKey();

            switch (key)
            {
                case ConsoleKey.W:
                    if (!direction.Equals(new Vector2(0, 1))) { direction = new Vector2(0, -1); }
                    break;
                case ConsoleKey.A:
                    if (!direction.Equals(new Vector2(1, 0))) { direction = new Vector2(-1, 0); }
                    break;
                case ConsoleKey.S:
                    if (!direction.Equals(new Vector2(0, -1))) { direction = new Vector2(0, 1); }
                    break;
                case ConsoleKey.D:
                    if (!direction.Equals(new Vector2(-1, 0))) { direction = new Vector2(1, 0); }
                    break;
                case ConsoleKey.X:
                    gameover = true;
                    break;
                default:
                    break;
            }
        }

    }

    private ConsoleKey GetKey()
    {
        ConsoleKey key;
        do { key = Console.ReadKey(true).Key; } while (Console.KeyAvailable);
        return key;
    }

    private void UpdatePos()
    {
        Vector2 head = snake[snake.Count - 1] + direction;

        if (head.X >= xlength || head.X < 0 || head.Y >= ylength || head.Y < 0 || (snake.Contains(head) && !direction.Equals(new Vector2(0, 0))))
        {
            gameover = true;
            return;
        }

        snake.Add(head);

        bool hasEaten = false;

        if (snake.Contains(food))
        {
            hasEaten = true;
            food = randomPos();
        }

        if (!hasEaten)
        {
            snake.RemoveAt(0);
        }

    }

    public string NextFrame()
    {
        int score = snake.Count - 1;
        string scoreDisplay = $"Score: {score}";

        StringBuilder output = new StringBuilder();
        output.Append(scoreDisplay);
        output.Append(new string('.', xlength + 2 - scoreDisplay.Length));
        output.Append("\n");
        for (int y = 0; y < ylength; y++)
        {
            output.Append(".");
            for (int x = 0; x < xlength; x++)
            {
                Vector2 pos = new Vector2(x, y);
                if (snake.Contains(pos)) { output.Append("#"); }
                else if (pos.Equals(food)) { output.Append("@"); }
                else { output.Append(" "); }
            }
            output.Append(".");
            output.Append("\n");
        }
        output.Append(new string('.', xlength + 2));
        return output.ToString();
    }
    private Vector2 randomPos()
    {
        return new Vector2(rand.Next(xlength), rand.Next(ylength));
    }
}