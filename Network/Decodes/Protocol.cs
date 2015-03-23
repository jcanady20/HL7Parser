using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Network.Decodes
{
	public enum Protocol
	{
		HOPOPT = 0,
		ICMP = 1,
		IGMP = 2,
		GGP = 3,
		IP = 4,
		ST = 5,
		TCP = 6,
		CBT = 7,
		EGP = 8,
		IGP = 9,
		BBNRCCMON = 10,
		NPVII = 11,
		PUP = 12,
		ARGUS = 13,
		EMCON = 14,
		XNET = 15,
		CHAOS = 16,
		UDP = 17,
		MUX  = 18,
		DNCMEAS = 19,
		HMP = 20,
		PRM = 21,
		XNSIDP = 22,
		TRUNK1 = 23,
		TRUNK2 = 24,
		LEAF1 = 25,
		LEAF2 = 26,
		RDP = 27,
		IRTP = 28,
		ISOTP4 = 29,
		NETBLT = 30,
		MFENSP = 31,
		DCCP = 32,
		SMP = 121,
		Unknown = -1
	}
}
