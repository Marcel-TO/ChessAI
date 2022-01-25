namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public class KingFigure : BaseFigure
    {
        public KingFigure(Position position, bool isWhite) : base(position, "King", isWhite)
        {
        }
    }
}
