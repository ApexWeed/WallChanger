using System.Collections.Generic;
using System.IO;

namespace LanguageEditor
{
    class Language
    {
        public readonly string Author;
        public readonly string Code;
        public readonly string Description;
        public readonly string Name;

        private readonly Dictionary<string, string> Strings;

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
        /// Clears the dictionary of strings.
        /// </summary>
        public void Clear()
        {
            Strings.Clear();
        }

        /// <summary>
        /// Gets a string from the dictionary.
        /// </summary>
        /// <param name="Key">The key to get.</param>
        /// <returns>The entry if it exists or the key.</returns>
        public string GetString(string Key)
        {
            return Strings.ContainsKey(Key) ? Strings[Key] : Key;
        }

        public void Save(string Folder)
        {
            using (StreamWriter write = new StreamWriter(Path.Combine(Folder, $"{Code}.lang")))
            {
                write.WriteLine(Name);
                write.WriteLine(Description);
                write.WriteLine(Author);
                foreach (var line in Strings)
                {
                    write.WriteLine($"{line.Key} = {line.Value}");
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}
