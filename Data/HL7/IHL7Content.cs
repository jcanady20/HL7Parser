using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public interface IHL7Content
	{
		int Id { get; set; }
		String Content { get; set; }
		String Name { get; set; }
		String Description { get; set; }
		void Parse();
		IList<IHL7Content> Children { get; }
	}
}