using BirdsAndNinjas.Pieces;
using System.Drawing;

namespace BirdsAndNinjas.Validators
{
    internal static class TileValidator
    {
        public static bool IsOutOfBounds((int, int) position, PieceTile[,] board)
        {
            var (row, col) = position;
            return row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1);
        }

        public static bool IsEmptyAndInBounds((int, int) position, PieceTile[,] board)
        {
            if(IsOutOfBounds(position, board))
            {
                return false;
            }

            var destination = board[position.Item1, position.Item2];

            return
                IsNotNullTile(destination)
                && destination.CurrentPiece.PieceType == PieceType.None;
        }

        public static bool IsEnemyAndInBounds(PieceTile source, (int, int) destinationPosition, PieceTile[,] board)
        {
            if (IsOutOfBounds(destinationPosition, board))
            {
                return false;
            }

            var destination = board[destinationPosition.Item1, destinationPosition.Item2];

            return 
                IsNotNullTile(destination)
            && destination.CurrentPiece.PieceType != PieceType.None
            && destination.CurrentPiece.IsWhite != source.CurrentPiece.IsWhite;
        }

        private static bool IsNotNullTile(PieceTile tile) =>
            tile != null
            && tile.CurrentPiece != null;
    }
}
