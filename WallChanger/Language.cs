using System.Collections.Generic;

namespace WallChanger
{
    public class Language
    {
        public string Code;
        public string Name;
        public string Description;
        public string Author;

        private Dictionary<string, string> Strings;

        /// <summary>
        /// Create a new instance of a language.
        /// </summary>
        /// <param name="Code">The short code for the language e.g en_AU.</param>
        /// <param name="Name">The long name of the language e.g Australian English</param>
        /// <param name="Description">The description of the language.</param>
        /// <param name="Author">The author of the language.</param>
        public Language(string Code, string Name, string Description, string Author)
        {
            this.Code = Code;
            this.Name = Name;
            this.Description = Description;
            this.Author = Author;

            Strings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Clears the dictionary of strings.
        /// </summary>
        public void Clear()
        {
            Strings.Clear();
        }

        /// <summary>
        /// Adds a new entry to the strings.
        /// </summary>
        /// <param name="Key">The key to add.</param>
        /// <param name="Value">The value to add.</param>
        public void AddString(string Key, string Value)
        {
            if (Strings.ContainsKey(Key))
                Strings[Key] = Value;
            else
                Strings.Add(Key, Value);
        }

        /// <summary>
        /// Gets a string from the dictionary.
        /// </summary>
        /// <param name="Key">The key to get.</param>
        /// <returns>The entry if it exists or the key.</returns>
        public string GetString(string Key)
        {
            if (Strings.ContainsKey(Key))
                return Strings[Key];
            else
                return Key;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Code);
        }
    }
}
