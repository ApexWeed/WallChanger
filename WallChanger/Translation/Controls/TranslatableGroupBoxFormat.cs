using System;

namespace WallChanger.Translation.Controls
{
    class TranslatableGroupBoxFormat : TranslatableGroupBox
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
                Text = translationString;
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
                    Text = defaultString;
                }
                if (string.IsNullOrWhiteSpace(defaultString))
                {
                    try
                    {
                        Text = string.Format(LM.GetString(translationString), parameters);
                    }
                    catch (FormatException)
                    {
                        Text = translationString;
                    }
                }
                else
                {
                    try
                    {
                        Text = string.Format(LM.GetStringDefault(translationString, defaultString), parameters);
                    }
                    catch (FormatException)
                    {
                        Text = translationString;
                    }
                }
            }
        }
    }
}
