using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public abstract class HL7ContentBase : IHL7Content
	{
		internal IList<IHL7Content> m_children;
		internal HL7Separators m_separators;
		internal string m_content;
		internal HL7ContentBase()
		{
			m_children = new List<IHL7Content>();
		}

		public int Id { get; set; }

		public string Content
		{
			get { return m_content; }
			set
			{
				if(String.IsNullOrEmpty(value) == false)
				{
					m_content = value.Trim();
				}
				else
				{
					m_content = value;
				}
				
				Parse();
			}
		}

		public string Name { get; set; }

		public string Description { get; set; }

		public abstract void Parse();

		public IList<IHL7Content> Children
		{
			get { return m_children; }
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(Content))
				return base.ToString();
			else
				return Content;
		}
	}
}
