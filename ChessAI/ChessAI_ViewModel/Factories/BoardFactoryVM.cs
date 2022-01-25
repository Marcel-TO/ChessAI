namespace ChessAI_ViewModel.Factories
{
    using ChessAI_Model.Factories;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.Logic;
    using System;

    public class BoardFactoryVM
    {
        private BoardFactory factory;

        public BoardFactoryVM()
        {
            this.factory = new BoardFactory();
        }

        public BoardVM CreateBoardVM()
        {
            Board board = this.factory.CreateBoard();
            return new BoardVM(board);
        }
    }
}
