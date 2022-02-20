namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public class EmptyFigure : BaseFigure
    {
        public EmptyFigure(Position position, bool isWhite) : base(0, position, "Empty", isWhite)
        {
        }

        public override List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size)
        {
            return new List<Position>();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
