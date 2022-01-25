namespace ChessAI_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;

    public class BoardVM
    {
        private Board board;

        public BoardVM(Board board)
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

        public List<BaseFigure> FigureList
        {
            get
            {
                return new List<BaseFigure>(this.Board.Figures.Cast<BaseFigure>().ToList());
            }
        }
    }
}
