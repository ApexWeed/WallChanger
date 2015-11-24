using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableTooltips : Component
    {
        [Category("Data")]
        [Description("Sets the ToolTip object to control tooltips for.")]
        public ToolTip ToolTips
        {
            get { return toolTips; }
            set { toolTips = value; }
        }
        protected ToolTip toolTips;

        [Category("Appearance")]
        [Description("The collection of strings to use to retrieve values from the language manager.")]
        public Dictionary<Control, string> TranslationStrings
        {
            get { return translationStrings; }
            set { translationStrings = value; }
        }
        private Dictionary<Control, string> translationStrings = new Dictionary<Control, string>();

        [Category("Appearance")]
        [Description("The collection of strings to use when the language manager doesn't have the string.")]
        public Dictionary<Control, string> DefaultStrings
        {
            get { return defaultStrings; }
            set { defaultStrings = value; }
        }
        private Dictionary<Control, string> defaultStrings = new Dictionary<Control, string>();

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

        public virtual void LanguageChanged(object sender, EventArgs e)
        {
            UpdateString(null);
        }

        public virtual void UpdateString(Control Control)
        {
            if (toolTips != null)
            {
                if (DesignMode)
                {
                    if (Control == null)
                    {
                        foreach (var pair in translationStrings)
                        {
                            toolTips.SetToolTip(pair.Key, pair.Value);
                        }
                    }
                    else
                    {
                        if (translationStrings.ContainsKey(Control))
                        {
                            toolTips.SetToolTip(Control, translationStrings[Control]);
                        }
                    }
                }
                else
                {
                    if (LM == null)
                        return;
                    if (Control == null)
                    {
                        foreach (var pair in translationStrings)
                        {
                            if (defaultStrings.ContainsKey(pair.Key))
                            {
                                toolTips.SetToolTip(pair.Key, LM.GetStringDefault(pair.Value, defaultStrings[pair.Key]));
                            }
                            else
                            {
                                toolTips.SetToolTip(pair.Key, LM.GetString(pair.Value));
                            }
                        }
                    }
                    else
                    {
                        if (translationStrings.ContainsKey(Control))
                        {
                            if (!translationStrings.ContainsKey(Control))
                            {
                                if (!defaultStrings.ContainsKey(Control))
                                {
                                    return;
                                }
                                toolTips.SetToolTip(Control, defaultStrings[Control]);
                            }
                            if (defaultStrings.ContainsKey(Control))
                            {
                                toolTips.SetToolTip(Control, LM.GetStringDefault(translationStrings[Control], defaultStrings[Control]));
                            }
                            else
                            {
                                toolTips.SetToolTip(Control, LM.GetString(translationStrings[Control]));
                            }
                        }
                    }
                }
            }
        }
    }
}
