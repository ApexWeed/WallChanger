using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using XnaFan.ImageComparison;

namespace WallChanger
{
    public partial class LibraryForm : Form
    {
        const int FILTERS_SHRUNKEN_HEIGHT = 30;
        const int FILTERS_EXPANDED_HEIGHT = 146;

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

        List<string> SizeCacheToUpdate = new List<string>();
        Queue<string> SizeCacheQueue = new Queue<string>();
        bool SizeCacheRunning = false;
        List<string> LastSizeRequest = new List<string>();

        ListViewColumnSorter lsvSorter;

        LanguageManager LM = GlobalVars.LanguageManager;
        
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

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Buttons.
            // Tooltips.
            // Filtering options.
            if (FiltersExpanded)
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY_TOOLTIP_FILTER_EXPAND"));
            else
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY_TOOLTIP_FILTER_SHRINK"));
            Tooltips.SetToolTip(btnClearFilters, LM.GetString("LIBRARY_TOOLTIP_FILTER_CLEAR"));
            Tooltips.SetToolTip(btnCategoryFilterClear, LM.GetString("LIBRARY_TOOLTIP_FILTER_CLEAR_CATEGORY"));
            Tooltips.SetToolTip(btnShowNameFilterClear, LM.GetString("LIBRARY_TOOLTIP_FILTER_CLEAR_SHOW_NAME"));
            Tooltips.SetToolTip(btnCharacterFilterClear, LM.GetString("LIBRARY_TOOLTIP_FILTER_CLEAR_CHARACTER"));
            Tooltips.SetToolTip(btnTagFilterClear, LM.GetString("LIBRARY_TOOLTIP_FILTER_CLEAR_TAG"));

            // Image options.
            Tooltips.SetToolTip(btnAddCategory, LM.GetString("LIBRARY_TOOLTIP_CATEGORY_ADD"));
            Tooltips.SetToolTip(btnClearCategory, LM.GetString("LIBRARY_TOOLTIP_CATEGORY_CLEAR"));
            Tooltips.SetToolTip(btnAddShowName, LM.GetString("LIBRARY_TOOLTIP_SHOW_NAME_ADD"));
            Tooltips.SetToolTip(btnClearShowName, LM.GetString("LIBRARY_TOOLTIP_SHOW_NAME_CLEAR"));
            Tooltips.SetToolTip(btnAddNewCharacter, LM.GetString("LIBRARY_TOOLTIP_CHARACTER_ADD"));
            Tooltips.SetToolTip(btnRemoveCharacter, LM.GetString("LIBRARY_TOOLTIP_CHARACTER_REMOVE"));
            Tooltips.SetToolTip(btnClearCharacters, LM.GetString("LIBRARY_TOOLTIP_CHARACTER_CLEAR"));
            Tooltips.SetToolTip(btnAddNewTag, LM.GetString("LIBRARY_TOOLTIP_TAG_ADD"));
            Tooltips.SetToolTip(btnRemoveTag, LM.GetString("LIBRARY_TOOLTIP_TAG_REMOVE"));
            Tooltips.SetToolTip(btnClearTags, LM.GetString("LIBRARY_TOOLTIP_TAG_CLEAR"));

            // Top functions.
            Tooltips.SetToolTip(btnAddToConfig, LM.GetString("LIBRARY_TOOLTIP_CONFIG_ADD"));
            Tooltips.SetToolTip(btnRemoveFromLibrary, LM.GetString("LIBRARY_TOOLTIP_REMOVE"));
            Tooltips.SetToolTip(btnClearLibrary, LM.GetString("LIBRARY_TOOLTIP_CLEAR"));
            Tooltips.SetToolTip(btnFindDuplicates, LM.GetString("LIBRARY_TOOLTIP_DUPLICATES_SELECTION"));
            Tooltips.SetToolTip(btnFindAllDuplicates, LM.GetString("LIBRARY_TOOLTIP_DUPLICATES"));
            Tooltips.SetToolTip(btnCacheDuplicateThumbnails, LM.GetString("LIBRARY_TOOLTIP_CACHE_GREYSCALE"));
            Tooltips.SetToolTip(btnCheckFiles, LM.GetString("LIBRARY_TOOLTIP_FILE_CHECK"));
            // Labels.
            // Filter options.
            lblFilters.Text = LM.GetString("LIBRARY_LABEL_FILTER");
            lblFilterCategory.Text = LM.GetString("LIBRARY_LABEL_FILTER_CATEGORY");
            lblFilterShowName.Text = LM.GetString("LIBRARY_LABEL_FILTER_SHOW_NAME");
            lblFilterCharacter.Text = LM.GetString("LIBRARY_LABEL_FILTER_CHARACTER");
            lblFilterTag.Text = LM.GetString("LIBRARY_LABEL_FILTER_TAG");

