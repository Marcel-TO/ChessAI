namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class EmptyFigure : BaseFigure
    {
        public EmptyFigure(Position position, bool isWhite) : base(position, "Empty", isWhite)
        {
        }
    }
}
