namespace ChessAI_Model.Logic
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.EventArgs;
    using ChessAI_Model.Figures;


    public class Executioner
    {
        public event EventHandler<BoardEventArgs> FigureSelected;

        public event EventHandler<FieldsEventArgs> AISelected;

        public void FigureSelection(BaseFigure current, Board board)
        {
            if (!board.IsItWhitesTurn)
            {
                this.AISelection(current, board);
                return;
            }

            if (!current.IsActive && !current.IsSelected)
            {
                // Checks if player uses an empty field.
                if (current.Name == "Empty")
                {
                    board.Figures = this.ResetFigureAttributes(board);
                    this.FigureSelected?.Invoke(this, new BoardEventArgs(board));
                    return;
                }

                // Checks that the player can only use white pieces.
                if (!current.IsWhite)
                {
                    board.Figures = this.ResetFigureAttributes(board);
                    this.FigureSelected?.Invoke(this, new BoardEventArgs(board));
                    return;
                }

                // Reset earlier attributes.
                board.Figures = this.ResetFigureAttributes(board);

                // Set new attributes.
                current.IsActive = true;
                board.CurrentActive = current;
                List<Position> moves = current.PossibleMoves(current, board.Figures, board.Width);

                // override possible move attributes to list.
                board.Figures = this.SelectPossibleMoves(moves, board);
            }
            else if (current.IsActive)
            {
                current.IsActive = false;
                board.CurrentActive = null;
            }
            else if (current.IsSelected)
            {
                board = this.MovePiece(current, board);
                board.Figures = this.ResetFigureAttributes(board);
                board.IsItWhitesTurn = false;
                board.CurrentActive.IsMoved = true;
            }

            board.Figures = this.SynchroniseBoard(board);
            this.FigureSelected?.Invoke(this, new BoardEventArgs(board));
        }

        private void AISelection(BaseFigure current, Board board)
        {
            if (!current.IsActive && !current.IsSelected)
            {
                // Checks if AI uses an empty field.
                if (current.Name == "Empty") // Useless?
                {
                    board.Figures = this.ResetFigureAttributes(board);
                    this.AISelected?.Invoke(this, new FieldsEventArgs(board.Figures)); // Wrong
                    return;
                }

                // Checks that the AI can only use black pieces.
                if (current.IsWhite) // Useless?
                {
                    board.Figures = this.ResetFigureAttributes(board);
                    this.AISelected?.Invoke(this, new FieldsEventArgs(board.Figures)); // Wrong
                    return;
                }

                // Reset earlier attributes.
                board.Figures = this.ResetFigureAttributes(board);

                // Set new attributes.
                current.IsActive = true;
                board.CurrentActive = current;
                List<Position> moves = current.PossibleMoves(current, board.Figures, board.Width);

                // override possible move attributes to list.
                board.Figures = this.SelectPossibleMoves(moves, board);
            }
            else if (current.IsActive) // Useless?
            {
                current.IsActive = false;
                board.CurrentActive = null;
            }
            else if (current.IsSelected)
            {
                board = this.MovePiece(current, board);
                board.Figures = this.ResetFigureAttributes(board);
                board.IsItWhitesTurn = true;
                board.CurrentActive.IsMoved = true;
            }

            board.Figures = this.SynchroniseBoard(board);
            this.AISelected?.Invoke(this, new FieldsEventArgs(board.Figures));
        }

        private BaseFigure[,] SynchroniseBoard(Board board)
        {
            BaseFigure[,] newOrder = new BaseFigure[board.Height, board.Width];

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    newOrder[board.Figures[y, x].Position.Y, board.Figures[y, x].Position.X] = board.Figures[y, x];
                }
            }

            return newOrder;
        }

        private BaseFigure[,] SelectPossibleMoves(List<Position> moves, Board board)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    for (int m = 0; m < moves.Count; m++)
                    {
                        if (board.Figures[y, x].Position.X == moves[m].X && board.Figures[y, x].Position.Y == moves[m].Y)
                        {
                            if (board.Figures[y, x].Name == "King")
                            {
                                board.Figures[y, x].IsEndangerd = true;
                                continue;
                            }

                            board.Figures[y, x].IsSelected = true;
                        }
                    }
                }
            }

            return board.Figures;
        }

        private BaseFigure[,] ResetFigureAttributes(Board board)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    board.Figures[y, x].IsActive = false;
                    board.Figures[y, x].IsSelected = false;
                }
            }

            return board.Figures;
        }

        private Board MovePiece(BaseFigure current, Board board)
        {
            Position figurePos = current.Position;
            Position activePos = board.CurrentActive.Position;

            if (current.Name == "Empty")
            {
                current.Position = activePos;
                board.CurrentActive.Position = figurePos;
            }
            else
            {
                current.Position = activePos;
                board.CurrentActive.Position = figurePos;
                BaseFigure NewCurrentFigure = new EmptyFigure(activePos, false);
                board.Figures = this.PutNewFigure(NewCurrentFigure, board);
            }

            return board;
        }

        private BaseFigure[,] PutNewFigure(BaseFigure newCurrentFigure, Board board)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (board.Figures[y, x].Position.X == newCurrentFigure.Position.X && board.Figures[y, x].Position.Y == newCurrentFigure.Position.Y)
                    {
                        board.Figures[y, x] = newCurrentFigure;
                    }
                }
            }

            return board.Figures;
        }
    }
}
