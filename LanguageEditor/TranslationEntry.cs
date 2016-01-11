using System.Collections.Generic;

namespace LanguageEditor
{
    public class TranslationEntry
    {
        public readonly string Name;
        public readonly string Translation;
        public readonly List<TranslationParameter> Parameters;

        public TranslationEntry(string Name)
        {
            this.Name = Name;
            this.Parameters = new List<TranslationParameter>();
        }

        public TranslationEntry(string Name, List<TranslationParameter> Parameters)
        {
            this.Name = Name;
            this.Parameters = Parameters;
        }

        public TranslationEntry(string Name, string Translation)
        {
            this.Name = Name;
            this.Translation = Translation;
            this.Parameters = new List<TranslationParameter>();
        }

        public TranslationEntry(string Name, string Translation, List<TranslationParameter> Parameters)
        {
            this.Name = Name;
            this.Translation = Translation;
            this.Parameters = Parameters;
        }

        public override string ToString()
        {
            return Parameters.Count > 0 ? $"{Name} ({Parameters.Count} Params)" : $"{Name}";
        }
    }
}
