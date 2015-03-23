using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HL7Parser.Data.Dictionary
{
	public static class HL7FieldExtensions
	{
		public static HL7Field ToHL7Field(this XElement xelement)
		{
			var hl7field = new HL7Field();

			hl7field.Description = xelement.Element("description").Value;
			hl7field.Segment = xelement.Element("seg").Value;
			hl7field.Sequence = Int32.Parse(xelement.Element("seq").Value);
			hl7field.Length = Int32.Parse(xelement.Element("len").Value);
			hl7field.Repeatable = (xelement.Element("rep").Value != "Y" ? false : true);

			return hl7field;
		}
	}
}
