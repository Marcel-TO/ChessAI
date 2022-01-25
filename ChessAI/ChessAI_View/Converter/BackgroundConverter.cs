namespace ChessAI_View.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using ChessAI_Model.Logic;

    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Position)
            {
                Position pos = (Position)value;

                if (pos.Y % 2 == 0)
                {
                    if (pos.X % 2 == 0)
                    {
                        return "/Pictures/wood.jpg";
                    }

                    return "/Pictures/marble.jpg";
                }

                if (pos.X % 2 == 0)
                {
                    return "/Pictures/marble.jpg";
                }

                return "/Pictures/wood.jpg";
            }

            return "Transparent";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
