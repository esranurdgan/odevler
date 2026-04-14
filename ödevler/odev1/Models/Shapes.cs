using System.Windows.Media;

namespace TetrisApp.Models
{
    // Inheritance & Polymorphism: Specific shapes inherit from Tetromino
    
    public class IPiece : Tetromino
    {
        public IPiece() : base(3)
        {
            Matrix = new int[,] {
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            Color = Colors.Cyan;
        }
    }

    public class OPiece : Tetromino
    {
        public OPiece() : base(4)
        {
            Matrix = new int[,] {
                { 1, 1 },
                { 1, 1 }
            };
            Color = Colors.Yellow;
        }

        // Polymorphism: O Piece doesn't actually rotate
        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }

    public class TPiece : Tetromino
    {
        public TPiece() : base(3)
        {
            Matrix = new int[,] {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 }
            };
            Color = Colors.Purple;
        }
    }

    public class SPiece : Tetromino
    {
        public SPiece() : base(3)
        {
            Matrix = new int[,] {
                { 0, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
            Color = Colors.Green;
        }
    }

    public class ZPiece : Tetromino
    {
        public ZPiece() : base(3)
        {
            Matrix = new int[,] {
                { 1, 1, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }
            };
            Color = Colors.Red;
        }
    }

    public class JPiece : Tetromino
    {
        public JPiece() : base(3)
        {
            Matrix = new int[,] {
                { 1, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 }
            };
            Color = Colors.Blue;
        }
    }

    public class LPiece : Tetromino
    {
        public LPiece() : base(3)
        {
            Matrix = new int[,] {
                { 0, 0, 1 },
                { 1, 1, 1 },
                { 0, 0, 0 }
            };
            Color = Colors.Orange;
        }
    }
}
