namespace WallChanger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ofdAdd = new System.Windows.Forms.OpenFileDialog();
            this.noiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.cmbWallpaperStyle = new WallChanger.Translation.Controls.TranslatableComboBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.grpImages = new WallChanger.Translation.Controls.TranslatableGroupBoxFormat();
            this.pnlImagesInner = new System.Windows.Forms.Panel();
            this.pnlFileList = new System.Windows.Forms.Panel();
            this.lstImages = new WallChanger.HighlightListBox();
            this.pnlImageButtons = new System.Windows.Forms.Panel();
            this.btnProcessing = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnSettings = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnLanguage = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnAddToLibrary = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnLibrary = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnAddImage = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnClear = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnRemoveImage = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnMoveDown = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnMoveUp = new WallChanger.Translation.Controls.TranslatableButton();
            this.grpConfig = new WallChanger.Translation.Controls.TranslatableGroupBox();
            this.pnlConfigInner = new System.Windows.Forms.Panel();
            this.lstConfigs = new System.Windows.Forms.ListBox();
            this.pnlConfigButtons = new System.Windows.Forms.Panel();
            this.btnNewConfig = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnRemoveConfig = new WallChanger.Translation.Controls.TranslatableButton();
            this.chkChangeThemeColour = new WallChanger.Translation.Controls.TranslatableCheckBox();
            this.chkFade = new WallChanger.Translation.Controls.TranslatableCheckBox();
            this.chkRandomise = new WallChanger.Translation.Controls.TranslatableCheckBox();
            this.lblNextChange = new WallChanger.Translation.Controls.TranslatableLabelFormat();
            this.btnTiming = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnTray = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnReload = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnSave = new WallChanger.Translation.Controls.TranslatableButton();
            this.chkStartup = new WallChanger.Translation.Controls.TranslatableCheckBox();
            this.MainTitle = new WallChanger.Translation.Controls.TranslatableTitle();
            this.trtToolTips = new WallChanger.Translation.Controls.TranslatableTooltips();
            this.pnlRight.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpImages.SuspendLayout();
            this.pnlImagesInner.SuspendLayout();
            this.pnlFileList.SuspendLayout();
            this.pnlImageButtons.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.pnlConfigInner.SuspendLayout();
            this.pnlConfigButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdAdd
            // 
            this.ofdAdd.Filter = "Image Files|*.bmp;*.png;*.tif;*.gif;*.jpg;*.jpeg|All Files|*.*";
            this.ofdAdd.Multiselect = true;
            // 
            // noiTray
            // 
            this.noiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("noiTray.Icon")));
            this.noiTray.Text = "Wallpaper Changer";
            this.noiTray.Click += new System.EventHandler(this.noiTray_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTopRight);
            this.pnlRight.Controls.Add(this.pnlBottomRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(605, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(179, 491);
            this.pnlRight.TabIndex = 11;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.grpConfig);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRight.Location = new System.Drawing.Point(0, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(179, 301);
            this.pnlTopRight.TabIndex = 13;
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.chkChangeThemeColour);
            this.pnlBottomRight.Controls.Add(this.cmbWallpaperStyle);
            this.pnlBottomRight.Controls.Add(this.chkFade);
            this.pnlBottomRight.Controls.Add(this.chkRandomise);
            this.pnlBottomRight.Controls.Add(this.lblNextChange);
            this.pnlBottomRight.Controls.Add(this.btnTiming);
            this.pnlBottomRight.Controls.Add(this.btnTray);
            this.pnlBottomRight.Controls.Add(this.btnReload);
            this.pnlBottomRight.Controls.Add(this.btnSave);
            this.pnlBottomRight.Controls.Add(this.chkStartup);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomRight.Location = new System.Drawing.Point(0, 301);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(179, 190);
            this.pnlBottomRight.TabIndex = 12;
            // 
            // cmbWallpaperStyle
            // 
            this.cmbWallpaperStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWallpaperStyle.FormattingEnabled = true;
            this.cmbWallpaperStyle.Location = new System.Drawing.Point(6, 141);
            this.cmbWallpaperStyle.Name = "cmbWallpaperStyle";
            this.cmbWallpaperStyle.Size = new System.Drawing.Size(167, 20);
            this.cmbWallpaperStyle.TabIndex = 12;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpImages);
            this.pnlLeft.Controls.Add(this.pnlSpacer);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(605, 491);
            this.pnlLeft.TabIndex = 12;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpacer.Location = new System.Drawing.Point(597, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(8, 491);
            this.pnlSpacer.TabIndex = 11;
            // 
            // grpImages
            // 
            this.grpImages.Controls.Add(this.pnlImagesInner);
            this.grpImages.DefaultString = null;
            this.grpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImages.Location = new System.Drawing.Point(0, 0);
            this.grpImages.Name = "grpImages";
            this.grpImages.Parameters = new object[0];
            this.grpImages.Size = new System.Drawing.Size(597, 491);
            this.grpImages.TabIndex = 10;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "MAIN.LABEL.IMAGES";
            this.grpImages.TranslationString = "MAIN.LABEL.IMAGES";
            // 
            // pnlImagesInner
            // 
            this.pnlImagesInner.Controls.Add(this.pnlFileList);
            this.pnlImagesInner.Controls.Add(this.pnlImageButtons);
            this.pnlImagesInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagesInner.Location = new System.Drawing.Point(3, 15);
            this.pnlImagesInner.Name = "pnlImagesInner";
            this.pnlImagesInner.Size = new System.Drawing.Size(591, 473);
            this.pnlImagesInner.TabIndex = 8;
            // 
            // pnlFileList
            // 
            this.pnlFileList.Controls.Add(this.lstImages);
            this.pnlFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileList.Location = new System.Drawing.Point(0, 0);
            this.pnlFileList.Name = "pnlFileList";
            this.pnlFileList.Size = new System.Drawing.Size(561, 473);
            this.pnlFileList.TabIndex = 8;
            // 
            // lstImages
            // 
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstImages.FormattingEnabled = true;
            this.lstImages.HorizontalScrollbar = true;
            this.lstImages.Location = new System.Drawing.Point(0, 0);
            this.lstImages.Name = "lstImages";
            this.lstImages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImages.Size = new System.Drawing.Size(561, 473);
            this.lstImages.TabIndex = 0;
            // 
            // pnlImageButtons
            // 
            this.pnlImageButtons.Controls.Add(this.btnProcessing);
            this.pnlImageButtons.Controls.Add(this.btnSettings);
            this.pnlImageButtons.Controls.Add(this.btnLanguage);
            this.pnlImageButtons.Controls.Add(this.btnAddToLibrary);
            this.pnlImageButtons.Controls.Add(this.btnLibrary);
            this.pnlImageButtons.Controls.Add(this.btnAddImage);
            this.pnlImageButtons.Controls.Add(this.btnClear);
            this.pnlImageButtons.Controls.Add(this.btnRemoveImage);
            this.pnlImageButtons.Controls.Add(this.btnMoveDown);
            this.pnlImageButtons.Controls.Add(this.btnMoveUp);
            this.pnlImageButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImageButtons.Location = new System.Drawing.Point(561, 0);
            this.pnlImageButtons.Name = "pnlImageButtons";
            this.pnlImageButtons.Size = new System.Drawing.Size(30, 473);
            this.pnlImageButtons.TabIndex = 7;
            // 
            // btnProcessing
            // 
            this.btnProcessing.DefaultString = null;
            this.btnProcessing.Image = global::WallChanger.Properties.Resources.processor;
            this.btnProcessing.Location = new System.Drawing.Point(3, 273);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(24, 24);
            this.btnProcessing.TabIndex = 11;
            this.ToolTips.SetToolTip(this.btnProcessing, "MAIN.TOOLTIP.PREPROCESSING");
            this.btnProcessing.TranslationString = null;
            this.btnProcessing.UseVisualStyleBackColor = true;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.DefaultString = null;
            this.btnSettings.Image = global::WallChanger.Properties.Resources.gear;
            this.btnSettings.Location = new System.Drawing.Point(3, 243);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(24, 24);
            this.btnSettings.TabIndex = 10;
            this.ToolTips.SetToolTip(this.btnSettings, "MAIN.TOOLTIP.SETTINGS");
            this.btnSettings.TranslationString = null;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.DefaultString = null;
            this.btnLanguage.Image = global::WallChanger.Properties.Resources.edit_language;
            this.btnLanguage.Location = new System.Drawing.Point(3, 213);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(24, 24);
            this.btnLanguage.TabIndex = 9;
            this.ToolTips.SetToolTip(this.btnLanguage, "MAIN.TOOLTIP.LANGUAGE");
            this.btnLanguage.TranslationString = null;
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnAddToLibrary
            // 
            this.btnAddToLibrary.DefaultString = null;
            this.btnAddToLibrary.Image = global::WallChanger.Properties.Resources.address_book__arrow;
            this.btnAddToLibrary.Location = new System.Drawing.Point(3, 183);
            this.btnAddToLibrary.Name = "btnAddToLibrary";
            this.btnAddToLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnAddToLibrary.TabIndex = 8;
            this.ToolTips.SetToolTip(this.btnAddToLibrary, "MAIN.TOOLTIP.LIBRARY_ADD");
            this.btnAddToLibrary.TranslationString = null;
            this.btnAddToLibrary.UseVisualStyleBackColor = true;
            this.btnAddToLibrary.Click += new System.EventHandler(this.btnAddToLibrary_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.DefaultString = null;
            this.btnLibrary.Image = global::WallChanger.Properties.Resources.address_book;
            this.btnLibrary.Location = new System.Drawing.Point(3, 153);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnLibrary.TabIndex = 7;
            this.ToolTips.SetToolTip(this.btnLibrary, "MAIN.TOOLTIP.LIBRARY");
            this.btnLibrary.TranslationString = null;
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.DefaultString = null;
            this.btnAddImage.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddImage.Location = new System.Drawing.Point(3, 3);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(24, 24);
            this.btnAddImage.TabIndex = 2;
            this.ToolTips.SetToolTip(this.btnAddImage, "MAIN.TOOLTIP.ADD");
            this.btnAddImage.TranslationString = null;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnClear
            // 
            this.btnClear.DefaultString = null;
            this.btnClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClear.Location = new System.Drawing.Point(3, 123);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 6;
            this.ToolTips.SetToolTip(this.btnClear, "MAIN.TOOLTIP.CLEAR");
            this.btnClear.TranslationString = null;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.DefaultString = null;
            this.btnRemoveImage.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveImage.Location = new System.Drawing.Point(3, 33);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveImage.TabIndex = 3;
            this.ToolTips.SetToolTip(this.btnRemoveImage, "MAIN.TOOLTIP.REMOVE");
            this.btnRemoveImage.TranslationString = null;
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.DefaultString = null;
            this.btnMoveDown.Image = global::WallChanger.Properties.Resources.navigation_270_button;
            this.btnMoveDown.Location = new System.Drawing.Point(3, 93);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 5;
            this.ToolTips.SetToolTip(this.btnMoveDown, "MAIN.TOOLTIP.MOVE_DOWN");
            this.btnMoveDown.TranslationString = null;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.DefaultString = null;
            this.btnMoveUp.Image = global::WallChanger.Properties.Resources.navigation_090_button;
            this.btnMoveUp.Location = new System.Drawing.Point(3, 63);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 4;
            this.ToolTips.SetToolTip(this.btnMoveUp, "MAIN.TOOLTIP.MOVE_UP");
            this.btnMoveUp.TranslationString = null;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.pnlConfigInner);
            this.grpConfig.DefaultString = null;
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfig.Location = new System.Drawing.Point(0, 0);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(179, 301);
            this.grpConfig.TabIndex = 9;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "MAIN.LABEL.CONFIGS";
            this.grpConfig.TranslationString = "MAIN.LABEL.CONFIGS";
            // 
            // pnlConfigInner
            // 
            this.pnlConfigInner.Controls.Add(this.lstConfigs);
            this.pnlConfigInner.Controls.Add(this.pnlConfigButtons);
            this.pnlConfigInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigInner.Location = new System.Drawing.Point(3, 15);
            this.pnlConfigInner.Name = "pnlConfigInner";
            this.pnlConfigInner.Size = new System.Drawing.Size(173, 283);
            this.pnlConfigInner.TabIndex = 4;
            // 
            // lstConfigs
            // 
            this.lstConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConfigs.FormattingEnabled = true;
            this.lstConfigs.ItemHeight = 12;
            this.lstConfigs.Location = new System.Drawing.Point(0, 0);
            this.lstConfigs.Name = "lstConfigs";
            this.lstConfigs.Size = new System.Drawing.Size(173, 256);
            this.lstConfigs.TabIndex = 0;
            this.lstConfigs.SelectedIndexChanged += new System.EventHandler(this.lstConfigs_SelectedIndexChanged);
            // 
            // pnlConfigButtons
            // 
            this.pnlConfigButtons.Controls.Add(this.btnNewConfig);
            this.pnlConfigButtons.Controls.Add(this.btnRemoveConfig);
            this.pnlConfigButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConfigButtons.Location = new System.Drawing.Point(0, 256);
            this.pnlConfigButtons.Name = "pnlConfigButtons";
            this.pnlConfigButtons.Size = new System.Drawing.Size(173, 27);
            this.pnlConfigButtons.TabIndex = 3;
            // 
            // btnNewConfig
            // 
            this.btnNewConfig.DefaultString = null;
            this.btnNewConfig.Location = new System.Drawing.Point(3, 3);
            this.btnNewConfig.Name = "btnNewConfig";
            this.btnNewConfig.Size = new System.Drawing.Size(75, 21);
            this.btnNewConfig.TabIndex = 1;
            this.btnNewConfig.Text = "MAIN.BUTTON.NEW";
            this.btnNewConfig.TranslationString = "MAIN.BUTTON.NEW";
            this.btnNewConfig.UseVisualStyleBackColor = true;
            this.btnNewConfig.Click += new System.EventHandler(this.btnNewConfig_Click);
            // 
            // btnRemoveConfig
            // 
            this.btnRemoveConfig.DefaultString = null;
            this.btnRemoveConfig.Location = new System.Drawing.Point(95, 3);
            this.btnRemoveConfig.Name = "btnRemoveConfig";
            this.btnRemoveConfig.Size = new System.Drawing.Size(75, 21);
            this.btnRemoveConfig.TabIndex = 2;
            this.btnRemoveConfig.Text = "MAIN.BUTTON.REMOVE";
            this.btnRemoveConfig.TranslationString = "MAIN.BUTTON.REMOVE";
            this.btnRemoveConfig.UseVisualStyleBackColor = true;
            this.btnRemoveConfig.Click += new System.EventHandler(this.btnRemoveConfig_Click);
            // 
            // chkChangeThemeColour
            // 
            this.chkChangeThemeColour.AutoSize = true;
            this.chkChangeThemeColour.DefaultString = null;
            this.chkChangeThemeColour.Location = new System.Drawing.Point(6, 119);
            this.chkChangeThemeColour.Name = "chkChangeThemeColour";
            this.chkChangeThemeColour.Size = new System.Drawing.Size(179, 16);
            this.chkChangeThemeColour.TabIndex = 13;
            this.chkChangeThemeColour.Text = "MAIN.LABEL.THEME_COLOUR";
            this.chkChangeThemeColour.TranslationString = "MAIN.LABEL.THEME_COLOUR";
            this.chkChangeThemeColour.UseVisualStyleBackColor = true;
            // 
            // chkFade
            // 
            this.chkFade.AutoSize = true;
            this.chkFade.DefaultString = null;
            this.chkFade.Location = new System.Drawing.Point(6, 78);
            this.chkFade.Name = "chkFade";
            this.chkFade.Size = new System.Drawing.Size(121, 16);
            this.chkFade.TabIndex = 11;
            this.chkFade.Text = "MAIN.LABEL.FADE";
            this.chkFade.TranslationString = "MAIN.LABEL.FADE";
            this.chkFade.UseVisualStyleBackColor = true;
            // 
            // chkRandomise
            // 
            this.chkRandomise.AutoSize = true;
            this.chkRandomise.DefaultString = null;
            this.chkRandomise.Location = new System.Drawing.Point(6, 56);
            this.chkRandomise.Name = "chkRandomise";
            this.chkRandomise.Size = new System.Drawing.Size(157, 16);
            this.chkRandomise.TabIndex = 10;
            this.chkRandomise.Text = "MAIN.LABEL.RANDOMISE";
            this.chkRandomise.TranslationString = "MAIN.LABEL.RANDOMISE";
            this.chkRandomise.UseVisualStyleBackColor = true;
            this.chkRandomise.CheckedChanged += new System.EventHandler(this.chkRandomise_CheckedChanged);
            // 
            // lblNextChange
            // 
            this.lblNextChange.AutoSize = true;
            this.lblNextChange.DefaultString = "NEXT_CHANGE: {0:hh\\\\:mm\\\\:ss}";
            this.lblNextChange.Location = new System.Drawing.Point(3, 169);
            this.lblNextChange.Name = "lblNextChange";
            this.lblNextChange.Parameters = new object[0];
            this.lblNextChange.Size = new System.Drawing.Size(152, 12);
            this.lblNextChange.TabIndex = 9;
            this.lblNextChange.Text = "MAIN.LABEL.NEXT_CHANGE";
            this.lblNextChange.TranslationString = "MAIN.LABEL.NEXT_CHANGE";
            // 
            // btnTiming
            // 
            this.btnTiming.DefaultString = null;
            this.btnTiming.Location = new System.Drawing.Point(6, 3);
            this.btnTiming.Name = "btnTiming";
            this.btnTiming.Size = new System.Drawing.Size(75, 21);
            this.btnTiming.TabIndex = 8;
            this.btnTiming.Text = "MAIN.BUTTON.TIMING";
            this.btnTiming.TranslationString = "MAIN.BUTTON.TIMING";
            this.btnTiming.UseVisualStyleBackColor = true;
            this.btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // btnTray
            // 
            this.btnTray.DefaultString = null;
            this.btnTray.Location = new System.Drawing.Point(98, 3);
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(75, 21);
            this.btnTray.TabIndex = 5;
            this.btnTray.Text = "MAIN.BUTTON.TRAY";
            this.btnTray.TranslationString = "MAIN.BUTTON.TRAY";
            this.btnTray.UseVisualStyleBackColor = true;
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btnReload
            // 
            this.btnReload.DefaultString = null;
            this.btnReload.Location = new System.Drawing.Point(6, 30);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 21);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "MAIN.BUTTON.RELOAD";
            this.btnReload.TranslationString = "MAIN.BUTTON.RELOAD";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.DefaultString = null;
            this.btnSave.Location = new System.Drawing.Point(98, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "MAIN.BUTTON.SAVE";
            this.btnSave.TranslationString = "MAIN.BUTTON.SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.DefaultString = null;
            this.chkStartup.Location = new System.Drawing.Point(6, 99);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(143, 16);
            this.chkStartup.TabIndex = 4;
            this.chkStartup.Text = "MAIN.LABEL.STARTUP";
            this.chkStartup.TranslationString = "MAIN.LABEL.STARTUP";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // MainTitle
            // 
            this.MainTitle.DefaultString = null;
            this.MainTitle.ParentForm = this;
            this.MainTitle.TranslationString = "TITLE.MAIN";
            // 
            // trtToolTips
            // 
            this.trtToolTips.DefaultStrings = ((System.Collections.Generic.Dictionary<System.Windows.Forms.Control, string>)(resources.GetObject("trtToolTips.DefaultStrings")));
            this.trtToolTips.ToolTips = this.ToolTips;
            this.trtToolTips.TranslationStrings = ((System.Collections.Generic.Dictionary<System.Windows.Forms.Control, string>)(resources.GetObject("trtToolTips.TranslationStrings")));
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "MainForm";
            this.Text = "TITLE.MAIN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.pnlRight.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlBottomRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.grpImages.ResumeLayout(false);
            this.pnlImagesInner.ResumeLayout(false);
            this.pnlFileList.ResumeLayout(false);
            this.pnlImageButtons.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.pnlConfigInner.ResumeLayout(false);
            this.pnlConfigButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HighlightListBox lstImages;
        private WallChanger.Translation.Controls.TranslatableButton btnAddImage;
        private WallChanger.Translation.Controls.TranslatableButton btnRemoveImage;
        private System.Windows.Forms.OpenFileDialog ofdAdd;
        private System.Windows.Forms.NotifyIcon noiTray;
        private WallChanger.Translation.Controls.TranslatableCheckBox chkStartup;
        private WallChanger.Translation.Controls.TranslatableButton btnTray;
        private WallChanger.Translation.Controls.TranslatableButton btnReload;
        private WallChanger.Translation.Controls.TranslatableButton btnSave;
        private WallChanger.Translation.Controls.TranslatableButton btnTiming;
        private WallChanger.Translation.Controls.TranslatableGroupBox grpConfig;
        private WallChanger.Translation.Controls.TranslatableButton btnRemoveConfig;
        private WallChanger.Translation.Controls.TranslatableButton btnNewConfig;
        private System.Windows.Forms.ListBox lstConfigs;
        private WallChanger.Translation.Controls.TranslatableGroupBoxFormat grpImages;
        private System.Windows.Forms.ToolTip ToolTips;
        private WallChanger.Translation.Controls.TranslatableButton btnClear;
        private WallChanger.Translation.Controls.TranslatableButton btnMoveDown;
        private WallChanger.Translation.Controls.TranslatableButton btnMoveUp;
        private System.Windows.Forms.Panel pnlConfigButtons;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTopRight;
        private System.Windows.Forms.Panel pnlBottomRight;
        private System.Windows.Forms.Panel pnlConfigInner;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.Panel pnlImageButtons;
        private System.Windows.Forms.Panel pnlImagesInner;
        private System.Windows.Forms.Panel pnlFileList;
        private WallChanger.Translation.Controls.TranslatableButton btnLibrary;
        private WallChanger.Translation.Controls.TranslatableButton btnAddToLibrary;
        private WallChanger.Translation.Controls.TranslatableLabelFormat lblNextChange;
        private WallChanger.Translation.Controls.TranslatableButton btnLanguage;
        private WallChanger.Translation.Controls.TranslatableButton btnSettings;
        private WallChanger.Translation.Controls.TranslatableCheckBox chkRandomise;
        private WallChanger.Translation.Controls.TranslatableCheckBox chkFade;
        private WallChanger.Translation.Controls.TranslatableComboBox cmbWallpaperStyle;
        private WallChanger.Translation.Controls.TranslatableButton btnProcessing;
        private WallChanger.Translation.Controls.TranslatableCheckBox chkChangeThemeColour;
        private Translation.Controls.TranslatableTitle MainTitle;
        private Translation.Controls.TranslatableTooltips trtToolTips;
    }
}

