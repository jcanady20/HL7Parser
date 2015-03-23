using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HL7Parser.Data.Dictionary
{
	public class HL7FieldCollection : List<HL7Field>
	{

		public HL7Field FieldLookUp(string name, int sequence)
		{
			return this.FirstOrDefault(x => String.Compare(x.Segment, name, true) == 0 && x.Sequence == sequence);
		}
		public static HL7FieldCollection Load(string filePath)
		{
			var xdoc = XDocument.Load(filePath);
			var hfs = new HL7FieldCollection();

			var results = xdoc.Descendants("segment").Select(r => r.ToHL7Field()).ToList();

			hfs.AddRange(results);

			return hfs;
		}
	}
}
