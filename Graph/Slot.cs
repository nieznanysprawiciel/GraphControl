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
	public class Slot : Control
	{
		Border					MainBorder;
		SlotSocket				Socket;
		ContentControl          TextContent;


		//// Resources
		//GradientBrush           m_socketBrush;

		#region DependancyProperties

		public static readonly DependencyProperty SlotColorProperty = DependencyProperty.Register( "SlotColor", typeof( Color ), typeof( Slot ), new PropertyMetadata( Colors.Green ) );

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
				Border mainBorder = this.Template.FindName("PART_MainBorder", this) as Border;
				if( mainBorder != MainBorder )
				{
					MainBorder = mainBorder;
				}

				TextContent = this.Template.FindName( "PART_TextContent", this ) as ContentControl;
				Socket = this.Template.FindName( "PART_Socket", this) as SlotSocket;
			}
		}

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
			}
		}


		#endregion
	}
}
