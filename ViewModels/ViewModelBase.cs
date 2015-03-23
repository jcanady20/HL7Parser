using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;


namespace HL7Parser.ViewModels
{
	public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging, IDisposable
	{
		protected bool m_isChanged = false;
		protected ViewModelBase() { }

		public Window Window { get; set; }

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// Verify that the property name matches a real,  
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;

				if (this.ThrowOnInvalidPropertyName)
					throw new Exception(msg);
				else
					Debug.Fail(msg);
			}
		}

		protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

		public event PropertyChangingEventHandler PropertyChanging;

		protected virtual void ReportPropertyChanging(string property)
		{
			this.VerifyPropertyName(property);
			if (PropertyChanging != null)
				PropertyChanging(this, new PropertyChangingEventArgs(property));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void ReportPropertyChanged(string property)
		{
			this.VerifyPropertyName(property);
			if (PropertyChanged != null)
			{
				if (!m_isChanged)
				{
					m_isChanged = true;
					PropertyChanged(this, new PropertyChangedEventArgs("IsChanged"));
				}
				PropertyChanged(this, new PropertyChangedEventArgs(property));
				CommandManager.InvalidateRequerySuggested();
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool dispose)
		{
		}
	}
}
