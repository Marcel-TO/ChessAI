namespace ChessAI_ViewModel.Figures
{
    using System;
    using ChessAI_Model.Figures;

    public class BaseFigureVM
    {
        private BaseFigure figure;

        public BaseFigureVM(BaseFigure figure)
        {
            this.Figure = figure;
        }

        public BaseFigure Figure
        {
            get
            {
                return this.figure;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.figure)} must not be null.");
                }

                this.figure = value;
            }
        }
    }
}
