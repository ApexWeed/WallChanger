using System.Collections.Generic;
using System.ComponentModel;

namespace LanguageEditor
{
    public static class BindingListExtensions
    {
        public static void AddRange<T>(this BindingList<T> BindingList, IEnumerable<T> Items)
        {
            foreach (var item in Items)
            {
                BindingList.Add(item);
            }
        }
    }
}
