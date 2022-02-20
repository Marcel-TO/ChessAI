namespace ChessAI_ViewModel.EventArgs
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Figures;
    using ChessAI_ViewModel.Figures;
    using ChessAI_ViewModel.Logic;

    public class BoardVMEventArgs
    {
        private BoardVM board;

        public BoardVMEventArgs(BoardVM board)
        {
            this.Board = board;
        }

        public BoardVM Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.board)} must not be null.");
                }

                this.board = value;
            }
        }
    }
}
