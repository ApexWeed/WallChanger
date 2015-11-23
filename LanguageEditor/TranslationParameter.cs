namespace LanguageEditor
{
    class TranslationParameter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0052:Make field readonly", Justification = "It's pretty much a struct.")]
        public string Original;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0052:Make field readonly", Justification = "It's pretty much a struct.")]
        public string Substitution;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0052:Make field readonly", Justification = "It's pretty much a struct.")]
        public string Description;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0052:Make field readonly", Justification = "It's pretty much a struct.")]
        public string Sample;

        public TranslationParameter(string Original)
        {
            this.Original = Original;
        }

        public TranslationParameter(string Original, string Substitution, string Description, string Sample)
        {
            this.Original = Original;
            this.Substitution = Substitution;
            this.Description = Description;
            this.Sample = Sample;
        }
    }
}
