﻿using System;
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
using System.Data;
using System.Xml;

namespace HL7Parser.Controls
{
	/// <summary>
	/// Interaction logic for XmlViewer.xaml
	/// </summary>
	public partial class XmlViewer : UserControl
	{
		private XmlDocument _xmldocument;
		public XmlViewer()
		{
			InitializeComponent();
		}

		public XmlDocument xmlDocument
		{
			get { return _xmldocument; }
			set
			{
				_xmldocument = value;
				BindXMLDocument();
			}
		}

		private void BindXMLDocument()
		{
			if (_xmldocument == null)
			{
				xmlTree.ItemsSource = null;
				return;
			}

			var provider = new XmlDataProvider();
			provider.Document = _xmldocument;
			Binding binding = new Binding();
			binding.Source = provider;
			binding.XPath = "child::node()";
			xmlTree.SetBinding(TreeView.ItemsSourceProperty, binding);
		}
	}
}
