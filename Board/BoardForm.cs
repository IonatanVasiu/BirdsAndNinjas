using BirdsAndNinjas.Pieces;
using BirdsAndNinjas.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BirdsAndNinjas.Board
{
    public partial class BoardForm : Form
    {
        private MainBoard _mainBoard;
        private PieceTile[,] _blackNinjas;
        private PieceTile[,] _whiteNinjas;

        private bool _isInMovingMode = false; //Click piesa pt mutare
        private PieceTile _source = null; //Piesa care va fi mutata
        private PieceTile Source
        {
            get => _source;
            set
            {
                if (value != null)
                {
                    _source = value;
                    _source.BackColor = BoardColors.SELECTED_TILE_COLOR;
                }
                else
                {
                    _source.BackColor = _source.BaseColor;
                    _source = value;
                }
            }
        }

        private bool _isWhiteTurn;
        public bool IsWhiteTurn
        {
            get => _isWhiteTurn;
            set
            {
                _isWhiteTurn = value;
                TurnBox.Text = $"{(_isWhiteTurn ? "White" : "Black")}'s turn";
            }
        }

        public BoardForm()
        {
            InitializeComponent();
            InitializeMainBoard();
            InitialiseNinjaBoards();

            IsWhiteTurn = true;
        }

        private void MainBoardClick(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            var pieceBox = sender as PieceTile;
            if (pieceBox.CurrentPiece == null)
            {
                return;
            }

            if (_isInMovingMode)
            {
                DoMove(pieceBox);
            }
            else
            {
                PrepareMove(pieceBox);
            }
        }

        private void DoMove(PieceTile destination)
        {
            if (PieceUnselected(destination))
            {
                return;
            }

            try
            {
                _mainBoard.ValidateMove(Source, destination);
                MoveToDestination(destination);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private void PrepareMove(PieceTile newSource)
        {
            if (CannotMovePiece(newSource, IsWhiteTurn))
            {
                return;
            }

            Debug.WriteLine("Moving: " + newSource.CurrentPiece.ToString());

            Source = newSource;
            _isInMovingMode = true;

            _mainBoard.PrepareMove(Source);
        }

        private void MoveToDestination(PieceTile destination)
        {
            Debug.WriteLine("Move to: " + destination.CurrentPiece.ToString());

            if (!WinIfCheckMate(destination))
            {
                destination.CurrentPiece = Source.CurrentPiece;
                Source.CurrentPiece.HasMoved = true;
                Source.CurrentPiece = Piece.None;        
                IsWhiteTurn = !IsWhiteTurn;
            }

            _isInMovingMode = false;
            Source = null;

            _mainBoard.ResetTileColors();
            _mainBoard.ResetAvailablePositions();
        }

        private bool WinIfCheckMate(PieceTile destination)
        {
            if(destination.CurrentPiece.PieceType != PieceType.King)
            {
                return false;
            }

            MessageBox.Show($"Player {(IsWhiteTurn ? "White" : "Black")} has won!");
            
            var newBoardForm = new BoardForm();
            newBoardForm.Show();
            Dispose(false);

            return true;
        }

        private bool PieceUnselected(PieceTile destination)
        {
            if (destination == Source)
            {
                Debug.WriteLine("Cancel moving " + Source.CurrentPiece.ToString());
                _isInMovingMode = false;
                Source = null;

                _mainBoard.ResetTileColors();
                return true;
            }

            if (destination.CurrentPiece.PieceType != PieceType.None && destination.CurrentPiece.IsWhite == IsWhiteTurn)
            {
                Source = null;
                PrepareMove(destination);
                return true;
            }

            return false;
        }

        private void InitializeMainBoard()
        {
            _mainBoard = new MainBoard();
            DrawMainBoard(_mainBoard.Board);
        }

        private void InitialiseNinjaBoards()
        {
            _blackNinjas = new PieceTile[2, 2]
            {
                {
                    new PieceTile(new Piece(PieceType.Ninja, false)),
                    new PieceTile(new Piece(PieceType.Ninja, false)),
                },
                {
                    new PieceTile(new Piece(PieceType.Ninja, false)),
                    new PieceTile(new Piece(PieceType.Ninja, false)),
                }
            };
            _whiteNinjas = new PieceTile[2, 2]
            {
                {
                    new PieceTile(new Piece(PieceType.Ninja, true)),
                    new PieceTile(new Piece(PieceType.Ninja, true)),
                },
                {
                    new PieceTile(new Piece(PieceType.Ninja, true)),
                    new PieceTile(new Piece(PieceType.Ninja, true)),
                }
            };
        }

        private void DrawMainBoard(PieceTile[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var piece = board[i, j];
                    if (piece is null)
                    {
                        continue;
                    }

                    piece.Position = (i, j);
                    piece.Parent = this;
                    piece.Location = new Point(j * PieceTile.LENGTH, i * PieceTile.LENGTH);
                    piece.Click += new EventHandler(MainBoardClick);

                    if (i % 2 + j % 2 != 1)
                    {
                        piece.BaseColor = BoardColors.BLACK_TILE_COLOR;
                    }
                    else
                    {
                        piece.BaseColor = BoardColors.WHITE_TILE_COLOR;
                    }

                    piece.BackgroundImageLayout = ImageLayout.Center;
                }
            }
        }

        public bool CannotMovePiece(PieceTile piece, bool isWhiteTurn) =>
            piece.CurrentPiece.PieceType == PieceType.None ||
            isWhiteTurn != piece.CurrentPiece.IsWhite;
    }
}
