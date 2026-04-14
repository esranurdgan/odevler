using System;
using System.Windows.Media;

namespace TetrisApp.Models
{
    /// <summary>
    /// Encapsulation: Manages the internal 2D grid of the game.
    /// </summary>
    public class GameBoard
    {
        private readonly Color?[] _cells; // Flat array for easier indexing, or use [,]
        public int Rows { get; }
        public int Columns { get; }

        public GameBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _cells = new Color?[rows * columns];
        }

        public Color? GetCell(int r, int c)
        {
            if (r < 0 || r >= Rows || c < 0 || c >= Columns) return null;
            return _cells[r * Columns + c];
        }

        public void SetCell(int r, int c, Color? color)
        {
            if (r >= 0 && r < Rows && c >= 0 && c < Columns)
            {
                _cells[r * Columns + c] = color;
            }
        }

        public bool IsEmpty(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns && _cells[r * Columns + c] == null;
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public int ClearFullRows()
        {
            int cleared = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    MoveRowsDown(r, 1);
                    r++; // Check the same row index again as it now has new content
                    cleared++;
                }
            }
            return cleared;
        }

        private bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (_cells[r * Columns + c] == null) return false;
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                _cells[r * Columns + c] = null;
            }
        }

        private void MoveRowsDown(int r, int numRows)
        {
            for (int row = r - 1; row >= 0; row--)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Color? color = _cells[row * Columns + col];
                    _cells[(row + numRows) * Columns + col] = color;
                    _cells[row * Columns + col] = null;
                }
            }
        }
    }
}
