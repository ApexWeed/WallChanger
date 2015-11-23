using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using WallChanger.Translation;

namespace WallChanger
{
    public partial class DuplicateForm : Form
    {

        bool AutoModeEngaged;

        readonly LanguageManager LM = GlobalVars.LanguageManager;
        readonly int MINIMUM_DATA_HEIGHT;

        /// <summary>
        /// Initialises a new duplicate form.
        /// </summary>
        /// <param name="Duplicates">The list of duplicate entries to add.</param>
        /// <param name="Owner">The owner of this form.</param>
        public DuplicateForm(List<List<string>> Duplicates, Form Owner)
        {
            InitializeComponent();
            this.Owner = Owner;

            for (int i = 0; i < Duplicates.Count; i++)
            {
                var DuplicateEntries = new List<Duplicate>();

                foreach (string Filename in Duplicates[i])
                {
                    var duplicate = new Duplicate(Filename, Path.GetFileName(Filename));
                    DuplicateEntries.Add(duplicate);
                }

                var duplicateList = new DuplicateList($"Entry {i + 1}", DuplicateEntries);
                lstDuplicates.Items.Add(duplicateList);
            }

            MINIMUM_DATA_HEIGHT = 58 + (this.Height - pnlRight.Height);

            if (lstDuplicates.Items.Count > 0)
                lstDuplicates.SelectedIndex = 0;

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE.DUPLICATE");
            // Buttons.
            btnKeep.Text = LM.GetString("DUPE.BUTTON.KEEP");
            btnRemove.Text = LM.GetString("DUPE.BUTTON.REMOVE");
            btnDelete.Text = LM.GetString("DUPE.BUTTON.DELETE");
            btnAuto.Text = LM.GetString("DUPE.BUTTON.AUTO");
            // Tooltips.
            // Labels.

            // Cascade.
        }

        /// <summary>
        /// Refreshes the displayed values in the listbox.
        /// </summary>
        /// <param name="List">The listbox to refresh.</param>
        private static void RefreshList(ListBox List)
        {
            var count = List.Items.Count;

            List.SuspendLayout();
            for (int i = 0; i < count; i++)
            {
                List.Items[i] = List.Items[i];
            }
            List.ResumeLayout();
        }

        /// <summary>
        /// Automatically keeps the highest resolution image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LM.GetString("DUPE.MESSAGE.CONFIRM_AUTO"), LM.GetString("DUPE.MESSAGE.CONFIRM_AUTO_TITLE"), MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                AutoModeEngaged = true;

                var DuplicateLists = new List<DuplicateList>();

                foreach (var List in lstDuplicates.Items)
                {
                    DuplicateLists.Add(List as DuplicateList);
                }

                foreach (var List in DuplicateLists)
                {
                    var maxSize = 0;

                    for (int i = 0; i < List.Duplicates.Count; i++)
                    {
                        var Entry = List.Duplicates[i];
                        var size = (Entry.Size.Width + Entry.Size.Height) / 2;
                        if (size < maxSize)
                        {
                            GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(x => x.Filename == Entry.Path));
                            File.Delete(Entry.Path);
                            List.Duplicates.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            if (i != 0)
                            {
                                GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(x => x.Filename == Entry.Path));
                                File.Delete(Entry.Path);
                                List.Duplicates.RemoveAt(0);
                                i--;
                            }
                            maxSize = size;
                        }
                    }
                }

                AutoModeEngaged = false;

                RefreshList(lstDuplicates);
            }
        }

        /// <summary>
        /// Deletes the selected image from disk.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LM.GetString("DUPE.MESSAGE.CONFIRM_DELETE"), LM.GetString("DUPE.MESSAGE.CONFIRM_DELETE_TITLE"), MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                File.Delete((lstDuplicateImages.SelectedItem as Duplicate).Path);
                RemoveFromLibrary();
            }
        }

        /// <summary>
        /// Keeps the image but removes it from the list.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnKeep_Click(object sender, EventArgs e)
        {
            RemoveEntry();
        }

        /// <summary>
        /// Removes the selected image from the library.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveFromLibrary();
        }

        /// <summary>
        /// Notifies the parent form of closure.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void DuplicateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is LibraryForm)
                LibraryForm.ChildClosed(this);
        }

        /// <summary>
        /// Updates control positions on resize.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void DuplicateForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        /// <summary>
        /// Updates the displayed image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void lstDuplicateImages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!AutoModeEngaged)
            {
                var duplicate = lstDuplicateImages.SelectedItem as Duplicate;

                if (duplicate == null)
                    return;

                lblFilePath.Text = duplicate.Path;
                picPreview.Image = Imaging.FromFile(duplicate.Path);
                lblImageSize.Text = string.Format(LM.GetStringDefault("DUPE.LABEL.IMAGE_SIZE", "DUPE.LABEL.IMAGE_SIZE {0}x{1}px"), picPreview.Image.Width, picPreview.Image.Height);
            }
        }

        /// <summary>
        /// Updates the displayed duplicate.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void lstDuplicates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!AutoModeEngaged)
            {
                var duplicate = lstDuplicates.SelectedItem as DuplicateList;

                if (duplicate != null)
                {
                    lstDuplicateImages.Items.Clear();
                    lstDuplicateImages.Items.AddRange(duplicate.Duplicates.ToArray());

                    if (lstDuplicateImages.Items.Count > 0)
                        lstDuplicateImages.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Removes the duplicate entry from the form.
        /// </summary>
        private void RemoveEntry()
        {
            (lstDuplicates.SelectedItem as DuplicateList).Duplicates.RemoveAt(lstDuplicateImages.SelectedIndex);
            if ((lstDuplicates.SelectedItem as DuplicateList).Duplicates.Count == 1)
            {
                lstDuplicates.Items.RemoveAt(lstDuplicates.SelectedIndex);
                if (lstDuplicates.Items.Count > 0)
                    lstDuplicates.SelectedIndex = 0;
            }

            RefreshList(lstDuplicates);
        }

        /// <summary>
        /// Removes the image from the library.
        /// </summary>
        private void RemoveFromLibrary()
        {
            GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == (lstDuplicateImages.SelectedItem as Duplicate).Path));
            if (Owner is LibraryForm)
                (Owner as LibraryForm).UpdateList();

            RemoveEntry();
        }

        /// <summary>
        /// Updates the positions of controls for this window size.
        /// </summary>
        private void UpdateControlPositions()
        {
            lblFilePath.Left = (pnlControls.Width / 2) - (TextRenderer.MeasureText(lblFilePath.Text, lblFilePath.Font).Width / 2);
            lblImageSize.Left = (pnlControls.Width / 2) - (TextRenderer.MeasureText(lblImageSize.Text, lblImageSize.Font).Width / 2);

            picPreview.Height = Imaging.CalculateImageHeight(picPreview.Image, picPreview, this.Height, MINIMUM_DATA_HEIGHT);

            btnRemove.Left = (pnlControls.Width / 2) - btnRemove.Width - btnKeep.Width - 9;
            btnKeep.Left = (pnlControls.Width / 2) - btnKeep.Width - 3;
            btnDelete.Left = (pnlControls.Width / 2) + 3;
            btnAuto.Left = (pnlControls.Width / 2) + btnAuto.Width + 9;
        }
    }
}