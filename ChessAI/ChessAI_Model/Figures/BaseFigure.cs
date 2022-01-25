namespace ChessAI_Model.Figures
{
    using ChessAI_Model.Logic;
    using System;

    public abstract class BaseFigure
    {
        private Position position;

        private string name;

        public BaseFigure(Position position, string name, bool isWhite)
        {
            this.Position = position;
            this.Name = name;
            this.IsWhite = isWhite;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.position)} must not be null.");
                }

                this.position = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.name)} must not be null.");
                }

                this.name = value;
            }
        }

        public bool IsWhite
        {
            get;
            private set;
        }
    }
}
