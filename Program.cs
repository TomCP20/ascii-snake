namespace AsciiSnake;

static class Program
{
    public static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();


        Board board = new Board(30, 10);

        while (!board.gameover)
        {
            Thread.Sleep(300);
            board.Update();
            string next = board.NextFrame();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(next);
        }
        Console.WriteLine("Thanks for playing!");
        Console.CursorVisible = true;
    }
}