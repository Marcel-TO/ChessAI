namespace ChessAI_ViewModel.AI
{
    using ChessAI_Model.AI;
    using ChessAI_Model.EventArgs;
    using ChessAI_ViewModel.EventArgs;
    using ChessAI_ViewModel.Factories;
    using ChessAI_ViewModel.Figures;
    using ChessAI_ViewModel.Logic;
    using System;
    using System.Collections.Generic;

    public class ChessAIVM
    {
        private ChessAI chessAI;

        private BoardFactoryVM factory;

        public ChessAIVM()
        {
            this.chessAI = new ChessAI();
            this.chessAI.AIMoved += this.AIMovedPiece;
            this.factory = new BoardFactoryVM(new FigureFactoryVM());
        }

        public event EventHandler<BoardVMEventArgs> AIMoved;

        public void EvaluateMoves(BoardVM boardVM)
        {
            this.chessAI.EvaluateMoves(boardVM.Board);
        }

        protected void AIMovedPiece(object sender, BoardEventArgs e)
        {
            // Synchronise List
            this.factory.FigureVMs = new List<BaseFigureVM>();
            this.factory.SynchroniseVMList(e.Board.Figures, e.Board.Width);
            BoardVM boardVM = new BoardVM(e.Board);
            boardVM.FigureVMList = this.factory.FigureVMs;

            boardVM = this.SynchroniseBoard(boardVM);
            boardVM.Board.IsItWhitesTurn = true;

            this.AIMoved?.Invoke(this, new BoardVMEventArgs(boardVM));
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
