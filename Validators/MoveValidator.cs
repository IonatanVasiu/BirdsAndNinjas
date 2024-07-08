using BirdsAndNinjas.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class MoveValidator
    {
        private readonly IPieceValidator _pawnValidator;
        private readonly IPieceValidator _knightValidator;
        private readonly IPieceValidator _rookValidator;
        private readonly IPieceValidator _bishopValidator;
        private readonly IPieceValidator _queenValidator;
        private readonly IPieceValidator _kingValidator;

        public MoveValidator() 
        { 
            _pawnValidator = new PawnValidator();
            _knightValidator = new KnightValidator();
            _rookValidator = new RookValidator();
            _bishopValidator = new BishopValidator();
            _queenValidator = new QueenValidator();
            _kingValidator = new KingValidator();
        }

        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board)
        {
            try
            {
                return ValidMoves(GetValidator(source.CurrentPiece.PieceType), source, board).ToList();
            }
            catch (Exception)
            {
                return new List<(int, int)>();
            }
        }

        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board)
        {
            try
            {
                return ValidAttacks(GetValidator(source.CurrentPiece.PieceType), source, board).ToList();
            }
            catch (Exception)
            {
                return new List<(int, int)>();
            }
        }

        private IEnumerable<(int, int)> ValidMoves(IPieceValidator validator, PieceTile source, PieceTile[,] board) =>
            validator.ValidMoves(source, board);

        private IEnumerable<(int, int)> ValidAttacks(IPieceValidator validator, PieceTile source, PieceTile[,] board) =>
            validator.ValidAttacks(source, board);

        private IPieceValidator GetValidator(PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return _pawnValidator;
                case PieceType.Knight:
                    return _knightValidator;
                case PieceType.Rook:
                    return _rookValidator;
                case PieceType.Bishop:
                    return _bishopValidator;
                case PieceType.Queen:
                    return _queenValidator;
                case PieceType.King:
                    return _kingValidator;

                default:
                    throw new ArgumentException("Unknown piece type");
            }
        }
    }
}
