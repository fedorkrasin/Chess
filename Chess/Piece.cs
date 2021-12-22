using System;

namespace Chess
{
    public class Piece
    {
        private PieceType _type;
        private PieceColor _color;
        
        public PieceType Type => _type;
        public PieceColor Color => _color;

        public Piece(PieceType type, PieceColor color)
        {
            _type = type;
            _color = color;
        }

        public override string ToString() =>
            _type switch
            {
                PieceType.Pawn => "P",
                PieceType.Bishop => "B",
                PieceType.Knight => "N",
                PieceType.Rook => "R",
                PieceType.Queen => "Q",
                PieceType.King => "K",
                _ => "\0"
            };
    }
}