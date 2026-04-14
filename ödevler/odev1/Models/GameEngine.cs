using System;
using System.Collections.Generic;

namespace TetrisApp.Models
{
    public class GameEngine
    {
        private readonly Tetromino[] _tetrominoes = new Tetromino[]
        {
            new IPiece(), new JPiece(), new LPiece(), new OPiece(), new SPiece(), new TPiece(), new ZPiece()
        };

        private readonly Random _random = new Random();

        public GameBoard Board { get; }
        public Tetromino CurrentPiece { get; private set; }
        public Tetromino NextPiece { get; private set; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }

        public GameEngine(int rows, int cols)
        {
            Board = new GameBoard(rows, cols);
            NextPiece = GetRandomPiece();
            CurrentPiece = GetRandomPiece();
        }

        private Tetromino GetRandomPiece()
        {
            // Abstraction: Selecting a piece from the pool without caring about its specific type
            int index = _random.Next(_tetrominoes.Length);
            return (Tetromino)Activator.CreateInstance(_tetrominoes[index].GetType());
        }

        public void RotatePiece()
        {
            CurrentPiece.RotateClockwise();
            if (!PieceFits())
            {
                CurrentPiece.RotateCounterClockwise();
            }
        }

        public void MovePieceLeft()
        {
            CurrentPiece.Move(0, -1);
            if (!PieceFits())
            {
                CurrentPiece.Move(0, 1);
            }
        }

        public void MovePieceRight()
        {
            CurrentPiece.Move(0, 1);
            if (!PieceFits())
            {
                CurrentPiece.Move(0, -1);
            }
        }

        public bool MovePieceDown()
        {
            CurrentPiece.Move(1, 0);
            if (!PieceFits())
            {
                CurrentPiece.Move(-1, 0);
                PlacePiece();
                return true; // Piece landed
            }
            return false; // Piece still falling
        }

        private bool PieceFits()
        {
            int[,] matrix = CurrentPiece.GetMatrix();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 0) continue;
                    
                    int boardRow = CurrentPiece.Row + r;
                    int boardCol = CurrentPiece.Column + c;

                    if (!Board.IsInside(boardRow, boardCol) || !Board.IsEmpty(boardRow, boardCol))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void PlacePiece()
        {
            int[,] matrix = CurrentPiece.GetMatrix();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        Board.SetCell(CurrentPiece.Row + r, CurrentPiece.Column + c, CurrentPiece.Color);
                    }
                }
            }

            Score += 10;
            Score += Board.ClearFullRows() * 100;

            CurrentPiece = NextPiece;
            NextPiece = GetRandomPiece();

            if (!PieceFits())
            {
                GameOver = true;
            }
        }

    }
}
