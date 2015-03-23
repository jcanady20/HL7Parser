using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace HL7Parser.Helpers
{
	public class EnumHelper<T> where T : struct, IConvertible
	{
		public string Name { get; private set; }
		public int Id { get; private set; }

		private T m_item;
		public T Item
		{
			get
			{
				return m_item;
			}
			set
			{
				m_item = value;
				Id = Convert.ToInt32(m_item);
				Name = EnumHelper.GetEnumDescription(m_item);
			}
		}

		public override string ToString()
		{
			return m_item.ToString();
		}
	}

	public class EnumCollection<T> : ObservableCollection<EnumHelper<T>> where T : struct, IConvertible
	{
		public EnumCollection()
		{
			foreach (T srs in EnumHelper.GetValues<T>())
			{
				this.Add(new EnumHelper<T>() { Item = srs });
			}
		}
	}

	public static class EnumHelper
	{
		public static T[] GetValues<T>()
		{
			Type enumType = typeof(T);
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(String.Format("Type '{0}' is not an enum", enumType.Name));
			}
			List<T> values = new List<T>();
			var fields = from field in enumType.GetFields()
						 where field.IsLiteral
						 select field;
			foreach (FieldInfo field in fields)
			{
				object value = field.GetValue(enumType);
				values.Add((T)value);
			}
			return values.ToArray();
		}

		public static object[] GetValues(Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(String.Format("Type '{0}' is not an enum", enumType.Name));
			}
			List<object> values = new List<object>();
			var fields = from field in enumType.GetFields()
						 where field.IsLiteral
						 select field;
			foreach (FieldInfo field in fields)
			{
				object value = field.GetValue(enumType);
				values.Add(value);
			}
			return values.ToArray();
		}

		public static string GetEnumDescription(object value)
		{
			string _result = string.Empty;
			Type enumType = value.GetType();
			if (!enumType.IsEnum)
				throw new ArgumentException(String.Format("Type '{0}' is not an enum", enumType.Name));

			try
			{
				_result = Enum.GetName(enumType, value);
				FieldInfo fieldinfo = enumType.GetField(_result);
				object[] attribs = fieldinfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
				System.ComponentModel.DescriptionAttribute desc = null;
				if (attribs != null && attribs.Length > 0)
				{
					desc = (System.ComponentModel.DescriptionAttribute)attribs[0];
					if (desc != null)
					{
						_result = desc.Description;
					}
				}
			}
			catch (ArgumentException)
			{
				_result = value.ToString();
			}
			return _result;
		}
	}
}
