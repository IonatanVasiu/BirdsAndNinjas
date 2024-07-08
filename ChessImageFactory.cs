using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Drawing;

namespace BirdsAndNinjas
{
    internal static class ChessImageFactory 
    {
        private static readonly Dictionary<PieceType, Bitmap> WhitePieceImageDictionary = new Dictionary<PieceType, Bitmap>()
        {
            { PieceType.Pawn, new Bitmap(Properties.Resources.white_pawn) },
            { PieceType.Rook, new Bitmap(Properties.Resources.white_rook) },
            { PieceType.Knight, new Bitmap(Properties.Resources.white_knight) },
            { PieceType.Bishop, new Bitmap(Properties.Resources.white_bishop) },
            { PieceType.Queen, new Bitmap(Properties.Resources.white_queen) },
            { PieceType.King, new Bitmap(Properties.Resources.white_king) },
            { PieceType.Bird, new Bitmap(Properties.Resources.white_flying_bombers) },
            { PieceType.Ninja, new Bitmap(Properties.Resources.white_ninja_pawn) },
            { PieceType.Guard, new Bitmap(Properties.Resources.white_ninja_guard_) }
        };

        private static readonly Dictionary<PieceType, Bitmap> BlackPieceImageDictionary = new Dictionary<PieceType, Bitmap>()
        {
            { PieceType.Pawn, new Bitmap(Properties.Resources.black_pawn) },
            { PieceType.Rook, new Bitmap(Properties.Resources.black_rook) },
            { PieceType.Knight, new Bitmap(Properties.Resources.black_knight) },
            { PieceType.Bishop, new Bitmap(Properties.Resources.black_bishop) },
            { PieceType.Queen, new Bitmap(Properties.Resources.black_queen) },
            { PieceType.King, new Bitmap(Properties.Resources.black_king) },
            { PieceType.Bird, new Bitmap(Properties.Resources.black_flying_bombers) },
            { PieceType.Ninja, new Bitmap(Properties.Resources.black_ninja_pawn) },
            { PieceType.Guard, new Bitmap(Properties.Resources.black_ninja_guard) }
        };

        public static Bitmap Generate(Piece piece)
        {
            if(piece.PieceType == PieceType.None)
            {
                return null;
            }

            if (piece.IsWhite)
            {
                return new Bitmap(GenerateWhite(piece.PieceType), new Size(PieceTile.LENGTH, PieceTile.LENGTH));
            }
            else
            {
                return new Bitmap(GenerateBlack(piece.PieceType), new Size(PieceTile.LENGTH, PieceTile.LENGTH));
            }
        }
        
        private static Bitmap GenerateWhite(PieceType pieceType) => WhitePieceImageDictionary[pieceType];

        private static Bitmap GenerateBlack(PieceType pieceType) => BlackPieceImageDictionary[pieceType];
    }
}
