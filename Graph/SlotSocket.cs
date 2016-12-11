using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graph
{


	public class SlotSocket : Control
	{

		#region Dependancy properties

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register( "Color", typeof( Color ), typeof( SlotSocket ), new PropertyMetadata( Colors.Green ) );
		public static readonly DependencyProperty SocketBrushProperty = DependencyProperty.Register( "SocketBrush", typeof( RadialGradientBrush ), typeof( SlotSocket ) );

		#endregion


		static SlotSocket()
		{
			DefaultStyleKeyProperty.OverrideMetadata( typeof( SlotSocket ), new FrameworkPropertyMetadata( typeof( SlotSocket ) ) );
		}

		public SlotSocket()
		{
			SocketBrush = CreateBrush();
		}


		private RadialGradientBrush			CreateBrush	()
		{
			var brush = new RadialGradientBrush();

			brush.GradientOrigin = new Point( 0.5, 0.5 );
			brush.Center = new Point( 0.5, 0.5 );

			GradientStop outerStop = new GradientStop();
			outerStop.Color = Colors.Blue;
			outerStop.Offset = 0.824;

			GradientStop innerStop = new GradientStop();
			outerStop.Color = Color;
			outerStop.Offset = 1.0;

			brush.GradientStops.Add( outerStop );
			brush.GradientStops.Add( innerStop );

			return brush;
		}


		#region Properties

		
		public Color Color
		{
			get
			{
				return (Color)this.GetValue( ColorProperty );
			}
			set
			{
				this.SetValue( ColorProperty, value );
			}
		}

		public RadialGradientBrush SocketBrush
		{
			get
			{
				return (RadialGradientBrush)this.GetValue( SocketBrushProperty );
			}

			set
			{
				this.SetValue( SocketBrushProperty, value );
			}
		}
		#endregion
	}
}
