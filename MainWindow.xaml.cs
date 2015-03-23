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
using System.Security.Principal;
using HL7Parser.Controls;
using HL7Parser.Data.HL7;

namespace HL7Parser
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private HL7Parser.Data.Dictionary.HL7FieldCollection m_hl7fields = null;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnParseMessage_Click(object sender, RoutedEventArgs e)
		{
			HL7Parser.Data.HL7.HL7Message message = new HL7Parser.Data.HL7.HL7Message(txtbxMessage.Text);
			if (message == null || message.Children.Count == 0) { }
			else
			{
				trvOverView.ItemsSource = message.Children;
				ParseResults.IsSelected = true;
			}
		}

		private void btnFind_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.DefaultExt = ".hl7";
			Nullable<bool> result = dlg.ShowDialog();

			if (result.HasValue && result == true)
			{
				// Attempt to open the file
				SaveMessage(dlg.FileName);
			}
		}

		private void btnOpenFile_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.Multiselect = false;
			dlg.DefaultExt = ".hl7";
			Nullable<bool> result =	dlg.ShowDialog();

			if (result.HasValue && result == true)
			{
				// Attempt to open the file
				LoadMessage(dlg.FileName);
			}
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//	Only Add Content the first time the tab is selected
			if (SnoopTab != null && SnoopTab.IsSelected && SnoopContent.Children.Count == 0)
			{
				if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) == false)
				{
					TextBlock tb = new TextBlock();
					tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
					tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
					tb.FontWeight = (FontWeight)new FontWeightConverter().ConvertFromString("Bold");
					tb.FontSize = 24;
					tb.Foreground = Brushes.Black;
					tb.Text = "This Feature requires Administrator level privleges";
					tb.TextWrapping = TextWrapping.Wrap;
					SnoopContent.Children.Add(tb);
				}
				else
				{
					SnoopControl sc = new SnoopControl();
					sc.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
					sc.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
					SnoopContent.Children.Add(sc);
				}
			}
		}

		private void btnRefreshSDataSource_Click(object sender, RoutedEventArgs e)
		{
			string fileName = String.Empty;
			if (cmbxDataSources.SelectedIndex == 0)
				fileName = "DataSources\\hl7segments_23.xml";
			else
				fileName = "DataSources\\hl7segments_25.xml";

			m_hl7fields = HL7Parser.Data.Dictionary.HL7FieldCollection.Load(fileName);
			dgDataSourceView.ItemsSource = m_hl7fields;
		}

		private void txtbxDataSourceSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (m_hl7fields == null) { }
			else if (txtbxDataSourceSearch.Text.Length == 0)
			{
				dgDataSourceView.ItemsSource = m_hl7fields;
			}
			else
			{
				IEnumerable<HL7Parser.Data.Dictionary.HL7Field> result = m_hl7fields.Where(h => h.Description.ToLower().Contains(txtbxDataSourceSearch.Text.ToLower()) || h.Segment.ToLower().Contains(txtbxDataSourceSearch.Text.ToLower()));
				dgDataSourceView.ItemsSource = result;
			}
		}

		private void LoadMessage(string fileName)
		{
			using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
			{
				this.txtbxMessage.Text = sr.ReadToEnd();
			}
		}

		private void SaveMessage(string fileName)
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false))
			{
				sw.Write(txtbxMessage.Text);
				sw.Flush();
			}
		}

		private void btnSelectSearchColumns_Click(object sender, RoutedEventArgs e)
		{

		}

		private void trvOverView_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
