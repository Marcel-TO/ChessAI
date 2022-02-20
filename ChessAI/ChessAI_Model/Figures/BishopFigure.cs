namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public class BishopFigure : BaseFigure
    {
        public BishopFigure(Position position, bool isWhite) : base(30, position, "Bishop", isWhite)
        {
        }

        public override List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size)
        {
            List<Position> moves = new List<Position>();

            // UpperRight
            moves = this.Movement(1, -1, size, current, figures, moves, size);
            // UpperLeft
            moves = this.Movement(-1, -1, size, current, figures, moves, size);
            // LowerRight
            moves = this.Movement(1, 1, size, current, figures, moves, size);
            // LowerLeft
            moves = this.Movement(-1, 1, size, current, figures, moves, size);

            return moves;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
