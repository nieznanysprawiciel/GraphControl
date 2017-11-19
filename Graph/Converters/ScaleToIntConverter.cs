using System;
using System.Globalization;
using System.Windows.Data;



namespace Graph.Converters
{

	public class ScaleToIntConverter : IValueConverter
	{
		//
		public object		Convert		( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var result = (double)value * double.Parse( parameter.ToString(), CultureInfo.InvariantCulture );
			return (UInt32)result;
		}

		//
		public object		ConvertBack	( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return (double)value / double.Parse( parameter.ToString(), CultureInfo.InvariantCulture );
		}
	}
}
