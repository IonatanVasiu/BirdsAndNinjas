using BirdsAndNinjas.Pieces;
using System.Collections.Generic;

namespace BirdsAndNinjas.Validators
{
    internal class PawnValidator : IPieceValidator
    {
        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board)
        {
            var moves = new List<(int, int)>();

            var singleMove = SingleForwardMove(source, board);
            if (singleMove != null)
            {
                moves.Add(((int, int))singleMove);

                var doubleMove = DoubleForwardMove(source, board);
                if(doubleMove != null)
                {
                    moves.Add(((int, int))doubleMove);
                }
            }
            
            return moves;
        }

        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board)
        {
            var (srcRow, srcCol) = source.Position;
            var nextRow = srcRow + 1 * GetDirection(source);
            
            var attackPositions = new List<(int, int)>();

            foreach(var position in new[] { (nextRow, srcCol - 1), (nextRow, srcCol + 1) })
            {
                if (TileValidator.IsEnemyAndInBounds(source, position, board))
                {
                    attackPositions.Add(position);
                }
            }

            return attackPositions;
        }

        private static (int, int)? DoubleForwardMove(PieceTile source, PieceTile[,] board)
        {
            if (source.CurrentPiece.HasMoved)
            {
                return null;
            }
            var (srcRow, srcCol) = source.Position;

            var destination = (srcRow + GetDirection(source) * 2, srcCol);
            if (TileValidator.IsEmptyAndInBounds(destination, board))
            {
                return destination;
            }

            return null;
        }

        private static (int, int)? SingleForwardMove(PieceTile source, PieceTile[,] board)
        {
            var (srcRow, srcCol) = source.Position;

            var destination = (srcRow + GetDirection(source), srcCol);
            if (TileValidator.IsEmptyAndInBounds(destination, board))
            {
                return destination;
            }

            return null;
        }

        private static int GetDirection(PieceTile pieceBox) => pieceBox.CurrentPiece.IsWhite ? -1 : 1;
    }
}
