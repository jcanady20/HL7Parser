using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL7Parser.Data.Dictionary;

namespace HL7Parser.Data.HL7
{
	internal static class HL7Dictionary
	{
		private static HL7FieldCollection _HL7Fields = null;
		internal static HL7FieldCollection HL7Fields
		{
			get
			{
				if(_HL7Fields == null)
					_HL7Fields = HL7FieldCollection.Load("DataSources\\hl7segments_23.xml");
				return _HL7Fields;
			}
		}
	}
}
