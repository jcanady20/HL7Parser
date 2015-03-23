using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace HL7Parser.Helpers
{
	public class RelayCommand : ICommand
	{
		#region Fields

		readonly Action<object> m_execute;
		readonly Predicate<object> m_canExecute;

		#endregion // Fields

		#region Constructors

		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			m_execute = execute;
			m_canExecute = canExecute;
		}
		#endregion // Constructors

		#region ICommand Members

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return m_canExecute == null ? true : m_canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			m_execute(parameter);
		}

		#endregion // ICommand Members
	}

	public class RelayCommand<T> : ICommand
	{
		#region Fields

		readonly Action<T> m_execute;
		readonly Predicate<T> m_canExecute;

		#endregion // Fields

		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{ }

		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			m_execute = execute;
			m_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return m_canExecute == null ? true : m_canExecute((T)parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (m_canExecute != null)
				{
					CommandManager.RequerySuggested += value;
				}
			}
			remove
			{
				if (m_canExecute != null)
				{
					CommandManager.RequerySuggested -= value;
				}
			}
		}

		public void Execute(object parameter)
		{
			m_execute((T)parameter);
		}
	}
}
