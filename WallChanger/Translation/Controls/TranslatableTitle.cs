using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableTitle : Component
    {
        public Form ParentForm
        {
            get { return parentForm; }
            set { parentForm = value; }
        }
        protected Form parentForm;

        [Category("Appearance")]
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
        protected string translationString;

        [Category("Appearance")]
        [Description("The string to use when the language manager doesn't have a suitable string.")]
        [DefaultValue("")]
        public string DefaultString
        {
            get { return defaultString; }
            set { defaultString = value; }
        }
        protected string defaultString;

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
        protected LanguageManager LM;

        public virtual void UpdateString(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                parentForm.Text = translationString;
            }
            else
            {
                if (LM == null)
                    return;
                if (string.IsNullOrWhiteSpace(translationString))
                {
                    if (string.IsNullOrWhiteSpace(defaultString))
                    {
                        return;
                    }
                    parentForm.Text = defaultString;
                }
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

        public override ISite Site
        {
            get { return base.Site; }
            set
            {
                base.Site = value;
                if (value == null)
                {
                    return;
                }
                var host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                var componentHost = host.RootComponent;
                if (componentHost is ContainerControl)
                {
                    parentForm = (componentHost as ContainerControl).FindForm();
                }
            }
        }
    }
}
