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

        public Language(string Code, string Name, string Description, string Author)
        {
            this.Code = Code;
            this.Name = Name;
            this.Description = Description;
            this.Author = Author;

            Strings = new Dictionary<string, string>();
        }

        public void Clear()
        {
            Strings.Clear();
        }

        public void AddString(string Key, string Value)
        {
            if (Strings.ContainsKey(Key))
                Strings[Key] = Value;
            else
                Strings.Add(Key, Value);
        }

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
