using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Graph
{

	[TemplateVisualState( Name = "Normal", GroupName = "MouseStates" )]
	[TemplateVisualState( Name = "MouseOn", GroupName = "MouseStates" )]
	[TemplateVisualState( Name = "MouseClicked", GroupName = "MouseStates" )]
	public class SlotSocket : Control
	{

		#region DependencyProperties

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register( "Color", typeof( Color ), typeof( SlotSocket ), new PropertyMetadata( Colors.Green ) );
		public static readonly DependencyProperty SocketBrushProperty = DependencyProperty.Register( "SocketBrush", typeof( RadialGradientBrush ), typeof( SlotSocket ) );

		#endregion


		static SlotSocket()
		{
			DefaultStyleKeyProperty.OverrideMetadata( typeof( SlotSocket ), new FrameworkPropertyMetadata( typeof( SlotSocket ) ) );
		}



		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			SocketBrush = CreateBrush( Color );

			this.MouseEnter += new MouseEventHandler( MouseEnterHandler );
			this.MouseLeave += new MouseEventHandler( MouseLeaveHandler );
		}


		#region EventsHandlers

		void		MouseLeaveHandler		( object sender, MouseEventArgs e )
		{
			VisualStateManager.GoToState( this, "Normal", true );
		}

		void		MouseEnterHandler		( object sender, MouseEventArgs e )
		{
			VisualStateManager.GoToState( this, "MouseOn", true );
		}

		#endregion

		#region ControlLogic

		private RadialGradientBrush		CreateBrush	( Color color )
		{
			var brush = new RadialGradientBrush();

			brush.GradientOrigin = new Point( 0.5, 0.5 );
			brush.Center = new Point( 0.5, 0.5 );

			GradientStop outerStop = new GradientStop();
			outerStop.Color = color;
			outerStop.Offset = 0.824;

			GradientStop innerStop = new GradientStop();
			innerStop.Color = (Color)ColorConverter.ConvertFromString( "#FF838383" );
			innerStop.Offset = 1.0;

			brush.GradientStops.Add( outerStop );
			brush.GradientStops.Add( innerStop );

			return brush;
		}

		public void						SetColor	( Color color )
		{
			SocketBrush = CreateBrush( color );
		}

		#endregion

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
				SocketBrush = CreateBrush( value );
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
