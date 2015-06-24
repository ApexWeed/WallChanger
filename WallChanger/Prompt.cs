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
        public static string ShowStringDialog(string text, string caption)
        {
            return ShowStringDialog(text, caption, "");
        }

        public static string ShowStringDialog(string text, string caption, string defaultText)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Panel panel = new Panel() { Dock = DockStyle.Fill };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Text = defaultText };
            Button confirmation = new Button() { Text = "Ok", Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
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
            prompt.ShowDialog();
            return textBox.Text;
        }

        public static StringBool ShowStringBoolDialog(string text, string caption, string checkText)
        {
            return ShowStringBoolDialog(text, caption, checkText, "", false);
        }

        public static StringBool ShowStringBoolDialog(string text, string caption, string checkText, string defaultText, bool defaultBool)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Panel panel = new Panel() { Dock = DockStyle.Fill };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Text = defaultText };
            CheckBox checkBox = new CheckBox() { Text = checkText, Top = 70, Left = 20, Checked = defaultBool };
            Button confirmation = new Button() { Text = "Ok", Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
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

        public static string ShowStringComboBoxDialog(string Prompt, string Title, string[] ComboBoxValues)
        {
            StringComboBoxPrompt prompt = new StringComboBoxPrompt(Prompt, Title, ComboBoxValues);

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
