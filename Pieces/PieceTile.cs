using System.Drawing;
using System.Windows.Forms;

namespace BirdsAndNinjas.Pieces
{
    public partial class PieceTile : UserControl
    {
        public const int LENGTH = 50;

        public (int, int) Position { get; set; } // (rand, coloana)      

        private Color _baseColor;
        public Color BaseColor
        {
            get => _baseColor;
            set
            {
                _baseColor = BackColor = value;
            }
        }

        private Piece _currentPiece;
        public Piece CurrentPiece
        {
            get => _currentPiece;
            set
            {
                _currentPiece = value;
                Draw();
            }
        }

        public PieceTile() : this(Piece.None) // piesa goala
        {
        }

        public PieceTile(Piece piece) // piesa negoala 
        {
            InitializeComponent();
            CurrentPiece = piece;
        }
        
        private void Draw()
        {
            BackgroundImage = ChessImageFactory.Generate(_currentPiece);
            Size = new Size(LENGTH, LENGTH);
        }
    }
}
