namespace ChessAI_ViewModel.EventArgs
{
    using System;
    using ChessAI_ViewModel.Figures;

    public class FigureCreatedEventArg
    {
        private BaseFigureVM figure;

        public FigureCreatedEventArg(BaseFigureVM figure)
        {
            this.Figure = figure;
        }

        public BaseFigureVM Figure
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
