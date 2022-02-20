namespace ChessAI_Model.EventArgs
{
    using System;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;

    public class BoardEventArgs
    {
        private Board board;

        public BoardEventArgs(Board board)
        {
            this.Board = board;
        }

        public Board Board
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
