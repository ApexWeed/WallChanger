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
        const int FILTERS_EXPANDED_HEIGHT = 146;
        const int FILTERS_SHRUNKEN_HEIGHT = 30;

        readonly List<string> Categories;
        readonly List<string> Characters;

        bool ComboBoxLocked;

        readonly List<string> FilterCategories;
        readonly List<string> FilterCharacters;
        bool FiltersExpanded;
        readonly List<string> FilterShowNames;
        readonly List<string> FilterTags;
        List<string> LastSizeRequest = new List<string>();

        readonly LanguageManager LM = GlobalVars.LanguageManager;

        readonly ListViewColumnSorter lsvSorter;

        readonly int MINIMUM_DATA_HEIGHT;
        bool ScanningDuplicates;
        readonly List<string> ShowNames;
        readonly Queue<string> SizeCacheQueue = new Queue<string>();
        bool SizeCacheRunning;

        readonly List<string> SizeCacheToUpdate = new List<string>();
        readonly List<string> Tags;

        /// <summary>
        /// Initialises a new instance of the library form.
        /// </summary>
        /// <param name="Owner">The form that owns this form.</param>
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
        /// Delegate to allow cross thread listview item retrieval.
        /// </summary>
        /// <param name="listView">The list view to retrieve items from.</param>
        /// <returns>A delegate of some kind. This is magic.</returns>
        private delegate ListView.ListViewItemCollection GetItems(ListView listView);

        /// <summary>
        /// Allows child forms to be opened.
        /// </summary>
        /// <param name="Child">The child that has closed.</param>
        public static void ChildClosed(Form Child)
        {
            if (Child is DuplicateForm)
                GlobalVars.DuplicateForm = null;
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE.LIBRARY");
            // Buttons.
            // Tooltips.
            // Filtering options.
            if (FiltersExpanded)
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY.TOOLTIP.FILTER.EXPAND"));
            else
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY.TOOLTIP.FILTER.SHRINK"));
            Tooltips.SetToolTip(btnClearFilters, LM.GetString("LIBRARY.TOOLTIP.FILTER.CLEAR"));
            Tooltips.SetToolTip(btnCategoryFilterClear, LM.GetString("LIBRARY.TOOLTIP.FILTER.CLEAR_CATEGORY"));
            Tooltips.SetToolTip(btnShowNameFilterClear, LM.GetString("LIBRARY.TOOLTIP.FILTER.CLEAR_SHOW_NAME"));
            Tooltips.SetToolTip(btnCharacterFilterClear, LM.GetString("LIBRARY.TOOLTIP.FILTER.CLEAR_CHARACTER"));
            Tooltips.SetToolTip(btnTagFilterClear, LM.GetString("LIBRARY.TOOLTIP.FILTER.CLEAR_TAG"));

            // Image options.
            Tooltips.SetToolTip(btnAddCategory, LM.GetString("LIBRARY.TOOLTIP.CATEGORY.ADD"));
            Tooltips.SetToolTip(btnClearCategory, LM.GetString("LIBRARY.TOOLTIP.CATEGORY.CLEAR"));
            Tooltips.SetToolTip(btnAddShowName, LM.GetString("LIBRARY.TOOLTIP.SHOWNAME.ADD"));
            Tooltips.SetToolTip(btnClearShowName, LM.GetString("LIBRARY.TOOLTIP.SHOWNAME.CLEAR"));
            Tooltips.SetToolTip(btnAddNewCharacter, LM.GetString("LIBRARY.TOOLTIP.CHARACTER.ADD"));
            Tooltips.SetToolTip(btnRemoveCharacter, LM.GetString("LIBRARY.TOOLTIP.CHARACTER.REMOVE"));
            Tooltips.SetToolTip(btnClearCharacters, LM.GetString("LIBRARY.TOOLTIP.CHARACTER.CLEAR"));
            Tooltips.SetToolTip(btnAddNewTag, LM.GetString("LIBRARY.TOOLTIP.TAG.ADD"));
            Tooltips.SetToolTip(btnRemoveTag, LM.GetString("LIBRARY.TOOLTIP.TAG.REMOVE"));
            Tooltips.SetToolTip(btnClearTags, LM.GetString("LIBRARY.TOOLTIP.TAG.CLEAR"));

            // Top functions.
            Tooltips.SetToolTip(btnAddToConfig, LM.GetString("LIBRARY.TOOLTIP.CONFIG_ADD"));
            Tooltips.SetToolTip(btnRemoveFromLibrary, LM.GetString("LIBRARY.TOOLTIP.REMOVE"));
            Tooltips.SetToolTip(btnClearLibrary, LM.GetString("LIBRARY.TOOLTIP.CLEAR"));
            Tooltips.SetToolTip(btnFindDuplicates, LM.GetString("LIBRARY.TOOLTIP.DUPLICATES_SELECTION"));
            Tooltips.SetToolTip(btnFindAllDuplicates, LM.GetString("LIBRARY.TOOLTIP.DUPLICATES"));
            Tooltips.SetToolTip(btnCacheDuplicateThumbnails, LM.GetString("LIBRARY.TOOLTIP.CACHE_GREYSCALE"));
            Tooltips.SetToolTip(btnCheckFiles, LM.GetString("LIBRARY.TOOLTIP.FILE_CHECK"));
            // Labels.
            // Filter options.
            lblFilters.Text = LM.GetString("LIBRARY.LABEL.FILTER");
            // Move buttons so they don't overlap filter text.
            btnExpand.Left = lblFilters.Left + TextRenderer.MeasureText(lblFilters.Text, lblFilters.Font).Width + 6;
            btnClearFilters.Left = btnExpand.Left + btnExpand.Width + 6;
            lblFilterCategory.Text = LM.GetString("LIBRARY.LABEL.FILTER.CATEGORY");
            lblFilterShowName.Text = LM.GetString("LIBRARY.LABEL.FILTER.SHOW_NAME");
            lblFilterCharacter.Text = LM.GetString("LIBRARY.LABEL.FILTER.CHARACTER");
            lblFilterTag.Text = LM.GetString("LIBRARY.LABEL.FILTER.TAG");

            // Image options.
            lblCategory.Text = LM.GetString("LIBRARY.LABEL.CATEGORY");
            lblShowName.Text = LM.GetString("LIBRARY.LABEL.SHOW_NAME");
            lblCharacters.Text = LM.GetString("LIBRARY.LABEL.CHARACTER");
            lblTags.Text = LM.GetString("LIBRARY.LABEL.TAG");

            // Columns.
            colFilename.Text = LM.GetString("LIBRARY.LABEL.COLUMN.FILENAME");
            colWidth.Text = LM.GetString("LIBRARY.LABEL.COLUMN.WIDTH");
            colHeight.Text = LM.GetString("LIBRARY.LABEL.COLUMN.HEIGHT");

            // Cascade.
            if (GlobalVars.DuplicateForm != null)
                GlobalVars.DuplicateForm.LocaliseInterface();
        }

        /// <summary>
        /// Updates the progress of the duplicate scan.
        /// </summary>
        /// <param name="Progress"></param>
        public void UpdateDuplicateScanProgress(Tuple<int, int> Progress)
        {
            tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.SCANNING_DUPLICATES", "LIBRARY.MESSAGE.SCANNING_DUPLICATES ({0}/{1})"), Progress.Item1, Progress.Item2);
            tspProgressBar.Value = (int)(((float)Progress.Item1 / Progress.Item2) * 100);
        }

        /// <summary>
        /// Updates the list of images with the current filters.
        /// </summary>
        public void UpdateList()
        {
            lsvDisplay.Items.Clear();
            var itemsToAdd = new List<ListViewItem>();
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
                var ImageSize = new Size(0, 0);
                if (GlobalVars.ImageSizeCache.ContainsKey(libraryItem.Filename))
                    ImageSize = GlobalVars.ImageSizeCache[libraryItem.Filename];
                else
                    SizeCacheQueue.Enqueue(libraryItem.Filename);

                var item = new ListViewItem(new string[] { string.Concat(Path.GetDirectoryName(libraryItem.Filename).Split('\\').Reverse().ToArray()[0], "\\", Path.GetFileNameWithoutExtension(libraryItem.Filename)), ImageSize.Width.ToString(), ImageSize.Height.ToString() })
                {
                    Tag = libraryItem.Filename
                };
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

            tslStatistics.Text = string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.STATS", "LIBRARY.MESSAGE.STATS: {0}/{1} {2}"), lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);

            LoadImageSizesAsync(false);
        }

        /// <summary>
        /// Handle windows messages.
        /// </summary>
        /// <param name="message">The message to handle.</param>
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;
            const int SC_MINIMIZE = 0xF020;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    var command = message.WParam.ToInt32() & 0xfff0;
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

        /// <summary>
        /// Gets a list of files in the specified directories.
        /// </summary>
        /// <param name="Directories">The enumerable list of directories.</param>
        /// <param name="Recursive">Whether or not to search sub directories.</param>
        /// <returns>A list of files in all directories.</returns>
        private static List<string> GetFiles(IEnumerable<string> Directories, bool Recursive = false)
        {
            var FileList = new List<string>();

            foreach (string Directory in Directories)
            {
                FileList.AddRange(GetFiles(Directory, Recursive));
            }

            return FileList;
        }

        /// <summary>
        /// Gets a list of files in the specified directory.
        /// </summary>
        /// <param name="Directory">The directory to scan.</param>
        /// <param name="Recursive">Whether or not to recursively scan directories.</param>
        /// <returns>A list of files in the specified directory.</returns>
        private static List<string> GetFiles(string Directory, bool Recursive = false)
        {
            var FileList = new List<string>();

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

        /// <summary>
        /// Gets a list of unique directory from a file list.
        /// </summary>
        /// <param name="Files">List of filenames.</param>
        /// <returns>List of unique directory names.</returns>
        private static List<string> GetUniqueDirectories(IEnumerable<string> Files)
        {
            var DirectoryNames = new List<string>();

            foreach (string File in Files)
            {
                DirectoryNames.AddDistinct(Path.GetDirectoryName(File));
            }

            return DirectoryNames;
        }

        /// <summary>
        /// Loads the file into the library.
        /// </summary>
        /// <param name="FileName">The file to add.</param>
        private static void LoadFile(string FileName)
        {
            using (Stream read = File.Open(FileName, FileMode.Open))
            {
                if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                {
                    using (StreamWriter write = File.AppendText("unknownFiles.log"))
                    {
                        write.WriteLine(FileName);
                    }
                    read.Close();
                    return;
                }
                GlobalVars.LibraryItems.AddDistinct(new LibraryItem(FileName));
            }
        }

        /// <summary>
        /// Adds a category to the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY.MESSAGE.NEW_CATEGORY"), LM.GetString("LIBRARY.MESSAGE.NEW_CATEGORY_TITLE"), Categories.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Categories.AddDistinct(Value);
            FilterCategories.AddDistinct(Value);
            UpdateComboBoxes();
            cmbCategory.SelectedItem = Value;
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = Value;
        }

        /// <summary>
        /// Adds a character name to the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddNewCharacter_Click(object sender, EventArgs e)
        {
            var Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY.MESSAGE.NEW_CHARACTER"), LM.GetString("LIBRARY.MESSAGE.NEW_CHARACTER_TITLE"), Characters.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Characters.AddDistinct(Value);
            FilterCharacters.AddDistinct(Value);
            lstCharacters.Items.Add(Value);
            lstCharacters.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.AddDistinct(Value);
        }

        /// <summary>
        /// Adds a tag to the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddNewTag_Click(object sender, EventArgs e)
        {
            var Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY.MESSAGE.NEW_TAG"), LM.GetString("LIBRARY.MESSAGE.NEW_TAG_TITLE"), Tags.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            Tags.AddDistinct(Value);
            FilterTags.AddDistinct(Value);
            lstTags.Items.Add(Value);
            lstTags.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.AddDistinct(Value);
        }

        /// <summary>
        /// Adds a show name to the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddShowName_Click(object sender, EventArgs e)
        {
            var Value = Prompt.ShowStringComboBoxDialog(LM.GetString("LIBRARY.MESSAGE.NEW_SHOW_NAME"), LM.GetString("LIBRARY.MESSAGE.NEW_SHOW_NAME_TITLE"), ShowNames.ToArray());
            if (string.IsNullOrWhiteSpace(Value))
                return;

            ShowNames.AddDistinct(Value);
            FilterShowNames.AddDistinct(Value);
            UpdateComboBoxes();
            cmbShowName.SelectedItem = Value;

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = Value;
        }

        /// <summary>
        /// Adds the selected images to the current config.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddToConfig_Click(object sender, EventArgs e)
        {
            if (Owner is MainForm)
            {
                var Images = new List<string>();
                foreach (ListViewItem item in lsvDisplay.SelectedItems)
                {
                    Images.Add(item.Tag as string);
                }
                (Owner as MainForm).AddImages(Images);
            }

        }

        /// <summary>
        /// Caches thumbnails.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnCacheDuplicateThumbnails_Click(object sender, EventArgs e)
        {
            var Images = new List<string>();
            foreach (ListViewItem item in lsvDisplay.Items)
            {
                Images.Add(item.Tag as string);
            }
            CacheDuplicateThumbnailsAsync(Images);
            tslStatus.Text = LM.GetString("LIBRARY.MESSAGE.READY");
        }

        /// <summary>
        /// CLears the category filter.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnCategoryFilterClear_Click(object sender, EventArgs e)
        {
            cmbCategoryFilter.Text = "";
            UpdateList();
        }

        /// <summary>
        /// Clears the character name filter.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnCharacterFilterClear_Click(object sender, EventArgs e)
        {
            cmbCharacterFilter.Text = "";
            UpdateList();
        }

        /// <summary>
        /// Removes deleted images from the library.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnCheckFiles_Click(object sender, EventArgs e)
        {
            CheckFilesExistAsync();

            UpdateList();
        }

        /// <summary>
        /// Clears the category on the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Category = "";
        }

        /// <summary>
        /// CLears the character names from the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearCharacters_Click(object sender, EventArgs e)
        {
            lstCharacters.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Clear();
        }

        /// <summary>
        /// Clears all filters.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbCategoryFilter.Text = "";
            cmbShowNameFilter.Text = "";
            cmbCharacterFilter.Text = "";
            cmbTagFilter.Text = "";
            UpdateList();
        }

        /// <summary>
        /// Clears the library.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearLibrary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LM.GetString("LIBRARY.MESSAGE.CLEAR"), LM.GetString("LIBRARY.MESSAGE.CLEAR_TITLE")) == DialogResult.OK)
            {
                GlobalVars.LibraryItems = new List<LibraryItem>();
                UpdateList();
            }
        }

        /// <summary>
        /// Clears the showname on the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearShowName_Click(object sender, EventArgs e)
        {
            cmbShowName.Text = "";

            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).ShowName = "";
        }

        /// <summary>
        /// Clears the tags on the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClearTags_Click(object sender, EventArgs e)
        {
            lstTags.Items.Clear();
            GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Clear();
        }

        /// <summary>
        /// Toggles whether the filtering options are expanded.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            FiltersExpanded = !FiltersExpanded;
            if (FiltersExpanded)
            {
                btnExpand.Image = Properties.Resources.toggle;
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY.TOOLTIP.FILTER.SHRINK"));
                pnlFilters.Height = FILTERS_EXPANDED_HEIGHT;
            }
            else
            {
                btnExpand.Image = Properties.Resources.toggle_expand;
                Tooltips.SetToolTip(btnExpand, LM.GetString("LIBRARY.TOOLTIP.FILTER.EXPAND"));
                pnlFilters.Height = FILTERS_SHRUNKEN_HEIGHT;
            }
        }

        /// <summary>
        /// Finds duplicates in the filtered list.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnFindAllDuplicates_Click(object sender, EventArgs e)
        {
            var Images = new List<string>();
            foreach (ListViewItem item in lsvDisplay.Items)
            {
                Images.Add(item.Tag as string);
            }
            FindDuplicatesAsync(Images);
        }

        /// <summary>
        /// Finds duplicates in the selection.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnFindDuplicates_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                items.Add(item.Tag as string);
            }
            FindDuplicatesAsync(items);
        }

        /// <summary>
        /// Removes the selected character name from the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemoveCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacters.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).CharacterNames.Remove(lstCharacters.SelectedItem as string);
                lstCharacters.Items.Remove(lstCharacters.SelectedItem);
            }
        }

        /// <summary>
        /// Removes the selected items from the library.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemoveFromLibrary_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lsvDisplay.SelectedItems)
            {
                GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(i => i.Filename == item.Tag as string));
            }
            UpdateList();
        }

        /// <summary>
        /// Removes the selected tag from the image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            if (lstTags.SelectedIndex > -1)
            {
                GlobalVars.LibraryItems.Find(i => i.Filename == lsvDisplay.SelectedItems[0].Tag as string).Tags.Remove(lstTags.SelectedItem as string);
                lstCharacters.Items.Remove(lstTags.SelectedItem);
            }
        }

        /// <summary>
        /// Clears the showname filter.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnShowNameFilterClear_Click(object sender, EventArgs e)
        {
            cmbShowNameFilter.Text = "";
            UpdateList();
        }

        /// <summary>
        /// Clears the tag filter.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnTagFilterClear_Click(object sender, EventArgs e)
        {
            cmbTagFilter.Text = "";
            UpdateList();
        }

        /// <summary>
        /// Caches the thumbnails of the specified images.
        /// </summary>
        /// <param name="ImagePaths"></param>
        private async void CacheDuplicateThumbnailsAsync(List<string> ImagePaths)
        {
            tslStatus.Text = LM.GetString("LIBRARY.MESSAGE.GENERATING_THUMBNAILS");
            for (int i = 0; i < ImagePaths.Count; i++)
            {
                if (!GlobalVars.ImageCache.ContainsKey(ImagePaths[i]))
                {
                    await Task.Run(() =>
                    {
                        var image = Image.FromFile(ImagePaths[i]);
                        GlobalVars.ImageCache.Add(ImagePaths[i], image.GetGrayScaleValues());
                        image.Dispose();
                    });
                }
                tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.GENERATING_THUMBNAILS_STATUS", "LIBRARY_GENERATING_THUMBNAILS_STATUS ({0}/{1})"), i + 1, ImagePaths.Count);
                tspProgressBar.Value = (int)(((float)(i + 1) / ImagePaths.Count) * 100);
            }
        }

        /// <summary>
        /// Checks if the library files exist on disk.
        /// </summary>
        private async void CheckFilesExistAsync()
        {
            var LibraryFilenames = new List<string>();

            foreach (var Item in GlobalVars.LibraryItems)
            {
                LibraryFilenames.Add(Item.Filename);
            }

            var Directories = await Task.Run(() => GetUniqueDirectories(LibraryFilenames));

            var DiskFilenames = await Task.Run(() => GetFiles(Directories));

            var MissingCount = 0;

            foreach (string ImagePath in LibraryFilenames)
            {
                if (await Task.Run(() => !DiskFilenames.Contains(ImagePath)))
                {
                    MissingCount++;
                    GlobalVars.LibraryItems.Remove(GlobalVars.LibraryItems.Find(x => x.Filename == ImagePath));
                }
            }

            MessageBox.Show(string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.MISSING", "{0} LIBRARY.MESSAGE.MISSING"), MissingCount));
        }

        /// <summary>
        /// Updates the image's category to the selected category.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
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

        /// <summary>
        /// Updates the image's showname to the selected showname.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
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

        /// <summary>
        /// Updates the list when the filters are changed.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void FilterChoiceChanged(object sender, EventArgs e)
        {
            // Don't update the list if we are already updating it.
            if (ComboBoxLocked)
                return;
            UpdateList();
        }

        /// <summary>
        /// Finds duplicate images in the specified list.
        /// </summary>
        /// <param name="ImagePaths">An enumerable list of image paths to check.</param>
        private async void FindDuplicatesAsync(IEnumerable<string> ImagePaths)
        {
            if (GlobalVars.DuplicateForm != null)
            {
                MessageBox.Show(LM.GetString("LIBRARY.MESSAGE.CLOSE_DUPLICATES"));
                return;
            }
            if (ScanningDuplicates)
                return;
            ScanningDuplicates = true;

            var Duplicates = new List<List<string>>();
            Duplicates = await ImageTool.GetDuplicateImagesMultithreadedCacheAsync(ImagePaths, 3, GlobalVars.ImageCache, new Progress<Tuple<int, int>>(UpdateDuplicateScanProgress));

            ScanningDuplicates = false;

            tslStatus.Text = LM.GetString("LIBRARY.MESSAGE.READY");

            if (Duplicates.Count == 0)
            {
                MessageBox.Show(LM.GetString("LIBRARY.MESSAGE.NO_DUPLICATES"));
            }
            else
            {
                if (GlobalVars.DuplicateForm == null)
                {
                    GlobalVars.DuplicateForm = new DuplicateForm(Duplicates, this);
                    GlobalVars.DuplicateForm.Show();
                }
                else
                {
                    GlobalVars.DuplicateForm.BringToFront();
                }
            }
        }
        /// <summary>
        /// Gets the items in a listview, using a delegate if required.
        /// </summary>
        /// <param name="listView">The listview to retrieve items from.</param>
        /// <returns>A ListViewItemCollection containing all items in the listview.</returns>
        private ListView.ListViewItemCollection GetListViewItems(ListView listView)
        {
#pragma warning disable CC0022 // Should dispose object
            var temp = new ListView.ListViewItemCollection(new ListView());
#pragma warning restore CC0022 // Should dispose object
            if (!listView.InvokeRequired)
            {
                foreach (ListViewItem item in listView.Items)
                    temp.Add(item);
                return temp;
            }
            else
                return (ListView.ListViewItemCollection)this.Invoke(new GetItems(GetListViewItems), new object[] { listView });
        }

        /// <summary>
        /// Adds the file drop to the library if they are images..
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void LibraryForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
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

#pragma warning disable CC0091 // Use static method
        /// <summary>
        /// Updates the cursor when the user drags files onto the window.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void LibraryForm_DragEnter(object sender, DragEventArgs e)
#pragma warning restore CC0091 // Use static method
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Saves the library and notifies the parent of closure.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
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

        /// <summary>
        /// Loads the folder and it's subfolders into the library.
        /// </summary>
        /// <param name="Folder">The folder to load.</param>
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

        /// <summary>
        /// Loads the sizes of the images asynchronously.
        /// </summary>
        /// <param name="skipChanges">Whether or not to skip the last update request.</param>
        private async void LoadImageSizesAsync(bool skipChanges = false)
        {
            var minWidth = int.MaxValue;
            var minHeight = int.MaxValue;
            var maxWidth = int.MinValue;
            var maxHeight = int.MinValue;

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
                    var image = SizeCacheQueue.Dequeue();
                    // Get the image size if it is not already cached.
                    if (!GlobalVars.ImageSizeCache.ContainsKey(image))
                    {
                        var size = new Size();
                        await Task.Run(() =>
                        {

                            try
                            {
                                size = Imaging.GetDimensions(image);
                            }
                            catch (ArgumentException)
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

                    tslStatus.Text = string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.SIZE_CALCULATE", "LIBRARY.MESSAGE.SIZE_CALCULATE ({0})"), SizeCacheQueue.Count);
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
                        var item = lsvDisplay.Items.FindByTag(image);
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
                    lblImageSize.Text = string.Format(LM.GetStringDefault("LIBRARY.LABEL.IMAGE_SIZES", "LIBRARY.LABEL.IMAGE_SIZES: {0}-{1}x{2}-{3}px"), minWidth, maxWidth, minHeight, maxHeight);
                }
                LastSizeRequest.Clear();
                tslStatus.Text = "Ready";
                tslStatistics.Text = string.Format(LM.GetStringDefault("LIBRARY.MESSAGE.STATS", "LIBRARY.MESSAGE.STATS: {0}/{1} {2}"), lsvDisplay.Items.Count, GlobalVars.LibraryItems.Count, GlobalVars.ImageSizeCache.Count);
                SizeCacheRunning = false;
            }
        }

        /// <summary>
        /// Sorts the listview.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
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

        /// <summary>
        /// Updates the interface to the currently selected image.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
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

                LoadImageSizesAsync(true);

                cmbCategory.Text = "";
                cmbShowName.Text = "";
                lstCharacters.Items.Clear();
                lstTags.Items.Clear();
                picPreview.Image = Properties.Resources.Blank;
            }
            else if (lsvDisplay.SelectedIndices.Count == 1)
            {
                btnFindDuplicates.Enabled = false;

                var preview = Imaging.FromFile(lsvDisplay.SelectedItems[0].Tag as string);
                lsvDisplay.SelectedItems[0].SubItems[1].Text = preview.Width.ToString();
                lsvDisplay.SelectedItems[0].SubItems[2].Text = preview.Height.ToString();
                GlobalVars.ImageSizeCache.AddDistinct(lsvDisplay.SelectedItems[0].Tag as string, preview.Size);

                lblImageSize.Text = string.Format(LM.GetStringDefault("LIBRARY.LABEL.IMAGE_SIZE", "LIBRARY.LABEL.IMAGE_SIZE: {0}x{1}px"), preview.Width, preview.Height);
                picPreview.Image = preview;
                picPreview.Height = Imaging.CalculateImageHeight(preview, picPreview, this.Height, MINIMUM_DATA_HEIGHT);
                UpdateComboBoxes();
                var item = new LibraryItem();
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

        /// <summary>
        /// Update the control positions when the container changes size.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void spcContainer_Panel2_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        /// <summary>
        /// Update the control positions when the splitter is moved.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void spcContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            UpdateControlPositions();
        }

        /// <summary>
        /// Updates the data in the comboboxes.
        /// </summary>
        private void UpdateComboBoxes()
        {
            ComboBoxLocked = true;

            var CategoryFilter = cmbCategoryFilter.Text;
            cmbCategoryFilter.DataSource = null;
            cmbCategoryFilter.DataSource = FilterCategories;
            cmbCategoryFilter.Text = CategoryFilter;

            var ShowNameFilter = cmbShowNameFilter.Text;
            cmbShowNameFilter.DataSource = null;
            cmbShowNameFilter.DataSource = FilterShowNames;
            cmbShowNameFilter.Text = ShowNameFilter;

            var CharacterFilter = cmbCharacterFilter.Text;
            cmbCharacterFilter.DataSource = null;
            cmbCharacterFilter.DataSource = FilterCharacters;
            cmbCharacterFilter.Text = CharacterFilter;

            var TagFilter = cmbTagFilter.Text;
            cmbTagFilter.DataSource = null;
            cmbTagFilter.DataSource = FilterTags;
            cmbTagFilter.Text = TagFilter;

            cmbCategory.DataSource = null;
            cmbShowName.DataSource = null;
            cmbCategory.DataSource = Categories;
            cmbShowName.DataSource = ShowNames;

            ComboBoxLocked = false;
        }

        /// <summary>
        /// Updates the controls to fill the window.
        /// </summary>
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

        /// <summary>
        /// Updates the control positions after the specfied delay.
        /// </summary>
        /// <param name="Delay">Delay in milliseconds.</param>
        private async void UpdateControlPositionsAsync(int Delay)
        {
            await Task.Delay(Delay);
            UpdateControlPositions();
        }
    }
}
