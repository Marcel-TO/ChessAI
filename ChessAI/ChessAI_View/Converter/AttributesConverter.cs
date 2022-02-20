namespace ChessAI_View.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using ChessAI_Model.Figures;
    using ChessAI_ViewModel.Figures;

    public class AttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is BaseFigure)
            {
                BaseFigure figure = (BaseFigure)value;

                if (figure.IsActive)
                {
                    return "CornflowerBlue";
                }
                else if (figure.IsSelected)
                {
                    return "Aqua";
                }
                else if (figure.IsEndangerd)
                {
                    return "Red";
                }
            }

            return "Transparent";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
