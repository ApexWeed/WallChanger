using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableTitle : Component, ISupportInitialize
    {
        private Form parentForm;

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
                parentForm.Text = translationString;
            }
            else
            {
                if (LM == null)
                    return;
                if (string.IsNullOrWhiteSpace(defaultString))
                {
                    parentForm.Text = LM.GetString(translationString);
                }
                else
                {
                    parentForm.Text = LM.GetStringDefault(translationString, defaultString);
                }
            }
        }

        void ISupportInitialize.BeginInit()
        {
            return;
        }

        void ISupportInitialize.EndInit()
        {
            if (parentForm != null)
                return; // do nothing if it is set
            IDesignerHost host;
            if (Site != null)
            {
                host = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host != null)
                {
                    if (host.RootComponent is Form)
                    {
                        parentForm = (Form)host.RootComponent;
                    }
                }
            }
        }
    }
}
