using BirdsAndNinjas.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace BirdsAndNinjas.Validators
{
    internal class QueenValidator : IPieceValidator
    {
        private readonly IPieceValidator _bishopValidator;
        private readonly IPieceValidator _rookValidator;

        public QueenValidator()
        {
            _bishopValidator = new BishopValidator();
            _rookValidator = new RookValidator();
        }

        public List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board)
        {
            return _bishopValidator.ValidAttacks(source, board)
                .Concat(_rookValidator.ValidAttacks(source, board))
                .ToList();
        }

        public List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board)
        {
            return _bishopValidator.ValidMoves(source, board)
                .Concat(_rookValidator.ValidMoves(source, board))
                .ToList();
        }
    }
}
