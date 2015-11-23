﻿using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class LanguageForm : Form
    {
        readonly LanguageManager LM = GlobalVars.LanguageManager;
        new readonly Form Parent;

        /// <summary>
        /// Initialises a new language form.
        /// </summary>
        /// <param name="Parent">The parent of this form.</param>
        public LanguageForm(Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE.LANGUAGE");
            // Buttons.
            btnSave.Text = LM.GetString("LANG.BUTTON.SAVE");
            // Tooltips.
            // Labels.
            lblCurrentLanguage.Text = LM.GetString("LANG.LABEL.CURRENT_LANGUAGE");
            lblFallbackLanguage.Text = LM.GetString("LANG.LABEL.FALLBACK_LANGUAGE");

            // Cascade.
            if (Parent is MainForm)
                (Parent as MainForm).LocaliseInterface();
        }

        /// <summary>
        /// Saves the language settings and updates the interface.
        /// </summary>
        /// <param name="sender">Sender that fired the event.</param>
        /// <param name="e">Event args associated with this event.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = (cmbCurrentLanguage.SelectedItem as Language).Code;
            Properties.Settings.Default.FallbackLanguage = (cmbFallbackLanguage.SelectedItem as Language).Code;

            // Update all opened interfaces.
            LocaliseInterface();
        }

        /// <summary>
        /// Updates the description.
        /// </summary>
        /// <param name="sender">Sender that fired the event.</param>
        /// <param name="e">Event args associated with this event.</param>
        private void LanguageChanged(object sender, EventArgs e)
        {
            txtDescription.Text = ((sender as ComboBox).SelectedItem as Language).Description;
        }

        /// <summary>
        /// Notifies the parent of closure.
        /// </summary>
        /// <param name="sender">Sender that fired the event.</param>
        /// <param name="e">Event args associated with this event.</param>
        private void LanguageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
        }

        /// <summary>
        /// Sets up the form for use.
        /// </summary>
        /// <param name="sender">Sender that fired the event.</param>
        /// <param name="e">Event args associated with this event.</param>
        private void LanguageForm_Load(object sender, EventArgs e)
        {
            var Languages = LM.GetLanguages();
            foreach (Language Lang in Languages)
            {
                cmbCurrentLanguage.Items.Add(Lang);
                cmbFallbackLanguage.Items.Add(Lang);
            }

            cmbFallbackLanguage.SelectedItem = cmbFallbackLanguage.Items.Find(x => (x as Language).Code == Properties.Settings.Default.FallbackLanguage);
            cmbCurrentLanguage.SelectedItem = cmbCurrentLanguage.Items.Find(x => (x as Language).Code == Properties.Settings.Default.Language);

            LocaliseInterface();
        }
    }
}
