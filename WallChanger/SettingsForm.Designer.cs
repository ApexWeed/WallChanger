namespace WallChanger
{
    partial class SettingsForm
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
            this.grpCompression = new System.Windows.Forms.GroupBox();
            this.lblCompressionWarning = new System.Windows.Forms.Label();
            this.lblCompressionLevel = new System.Windows.Forms.Label();
            this.cmbCompressionLevel = new System.Windows.Forms.ComboBox();
            this.grpDefaults = new System.Windows.Forms.GroupBox();
            this.lblDefaultWallpaperStyle = new System.Windows.Forms.Label();
            this.cmbDefaultWallpaperStyle = new System.Windows.Forms.ComboBox();
            this.chkDefaultFading = new System.Windows.Forms.CheckBox();
            this.chkDefaultRandomise = new System.Windows.Forms.CheckBox();
            this.btnChangeDefaultTiming = new System.Windows.Forms.Button();
            this.lblDefaultInterval = new System.Windows.Forms.Label();
            this.lblDefaultOffset = new System.Windows.Forms.Label();
            this.lblHighlightMode = new System.Windows.Forms.Label();
            this.cmbHighlightMode = new System.Windows.Forms.ComboBox();
            this.grpHighlight = new System.Windows.Forms.GroupBox();
            this.btnHighlightColour = new System.Windows.Forms.Button();
            this.picHighlightColour = new System.Windows.Forms.PictureBox();
            this.lblHighlightColour = new System.Windows.Forms.Label();
            this.cdgColourDialog = new System.Windows.Forms.ColorDialog();
            this.chkGlobalRandomise = new System.Windows.Forms.CheckBox();
            this.chkGlobalFading = new System.Windows.Forms.CheckBox();
            this.chkGlobalWallpaperStyle = new System.Windows.Forms.CheckBox();
            this.grpCompression.SuspendLayout();
            this.grpDefaults.SuspendLayout();
            this.grpHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHighlightColour)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCompression
            // 
            this.grpCompression.Controls.Add(this.lblCompressionWarning);
            this.grpCompression.Controls.Add(this.lblCompressionLevel);
            this.grpCompression.Controls.Add(this.cmbCompressionLevel);
            this.grpCompression.Location = new System.Drawing.Point(12, 11);
            this.grpCompression.Name = "grpCompression";
            this.grpCompression.Size = new System.Drawing.Size(741, 81);
            this.grpCompression.TabIndex = 0;
            this.grpCompression.TabStop = false;
            this.grpCompression.Text = "SETTINGS_LABEL_COMPRESSION";
            // 
            // lblCompressionWarning
            // 
            this.lblCompressionWarning.AutoSize = true;
            this.lblCompressionWarning.Location = new System.Drawing.Point(6, 52);
            this.lblCompressionWarning.Name = "lblCompressionWarning";
            this.lblCompressionWarning.Size = new System.Drawing.Size(238, 12);
            this.lblCompressionWarning.TabIndex = 2;
            this.lblCompressionWarning.Text = "SETTINGS_LABEL_COMPRESSION_WARNING";
            // 
            // lblCompressionLevel
            // 
            this.lblCompressionLevel.AutoSize = true;
            this.lblCompressionLevel.Location = new System.Drawing.Point(6, 15);
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            this.lblCompressionLevel.Size = new System.Drawing.Size(220, 12);
            this.lblCompressionLevel.TabIndex = 1;
            this.lblCompressionLevel.Text = "SETTINGS_LABEL_COMPRESSION_LEVEL";
            // 
            // cmbCompressionLevel
            // 
            this.cmbCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompressionLevel.FormattingEnabled = true;
            this.cmbCompressionLevel.Location = new System.Drawing.Point(9, 30);
            this.cmbCompressionLevel.Name = "cmbCompressionLevel";
            this.cmbCompressionLevel.Size = new System.Drawing.Size(726, 20);
            this.cmbCompressionLevel.TabIndex = 0;
            this.cmbCompressionLevel.SelectedValueChanged += new System.EventHandler(this.cmbCompressionLevel_SelectedValueChanged);
            // 
            // grpDefaults
            // 
            this.grpDefaults.Controls.Add(this.chkGlobalWallpaperStyle);
            this.grpDefaults.Controls.Add(this.chkGlobalFading);
            this.grpDefaults.Controls.Add(this.chkGlobalRandomise);
            this.grpDefaults.Controls.Add(this.lblDefaultWallpaperStyle);
            this.grpDefaults.Controls.Add(this.cmbDefaultWallpaperStyle);
            this.grpDefaults.Controls.Add(this.chkDefaultFading);
            this.grpDefaults.Controls.Add(this.chkDefaultRandomise);
            this.grpDefaults.Controls.Add(this.btnChangeDefaultTiming);
            this.grpDefaults.Controls.Add(this.lblDefaultInterval);
            this.grpDefaults.Controls.Add(this.lblDefaultOffset);
            this.grpDefaults.Location = new System.Drawing.Point(12, 98);
            this.grpDefaults.Name = "grpDefaults";
            this.grpDefaults.Size = new System.Drawing.Size(741, 140);
            this.grpDefaults.TabIndex = 4;
            this.grpDefaults.TabStop = false;
            this.grpDefaults.Text = "SETTINGS_LABEL_DEFAULT";
            // 
            // lblDefaultWallpaperStyle
            // 
            this.lblDefaultWallpaperStyle.AutoSize = true;
            this.lblDefaultWallpaperStyle.Location = new System.Drawing.Point(6, 86);
            this.lblDefaultWallpaperStyle.Name = "lblDefaultWallpaperStyle";
            this.lblDefaultWallpaperStyle.Size = new System.Drawing.Size(261, 12);
            this.lblDefaultWallpaperStyle.TabIndex = 7;
            this.lblDefaultWallpaperStyle.Text = "SETTINGS_LABEL_DEFAULT_WALLPAPER_STYLE";
            // 
            // cmbDefaultWallpaperStyle
            // 
            this.cmbDefaultWallpaperStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultWallpaperStyle.FormattingEnabled = true;
            this.cmbDefaultWallpaperStyle.Location = new System.Drawing.Point(9, 101);
            this.cmbDefaultWallpaperStyle.Name = "cmbDefaultWallpaperStyle";
            this.cmbDefaultWallpaperStyle.Size = new System.Drawing.Size(726, 20);
            this.cmbDefaultWallpaperStyle.TabIndex = 6;
            this.cmbDefaultWallpaperStyle.SelectedValueChanged += new System.EventHandler(this.cmbDefaultWallpaperStyle_SelectedValueChanged);
            // 
            // chkDefaultFading
            // 
            this.chkDefaultFading.AutoSize = true;
            this.chkDefaultFading.Location = new System.Drawing.Point(9, 63);
            this.chkDefaultFading.Name = "chkDefaultFading";
            this.chkDefaultFading.Size = new System.Drawing.Size(218, 16);
            this.chkDefaultFading.TabIndex = 5;
            this.chkDefaultFading.Text = "SETTINGS_LABEL_DEFAULT_FADING";
            this.chkDefaultFading.UseVisualStyleBackColor = true;
            this.chkDefaultFading.CheckedChanged += new System.EventHandler(this.chkDefaultFade_CheckedChanged);
            // 
            // chkDefaultRandomise
            // 
            this.chkDefaultRandomise.AutoSize = true;
            this.chkDefaultRandomise.Location = new System.Drawing.Point(9, 42);
            this.chkDefaultRandomise.Name = "chkDefaultRandomise";
            this.chkDefaultRandomise.Size = new System.Drawing.Size(242, 16);
            this.chkDefaultRandomise.TabIndex = 4;
            this.chkDefaultRandomise.Text = "SETTINGS_LABEL_DEFAULT_RANDOMISE";
            this.chkDefaultRandomise.UseVisualStyleBackColor = true;
            this.chkDefaultRandomise.CheckedChanged += new System.EventHandler(this.chkDefaultRandomise_CheckedChanged);
            // 
            // btnChangeDefaultTiming
            // 
            this.btnChangeDefaultTiming.Location = new System.Drawing.Point(660, 15);
            this.btnChangeDefaultTiming.Name = "btnChangeDefaultTiming";
            this.btnChangeDefaultTiming.Size = new System.Drawing.Size(75, 21);
            this.btnChangeDefaultTiming.TabIndex = 3;
            this.btnChangeDefaultTiming.Text = "SETTINGS_BUTTON_DEFAULT_TIMING";
            this.btnChangeDefaultTiming.UseVisualStyleBackColor = true;
            this.btnChangeDefaultTiming.Click += new System.EventHandler(this.btnChangeDefaultTiming_Click);
            // 
            // lblDefaultInterval
            // 
            this.lblDefaultInterval.AutoSize = true;
            this.lblDefaultInterval.Location = new System.Drawing.Point(6, 27);
            this.lblDefaultInterval.Name = "lblDefaultInterval";
            this.lblDefaultInterval.Size = new System.Drawing.Size(282, 12);
            this.lblDefaultInterval.TabIndex = 2;
            this.lblDefaultInterval.Text = "SETTINGS_LABEL_WALLPAPER_DEFAULT_INTERVAL";
            // 
            // lblDefaultOffset
            // 
            this.lblDefaultOffset.AutoSize = true;
            this.lblDefaultOffset.Location = new System.Drawing.Point(6, 15);
            this.lblDefaultOffset.Name = "lblDefaultOffset";
            this.lblDefaultOffset.Size = new System.Drawing.Size(270, 12);
            this.lblDefaultOffset.TabIndex = 1;
            this.lblDefaultOffset.Text = "SETTINGS_LABEL_WALLPAPER_DEFAULT_OFFSET";
            // 
            // lblHighlightMode
            // 
            this.lblHighlightMode.AutoSize = true;
            this.lblHighlightMode.Location = new System.Drawing.Point(6, 15);
            this.lblHighlightMode.Name = "lblHighlightMode";
            this.lblHighlightMode.Size = new System.Drawing.Size(197, 12);
            this.lblHighlightMode.TabIndex = 7;
            this.lblHighlightMode.Text = "SETTINGS_LABEL_HIGHLIGHT_MODE";
            // 
            // cmbHighlightMode
            // 
            this.cmbHighlightMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHighlightMode.FormattingEnabled = true;
            this.cmbHighlightMode.Location = new System.Drawing.Point(9, 30);
            this.cmbHighlightMode.Name = "cmbHighlightMode";
            this.cmbHighlightMode.Size = new System.Drawing.Size(726, 20);
            this.cmbHighlightMode.TabIndex = 6;
            this.cmbHighlightMode.SelectedValueChanged += new System.EventHandler(this.cmbHighlightMode_SelectedValueChanged);
            // 
            // grpHighlight
            // 
            this.grpHighlight.Controls.Add(this.btnHighlightColour);
            this.grpHighlight.Controls.Add(this.picHighlightColour);
            this.grpHighlight.Controls.Add(this.lblHighlightColour);
            this.grpHighlight.Controls.Add(this.lblHighlightMode);
            this.grpHighlight.Controls.Add(this.cmbHighlightMode);
            this.grpHighlight.Location = new System.Drawing.Point(12, 244);
            this.grpHighlight.Name = "grpHighlight";
            this.grpHighlight.Size = new System.Drawing.Size(741, 135);
            this.grpHighlight.TabIndex = 5;
            this.grpHighlight.TabStop = false;
            this.grpHighlight.Text = "SETTINGS_LABEL_HIGHLIGHT";
            // 
            // btnHighlightColour
            // 
            this.btnHighlightColour.Location = new System.Drawing.Point(660, 54);
            this.btnHighlightColour.Name = "btnHighlightColour";
            this.btnHighlightColour.Size = new System.Drawing.Size(75, 21);
            this.btnHighlightColour.TabIndex = 8;
            this.btnHighlightColour.Text = "SETTINGS_BUTTON_HIGHLIGHT_COLOUR";
            this.btnHighlightColour.UseVisualStyleBackColor = true;
            this.btnHighlightColour.Click += new System.EventHandler(this.btnHighlightColour_Click);
            // 
            // picHighlightColour
            // 
            this.picHighlightColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHighlightColour.Location = new System.Drawing.Point(228, 54);
            this.picHighlightColour.Name = "picHighlightColour";
            this.picHighlightColour.Size = new System.Drawing.Size(426, 21);
            this.picHighlightColour.TabIndex = 9;
            this.picHighlightColour.TabStop = false;
            // 
            // lblHighlightColour
            // 
            this.lblHighlightColour.AutoSize = true;
            this.lblHighlightColour.Location = new System.Drawing.Point(6, 59);
            this.lblHighlightColour.Name = "lblHighlightColour";
            this.lblHighlightColour.Size = new System.Drawing.Size(211, 12);
            this.lblHighlightColour.TabIndex = 8;
            this.lblHighlightColour.Text = "SETTINGS_LABEL_HIGHLIGHT_COLOUR";
            // 
            // chkGlobalRandomise
            // 
            this.chkGlobalRandomise.AutoSize = true;
            this.chkGlobalRandomise.Location = new System.Drawing.Point(370, 42);
            this.chkGlobalRandomise.Name = "chkGlobalRandomise";
            this.chkGlobalRandomise.Size = new System.Drawing.Size(290, 16);
            this.chkGlobalRandomise.TabIndex = 8;
            this.chkGlobalRandomise.Text = "SETTINGS_LABEL_DEFAULT_GLOBAL_RANDOMISE";
            this.chkGlobalRandomise.UseVisualStyleBackColor = true;
            this.chkGlobalRandomise.CheckedChanged += new System.EventHandler(this.chkGlobalRandomise_CheckedChanged);
            // 
            // chkGlobalFading
            // 
            this.chkGlobalFading.AutoSize = true;
            this.chkGlobalFading.Location = new System.Drawing.Point(370, 63);
            this.chkGlobalFading.Name = "chkGlobalFading";
            this.chkGlobalFading.Size = new System.Drawing.Size(266, 16);
            this.chkGlobalFading.TabIndex = 9;
            this.chkGlobalFading.Text = "SETTINGS_LABEL_DEFAULT_GLOBAL_FADING";
            this.chkGlobalFading.UseVisualStyleBackColor = true;
            this.chkGlobalFading.CheckedChanged += new System.EventHandler(this.chkGlobalFading_CheckedChanged);
            // 
            // chkGlobalWallpaperStyle
            // 
            this.chkGlobalWallpaperStyle.AutoSize = true;
            this.chkGlobalWallpaperStyle.Location = new System.Drawing.Point(370, 85);
            this.chkGlobalWallpaperStyle.Name = "chkGlobalWallpaperStyle";
            this.chkGlobalWallpaperStyle.Size = new System.Drawing.Size(328, 16);
            this.chkGlobalWallpaperStyle.TabIndex = 10;
            this.chkGlobalWallpaperStyle.Text = "SETTINGS_LABEL_DEFAULT_GLOBAL_WALLPAPER_STYLE";
            this.chkGlobalWallpaperStyle.UseVisualStyleBackColor = true;
            this.chkGlobalWallpaperStyle.CheckedChanged += new System.EventHandler(this.chkGlobalWallpaperStyle_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 394);
            this.Controls.Add(this.grpHighlight);
            this.Controls.Add(this.grpDefaults);
            this.Controls.Add(this.grpCompression);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpCompression.ResumeLayout(false);
            this.grpCompression.PerformLayout();
            this.grpDefaults.ResumeLayout(false);
            this.grpDefaults.PerformLayout();
            this.grpHighlight.ResumeLayout(false);
            this.grpHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHighlightColour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCompression;
        private System.Windows.Forms.Label lblCompressionWarning;
        private System.Windows.Forms.Label lblCompressionLevel;
        private System.Windows.Forms.ComboBox cmbCompressionLevel;
        private System.Windows.Forms.GroupBox grpDefaults;
        private System.Windows.Forms.Label lblDefaultOffset;
        private System.Windows.Forms.Label lblDefaultInterval;
        private System.Windows.Forms.CheckBox chkDefaultFading;
        private System.Windows.Forms.CheckBox chkDefaultRandomise;
        private System.Windows.Forms.Button btnChangeDefaultTiming;
        private System.Windows.Forms.Label lblDefaultWallpaperStyle;
        private System.Windows.Forms.ComboBox cmbDefaultWallpaperStyle;
        private System.Windows.Forms.Label lblHighlightMode;
        private System.Windows.Forms.ComboBox cmbHighlightMode;
        private System.Windows.Forms.GroupBox grpHighlight;
        private System.Windows.Forms.Label lblHighlightColour;
        private System.Windows.Forms.Button btnHighlightColour;
        private System.Windows.Forms.PictureBox picHighlightColour;
        private System.Windows.Forms.ColorDialog cdgColourDialog;
        private System.Windows.Forms.CheckBox chkGlobalWallpaperStyle;
        private System.Windows.Forms.CheckBox chkGlobalFading;
        private System.Windows.Forms.CheckBox chkGlobalRandomise;
    }
}