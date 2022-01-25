namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class PawnFigure : BaseFigure
    {
        public PawnFigure(Position position, bool isWhite) : base(position, "Pawn", isWhite)
        {
        }
    }
}
