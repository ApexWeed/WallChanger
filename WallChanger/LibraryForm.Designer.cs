﻿namespace WallChanger
{
    partial class LibraryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spcContainer = new System.Windows.Forms.SplitContainer();
            this.pnlImageList = new System.Windows.Forms.Panel();
            this.lsvDisplay = new System.Windows.Forms.ListView();
            this.colFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnCheckFiles = new System.Windows.Forms.Button();
            this.btnCacheDuplicateThumbnails = new System.Windows.Forms.Button();
            this.btnClearLibrary = new System.Windows.Forms.Button();
            this.btnFindAllDuplicates = new System.Windows.Forms.Button();
            this.btnFindDuplicates = new System.Windows.Forms.Button();
            this.btnRemoveFromLibrary = new System.Windows.Forms.Button();
            this.btnAddToConfig = new System.Windows.Forms.Button();
            this.btnTagFilterClear = new System.Windows.Forms.Button();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.cmbTagFilter = new System.Windows.Forms.ComboBox();
            this.btnCharacterFilterClear = new System.Windows.Forms.Button();
            this.lblFilterCharacter = new System.Windows.Forms.Label();
            this.cmbCharacterFilter = new System.Windows.Forms.ComboBox();
            this.btnShowNameFilterClear = new System.Windows.Forms.Button();
            this.lblFilterShowName = new System.Windows.Forms.Label();
            this.cmbShowNameFilter = new System.Windows.Forms.ComboBox();
            this.btnCategoryFilterClear = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnExpand = new System.Windows.Forms.Button();
            this.lblFilters = new System.Windows.Forms.Label();
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.pnlTagContainer = new System.Windows.Forms.Panel();
            this.pnlTagList = new System.Windows.Forms.Panel();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.pnlTagButtons = new System.Windows.Forms.Panel();
            this.lblTags = new System.Windows.Forms.Label();
            this.btnAddNewTag = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnClearTags = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblImageSize = new System.Windows.Forms.Label();
            this.btnAddNewCharacter = new System.Windows.Forms.Button();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.btnClearCharacters = new System.Windows.Forms.Button();
            this.btnRemoveCharacter = new System.Windows.Forms.Button();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.btnClearShowName = new System.Windows.Forms.Button();
            this.btnClearCategory = new System.Windows.Forms.Button();
            this.btnAddShowName = new System.Windows.Forms.Button();
            this.cmbShowName = new System.Windows.Forms.ComboBox();
            this.lblShowName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.Tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStatistics = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pnlStatusbar = new System.Windows.Forms.Panel();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).BeginInit();
            this.spcContainer.Panel1.SuspendLayout();
            this.spcContainer.Panel2.SuspendLayout();
            this.spcContainer.SuspendLayout();
            this.pnlImageList.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.pnlTagContainer.SuspendLayout();
            this.pnlTagList.SuspendLayout();
            this.pnlTagButtons.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.pnlStatusbar.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcContainer
            // 
            this.spcContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContainer.Location = new System.Drawing.Point(0, 0);
            this.spcContainer.Name = "spcContainer";
            // 
            // spcContainer.Panel1
            // 
            this.spcContainer.Panel1.Controls.Add(this.pnlImageList);
            this.spcContainer.Panel1.Controls.Add(this.pnlFilters);
            // 
            // spcContainer.Panel2
            // 
            this.spcContainer.Panel2.Controls.Add(this.pnlBottomRight);
            this.spcContainer.Panel2.Controls.Add(this.picPreview);
            this.spcContainer.Panel2.Resize += new System.EventHandler(this.spcContainer_Panel2_Resize);
            this.spcContainer.Panel2MinSize = 202;
            this.spcContainer.Size = new System.Drawing.Size(857, 522);
            this.spcContainer.SplitterDistance = 651;
            this.spcContainer.TabIndex = 1;
            this.spcContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spcContainer_SplitterMoved);
            // 
            // pnlImageList
            // 
            this.pnlImageList.Controls.Add(this.lsvDisplay);
            this.pnlImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageList.Location = new System.Drawing.Point(0, 146);
            this.pnlImageList.Name = "pnlImageList";
            this.pnlImageList.Size = new System.Drawing.Size(651, 376);
            this.pnlImageList.TabIndex = 2;
            // 
            // lsvDisplay
            // 
            this.lsvDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilename,
            this.colWidth,
            this.colHeight});
            this.lsvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDisplay.FullRowSelect = true;
            this.lsvDisplay.HideSelection = false;
            this.lsvDisplay.Location = new System.Drawing.Point(0, 0);
            this.lsvDisplay.Name = "lsvDisplay";
            this.lsvDisplay.Size = new System.Drawing.Size(651, 376);
            this.lsvDisplay.TabIndex = 1;
            this.lsvDisplay.UseCompatibleStateImageBehavior = false;
            this.lsvDisplay.View = System.Windows.Forms.View.Details;
            this.lsvDisplay.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvDisplay_ColumnClick);
            this.lsvDisplay.SelectedIndexChanged += new System.EventHandler(this.lsvDisplay_SelectedIndexChanged);
            // 
            // colFilename
            // 
            this.colFilename.Text = "LIBRARY_LABEL_COLUMN_FILENAME";
            this.colFilename.Width = 527;
            // 
            // colWidth
            // 
            this.colWidth.Text = "LIBRARY_LABEL_COLUMN_WIDTH";
            // 
            // colHeight
            // 
            this.colHeight.Text = "LIBRARY_LABEL_COLUMN_HEIGHT";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnCheckFiles);
            this.pnlFilters.Controls.Add(this.btnCacheDuplicateThumbnails);
            this.pnlFilters.Controls.Add(this.btnClearLibrary);
            this.pnlFilters.Controls.Add(this.btnFindAllDuplicates);
            this.pnlFilters.Controls.Add(this.btnFindDuplicates);
            this.pnlFilters.Controls.Add(this.btnRemoveFromLibrary);
            this.pnlFilters.Controls.Add(this.btnAddToConfig);
            this.pnlFilters.Controls.Add(this.btnTagFilterClear);
            this.pnlFilters.Controls.Add(this.lblFilterTag);
            this.pnlFilters.Controls.Add(this.cmbTagFilter);
            this.pnlFilters.Controls.Add(this.btnCharacterFilterClear);
            this.pnlFilters.Controls.Add(this.lblFilterCharacter);
            this.pnlFilters.Controls.Add(this.cmbCharacterFilter);
            this.pnlFilters.Controls.Add(this.btnShowNameFilterClear);
            this.pnlFilters.Controls.Add(this.lblFilterShowName);
            this.pnlFilters.Controls.Add(this.cmbShowNameFilter);
            this.pnlFilters.Controls.Add(this.btnCategoryFilterClear);
            this.pnlFilters.Controls.Add(this.btnClearFilters);
            this.pnlFilters.Controls.Add(this.lblFilterCategory);
            this.pnlFilters.Controls.Add(this.cmbCategoryFilter);
            this.pnlFilters.Controls.Add(this.btnExpand);
            this.pnlFilters.Controls.Add(this.lblFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(651, 146);
            this.pnlFilters.TabIndex = 1;
            // 
            // btnCheckFiles
            // 
            this.btnCheckFiles.Image = global::WallChanger.Properties.Resources.drive;
            this.btnCheckFiles.Location = new System.Drawing.Point(444, 3);
            this.btnCheckFiles.Name = "btnCheckFiles";
            this.btnCheckFiles.Size = new System.Drawing.Size(24, 24);
            this.btnCheckFiles.TabIndex = 32;
            this.Tooltips.SetToolTip(this.btnCheckFiles, "LIBRARY_TOOLTIP_FILE_CHECK");
            this.btnCheckFiles.UseVisualStyleBackColor = true;
            this.btnCheckFiles.Click += new System.EventHandler(this.btnCheckFiles_Click);
            // 
            // btnCacheDuplicateThumbnails
            // 
            this.btnCacheDuplicateThumbnails.Image = global::WallChanger.Properties.Resources.picture_small;
            this.btnCacheDuplicateThumbnails.Location = new System.Drawing.Point(474, 3);
            this.btnCacheDuplicateThumbnails.Name = "btnCacheDuplicateThumbnails";
            this.btnCacheDuplicateThumbnails.Size = new System.Drawing.Size(24, 24);
            this.btnCacheDuplicateThumbnails.TabIndex = 31;
            this.Tooltips.SetToolTip(this.btnCacheDuplicateThumbnails, "LIBRARY_TOOLTIP_CACHE_GREYSCALE");
            this.btnCacheDuplicateThumbnails.UseVisualStyleBackColor = true;
            this.btnCacheDuplicateThumbnails.Click += new System.EventHandler(this.btnCacheDuplicateThumbnails_Click);
            // 
            // btnClearLibrary
            // 
            this.btnClearLibrary.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearLibrary.Location = new System.Drawing.Point(564, 3);
            this.btnClearLibrary.Name = "btnClearLibrary";
            this.btnClearLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnClearLibrary.TabIndex = 30;
            this.Tooltips.SetToolTip(this.btnClearLibrary, "LIBRARY_TOOLTIP_CLEAR");
            this.btnClearLibrary.UseVisualStyleBackColor = true;
            this.btnClearLibrary.Click += new System.EventHandler(this.btnClearLibrary_Click);
            // 
            // btnFindAllDuplicates
            // 
            this.btnFindAllDuplicates.Image = global::WallChanger.Properties.Resources.blue_document_copy;
            this.btnFindAllDuplicates.Location = new System.Drawing.Point(504, 3);
            this.btnFindAllDuplicates.Name = "btnFindAllDuplicates";
            this.btnFindAllDuplicates.Size = new System.Drawing.Size(24, 24);
            this.btnFindAllDuplicates.TabIndex = 28;
            this.Tooltips.SetToolTip(this.btnFindAllDuplicates, "LIBRARY_TOOLTIP_DUPLICATES");
            this.btnFindAllDuplicates.UseVisualStyleBackColor = true;
            this.btnFindAllDuplicates.Click += new System.EventHandler(this.btnFindAllDuplicates_Click);
            // 
            // btnFindDuplicates
            // 
            this.btnFindDuplicates.Image = global::WallChanger.Properties.Resources.document_copy;
            this.btnFindDuplicates.Location = new System.Drawing.Point(534, 3);
            this.btnFindDuplicates.Name = "btnFindDuplicates";
            this.btnFindDuplicates.Size = new System.Drawing.Size(24, 24);
            this.btnFindDuplicates.TabIndex = 27;
            this.Tooltips.SetToolTip(this.btnFindDuplicates, "LIBRARY_TOOLTIP_DUPLICATES_SELECTION");
            this.btnFindDuplicates.UseVisualStyleBackColor = true;
            this.btnFindDuplicates.Click += new System.EventHandler(this.btnFindDuplicates_Click);
            // 
            // btnRemoveFromLibrary
            // 
            this.btnRemoveFromLibrary.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveFromLibrary.Location = new System.Drawing.Point(594, 3);
            this.btnRemoveFromLibrary.Name = "btnRemoveFromLibrary";
            this.btnRemoveFromLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveFromLibrary.TabIndex = 15;
            this.Tooltips.SetToolTip(this.btnRemoveFromLibrary, "LIBRARY_TOOLTIP_REMOVE");
            this.btnRemoveFromLibrary.UseVisualStyleBackColor = true;
            this.btnRemoveFromLibrary.Click += new System.EventHandler(this.btnRemoveFromLibrary_Click);
            // 
            // btnAddToConfig
            // 
            this.btnAddToConfig.Image = global::WallChanger.Properties.Resources.address_book__arrow;
            this.btnAddToConfig.Location = new System.Drawing.Point(624, 3);
            this.btnAddToConfig.Name = "btnAddToConfig";
            this.btnAddToConfig.Size = new System.Drawing.Size(24, 24);
            this.btnAddToConfig.TabIndex = 9;
            this.Tooltips.SetToolTip(this.btnAddToConfig, "LIBRARY_TOOLTIP_CONFIG_ADD");
            this.btnAddToConfig.UseVisualStyleBackColor = true;
            this.btnAddToConfig.Click += new System.EventHandler(this.btnAddToConfig_Click);
            // 
            // btnTagFilterClear
            // 
            this.btnTagFilterClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnTagFilterClear.Location = new System.Drawing.Point(363, 88);
            this.btnTagFilterClear.Name = "btnTagFilterClear";
            this.btnTagFilterClear.Size = new System.Drawing.Size(24, 24);
            this.btnTagFilterClear.TabIndex = 26;
            this.Tooltips.SetToolTip(this.btnTagFilterClear, "LIBRARY_TOOLTIP_FILTER_TAG");
            this.btnTagFilterClear.UseVisualStyleBackColor = true;
            this.btnTagFilterClear.Click += new System.EventHandler(this.btnTagFilterClear_Click);
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(198, 94);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(163, 13);
            this.lblFilterTag.TabIndex = 25;
            this.lblFilterTag.Text = "LIBRARY_LABEL_FILTER_TAG";
            // 
            // cmbTagFilter
            // 
            this.cmbTagFilter.FormattingEnabled = true;
            this.cmbTagFilter.Location = new System.Drawing.Point(201, 118);
            this.cmbTagFilter.Name = "cmbTagFilter";
            this.cmbTagFilter.Size = new System.Drawing.Size(186, 21);
            this.cmbTagFilter.TabIndex = 24;
            this.cmbTagFilter.SelectedValueChanged += new System.EventHandler(this.FilterChoiceChanged);
            // 
            // btnCharacterFilterClear
            // 
            this.btnCharacterFilterClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnCharacterFilterClear.Location = new System.Drawing.Point(168, 88);
            this.btnCharacterFilterClear.Name = "btnCharacterFilterClear";
            this.btnCharacterFilterClear.Size = new System.Drawing.Size(24, 24);
            this.btnCharacterFilterClear.TabIndex = 23;
            this.Tooltips.SetToolTip(this.btnCharacterFilterClear, "LIBRARY_TOOLTIP_FILTER_CHARACTER");
            this.btnCharacterFilterClear.UseVisualStyleBackColor = true;
            this.btnCharacterFilterClear.Click += new System.EventHandler(this.btnCharacterFilterClear_Click);
            // 
            // lblFilterCharacter
            // 
            this.lblFilterCharacter.AutoSize = true;
            this.lblFilterCharacter.Location = new System.Drawing.Point(3, 94);
            this.lblFilterCharacter.Name = "lblFilterCharacter";
            this.lblFilterCharacter.Size = new System.Drawing.Size(207, 13);
            this.lblFilterCharacter.TabIndex = 22;
            this.lblFilterCharacter.Text = "LIBRARY_LABEL_FILTER_CHARACTER";
            // 
            // cmbCharacterFilter
            // 
            this.cmbCharacterFilter.FormattingEnabled = true;
            this.cmbCharacterFilter.Location = new System.Drawing.Point(6, 118);
            this.cmbCharacterFilter.Name = "cmbCharacterFilter";
            this.cmbCharacterFilter.Size = new System.Drawing.Size(186, 21);
            this.cmbCharacterFilter.TabIndex = 21;
            this.cmbCharacterFilter.SelectedValueChanged += new System.EventHandler(this.FilterChoiceChanged);
            // 
            // btnShowNameFilterClear
            // 
            this.btnShowNameFilterClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnShowNameFilterClear.Location = new System.Drawing.Point(363, 31);
            this.btnShowNameFilterClear.Name = "btnShowNameFilterClear";
            this.btnShowNameFilterClear.Size = new System.Drawing.Size(24, 24);
            this.btnShowNameFilterClear.TabIndex = 20;
            this.Tooltips.SetToolTip(this.btnShowNameFilterClear, "LIBRARY_TOOLTIP_FILTER_SHOW_NAME");
            this.btnShowNameFilterClear.UseVisualStyleBackColor = true;
            this.btnShowNameFilterClear.Click += new System.EventHandler(this.btnShowNameFilterClear_Click);
            // 
            // lblFilterShowName
            // 
            this.lblFilterShowName.AutoSize = true;
            this.lblFilterShowName.Location = new System.Drawing.Point(198, 37);
            this.lblFilterShowName.Name = "lblFilterShowName";
            this.lblFilterShowName.Size = new System.Drawing.Size(212, 13);
            this.lblFilterShowName.TabIndex = 19;
            this.lblFilterShowName.Text = "LIBRARY_LABEL_FILTER_SHOW_NAME";
            // 
            // cmbShowNameFilter
            // 
            this.cmbShowNameFilter.FormattingEnabled = true;
            this.cmbShowNameFilter.Location = new System.Drawing.Point(201, 61);
            this.cmbShowNameFilter.Name = "cmbShowNameFilter";
            this.cmbShowNameFilter.Size = new System.Drawing.Size(186, 21);
            this.cmbShowNameFilter.TabIndex = 18;
            this.cmbShowNameFilter.SelectedValueChanged += new System.EventHandler(this.FilterChoiceChanged);
            // 
            // btnCategoryFilterClear
            // 
            this.btnCategoryFilterClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnCategoryFilterClear.Location = new System.Drawing.Point(168, 31);
            this.btnCategoryFilterClear.Name = "btnCategoryFilterClear";
            this.btnCategoryFilterClear.Size = new System.Drawing.Size(24, 24);
            this.btnCategoryFilterClear.TabIndex = 17;
            this.Tooltips.SetToolTip(this.btnCategoryFilterClear, "LIBRARY_TOOLTIP_FILTER_CATEGORY");
            this.btnCategoryFilterClear.UseVisualStyleBackColor = true;
            this.btnCategoryFilterClear.Click += new System.EventHandler(this.btnCategoryFilterClear_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearFilters.Location = new System.Drawing.Point(73, 3);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(24, 24);
            this.btnClearFilters.TabIndex = 15;
            this.Tooltips.SetToolTip(this.btnClearFilters, "LIBRARY_TOOLTIP_FILTER_CLEAR");
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Location = new System.Drawing.Point(3, 37);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(200, 13);
            this.lblFilterCategory.TabIndex = 16;
            this.lblFilterCategory.Text = "LIBRARY_LABEL_FILTER_CATEGORY";
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(6, 61);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(186, 21);
            this.cmbCategoryFilter.TabIndex = 15;
            this.cmbCategoryFilter.SelectedValueChanged += new System.EventHandler(this.FilterChoiceChanged);
            // 
            // btnExpand
            // 
            this.btnExpand.Image = global::WallChanger.Properties.Resources.toggle_expand;
            this.btnExpand.Location = new System.Drawing.Point(43, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 15;
            this.Tooltips.SetToolTip(this.btnExpand, "LIBRARY_TOOLTIP_FILTER_EXPAND");
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(3, 9);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(142, 13);
            this.lblFilters.TabIndex = 0;
            this.lblFilters.Text = "LIBRARY_LABEL_FILTERS";
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.pnlTagContainer);
            this.pnlBottomRight.Controls.Add(this.pnlDetails);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomRight.Location = new System.Drawing.Point(0, 202);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(202, 320);
            this.pnlBottomRight.TabIndex = 5;
            // 
            // pnlTagContainer
            // 
            this.pnlTagContainer.Controls.Add(this.pnlTagList);
            this.pnlTagContainer.Controls.Add(this.pnlTagButtons);
            this.pnlTagContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagContainer.Location = new System.Drawing.Point(0, 225);
            this.pnlTagContainer.Name = "pnlTagContainer";
            this.pnlTagContainer.Padding = new System.Windows.Forms.Padding(7, 0, 9, 0);
            this.pnlTagContainer.Size = new System.Drawing.Size(202, 95);
            this.pnlTagContainer.TabIndex = 6;
            // 
            // pnlTagList
            // 
            this.pnlTagList.Controls.Add(this.lstTags);
            this.pnlTagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagList.Location = new System.Drawing.Point(7, 30);
            this.pnlTagList.Name = "pnlTagList";
            this.pnlTagList.Size = new System.Drawing.Size(186, 65);
            this.pnlTagList.TabIndex = 19;
            // 
            // lstTags
            // 
            this.lstTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(0, 0);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(186, 65);
            this.lstTags.TabIndex = 0;
            // 
            // pnlTagButtons
            // 
            this.pnlTagButtons.Controls.Add(this.lblTags);
            this.pnlTagButtons.Controls.Add(this.btnAddNewTag);
            this.pnlTagButtons.Controls.Add(this.btnRemoveTag);
            this.pnlTagButtons.Controls.Add(this.btnClearTags);
            this.pnlTagButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTagButtons.Location = new System.Drawing.Point(7, 0);
            this.pnlTagButtons.Name = "pnlTagButtons";
            this.pnlTagButtons.Size = new System.Drawing.Size(186, 30);
            this.pnlTagButtons.TabIndex = 18;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(0, 6);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(120, 13);
            this.lblTags.TabIndex = 1;
            this.lblTags.Text = "LIBRARY_LABEL_TAG";
            // 
            // btnAddNewTag
            // 
            this.btnAddNewTag.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddNewTag.Location = new System.Drawing.Point(102, 0);
            this.btnAddNewTag.Name = "btnAddNewTag";
            this.btnAddNewTag.Size = new System.Drawing.Size(24, 24);
            this.btnAddNewTag.TabIndex = 17;
            this.Tooltips.SetToolTip(this.btnAddNewTag, "LIBRARY_TOOLTIP_TAG_ADD");
            this.btnAddNewTag.UseVisualStyleBackColor = true;
            this.btnAddNewTag.Click += new System.EventHandler(this.btnAddNewTag_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveTag.Location = new System.Drawing.Point(132, 0);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveTag.TabIndex = 15;
            this.Tooltips.SetToolTip(this.btnRemoveTag, "LIBRARY_TOOLTIP_TAG_REMOVE");
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnClearTags
            // 
            this.btnClearTags.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearTags.Location = new System.Drawing.Point(162, 0);
            this.btnClearTags.Name = "btnClearTags";
            this.btnClearTags.Size = new System.Drawing.Size(24, 24);
            this.btnClearTags.TabIndex = 16;
            this.Tooltips.SetToolTip(this.btnClearTags, "LIBRARY_TOOLTIP_TAG_CLEAR");
            this.btnClearTags.UseVisualStyleBackColor = true;
            this.btnClearTags.Click += new System.EventHandler(this.btnClearTags_Click);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblImageSize);
            this.pnlDetails.Controls.Add(this.btnAddNewCharacter);
            this.pnlDetails.Controls.Add(this.lstCharacters);
            this.pnlDetails.Controls.Add(this.btnClearCharacters);
            this.pnlDetails.Controls.Add(this.btnRemoveCharacter);
            this.pnlDetails.Controls.Add(this.lblCharacters);
            this.pnlDetails.Controls.Add(this.btnClearShowName);
            this.pnlDetails.Controls.Add(this.btnClearCategory);
            this.pnlDetails.Controls.Add(this.btnAddShowName);
            this.pnlDetails.Controls.Add(this.cmbShowName);
            this.pnlDetails.Controls.Add(this.lblShowName);
            this.pnlDetails.Controls.Add(this.lblCategory);
            this.pnlDetails.Controls.Add(this.btnAddCategory);
            this.pnlDetails.Controls.Add(this.cmbCategory);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(202, 225);
            this.pnlDetails.TabIndex = 5;
            // 
            // lblImageSize
            // 
            this.lblImageSize.AutoSize = true;
            this.lblImageSize.Location = new System.Drawing.Point(4, 3);
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Size = new System.Drawing.Size(162, 13);
            this.lblImageSize.TabIndex = 14;
            this.lblImageSize.Text = "LIBRARY_LABEL_IMAGE_SIZE";
            // 
            // btnAddNewCharacter
            // 
            this.btnAddNewCharacter.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddNewCharacter.Location = new System.Drawing.Point(109, 133);
            this.btnAddNewCharacter.Name = "btnAddNewCharacter";
            this.btnAddNewCharacter.Size = new System.Drawing.Size(24, 24);
            this.btnAddNewCharacter.TabIndex = 13;
            this.Tooltips.SetToolTip(this.btnAddNewCharacter, "LIBRARY_TOOLTIP_CHRACTER_ADD");
            this.btnAddNewCharacter.UseVisualStyleBackColor = true;
            this.btnAddNewCharacter.Click += new System.EventHandler(this.btnAddNewCharacter_Click);
            // 
            // lstCharacters
            // 
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.Location = new System.Drawing.Point(7, 163);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(186, 56);
            this.lstCharacters.TabIndex = 12;
            // 
            // btnClearCharacters
            // 
            this.btnClearCharacters.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCharacters.Location = new System.Drawing.Point(169, 133);
            this.btnClearCharacters.Name = "btnClearCharacters";
            this.btnClearCharacters.Size = new System.Drawing.Size(24, 24);
            this.btnClearCharacters.TabIndex = 11;
            this.Tooltips.SetToolTip(this.btnClearCharacters, "LIBRARY_TOOLTIP_CHRACTER_CLEAR");
            this.btnClearCharacters.UseVisualStyleBackColor = true;
            this.btnClearCharacters.Click += new System.EventHandler(this.btnClearCharacters_Click);
            // 
            // btnRemoveCharacter
            // 
            this.btnRemoveCharacter.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveCharacter.Location = new System.Drawing.Point(139, 133);
            this.btnRemoveCharacter.Name = "btnRemoveCharacter";
            this.btnRemoveCharacter.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveCharacter.TabIndex = 10;
            this.Tooltips.SetToolTip(this.btnRemoveCharacter, "LIBRARY_TOOLTIP_CHARACTER_REMOVE");
            this.btnRemoveCharacter.UseVisualStyleBackColor = true;
            this.btnRemoveCharacter.Click += new System.EventHandler(this.btnRemoveCharacter_Click);
            // 
            // lblCharacters
            // 
            this.lblCharacters.AutoSize = true;
            this.lblCharacters.Location = new System.Drawing.Point(4, 139);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(164, 13);
            this.lblCharacters.TabIndex = 9;
            this.lblCharacters.Text = "LIBRARY_LABEL_CHARACTER";
            // 
            // btnClearShowName
            // 
            this.btnClearShowName.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearShowName.Location = new System.Drawing.Point(169, 76);
            this.btnClearShowName.Name = "btnClearShowName";
            this.btnClearShowName.Size = new System.Drawing.Size(24, 24);
            this.btnClearShowName.TabIndex = 8;
            this.Tooltips.SetToolTip(this.btnClearShowName, "LIBRARY_TOOLTIP_SHOW_NAME_CLEAR");
            this.btnClearShowName.UseVisualStyleBackColor = true;
            this.btnClearShowName.Click += new System.EventHandler(this.btnClearShowName_Click);
            // 
            // btnClearCategory
            // 
            this.btnClearCategory.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCategory.Location = new System.Drawing.Point(169, 19);
            this.btnClearCategory.Name = "btnClearCategory";
            this.btnClearCategory.Size = new System.Drawing.Size(24, 24);
            this.btnClearCategory.TabIndex = 7;
            this.Tooltips.SetToolTip(this.btnClearCategory, "LIBRARY_TOOLTIP_CATTEGORY_CLEAR");
            this.btnClearCategory.UseVisualStyleBackColor = true;
            this.btnClearCategory.Click += new System.EventHandler(this.btnClearCategory_Click);
            // 
            // btnAddShowName
            // 
            this.btnAddShowName.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddShowName.Location = new System.Drawing.Point(139, 76);
            this.btnAddShowName.Name = "btnAddShowName";
            this.btnAddShowName.Size = new System.Drawing.Size(24, 24);
            this.btnAddShowName.TabIndex = 6;
            this.Tooltips.SetToolTip(this.btnAddShowName, "LIBRARY_TOOLTIP_SHOW_NAME_ADD");
            this.btnAddShowName.UseVisualStyleBackColor = true;
            this.btnAddShowName.Click += new System.EventHandler(this.btnAddShowName_Click);
            // 
            // cmbShowName
            // 
            this.cmbShowName.FormattingEnabled = true;
            this.cmbShowName.Location = new System.Drawing.Point(7, 106);
            this.cmbShowName.Name = "cmbShowName";
            this.cmbShowName.Size = new System.Drawing.Size(186, 21);
            this.cmbShowName.TabIndex = 5;
            this.cmbShowName.SelectedValueChanged += new System.EventHandler(this.cmbShowName_SelectedValueChanged);
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.Location = new System.Drawing.Point(3, 82);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(169, 13);
            this.lblShowName.TabIndex = 4;
            this.lblShowName.Text = "LIBRARY_LABEL_SHOW_NAME";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(4, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(157, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "LIBRARY_LABEL_CATEGORY";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddCategory.Location = new System.Drawing.Point(139, 19);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 24);
            this.btnAddCategory.TabIndex = 3;
            this.Tooltips.SetToolTip(this.btnAddCategory, "LIBRARY_TOOLTIP_CATEGORY_ADD");
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(7, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(186, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(202, 202);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tslStatistics,
            this.tspProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, -1);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(171, 18);
            this.tslStatus.Text = "LIBRARY_MESSAGE_READY";
            // 
            // tslStatistics
            // 
            this.tslStatistics.Name = "tslStatistics";
            this.tslStatistics.Size = new System.Drawing.Size(134, 18);
            this.tslStatistics.Text = "toolStripStatusLabel1";
            // 
            // tspProgressBar
            // 
            this.tspProgressBar.Name = "tspProgressBar";
            this.tspProgressBar.Size = new System.Drawing.Size(100, 17);
            // 
            // pnlStatusbar
            // 
            this.pnlStatusbar.Controls.Add(this.statusStrip1);
            this.pnlStatusbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusbar.Location = new System.Drawing.Point(0, 522);
            this.pnlStatusbar.Name = "pnlStatusbar";
            this.pnlStatusbar.Size = new System.Drawing.Size(857, 22);
            this.pnlStatusbar.TabIndex = 3;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.spcContainer);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(857, 522);
            this.pnlMainContainer.TabIndex = 4;
            // 
            // LibraryForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 544);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlStatusbar);
            this.MinimumSize = new System.Drawing.Size(16, 582);
            this.Name = "LibraryForm";
            this.Text = "LibraryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryForm_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LibraryForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LibraryForm_DragEnter);
            this.spcContainer.Panel1.ResumeLayout(false);
            this.spcContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).EndInit();
            this.spcContainer.ResumeLayout(false);
            this.pnlImageList.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlTagContainer.ResumeLayout(false);
            this.pnlTagList.ResumeLayout(false);
            this.pnlTagButtons.ResumeLayout(false);
            this.pnlTagButtons.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlStatusbar.ResumeLayout(false);
            this.pnlStatusbar.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spcContainer;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ToolTip Tooltips;
        private System.Windows.Forms.Panel pnlBottomRight;
        private System.Windows.Forms.Panel pnlTagContainer;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnAddNewCharacter;
        private System.Windows.Forms.ListBox lstCharacters;
        private System.Windows.Forms.Button btnClearCharacters;
        private System.Windows.Forms.Button btnRemoveCharacter;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.Button btnClearShowName;
        private System.Windows.Forms.Button btnClearCategory;
        private System.Windows.Forms.Button btnAddShowName;
        private System.Windows.Forms.ComboBox cmbShowName;
        private System.Windows.Forms.Label lblShowName;
        private System.Windows.Forms.Label lblImageSize;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Panel pnlTagList;
        private System.Windows.Forms.Panel pnlTagButtons;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.Button btnAddNewTag;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnClearTags;
        private System.Windows.Forms.Panel pnlImageList;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnCategoryFilterClear;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Button btnTagFilterClear;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.ComboBox cmbTagFilter;
        private System.Windows.Forms.Button btnCharacterFilterClear;
        private System.Windows.Forms.Label lblFilterCharacter;
        private System.Windows.Forms.ComboBox cmbCharacterFilter;
        private System.Windows.Forms.Button btnShowNameFilterClear;
        private System.Windows.Forms.Label lblFilterShowName;
        private System.Windows.Forms.ComboBox cmbShowNameFilter;
        private System.Windows.Forms.Button btnAddToConfig;
        private System.Windows.Forms.Button btnRemoveFromLibrary;
        private System.Windows.Forms.Button btnFindAllDuplicates;
        private System.Windows.Forms.Button btnFindDuplicates;
        private System.Windows.Forms.Button btnClearLibrary;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.Panel pnlStatusbar;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.ToolStripStatusLabel tslStatistics;
        private System.Windows.Forms.ListView lsvDisplay;
        private System.Windows.Forms.ColumnHeader colFilename;
        private System.Windows.Forms.ColumnHeader colWidth;
        private System.Windows.Forms.ColumnHeader colHeight;
        private System.Windows.Forms.ToolStripProgressBar tspProgressBar;
        private System.Windows.Forms.Button btnCacheDuplicateThumbnails;
        private System.Windows.Forms.Button btnCheckFiles;
    }
}