using System.Reflection;

namespace foot2rue.WF.Extensions
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// This is SOOOOOOOOOOOOOOO overengineered for what I need
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        /// <remarks>This is funny though</remarks>
        public static TChild ExtendParentClass<TParent, TChild>(this TParent parent) where TChild : TParent, new()
        {
            if (parent == null) 
                throw new ArgumentNullException("What exactly were you hoping for ?");

            TChild child = new TChild();

            PropertyInfo[] parentProperties = parent.GetType().GetProperties();
            PropertyInfo[] childProperties = child.GetType().GetProperties();
            foreach (PropertyInfo parentProperty in parentProperties)
            {
                PropertyInfo? childProperty = Array.Find(childProperties, p => p.Name == parentProperty.Name);
                if (childProperty != null && childProperty.PropertyType == parentProperty.PropertyType && childProperty.CanWrite)
                    childProperty.SetValue(child, parentProperty.GetValue(parent));
            }

            return child;
        }
    }
}
