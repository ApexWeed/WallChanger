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
            this.chkDefaultFade = new System.Windows.Forms.CheckBox();
            this.chkDefaultRandomise = new System.Windows.Forms.CheckBox();
            this.btnChangeDefaultTiming = new System.Windows.Forms.Button();
            this.lblDefaultInterval = new System.Windows.Forms.Label();
            this.lblDefaultOffset = new System.Windows.Forms.Label();
            this.lblHighlightMode = new System.Windows.Forms.Label();
            this.cmbHighlightMode = new System.Windows.Forms.ComboBox();
            this.grpHighlight = new System.Windows.Forms.GroupBox();
            this.lblHighlightColour = new System.Windows.Forms.Label();
            this.cdgColourDialog = new System.Windows.Forms.ColorDialog();
            this.picHighlightColour = new System.Windows.Forms.PictureBox();
            this.btnHighlightColour = new System.Windows.Forms.Button();
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
            this.grpCompression.Location = new System.Drawing.Point(12, 12);
            this.grpCompression.Name = "grpCompression";
            this.grpCompression.Size = new System.Drawing.Size(741, 88);
            this.grpCompression.TabIndex = 0;
            this.grpCompression.TabStop = false;
            this.grpCompression.Text = "SETTINGS_LABEL_COMPRESSION";
            // 
            // lblCompressionWarning
            // 
            this.lblCompressionWarning.AutoSize = true;
            this.lblCompressionWarning.Location = new System.Drawing.Point(6, 56);
            this.lblCompressionWarning.Name = "lblCompressionWarning";
            this.lblCompressionWarning.Size = new System.Drawing.Size(244, 13);
            this.lblCompressionWarning.TabIndex = 2;
            this.lblCompressionWarning.Text = "SETTINGS_LABEL_COMPRESSION_WARNING";
            // 
            // lblCompressionLevel
            // 
            this.lblCompressionLevel.AutoSize = true;
            this.lblCompressionLevel.Location = new System.Drawing.Point(6, 16);
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            this.lblCompressionLevel.Size = new System.Drawing.Size(224, 13);
            this.lblCompressionLevel.TabIndex = 1;
            this.lblCompressionLevel.Text = "SETTINGS_LABEL_COMPRESSION_LEVEL";
            // 
            // cmbCompressionLevel
            // 
            this.cmbCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompressionLevel.FormattingEnabled = true;
            this.cmbCompressionLevel.Location = new System.Drawing.Point(9, 32);
            this.cmbCompressionLevel.Name = "cmbCompressionLevel";
            this.cmbCompressionLevel.Size = new System.Drawing.Size(726, 21);
            this.cmbCompressionLevel.TabIndex = 0;
            this.cmbCompressionLevel.SelectedValueChanged += new System.EventHandler(this.cmbCompressionLevel_SelectedValueChanged);
            // 
            // grpDefaults
            // 
            this.grpDefaults.Controls.Add(this.lblDefaultWallpaperStyle);
            this.grpDefaults.Controls.Add(this.cmbDefaultWallpaperStyle);
            this.grpDefaults.Controls.Add(this.chkDefaultFade);
            this.grpDefaults.Controls.Add(this.chkDefaultRandomise);
            this.grpDefaults.Controls.Add(this.btnChangeDefaultTiming);
            this.grpDefaults.Controls.Add(this.lblDefaultInterval);
            this.grpDefaults.Controls.Add(this.lblDefaultOffset);
            this.grpDefaults.Location = new System.Drawing.Point(12, 106);
            this.grpDefaults.Name = "grpDefaults";
            this.grpDefaults.Size = new System.Drawing.Size(741, 146);
            this.grpDefaults.TabIndex = 4;
            this.grpDefaults.TabStop = false;
            this.grpDefaults.Text = "SETTINGS_LABEL_DEFAULT";
            // 
            // lblDefaultWallpaperStyle
            // 
            this.lblDefaultWallpaperStyle.AutoSize = true;
            this.lblDefaultWallpaperStyle.Location = new System.Drawing.Point(6, 88);
            this.lblDefaultWallpaperStyle.Name = "lblDefaultWallpaperStyle";
            this.lblDefaultWallpaperStyle.Size = new System.Drawing.Size(212, 13);
            this.lblDefaultWallpaperStyle.TabIndex = 7;
            this.lblDefaultWallpaperStyle.Text = "SETTINGS_LABEL_WALLPAPER_STYLE";
            // 
            // cmbDefaultWallpaperStyle
            // 
            this.cmbDefaultWallpaperStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultWallpaperStyle.FormattingEnabled = true;
            this.cmbDefaultWallpaperStyle.Location = new System.Drawing.Point(9, 104);
            this.cmbDefaultWallpaperStyle.Name = "cmbDefaultWallpaperStyle";
            this.cmbDefaultWallpaperStyle.Size = new System.Drawing.Size(726, 21);
            this.cmbDefaultWallpaperStyle.TabIndex = 6;
            this.cmbDefaultWallpaperStyle.SelectedValueChanged += new System.EventHandler(this.cmbDefaultWallpaperStyle_SelectedValueChanged);
            // 
            // chkDefaultFade
            // 
            this.chkDefaultFade.AutoSize = true;
            this.chkDefaultFade.Location = new System.Drawing.Point(9, 68);
            this.chkDefaultFade.Name = "chkDefaultFade";
            this.chkDefaultFade.Size = new System.Drawing.Size(208, 17);
            this.chkDefaultFade.TabIndex = 5;
            this.chkDefaultFade.Text = "SETTINGS_LABEL_DEFAULT_FADE";
            this.chkDefaultFade.UseVisualStyleBackColor = true;
            this.chkDefaultFade.CheckedChanged += new System.EventHandler(this.chkDefaultFade_CheckedChanged);
            // 
            // chkDefaultRandomise
            // 
            this.chkDefaultRandomise.AutoSize = true;
            this.chkDefaultRandomise.Location = new System.Drawing.Point(9, 45);
            this.chkDefaultRandomise.Name = "chkDefaultRandomise";
            this.chkDefaultRandomise.Size = new System.Drawing.Size(245, 17);
            this.chkDefaultRandomise.TabIndex = 4;
            this.chkDefaultRandomise.Text = "SETTINGS_LABEL_DEFAULT_RANDOMISE";
            this.chkDefaultRandomise.UseVisualStyleBackColor = true;
            this.chkDefaultRandomise.CheckedChanged += new System.EventHandler(this.chkDefaultRandomise_CheckedChanged);
            // 
            // btnChangeDefaultTiming
            // 
            this.btnChangeDefaultTiming.Location = new System.Drawing.Point(660, 16);
            this.btnChangeDefaultTiming.Name = "btnChangeDefaultTiming";
            this.btnChangeDefaultTiming.Size = new System.Drawing.Size(75, 23);
            this.btnChangeDefaultTiming.TabIndex = 3;
            this.btnChangeDefaultTiming.Text = "SETTINGS_BUTTON_DEFAULT_TIMING";
            this.btnChangeDefaultTiming.UseVisualStyleBackColor = true;
            this.btnChangeDefaultTiming.Click += new System.EventHandler(this.btnChangeDefaultTiming_Click);
            // 
            // lblDefaultInterval
            // 
            this.lblDefaultInterval.AutoSize = true;
            this.lblDefaultInterval.Location = new System.Drawing.Point(6, 29);
            this.lblDefaultInterval.Name = "lblDefaultInterval";
            this.lblDefaultInterval.Size = new System.Drawing.Size(286, 13);
            this.lblDefaultInterval.TabIndex = 2;
            this.lblDefaultInterval.Text = "SETTINGS_LABEL_WALLPAPER_DEFAULT_INTERVAL";
            // 
            // lblDefaultOffset
            // 
            this.lblDefaultOffset.AutoSize = true;
            this.lblDefaultOffset.Location = new System.Drawing.Point(6, 16);
            this.lblDefaultOffset.Name = "lblDefaultOffset";
            this.lblDefaultOffset.Size = new System.Drawing.Size(274, 13);
            this.lblDefaultOffset.TabIndex = 1;
            this.lblDefaultOffset.Text = "SETTINGS_LABEL_WALLPAPER_DEFAULT_OFFSET";
            // 
            // lblHighlightMode
            // 
            this.lblHighlightMode.AutoSize = true;
            this.lblHighlightMode.Location = new System.Drawing.Point(6, 16);
            this.lblHighlightMode.Name = "lblHighlightMode";
            this.lblHighlightMode.Size = new System.Drawing.Size(203, 13);
            this.lblHighlightMode.TabIndex = 7;
            this.lblHighlightMode.Text = "SETTINGS_LABEL_HIGHLIGHT_MODE";
            // 
            // cmbHighlightMode
            // 
            this.cmbHighlightMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHighlightMode.FormattingEnabled = true;
            this.cmbHighlightMode.Location = new System.Drawing.Point(9, 32);
            this.cmbHighlightMode.Name = "cmbHighlightMode";
            this.cmbHighlightMode.Size = new System.Drawing.Size(726, 21);
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
            this.grpHighlight.Location = new System.Drawing.Point(12, 258);
            this.grpHighlight.Name = "grpHighlight";
            this.grpHighlight.Size = new System.Drawing.Size(741, 146);
            this.grpHighlight.TabIndex = 5;
            this.grpHighlight.TabStop = false;
            this.grpHighlight.Text = "SETTINGS_LABEL_HIGHLIGHT";
            // 
            // lblHighlightColour
            // 
            this.lblHighlightColour.AutoSize = true;
            this.lblHighlightColour.Location = new System.Drawing.Point(6, 64);
            this.lblHighlightColour.Name = "lblHighlightColour";
            this.lblHighlightColour.Size = new System.Drawing.Size(216, 13);
            this.lblHighlightColour.TabIndex = 8;
            this.lblHighlightColour.Text = "SETTINGS_LABEL_HIGHLIGHT_COLOUR";
            // 
            // picHighlightColour
            // 
            this.picHighlightColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHighlightColour.Location = new System.Drawing.Point(228, 59);
            this.picHighlightColour.Name = "picHighlightColour";
            this.picHighlightColour.Size = new System.Drawing.Size(426, 23);
            this.picHighlightColour.TabIndex = 9;
            this.picHighlightColour.TabStop = false;
            // 
            // btnHighlightColour
            // 
            this.btnHighlightColour.Location = new System.Drawing.Point(660, 59);
            this.btnHighlightColour.Name = "btnHighlightColour";
            this.btnHighlightColour.Size = new System.Drawing.Size(75, 23);
            this.btnHighlightColour.TabIndex = 8;
            this.btnHighlightColour.Text = "SETTINGS_BUTTON_HIGHLIGHT_COLOUR";
            this.btnHighlightColour.UseVisualStyleBackColor = true;
            this.btnHighlightColour.Click += new System.EventHandler(this.btnHighlightColour_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 487);
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
        private System.Windows.Forms.CheckBox chkDefaultFade;
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
    }
}