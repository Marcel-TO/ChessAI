namespace ChessAI_Model.Figures
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;

    [Serializable]
    public class PawnFigure : BaseFigure
    {
        public PawnFigure(Position position, bool isWhite) : base(10, position, "Pawn", isWhite)
        {
        }

        public override List<Position> PossibleMoves(BaseFigure current, BaseFigure[,] figures, int size)
        {
            List<Position> moves = new List<Position>();

            // Checks white movements.
            if (this.IsWhite)
            {
                // Movement if pawn didnt't move since start.
                if (!this.IsMoved)
                {
                    moves = this.SpecialMovement(0, -1, 2, current, figures, moves, size);
                }

                moves = this.Movement(0, -1, 1, current, figures, moves, size);
            }
            // Checks black movements.
            else
            {
                // Movement if pawn didnt't move since start.
                if (!this.IsMoved)
                {
                    moves = this.SpecialMovement(0, 1, 2, current, figures, moves, size);
                }

                moves = this.Movement(0, 1, 1, current, figures, moves, size);
            }

            return moves;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Accept(this);
        }

        protected override List<Position> Movement(int deltaX, int deltaY, int amountOfMoves, BaseFigure current, BaseFigure[,] figures, List<Position> moves, int size)
        {
            if ((deltaX < -2 && deltaY < -2) || (deltaX > 2 && deltaY > 2))
            {
                throw new ArgumentOutOfRangeException($"The values {deltaX} and {deltaY} must be between -2 and 2.");
            }

            int xPos = current.Position.X + deltaX;
            int yPos = current.Position.Y + deltaY;
            int moveCount = 0;

            while (xPos <= 7 && yPos <= 7 && xPos >= 0 && yPos >= 0)
            {
                // Check if field is empty.
                if (figures[yPos, xPos].Name == "Empty")
                {
                    moves.Add(new Position(xPos, yPos));
                }

                // Checks if pawn can hit right.
                if (xPos + 1 < 7)
                {
                    if (figures[yPos, xPos + 1].Name != "Empty" && figures[yPos, xPos + 1].IsWhite != current.IsWhite)
                    {
                        moves.Add(new Position(xPos + 1, yPos));
                    }
                }

                // Checks if pawn can hit left.
                if (xPos - 1 >= 0)
                {
                    if (figures[yPos, xPos - 1].Name != "Empty" && figures[yPos, xPos - 1].IsWhite != current.IsWhite)
                    {
                        moves.Add(new Position(xPos - 1, yPos));
                    }
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

        private List<Position> SpecialMovement(int deltaX, int deltaY, int amountOfMoves, BaseFigure current, BaseFigure[,] figures, List<Position> moves, int size)
        {
            if ((deltaX < -2 && deltaY < -2) || (deltaX > 2 && deltaY > 2))
            {
                throw new ArgumentOutOfRangeException($"The values {deltaX} and {deltaY} must be between -2 and 2.");
            }

            int xPos = current.Position.X + deltaX;
            int yPos = current.Position.Y + deltaY;
            int moveCount = 0;

            while (xPos <= 7 && yPos <= 7 && xPos >= 0 && yPos >= 0)
            {
                // Check if field is empty.
                if (figures[yPos, xPos].Name == "Empty")
                {
                    moves.Add(new Position(xPos, yPos));
                }
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
