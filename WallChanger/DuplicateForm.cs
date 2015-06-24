using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WallChanger
{
    public partial class DuplicateForm : Form
    {
        int MINIMUM_DATA_HEIGHT;

        bool AutoModeEngaged = false;

        AutoResolveForm autoResolveForm = null;

        public DuplicateForm(List<List<string>> Duplicates, Form Owner)
        {
            InitializeComponent();
            this.Owner = Owner;

            for (int i = 0; i < Duplicates.Count; i++)
            {
                List<Duplicate> DuplicateEntries = new List<Duplicate>();

                foreach (string Filename in Duplicates[i])
                {
                    Duplicate duplicate = new Duplicate(Filename, Path.GetFileName(Filename));
                    DuplicateEntries.Add(duplicate);
                }

                DuplicateList duplicateList = new DuplicateList(string.Format("Entry {0}", i + 1), DuplicateEntries);
                lstDuplicates.Items.Add(duplicateList);
            }

            MINIMUM_DATA_HEIGHT = 58 + (this.Height - pnlRight.Height);

            if (lstDuplicates.Items.Count > 0)
                lstDuplicates.SelectedIndex = 0;
        }

        private void DuplicateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is LibraryForm)
                (Owner as LibraryForm).ChildClosed(this);
        }

        private void lstDuplicates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!AutoModeEngaged)
            {
                DuplicateList duplicate = lstDuplicates.SelectedItem as DuplicateList;

                if (duplicate != null)
                {
                    lstDuplicateImages.Items.Clear();
                    lstDuplicateImages.Items.AddRange(duplicate.Duplicates.ToArray());

                    if (lstDuplicateImages.Items.Count > 0)
                        lstDuplicateImages.SelectedIndex = 0;
                }
            }
        }

        private void lstDuplicateImages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!AutoModeEngaged)
            {
                Duplicate duplicate = lstDuplicateImages.SelectedItem as Duplicate;

                if (duplicate == null)
                    return;

                lblFilePath.Text = duplicate.Path;
                picPreview.Image = Imaging.FromFile(duplicate.Path);
                lblImageSize.Text = string.Format("{0} x {1}", picPreview.Image.Width, picPreview.Image.Height);
            }
        }

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

        private void DuplicateForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveFromLibrary();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this image?", "Confirm Deletion", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                File.Delete((lstDuplicateImages.SelectedItem as Duplicate).Path);
                RemoveFromLibrary();
            }
        }

        private void btnKeep_Click(object sender, EventArgs e)
        {
            RemoveEntry();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will automatically delete duplicate images keeping the highest resolution version. Continue?") == DialogResult.OK)
            {
                AutoModeEngaged = true;

                List<DuplicateList> DuplicateLists = new List<DuplicateList>();

                foreach (var List in lstDuplicates.Items)
                {
                    DuplicateLists.Add(List as DuplicateList);
                }

                foreach (var List in DuplicateLists)
                {
                    int maxSize = 0;

                    for (int i = 0; i < List.Duplicates.Count; i++)
                    {
                        Duplicate Entry = List.Duplicates[i];
                        int size = (Entry.Size.Width + Entry.Size.Height) / 2;
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

        private void RemoveFromLibrary()
        {
            GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == (lstDuplicateImages.SelectedItem as Duplicate).Path));
            if (Owner is LibraryForm)
                (Owner as LibraryForm).UpdateList();

            RemoveEntry();
        }

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

        private void RefreshList(ListBox List)
        {
            int count = List.Items.Count;

            List.SuspendLayout();
            for (int i = 0; i < count; i++)
            {
                List.Items[i] = List.Items[i];
            }
            List.ResumeLayout();
        }
    }
}