using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class KingValidator : IPieceValidator
    {
        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board)
        {
            return GetSurroundingTiles(source, board)
                .Where(position => TileValidator.IsEnemyAndInBounds(source, position, board))
                .ToList();
        }

        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board)
        {
            return GetSurroundingTiles(source, board)
                .Where(position => TileValidator.IsEmptyAndInBounds(position, board))
                .ToList();
        }

        private IEnumerable<(int, int)> GetSurroundingTiles(PieceTile source, PieceTile[,] board)
        {
            var (sourceRow, sourceColumn) = source.Position;
            yield return (sourceRow, sourceColumn - 1);
            yield return (sourceRow, sourceColumn + 1);
            yield return (sourceRow - 1, sourceColumn);
            yield return (sourceRow + 1, sourceColumn);
            yield return (sourceRow - 1, sourceColumn - 1);
            yield return (sourceRow + 1, sourceColumn - 1);
            yield return (sourceRow + 1, sourceColumn + 1);
            yield return (sourceRow - 1, sourceColumn + 1);
        }
    }
}
