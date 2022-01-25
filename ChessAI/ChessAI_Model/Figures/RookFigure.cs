namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class RookFigure : BaseFigure
    {
        public RookFigure(Position position, bool isWhite) : base(position, "Rook", isWhite)
        {
        }
    }
}
