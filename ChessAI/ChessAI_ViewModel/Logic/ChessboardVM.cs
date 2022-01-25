namespace ChessAI_ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.Factories;
    using ChessAI_ViewModel.Figures;
    using ChessAI_ViewModel.Logic;

    public class ChessboardVM : INotifyPropertyChanged
    {
        private string isBoardVisible;

        public string isButtonVisible;

        private List<BaseFigureVM> fields;

        private BoardVM board;

        private BoardFactoryVM factory;

        public ChessboardVM()
        {
            this.IsBoardVisible = "Collapsed";
            this.IsButtonVisible = "Visible";

            this.factory = new BoardFactoryVM();
            this.Board = this.factory.CreateBoardVM();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string IsBoardVisible
        {
            get
            {
                return this.isBoardVisible;
            }

            private set
            {
                if (value != "Collapsed" && value != "Visible")
                {
                    throw new ArgumentOutOfRangeException($"The content of {nameof(this.isBoardVisible)} must be 'Visible' or 'Collapsed'");
                }

                this.isBoardVisible = value;
            }
        }

        public string IsButtonVisible
        {
            get
            {
                return this.isButtonVisible;
            }

            private set
            {
                if (value != "Collapsed" && value != "Visible")
                {
                    throw new ArgumentOutOfRangeException($"The content of {nameof(this.isButtonVisible)} must be 'Visible' or 'Collapsed'");
                }

                this.isButtonVisible = value;
            }
        }

        public ICommand NewGameStartCommand
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.StartNewGame();
                });
            }
        }

        public List<BaseFigureVM> Fields
        {
            get
            {
                return this.fields;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.fields)} must not be null.");
                }

                this.fields = value;
            }
        }

        public BoardVM Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.board)} must not be null.");
                }

                this.board = value;
            }
        }

        private void StartNewGame()
        {
            this.IsButtonVisible = "Collapsed";
            this.IsBoardVisible = "Visible";
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsButtonVisible)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsBoardVisible)));


        }
    }
}
