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
            Console.WriteLine("\n—————————————————————————————————");
            
            for (var i = 0; i < boardHeight; i++)
            {
                Console.Write("|");
                    
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
                Console.WriteLine("\n—————————————————————————————————");
            }
            
            Console.WriteLine("\n");
        }

        public void Move(int prevX, int prevY, int newX, int newY)
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
    }
}