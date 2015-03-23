using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7Parser.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> action)
		{
			foreach (var i in array)
				action(i);
			return array;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable array, Action<T> action)
		{
			return array.Cast<T>().ForEach<T>(action);
		}

		public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
		{
			var list = new List<RT>();
			foreach (var i in array)
			{
				var obj = func(i);
				if (obj != null)
					list.Add(obj);
			}
			return list;
		}
	}
}
