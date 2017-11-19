using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTestApp.GraphRepr
{
	public class GraphNodeRepr
	{
		ObservableCollection< string >      m_slots;


		string								GroupName { get; set; }

		public GraphNodeRepr()
		{
			m_slots = new ObservableCollection<string>();

			m_slots.Add( "First slot" );
			m_slots.Add( "Name" );
			m_slots.Add( "RenderTarget" );

			GroupName = "GroupName";
		}




		public ObservableCollection< string > Slots
		{
			get
			{
				return m_slots;
			}

			set
			{
				m_slots = value;
			}
		}
	}
}
