namespace ChessAI_View.Converter
{
    using ChessAI_Model.Figures;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IsFigureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BishopFigure)
            {
                BishopFigure figure = (BishopFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_Bishop.png";
                }

                return "/Pictures/B_Bishop.png";
            }
            else if (value is KingFigure)
            {
                KingFigure figure = (KingFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_King.png";
                }

                return "/Pictures/B_King.png";
            }
            else if (value is KnightFigure)
            {
                KnightFigure figure = (KnightFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_Knight.png";
                }

                return "/Pictures/B_Knight.png";
            }
            else if (value is PawnFigure)
            {
                PawnFigure figure = (PawnFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_Pawn.png";
                }

                return "/Pictures/B_Pawn.png";
            }
            else if (value is QueenFigure)
            {
                QueenFigure figure = (QueenFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_Queen.png";
                }

                return "/Pictures/B_Queen.png";
            }
            else if (value is RookFigure)
            {
                RookFigure figure = (RookFigure)value;

                if (figure.IsWhite)
                {
                    return "/Pictures/W_Rook.png";
                }

                return "/Pictures/B_Rook.png";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
