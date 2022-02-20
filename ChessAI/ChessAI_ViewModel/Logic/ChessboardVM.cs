namespace ChessAI_ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using ChessAI_Model.Figures;
    using ChessAI_Model.Interfaces;
    using ChessAI_Model.Logic;
    using ChessAI_ViewModel.AI;
    using ChessAI_ViewModel.EventArgs;
    using ChessAI_ViewModel.Factories;
    using ChessAI_ViewModel.Figures;
    using ChessAI_ViewModel.Logic;

    public class ChessboardVM : INotifyPropertyChanged
    {
        private string isBoardVisible;

        public string isButtonVisible;

        private ObservableCollection<BaseFigureVM> fields;

        private BoardVM board;

        private BoardFactoryVM factory;

        private ExecutionerVM execute;

        private ChessAIVM chessAI;

        public ChessboardVM()
        {
            this.IsBoardVisible = "Collapsed";
            this.IsButtonVisible = "Visible";

            this.chessAI = new ChessAIVM();
            this.chessAI.AIMoved += this.AIMoved;
            this.execute = new ExecutionerVM();
            this.execute.FigureSelected += this.FigureSelected;
            this.factory = new BoardFactoryVM(new FigureFactoryVM());
            this.Board = this.factory.CreateBoardVM(8, 8);
            this.Fields = new ObservableCollection<BaseFigureVM>(this.Board.FigureVMList);
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

        public ICommand SelectFigureCommand
        {
            get
            {
                return new GenericCommand(figureObj =>
                {
                    this.SelectFigure(figureObj);
                });
            }
        }

        public ObservableCollection<BaseFigureVM> Fields
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

        private void SelectFigure(object figureObj)
        {
            if (figureObj is BaseFigureVM)
            {
                BaseFigureVM figure = (BaseFigureVM)figureObj;
                this.execute.FigureSelection(figure, this.Board);
            }
        }

        protected void FigureSelected(object sender, BoardVMEventArgs e)
        {
            this.Board = e.Board;
            this.Fields = new ObservableCollection<BaseFigureVM>(this.Board.FigureVMList);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Board)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Fields)));

            if (!this.Board.Board.IsItWhitesTurn) 
            {
                this.chessAI.EvaluateMoves(this.Board);
            }
        }

        protected void AIMoved(object sender, BoardVMEventArgs e)
        {
            this.Board = e.Board;
            this.Fields = new ObservableCollection<BaseFigureVM>(this.Board.FigureVMList);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Board)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Fields)));
        }
    }
}
