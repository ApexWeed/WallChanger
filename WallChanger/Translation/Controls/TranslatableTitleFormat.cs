using System;

namespace WallChanger.Translation.Controls
{
    class TranslatableTitleFormat : TranslatableTitle
    {
        public object[] Parameters
        {
            get { return parameters; }
            set
            {
                parameters = value;
                if (parameters == null)
                {
                    parameters = new object[0];
                }
                UpdateString(null, null);
            }
        }
        protected object[] parameters = new object[0];

        public override void UpdateString(object sender, EventArgs e)
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
                    try
                    {
                        parentForm.Text = string.Format(LM.GetString(translationString), parameters);
                    }
                    catch (FormatException)
                    {
                        parentForm.Text = translationString;
                    }
                }
                else
                {
                    try
                    {
                        parentForm.Text = string.Format(LM.GetStringDefault(translationString, defaultString), parameters);
                    }
                    catch (FormatException)
                    {
                        parentForm.Text = translationString;
                    }
                }
            }
        }
    }
}
