using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public class HL7Field : HL7ContentBase
	{
		public HL7Field(string content, HL7Separators separators)
		{
			m_separators = separators;
			Content = content;
		}
		
		public override void Parse()
		{
			string[] raw;
			if (Content.Contains(m_separators.RepetionSeparator))
			{
				raw = Content.Split(new char[] { m_separators.RepetionSeparator });
			}
			else
			{
				raw = Content.Split(new char[] { m_separators.ComponentSeparator });
			}
			for (int i = 0; i < raw.Length; i++)
			{
				m_children.Add(new HL7Compent(i, raw[i].Trim(), m_separators));
			}
		}
	}
}
