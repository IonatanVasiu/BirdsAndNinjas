using BirdsAndNinjas.Exceptions;
using BirdsAndNinjas.Pieces;
using BirdsAndNinjas.Utils;
using BirdsAndNinjas.Validators;
using System.Collections.Generic;
using System.Drawing;

namespace BirdsAndNinjas.Board
{
    internal class MainBoard
    {
        private readonly MoveValidator _moveValidator;

        public PieceTile[,] Board { get; private set; }

        private List<(int, int)> _availableMoves;
        private List<(int, int)> _availableAttacks;

        public MainBoard() 
        {
            Board = Initialise();
            _moveValidator = new MoveValidator();

            _availableMoves = new List<(int, int)>();
            _availableAttacks = new List<(int, int)>();
        }

        public void PrepareMove(PieceTile source)
        {
            ResetTileColors();
            InitialiseAvailableMoves(source);
            ColorTiles(_availableMoves, BoardColors.AVAILABLE_TILE_COLOR);
            ColorTiles(_availableAttacks, BoardColors.ATTACK_TILE_COLOR);
        }

        public void ValidateMove(PieceTile source, PieceTile destination)
        {
            if (source == null || destination == null)
            {
                throw new InvalidMoveException("Null source or destination.");
            }

            var (row, col) = destination.Position;
            if (!_availableMoves.Contains((row, col)) && !_availableAttacks.Contains((row, col)))
            {
                throw new InvalidMoveException($"Can't move {source.CurrentPiece} to {destination.CurrentPiece}.");
            }
        }

        private void InitialiseAvailableMoves(PieceTile source)
        {
            _availableMoves = _moveValidator.ValidMoves(source, Board);
            _availableAttacks = _moveValidator.ValidAttacks(source, Board);
        }

        private void ColorTiles(List<(int, int)> tiles, Color? color = null)
        {
            foreach (var (row, col) in tiles)
            {
                if (TileValidator.IsOutOfBounds((row, col), Board))
                {
                    continue;
                }

                if (color == null)
                {
                    Board[row, col].BackColor = Board[row, col].BaseColor;
                }
                else if (Board[row, col] != null)
                {
                    Board[row, col].BackColor = (Color)color;
                }
            }
        }

        public void ResetTileColors()
        {
            ColorTiles(_availableMoves);
            ColorTiles(_availableAttacks);
        }

        public void ResetAvailablePositions()
        {
            _availableMoves = new List<(int, int)>();
            _availableAttacks = new List<(int, int)>();
        }

        private PieceTile[,] Initialise() => Board = new PieceTile[12, 10]
        {
            {
                null,
                null,
                null,
                null,
                new PieceTile(new Piece(PieceType.Bird, false)),
                new PieceTile(new Piece(PieceType.Bird, false)),
                null,
                null,
                null,
                null,
            },
            {
                new PieceTile(new Piece(PieceType.Guard, false)),
                new PieceTile(new Piece(PieceType.Rook, false)),
                new PieceTile(new Piece(PieceType.Knight, false)),
                new PieceTile(new Piece(PieceType.Bishop, false)),
                new PieceTile(new Piece(PieceType.King, false)),
                new PieceTile(new Piece(PieceType.Queen, false)),
                new PieceTile(new Piece(PieceType.Bishop, false)),
                new PieceTile(new Piece(PieceType.Knight, false)),
                new PieceTile(new Piece(PieceType.Rook, false)),
                new PieceTile(new Piece(PieceType.Guard, false)),
            },
            {
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
                new PieceTile(new Piece(PieceType.Pawn, false)),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
                new PieceTile(),
            },
            {
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
                new PieceTile(new Piece(PieceType.Pawn, true)),
            },
            {
                new PieceTile(new Piece(PieceType.Guard, true)),
                new PieceTile(new Piece(PieceType.Rook, true)),
                new PieceTile(new Piece(PieceType.Knight, true)),
                new PieceTile(new Piece(PieceType.Bishop, true)),
                new PieceTile(new Piece(PieceType.King, true)),
                new PieceTile(new Piece(PieceType.Queen, true)),
                new PieceTile(new Piece(PieceType.Bishop, true)),
                new PieceTile(new Piece(PieceType.Knight, true)),
                new PieceTile(new Piece(PieceType.Rook, true)),
                new PieceTile(new Piece(PieceType.Guard, true)),
            },
            {
                null,
                null,
                null,
                null,
                new PieceTile(new Piece(PieceType.Bird, true)),
                new PieceTile(new Piece(PieceType.Bird, true)),
                null,
                null,
                null,
                null,
            },
        };
    }
}
