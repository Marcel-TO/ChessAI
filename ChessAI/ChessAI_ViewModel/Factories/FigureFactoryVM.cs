namespace ChessAI_ViewModel.Factories
{
    using System;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Interfaces;
    using ChessAI_ViewModel.EventArgs;
    using ChessAI_ViewModel.Figures;

    public class FigureFactoryVM : IVisitor
    {
        public event EventHandler<FigureCreatedEventArg> FigureCreated;

        public void Accept(BishopFigure figure)
        {
            BishopFigureVM figureVM = new BishopFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(EmptyFigure figure)
        {
            EmptyFigureVM figureVM = new EmptyFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(KingFigure figure)
        {
            KingFigureVM figureVM = new KingFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(KnightFigure figure)
        {
            KnightFigureVM figureVM = new KnightFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(PawnFigure figure)
        {
            PawnFigureVM figureVM = new PawnFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(QueenFigure figure)
        {
            QueenFigureVM figureVM = new QueenFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }

        public void Accept(RookFigure figure)
        {
            RookFigureVM figureVM = new RookFigureVM(figure);
            this.FigureCreated?.Invoke(this, new FigureCreatedEventArg(figureVM));
        }
    }
}
