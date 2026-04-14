using System;
using System.Windows.Media;

namespace TetrisApp.Models
{
    /// <summary>
    /// Abstraction: Defines the basic structure of a Tetris piece.
    /// Encapsulation: Protects shape data and position.
    /// </summary>
    public abstract class Tetromino
    {
        // Encapsulation: Private fields with protected/public accessors
        protected int[,] Matrix;
        public int Row { get; set; }
        public int Column { get; set; }
        public Color Color { get; protected set; }

        public Tetromino(int columnOffset)
        {
            Row = 0;
            Column = columnOffset;
        }

        public int[,] GetMatrix() => (int[,])Matrix.Clone();

        public void Move(int rowStep, int colStep)
        {
            Row += rowStep;
            Column += colStep;
        }

        // Polymorphism: Rotation logic can be overridden if needed
        public virtual void RotateClockwise()
        {
            int size = Matrix.GetLength(0);
            int[,] rotated = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    rotated[c, size - 1 - r] = Matrix[r, c];
                }
            }
            Matrix = rotated;
        }

        public virtual void RotateCounterClockwise()
        {
            int size = Matrix.GetLength(0);
            int[,] rotated = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    rotated[size - 1 - c, r] = Matrix[r, c];
                }
            }
            Matrix = rotated;
        }
    }
}
