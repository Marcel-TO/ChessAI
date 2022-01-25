namespace ChessAI_Model.Factories
{
    using System;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;

    public class BoardFactory
    {
        public Board CreateBoard()
        {
            BaseFigure[,] figures = this.CreateFigures();

            return new Board(figures);
        }

        private BaseFigure[,] CreateFigures()
        {
            BaseFigure[,] figures = new BaseFigure[8, 8];
            figures = this.CreateBlackFigures(figures);

            for (int y = 2; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    figures[y, x] = new EmptyFigure(new Position(x, y), false);
                }
            }

            figures = this.CreateWhiteFigures(figures);

            return figures;
        }

        private BaseFigure[,] CreateBlackFigures(BaseFigure[,] currentFigures)
        {
            currentFigures[0, 0] = new RookFigure(new Position(0, 0), false);
            currentFigures[0, 1] = new KnightFigure(new Position(1, 0), false);
            currentFigures[0, 2] = new BishopFigure(new Position(2, 0), false);
            currentFigures[0, 3] = new KingFigure(new Position(3, 0), false);
            currentFigures[0, 4] = new QueenFigure(new Position(4, 0), false);
            currentFigures[0, 5] = new BishopFigure(new Position(5, 0), false);
            currentFigures[0, 6] = new KnightFigure(new Position(6, 0), false);
            currentFigures[0, 7] = new RookFigure(new Position(7, 0), false);

            for (int x = 0; x < 8; x++)
            {
                currentFigures[1, x] = new PawnFigure(new Position(x, 1), false);
            }

            return currentFigures;
        }

        private BaseFigure[,] CreateWhiteFigures(BaseFigure[,] currentFigures)
        {
            currentFigures[7, 0] = new RookFigure(new Position(0, 7), true);
            currentFigures[7, 1] = new KnightFigure(new Position(1, 7), true);
            currentFigures[7, 2] = new BishopFigure(new Position(2, 7), true);
            currentFigures[7, 3] = new KingFigure(new Position(3, 7), true);
            currentFigures[7, 4] = new QueenFigure(new Position(4, 7), true);
            currentFigures[7, 5] = new BishopFigure(new Position(5, 7), true);
            currentFigures[7, 6] = new KnightFigure(new Position(6, 7), true);
            currentFigures[7, 7] = new RookFigure(new Position(7, 7), true);

            for (int x = 0; x < 8; x++)
            {
                currentFigures[6, x] = new PawnFigure(new Position(x, 6), true);
            }

            return currentFigures;
        }
    }
}
