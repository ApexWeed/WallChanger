using System.Collections.Generic;
using System.IO;

namespace LanguageEditor
{
    class LanguageManager
    {
        public readonly Dictionary<string, Language> Languages;

        /// <summary>
        /// Initialises the language manager and loads languages.
        /// </summary>
        public LanguageManager(bool IgnoreFileNotFound = false)
        {
            Languages = new Dictionary<string, Language>();

            if (!Directory.Exists("lang"))
            {
                if (IgnoreFileNotFound)
                    return;
                else
                    throw new FileNotFoundException("Language folder not found, the program will still work but the interface will identifier names instead.");
            }

            foreach (var File in Directory.GetFiles("lang", "*.lang"))
            {
                AddLanguage(File);
            }
        }

        /// <summary>
        /// Gets all the language without the translation strings.
        /// </summary>
        /// <param name="IncludeStrings">Whether to include the strings.</param>
        /// <returns>List of languages.</returns>
        public List<Language> GetLanguages(bool IncludeStrings = false)
        {
            var languages = new List<Language>();

            foreach (var Pair in Languages)
            {
                if (IncludeStrings)
                {
                    languages.Add(Pair.Value);
                }
                else
                {
                    languages.Add(new Language(Pair.Value.Code, Pair.Value.Name, Pair.Value.Description, Pair.Value.Author));
                }
            }

            return languages;
        }

        /// <summary>
        /// Gets the requested string in the specified language or the key if it doesn't exist.
        /// </summary>
        /// <param name="Key">String to retrieve.</param>
        /// <param name="Language">The language code to use.</param>
        /// <returns>The language specific string.</returns>
        public string GetString(string Key, string Language)
        {
            if (Languages.ContainsKey(Language))
                return Languages[Language].GetString(Key);

            return Key;
        }

        /// <summary>
        /// Adds a language from a file.
        /// </summary>
        /// <param name="Filename">The path to the file to load.</param>
        private void AddLanguage(string Filename)
        {
            using (FileStream fs = File.Open(Filename, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    var Name = r.ReadLine();
                    var Description = r.ReadLine();
                    var Author = r.ReadLine();
                    var language = new Language(Path.GetFileNameWithoutExtension(Filename), Name, Description, Author);
                    while (!r.EndOfStream)
                    {
                        var Line = r.ReadLine();
                        // Ignore blank lines and comments.
                        if (string.IsNullOrWhiteSpace(Line) || Line.Trim().StartsWith("#"))
                            continue;

                        // STRING_NAME=Output string
                        // STRING_NAME = Output string
                        var Parts = Line.Split('=');
                        if (Parts.Length != 2)
                            continue;

                        language.AddString(Parts[0].Trim(), Parts[1].Trim());
                    }
                    Languages.Add(Path.GetFileNameWithoutExtension(Filename), language);
                }
            }
        }
    }
}
