namespace ChessAI_Model.Logic
{
    using System;

    [Serializable]
    public class Position
    {
        private int x;

        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.x)} must be between 1 and 8");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.y)} must be between 1 and 8");
                }

                this.y = value;
            }
        }
    }
}
