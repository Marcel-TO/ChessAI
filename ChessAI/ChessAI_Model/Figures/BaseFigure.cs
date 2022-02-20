namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public abstract class BaseFigure : IVisitable
    {
        private Position position;

        private string name;

        private int points;

        public BaseFigure(int points, Position position, string name, bool isWhite)
        {
            this.Points = points;
            this.Position = new Position(position.X, position.Y);
            this.Name = name;
            this.IsWhite = isWhite;
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                if (value < -900 || value > 900)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.points)} must be within the range of -900 and 900.");
                }

                this.points = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
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

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }

        public bool IsEndangerd
        {
            get;
            set;
        }

        public bool IsMoved
        {
            get;
            set;
        }

        public abstract List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size);

        public abstract void Accept(IVisitor visitor);

        protected virtual List<Position> Movement(int deltaX, int deltaY, int amountOfMoves, BaseFigure current, BaseFigure[,] figures, List<Position> moves, int size)
        {
            if ((deltaX < -2 && deltaY < -2) || (deltaX > 2 && deltaY > 2))
            {
                throw new ArgumentOutOfRangeException($"The values {deltaX} and {deltaY} must be between -2 and 2.");
            }

            int xPos = current.Position.X + deltaX;
            int yPos = current.Position.Y + deltaY;
            int moveCount = 0;

            while (xPos < size && yPos < size && xPos >= 0 && yPos >= 0)
            {
                // Check if field is empty.
                if (figures[yPos, xPos].Name == "Empty")
                {
                    moves.Add(new Position(xPos, yPos));
                }
                // Check if field is not the same color.
                else if (figures[yPos, xPos].IsWhite != current.IsWhite)
                {
                    moves.Add(new Position(xPos, yPos));
                    break;
                }
                // Hits figure of same color.
                else
                {
                    break;
                }
                

                xPos += deltaX;
                yPos += deltaY;
                moveCount++;

                // Check if movement count is reached.
                if (moveCount >= amountOfMoves)
                {
                    break;
                }
            }

            return moves;
        }
    }
}
