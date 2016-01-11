namespace LanguageEditor
{
    public class ColourableTranslationEntry
    {
        public ColourableTreeView.ColourMode ColourMode;
        public TranslationEntry TranslationEntry;
        public bool Emphasise;

        public ColourableTranslationEntry(ColourableTreeView.ColourMode ColourMode, TranslationEntry TranslationEntry)
        {
            this.ColourMode = ColourMode;
            this.TranslationEntry = TranslationEntry;
        }

        public ColourableTranslationEntry(ColourableTreeView.ColourMode ColourMode, TranslationEntry TranslationEntry, bool Emphasise)
        {
            this.ColourMode = ColourMode;
            this.TranslationEntry = TranslationEntry;
            this.Emphasise = Emphasise;
        }
    }
}
