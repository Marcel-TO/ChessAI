namespace ChessAI_Model.Logic
{
    using System;
    using ChessAI_Model.Figures;

    public class Board
    {
        private BaseFigure[,] figures;

        public Board(BaseFigure[,] figures)
        {
            this.Figures = figures;
        }

        public BaseFigure[,] Figures
        {
            get
            {
                return this.figures;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.figures)} must not be null.");
                }
                else if (value.Length != 64)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.figures)} must be 64 (8x8).");
                }

                this.figures = value;
            }
        }
    }
}
