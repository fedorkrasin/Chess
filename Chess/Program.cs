using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Chessboard();
            board.Show();
            board.Move(0,1,2,2);
            board.Show();
        }
    }
}