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
    public partial class LibraryForm : Form
    {
        int MinimumDataHeight;
        
        bool ComboBoxLocked = false;
        bool FiltersExpanded = false;

        List<string> Categories;
        List<string> ShowNames;
        List<string> Characters;
        List<string> Tags;

        List<string> FilterCategories;
        List<string> FilterShowNames;
        List<string> FilterCharacters;
        List<string> FilterTags;

        Dictionary<string, Size> SizeCache;
        
        public LibraryForm(Form Owner)
        {
            InitializeComponent();

            this.Owner = Owner;
            Categories = new List<string>();
            ShowNames = new List<string>();
            Characters = new List<string>();
            Tags = new List<string>();
            SizeCache = new Dictionary<string, Size>();

            // Need to add the blank as the first entry.
            Categories.AddDistinct("");
            ShowNames.AddDistinct("");
            Characters.AddDistinct("");
            Tags.AddDistinct("");

            FilterCategories = new List<string>();
            FilterShowNames = new List<string>();
            FilterCharacters = new List<string>();
            FilterTags = new List<string>();

            // Need to add the blank as the first entry.
            FilterCategories.AddDistinct("");
            FilterShowNames.AddDistinct("");
            FilterCharacters.AddDistinct("");
            FilterTags.AddDistinct("");

            UpdateList();

            pnlFilters.Height = 30;
            MinimumDataHeight = this.MinimumSize.Height - 202;
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is MainForm)
                (Owner as MainForm).ChildClosed(this);
        }

        public void UpdateList()
        {
            lstImages.Items.Clear();
            foreach (var libraryItem in GlobalVars.LibraryItems)
            {
                if (!string.IsNullOrWhiteSpace(cmbCategoryFilter.Text) && cmbCategoryFilter.Text != libraryItem.Category)
                    continue;
                if (!string.IsNullOrWhiteSpace(cmbShowNameFilter.Text) && cmbShowNameFilter.Text != libraryItem.ShowName)
                    continue;
                if (!string.IsNullOrWhiteSpace(cmbCharacterFilter.Text) && !libraryItem.CharacterNames.Contains(cmbCharacterFilter.Text))
                    continue;
                if (!string.IsNullOrWhiteSpace(cmbTagFilter.Text) && !libraryItem.Tags.Contains(cmbTagFilter.Text))
                    continue;

                lstImages.Items.Add(libraryItem.Filename);
                
                Categories.AddDistinct(libraryItem.Category);
                ShowNames.AddDistinct(libraryItem.ShowName);
                Characters.AddDistinct(libraryItem.CharacterNames);
                Tags.AddDistinct(libraryItem.Tags);

                FilterCategories.AddDistinct(libraryItem.Category);
                FilterShowNames.AddDistinct(libraryItem.ShowName);
                FilterCharacters.AddDistinct(libraryItem.CharacterNames);
                FilterTags.AddDistinct(libraryItem.Tags);
            }
            lstImages.SelectedIndex = 0;
        }

        private void UpdateComboBoxes()
        {
            ComboBoxLocked = true;

            string CategoryFilter = cmbCategoryFilter.Text;
            cmbCategoryFilter.DataSource = null;
            cmbCategoryFilter.DataSource = FilterCategories;
            cmbCategoryFilter.Text = CategoryFilter;

            string ShowNameFilter = cmbShowNameFilter.Text;
            cmbShowNameFilter.DataSource = null;
            cmbShowNameFilter.DataSource = FilterShowNames;
            cmbShowNameFilter.Text = ShowNameFilter;

            string CharacterFilter = cmbCharacterFilter.Text;
            cmbCharacterFilter.DataSource = null;
            cmbCharacterFilter.DataSource = FilterCharacters;
            cmbCharacterFilter.Text = CharacterFilter;

            string TagFilter = cmbTagFilter.Text;
            cmbTagFilter.DataSource = null;
            cmbTagFilter.DataSource = FilterTags;
            cmbTagFilter.Text = TagFilter;
            
            cmbCategory.DataSource = null;
            cmbShowName.DataSource = null;
            cmbCategory.DataSource = Categories;
            cmbShowName.DataSource = ShowNames;

            ComboBoxLocked = false;
        }

        private void UpdateControlPositions()
        {
            picPreview.Height = CalculateImageHeight(picPreview.Image, picPreview);

            cmbCategory.Width = pnlDetails.Width - 16;
            cmbShowName.Width = pnlDetails.Width - 16;
            lstCharacters.Width = pnlDetails.Width - 16;

            btnAddCategory.Left = pnlDetails.Width - 63;
            btnClearCategory.Left = pnlDetails.Width - 33;

            btnAddShowName.Left = pnlDetails.Width - 63;
            btnClearShowName.Left = pnlDetails.Width - 33;

            btnAddNewCharacter.Left = pnlDetails.Width - 93;
            btnRemoveCharacter.Left = pnlDetails.Width - 63;
            btnClearCharacters.Left = pnlDetails.Width - 33;

            btnAddNewTag.Left = pnlTagButtons.Width - 84;
            btnRemoveTag.Left = pnlTagButtons.Width - 54;
            btnClearTags.Left = pnlTagButtons.Width - 24;

            btnAddToConfig.Left = pnlFilters.Width - 27;
        }

        private int CalculateImageHeight(Image Image, PictureBox PictureBox)
        {
            if (Image == null)
                return 202;

            int MaxImageHeight = this.Height - MinimumDataHeight;
            float Ratio = (float)Image.Width / (float)Image.Height;
            int ImageHeight = (int)(PictureBox.Width / Ratio);
            return ImageHeight <= MaxImageHeight ? ImageHeight : MaxImageHeight;
        }

        private async void LoadImageSizes()
        {
            int minWidth = int.MaxValue;
            int minHeight = int.MaxValue;
            int maxWidth = int.MinValue;
            int maxHeight = int.MinValue;

            foreach (string image in lstImages.SelectedItems)
            {
                // Get the image size if it is not already cached.
                if (!SizeCache.ContainsKey(image))
                {
                    await Task.Run(() =>
                    {
                        using (Image img = Image.FromFile(image))
                        {
                            SizeCache.AddDistinct(image, img.Size);
                        }
                    });
                }

                if (SizeCache[image].Width < minWidth)
                    minWidth = SizeCache[image].Width;
                else if (SizeCache[image].Width > maxWidth)
                    maxWidth = SizeCache[image].Width;

                if (SizeCache[image].Height < minHeight)
                    minHeight = SizeCache[image].Height;
                else if (SizeCache[image].Height > maxHeight)
                    maxHeight = SizeCache[image].Height;

                lblImageSize.Text = string.Format("Image Size: {0}-{1}x{2}-{3}px", minWidth, maxWidth, minHeight, maxHeight);
            }
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxLocked = true;
            if (lstImages.SelectedIndices.Count > 1)
            {
                cmbCategory.Enabled = false;
                cmbShowName.Enabled = false;
                lstCharacters.Enabled = false;
                lstTags.Enabled = false;

                LoadImageSizes();

                cmbCategory.Text = "";
                cmbShowName.Text = "";
                lstCharacters.Items.Clear();
                lstTags.Items.Clear();
                picPreview.Image = Properties.Resources.Blank;
            }
            else
            {
                Image preview = Image.FromFile(lstImages.SelectedItem as string);
                SizeCache.AddDistinct(lstImages.SelectedItem as string, preview.Size);
                lblImageSize.Text = string.Format("Image Size: {0}x{1}px", preview.Width, preview.Height);
                picPreview.Image = preview;
                picPreview.Height = CalculateImageHeight(preview, picPreview);
                UpdateComboBoxes();
                LibraryItem item = GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string);

                if (!string.IsNullOrWhiteSpace(item.Category))
                    cmbCategory.Text = item.Category;
                else
                    cmbCategory.Text = "";

                if (!string.IsNullOrWhiteSpace(item.ShowName))
                    cmbShowName.Text = item.ShowName;
                else
                    cmbShowName.Text = "";

                lstCharacters.Items.Clear();
                lstCharacters.Items.AddRange(item.CharacterNames.ToArray());
                lstTags.Items.Clear();
                lstTags.Items.AddRange(item.Tags.ToArray());

                cmbCategory.Enabled = true;
                cmbShowName.Enabled = true;
                lstCharacters.Enabled = true;
                lstTags.Enabled = true;
            }
            ComboBoxLocked = false;
        }

        #region "Category"
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the name for the category or use a pre existing value.", "Enter Category", Categories.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Categories.AddDistinct(Value);
            FilterCategories.AddDistinct(Value);
            UpdateComboBoxes();
            cmbCategory.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = Value;
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = "";
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want to update any values when multiple are selected.
            if (lstImages.SelectedItems.Count > 1)
                return;
            
            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = cmbCategory.Text;
        }
        #endregion

        #region "Show Name"
        private void btnAddShowName_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the show name or use a pre existing value.", "Enter Show Name", ShowNames.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            ShowNames.AddDistinct(Value);
            FilterShowNames.AddDistinct(Value);
            UpdateComboBoxes();
            cmbShowName.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = Value;
        }

        private void btnClearShowName_Click(object sender, EventArgs e)
        {
            cmbShowName.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = "";
        }

        private void cmbShowName_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want to update any values when multiple are selected.
            if (lstImages.SelectedItems.Count > 1)
                return;

            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = cmbShowName.Text;
        }
        #endregion

        #region "Character"
        private void btnAddNewCharacter_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the character name or use a pre existing value.", "Enter Character Name", Characters.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Characters.AddDistinct(Value);
            FilterCharacters.AddDistinct(Value);
            lstCharacters.Items.Add(Value);
            lstCharacters.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.AddDistinct(Value);
        }

        private void btnRemoveCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                lstCharacters.Items.Remove(lstCharacters.SelectedItem);
            }
        }

        private void btnClearCharacters_Click(object sender, EventArgs e)
        {
            lstCharacters.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Clear();
        }
        #endregion

        #region "Tags"
        private void btnAddNewTag_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog("Enter the tag or use a pre existing value.", "Enter Tag", Tags.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Tags.AddDistinct(Value);
            FilterTags.AddDistinct(Value);
            lstTags.Items.Add(Value);
            lstTags.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.AddDistinct(Value);
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Remove(lstTags.SelectedItem as string);
                lstCharacters.Items.Remove(lstTags.SelectedItem);
            }
        }

        private void btnClearTags_Click(object sender, EventArgs e)
        {
            lstTags.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Clear();
        }
        #endregion

        private void btnExpand_Click(object sender, EventArgs e)
        {
            FiltersExpanded = !FiltersExpanded;
            if (FiltersExpanded)
            {
                btnExpand.Image = Properties.Resources.toggle;
                Tooltips.SetToolTip(btnExpand, "Shrink filters.");
                pnlFilters.Height = 146;
            }
            else
            {
                btnExpand.Image = Properties.Resources.toggle_expand;
                Tooltips.SetToolTip(btnExpand, "Expand filters.");
                pnlFilters.Height = 30;
            }
        }

        private void spcContainer_Panel2_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void spcContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            UpdateControlPositions();
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MAXIMIZE)
                    {
                        UpdateControlPositionsAsync(50);
                    }
                    if (command == SC_RESTORE)
                    {
                        UpdateControlPositionsAsync(50);
                    }
                    break;
            }

            base.WndProc(ref message);
        }

        private async void UpdateControlPositionsAsync(int Delay)
        {
            await Task.Delay(Delay);
            UpdateControlPositions();
        }

        #region "Filters"
        private void FilterChoiceChanged(object sender, EventArgs e)
        {
            // Don't update the list if we are already updating it.
            if (ComboBoxLocked)
                return;
            UpdateList();
        }

        private void btnCategoryFilterClear_Click(object sender, EventArgs e)
        {
            cmbCategoryFilter.Text = "";
            UpdateList();
        }

        private void btnShowNameFilterClear_Click(object sender, EventArgs e)
        {
            cmbShowNameFilter.Text = "";
            UpdateList();
        }

        private void btnCharacterFilterClear_Click(object sender, EventArgs e)
        {
            cmbCharacterFilter.Text = "";
            UpdateList();
        }

        private void btnTagFilterClear_Click(object sender, EventArgs e)
        {
            cmbTagFilter.Text = "";
            UpdateList();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbCategoryFilter.Text = "";
            cmbShowNameFilter.Text = "";
            cmbCharacterFilter.Text = "";
            cmbTagFilter.Text = "";
            UpdateList();
        }
        #endregion

        private void btnAddToConfig_Click(object sender, EventArgs e)
        {
            if (Owner is MainForm)
            {
                string[] Images = new string[lstImages.SelectedItems.Count];
                lstImages.SelectedItems.CopyTo(Images, 0);
                (Owner as MainForm).AddImages(new List<string>(Images));
            }

        }

        private void LibraryForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                using (Stream read = File.Open(file, FileMode.Open))
                {
                    if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                        continue;
                    GlobalVars.LibraryItems.Add(new LibraryItem(file));
                }
            }
            UpdateList();
        }

        private void LibraryForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
