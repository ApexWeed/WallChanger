using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WallChanger
{
    public partial class DuplicateForm : Form
    {
        int MINIMUM_DATA_HEIGHT;
        
        List<List<string>> Duplicates;
        //         filename  -> index
        Dictionary<string,      int> DuplicateEntryMapping;
        //         listentry -> filename
        Dictionary<string,      string> DuplicateImageMapping;
        //         filename  -> image
        Dictionary<string,      Image> ImageMapping;

        public DuplicateForm(List<List<string>> Duplicates, Form Owner)
        {
            InitializeComponent();
            this.Owner = Owner;
            this.Duplicates = Duplicates;
            DuplicateEntryMapping = new Dictionary<string, int>();
            DuplicateImageMapping = new Dictionary<string, string>();
            ImageMapping = new Dictionary<string, Image>();

            for (int i = 0; i < Duplicates.Count; i++)
            {
                int innerI = i;
                string text = string.Format("Duplicate {0}, {1} duplicates found", innerI + 1, Duplicates[i].Count);
                lstDuplicates.Items.Add(text);
                DuplicateEntryMapping.Add(text, innerI);
            }
            MINIMUM_DATA_HEIGHT = 58 + (this.Height - pnlRight.Height);
            LoadImages();
        }

        private async void LoadImages()
        {
            pnlLoadingImages.Visible = true;
            pnlRight.Visible = false;
            int Count = 0;
            int Current = 0;

            foreach (var entry in Duplicates)
            {
                foreach (var image in entry)
                {
                    Count++;
                }
            }

            UpdateLoadProgress(Current, Count);
            foreach (var entry in Duplicates)
            {
                foreach (var image in entry)
                {
                    await Task.Run(() => { ImageMapping.Add(image, Imaging.FromFile(image)); });
                    UpdateLoadProgress(++Current, Count);
                }
            }

            pnlRight.Visible = true;
            pnlLoadingImages.Visible = false;
            lstDuplicates.SelectedIndex = 0;
        }

        private void UpdateLoadProgress(int Current, int Count)
        {
            int Percent = (int)(((float)Current / (float)Count) * 100);

            lblLoadingImages.Text = string.Format("Loading images ({0} / {1})", Current, Count);
            pgbLoadingImages.Value = Percent;

            UpdateControlPositions();
        }

        private void DuplicateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is LibraryForm)
                (Owner as LibraryForm).ChildClosed(this);
        }

        private void lstDuplicates_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want to do anything if images are still loading.
            if (pnlRight.Visible)
            {
                if (lstDuplicates.SelectedItem != null)
                {
                    lstDuplicateImages.Items.Clear();
                    DuplicateImageMapping.Clear();
                    int Index = DuplicateEntryMapping[lstDuplicates.SelectedItem as string];
                    for (int i = 0; i < Duplicates[Index].Count; i++)
                    {
                        int innerI = i;
                        string text = string.Format("Image {0} ({1}x{2})", innerI + 1, ImageMapping[Duplicates[Index][i]].Width, ImageMapping[Duplicates[Index][i]].Height);
                        lstDuplicateImages.Items.Add(text);
                        DuplicateImageMapping.Add(text, Duplicates[Index][i]);
                    }
                    if (lstDuplicateImages.Items.Count > 0)
                        lstDuplicateImages.SelectedIndex = 0;
                }
            }
        }

        private void lstDuplicateImages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstDuplicateImages.SelectedItem != null)
            {
                Image image = ImageMapping[DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]];
                picPreview.Image = image;
                lblImageSize.Text = string.Format("Image Size: ({0}x{1})", image.Width, image.Height);
                lblFilePath.Text = DuplicateImageMapping[lstDuplicateImages.SelectedItem as string];
                UpdateControlPositions();
            }
        }

        private void UpdateControlPositions()
        {
            lblLoadingImages.Left = (pnlLoadingImages.Width / 2) - (TextRenderer.MeasureText(lblLoadingImages.Text, lblLoadingImages.Font).Width / 2);
            lblLoadingImages.Top = ((pnlLoadingImages.Height - pgbLoadingImages.Height) / 2) - (TextRenderer.MeasureText(lblLoadingImages.Text, lblLoadingImages.Font).Height / 2);

            lblFilePath.Left = (pnlControls.Width / 2) - (TextRenderer.MeasureText(lblFilePath.Text, lblFilePath.Font).Width / 2);
            lblImageSize.Left = (pnlControls.Width / 2) - (TextRenderer.MeasureText(lblImageSize.Text, lblImageSize.Font).Width / 2);

            picPreview.Height = Imaging.CalculateImageHeight(picPreview.Image, picPreview, this.Height, MINIMUM_DATA_HEIGHT);

            btnRemove.Left = (pnlControls.Width / 2) - btnRemove.Width - 3 - btnKeep.Width / 2;
            btnKeep.Left = (pnlControls.Width / 2) - btnKeep.Width / 2;
            btnDelete.Left = (pnlControls.Width / 2) + 3 + btnKeep.Width / 2;
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
                File.Delete(DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]);
                RemoveFromLibrary();
            }
        }

        private void btnKeep_Click(object sender, EventArgs e)
        {
            RemoveEntry();
        }

        private void RemoveFromLibrary()
        {
            GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]));
            if (Owner is LibraryForm)
                (Owner as LibraryForm).UpdateList();

            RemoveEntry();
        }

        private void RemoveEntry()
        {
            ImageMapping[DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]].Dispose();
            ImageMapping.Remove(DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]);
            Duplicates[DuplicateEntryMapping[lstDuplicates.SelectedItem as string]].Remove(Duplicates[DuplicateEntryMapping[lstDuplicates.SelectedItem as string]].Find(i => i == DuplicateImageMapping[lstDuplicateImages.SelectedItem as string]));
            DuplicateImageMapping.Remove(lstDuplicateImages.SelectedItem as string);
            lstDuplicateImages.Items.Remove(lstDuplicateImages.SelectedItem as string);
            if (lstDuplicateImages.Items.Count == 0)
            {
                //Duplicates.RemoveAt(DuplicateEntryMapping[lstDuplicates.SelectedItem as string]);
                DuplicateEntryMapping.Remove(lstDuplicates.SelectedItem as string);
                lstDuplicates.Items.Remove(lstDuplicates.SelectedItem as string);
                if (lstDuplicates.Items.Count > 0)
                    lstDuplicates.SelectedIndex = 0;
            }
            else
            {
                lstDuplicateImages.SelectedIndex = 0;
            }
        }
    }
}
