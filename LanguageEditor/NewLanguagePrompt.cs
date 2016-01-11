using System;
using System.Windows.Forms;

namespace LanguageEditor
{
    public partial class NewLanguagePrompt : Form
    {
        public string LanguageCode;
        public string LanguageName;
        public string Author;
        public string Description;

        public NewLanguagePrompt()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LanguageCode = txtLanguageCode.Text;
            LanguageName = txtLanguageName.Text;
            Author = txtAuthor.Text;
            Description = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(LanguageCode) || string.IsNullOrWhiteSpace(LanguageName))
            {
                MessageBox.Show("Language name and language code cannot be empty.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
