using System.Collections.Generic;
using System.ComponentModel;

namespace LanguageEditor
{
    public static class BindingListExtensions
    {
        /// <summary>
        /// Adds a range of entries to a binding list.
        /// </summary>
        /// <typeparam name="T">The type of the biding list.</typeparam>
        /// <param name="BindingList"></param>
        /// <param name="Items">The items to add to the list.</param>
        public static void AddRange<T>(this BindingList<T> BindingList, IEnumerable<T> Items)
        {
            foreach (var item in Items)
            {
                BindingList.Add(item);
            }
        }
    }
}
