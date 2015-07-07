﻿namespace WallChanger
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
            this.grpWallpaper = new System.Windows.Forms.GroupBox();
            this.lblWallpaperStyle = new System.Windows.Forms.Label();
            this.cmbWallpaperStyle = new System.Windows.Forms.ComboBox();
            this.grpDefaults = new System.Windows.Forms.GroupBox();
            this.lblDefaultOffset = new System.Windows.Forms.Label();
            this.lblDefaultInterval = new System.Windows.Forms.Label();
            this.btnChangeDefaultTiming = new System.Windows.Forms.Button();
            this.chkDefaultRandomise = new System.Windows.Forms.CheckBox();
            this.chkDefaultFade = new System.Windows.Forms.CheckBox();
            this.grpCompression.SuspendLayout();
            this.grpWallpaper.SuspendLayout();
            this.grpDefaults.SuspendLayout();
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
            this.cmbCompressionLevel.FormattingEnabled = true;
            this.cmbCompressionLevel.Location = new System.Drawing.Point(9, 32);
            this.cmbCompressionLevel.Name = "cmbCompressionLevel";
            this.cmbCompressionLevel.Size = new System.Drawing.Size(726, 21);
            this.cmbCompressionLevel.TabIndex = 0;
            this.cmbCompressionLevel.SelectedValueChanged += new System.EventHandler(this.cmbCompressionLevel_SelectedValueChanged);
            // 
            // grpWallpaper
            // 
            this.grpWallpaper.Controls.Add(this.lblWallpaperStyle);
            this.grpWallpaper.Controls.Add(this.cmbWallpaperStyle);
            this.grpWallpaper.Location = new System.Drawing.Point(12, 106);
            this.grpWallpaper.Name = "grpWallpaper";
            this.grpWallpaper.Size = new System.Drawing.Size(741, 71);
            this.grpWallpaper.TabIndex = 3;
            this.grpWallpaper.TabStop = false;
            this.grpWallpaper.Text = "SETTINGS_LABEL_WALLPAPER";
            // 
            // lblWallpaperStyle
            // 
            this.lblWallpaperStyle.AutoSize = true;
            this.lblWallpaperStyle.Location = new System.Drawing.Point(6, 16);
            this.lblWallpaperStyle.Name = "lblWallpaperStyle";
            this.lblWallpaperStyle.Size = new System.Drawing.Size(212, 13);
            this.lblWallpaperStyle.TabIndex = 1;
            this.lblWallpaperStyle.Text = "SETTINGS_LABEL_WALLPAPER_STYLE";
            // 
            // cmbWallpaperStyle
            // 
            this.cmbWallpaperStyle.FormattingEnabled = true;
            this.cmbWallpaperStyle.Location = new System.Drawing.Point(9, 32);
            this.cmbWallpaperStyle.Name = "cmbWallpaperStyle";
            this.cmbWallpaperStyle.Size = new System.Drawing.Size(726, 21);
            this.cmbWallpaperStyle.TabIndex = 0;
            this.cmbWallpaperStyle.SelectedValueChanged += new System.EventHandler(this.cmbWallpaperStyle_SelectedValueChanged);
            // 
            // grpDefaults
            // 
            this.grpDefaults.Controls.Add(this.chkDefaultFade);
            this.grpDefaults.Controls.Add(this.chkDefaultRandomise);
            this.grpDefaults.Controls.Add(this.btnChangeDefaultTiming);
            this.grpDefaults.Controls.Add(this.lblDefaultInterval);
            this.grpDefaults.Controls.Add(this.lblDefaultOffset);
            this.grpDefaults.Location = new System.Drawing.Point(12, 183);
            this.grpDefaults.Name = "grpDefaults";
            this.grpDefaults.Size = new System.Drawing.Size(741, 101);
            this.grpDefaults.TabIndex = 4;
            this.grpDefaults.TabStop = false;
            this.grpDefaults.Text = "SETTINGS_LABEL_DEFAULT";
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
            // lblDefaultInterval
            // 
            this.lblDefaultInterval.AutoSize = true;
            this.lblDefaultInterval.Location = new System.Drawing.Point(6, 29);
            this.lblDefaultInterval.Name = "lblDefaultInterval";
            this.lblDefaultInterval.Size = new System.Drawing.Size(286, 13);
            this.lblDefaultInterval.TabIndex = 2;
            this.lblDefaultInterval.Text = "SETTINGS_LABEL_WALLPAPER_DEFAULT_INTERVAL";
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 297);
            this.Controls.Add(this.grpDefaults);
            this.Controls.Add(this.grpWallpaper);
            this.Controls.Add(this.grpCompression);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpCompression.ResumeLayout(false);
            this.grpCompression.PerformLayout();
            this.grpWallpaper.ResumeLayout(false);
            this.grpWallpaper.PerformLayout();
            this.grpDefaults.ResumeLayout(false);
            this.grpDefaults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCompression;
        private System.Windows.Forms.Label lblCompressionWarning;
        private System.Windows.Forms.Label lblCompressionLevel;
        private System.Windows.Forms.ComboBox cmbCompressionLevel;
        private System.Windows.Forms.GroupBox grpWallpaper;
        private System.Windows.Forms.Label lblWallpaperStyle;
        private System.Windows.Forms.ComboBox cmbWallpaperStyle;
        private System.Windows.Forms.GroupBox grpDefaults;
        private System.Windows.Forms.Label lblDefaultOffset;
        private System.Windows.Forms.Label lblDefaultInterval;
        private System.Windows.Forms.CheckBox chkDefaultFade;
        private System.Windows.Forms.CheckBox chkDefaultRandomise;
        private System.Windows.Forms.Button btnChangeDefaultTiming;
    }
}