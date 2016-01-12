using System.Collections.Generic;
using System.Text;

namespace LanguageEditor
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Joins together the elements of an enumeration using the specified joiner.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="Enumerable"></param>
        /// <param name="Joiner">The string to put between elements, defaults to '.'.</param>
        /// <returns>A string containing the elements in Enumerable joined by Joiner.</returns>
        public static string JoinString<T>(this IEnumerable<T> Enumerable, string Joiner = ".")
        {
            var builder = new StringBuilder();
            var first = true;
            foreach (T val in Enumerable)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(Joiner);
                }
                builder.Append(val);
            }

            return builder.ToString();
        }
    }
}
