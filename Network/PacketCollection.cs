using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HL7Parser.Network
{
	public class PacketCollection : ObservableCollection<Packet>
	{
		public PacketCollection() { }
		public void Save(string filePath)
		{
		}
	}
}
