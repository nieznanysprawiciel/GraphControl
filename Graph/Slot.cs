using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Documents;



namespace Graph
{
	[TemplatePart( Name = "PART_MainBorder", Type = typeof( Border ) )]
	[TemplatePart( Name = "PART_TextContent", Type = typeof( ContentControl ) )]
	[TemplatePart( Name = "PART_Socket", Type = typeof( SlotSocket ) )]
	[TemplateVisualState( Name = "Normal", GroupName = "MouseStates" )]
	[TemplateVisualState( Name = "MouseOn", GroupName = "MouseStates" )]
	[TemplateVisualState( Name = "MouseClicked", GroupName = "MouseStates" )]
	public class Slot : Control
	{
		Border					MainBorder;
		SlotSocket				Socket;
		ContentControl          TextContent;



		#region DependancyProperties

		public static readonly DependencyProperty SlotColorProperty = DependencyProperty.Register( "SlotColor", typeof( Color ), typeof( Slot ), new PropertyMetadata( Colors.Green ) );
		public static readonly DependencyProperty SlotDecoratorBrushProperty = DependencyProperty.Register( "SlotDecoratorBrush", typeof( Brush ), typeof( Slot ) );
		#endregion



		static Slot()
		{
			DefaultStyleKeyProperty.OverrideMetadata( typeof( Slot ), new FrameworkPropertyMetadata( typeof( Slot ) ) );
		}


		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if( this.Template != null )
			{
				Border mainBorder = this.Template.FindName( "PART_MainBorder", this ) as Border;
				if( mainBorder != MainBorder )
				{
					MainBorder = mainBorder;
				}

				TextContent = this.Template.FindName( "PART_TextContent", this ) as ContentControl;
				Socket = this.Template.FindName( "PART_Socket", this) as SlotSocket;
			}

			this.MouseEnter += new MouseEventHandler( MouseEnterHandler );
			this.MouseLeave += new MouseEventHandler( MouseLeaveHandler );
		}

		#region EventsHandlers

		void MouseLeaveHandler( object sender, MouseEventArgs e )
		{
			VisualStateManager.GoToState( this, "Normal", true );
		}

		void MouseEnterHandler( object sender, MouseEventArgs e )
		{
			VisualStateManager.GoToState( this, "MouseOn", true );
		}

		#endregion

		#region Properties

		public Color SlotColor
		{
			get
			{
				return (Color)this.GetValue( SlotColorProperty );
			}
			set
			{
				this.SetValue( SlotColorProperty, value );
				//Socket.SetColor( value );
			}
		}

		public Brush SlotDecoratorBrush
		{
			get
			{
				return (Brush)this.GetValue( SlotDecoratorBrushProperty );
			}

			set
			{
				this.SetValue( SlotDecoratorBrushProperty, value );
			}
		}

		#endregion
	}
}
