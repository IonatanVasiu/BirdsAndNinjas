using BirdsAndNinjas.Pieces;
using System.Collections.Generic;

namespace BirdsAndNinjas.Validators
{
    internal interface IPieceValidator
    {
        List<(int, int)> ValidMoves(PieceTile source, PieceTile[,] board);
        List<(int, int)> ValidAttacks(PieceTile source, PieceTile[,] board);
    }
}
