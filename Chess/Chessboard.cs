using System;

namespace Chess
{
    public class Chessboard
    {
        private const int boardWidth = 8;
        private const int boardHeight = 8;

        private Piece[,] _board = new Piece[boardHeight, boardWidth];

        public Chessboard()
        {
            for (var i = 0; i < boardHeight; i++)
            {
                var color = i < 3 ? PieceColor.Black : PieceColor.White;

                for (var j = 0; j < boardWidth; j++)
                {
                    if (i < 2 || i > 5)
                    {
                        var type = PieceType.Pawn;
                        
                        if (i == 0 || i == boardHeight - 1)
                        {
                            switch (j)
                            {
                                case 0:
                                case boardWidth - 1:
                                    type = PieceType.Rook;
                                    break;
                                case 1:
                                case boardWidth - 2:
                                    type = PieceType.Knight;
                                    break;
                                case 2:
                                case boardWidth - 3:
                                    type = PieceType.Bishop;
                                    break;
                                case 3:
                                    type = PieceType.Queen;
                                    break;
                                case 4:
                                    type = PieceType.King;
                                    break;
                            }
                        }
                        
                        _board[i, j] = new Piece(type, color);
                    }
                }
            }
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\n   —————————————————————————————————");
            
            for (var i = 0; i < boardHeight; i++)
            {
                Console.Write($" {boardHeight - i} |");
                    
                for (var j = 0; j < boardWidth; j++)
                {
                    if ((i + j) % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Green;
                    
                    if (_board[i, j] is not null)
                    {
                        if (_board[i, j].Color == PieceColor.White) Console.ForegroundColor = ConsoleColor.White;
                        else Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" " + _board[i, j] + " ");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n   —————————————————————————————————");
            }
            
            Console.WriteLine("     A   B   C   D   E   F   G   H\n");
        }

        private void Move(int prevY, int prevX, int newY, int newX)
        {
            if (_board[prevX, prevY] != null)
            {
                _board[newX, newY] = _board[prevX, prevY];
                _board[prevX, prevY] = null;
            }
            else
            {
                Console.WriteLine("no piece!");
            }
        }

        public void Move()
        {
            while (true)
            {
                Console.Write("Your turn: ");
                var turn = Console.ReadLine();
                if (turn == null)
                {
                    Console.WriteLine("null");
                    continue;
                }

                var firstPositionString = turn[..2];
                var secondPositionString = turn[3..];

                var firstPosition = MoveToInt(firstPositionString);
                var secondPosition = MoveToInt(secondPositionString);
                
                Move(firstPosition.Item1, firstPosition.Item2, secondPosition.Item1, secondPosition.Item2);
                
                break;
            }
        }
        
        private static (int, int) MoveToInt(string move)
        {
            var moveUpper = move.ToUpper();
            var horizontal = (moveUpper[0] - '0') % 17;
            var vertical = boardHeight - 1 - (moveUpper[1] - '0' - 1);
            Console.WriteLine((horizontal, vertical));
            return (horizontal, vertical);
        }
    }
}