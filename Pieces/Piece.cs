namespace BirdsAndNinjas.Pieces
{
    public class Piece
    {
        public PieceType PieceType { get; }
        public bool IsWhite { get; }
        public static Piece None => new Piece(PieceType.None, true);  //piesa None cand nu e piesa pe patratel
        public bool HasMoved { get; set; }

        public Piece(PieceType pieceType, bool isWhite)
        {
            PieceType = pieceType;
            IsWhite = isWhite;
            HasMoved = false;
        }

        public override string ToString()
        {
            if(PieceType == PieceType.None)
            {
                return "Empty";
            }

            return $"{(IsWhite ? "White" : "Black")} {PieceType}";
        }
    }
}
