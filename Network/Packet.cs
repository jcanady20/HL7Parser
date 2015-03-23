using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HL7Parser.Network.Decodes;
using System.Threading;

namespace HL7Parser.Network
{
	public class Packet
	{
		private byte[] m_packet;
		private int m_dataLength;

		public Packet(byte[] rawbytes, int dataLength)
		{
			TimeStamp = DateTime.Now;
			m_packet = rawbytes;
			m_dataLength = dataLength;
			
			DecodePacket();
		}
		
		private void DecodePacket()
		{
			//	Since all protocol packets are encapsulated in the IP datagram
			//	so we start by parsing the IP header and see what protocol data
			//	is being carried by it
			IPHeader = new IPHeader(m_packet, m_dataLength);

			ProtocolHeader = ProtocolFactory.Factory(IPHeader.ProtocolType, IPHeader.DataGram, IPHeader.MessageLength);
		}

		public DateTime TimeStamp { get; private set; }

		public IPHeader IPHeader { get; set; }

		public int PacketLength
		{
			get
			{
				return m_dataLength;
			}
		}
		
		public IProtocol ProtocolHeader { get; set; }

		public string ProtocolName
		{
			get
			{
				return IPHeader.ProtocolType.ToString();
			}
		} 
		
		public byte[] DataGram { get { return ProtocolHeader.DataGram; } }

		public string HexView
		{
			get
			{
				return HexDump(m_packet).ToString();
			}
		}

		private StringBuilder HexDump(byte[] bytes)
		{
			StringBuilder hex = new StringBuilder();
			StringBuilder sb = new StringBuilder();

			for (int line = 0; line < m_dataLength; line += 16)
			{
				byte[] lineBytes = bytes.Skip(line).Take(16).ToArray();
				
				sb.AppendFormat("{0:x8} ", line);
				sb.Append(string.Join(" ", lineBytes.Select(b => b.ToString("x2")).ToArray()).PadRight(16 * 3));
				sb.Append(" ");
				sb.Append(new string(lineBytes.Select(b => b < 32 ? '.' : (char)b).ToArray()));
				
				hex.AppendLine(sb.ToString());
				sb.Clear();
			}
			return hex;
		}
	}
}
