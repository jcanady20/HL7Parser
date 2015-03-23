using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Network.Decodes
{
	public interface IProtocol
	{
		Protocol ProtocolType { get; }
		void Decode(byte[] data, int dataLength);
		byte[] DataGram { get; }
	}
}
