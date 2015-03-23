using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Network.Decodes
{
	public class ProtocolFactory
	{
		public static IProtocol Factory(Protocol ptype, byte[] data, int dataLength)
		{
			IProtocol p = null;
			switch (ptype)
			{
				case Protocol.TCP:
					p = new TCPHeader(data, dataLength);
					break;
				case Protocol.UDP:
					p = new UDPHeader(data, dataLength);
					break;
				case Protocol.ICMP:
					p = new ICMP(data, dataLength);
					break;
				default:
					break;
			}
			return p;
		}
	}
}
