using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableCheckBox : CheckBox
    {
        [Category(nameof(Appearance))]
        [Description("The string to retrieve from the language manager.")]
        public string TranslationString
        {
            get { return translationString; }
            set
            {
                translationString = value;
                UpdateString(null, null);
            }
        }
        private string translationString;

        [Category(nameof(Appearance))]
        [Description("The string to use when the language manager doesn't have a suitable string.")]
        [DefaultValue("")]
        public string DefaultString
        {
            get { return defaultString; }
            set { defaultString = value; }
        }
        private string defaultString;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LanguageManager LanguageManager
        {
            set
            {
                LM = value;
                if (LM != null)
                {
                    UpdateString(LM, null);
                    LM.LanguageChanged += UpdateString;
                }
            }
        }
        private LanguageManager LM;

        public void UpdateString(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                Text = translationString;
            }
            else
            {
                if (LM == null)
                    return;
                if (string.IsNullOrWhiteSpace(defaultString))
                {
                    Text = LM.GetString(translationString);
                }
                else
                {
                    Text = LM.GetStringDefault(translationString, defaultString);
                }
            }
        }
    }
}
