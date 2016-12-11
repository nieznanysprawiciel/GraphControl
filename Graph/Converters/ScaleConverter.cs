using System;
using System.Globalization;
using System.Windows.Data;



namespace Graph.Converters
{

	public class ScaleConverter : IValueConverter
	{
		//
		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return (double)value * double.Parse( parameter.ToString(), CultureInfo.InvariantCulture );
		}

		//
		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return (double)value / double.Parse( parameter.ToString(), CultureInfo.InvariantCulture );
		}
	}
}
