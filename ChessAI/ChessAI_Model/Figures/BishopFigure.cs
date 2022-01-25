namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class BishopFigure : BaseFigure
    {
        public BishopFigure(Position position, bool isWhite) : base(position, "Bishop", isWhite)
        {
        }
    }
}
