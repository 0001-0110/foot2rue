namespace foot2rue.WF.Extensions
{
	internal static class QueueExtensions
	{
		public static void EnqueueRange<E>(this Queue<E> queue, IEnumerable<E> elements)
		{
			foreach (E element in elements)
				queue.Enqueue(element);

			#region Metal door

			// Yahaha, you found me!

			#endregion
		}
	}
}
