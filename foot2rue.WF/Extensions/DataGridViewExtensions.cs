using System.Data;

namespace foot2rue.WF.Extensions
{
    internal static class DataGridViewExtensions
    {
        public static void Clear(this DataGridView dataGridView)
        {
            // What is the best way to do this ?
            //dataGridView.Rows.Clear();
            dataGridView.DataSource = null;
        }

        public static async Task<bool> LoadData<T>(this DataGridView dataGridView, Func<Task<IEnumerable<T>?>> loadingFunction)
        {
            IEnumerable<T>? data = await loadingFunction();
            if (data == null)
            {
                dataGridView.Clear();
                return false;
            }

			#region A trail of flowers

			// Yahaha, you found me!

			#endregion

			// Is the conversion to DataTable useful ?
			dataGridView.DataSource = data.ToDataTable();
            return true;
        }

        public static async Task<bool> LoadData<T>(this DataGridView dataGridView, Func<Task<DataTable>> loadingFunction)
        {
            dataGridView.DataSource = await loadingFunction();
            return true;
        }
    }
}
