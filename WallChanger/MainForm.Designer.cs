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
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.ofdAdd = new System.Windows.Forms.OpenFileDialog();
            this.noiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.btnTray = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTiming = new System.Windows.Forms.Button();
            this.grbConfig = new System.Windows.Forms.GroupBox();
            this.btnRemoveConfig = new System.Windows.Forms.Button();
            this.btnNewConfig = new System.Windows.Forms.Button();
            this.lstConfigs = new System.Windows.Forms.ListBox();
            this.grpImages = new System.Windows.Forms.GroupBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.grbConfig.SuspendLayout();
            this.grpImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(6, 19);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(545, 446);
            this.lstFiles.TabIndex = 0;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddImage.Location = new System.Drawing.Point(557, 19);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(24, 24);
            this.btnAddImage.TabIndex = 2;
            this.ToolTips.SetToolTip(this.btnAddImage, "Add images...");
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnDeleteImage.Location = new System.Drawing.Point(557, 49);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteImage.TabIndex = 3;
            this.ToolTips.SetToolTip(this.btnDeleteImage, "Remove selected images.");
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
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
            this.chkStartup.Location = new System.Drawing.Point(641, 470);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(98, 17);
            this.chkStartup.TabIndex = 4;
            this.chkStartup.Text = "Run on Startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // btnTray
            // 
            this.btnTray.Location = new System.Drawing.Point(692, 412);
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(75, 23);
            this.btnTray.TabIndex = 5;
            this.btnTray.Text = "To Tray";
            this.btnTray.UseVisualStyleBackColor = true;
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(611, 441);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(692, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTiming
            // 
            this.btnTiming.Location = new System.Drawing.Point(611, 412);
            this.btnTiming.Name = "btnTiming";
            this.btnTiming.Size = new System.Drawing.Size(75, 23);
            this.btnTiming.TabIndex = 8;
            this.btnTiming.Text = "Timing";
            this.btnTiming.UseVisualStyleBackColor = true;
            this.btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // grbConfig
            // 
            this.grbConfig.Controls.Add(this.btnRemoveConfig);
            this.grbConfig.Controls.Add(this.btnNewConfig);
            this.grbConfig.Controls.Add(this.lstConfigs);
            this.grbConfig.Location = new System.Drawing.Point(605, 12);
            this.grbConfig.Name = "grbConfig";
            this.grbConfig.Size = new System.Drawing.Size(167, 394);
            this.grbConfig.TabIndex = 9;
            this.grbConfig.TabStop = false;
            this.grbConfig.Text = "Configs";
            // 
            // btnRemoveConfig
            // 
            this.btnRemoveConfig.Location = new System.Drawing.Point(87, 365);
            this.btnRemoveConfig.Name = "btnRemoveConfig";
            this.btnRemoveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveConfig.TabIndex = 2;
            this.btnRemoveConfig.Text = "Remove";
            this.btnRemoveConfig.UseVisualStyleBackColor = true;
            this.btnRemoveConfig.Click += new System.EventHandler(this.btnRemoveConfig_Click);
            // 
            // btnNewConfig
            // 
            this.btnNewConfig.Location = new System.Drawing.Point(6, 365);
            this.btnNewConfig.Name = "btnNewConfig";
            this.btnNewConfig.Size = new System.Drawing.Size(75, 23);
            this.btnNewConfig.TabIndex = 1;
            this.btnNewConfig.Text = "New";
            this.btnNewConfig.UseVisualStyleBackColor = true;
            this.btnNewConfig.Click += new System.EventHandler(this.btnNewConfig_Click);
            // 
            // lstConfigs
            // 
            this.lstConfigs.FormattingEnabled = true;
            this.lstConfigs.Location = new System.Drawing.Point(6, 19);
            this.lstConfigs.Name = "lstConfigs";
            this.lstConfigs.Size = new System.Drawing.Size(155, 342);
            this.lstConfigs.TabIndex = 0;
            this.lstConfigs.SelectedIndexChanged += new System.EventHandler(this.lstConfigs_SelectedIndexChanged);
            // 
            // grpImages
            // 
            this.grpImages.Controls.Add(this.btnClear);
            this.grpImages.Controls.Add(this.btnMoveDown);
            this.grpImages.Controls.Add(this.btnMoveUp);
            this.grpImages.Controls.Add(this.lstFiles);
            this.grpImages.Controls.Add(this.btnDeleteImage);
            this.grpImages.Controls.Add(this.btnAddImage);
            this.grpImages.Location = new System.Drawing.Point(12, 12);
            this.grpImages.Name = "grpImages";
            this.grpImages.Size = new System.Drawing.Size(587, 472);
            this.grpImages.TabIndex = 10;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "Images";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::WallChanger.Properties.Resources.navigation_090_button;
            this.btnMoveUp.Location = new System.Drawing.Point(557, 79);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 4;
            this.ToolTips.SetToolTip(this.btnMoveUp, "Move selected images up.");
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::WallChanger.Properties.Resources.navigation_270_button;
            this.btnMoveDown.Location = new System.Drawing.Point(557, 109);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 5;
            this.ToolTips.SetToolTip(this.btnMoveDown, "Move selected images down.");
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClear.Location = new System.Drawing.Point(557, 139);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 6;
            this.ToolTips.SetToolTip(this.btnClear, "Clear images.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 495);
            this.Controls.Add(this.grpImages);
            this.Controls.Add(this.grbConfig);
            this.Controls.Add(this.btnTiming);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnTray);
            this.Name = "MainForm";
            this.Text = "Wall Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.grbConfig.ResumeLayout(false);
            this.grpImages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.OpenFileDialog ofdAdd;
        private System.Windows.Forms.NotifyIcon noiTray;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Button btnTray;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTiming;
        private System.Windows.Forms.GroupBox grbConfig;
        private System.Windows.Forms.Button btnRemoveConfig;
        private System.Windows.Forms.Button btnNewConfig;
        private System.Windows.Forms.ListBox lstConfigs;
        private System.Windows.Forms.GroupBox grpImages;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
    }
}

