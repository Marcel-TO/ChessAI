namespace ChessAI_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.Figures;

    public class BoardVM
    {
        private Board board;

        private List<BaseFigureVM> figureVMList;

        public BoardVM(Board board)
        {
            this.Board = board;
            this.figureVMList = new List<BaseFigureVM>();
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

        public List<BaseFigureVM> FigureVMList
        {
            get
            {
                return this.figureVMList;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.figureVMList)} must not be null.");
                }

                this.figureVMList = value;
            }
        }
    }
}
