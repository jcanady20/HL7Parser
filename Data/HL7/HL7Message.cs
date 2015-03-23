using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public class HL7Message : HL7ContentBase
	{
		public HL7Message(String content)
		{
			Content = content;
		}
		
		public override void Parse()
		{
			if (Content.StartsWith("MSH") == false)
				throw new ArgumentException("Invalid Message, Message does not start with MSH");

			GetSeparators();
			Content.Split(new char[] { (char)0x0D })
				.ToList()
				.ForEach(r => {
					m_children.Add(new HL7Segment(r, m_separators));
				});
		}
		
		private void GetSeparators()
		{
			if (Content == null)
				return;
			m_separators = new HL7Separators(Content.Substring(3, 5));
		}
	}
}
