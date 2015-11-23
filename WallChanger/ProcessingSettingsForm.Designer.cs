namespace WallChanger
{
    partial class ProcessingSettingsForm
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
            this.chkProcessingEnabled = new System.Windows.Forms.CheckBox();
            this.grpPreProcessing = new System.Windows.Forms.GroupBox();
            this.chkImageFilterEnabled = new System.Windows.Forms.CheckBox();
            this.cmbImageFilter = new System.Windows.Forms.ComboBox();
            this.chkEdgeDetectionEnabled = new System.Windows.Forms.CheckBox();
            this.cmbEdgeDetection = new System.Windows.Forms.ComboBox();
            this.chkTintEnabled = new System.Windows.Forms.CheckBox();
            this.btnTintColour = new System.Windows.Forms.Button();
            this.picTintColour = new System.Windows.Forms.PictureBox();
            this.chkVignetteEnabled = new System.Windows.Forms.CheckBox();
            this.btnVignetteColour = new System.Windows.Forms.Button();
            this.picVignetteColour = new System.Windows.Forms.PictureBox();
            this.numPixelateSize = new System.Windows.Forms.NumericUpDown();
            this.chkPixelateEnabled = new System.Windows.Forms.CheckBox();
            this.numGaussianSharpenKernel = new System.Windows.Forms.NumericUpDown();
            this.chkGaussianSharpenEnabled = new System.Windows.Forms.CheckBox();
            this.numGaussianBlurKernel = new System.Windows.Forms.NumericUpDown();
            this.chkGaussianBlurEnabled = new System.Windows.Forms.CheckBox();
            this.lblHueValue = new System.Windows.Forms.Label();
            this.trkHue = new System.Windows.Forms.TrackBar();
            this.chkHueEnabled = new System.Windows.Forms.CheckBox();
            this.lblContrastValue = new System.Windows.Forms.Label();
            this.trkContrast = new System.Windows.Forms.TrackBar();
            this.chkContrastEnabled = new System.Windows.Forms.CheckBox();
            this.lblSaturationValue = new System.Windows.Forms.Label();
            this.trkSaturation = new System.Windows.Forms.TrackBar();
            this.chkSaturationEnabled = new System.Windows.Forms.CheckBox();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.trkBrightness = new System.Windows.Forms.TrackBar();
            this.chkBrightnessEnabled = new System.Windows.Forms.CheckBox();
            this.cdgColourDialog = new System.Windows.Forms.ColorDialog();
            this.chkChannelRotationEnabled = new System.Windows.Forms.CheckBox();
            this.cmbChannelRotation = new System.Windows.Forms.ComboBox();
            this.grpPreProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTintColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVignetteColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPixelateSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGaussianSharpenKernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGaussianBlurKernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // chkProcessingEnabled
            // 
            this.chkProcessingEnabled.AutoSize = true;
            this.chkProcessingEnabled.Location = new System.Drawing.Point(12, 12);
            this.chkProcessingEnabled.Name = "chkProcessingEnabled";
            this.chkProcessingEnabled.Size = new System.Drawing.Size(309, 16);
            this.chkProcessingEnabled.TabIndex = 0;
            this.chkProcessingEnabled.Text = "PREPROCESSING.LABEL.PREPROCESSING_ENABLED";
            this.chkProcessingEnabled.UseVisualStyleBackColor = true;
            this.chkProcessingEnabled.CheckedChanged += new System.EventHandler(this.chkProcessingEnabled_CheckedChanged);
            // 
            // grpPreProcessing
            // 
            this.grpPreProcessing.Controls.Add(this.chkChannelRotationEnabled);
            this.grpPreProcessing.Controls.Add(this.cmbChannelRotation);
            this.grpPreProcessing.Controls.Add(this.chkImageFilterEnabled);
            this.grpPreProcessing.Controls.Add(this.cmbImageFilter);
            this.grpPreProcessing.Controls.Add(this.chkEdgeDetectionEnabled);
            this.grpPreProcessing.Controls.Add(this.cmbEdgeDetection);
            this.grpPreProcessing.Controls.Add(this.chkTintEnabled);
            this.grpPreProcessing.Controls.Add(this.btnTintColour);
            this.grpPreProcessing.Controls.Add(this.picTintColour);
            this.grpPreProcessing.Controls.Add(this.chkVignetteEnabled);
            this.grpPreProcessing.Controls.Add(this.btnVignetteColour);
            this.grpPreProcessing.Controls.Add(this.picVignetteColour);
            this.grpPreProcessing.Controls.Add(this.numPixelateSize);
            this.grpPreProcessing.Controls.Add(this.chkPixelateEnabled);
            this.grpPreProcessing.Controls.Add(this.numGaussianSharpenKernel);
            this.grpPreProcessing.Controls.Add(this.chkGaussianSharpenEnabled);
            this.grpPreProcessing.Controls.Add(this.numGaussianBlurKernel);
            this.grpPreProcessing.Controls.Add(this.chkGaussianBlurEnabled);
            this.grpPreProcessing.Controls.Add(this.lblHueValue);
            this.grpPreProcessing.Controls.Add(this.trkHue);
            this.grpPreProcessing.Controls.Add(this.chkHueEnabled);
            this.grpPreProcessing.Controls.Add(this.lblContrastValue);
            this.grpPreProcessing.Controls.Add(this.trkContrast);
            this.grpPreProcessing.Controls.Add(this.chkContrastEnabled);
            this.grpPreProcessing.Controls.Add(this.lblSaturationValue);
            this.grpPreProcessing.Controls.Add(this.trkSaturation);
            this.grpPreProcessing.Controls.Add(this.chkSaturationEnabled);
            this.grpPreProcessing.Controls.Add(this.lblBrightnessValue);
            this.grpPreProcessing.Controls.Add(this.trkBrightness);
            this.grpPreProcessing.Controls.Add(this.chkBrightnessEnabled);
            this.grpPreProcessing.Location = new System.Drawing.Point(12, 34);
            this.grpPreProcessing.Name = "grpPreProcessing";
            this.grpPreProcessing.Size = new System.Drawing.Size(714, 434);
            this.grpPreProcessing.TabIndex = 1;
            this.grpPreProcessing.TabStop = false;
            this.grpPreProcessing.Text = "PREPROCESSING.LABEL.PREPROCESSING";
            // 
            // chkImageFilterEnabled
            // 
            this.chkImageFilterEnabled.AutoSize = true;
            this.chkImageFilterEnabled.Location = new System.Drawing.Point(6, 383);
            this.chkImageFilterEnabled.Name = "chkImageFilterEnabled";
            this.chkImageFilterEnabled.Size = new System.Drawing.Size(290, 16);
            this.chkImageFilterEnabled.TabIndex = 27;
            this.chkImageFilterEnabled.Text = "PREPROCESSOR_LABEL_IMAGE_FILTER_ENABLED";
            this.chkImageFilterEnabled.UseVisualStyleBackColor = true;
            this.chkImageFilterEnabled.CheckedChanged += new System.EventHandler(this.chkImageFilterEnabled_CheckedChanged);
            // 
            // cmbImageFilter
            // 
            this.cmbImageFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageFilter.FormattingEnabled = true;
            this.cmbImageFilter.Location = new System.Drawing.Point(299, 381);
            this.cmbImageFilter.Name = "cmbImageFilter";
            this.cmbImageFilter.Size = new System.Drawing.Size(409, 20);
            this.cmbImageFilter.TabIndex = 26;
            this.cmbImageFilter.SelectedIndexChanged += new System.EventHandler(this.cmbImageFilter_SelectedIndexChanged);
            // 
            // chkEdgeDetectionEnabled
            // 
            this.chkEdgeDetectionEnabled.AutoSize = true;
            this.chkEdgeDetectionEnabled.Location = new System.Drawing.Point(6, 357);
            this.chkEdgeDetectionEnabled.Name = "chkEdgeDetectionEnabled";
            this.chkEdgeDetectionEnabled.Size = new System.Drawing.Size(310, 16);
            this.chkEdgeDetectionEnabled.TabIndex = 25;
            this.chkEdgeDetectionEnabled.Text = "PREPROCESSOR_LABEL_EDGE_DETECTION_ENABLED";
            this.chkEdgeDetectionEnabled.UseVisualStyleBackColor = true;
            this.chkEdgeDetectionEnabled.CheckedChanged += new System.EventHandler(this.chkEdgeDetectionEnabled_CheckedChanged);
            // 
            // cmbEdgeDetection
            // 
            this.cmbEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdgeDetection.FormattingEnabled = true;
            this.cmbEdgeDetection.Location = new System.Drawing.Point(299, 355);
            this.cmbEdgeDetection.Name = "cmbEdgeDetection";
            this.cmbEdgeDetection.Size = new System.Drawing.Size(409, 20);
            this.cmbEdgeDetection.TabIndex = 24;
            this.cmbEdgeDetection.SelectedIndexChanged += new System.EventHandler(this.cmbEdgeDetection_SelectedIndexChanged);
            // 
            // chkTintEnabled
            // 
            this.chkTintEnabled.AutoSize = true;
            this.chkTintEnabled.Location = new System.Drawing.Point(6, 330);
            this.chkTintEnabled.Name = "chkTintEnabled";
            this.chkTintEnabled.Size = new System.Drawing.Size(238, 16);
            this.chkTintEnabled.TabIndex = 23;
            this.chkTintEnabled.Text = "PREPROCESSOR_LABEL_TINT_ENABLED";
            this.chkTintEnabled.UseVisualStyleBackColor = true;
            this.chkTintEnabled.CheckedChanged += new System.EventHandler(this.chkTintEnabled_CheckedChanged);
            // 
            // btnTintColour
            // 
            this.btnTintColour.Location = new System.Drawing.Point(633, 326);
            this.btnTintColour.Name = "btnTintColour";
            this.btnTintColour.Size = new System.Drawing.Size(75, 23);
            this.btnTintColour.TabIndex = 22;
            this.btnTintColour.Text = "PREPROCESSOR_BUTTON_TINT";
            this.btnTintColour.UseVisualStyleBackColor = true;
            this.btnTintColour.Click += new System.EventHandler(this.btnTintColour_Click);
            // 
            // picTintColour
            // 
            this.picTintColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTintColour.Location = new System.Drawing.Point(299, 326);
            this.picTintColour.Name = "picTintColour";
            this.picTintColour.Size = new System.Drawing.Size(328, 23);
            this.picTintColour.TabIndex = 21;
            this.picTintColour.TabStop = false;
            // 
            // chkVignetteEnabled
            // 
            this.chkVignetteEnabled.AutoSize = true;
            this.chkVignetteEnabled.Location = new System.Drawing.Point(6, 301);
            this.chkVignetteEnabled.Name = "chkVignetteEnabled";
            this.chkVignetteEnabled.Size = new System.Drawing.Size(268, 16);
            this.chkVignetteEnabled.TabIndex = 20;
            this.chkVignetteEnabled.Text = "PREPROCESSOR_LABEL_VIGNETTE_ENABLED";
            this.chkVignetteEnabled.UseVisualStyleBackColor = true;
            this.chkVignetteEnabled.CheckedChanged += new System.EventHandler(this.chkVignetteEnabled_CheckedChanged);
            // 
            // btnVignetteColour
            // 
            this.btnVignetteColour.Location = new System.Drawing.Point(633, 297);
            this.btnVignetteColour.Name = "btnVignetteColour";
            this.btnVignetteColour.Size = new System.Drawing.Size(75, 23);
            this.btnVignetteColour.TabIndex = 19;
            this.btnVignetteColour.Text = "PREPROCESSOR_BUTTON_VIGNETTE";
            this.btnVignetteColour.UseVisualStyleBackColor = true;
            this.btnVignetteColour.Click += new System.EventHandler(this.btnVignetteColour_Click);
            // 
            // picVignetteColour
            // 
            this.picVignetteColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVignetteColour.Location = new System.Drawing.Point(299, 297);
            this.picVignetteColour.Name = "picVignetteColour";
            this.picVignetteColour.Size = new System.Drawing.Size(328, 23);
            this.picVignetteColour.TabIndex = 18;
            this.picVignetteColour.TabStop = false;
            // 
            // numPixelateSize
            // 
            this.numPixelateSize.Location = new System.Drawing.Point(299, 272);
            this.numPixelateSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPixelateSize.Name = "numPixelateSize";
            this.numPixelateSize.Size = new System.Drawing.Size(409, 19);
            this.numPixelateSize.TabIndex = 17;
            this.numPixelateSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPixelateSize.ValueChanged += new System.EventHandler(this.numPixelateSize_ValueChanged);
            // 
            // chkPixelateEnabled
            // 
            this.chkPixelateEnabled.AutoSize = true;
            this.chkPixelateEnabled.Location = new System.Drawing.Point(6, 273);
            this.chkPixelateEnabled.Name = "chkPixelateEnabled";
            this.chkPixelateEnabled.Size = new System.Drawing.Size(268, 16);
            this.chkPixelateEnabled.TabIndex = 16;
            this.chkPixelateEnabled.Text = "PREPROCESSING.LABEL.PIXELATE_ENABLED";
            this.chkPixelateEnabled.UseVisualStyleBackColor = true;
            this.chkPixelateEnabled.CheckedChanged += new System.EventHandler(this.chkPixelateEnabled_CheckedChanged);
            // 
            // numGaussianSharpenKernel
            // 
            this.numGaussianSharpenKernel.Location = new System.Drawing.Point(299, 247);
            this.numGaussianSharpenKernel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGaussianSharpenKernel.Name = "numGaussianSharpenKernel";
            this.numGaussianSharpenKernel.Size = new System.Drawing.Size(409, 19);
            this.numGaussianSharpenKernel.TabIndex = 15;
            this.numGaussianSharpenKernel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGaussianSharpenKernel.ValueChanged += new System.EventHandler(this.numGaussianSharpenKernel_ValueChanged);
            // 
            // chkGaussianSharpenEnabled
            // 
            this.chkGaussianSharpenEnabled.AutoSize = true;
            this.chkGaussianSharpenEnabled.Location = new System.Drawing.Point(6, 248);
            this.chkGaussianSharpenEnabled.Name = "chkGaussianSharpenEnabled";
            this.chkGaussianSharpenEnabled.Size = new System.Drawing.Size(330, 16);
            this.chkGaussianSharpenEnabled.TabIndex = 14;
            this.chkGaussianSharpenEnabled.Text = "PREPROCESSING.LABEL.GAUSSIAN_SHARPEN_ENABLED";
            this.chkGaussianSharpenEnabled.UseVisualStyleBackColor = true;
            this.chkGaussianSharpenEnabled.CheckedChanged += new System.EventHandler(this.chkGaussianSharpenEnabled_CheckedChanged);
            // 
            // numGaussianBlurKernel
            // 
            this.numGaussianBlurKernel.Location = new System.Drawing.Point(299, 222);
            this.numGaussianBlurKernel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGaussianBlurKernel.Name = "numGaussianBlurKernel";
            this.numGaussianBlurKernel.Size = new System.Drawing.Size(409, 19);
            this.numGaussianBlurKernel.TabIndex = 13;
            this.numGaussianBlurKernel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGaussianBlurKernel.ValueChanged += new System.EventHandler(this.numGaussianBlurKernel_ValueChanged);
            // 
            // chkGaussianBlurEnabled
            // 
            this.chkGaussianBlurEnabled.AutoSize = true;
            this.chkGaussianBlurEnabled.Location = new System.Drawing.Point(6, 223);
            this.chkGaussianBlurEnabled.Name = "chkGaussianBlurEnabled";
            this.chkGaussianBlurEnabled.Size = new System.Drawing.Size(307, 16);
            this.chkGaussianBlurEnabled.TabIndex = 12;
            this.chkGaussianBlurEnabled.Text = "PREPROCESSING.LABEL.GAUSSIAN_BLUR_ENABLED";
            this.chkGaussianBlurEnabled.UseVisualStyleBackColor = true;
            this.chkGaussianBlurEnabled.CheckedChanged += new System.EventHandler(this.chkGaussianBlurEnabled_CheckedChanged);
            // 
            // lblHueValue
            // 
            this.lblHueValue.AutoSize = true;
            this.lblHueValue.Location = new System.Drawing.Point(6, 190);
            this.lblHueValue.Name = "lblHueValue";
            this.lblHueValue.Size = new System.Drawing.Size(166, 12);
            this.lblHueValue.TabIndex = 11;
            this.lblHueValue.Text = "PREPROCESSING_HUE_VALUE";
            // 
            // trkHue
            // 
            this.trkHue.LargeChange = 45;
            this.trkHue.Location = new System.Drawing.Point(299, 171);
            this.trkHue.Maximum = 360;
            this.trkHue.Name = "trkHue";
            this.trkHue.Size = new System.Drawing.Size(409, 45);
            this.trkHue.TabIndex = 10;
            this.trkHue.Scroll += new System.EventHandler(this.trkHue_Scroll);
            // 
            // chkHueEnabled
            // 
            this.chkHueEnabled.AutoSize = true;
            this.chkHueEnabled.Location = new System.Drawing.Point(6, 171);
            this.chkHueEnabled.Name = "chkHueEnabled";
            this.chkHueEnabled.Size = new System.Drawing.Size(239, 16);
            this.chkHueEnabled.TabIndex = 9;
            this.chkHueEnabled.Text = "PREPROCESSING.LABEL.HUE_ENABLED";
            this.chkHueEnabled.UseVisualStyleBackColor = true;
            this.chkHueEnabled.CheckedChanged += new System.EventHandler(this.chkHueEnabled_CheckedChanged);
            // 
            // lblContrastValue
            // 
            this.lblContrastValue.AutoSize = true;
            this.lblContrastValue.Location = new System.Drawing.Point(6, 139);
            this.lblContrastValue.Name = "lblContrastValue";
            this.lblContrastValue.Size = new System.Drawing.Size(204, 12);
            this.lblContrastValue.TabIndex = 8;
            this.lblContrastValue.Text = "PREPROCESSING_CONTRAST_VALUE";
            // 
            // trkContrast
            // 
            this.trkContrast.LargeChange = 25;
            this.trkContrast.Location = new System.Drawing.Point(299, 120);
            this.trkContrast.Maximum = 100;
            this.trkContrast.Minimum = -100;
            this.trkContrast.Name = "trkContrast";
            this.trkContrast.Size = new System.Drawing.Size(409, 45);
            this.trkContrast.TabIndex = 7;
            this.trkContrast.Scroll += new System.EventHandler(this.trkContrast_Scroll);
            // 
            // chkContrastEnabled
            // 
            this.chkContrastEnabled.AutoSize = true;
            this.chkContrastEnabled.Location = new System.Drawing.Point(6, 120);
            this.chkContrastEnabled.Name = "chkContrastEnabled";
            this.chkContrastEnabled.Size = new System.Drawing.Size(277, 16);
            this.chkContrastEnabled.TabIndex = 6;
            this.chkContrastEnabled.Text = "PREPROCESSING.LABEL.CONTRAST_ENABLED";
            this.chkContrastEnabled.UseVisualStyleBackColor = true;
            this.chkContrastEnabled.CheckedChanged += new System.EventHandler(this.chkContrastEnabled_CheckedChanged);
            // 
            // lblSaturationValue
            // 
            this.lblSaturationValue.AutoSize = true;
            this.lblSaturationValue.Location = new System.Drawing.Point(6, 88);
            this.lblSaturationValue.Name = "lblSaturationValue";
            this.lblSaturationValue.Size = new System.Drawing.Size(215, 12);
            this.lblSaturationValue.TabIndex = 5;
            this.lblSaturationValue.Text = "PREPROCESSING_SATURATION_VALUE";
            // 
            // trkSaturation
            // 
            this.trkSaturation.LargeChange = 25;
            this.trkSaturation.Location = new System.Drawing.Point(299, 69);
            this.trkSaturation.Maximum = 100;
            this.trkSaturation.Minimum = -100;
            this.trkSaturation.Name = "trkSaturation";
            this.trkSaturation.Size = new System.Drawing.Size(409, 45);
            this.trkSaturation.TabIndex = 4;
            this.trkSaturation.Scroll += new System.EventHandler(this.trkSaturation_Scroll);
            // 
            // chkSaturationEnabled
            // 
            this.chkSaturationEnabled.AutoSize = true;
            this.chkSaturationEnabled.Location = new System.Drawing.Point(6, 69);
            this.chkSaturationEnabled.Name = "chkSaturationEnabled";
            this.chkSaturationEnabled.Size = new System.Drawing.Size(288, 16);
            this.chkSaturationEnabled.TabIndex = 3;
            this.chkSaturationEnabled.Text = "PREPROCESSING.LABEL.SATURATION_ENABLED";
            this.chkSaturationEnabled.UseVisualStyleBackColor = true;
            this.chkSaturationEnabled.CheckedChanged += new System.EventHandler(this.chkSaturationEnabled_CheckedChanged);
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.AutoSize = true;
            this.lblBrightnessValue.Location = new System.Drawing.Point(6, 37);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(214, 12);
            this.lblBrightnessValue.TabIndex = 2;
            this.lblBrightnessValue.Text = "PREPROCESSING_BRIGHTNESS_VALUE";
            // 
            // trkBrightness
            // 
            this.trkBrightness.LargeChange = 25;
            this.trkBrightness.Location = new System.Drawing.Point(299, 18);
            this.trkBrightness.Maximum = 100;
            this.trkBrightness.Minimum = -100;
            this.trkBrightness.Name = "trkBrightness";
            this.trkBrightness.Size = new System.Drawing.Size(409, 45);
            this.trkBrightness.TabIndex = 1;
            this.trkBrightness.Scroll += new System.EventHandler(this.trkBrightness_Scroll);
            // 
            // chkBrightnessEnabled
            // 
            this.chkBrightnessEnabled.AutoSize = true;
            this.chkBrightnessEnabled.Location = new System.Drawing.Point(6, 18);
            this.chkBrightnessEnabled.Name = "chkBrightnessEnabled";
            this.chkBrightnessEnabled.Size = new System.Drawing.Size(287, 16);
            this.chkBrightnessEnabled.TabIndex = 0;
            this.chkBrightnessEnabled.Text = "PREPROCESSING.LABEL.BRIGHTNESS_ENABLED";
            this.chkBrightnessEnabled.UseVisualStyleBackColor = true;
            this.chkBrightnessEnabled.CheckedChanged += new System.EventHandler(this.chkBrightnessEnabled_CheckedChanged);
            // 
            // chkChannelRotationEnabled
            // 
            this.chkChannelRotationEnabled.AutoSize = true;
            this.chkChannelRotationEnabled.Location = new System.Drawing.Point(6, 409);
            this.chkChannelRotationEnabled.Name = "chkChannelRotationEnabled";
            this.chkChannelRotationEnabled.Size = new System.Drawing.Size(327, 16);
            this.chkChannelRotationEnabled.TabIndex = 29;
            this.chkChannelRotationEnabled.Text = "PREPROCESSOR_LABEL_CHANNEL_ROTATION_ENABLED";
            this.chkChannelRotationEnabled.UseVisualStyleBackColor = true;
            this.chkChannelRotationEnabled.CheckedChanged += new System.EventHandler(this.chkChannelRotationEnabled_CheckedChanged);
            // 
            // cmbChannelRotation
            // 
            this.cmbChannelRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannelRotation.FormattingEnabled = true;
            this.cmbChannelRotation.Location = new System.Drawing.Point(299, 407);
            this.cmbChannelRotation.Name = "cmbChannelRotation";
            this.cmbChannelRotation.Size = new System.Drawing.Size(409, 20);
            this.cmbChannelRotation.TabIndex = 28;
            this.cmbChannelRotation.SelectedIndexChanged += new System.EventHandler(this.cmbChannelRotation_SelectedIndexChanged);
            // 
            // ProcessingSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 480);
            this.Controls.Add(this.grpPreProcessing);
            this.Controls.Add(this.chkProcessingEnabled);
            this.Name = "ProcessingSettingsForm";
            this.Text = "ProcessingSettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProcessingSettingsForm_FormClosed);
            this.grpPreProcessing.ResumeLayout(false);
            this.grpPreProcessing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTintColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVignetteColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPixelateSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGaussianSharpenKernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGaussianBlurKernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkProcessingEnabled;
        private System.Windows.Forms.GroupBox grpPreProcessing;
        private System.Windows.Forms.NumericUpDown numPixelateSize;
        private System.Windows.Forms.CheckBox chkPixelateEnabled;
        private System.Windows.Forms.NumericUpDown numGaussianSharpenKernel;
        private System.Windows.Forms.CheckBox chkGaussianSharpenEnabled;
        private System.Windows.Forms.NumericUpDown numGaussianBlurKernel;
        private System.Windows.Forms.CheckBox chkGaussianBlurEnabled;
        private System.Windows.Forms.Label lblHueValue;
        private System.Windows.Forms.TrackBar trkHue;
        private System.Windows.Forms.CheckBox chkHueEnabled;
        private System.Windows.Forms.Label lblContrastValue;
        private System.Windows.Forms.TrackBar trkContrast;
        private System.Windows.Forms.CheckBox chkContrastEnabled;
        private System.Windows.Forms.Label lblSaturationValue;
        private System.Windows.Forms.TrackBar trkSaturation;
        private System.Windows.Forms.CheckBox chkSaturationEnabled;
        private System.Windows.Forms.Label lblBrightnessValue;
        private System.Windows.Forms.TrackBar trkBrightness;
        private System.Windows.Forms.CheckBox chkBrightnessEnabled;
        private System.Windows.Forms.Button btnVignetteColour;
        private System.Windows.Forms.PictureBox picVignetteColour;
        private System.Windows.Forms.CheckBox chkImageFilterEnabled;
        private System.Windows.Forms.ComboBox cmbImageFilter;
        private System.Windows.Forms.CheckBox chkEdgeDetectionEnabled;
        private System.Windows.Forms.ComboBox cmbEdgeDetection;
        private System.Windows.Forms.CheckBox chkTintEnabled;
        private System.Windows.Forms.Button btnTintColour;
        private System.Windows.Forms.PictureBox picTintColour;
        private System.Windows.Forms.CheckBox chkVignetteEnabled;
        private System.Windows.Forms.ColorDialog cdgColourDialog;
        private System.Windows.Forms.CheckBox chkChannelRotationEnabled;
        private System.Windows.Forms.ComboBox cmbChannelRotation;
    }
}