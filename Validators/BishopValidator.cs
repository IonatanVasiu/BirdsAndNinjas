using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class BishopValidator : IPieceValidator
    {
        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board) =>
           GetFinalPositions(source, board)
           .Where(position => TileValidator.IsEnemyAndInBounds(source, position, board))
           .ToList();

        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board)
        {
            var (sourceRow, sourceColumn) = source.Position;
            var moves = new List<(int, int)>();
            var finalPositions = GetFinalPositions(source, board);

            foreach (var (endRow, endCol) in finalPositions)
            {
                if (endRow > sourceRow)
                {
                    if (endCol > sourceColumn)
                    {
                        for (int row = sourceRow + 1, col = sourceColumn + 1; row < endRow && col < endCol; row++, col++)
                        {
                            moves.Add((row, col));
                        }
                    }
                    else if (endCol < sourceColumn)
                    {
                        for (int row = sourceRow + 1, col = sourceColumn - 1; row < endRow && col > endCol; row++, col--)
                        {
                            moves.Add((row, col));
                        }
                    }
                }

                if (endRow < sourceRow)
                {
                    if (endCol > sourceColumn)
                    {
                        for (int row = sourceRow - 1, col = sourceColumn + 1; row > endRow && col < endCol; row--, col++)
                        {
                            moves.Add((row, col));
                        }
                    }
                    else if (endCol < sourceColumn)
                    {
                        for (int row = sourceRow - 1, col = sourceColumn - 1; row > endRow && col > endCol; row--, col--)
                        {
                            moves.Add((row, col));
                        }
                    }
                }
            }

            return moves;
        }

        private List<(int, int)> GetFinalPositions(PieceTile source, PieceTile[,] board)
        {
            var (sourceRow, sourceColumn) = source.Position;
            var finalPositions = new List<(int, int)>();

            int row = sourceRow - 1;
            int col = sourceColumn - 1;
            while (TileValidator.IsEmptyAndInBounds((row, col), board))
            {
                row--;
                col--;
            }
            finalPositions.Add((row, col));

            row = sourceRow + 1;
            col = sourceColumn + 1;
            while (TileValidator.IsEmptyAndInBounds((row, col), board))
            {
                row++;
                col++;
            }
            finalPositions.Add((row, col));

            row = sourceRow + 1;
            col = sourceColumn - 1;
            while (TileValidator.IsEmptyAndInBounds((row, col), board))
            {
                row++;
                col--;
            }
            finalPositions.Add((row, col));

            row = sourceRow - 1;
            col = sourceColumn + 1;
            while (TileValidator.IsEmptyAndInBounds((row, col), board))
            {
                row--;
                col++;
            }
            finalPositions.Add((row, col));


            return finalPositions;
        }
    }
}
