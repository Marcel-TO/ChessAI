namespace ChessAI_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.AI;
    using ChessAI_Model.EventArgs;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.EventArgs;
    using ChessAI_ViewModel.Factories;
    using ChessAI_ViewModel.Figures;

    public class ExecutionerVM
    {
        private Executioner execute;

        private BoardFactoryVM factory;

        public ExecutionerVM()
        {
            this.execute = new Executioner();
            this.execute.FigureSelected += this.FigureGotSelected;
            this.factory = new BoardFactoryVM(new FigureFactoryVM());
        }

        public event EventHandler<BoardVMEventArgs> FigureSelected;

        public void FigureSelection(BaseFigureVM currentFigure, BoardVM board)
        {
            this.execute.FigureSelection(currentFigure.Figure, board.Board);
        }

        protected void FigureGotSelected(object sender, BoardEventArgs e)
        {
            // Synchronise List
            this.factory.FigureVMs = new List<BaseFigureVM>();
            this.factory.SynchroniseVMList(e.Board.Figures, e.Board.Width);
            BoardVM boardVM = new BoardVM(e.Board);
            boardVM.FigureVMList = this.factory.FigureVMs;

            boardVM = this.SynchroniseBoard(boardVM);

            this.FigureSelected?.Invoke(this, new BoardVMEventArgs(boardVM));
        }

        private BoardVM SynchroniseBoard(BoardVM board)
        {
            for (int i = 0; i < board.FigureVMList.Count; i++)
            {
                if (board.FigureVMList[i].Figure.IsActive)
                {
                    board.Board.CurrentActive = board.FigureVMList[i].Figure;
                }
            }

            return board;
        }
    }
}
