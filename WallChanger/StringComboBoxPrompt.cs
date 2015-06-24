using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class StringComboBoxPrompt : Form
    {
        public string ChosenString;

        public StringComboBoxPrompt(string Prompt, string Title, string[] ComboBoxValues)
        {
            InitializeComponent();

            lblPrompt.Text = Prompt;
            this.Text = Title;
            cmbComboBox.DataSource = ComboBoxValues;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdbComboBox.Checked)
            {
                ChosenString = cmbComboBox.Text;
            }
            else
            {
                ChosenString = txtTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(ChosenString))
            {
                MessageBox.Show("You need to enter a string in either of the two input methods.");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            if (rdbComboBox.Checked)
            {
                cmbComboBox.Enabled = true;
                txtTextBox.Enabled = false;
            }
            else
            {
                cmbComboBox.Enabled = false;
                txtTextBox.Enabled = true;
            }
        }
    }
}
