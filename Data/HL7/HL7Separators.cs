using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Data.HL7
{
	public class HL7Separators
	{
		private char[] _hl7chars;
		private HL7Separators()
		{
			_hl7chars = new char[5];
		}
		public HL7Separators(string hl7chars) : this()
		{
			if (hl7chars.Length != 5)
				throw new ArgumentOutOfRangeException("HL7 Specifies 5 field separators.");
			
			_hl7chars = hl7chars.ToArray();
			for (int i = 0; i < hl7chars.Length; i++)
			{
				_hl7chars[i] = hl7chars[i];
			}
		}

		public char FieldSeparator
		{
			get { return _hl7chars[0]; }
		}
		public char ComponentSeparator
		{
			get { return _hl7chars[1]; }
		}
		public char SubcomponentSeparator
		{
			get { return _hl7chars[4]; }
		}
		public char RepetionSeparator
		{
			get { return _hl7chars[2]; }
		}
		public char EscapeCharacter
		{
			get { return _hl7chars[3]; }
		}
	}
}
