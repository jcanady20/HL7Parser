using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace HL7Parser.Network.Decodes
{
	public class ICMP : IProtocol
	{
		private byte m_type;			//	Eight bits for Type
		private byte m_code;			//	Eight bits for Code
		private ushort m_checksum;		//	Sixteen bits for CheckSum
		private ushort m_identifier;	//	Sixteen bits for Identifier
		private ushort m_sequence;		//	Sixteen bits for Sequence Number

		public ICMP(byte[] data, int nRecieved)
		{
			Decode(data, nRecieved);
		}
		
		public Protocol ProtocolType
		{
			get
			{
				return Protocol.ICMP;
			}
		}

		public void Decode(byte[] data, int dataLength)
		{
			using (MemoryStream ms = new MemoryStream(data, 0, data.Length))
			{
				using(BinaryReader br = new BinaryReader(ms))
				{
					m_type = br.ReadByte();
					m_code = br.ReadByte();
					m_checksum = (ushort)IPAddress.NetworkToHostOrder(br.ReadInt16());
					m_identifier = (ushort)IPAddress.NetworkToHostOrder(br.ReadInt16());
					m_sequence = (ushort)IPAddress.NetworkToHostOrder(br.ReadInt16());
				}
			}
		}

		public char ICMPType
		{
			get
			{
				return Convert.ToChar(m_type);
			}
		}
		public char ICMPCode
		{
			get
			{
				return Convert.ToChar(m_code);
			}
		}
		public ushort CheckSum
		{
			get
			{
				return m_checksum;
			}
		}
		public ushort Identifier
		{
			get
			{
				return m_identifier;
			}
		}
		public ushort Sequence
		{
			get
			{
				return m_sequence;
			}
		}

		public byte[] DataGram { get; private set; }
			 
	}
}
