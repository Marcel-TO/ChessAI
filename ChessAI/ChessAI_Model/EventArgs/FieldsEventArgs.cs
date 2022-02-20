namespace ChessAI_Model.EventArgs
{
    using System;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;

    public class FieldsEventArgs
    {
        private BaseFigure[,] figures;

        public FieldsEventArgs(BaseFigure[,] figures)
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

                this.figures = value;
            }
        }
    }
}
