using System;

namespace HL7Parser.Data.Dictionary
{
	public class HL7Field
	{
		public HL7Field() { }
		public string Description { get; set; }
		public string Segment { get; set; }
		public int Sequence { get; set; }
		public int Length { get; set; }
		public bool Repeatable { get; set; }
	}
}
