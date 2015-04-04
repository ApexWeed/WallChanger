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
        int MINIMUM_DATA_HEIGHT;
        
        bool ComboBoxLocked = false;
        bool FiltersExpanded = false;
        bool ScanningDuplicates = false;

        List<string> Categories;
        List<string> ShowNames;
        List<string> Characters;
        List<string> Tags;

        List<string> FilterCategories;
        List<string> FilterShowNames;
        List<string> FilterCharacters;
        List<string> FilterTags;

        Queue<string> SizeCacheQueue = new Queue<string>();
        bool SizeCacheRunning = false;
        List<string> LastSizeRequest = new List<string>();

        ListViewColumnSorter lsvSorter;
        
        public LibraryForm(Form Owner)
        {
            InitializeComponent();

            this.Owner = Owner;
            Categories = new List<string>();
            ShowNames = new List<string>();
            Characters = new List<string>();
            Tags = new List<string>();

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
            MINIMUM_DATA_HEIGHT = this.MinimumSize.Height - 202;

            lsvSorter = new ListViewColumnSorter();
            lsvDisplay.ListViewItemSorter = lsvSorter;
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is MainForm)
                (Owner as MainForm).ChildClosed(this);
        }

        public void UpdateList()
        {
            // CONVERTED
            //lstImages.Items.Clear();
            lsvDisplay.Items.Clear();
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
                Size ImageSize = new Size(0, 0);
                if (GlobalVars.ImageSizeCache.ContainsKey(libraryItem.Filename))
                    ImageSize = GlobalVars.ImageSizeCache[libraryItem.Filename];
                else
                    SizeCacheQueue.Enqueue(libraryItem.Filename);

                // CONVERTED
                ListViewItem item = new ListViewItem(new string[] { string.Concat(Path.GetDirectoryName(libraryItem.Filename).Split('\\').Reverse().ToArray()[0], "\\", Path.GetFileNameWithoutExtension(libraryItem.Filename)), ImageSize.Width.ToString(), ImageSize.Height.ToString() });
                item.Tag = libraryItem.Filename;
                lsvDisplay.Items.Add(item);
                //lstImages.Items.Add(libraryItem.Filename);
                
                Categories.AddDistinct(libraryItem.Category);
                ShowNames.AddDistinct(libraryItem.ShowName);
                Characters.AddDistinct(libraryItem.CharacterNames);
                Tags.AddDistinct(libraryItem.Tags);

                FilterCategories.AddDistinct(libraryItem.Category);
                FilterShowNames.AddDistinct(libraryItem.ShowName);
                FilterCharacters.AddDistinct(libraryItem.CharacterNames);
                FilterTags.AddDistinct(libraryItem.Tags);
            }
            // CONVERTED
            if (lsvDisplay.Items.Count > 0)
                lsvDisplay.Items[0].Selected = true;
            //if (lstImages.Items.Count > 0)
            //    lstImages.SelectedIndex = 0;

            // CONVERTED
            tslStatistics.Text = string.Format("Images displayed: {0}/{1} Size cache: {2}", lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
            //tslStatistics.Text = string.Format("Images displayed: {0}/{1} Size cache: {2}", lstImages.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);

            LoadImageSizes(false);
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
            picPreview.Height = Imaging.CalculateImageHeight(picPreview.Image, picPreview, this.Height, MINIMUM_DATA_HEIGHT);

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
            btnRemoveFromLibrary.Left = pnlFilters.Width - 57;
            btnClearLibrary.Left = pnlFilters.Width - 87;
            btnFindDuplicates.Left = pnlFilters.Width - 117;
            btnFindAllDuplicates.Left = pnlFilters.Width - 147;
            lblDuplicates.Left = pnlFilters.Width - 271;

            colFilename.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private async void LoadImageSizes(bool skipChanges = false)
        {
            int minWidth = int.MaxValue;
            int minHeight = int.MaxValue;
            int maxWidth = int.MinValue;
            int maxHeight = int.MinValue;

            if (skipChanges)
            {
                LastSizeRequest = new List<string>();
                foreach (ListViewItem item in lsvDisplay.SelectedItems)
                {
                    SizeCacheQueue.Enqueue(item.Tag as string);
                    LastSizeRequest.Add(item.Tag as string);
                }
            }

            if (!SizeCacheRunning)
            {
                while (SizeCacheQueue.Count > 0)
                {
                    string image = SizeCacheQueue.Dequeue();
                    // Get the image size if it is not already cached.
                    if (!GlobalVars.ImageSizeCache.ContainsKey(image))
                    {
                        System.Drawing.Size size = new Size();
                        await Task.Run(() =>
                        {
                            using (Image img = Image.FromFile(image))
                            {
                                GlobalVars.ImageSizeCache.AddDistinct(image, img.Size);
                                size = img.Size;
                            }
                        });

                        ListViewItem item = lsvDisplay.Items.FindByTag(image);
                        item.SubItems[1].Text = size.Width.ToString();
                        item.SubItems[2].Text = size.Height.ToString();
                    }

                    tslStatus.Text = string.Format("Calculating image sizes ({0} remaining)", SizeCacheQueue.Count);
                }

                foreach (string image in LastSizeRequest)
                {
                    if (GlobalVars.ImageSizeCache[image].Width < minWidth)
                        minWidth = GlobalVars.ImageSizeCache[image].Width;
                    else if (GlobalVars.ImageSizeCache[image].Width > maxWidth)
                        maxWidth = GlobalVars.ImageSizeCache[image].Width;

                    if (GlobalVars.ImageSizeCache[image].Height < minHeight)
                        minHeight = GlobalVars.ImageSizeCache[image].Height;
                    else if (GlobalVars.ImageSizeCache[image].Height > maxHeight)
                        maxHeight = GlobalVars.ImageSizeCache[image].Height;
                    lblImageSize.Text = string.Format("Image Size: {0}-{1}x{2}-{3}px", minWidth, maxWidth, minHeight, maxHeight);
                }
                LastSizeRequest.Clear();
                tslStatus.Text = "Ready";
                // CONVERTED
                tslStatistics.Text = string.Format("Images displayed: {0}/{1} Size cache: {2}", lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
                //tslStatistics.Text = string.Format("Images displayed: {0}/{1} Size cache: {2}", lstImages.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
            }
        }

        private delegate ListView.ListViewItemCollection GetItems(ListView listView);
        private ListView.ListViewItemCollection GetListViewItems(ListView listView)
        {
            ListView.ListViewItemCollection temp = new ListView.ListViewItemCollection(new ListView());
            if (!listView.InvokeRequired)
            {
                foreach (ListViewItem item in listView.Items)
                    temp.Add(item);
                return temp;
            }
            else
                return (ListView.ListViewItemCollection)this.Invoke(new GetItems(GetListViewItems), new object[] { listView });
        }

        // CONVERTED
        private void lsvDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxLocked = true;
            if (lsvDisplay.SelectedIndices.Count > 1)
            {
                btnFindDuplicates.Enabled = true;
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
                btnFindDuplicates.Enabled = false;
                Image preview = Imaging.FromFile(lsvDisplay.SelectedItems[0].Tag as string);
                GlobalVars.ImageSizeCache.AddDistinct(lsvDisplay.SelectedItems[0].Tag as string, preview.Size);
                lblImageSize.Text = string.Format("Image Size: {0}x{1}px", preview.Width, preview.Height);
                lsvDisplay.SelectedItems[0].SubItems[1].Text = preview.Width.ToString();
                lsvDisplay.SelectedItems[0].SubItems[2].Text = preview.Height.ToString();
                picPreview.Image = preview;
                picPreview.Height = Imaging.CalculateImageHeight(preview, picPreview, this.Height, MINIMUM_DATA_HEIGHT);
                UpdateComboBoxes();
                LibraryItem item = GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string);

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

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Don't need to do anything here.
            return;
            ComboBoxLocked = true;
            if (lstImages.SelectedIndices.Count > 1)
            {
                btnFindDuplicates.Enabled = true;
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
                btnFindDuplicates.Enabled = false;
                Image preview = Imaging.FromFile(lstImages.SelectedItem as string);
                GlobalVars.ImageSizeCache.AddDistinct(lstImages.SelectedItem as string, preview.Size);
                lblImageSize.Text = string.Format("Image Size: {0}x{1}px", preview.Width, preview.Height);
                picPreview.Image = preview;
                picPreview.Height = Imaging.CalculateImageHeight(preview, picPreview, this.Height, MINIMUM_DATA_HEIGHT);
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
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = Value;
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = Value;
            Library.Save();
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = "";
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = "";
            Library.Save();
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            // CONVERTED
            // Don't want to update any values when multiple are selected.
            if (lsvDisplay.SelectedItems.Count > 1)
                return;
            //if (lstImages.SelectedItems.Count > 1)
                //return;
            
            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = cmbCategory.Text;
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Category = cmbCategory.Text;
            Library.Save();
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
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = Value;
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = Value;
            Library.Save();
        }

        private void btnClearShowName_Click(object sender, EventArgs e)
        {
            cmbShowName.Text = "";
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = "";
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = "";
            Library.Save();
        }

        private void cmbShowName_SelectedValueChanged(object sender, EventArgs e)
        {
            // CONVERTED
            // Don't want to update any values when multiple are selected.
            if (lsvDisplay.SelectedItems.Count > 1)
                return;

            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = cmbShowName.Text;
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).ShowName = cmbShowName.Text;
            Library.Save();
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
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.AddDistinct(Value);
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.AddDistinct(Value);
            Library.Save();
        }

        private void btnRemoveCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex > -1)
            {
                // CONVERTED
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                lstCharacters.Items.Remove(lstCharacters.SelectedItem);
                Library.Save();
            }
        }

        private void btnClearCharacters_Click(object sender, EventArgs e)
        {
            lstCharacters.Items.Clear();
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Clear();
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Clear();
            Library.Save();
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
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Clear();
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).CharacterNames.Clear();
            Library.Save();
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex > -1)
            {
                // CONVERTED
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Remove(lstTags.SelectedItem as string);
                //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Remove(lstTags.SelectedItem as string);
                lstCharacters.Items.Remove(lstTags.SelectedItem);
                Library.Save();
            }
        }

        private void btnClearTags_Click(object sender, EventArgs e)
        {
            lstTags.Items.Clear();
            // CONVERTED
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Clear();
            //GlobalVars.LibraryItems.Find(i => i.Filename == lstImages.SelectedItem as string).Tags.Clear();
            Library.Save();
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
            const int SC_MINIMIZE = 0xF020;

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
                    if (command == SC_MINIMIZE)
                    {

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
                // CONVERTED
                List<string> Images = new List<string>();
                foreach (ListViewItem item in lsvDisplay.SelectedItems)
                {
                    Images.Add(item.Tag as string);
                }
                (Owner as MainForm).AddImages(Images);
                //string[] Images = new string[lstImages.SelectedItems.Count];
                //lstImages.SelectedItems.CopyTo(Images, 0);
                //(Owner as MainForm).AddImages(new List<string>(Images));
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
                    {
                        read.Close();
                        continue;
                    }
                    GlobalVars.LibraryItems.AddDistinct(new LibraryItem(file));
                }
            }
            Library.Save();
            UpdateList();
        }

        private void LibraryForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnRemoveFromLibrary_Click(object sender, EventArgs e)
        {
            // CONVERTED
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == item.Tag as string));
            }
            //foreach (string image in lstImages.SelectedItems)
            //{
            //    GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == image));
            //}
            UpdateList();
        }

        private void btnClearLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the whole library? This cannot be undone.", "Confirm Clear") == System.Windows.Forms.DialogResult.OK)
            {
                GlobalVars.LibraryItems = new List<LibraryItem>();
                UpdateList();
            }
        }

        private void btnFindDuplicates_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            // CONVERTED
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                items.Add(item.Tag as string);
            }
            //foreach (string item in lstImages.SelectedItems)
            //{
            //    items.Add(item);
            //}
            FindDuplicates(items);
        }

        private void btnFindAllDuplicates_Click(object sender, EventArgs e)
        {
            List<string> Images = new List<string>();
            foreach (ListViewItem item in lsvDisplay.Items)
            {
                Images.Add(item.Tag as string);
            }
            FindDuplicates(Images);
            //string[] items = new string[lstImages.Items.Count];
            //lstImages.Items.CopyTo(items, 0);
            //FindDuplicates(new List<string>(items));
        }

        private async void FindDuplicates(List<string> ImagePaths)
        {
            if (GlobalVars.DuplicateForm != null)
            {
                MessageBox.Show("Close the previous duplicate viewer first.");
                return;
            }
            if (ScanningDuplicates)
                return;
            ScanningDuplicates = true;
            lblDuplicates.Visible = ScanningDuplicates;

            List<List<string>> Duplicates = new List<List<string>>();
            await Task.Run(() => { Duplicates = XnaFan.ImageComparison.ImageTool.GetDuplicateImages(ImagePaths, 3); });
            
            ScanningDuplicates = false;
            lblDuplicates.Visible = ScanningDuplicates;

            if (Duplicates.Count == 0)
            {
                MessageBox.Show("No duplicates found.");
            }
            else
            {
                if (GlobalVars.DuplicateForm == null)
                {
                    GlobalVars.DuplicateForm = new DuplicateForm(Duplicates, this);
                    GlobalVars.DuplicateForm.Show();
                }
            }
        }

        public void ChildClosed(Form Child)
        {
            if (Child is DuplicateForm)
                GlobalVars.DuplicateForm = null;
        }

        private void lsvDisplay_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lsvSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lsvSorter.Order == SortOrder.Ascending)
                {
                    lsvSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lsvSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lsvSorter.SortColumn = e.Column;
                lsvSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lsvDisplay.Sort();
        }
    }
}
