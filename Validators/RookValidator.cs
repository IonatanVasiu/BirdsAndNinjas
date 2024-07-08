using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class RookValidator : IPieceValidator
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
                    for (int row = sourceRow + 1; row < endRow; row++)
                    {
                        moves.Add((row, sourceColumn));
                    }
                    continue;
                }

                if (endRow < sourceRow)
                {
                    for (int row = sourceRow - 1; row > endRow; row--)
                    {
                        moves.Add((row, sourceColumn));
                    }
                    continue;
                }

                if (endCol > sourceColumn)
                {
                    for (int col = sourceColumn + 1; col < endCol; col++)
                    {
                        moves.Add((sourceRow, col));
                    }
                    continue;
                }

                if (endCol < sourceColumn)
                {
                    for (int col = sourceColumn - 1; col > endCol; col--)
                    {
                        moves.Add((sourceRow, col));
                    }
                    continue;
                }
            }
            
            return moves;
        }

        private List<(int, int)> GetFinalPositions(PieceTile source, PieceTile[,] board)
        {
            var (sourceRow, sourceColumn) = source.Position;
            var finalPositions = new List<(int, int)>();

            int row = sourceRow - 1;
            while (TileValidator.IsEmptyAndInBounds((row, sourceColumn), board))
            {
                row--;
            }
            finalPositions.Add((row, sourceColumn));

            row = sourceRow + 1;
            while (TileValidator.IsEmptyAndInBounds((row, sourceColumn), board))
            {
                row++;
            }
            finalPositions.Add((row, sourceColumn));

            int col = sourceColumn - 1;
            while (TileValidator.IsEmptyAndInBounds((sourceRow, col), board))
            {
                col--;
            }
            finalPositions.Add((sourceRow, col));

            col = sourceColumn + 1;
            while (TileValidator.IsEmptyAndInBounds((sourceRow, col), board))
            {
                col++;
            }
            finalPositions.Add((sourceRow, col));

            return finalPositions;
        }
    }
}
