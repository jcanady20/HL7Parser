using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HL7Parser.Network;

namespace HL7Parser.Controls
{
	public partial class SnoopControl : UserControl
	{
		private Sniffer m_sniffer;
		private List<string> m_ipenterfaces;

		public SnoopControl()
		{
			m_sniffer = new Network.Sniffer();
			m_ipenterfaces = Network.Sniffer.GetNetworkAddresses();
			InitializeComponent();

			cmbxIpAddress.ItemsSource = m_ipenterfaces;
		}

		public Sniffer Sniffer
		{
			get
			{
				return m_sniffer;
			}
		}

		private void btnStopCapture_Click(object sender, RoutedEventArgs e)
		{
			m_sniffer.Stop();
		}

		private void btnStartCapture_Click(object sender, RoutedEventArgs e)
		{
			m_sniffer.Start();
			dgPacketBuffer.ItemsSource = null;
			this.m_sniffer.ClearBuffer();
			dgPacketBuffer.ItemsSource = this.m_sniffer.PacketBuffer;
		}

		private void btnNewCapture_Click(object sender, RoutedEventArgs e)
		{
			m_sniffer.PacketBuffer.Clear();
		}

		private void btnSaveCapture_Click(object sender, RoutedEventArgs e)
		{
			this.m_sniffer.PacketBuffer.Save(String.Empty);
		}

		private void cmbxIpAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string o = cmbxIpAddress.SelectedItem.ToString();
			cmbxIpAddress.Text = o;
			m_sniffer.SetIPAddress(o);
		}
	}
}
