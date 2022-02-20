namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public class QueenFigure : BaseFigure
    {
        public QueenFigure(Position position, bool isWhite) : base(90, position, "Queen", isWhite)
        {
        }

        public override List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size)
        {
            List<Position> moves = new List<Position>();

            // Right
            moves = this.Movement(1, 0, size, current, figures, moves, size);
            // Left
            moves = this.Movement(-1, 0, size, current, figures, moves, size);
            // Down
            moves = this.Movement(0, 1, size, current, figures, moves, size);
            // Up
            moves = this.Movement(0, -1, size, current, figures, moves, size);

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
