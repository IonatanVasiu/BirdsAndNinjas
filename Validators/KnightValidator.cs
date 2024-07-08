using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class KnightValidator : IPieceValidator
    {
        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board) => 
            GetPossibleMoves(source)
            .Where(position => TileValidator.IsEmptyAndInBounds((position.Item1, position.Item2), board))
            .ToList();

        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board) =>
            GetPossibleMoves(source)
            .Where(position => TileValidator.IsEnemyAndInBounds(source, position, board))
            .ToList();

        private List<(int, int)> GetPossibleMoves(PieceTile source)
        {
            var (srcRow, srcCol) = source.Position;

            return new List<(int, int)>()
            {
                (srcRow + 2, srcCol + 1),
                (srcRow + 2, srcCol - 1),

                (srcRow - 2, srcCol + 1),
                (srcRow - 2, srcCol - 1),

                (srcRow + 1, srcCol + 2),
                (srcRow - 1, srcCol + 2),

                (srcRow + 1, srcCol - 2),
                (srcRow - 1, srcCol - 2),
            };
        }
    }
}
