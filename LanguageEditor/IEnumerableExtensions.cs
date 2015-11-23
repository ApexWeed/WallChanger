using System.Collections.Generic;
using System.Text;

namespace LanguageEditor
{
    public static class IEnumerableExtensions
    {
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
