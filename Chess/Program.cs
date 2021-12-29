using System;

namespace Chess
{
    class Program
    {
        private static void Main()
        {
            var board = new Chessboard();
            board.Show();
            board.Move();
            board.Show();
            // board.Move();
        }
    }
}