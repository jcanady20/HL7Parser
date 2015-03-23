using System.Net;
using System.Text;
using System;
using System.IO;

namespace HL7Parser.Network.Decodes
{
    public class UDPHeader : IProtocol
    {
        //	UDP header fields
        private ushort usSourcePort;            //	Sixteen bits for the source port number        
        private ushort usDestinationPort;       //	Sixteen bits for the destination port number
        private ushort usLength;                //	Length of the UDP header
        private short sChecksum;                //	Sixteen bits for the checksum
                                                //	(checksum can be negative so taken as short)              

		//End UDP header fields
        private byte[] byUDPData = new byte[4096];  //Data carried by the UDP packet

        public UDPHeader(byte [] byBuffer, int nReceived)
        {
			Decode(byBuffer, nReceived);
        }

        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString();
            }
        }

        public string Length
        {
            get
            {
                return usLength.ToString ();
            }
        }

        public string Checksum
        {
            get
            {
                //	Return the checksum in hexadecimal format
                return string.Format("0x{0:x2}", sChecksum);
            }
        }

		public byte[] DataGram
        {
            get
            {
                return byUDPData;
            }
        }

		public Protocol ProtocolType
		{
			get { return Protocol.UDP; }
		}

		public void Decode(byte[] data, int dataLength)
		{
			MemoryStream memoryStream = new MemoryStream(data, 0, dataLength);
			BinaryReader binaryReader = new BinaryReader(memoryStream);

			//	The first sixteen bits contain the source port
			usSourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

			//	The next sixteen bits contain the destination port
			usDestinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

			//The next sixteen bits contain the length of the UDP packet
			usLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

			//	The next sixteen bits contain the checksum
			sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

			//	Copy the data carried by the UDP packet into the data buffer
			Array.Copy(data,
					   8,               //	The UDP header is of 8 bytes so we start copying after it
					   byUDPData,
					   0,
					   dataLength - 8);
		}
	}
}