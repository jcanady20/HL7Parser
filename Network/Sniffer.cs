using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Threading;
using System.Windows.Threading;

namespace HL7Parser.Network
{
	public class Sniffer
	{
		private DispatcherSynchronizationContext requestingContext = null;
		private Socket m_socket;
		private byte[] buffer = new byte[4096];
		private bool m_cancelled;
		private IPAddress m_ipaddress;
		private PacketCollection m_packetbuffer;
		private object m_syncLock = new object();
		private Queue<Packet> m_packetQueue;

		public Sniffer()
		{
			m_packetbuffer = new PacketCollection();
		}
		
		public Sniffer(IPAddress ipAddress) : this()
		{
			m_ipaddress = ipAddress;
		}
		
		public Sniffer(string ipAddress) : this(IPAddress.Parse(ipAddress))
		{
		}

		public void Start()
		{
			if (m_ipaddress == null)
				throw new ArgumentNullException("IP Address");
			m_cancelled = false;
			DoWork();
		}
		
		public void Stop()
		{
			m_cancelled = true;
		}
		
		private void DoWork()
		{
			m_packetQueue = new Queue<Packet>();

			m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

			m_socket.Bind(new IPEndPoint(m_ipaddress, 0));

			m_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

			byte[] byTrue = new byte[4] { 1, 0, 0, 0};
			byte[] byOut = new byte[4] { 1, 0, 0, 0};

			m_socket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);
			
			//	Requesting Context is required to marshal the result across threads.
			requestingContext = (DispatcherSynchronizationContext)DispatcherSynchronizationContext.Current;

			m_socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnRecieve), null);
		}

		public PacketCollection PacketBuffer
		{
			get
			{
				return m_packetbuffer;
			}
		}

		public void SetIPAddress(string ipAddress)
		{
			m_ipaddress = IPAddress.Parse(ipAddress);
		}
		
		public void ClearBuffer()
		{
			lock (m_syncLock)
			{
				m_packetbuffer.Clear();
			}
		}

		private void OnRecieve(IAsyncResult ar)
		{
			int nRecieved = m_socket.EndReceive(ar);

			Packet p = new Packet(buffer, nRecieved);
			
			m_packetQueue.Enqueue(p);

			//	Perform a Call back to the main thread os that it can process the data
			SendOrPostCallback callback = new SendOrPostCallback(ParseData);
			requestingContext.Post(callback, null);

			if (m_cancelled == false && m_socket != null)
			{
				buffer = new byte[4096];
				m_socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnRecieve), null);
			}
		}

		private void ParseData(object obj)
		{
			lock (m_syncLock)
			{
				for(int i = 0; i < m_packetQueue.Count; i++)
				{
					Packet p = m_packetQueue.Dequeue();
					if (p.IPHeader.ProtocolType == Decodes.Protocol.UDP || p.IPHeader.ProtocolType == Decodes.Protocol.TCP)
						this.m_packetbuffer.Add(p);
				}
			}
		}

		public static List<string> GetNetworkAddresses()
		{
			List<string> _addresses = new List<string>();

			IPHostEntry HostEntry = Dns.GetHostEntry((Dns.GetHostName()));
			if (HostEntry.AddressList.Length > 0)
			{
				foreach (IPAddress ip in HostEntry.AddressList)
				{
					if (ip.AddressFamily == AddressFamily.InterNetwork)
					{
						_addresses.Add(ip.ToString());
					}
				}
			}

			return _addresses;
		}
	}
}
