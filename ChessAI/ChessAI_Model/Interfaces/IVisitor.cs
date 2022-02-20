namespace ChessAI_Model.Interfaces
{
    using System;
    using ChessAI_Model.Figures;

    public interface IVisitor
    {
        void Accept(BishopFigure figure);

        void Accept(EmptyFigure figure);

        void Accept(KingFigure figure);

        void Accept(KnightFigure figure);

        void Accept(PawnFigure figure);

        void Accept(QueenFigure figure);

        void Accept(RookFigure figure);
    }
}
