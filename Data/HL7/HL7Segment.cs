using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL7Parser.Extensions;

namespace HL7Parser.Data.HL7
{
	public class HL7Segment : HL7ContentBase
	{
		public HL7Segment(string content, HL7Separators separators)
		{
			m_separators = separators;
			Content = content;
		}
		public  override void Parse()
		{
			var raw = Content.Split(m_separators.FieldSeparator).ToList();
			Name = raw[0];
			if (String.Compare(Name, "MSH", true) == 0)
			{
				raw.Insert(1, m_separators.FieldSeparator.ToString());
			}
			if(raw.Count() == 0)
			{
				return;
			}
			var x = 1;
			raw
				.Skip(1)
				.ForEach(r => {
					var _field = new HL7Field(r, m_separators);
					_field.Id = x;
					var result = HL7Dictionary.HL7Fields.FieldLookUp(this.Name, x);
					if(result != null)
					{
						_field.Name = result.Description;
					}
					base.Children.Add(_field);
					x += 1;
			});
		}
	}
}
