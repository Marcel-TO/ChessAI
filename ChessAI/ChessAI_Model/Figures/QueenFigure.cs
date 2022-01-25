namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class QueenFigure : BaseFigure
    {
        public QueenFigure(Position position, bool isWhite) : base(position, "Queen", isWhite)
        {
        }
    }
}
