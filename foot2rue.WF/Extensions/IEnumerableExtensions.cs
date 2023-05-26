using System.Data;
using System.Reflection;

namespace foot2rue.WF.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> IfNotNull<T>(this IEnumerable<T>? enumerable)
        {
            if (enumerable == null)
                return Enumerable.Empty<T>();
            return enumerable;
        }

        public static DataTable? ToDataTable<T>(this IEnumerable<T>? items)
        {
            if (items == null)
                return null;

            // Get the properties
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            DataTable dataTable = new DataTable(typeof(T).Name);

            // Create a new column for each property
            foreach (PropertyInfo property in properties)
                dataTable.Columns.Add(property.Name, property.PropertyType);

            // Create a new row for each item
            foreach (T? item in items)
            {
                // Create a list of object, that where each value contains a property of this item
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                    // Almost positive that this cannot be null
                    values[i] = properties[i].GetValue(item, null)!;

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
