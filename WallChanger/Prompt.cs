using System.Windows.Forms;

namespace WallChanger
{
    public struct StringBool
    {
        public string String;
        public bool Bool;

        public StringBool(string _string, bool _bool)
        {
            String = _string;
            Bool = _bool;
        }
    }

    public static class Prompt
    {
        /// <summary>
        /// Prompts the user for a string.
        /// </summary>
        /// <param name="Text">The text to display in the window.</param>
        /// <param name="Caption">The text to display in the title bar.</param>
        /// <param name="DefaultText">The default value for the prompt.</param>
        /// <returns></returns>
        public static string ShowStringDialog(string Text, string Caption, string DefaultText = "")
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = Caption;
            Panel panel = new Panel() { Dock = DockStyle.Fill };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = Text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Text = DefaultText };
            Button confirmation = new Button() { Text = "Ok", Top = 70 };
            confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            panel.Controls.Add(textLabel);
            panel.Controls.Add(textBox);
            panel.Controls.Add(confirmation);
            prompt.Controls.Add(panel);
            textBox.Width = panel.Width - 40;
            textLabel.Width = panel.Width - 40;
            confirmation.Left = panel.Width - 20 - confirmation.Width;
            prompt.ResizeEnd += (sender, e) =>
            {
                textBox.Width = panel.Width - 40;
                textLabel.Width = panel.Width - 40;
                confirmation.Left = panel.Width - 20 - confirmation.Width;
            };
            prompt.AcceptButton = confirmation;
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Prompts the user for a boolean and string.
        /// </summary>
        /// <param name="Text">The text to display in the window.</param>
        /// <param name="Caption">The text to display in the title bar.</param>
        /// <param name="CheckText">The text to display next to the check box.</param>
        /// <param name="DefaultText">The default textbox value.</param>
        /// <param name="DefaultBool">The default check state.</param>
        /// <returns></returns>
        public static StringBool ShowStringBoolDialog(string Text, string Caption, string CheckText, string DefaultText = "", bool DefaultBool = false)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = Caption;
            Panel panel = new Panel() { Dock = DockStyle.Fill };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = Text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Text = DefaultText };
            CheckBox checkBox = new CheckBox() { Text = CheckText, Top = 70, Left = 20, Checked = DefaultBool };
            Button confirmation = new Button() { Text = "Ok", Top = 70 };
            confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            panel.Controls.Add(textLabel);
            panel.Controls.Add(textBox);
            panel.Controls.Add(confirmation);
            panel.Controls.Add(checkBox);
            prompt.Controls.Add(panel);
            textBox.Width = panel.Width - 40;
            textLabel.Width = panel.Width - 40;
            confirmation.Left = panel.Width - 20 - confirmation.Width;
            prompt.ResizeEnd += (sender, e) =>
            {
                textLabel.Width = panel.Width - 40;
                textBox.Width = panel.Width - 40;
                confirmation.Left = panel.Width - 20 - confirmation.Width;
            };
            prompt.AcceptButton = confirmation;
            prompt.ShowDialog();
            return new StringBool(textBox.Text, checkBox.Checked);
        }

        /// <summary>
        /// Prompts the user to select a value from a combo box.
        /// </summary>
        /// <param name="Prompt">The text to display in the window.</param>
        /// <param name="Title">The text to display in the title bar.</param>
        /// <param name="ComboBoxValues">The values to add to the combo box.</param>
        /// <param name="AllowNew">Whether to allow the user to add new entries.</param>
        /// <returns>Either the chosen value or null.</returns>
        public static string ShowStringComboBoxDialog(string Prompt, string Title, string[] ComboBoxValues, bool AllowNew = true)
        {
            StringComboBoxPrompt prompt = new StringComboBoxPrompt(Prompt, Title, ComboBoxValues, AllowNew);

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return prompt.ChosenString;
            }
            else
            {
                return null;
            }
        }
    }
}
