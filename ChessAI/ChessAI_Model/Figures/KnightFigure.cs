namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public class KnightFigure : BaseFigure
    {
        public KnightFigure(Position position, bool isWhite) : base(30, position, "Knight", isWhite)
        {
        }

        public override List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size)
        {
            List<Position> moves = new List<Position>();

            // TopRight
            moves = this.Movement(1, -2, 1, current, figures, moves, size);
            // TopLeft
            moves = this.Movement(-1, -2, 1, current, figures, moves, size);
            // BottomRight
            moves = this.Movement(1, 2, 1, current, figures, moves, size);
            // BottomLeft
            moves = this.Movement(-1, 2, 1, current, figures, moves, size);
            // RightTop
            moves = this.Movement(2, -1, 1, current, figures, moves, size);
            // RightBottom
            moves = this.Movement(2, 1, 1, current, figures, moves, size);
            // LeftTop
            moves = this.Movement(-2, -1, 1, current, figures, moves, size);
            // LeftBottom
            moves = this.Movement(-2, 1, 1, current, figures, moves, size);

            return moves;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
