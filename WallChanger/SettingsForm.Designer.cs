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
            this.chkGlobalWallpaperStyle = new System.Windows.Forms.CheckBox();
            this.chkGlobalFading = new System.Windows.Forms.CheckBox();
            this.chkGlobalRandomise = new System.Windows.Forms.CheckBox();
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
            this.grpPreProcessing = new System.Windows.Forms.GroupBox();
            this.btnPreProcessingDefaults = new System.Windows.Forms.Button();
            this.chkGlobalPreProcessing = new System.Windows.Forms.CheckBox();
            this.grpMisc = new System.Windows.Forms.GroupBox();
            this.chkDefaultColourChanging = new System.Windows.Forms.CheckBox();
            this.chkGlobalColourChanging = new System.Windows.Forms.CheckBox();
            this.lblColourChangingDesc = new System.Windows.Forms.Label();
            this.chkRainbowMode = new System.Windows.Forms.CheckBox();
            this.grpCompression.SuspendLayout();
            this.grpDefaults.SuspendLayout();
            this.grpHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHighlightColour)).BeginInit();
            this.grpPreProcessing.SuspendLayout();
            this.grpMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCompression
            // 
            this.grpCompression.Controls.Add(this.lblCompressionWarning);
            this.grpCompression.Controls.Add(this.lblCompressionLevel);
            this.grpCompression.Controls.Add(this.cmbCompressionLevel);
            this.grpCompression.Location = new System.Drawing.Point(12, 11);
            this.grpCompression.Name = "grpCompression";
            this.grpCompression.Size = new System.Drawing.Size(741, 70);
            this.grpCompression.TabIndex = 0;
            this.grpCompression.TabStop = false;
            this.grpCompression.Text = "SETTINGS.LABEL.COMPRESSION";
            // 
            // lblCompressionWarning
            // 
            this.lblCompressionWarning.AutoSize = true;
            this.lblCompressionWarning.Location = new System.Drawing.Point(6, 52);
            this.lblCompressionWarning.Name = "lblCompressionWarning";
            this.lblCompressionWarning.Size = new System.Drawing.Size(238, 12);
            this.lblCompressionWarning.TabIndex = 2;
            this.lblCompressionWarning.Text = "SETTINGS.LABEL.COMPRESSION.WARNING";
            // 
            // lblCompressionLevel
            // 
            this.lblCompressionLevel.AutoSize = true;
            this.lblCompressionLevel.Location = new System.Drawing.Point(6, 15);
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            this.lblCompressionLevel.Size = new System.Drawing.Size(220, 12);
            this.lblCompressionLevel.TabIndex = 1;
            this.lblCompressionLevel.Text = "SETTINGS.LABEL.COMPRESSION.LEVEL";
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
            this.grpDefaults.Location = new System.Drawing.Point(12, 87);
            this.grpDefaults.Name = "grpDefaults";
            this.grpDefaults.Size = new System.Drawing.Size(741, 128);
            this.grpDefaults.TabIndex = 4;
            this.grpDefaults.TabStop = false;
            this.grpDefaults.Text = "SETTINGS.LABEL.DEFAULT";
            // 
            // chkGlobalWallpaperStyle
            // 
            this.chkGlobalWallpaperStyle.AutoSize = true;
            this.chkGlobalWallpaperStyle.Location = new System.Drawing.Point(370, 85);
            this.chkGlobalWallpaperStyle.Name = "chkGlobalWallpaperStyle";
            this.chkGlobalWallpaperStyle.Size = new System.Drawing.Size(328, 16);
            this.chkGlobalWallpaperStyle.TabIndex = 10;
            this.chkGlobalWallpaperStyle.Text = "SETTINGS.LABEL.DEFAULT.GLOBAL_WALLPAPER_STYLE";
            this.chkGlobalWallpaperStyle.UseVisualStyleBackColor = true;
            this.chkGlobalWallpaperStyle.CheckedChanged += new System.EventHandler(this.chkGlobalWallpaperStyle_CheckedChanged);
            // 
            // chkGlobalFading
            // 
            this.chkGlobalFading.AutoSize = true;
            this.chkGlobalFading.Location = new System.Drawing.Point(370, 63);
            this.chkGlobalFading.Name = "chkGlobalFading";
            this.chkGlobalFading.Size = new System.Drawing.Size(266, 16);
            this.chkGlobalFading.TabIndex = 9;
            this.chkGlobalFading.Text = "SETTINGS.LABEL.DEFAULT.GLOBAL_FADING";
            this.chkGlobalFading.UseVisualStyleBackColor = true;
            this.chkGlobalFading.CheckedChanged += new System.EventHandler(this.chkGlobalFading_CheckedChanged);
            // 
            // chkGlobalRandomise
            // 
            this.chkGlobalRandomise.AutoSize = true;
            this.chkGlobalRandomise.Location = new System.Drawing.Point(370, 42);
            this.chkGlobalRandomise.Name = "chkGlobalRandomise";
            this.chkGlobalRandomise.Size = new System.Drawing.Size(290, 16);
            this.chkGlobalRandomise.TabIndex = 8;
            this.chkGlobalRandomise.Text = "SETTINGS.LABEL.DEFAULT.GLOBAL_RANDOMISE";
            this.chkGlobalRandomise.UseVisualStyleBackColor = true;
            this.chkGlobalRandomise.CheckedChanged += new System.EventHandler(this.chkGlobalRandomise_CheckedChanged);
            // 
            // lblDefaultWallpaperStyle
            // 
            this.lblDefaultWallpaperStyle.AutoSize = true;
            this.lblDefaultWallpaperStyle.Location = new System.Drawing.Point(6, 86);
            this.lblDefaultWallpaperStyle.Name = "lblDefaultWallpaperStyle";
            this.lblDefaultWallpaperStyle.Size = new System.Drawing.Size(261, 12);
            this.lblDefaultWallpaperStyle.TabIndex = 7;
            this.lblDefaultWallpaperStyle.Text = "SETTINGS.LABEL.DEFAULT.WALLPAPER_STYLE";
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
            this.chkDefaultFading.Text = "SETTINGS.LABEL.DEFAULT.FADING";
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
            this.chkDefaultRandomise.Text = "SETTINGS.LABEL.DEFAULT.RANDOMISE";
            this.chkDefaultRandomise.UseVisualStyleBackColor = true;
            this.chkDefaultRandomise.CheckedChanged += new System.EventHandler(this.chkDefaultRandomise_CheckedChanged);
            // 
            // btnChangeDefaultTiming
            // 
            this.btnChangeDefaultTiming.Location = new System.Drawing.Point(660, 15);
            this.btnChangeDefaultTiming.Name = "btnChangeDefaultTiming";
            this.btnChangeDefaultTiming.Size = new System.Drawing.Size(75, 21);
            this.btnChangeDefaultTiming.TabIndex = 3;
            this.btnChangeDefaultTiming.Text = "SETTINGS.BUTTON.DEFAULT_TIMING";
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
            this.lblDefaultInterval.Text = "SETTINGS.LABEL.WALLPAPER_DEFAULT_INTERVAL";
            // 
            // lblDefaultOffset
            // 
            this.lblDefaultOffset.AutoSize = true;
            this.lblDefaultOffset.Location = new System.Drawing.Point(6, 15);
            this.lblDefaultOffset.Name = "lblDefaultOffset";
            this.lblDefaultOffset.Size = new System.Drawing.Size(270, 12);
            this.lblDefaultOffset.TabIndex = 1;
            this.lblDefaultOffset.Text = "SETTINGS.LABEL.WALLPAPER_DEFAULT_OFFSET";
            // 
            // lblHighlightMode
            // 
            this.lblHighlightMode.AutoSize = true;
            this.lblHighlightMode.Location = new System.Drawing.Point(6, 15);
            this.lblHighlightMode.Name = "lblHighlightMode";
            this.lblHighlightMode.Size = new System.Drawing.Size(197, 12);
            this.lblHighlightMode.TabIndex = 7;
            this.lblHighlightMode.Text = "SETTINGS.LABEL.HIGHLIGHT.MODE";
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
            this.grpHighlight.Location = new System.Drawing.Point(12, 221);
            this.grpHighlight.Name = "grpHighlight";
            this.grpHighlight.Size = new System.Drawing.Size(741, 82);
            this.grpHighlight.TabIndex = 5;
            this.grpHighlight.TabStop = false;
            this.grpHighlight.Text = "SETTINGS.LABEL.HIGHLIGHT";
            // 
            // btnHighlightColour
            // 
            this.btnHighlightColour.Location = new System.Drawing.Point(660, 54);
            this.btnHighlightColour.Name = "btnHighlightColour";
            this.btnHighlightColour.Size = new System.Drawing.Size(75, 21);
            this.btnHighlightColour.TabIndex = 8;
            this.btnHighlightColour.Text = "SETTINGS.BUTTON.HIGHLIGHT_COLOUR";
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
            this.lblHighlightColour.Text = "SETTINGS.LABEL.HIGHLIGHT.COLOUR";
            // 
            // grpPreProcessing
            // 
            this.grpPreProcessing.Controls.Add(this.btnPreProcessingDefaults);
            this.grpPreProcessing.Controls.Add(this.chkGlobalPreProcessing);
            this.grpPreProcessing.Location = new System.Drawing.Point(12, 309);
            this.grpPreProcessing.Name = "grpPreProcessing";
            this.grpPreProcessing.Size = new System.Drawing.Size(741, 40);
            this.grpPreProcessing.TabIndex = 6;
            this.grpPreProcessing.TabStop = false;
            this.grpPreProcessing.Text = "SETTINGS.LABEL.PREPROCESSING";
            // 
            // btnPreProcessingDefaults
            // 
            this.btnPreProcessingDefaults.Location = new System.Drawing.Point(660, 11);
            this.btnPreProcessingDefaults.Name = "btnPreProcessingDefaults";
            this.btnPreProcessingDefaults.Size = new System.Drawing.Size(75, 23);
            this.btnPreProcessingDefaults.TabIndex = 1;
            this.btnPreProcessingDefaults.Text = "SETTINGS.BUTTON.PREPROCESSING_DEFAULTS";
            this.btnPreProcessingDefaults.UseVisualStyleBackColor = true;
            this.btnPreProcessingDefaults.Click += new System.EventHandler(this.btnPreProcessingDefaults_Click);
            // 
            // chkGlobalPreProcessing
            // 
            this.chkGlobalPreProcessing.AutoSize = true;
            this.chkGlobalPreProcessing.Location = new System.Drawing.Point(9, 18);
            this.chkGlobalPreProcessing.Name = "chkGlobalPreProcessing";
            this.chkGlobalPreProcessing.Size = new System.Drawing.Size(262, 16);
            this.chkGlobalPreProcessing.TabIndex = 0;
            this.chkGlobalPreProcessing.Text = "SETTINGS.LABEL.GLOBAL_PREPROCESSING";
            this.chkGlobalPreProcessing.UseVisualStyleBackColor = true;
            this.chkGlobalPreProcessing.CheckedChanged += new System.EventHandler(this.chkGlobalPreProcessing_CheckedChanged);
            // 
            // grpMisc
            // 
            this.grpMisc.Controls.Add(this.chkRainbowMode);
            this.grpMisc.Controls.Add(this.lblColourChangingDesc);
            this.grpMisc.Controls.Add(this.chkGlobalColourChanging);
            this.grpMisc.Controls.Add(this.chkDefaultColourChanging);
            this.grpMisc.Location = new System.Drawing.Point(12, 355);
            this.grpMisc.Name = "grpMisc";
            this.grpMisc.Size = new System.Drawing.Size(741, 73);
            this.grpMisc.TabIndex = 7;
            this.grpMisc.TabStop = false;
            this.grpMisc.Text = "SETTINGS.LABEL.MISCELLANEOUS";
            // 
            // chkDefaultColourChanging
            // 
            this.chkDefaultColourChanging.AutoSize = true;
            this.chkDefaultColourChanging.Location = new System.Drawing.Point(8, 30);
            this.chkDefaultColourChanging.Name = "chkDefaultColourChanging";
            this.chkDefaultColourChanging.Size = new System.Drawing.Size(273, 16);
            this.chkDefaultColourChanging.TabIndex = 0;
            this.chkDefaultColourChanging.Text = "SETTINGS.LABEL.DEFAULT.COLOUR_CHANGE";
            this.chkDefaultColourChanging.UseVisualStyleBackColor = true;
            this.chkDefaultColourChanging.CheckedChanged += new System.EventHandler(this.chkDefaultColourChanging_CheckedChanged);
            // 
            // chkGlobalColourChanging
            // 
            this.chkGlobalColourChanging.AutoSize = true;
            this.chkGlobalColourChanging.Location = new System.Drawing.Point(369, 30);
            this.chkGlobalColourChanging.Name = "chkGlobalColourChanging";
            this.chkGlobalColourChanging.Size = new System.Drawing.Size(321, 16);
            this.chkGlobalColourChanging.TabIndex = 10;
            this.chkGlobalColourChanging.Text = "SETTINGS.LABEL.DEFAULT.GLOBAL_COLOUR_CHANGE";
            this.chkGlobalColourChanging.UseVisualStyleBackColor = true;
            this.chkGlobalColourChanging.CheckedChanged += new System.EventHandler(this.chkGlobalColourChanging_CheckedChanged);
            // 
            // lblColourChangingDesc
            // 
            this.lblColourChangingDesc.AutoSize = true;
            this.lblColourChangingDesc.Location = new System.Drawing.Point(7, 15);
            this.lblColourChangingDesc.Name = "lblColourChangingDesc";
            this.lblColourChangingDesc.Size = new System.Drawing.Size(233, 12);
            this.lblColourChangingDesc.TabIndex = 11;
            this.lblColourChangingDesc.Text = "SETTINGS.LABEL.COLOUR_CHANGE_DESC";
            // 
            // chkRainbowMode
            // 
            this.chkRainbowMode.AutoSize = true;
            this.chkRainbowMode.Location = new System.Drawing.Point(8, 52);
            this.chkRainbowMode.Name = "chkRainbowMode";
            this.chkRainbowMode.Size = new System.Drawing.Size(209, 16);
            this.chkRainbowMode.TabIndex = 12;
            this.chkRainbowMode.Text = "SETTINGS.LABEL.RAINBOW_MODE";
            this.chkRainbowMode.UseVisualStyleBackColor = true;
            this.chkRainbowMode.CheckedChanged += new System.EventHandler(this.chkRainbowMode_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 440);
            this.Controls.Add(this.grpMisc);
            this.Controls.Add(this.grpPreProcessing);
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
            this.grpPreProcessing.ResumeLayout(false);
            this.grpPreProcessing.PerformLayout();
            this.grpMisc.ResumeLayout(false);
            this.grpMisc.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpPreProcessing;
        private System.Windows.Forms.Button btnPreProcessingDefaults;
        private System.Windows.Forms.CheckBox chkGlobalPreProcessing;
        private System.Windows.Forms.GroupBox grpMisc;
        private System.Windows.Forms.Label lblColourChangingDesc;
        private System.Windows.Forms.CheckBox chkGlobalColourChanging;
        private System.Windows.Forms.CheckBox chkDefaultColourChanging;
        private System.Windows.Forms.CheckBox chkRainbowMode;
    }
}