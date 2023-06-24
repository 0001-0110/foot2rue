using static System.Windows.Forms.Control;

namespace foot2rue.WF.Extensions
{
	internal static class ControlCollectionExtensions
	{
		public static IEnumerable<TResult> Select<TResult>(this ControlCollection collection, Func<Control, TResult> selector)
		{
			foreach (TResult result in collection.Select((control, i) => selector(control)))
				yield return result;
		}

		public static IEnumerable<TResult> Select<TResult>(this ControlCollection collection, Func<Control, int, TResult> selector)
		{
			for (int i = 0; i < collection.Count; i++)
				yield return selector(collection[i], i);
		}
	}
}
