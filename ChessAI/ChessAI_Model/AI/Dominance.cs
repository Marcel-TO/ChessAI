namespace ChessAI_Model.AI
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Figures;

    public class Dominance
    {
        private BaseFigure[,] move;

        private int size;

        public Dominance(BaseFigure[,] move, int size)
        {
            this.Move = move;
            this.Size = size;
            this.PossibleMoves = new List<Dominance>();
        }

        public BaseFigure[,] Move
        {
            get
            {
                return this.move;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.move)} must not be null.");
                }

                this.move = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.size)} must not be less than 1.");
                }

                this.size = value;
            }
        }

        public int DominanceFaktor
        {
            get
            {
                return this.CalculateSideDominance(this.Move, this.size);
            }
        }

        public List<Dominance> PossibleMoves
        {
            get;
            set;
        }

        private int CalculateSideDominance(BaseFigure[,] figures, int size)
        {
            int dominance = 0;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (figures[y, x].IsWhite)
                    {
                        dominance -= figures[y, x].Points;
                        continue;
                    }

                    dominance += figures[y, x].Points;
                }
            }

            return dominance;
        }
    }
}
