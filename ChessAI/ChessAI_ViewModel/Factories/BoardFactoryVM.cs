namespace ChessAI_ViewModel.Factories
{
    using ChessAI_Model.Factories;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.EventArgs;
    using ChessAI_ViewModel.Figures;
    using ChessAI_ViewModel.Logic;
    using System;
    using System.Collections.Generic;

    public class BoardFactoryVM
    {
        private BoardFactory factory;

        private FigureFactoryVM figureFactory;

        private List<BaseFigureVM> figureVMs;

        public BoardFactoryVM(FigureFactoryVM figureFactory)
        {
            this.factory = new BoardFactory();
            this.figureFactory = figureFactory;
            this.figureFactory.FigureCreated += this.FigureCreated;
            this.FigureVMs = new List<BaseFigureVM>();
        }

        public List<BaseFigureVM> FigureVMs
        {
            get
            {
                return this.figureVMs;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.figureVMs)} must not be null.");
                }

                this.figureVMs = value;
            }
        }

        public BoardVM CreateBoardVM(int xSize, int ySize)
        {
            Board board = this.factory.CreateBoard(xSize, ySize);
            this.FigureVMs = new List<BaseFigureVM>();
            this.SynchroniseVMList(board.Figures, board.Width);
            BoardVM boardVM = new BoardVM(board);
            boardVM.FigureVMList = this.figureVMs;
            return boardVM;
        }

        public void SynchroniseVMList(BaseFigure[,] figures, int size)
        {
            List<BaseFigureVM> figureVMs = new List<BaseFigureVM>();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    figures[y, x].Accept(this.figureFactory);
                }
            }
        }

        protected void FigureCreated(object sender, FigureCreatedEventArg e)
        {
            this.FigureVMs.Add(e.Figure);
        }
    }
}
