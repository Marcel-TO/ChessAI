namespace ChessAI_Model.AI
{
    using System;
    using System.Collections.Generic;
    using ChessAI_Model.EventArgs;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;

    public class ChessAI
    {
        private Executioner execute;

        private List<BaseFigure[,]> possibleMoves;

        private Random random;

        public ChessAI()
        {
            this.execute = new Executioner();
            this.execute.AISelected += this.PossibleMove;
            this.possibleMoves = new List<BaseFigure[,]>();
            this.random = new Random();
        }

        public event EventHandler<BoardEventArgs> AIMoved;

        public void EvaluateMoves(Board board)
        {
            this.possibleMoves = new List<BaseFigure[,]>();
            board = this.ResetAttributes(board);

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (board.Figures[y, x].Name != "Empty" && !board.Figures[y, x].IsWhite)
                    {
                        // Gets current active piece.
                        board.CurrentActive = board.Figures[y, x];
                        board.Figures[y, x].IsActive = true;

                        // Gets all moves from the active piece.
                        List<Position> moves = board.Figures[y, x].PossibleMoves(board.Figures[y, x], board.Figures, board.Width);

                        for (int i = 0; i < moves.Count; i++)
                        {
                            Board newBoard = board.Clone(board);
                            newBoard.Figures[moves[i].Y, moves[i].X].IsSelected = true;
                            this.execute.FigureSelection(newBoard.Figures[moves[i].Y, moves[i].X], newBoard); // Gibt noch Probleme damit sich das base board nicht ändert.
                            newBoard.Figures[moves[i].Y, moves[i].X].IsSelected = false;
                        }

                        // Resets the current active piece.
                        board.CurrentActive = null;
                        board.Figures[y, x].IsActive = false;
                    }
                }
            }

            // MinMaxAlgo

            int index = this.GetIndexOfLowestDominance(this.possibleMoves, board.Width);
            board.Figures = this.possibleMoves[index];

            this.AIMoved?.Invoke(this, new BoardEventArgs(board));
        }

        protected void PossibleMove(object sender, FieldsEventArgs e)
        {
            this.possibleMoves.Add(e.Figures);
        }

        private Board ResetAttributes(Board board)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    board.Figures[y, x].IsActive = false;
                    board.Figures[y, x].IsSelected = false;
                    board.Figures[y, x].IsEndangerd = false;
                }
            }

            return board;
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

        private int GetIndexOfLowestDominance(List<BaseFigure[,]> possibleMoves, int size)
        {
            int index = this.random.Next(0, possibleMoves.Count);
            int dominance = this.CalculateSideDominance(this.possibleMoves[index], size);

            // Calculate Dominance of every possible move.
            for (int i = 0; i < this.possibleMoves.Count; i++)
            {
                int newDominance = this.CalculateSideDominance(this.possibleMoves[i], size);

                if (newDominance > dominance)
                {
                    dominance = newDominance;
                    index = i;
                }
            }

            return index;
        }

        private void MinimaxAlgorithm(List<BaseFigure[,]> possibleMoves, int size, bool aiIsWhite)
        {
            // The search depth of the minimax algorithm.
            int searchDepth = 2;
            // The list of all possible moves from each search depth.

            for (int i = searchDepth; i > 0; i++)
            {
                // Get the new possible moves for each current move.
                // Calculate dominance (get the minimum for calculating the best move for enemy).
                // Get the new possible moves again......
            }
        }

        private List<BaseFigure[,]> InitializeMoves(BaseFigure[,] currentBoard, int size, bool isWhitesTurn)
        {
            List<BaseFigure[,]> possibleMoves = new List<BaseFigure[,]>();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (currentBoard[y, x].Name != "Empty" && currentBoard[y, x].IsWhite == isWhitesTurn)
                    {
                        
                    }
                }
            }

            return possibleMoves;
        }
    }
}
