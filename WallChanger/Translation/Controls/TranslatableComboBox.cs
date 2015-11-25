using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WallChanger.Translation.Controls
{
    class TranslatableComboBox : ComboBox
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LanguageManager LanguageManager
        {
            set
            {
                LM = value;
                if (LM != null)
                {
                    UpdateStrings(LM, null);
                    LM.LanguageChanged += UpdateStrings;
                }
            }
        }
        protected LanguageManager LM;

        public event EventHandler<EventArgs> StringChanged;
        protected void FireStringChanged(object sender, EventArgs e)
        {
            StringChanged?.Invoke(sender, e);
        }

        public virtual void UpdateStrings(object sender, EventArgs e)
        {
            RefreshItems();

            FireStringChanged(this, e);
        }
    }
}
