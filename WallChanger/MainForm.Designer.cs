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
            this.lstImages = new System.Windows.Forms.ListBox();
            this.ofdAdd = new System.Windows.Forms.OpenFileDialog();
            this.noiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.btnTray = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTiming = new System.Windows.Forms.Button();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.pnlConfigInner = new System.Windows.Forms.Panel();
            this.lstConfigs = new System.Windows.Forms.ListBox();
            this.pnlConfigButtons = new System.Windows.Forms.Panel();
            this.btnNewConfig = new System.Windows.Forms.Button();
            this.btnRemoveConfig = new System.Windows.Forms.Button();
            this.grpImages = new System.Windows.Forms.GroupBox();
            this.pnlImagesInner = new System.Windows.Forms.Panel();
            this.pnlFileList = new System.Windows.Forms.Panel();
            this.pnlImageButtons = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.btnAddToLibrary = new System.Windows.Forms.Button();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.chkFade = new System.Windows.Forms.CheckBox();
            this.chkRandomise = new System.Windows.Forms.CheckBox();
            this.lblNextChange = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.grpConfig.SuspendLayout();
            this.pnlConfigInner.SuspendLayout();
            this.pnlConfigButtons.SuspendLayout();
            this.grpImages.SuspendLayout();
            this.pnlImagesInner.SuspendLayout();
            this.pnlFileList.SuspendLayout();
            this.pnlImageButtons.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstImages
            // 
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.FormattingEnabled = true;
            this.lstImages.HorizontalScrollbar = true;
            this.lstImages.Location = new System.Drawing.Point(0, 0);
            this.lstImages.Name = "lstImages";
            this.lstImages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImages.Size = new System.Drawing.Size(561, 513);
            this.lstImages.TabIndex = 0;
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
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(6, 107);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(149, 17);
            this.chkStartup.TabIndex = 4;
            this.chkStartup.Text = "MAIN_LABEL_STARTUP";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // btnTray
            // 
            this.btnTray.Location = new System.Drawing.Point(98, 3);
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(75, 23);
            this.btnTray.TabIndex = 5;
            this.btnTray.Text = "MAIN_BUTTON_TRAY";
            this.btnTray.UseVisualStyleBackColor = true;
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(6, 32);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "MAIN_BUTTON_RELOAD";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "MAIN_BUTTON_SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTiming
            // 
            this.btnTiming.Location = new System.Drawing.Point(6, 3);
            this.btnTiming.Name = "btnTiming";
            this.btnTiming.Size = new System.Drawing.Size(75, 23);
            this.btnTiming.TabIndex = 8;
            this.btnTiming.Text = "MAIN_BUTTON_TIMING";
            this.btnTiming.UseVisualStyleBackColor = true;
            this.btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.pnlConfigInner);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfig.Location = new System.Drawing.Point(0, 0);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(179, 382);
            this.grpConfig.TabIndex = 9;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "MAIN_LABEL_CONFIGS";
            // 
            // pnlConfigInner
            // 
            this.pnlConfigInner.Controls.Add(this.lstConfigs);
            this.pnlConfigInner.Controls.Add(this.pnlConfigButtons);
            this.pnlConfigInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigInner.Location = new System.Drawing.Point(3, 16);
            this.pnlConfigInner.Name = "pnlConfigInner";
            this.pnlConfigInner.Size = new System.Drawing.Size(173, 363);
            this.pnlConfigInner.TabIndex = 4;
            // 
            // lstConfigs
            // 
            this.lstConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConfigs.FormattingEnabled = true;
            this.lstConfigs.Location = new System.Drawing.Point(0, 0);
            this.lstConfigs.Name = "lstConfigs";
            this.lstConfigs.Size = new System.Drawing.Size(173, 334);
            this.lstConfigs.TabIndex = 0;
            this.lstConfigs.SelectedIndexChanged += new System.EventHandler(this.lstConfigs_SelectedIndexChanged);
            // 
            // pnlConfigButtons
            // 
            this.pnlConfigButtons.Controls.Add(this.btnNewConfig);
            this.pnlConfigButtons.Controls.Add(this.btnRemoveConfig);
            this.pnlConfigButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConfigButtons.Location = new System.Drawing.Point(0, 334);
            this.pnlConfigButtons.Name = "pnlConfigButtons";
            this.pnlConfigButtons.Size = new System.Drawing.Size(173, 29);
            this.pnlConfigButtons.TabIndex = 3;
            // 
            // btnNewConfig
            // 
            this.btnNewConfig.Location = new System.Drawing.Point(3, 3);
            this.btnNewConfig.Name = "btnNewConfig";
            this.btnNewConfig.Size = new System.Drawing.Size(75, 23);
            this.btnNewConfig.TabIndex = 1;
            this.btnNewConfig.Text = "MAIN_BUTTON_NEW";
            this.btnNewConfig.UseVisualStyleBackColor = true;
            this.btnNewConfig.Click += new System.EventHandler(this.btnNewConfig_Click);
            // 
            // btnRemoveConfig
            // 
            this.btnRemoveConfig.Location = new System.Drawing.Point(95, 3);
            this.btnRemoveConfig.Name = "btnRemoveConfig";
            this.btnRemoveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveConfig.TabIndex = 2;
            this.btnRemoveConfig.Text = "MAIN_BUTTON_REMOVE";
            this.btnRemoveConfig.UseVisualStyleBackColor = true;
            this.btnRemoveConfig.Click += new System.EventHandler(this.btnRemoveConfig_Click);
            // 
            // grpImages
            // 
            this.grpImages.Controls.Add(this.pnlImagesInner);
            this.grpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImages.Location = new System.Drawing.Point(0, 0);
            this.grpImages.Name = "grpImages";
            this.grpImages.Size = new System.Drawing.Size(597, 532);
            this.grpImages.TabIndex = 10;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "MAIN_LABEL_IMAGES";
            // 
            // pnlImagesInner
            // 
            this.pnlImagesInner.Controls.Add(this.pnlFileList);
            this.pnlImagesInner.Controls.Add(this.pnlImageButtons);
            this.pnlImagesInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagesInner.Location = new System.Drawing.Point(3, 16);
            this.pnlImagesInner.Name = "pnlImagesInner";
            this.pnlImagesInner.Size = new System.Drawing.Size(591, 513);
            this.pnlImagesInner.TabIndex = 8;
            // 
            // pnlFileList
            // 
            this.pnlFileList.Controls.Add(this.lstImages);
            this.pnlFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileList.Location = new System.Drawing.Point(0, 0);
            this.pnlFileList.Name = "pnlFileList";
            this.pnlFileList.Size = new System.Drawing.Size(561, 513);
            this.pnlFileList.TabIndex = 8;
            // 
            // pnlImageButtons
            // 
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
            this.pnlImageButtons.Size = new System.Drawing.Size(30, 513);
            this.pnlImageButtons.TabIndex = 7;
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::WallChanger.Properties.Resources.gear;
            this.btnSettings.Location = new System.Drawing.Point(3, 243);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(24, 24);
            this.btnSettings.TabIndex = 10;
            this.ToolTips.SetToolTip(this.btnSettings, "MAIN_TOOLTIP_SETTINGS");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.Image = global::WallChanger.Properties.Resources.language;
            this.btnLanguage.Location = new System.Drawing.Point(3, 213);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(24, 24);
            this.btnLanguage.TabIndex = 9;
            this.ToolTips.SetToolTip(this.btnLanguage, "MAIN_TOOLTIP_LANGUAGE");
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnAddToLibrary
            // 
            this.btnAddToLibrary.Image = global::WallChanger.Properties.Resources.address_book__arrow;
            this.btnAddToLibrary.Location = new System.Drawing.Point(3, 183);
            this.btnAddToLibrary.Name = "btnAddToLibrary";
            this.btnAddToLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnAddToLibrary.TabIndex = 8;
            this.ToolTips.SetToolTip(this.btnAddToLibrary, "MAIN_TOOLTIP_LIBRARY_ADD");
            this.btnAddToLibrary.UseVisualStyleBackColor = true;
            this.btnAddToLibrary.Click += new System.EventHandler(this.btnAddToLibrary_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.Image = global::WallChanger.Properties.Resources.address_book;
            this.btnLibrary.Location = new System.Drawing.Point(3, 153);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(24, 24);
            this.btnLibrary.TabIndex = 7;
            this.ToolTips.SetToolTip(this.btnLibrary, "MAIN_TOOLTIP_LIBRARY");
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddImage.Location = new System.Drawing.Point(3, 3);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(24, 24);
            this.btnAddImage.TabIndex = 2;
            this.ToolTips.SetToolTip(this.btnAddImage, "MAIN_TOOLTIP_ADD");
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClear.Location = new System.Drawing.Point(3, 123);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 6;
            this.ToolTips.SetToolTip(this.btnClear, "MAIN_TOOLTIP_CLEAR");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveImage.Location = new System.Drawing.Point(3, 33);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveImage.TabIndex = 3;
            this.ToolTips.SetToolTip(this.btnRemoveImage, "MAIN_TOOLTIP_REMOVE");
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::WallChanger.Properties.Resources.navigation_270_button;
            this.btnMoveDown.Location = new System.Drawing.Point(3, 93);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 5;
            this.ToolTips.SetToolTip(this.btnMoveDown, "MAIN_TOOLTIP_MOVE_DOWN");
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::WallChanger.Properties.Resources.navigation_090_button;
            this.btnMoveUp.Location = new System.Drawing.Point(3, 63);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 4;
            this.ToolTips.SetToolTip(this.btnMoveUp, "MAIN_TOOLTIP_MOVE_UP");
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTopRight);
            this.pnlRight.Controls.Add(this.pnlBottomRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(605, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(179, 532);
            this.pnlRight.TabIndex = 11;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.grpConfig);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRight.Location = new System.Drawing.Point(0, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(179, 382);
            this.pnlTopRight.TabIndex = 13;
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.chkFade);
            this.pnlBottomRight.Controls.Add(this.chkRandomise);
            this.pnlBottomRight.Controls.Add(this.lblNextChange);
            this.pnlBottomRight.Controls.Add(this.btnTiming);
            this.pnlBottomRight.Controls.Add(this.btnTray);
            this.pnlBottomRight.Controls.Add(this.btnReload);
            this.pnlBottomRight.Controls.Add(this.btnSave);
            this.pnlBottomRight.Controls.Add(this.chkStartup);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomRight.Location = new System.Drawing.Point(0, 382);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(179, 150);
            this.pnlBottomRight.TabIndex = 12;
            // 
            // chkFade
            // 
            this.chkFade.AutoSize = true;
            this.chkFade.Location = new System.Drawing.Point(6, 84);
            this.chkFade.Name = "chkFade";
            this.chkFade.Size = new System.Drawing.Size(126, 17);
            this.chkFade.TabIndex = 11;
            this.chkFade.Text = "MAIN_LABEL_FADE";
            this.chkFade.UseVisualStyleBackColor = true;
            // 
            // chkRandomise
            // 
            this.chkRandomise.AutoSize = true;
            this.chkRandomise.Location = new System.Drawing.Point(6, 61);
            this.chkRandomise.Name = "chkRandomise";
            this.chkRandomise.Size = new System.Drawing.Size(163, 17);
            this.chkRandomise.TabIndex = 10;
            this.chkRandomise.Text = "MAIN_LABEL_RANDOMISE";
            this.chkRandomise.UseVisualStyleBackColor = true;
            this.chkRandomise.CheckedChanged += new System.EventHandler(this.chkRandomise_CheckedChanged);
            // 
            // lblNextChange
            // 
            this.lblNextChange.AutoSize = true;
            this.lblNextChange.Location = new System.Drawing.Point(3, 127);
            this.lblNextChange.Name = "lblNextChange";
            this.lblNextChange.Size = new System.Drawing.Size(159, 13);
            this.lblNextChange.TabIndex = 9;
            this.lblNextChange.Text = "MAIN_LABEL_NEXT_CHANGE";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpImages);
            this.pnlLeft.Controls.Add(this.pnlSpacer);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(605, 532);
            this.pnlLeft.TabIndex = 12;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpacer.Location = new System.Drawing.Point(597, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(8, 532);
            this.pnlSpacer.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "MainForm";
            this.Text = "Wall Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.grpConfig.ResumeLayout(false);
            this.pnlConfigInner.ResumeLayout(false);
            this.pnlConfigButtons.ResumeLayout(false);
            this.grpImages.ResumeLayout(false);
            this.pnlImagesInner.ResumeLayout(false);
            this.pnlFileList.ResumeLayout(false);
            this.pnlImageButtons.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlBottomRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.OpenFileDialog ofdAdd;
        private System.Windows.Forms.NotifyIcon noiTray;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Button btnTray;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTiming;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.Button btnRemoveConfig;
        private System.Windows.Forms.Button btnNewConfig;
        private System.Windows.Forms.ListBox lstConfigs;
        private System.Windows.Forms.GroupBox grpImages;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
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
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.Button btnAddToLibrary;
        private System.Windows.Forms.Label lblNextChange;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.CheckBox chkRandomise;
        private System.Windows.Forms.CheckBox chkFade;
    }
}

