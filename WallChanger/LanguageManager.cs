using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    public class LanguageManager
    {
        Dictionary<string, Language> Languages;

        /// <summary>
        /// Initialses the language manager and loads languages.
        /// </summary>
        public LanguageManager()
        {
            Languages = new Dictionary<string, Language>();

            foreach (var File in Directory.GetFiles(Path.Combine(GlobalVars.ApplicationPath, "lang"), "*.lang"))
            {
                AddLanguage(File);
            }
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
                    string Name = r.ReadLine();
                    string Description = r.ReadLine();
                    string Author = r.ReadLine();
                    Language language = new Language(Path.GetFileNameWithoutExtension(Filename), Name, Description, Author);
                    while (!r.EndOfStream)
                    {
                        string Line = r.ReadLine();
                        // Ignore blank lines and comments.
                        if (string.IsNullOrWhiteSpace(Line) || Line.Trim().StartsWith("#"))
                            continue;

                        // STRING_NAME=Output string
                        // STRING_NAME = Output string
                        string[] Parts = Line.Split('=');
                        if (Parts.Length != 2)
                            continue;

                        language.AddString(Parts[0].Trim(), Parts[1].Trim());
                    }
                    Languages.Add(Path.GetFileNameWithoutExtension(Filename), language);
                }
            }
        }

        /// <summary>
        /// Gets all the language without the translation strings.
        /// </summary>
        /// <returns>List of languages.</returns>
        public List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();

            foreach (var Pair in Languages)
            {
                languages.Add(new Language(Pair.Value.Code, Pair.Value.Name, Pair.Value.Description, Pair.Value.Author));
            }

            return languages;
        }

        /// <summary>
        /// Gets the requested string in the current language or the key if it doesn't exist.
        /// </summary>
        /// <param name="Key">String to retrieve.</param>
        /// <returns>The language specific string.</returns>
        public string GetString(string Key)
        {
            string Value = GetString(Key, Properties.Settings.Default.Language);
            if (Value != Key)
                return Value;

            Value = GetString(Key, Properties.Settings.Default.FallbackLanguage);
            return Value;
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
        /// Gets the requested string in the current language or returns the default if it doesn't exist.
        /// </summary>
        /// <param name="Key">The string to retrieve.</param>
        /// <param name="Default">What to return if the string does not exist.</param>
        /// <returns>The language specific string.</returns>
        public string GetStringDefault(string Key, string Default)
        {
            string Value = GetString(Key);
            if (Value == Key)
                return Default;

            return Value;
        }
    }
}