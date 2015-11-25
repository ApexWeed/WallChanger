using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableColumnHeaders : Component
    {
        [Category("Appearance")]
        [Description("The collection of strings to use to retrieve values from the language manager.")]
        public Dictionary<ColumnHeader, string> TranslationStrings
        {
            get { return translationStrings; }
            set { translationStrings = value; }
        }
        private Dictionary<ColumnHeader, string> translationStrings = new Dictionary<ColumnHeader, string>();

        [Category("Appearance")]
        [Description("The collection of strings to use when the language manager doesn't have the string.")]
        public Dictionary<ColumnHeader, string> DefaultStrings
        {
            get { return defaultStrings; }
            set { defaultStrings = value; }
        }
        private Dictionary<ColumnHeader, string> defaultStrings = new Dictionary<ColumnHeader, string>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LanguageManager LanguageManager
        {
            set
            {
                LM = value;
                if (LM != null)
                {
                    UpdateString(null);
                    LM.LanguageChanged += LanguageChanged;
                }
            }
        }
        protected LanguageManager LM;

        public event EventHandler<EventArgs> StringChanged;
        protected void FireStringChanged(object sender, EventArgs e)
        {
            StringChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Adds or updates an existing control's tooltips.
        /// </summary>
        /// <param name="ColumnHeader">The column header to add / update.</param>
        /// <param name="TranslationString">The string to retrieve from the language manager.</param>
        /// <param name="DefaultString">The string to use if the language manager doesn't have a suitable string.</param>
        public void UpdateColumnHeader(ColumnHeader ColumnHeader, string TranslationString, string DefaultString = "")
        {
            if (translationStrings.ContainsKey(ColumnHeader))
            {
                translationStrings[ColumnHeader] = TranslationString;
                if (DefaultString != "")
                {
                    if (defaultStrings.ContainsKey(ColumnHeader))
                    {
                        defaultStrings[ColumnHeader] = DefaultString;
                    }
                    else
                    {
                        defaultStrings.Add(ColumnHeader, DefaultString);
                    }
                }
            }
            else
            {
                translationStrings.Add(ColumnHeader, TranslationString);
                if (DefaultString != "")
                {
                    defaultStrings.Add(ColumnHeader, DefaultString);
                }
            }
            UpdateString(ColumnHeader);
        }

        public virtual void LanguageChanged(object sender, EventArgs e)
        {
            UpdateString(null);
        }

        public virtual void UpdateString(ColumnHeader ColumnHeader)
        {
            if (!DesignMode)
            {
                if (LM == null)
                    return;
                if (ColumnHeader == null)
                {
                    foreach (var pair in translationStrings)
                    {
                        if (defaultStrings.ContainsKey(pair.Key))
                        {
                            pair.Key.Text = LM.GetStringDefault(pair.Value, defaultStrings[pair.Key]);
                        }
                        else
                        {
                            pair.Key.Text = LM.GetString(pair.Value);
                        }
                    }
                }
                else
                {
                    if (translationStrings.ContainsKey(ColumnHeader))
                    {
                        if (!translationStrings.ContainsKey(ColumnHeader))
                        {
                            if (!defaultStrings.ContainsKey(ColumnHeader))
                            {
                                return;
                            }
                            ColumnHeader.Text = defaultStrings[ColumnHeader];
                        }
                        if (defaultStrings.ContainsKey(ColumnHeader))
                        {
                            ColumnHeader.Text = LM.GetStringDefault(translationStrings[ColumnHeader], defaultStrings[ColumnHeader]);
                        }
                        else
                        {
                            ColumnHeader.Text = LM.GetString(translationStrings[ColumnHeader]);
                        }
                    }
                }

                FireStringChanged(this, null);
            }
        }
    }
}
