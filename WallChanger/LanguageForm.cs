using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class LanguageForm : Form
    {
        new Form Parent;
        LanguageManager LM = GlobalVars.LanguageManager;

        public LanguageForm(Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        private void LanguageForm_Load(object sender, EventArgs e)
        {
            List<Language> Languages = LM.GetLanguages();
            foreach (Language Lang in Languages)
            {
                cmbCurrentLanguage.Items.Add(Lang);
                cmbFallbackLanguage.Items.Add(Lang);
            }

            cmbFallbackLanguage.SelectedItem = cmbFallbackLanguage.Items.Find(x => (x as Language).Code == Properties.Settings.Default.FallbackLanguage);
            cmbCurrentLanguage.SelectedItem = cmbCurrentLanguage.Items.Find(x => (x as Language).Code == Properties.Settings.Default.Language);

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Buttons.
            btnSave.Text = LM.GetString("LANG_BUTTON_SAVE");
            // Tooltips.
            // Labels.
            lblCurrentLanguage.Text = LM.GetString("LANG_LABEL_CURRENT_LANGUAGE");
            lblFallbackLanguage.Text = LM.GetString("LANG_LABEL_FALLBACK_LANGUAGE");

            // Cascade.
            if (Parent is MainForm)
                (Parent as MainForm).LocaliseInterface();
        }

        private void LanguageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = (cmbCurrentLanguage.SelectedItem as Language).Code;
            Properties.Settings.Default.FallbackLanguage = (cmbFallbackLanguage.SelectedItem as Language).Code;

            // Update all opened interfaces.
            LocaliseInterface();
        }

        private void LanguageChanged(object sender, EventArgs e)
        {
            txtDescription.Text = ((sender as ComboBox).SelectedItem as Language).Description;
        }
    }
}
