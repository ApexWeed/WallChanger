using System;

namespace LanguageEditor
{
    public static class ComboBoxObjectCollectionExtensions
    {
        /// <summary>
        /// Searches a ComboBoxObjectCollection using the specified predicate.
        /// </summary>
        /// <param name="Collection">The collection to search.</param>
        /// <param name="Pred">The predicate to apply.</param>
        /// <returns>Either the found object or null</returns>
        public static object Find(this System.Windows.Forms.ComboBox.ObjectCollection Collection, Predicate<object> Pred)
        {
            foreach (var Item in Collection)
                if ((bool)Pred?.Invoke(Item))
                    return Item;

            return null;
        }
    }
}
