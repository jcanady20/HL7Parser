using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public class HL7Compent : HL7ContentBase
	{
		public HL7Compent(int id, string content, HL7Separators separators)
		{
			Id = id;
			m_separators = separators;
			Content = content;
		}
		
		
		public override void Parse()
		{
			if (Content.Contains(m_separators.ComponentSeparator))
			{
				string[] raw = Content.Split(new char[] { m_separators.ComponentSeparator });
				for (int i = 0; i < raw.Length; i++)
					m_children.Add(new HL7Compent(i, raw[i].Trim(), m_separators));
			}
		}
	}
}