            // Image options.
            lblCategory.Text = LM.GetString("LIBRARY_LABEL_CATEGORY");
            lblShowName.Text = LM.GetString("LIBRARY_LABEL_SHOW_NAME");
            lblCharacters.Text = LM.GetString("LIBRARY_LABEL_CHARACTER");
            lblTags.Text = LM.GetString("LIBRARY_LABEL_TAG");

            // Columns.
            colFilename.Text = LM.GetString("LIBRARY_LABEL_COLUMN_FILENAME");
            colWidth.Text = LM.GetString("LIBRARY_LABEL_COLUMN_WIDTH");
            colHeight.Text = LM.GetString("LIBRARY_LABEL_COLUMN_HEIGHT");

            // Cascade.
            if (GlobalVars.DuplicateForm != null)
                GlobalVars.DuplicateForm.LocaliseInterface();
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalVars.DuplicateForm != null)
            {
                GlobalVars.DuplicateForm.Close();
            }

            Library.Save();

            if (Owner is MainForm)
                (Owner as MainForm).ChildClosed(this);
        }

        public void UpdateList()
        {
            lsvDisplay.Items.Clear();
            List<ListViewItem> itemsToAdd = new List<ListViewItem>();
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

                ListViewItem item = new ListViewItem(new string[] { string.Concat(Path.GetDirectoryName(libraryItem.Filename).Split('\\').Reverse().ToArray()[0], "\\", Path.GetFileNameWithoutExtension(libraryItem.Filename)), ImageSize.Width.ToString(), ImageSize.Height.ToString() });
                item.Tag = libraryItem.Filename;
                itemsToAdd.Add(item);
                
                Categories.AddDistinct(libraryItem.Category);
                ShowNames.AddDistinct(libraryItem.ShowName);
                Characters.AddDistinct(libraryItem.CharacterNames);
                Tags.AddDistinct(libraryItem.Tags);

                FilterCategories.AddDistinct(libraryItem.Category);
                FilterShowNames.AddDistinct(libraryItem.ShowName);
                FilterCharacters.AddDistinct(libraryItem.CharacterNames);
                FilterTags.AddDistinct(libraryItem.Tags);
            }

            lsvDisplay.Items.AddRange(itemsToAdd.ToArray());

            if (lsvDisplay.Items.Count > 0)
                lsvDisplay.Items[0].Selected = true;

            tslStatistics.Text = string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_STATS", "LIBRARY_MESSAGE_STATS: {0}/{1} {2}"), lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
            
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
            btnCacheDuplicateThumbnails.Left = pnlFilters.Width - 177;
            btnCheckFiles.Left = pnlFilters.Width - 207;

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
                SizeCacheRunning = true;
                while (SizeCacheQueue.Count > 0)
                {
                    string image = SizeCacheQueue.Dequeue();
                    // Get the image size if it is not already cached.
                    if (!GlobalVars.ImageSizeCache.ContainsKey(image))
                    {
                        Size size = new Size();
                        await Task.Run(() =>
                        {

                            try
                            {
                                size = Imaging.GetDimensions(image);
                            }
                            catch (ArgumentException ex)
                            {
                                using (Image img = Image.FromFile(image))
                                {
                                    size = img.Size;
                                }
                            }
                            GlobalVars.ImageSizeCache.AddDistinct(image, size);
                        });

                        SizeCacheToUpdate.Add(image);
                    }

                    tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_SIZE_CALCULATE", "LIBRARY_MESSAGE_SIZE_CALCULATE ({0})"), SizeCacheQueue.Count);
                }

                if (SizeCacheToUpdate.Count > 50)
                {
                    SizeCacheToUpdate.Clear();
                    UpdateList();
                }
                else
                {
                    lsvDisplay.BeginUpdate();
                    foreach (string image in SizeCacheToUpdate)
                    {
                        ListViewItem item = lsvDisplay.Items.FindByTag(image);
                        item.SubItems[1].Text = GlobalVars.ImageSizeCache[image].Width.ToString();
                        item.SubItems[2].Text = GlobalVars.ImageSizeCache[image].Height.ToString();
                    }
                    SizeCacheToUpdate.Clear();
                    lsvDisplay.EndUpdate();
                }

                foreach (string image in LastSizeRequest)
                {
                    if (GlobalVars.ImageSizeCache[image].Width < minWidth)
                        minWidth = GlobalVars.ImageSizeCache[image].Width;
                    if (GlobalVars.ImageSizeCache[image].Width > maxWidth)
                        maxWidth = GlobalVars.ImageSizeCache[image].Width;

                    if (GlobalVars.ImageSizeCache[image].Height < minHeight)
                        minHeight = GlobalVars.ImageSizeCache[image].Height;
                    if (GlobalVars.ImageSizeCache[image].Height > maxHeight)
                        maxHeight = GlobalVars.ImageSizeCache[image].Height;
                    lblImageSize.Text = string.Format(LM.GetStringDefault("LIBRARY_LABEL_IMAGE_SIZES", "LIBRARY_LABEL_IMAGE_SIZES: {0}-{1}x{2}-{3}px"), minWidth, maxWidth, minHeight, maxHeight);
                }
                LastSizeRequest.Clear();
                tslStatus.Text = "Ready";
                tslStatistics.Text = string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_STATS", "LIBRARY_MESSAGE_STATS: {0}/{1} {2}"), lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
                SizeCacheRunning = false;
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

                LoadImageSizes(true);

                cmbCategory.Text = "";
                cmbShowName.Text = "";
                lstCharacters.Items.Clear();
                lstTags.Items.Clear();
                picPreview.Image = Properties.Resources.Blank;
            }
            else if (lsvDisplay.SelectedIndices.Count == 1)
            {
                btnFindDuplicates.Enabled = false;
                Image preview = new Bitmap(1, 1);

                preview = Imaging.FromFile(lsvDisplay.SelectedItems[0].Tag as string);
                lsvDisplay.SelectedItems[0].SubItems[1].Text = preview.Width.ToString();
                lsvDisplay.SelectedItems[0].SubItems[2].Text = preview.Height.ToString();
                GlobalVars.ImageSizeCache.AddDistinct(lsvDisplay.SelectedItems[0].Tag as string, preview.Size);

                lblImageSize.Text = string.Format(LM.GetStringDefault("LIBRARY_LABEL_IMAGE_SIZE", "LIBRARY_LABEL_IMAGE_SIZE: {0}x{1}px"), preview.Width, preview.Height);
                picPreview.Image = preview;
                picPreview.Height = Imaging.CalculateImageHeight(preview, picPreview, this.Height, MINIMUM_DATA_HEIGHT);
                UpdateComboBoxes();
                LibraryItem item = new LibraryItem();
                item = GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string);

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
            string Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY_MESSAGE_NEW_CATEGORY"), LM.GetString("LIBRARY_MESSAGE_NEW_CATEGORY_TITLE"), Categories.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Categories.AddDistinct(Value);
            FilterCategories.AddDistinct(Value);
            UpdateComboBoxes();
            cmbCategory.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = Value;
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = "";
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want to update any values when multiple are selected.
            if (lsvDisplay.SelectedItems.Count > 1)
                return;
            
            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = cmbCategory.Text;
        }
        #endregion

        #region "Show Name"
        private void btnAddShowName_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY_MESSAGE_NEW_SHOW_NAME"), LM.GetString("LIBRARY_MESSAGE_NEW_SHOW_NAME_TITLE"), ShowNames.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            ShowNames.AddDistinct(Value);
            FilterShowNames.AddDistinct(Value);
            UpdateComboBoxes();
            cmbShowName.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = Value;
        }

        private void btnClearShowName_Click(object sender, EventArgs e)
        {
            cmbShowName.Text = "";

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = "";
        }

        private void cmbShowName_SelectedValueChanged(object sender, EventArgs e)
        {
            // Don't want to update any values when multiple are selected.
            if (lsvDisplay.SelectedItems.Count > 1)
                return;

            // Don't want the values changing when swapping between entries.
            if (ComboBoxLocked)
                return;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = cmbShowName.Text;
        }
        #endregion

        #region "Character"
        private void btnAddNewCharacter_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY_MESSAGE_NEW_CHARACTER"), LM.GetString("LIBRARY_MESSAGE_NEW_CHARACTER_TITLE"), Characters.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Characters.AddDistinct(Value);
            FilterCharacters.AddDistinct(Value);
            lstCharacters.Items.Add(Value);
            lstCharacters.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.AddDistinct(Value);
        }

        private void btnRemoveCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                lstCharacters.Items.Remove(lstCharacters.SelectedItem);
            }
        }

        private void btnClearCharacters_Click(object sender, EventArgs e)
        {
            lstCharacters.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Clear();
        }
        #endregion

        #region "Tags"
        private void btnAddNewTag_Click(object sender, EventArgs e)
        {
            string Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY_MESSAGE_NEW_TAG"), LM.GetString("LIBRARY_MESSAGE_NEW_TAG_TITLE"), Tags.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Tags.AddDistinct(Value);
            FilterTags.AddDistinct(Value);
            lstTags.Items.Add(Value);
            lstTags.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.AddDistinct(Value);
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Remove(lstTags.SelectedItem as string);
                lstCharacters.Items.Remove(lstTags.SelectedItem);
            }
        }

        private void btnClearTags_Click(object sender, EventArgs e)
        {
            lstTags.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Clear();
        }
        #endregion

        private void btnExpand_Click(object sender, EventArgs e)
        {
            FiltersExpanded = !FiltersExpanded;
            if (FiltersExpanded)
            {
                btnExpand.Image = Properties.Resources.toggle;
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY_TOOLTIP_FILTER_SHRINK"));
                pnlFilters.Height = FILTERS_EXPANDED_HEIGHT;
            }
            else
            {
                btnExpand.Image = Properties.Resources.toggle_expand;
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY_TOOLTIP_FILTER_EXPAND"));
                pnlFilters.Height = FILTERS_SHRUNKEN_HEIGHT;
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
                List<string> Images = new List<string>();
                foreach (ListViewItem item in lsvDisplay.SelectedItems)
                {
                    Images.Add(item.Tag as string);
                }
                (Owner as MainForm).AddImages(Images);
            }

        }

        private void LibraryForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    LoadFolder(file);
                }
                else
                {
                    LoadFile(file);
                }
            }
            UpdateList();
        }

        private void LoadFolder(string Folder)
        {
            foreach (string directory in Directory.GetDirectories(Folder))
            {
                LoadFolder(directory);
            }
            foreach (string file in Directory.GetFiles(Folder))
            {
                LoadFile(file);
            }
        }

        private void LoadFile(string FileName)
        {
            using (Stream read = File.Open(FileName, FileMode.Open))
            {
                if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                {
                    using (StreamWriter write = File.AppendText("debuglog.log"))
                    {
                        write.WriteLine(FileName);
                    }
                    read.Close();
                    return;
                }
                GlobalVars.LibraryItems.AddDistinct(new LibraryItem(FileName));
            }
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
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == item.Tag as string));
            }
            UpdateList();
        }

        private void btnClearLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LM.GetString("LIBRARY_MESSAGE_CLEAR"), LM.GetString("LIBRARY_MESSAGE_CLEAR_TITLE")) == DialogResult.OK)
            {
                GlobalVars.LibraryItems = new List<LibraryItem>();
                UpdateList();
            }
        }

        private void btnFindDuplicates_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                items.Add(item.Tag as string);
            }
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
        }

        private void btnCacheDuplicateThumbnails_Click(object sender, EventArgs e)
        {
            List<string> Images = new List<string>();
            foreach (ListViewItem item in lsvDisplay.Items)
            {
                Images.Add(item.Tag as string);
            }
            CacheDuplicateThumbnails(Images);
            tslStatus.Text = LM.GetString("LIBRARY_MESSAGE_READY");
        }

        private void btnCheckFiles_Click(object sender, EventArgs e)
        {
            CheckFilesExist();

            UpdateList();
        }

        private async void CheckFilesExist()
        {
            List<string> LibraryFilenames = new List<string>();

            foreach (var Item in GlobalVars.LibraryItems)
            {
                LibraryFilenames.Add(Item.Filename);
            }

            List<string> Directories = await Task.Run(() => GetUniqueDirectories(LibraryFilenames));

            List<string> DiskFilenames = await Task.Run(() => GetFiles(Directories));

            int MissingCount = 0;

            foreach (string ImagePath in LibraryFilenames)
            {
                if (await Task.Run(() => !DiskFilenames.Contains(ImagePath)))
                {
                    MissingCount++;
                    GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(x => x.Filename == ImagePath));
                }
            }

            MessageBox.Show(string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_MISSING", "{0} LIBRARY_MESSAGE_MISSING"), MissingCount));
        }

        private List<string> GetUniqueDirectories(IEnumerable<string> Files)
        {
            List<string> DirectoryNames = new List<string>();

            foreach (string File in Files)
            {
                DirectoryNames.AddDistinct(Path.GetDirectoryName(File));
            }

            return DirectoryNames;
        }

        private List<string> GetFiles(IEnumerable<string> Directories, bool Recursive = false)
        {
            List<string> FileList = new List<string>();

            foreach (string Directory in Directories)
            {
                FileList.AddRange(GetFiles(Directory, Recursive));
            }

            return FileList;
        }

        private List<string> GetFiles(string Directory, bool Recursive = false)
        {
            List<string> FileList = new List<string>();

            var Files = System.IO.Directory.GetFiles(Directory);

            FileList.AddRange(Files);

            if (Recursive)
            {
                foreach (string SubDirectory in System.IO.Directory.GetDirectories(Directory))
                {
                    FileList.AddRange(System.IO.Directory.GetFiles(SubDirectory));
                }
            }

            return FileList;
        }

        private async void FindDuplicates(List<string> ImagePaths)
        {
            if (GlobalVars.DuplicateForm != null)
            {
                MessageBox.Show(LM.GetString("LIBRARY_MESSAGE_CLOSE_DUPLICATES"));
                return;
            }
            if (ScanningDuplicates)
                return;
            ScanningDuplicates = true;

            List<List<string>> Duplicates = new List<List<string>>();
            Duplicates = await ImageTool.GetDuplicateImagesMultithreadedCache(ImagePaths, 3, GlobalVars.ImageCache, new Progress<Tuple<int, int>>(UpdateDuplicateScanProgress));
            
            ScanningDuplicates = false;

            tslStatus.Text = LM.GetString("LIBRARY_MESSAGE_READY");

            if (Duplicates.Count == 0)
            {
                MessageBox.Show(LM.GetString("LIBRARY_MESSAGE_NO_DUPLICATES"));
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

        public void UpdateDuplicateScanProgress(Tuple<int, int> Progress)
        {
            tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_SCANNING_DUPLICATES", "LIBRARY_MESSAGE_SCANNING_DUPLICATES ({0}/{1})"), Progress.Item1, Progress.Item2);
            tspProgressBar.Value = (int)(((float)Progress.Item1 / Progress.Item2) * 100);
        }

        private async void CacheDuplicateThumbnails(List<string> ImagePaths)
        {
            tslStatus.Text = LM.GetString("LIBRARY_MESSAGE_GENERATING_THUMBNAILS");
            for (int i = 0; i < ImagePaths.Count; i++)
            {
                if (!GlobalVars.ImageCache.ContainsKey(ImagePaths[i]))
                {
                    await Task.Run(() =>
                    {
                        Image image = Image.FromFile(ImagePaths[i]);
                        GlobalVars.ImageCache.Add(ImagePaths[i], image.GetGrayScaleValues());
                        image.Dispose();
                    });
                }
                tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY_MESSAGE_GENERATING_THUMBNAILS_STATUS", "LIBRARY_GENERATING_THUMBNAILS_STATUS ({0}/{1})"), i + 1, ImagePaths.Count);
                tspProgressBar.Value = (int)(((float)(i + 1) / ImagePaths.Count) * 100);
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
