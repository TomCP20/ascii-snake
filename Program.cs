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
            board.Update();

            string next = board.NextFrame();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(next);

            Thread.Sleep(300);
        }
        Console.WriteLine("Thanks for playing!");
        Console.CursorVisible = true;
    }
}