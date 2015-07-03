using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class SettingsForm : Form
    {
        new Form Parent;
        LanguageManager LM = GlobalVars.LanguageManager;

        public SettingsForm(Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.None);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Fast);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Low);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Normal);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.High);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Ultra);

            cmbCompressionLevel.SelectedItem = cmbCompressionLevel.Items.Find(x => (SevenZip.CompressionLevel)x == Properties.Settings.Default.CompressionLevel);

            LocaliseInterface();
        }

        public void LocaliseInterface()
        {
            // Buttons.

            // Tooltips.

            // Labels.
            grpCompression.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION");
            lblCompressionLevel.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_LEVEL");
            lblCompressionWarning.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_WARNING");

            // Cascade.
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
        }

        private void cmbCompressionLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCompressionLevel.SelectedItem != null)
            {
                Properties.Settings.Default.CompressionLevel = (SevenZip.CompressionLevel)cmbCompressionLevel.SelectedItem;
            }
        }
    }
}
