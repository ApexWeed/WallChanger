using System;
using System.Windows.Forms;
using WallChanger.Layout;
using WallChanger.Translation;
using WallChanger.Translation.Controls;

namespace WallChanger
{
    public partial class ProcessingSettingsForm : Form
    {

        private readonly LanguageManager LM = GlobalVars.LanguageManager;
        new private readonly Form Parent;
        private readonly SettingChanged SettingChangedHandler;

        new readonly LayoutEngine Layout;

        #region "Controls"
        NumericUpDown numGaussianBlurKernelSize;
        NumericUpDown numGaussianSharpenKernelSize;
        NumericUpDown numPixelateSize;

        PictureBox picVignetteColour;
        PictureBox picTintColour;

        TrackBar trkBrightness;
        TrackBar trkSaturation;
        TrackBar trkContrast;
        TrackBar trkHue;

        TranslatableButton btnVignetteColour;
        TranslatableButton btnTintColour;

        TranslatableCheckBox chkPreprocessingEnabled;
        TranslatableCheckBox chkBrightnessEnabled;
        TranslatableCheckBox chkSaturationEnabled;
        TranslatableCheckBox chkContrastEnabled;
        TranslatableCheckBox chkHueEnabled;
        TranslatableCheckBox chkGaussianBlurEnabled;
        TranslatableCheckBox chkGaussianSharpenEnabled;
        TranslatableCheckBox chkPixelateEnabled;
        TranslatableCheckBox chkVignetteEnabled;
        TranslatableCheckBox chkTintEnabled;
        TranslatableCheckBox chkEdgeDetectionEnabled;
        TranslatableCheckBox chkImageFilterEnabled;
        TranslatableCheckBox chkChannelRotationEnabled;

        TranslatableComboBox cmbEdgeDetection;
        TranslatableComboBox cmbImageFilter;
        TranslatableComboBox cmbChannelRotation;

        TranslatableGroupBox grpPreprocessing;

        TranslatableLabelFormat lblBrightnessValue;
        TranslatableLabelFormat lblSaturationValue;
        TranslatableLabelFormat lblContrastValue;
        TranslatableLabelFormat lblHueValue;
        #endregion

        /// <summary>
        /// Handles settings updating.
        /// </summary>
        /// <param name="ChangedSetting">The setting that has changed.</param>
        /// <param name="Value">The value the setting has been changed to.</param>
        public delegate void SettingChanged(ProcessingSetting ChangedSetting, object Value);

        public ProcessingSettingsForm(string Source, ProcessingSettings Settings, SettingChanged SettingChangedHandler, Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
            this.SettingChangedHandler = SettingChangedHandler;

            ProcessingSettingsTitle.LanguageManager = LM;
            ProcessingSettingsTitle.Parameters = new object[] { Source };

            Layout = new LayoutEngine(this)
            {
                Padding = new Padding(5),
                UpdateContainerSize = true
            };

            #region "Numeric Up Down"
            numGaussianBlurKernelSize = new NumericUpDown
            {
                Minimum = new decimal(new int[] { 1, 0, 0, 0 }),
                Value = Settings.GaussianBlurSize.Clamp(1, 100),
                Enabled = Settings.GaussianBlurEnabled
            };
            numGaussianSharpenKernelSize = new NumericUpDown
            {
                Minimum = new decimal(new int[] { 1, 0, 0, 0 }),
                Value = Settings.GaussianSharpenSize.Clamp(1, 100),
                Enabled = Settings.GaussianSharpenEnabled
            };
            numPixelateSize = new NumericUpDown
            {
                Minimum = new decimal(new int[] { 1, 0, 0, 0 }),
                Value = Settings.PixelateSize.Clamp(1, 100),
                Enabled = Settings.PixelateEnabled
            };

            numGaussianBlurKernelSize.ValueChanged += numGaussianBlurKernelSize_ValueChanged;
            numGaussianSharpenKernelSize.ValueChanged += numGaussianSharpenKernelSize_ValueChanged;
            numPixelateSize.ValueChanged += numPixelateSize_ValueChanged;
            #endregion

            #region "Picture Box"
            picVignetteColour = new PictureBox
            {
                Height = 21,
                BackColor = Settings.VignetteColour
            };
            picTintColour = new PictureBox
            {
                Height = 21,
                BackColor = Settings.TintColour
            };
            #endregion

            #region "Track Bar"
            trkBrightness = new TrackBar
            {
                Minimum = -100,
                Maximum = 100,
                Value = Settings.BrightnessValue.Clamp(-100, 100),
                Enabled = Settings.BrightnessEnabled
            };
            trkSaturation = new TrackBar
            {
                Minimum = -100,
                Maximum = 100,
                Value = Settings.SaturationValue.Clamp(-100, 100),
                Enabled = Settings.SaturationEnabled
            };
            trkContrast = new TrackBar
            {
                Minimum = -100,
                Maximum = 100,
                Value = Settings.ContrastValue.Clamp(-100, 100),
                Enabled = Settings.ContrastEnabled
            };
            trkHue = new TrackBar
            {
                Minimum = 0,
                Maximum = 360,
                Value = Settings.HueValue.Clamp(0, 360),
                Enabled = Settings.HueEnabled
            };

            trkBrightness.Scroll += trkBrightness_Scroll;
            trkSaturation.Scroll += trkSaturation_Scroll;
            trkContrast.Scroll += trkContrast_Scroll;
            trkHue.Scroll += trkHue_Scroll;
            #endregion

            #region "Translatable Button"
            btnVignetteColour = new TranslatableButton
            {
                TranslationString = "PREPROCESSING.BUTTON.VIGNETTE_COLOUR",
                LanguageManager = LM,
                Enabled = Settings.VignetteEnabled
            };
            btnTintColour = new TranslatableButton
            {
                TranslationString = "PREPROCESSING.BUTTON.TINT_COLOUR",
                LanguageManager = LM,
                Enabled = Settings.TintEnabled
            };

            btnVignetteColour.Click += btnVignetteColour_Click;
            btnTintColour.Click += btnTintColour_Click;
            #endregion

            #region "Translatable Check Box"
            chkPreprocessingEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.PREPROCESSING_ENABLED",
                LanguageManager = LM,
                Checked = Settings.PreProcessingEnabled,
                AutoSize = true
            };
            chkBrightnessEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.BRIGHTNESS_ENABLED",
                LanguageManager = LM,
                Checked = Settings.BrightnessEnabled,
                AutoSize = true
            };
            chkSaturationEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.SATURATION_ENABLED",
                LanguageManager = LM,
                Checked = Settings.SaturationEnabled,
                AutoSize = true
            };
            chkContrastEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.CONTRAST_ENABLED",
                LanguageManager = LM,
                Checked = Settings.ContrastEnabled,
                AutoSize = true
            };
            chkHueEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.HUE_ENABLED",
                LanguageManager = LM,
                Checked = Settings.HueEnabled,
                AutoSize = true
            };
            chkGaussianBlurEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.GAUSSIAN_BLUR_ENABLED",
                LanguageManager = LM,
                Checked = Settings.GaussianBlurEnabled,
                AutoSize = true
            };
            chkGaussianSharpenEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.GAUSSIAN_SHARPEN_ENABLED",
                LanguageManager = LM,
                Checked = Settings.GaussianSharpenEnabled,
                AutoSize = true
            };
            chkPixelateEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.PIXELATE_ENABLED",
                LanguageManager = LM,
                Checked = Settings.PixelateEnabled,
                AutoSize = true
            };
            chkVignetteEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.VIGNETTE_ENABLED",
                LanguageManager = LM,
                Checked = Settings.VignetteEnabled,
                AutoSize = true
            };
            chkTintEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.TINT_ENABLED",
                LanguageManager = LM,
                Checked = Settings.TintEnabled,
                AutoSize = true
            };
            chkEdgeDetectionEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.EDGE_DETECTION_ENABLED",
                LanguageManager = LM,
                Checked = Settings.EdgeDetectionEnabled,
                AutoSize = true
            };
            chkImageFilterEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.IMAGE_FILTER_ENABLED",
                LanguageManager = LM,
                Checked = Settings.ImageFilterEnabled,
                AutoSize = true
            };
            chkChannelRotationEnabled = new TranslatableCheckBox
            {
                TranslationString = "PREPROCESSING.LABEL.CHANNEL_ROTATION_ENABLED",
                LanguageManager = LM,
                Checked = Settings.ChannelRotationEnabled,
                AutoSize = true
            };

            chkPreprocessingEnabled.CheckedChanged += chkPreprocessingEnabled_CheckedChanged;
            chkBrightnessEnabled.CheckedChanged += chkBrightnessEnabled_CheckedChanged;
            chkSaturationEnabled.CheckedChanged += chkSaturationEnabled_CheckedChanged;
            chkContrastEnabled.CheckedChanged += chkContrastEnabled_CheckedChanged;
            chkHueEnabled.CheckedChanged += chkHueEnabled_CheckedChanged;
            chkGaussianBlurEnabled.CheckedChanged += chkGaussianBlurEnabled_CheckedChanged;
            chkGaussianSharpenEnabled.CheckedChanged += chkGaussianSharpenEnabled_CheckedChanged;
            chkPixelateEnabled.CheckedChanged += chkPixelateEnabled_CheckedChanged;
            chkVignetteEnabled.CheckedChanged += chkVignetteEnabled_CheckedChanged;
            chkTintEnabled.CheckedChanged += chkTintEnabled_CheckedChanged;
            chkEdgeDetectionEnabled.CheckedChanged += chkEdgeDetectionEnabled_CheckedChanged;
            chkImageFilterEnabled.CheckedChanged += chkImageFilterEnabled_CheckedChanged;
            chkChannelRotationEnabled.CheckedChanged += chkChannelRotationEnabled_CheckedChanged;
            #endregion

            #region "Translatable Combo Box"
            cmbEdgeDetection = new TranslatableComboBox
            {
                LanguageManager = LM,
                Enabled = Settings.EdgeDetectionEnabled
            };
            cmbImageFilter = new TranslatableComboBox
            {
                LanguageManager = LM,
                Enabled = Settings.ImageFilterEnabled
            };
            cmbChannelRotation = new TranslatableComboBox
            {
                LanguageManager = LM,
                Enabled = Settings.ChannelRotationEnabled
            };

            cmbEdgeDetection.Items.Clear();
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.KayyaliEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.KirschEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.Laplacian3X3EdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.Laplacian5X5EdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.LaplacianOfGaussianEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.PrewittEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.RobertsEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.SharrEdgeFilter));
            cmbEdgeDetection.Items.Add(new EdgeDetectionFilterWrapper(EdgeDetectionFilter.SobelEdgeFilter));

            cmbEdgeDetection.SelectedItem = cmbEdgeDetection.Items.Find(x => (EdgeDetectionFilterWrapper)x == Settings.EdgeDetectionFilter);

            cmbImageFilter.Items.Clear();
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.BlackWhite));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Comic));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Gotham));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.GreyScale));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.HiSatch));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Invert));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Lomograph));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.LoSatch));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Polaroid));
            cmbImageFilter.Items.Add(new ImageFilterMatrixWrapper(ImageFilterMatrix.Sepia));

            cmbImageFilter.SelectedItem = cmbImageFilter.Items.Find(x => (ImageFilterMatrixWrapper)x == Settings.ImageFilterMatrix);

            cmbChannelRotation.Items.Clear();
            cmbChannelRotation.Items.Add(new ChannelRotationWrapper(ChannelRotation.RotateOnce));
            cmbChannelRotation.Items.Add(new ChannelRotationWrapper(ChannelRotation.RotateTwice));

            cmbChannelRotation.SelectedItem = cmbChannelRotation.Items.Find(x => (ChannelRotationWrapper)x == Settings.ChannelRotationValue);

            cmbEdgeDetection.SelectedIndexChanged += cmbEdgeDetection_SelectedIndexChanged;
            cmbImageFilter.SelectedIndexChanged += cmbImageFilter_SelectedIndexChanged;
            cmbChannelRotation.SelectedIndexChanged += cmbChannelRotation_SelectedIndexChanged;
            #endregion

            #region "Translatable Group Box"
            grpPreprocessing = new TranslatableGroupBox
            {
                TranslationString = "PREPROCESSING.LABEL.PREPROCESSING",
                LanguageManager = LM,
                Enabled = Settings.PreProcessingEnabled
            };
            #endregion

            #region "Translatable Label Format"
            lblBrightnessValue = new TranslatableLabelFormat
            {
                TranslationString = "PREPROCESSING.LABEL.BRIGHTNESS_VALUE",
                LanguageManager = LM,
                Parameters = new object[] { Settings.BrightnessValue }
            };
            lblSaturationValue = new TranslatableLabelFormat
            {
                TranslationString = "PREPROCESSING.LABEL.SATURATION_VALUE",
                LanguageManager = LM,
                Parameters = new object[] { Settings.SaturationValue }
            };
            lblContrastValue = new TranslatableLabelFormat
            {
                TranslationString = "PREPROCESSING.LABEL.CONTRAST_VALUE",
                LanguageManager = LM,
                Parameters = new object[] { Settings.ContrastValue }
            };
            lblHueValue = new TranslatableLabelFormat
            {
                TranslationString = "PREPROCESSING.LABEL.HUE_VALUE",
                LanguageManager = LM,
                Parameters = new object[] { Settings.HueValue }
            };
            #endregion

            #region "Layout"
            Layout.AddControl(chkPreprocessingEnabled);

            using (Layout.BeginGroupBox(grpPreprocessing))
            {
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkBrightnessEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(trkBrightness);
                }
                Layout.OffsetY(-25);
                Layout.AddControl(lblBrightnessValue);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkSaturationEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(trkSaturation);
                }
                Layout.OffsetY(-25);
                Layout.AddControl(lblSaturationValue);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkContrastEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(trkContrast);
                }
                Layout.OffsetY(-25);
                Layout.AddControl(lblContrastValue);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkHueEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(trkHue);
                }
                Layout.OffsetY(-25);
                Layout.AddControl(lblHueValue);

                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkGaussianBlurEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(numGaussianBlurKernelSize);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkGaussianSharpenEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(numGaussianSharpenKernelSize);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkPixelateEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(numPixelateSize);
                }

                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkVignetteEnabled);
                    Layout.ColumnWidth(75);
                    using (Layout.BeginRow())
                    {
                        Layout.AddControl(picVignetteColour);
                        Layout.ColumnWidth(33);
                        Layout.AddControl(btnVignetteColour);
                    }
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkTintEnabled);
                    Layout.ColumnWidth(75);
                    using (Layout.BeginRow())
                    {
                        Layout.AddControl(picTintColour);
                        Layout.ColumnWidth(33);
                        Layout.AddControl(btnTintColour);
                    }
                }

                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkEdgeDetectionEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(cmbEdgeDetection);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkImageFilterEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(cmbImageFilter);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkChannelRotationEnabled);
                    Layout.ColumnWidth(75);
                    Layout.AddControl(cmbChannelRotation);
                }
            }

            Layout.ProcessLayout();
            #endregion
        }

        private void btnTintColour_Click(object sender, EventArgs e)
        {
            cdgColourDialog.Color = picTintColour.BackColor;
            if (cdgColourDialog.ShowDialog() == DialogResult.OK)
            {
                picTintColour.BackColor = cdgColourDialog.Color;
                SettingChangedHandler?.Invoke(ProcessingSetting.TintColour, cdgColourDialog.Color);
            }
        }

        private void btnVignetteColour_Click(object sender, EventArgs e)
        {
            cdgColourDialog.Color = picVignetteColour.BackColor;
            if (cdgColourDialog.ShowDialog() == DialogResult.OK)
            {
                picVignetteColour.BackColor = cdgColourDialog.Color;
                SettingChangedHandler?.Invoke(ProcessingSetting.VignetteColour, cdgColourDialog.Color);
            }
        }

        private void chkBrightnessEnabled_CheckedChanged(object sender, EventArgs e)
        {
            trkBrightness.Enabled = chkBrightnessEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.BrightnessEnabled, chkBrightnessEnabled.Checked);
        }

        private void chkChannelRotationEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cmbChannelRotation.Enabled = chkChannelRotationEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.ChannelRotationEnabled, chkChannelRotationEnabled.Checked);
        }

        private void chkContrastEnabled_CheckedChanged(object sender, EventArgs e)
        {
            trkContrast.Enabled = chkContrastEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.ContrastEnabled, chkContrastEnabled.Checked);
        }

        private void chkEdgeDetectionEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cmbEdgeDetection.Enabled = chkEdgeDetectionEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.EdgeDetectionEnabled, chkEdgeDetectionEnabled.Checked);
        }

        private void chkGaussianBlurEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numGaussianBlurKernelSize.Enabled = chkGaussianBlurEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianBlurEnabled, chkGaussianBlurEnabled.Checked);
        }

        private void chkGaussianSharpenEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numGaussianSharpenKernelSize.Enabled = chkGaussianSharpenEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianSharpenEnabled, chkGaussianSharpenEnabled.Checked);
        }

        private void chkHueEnabled_CheckedChanged(object sender, EventArgs e)
        {
            trkHue.Enabled = chkHueEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.HueEnabled, chkHueEnabled.Checked);
        }

        private void chkImageFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cmbImageFilter.Enabled = chkImageFilterEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.ImageFilterEnabled, chkImageFilterEnabled.Checked);
        }

        private void chkPixelateEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numPixelateSize.Enabled = chkPixelateEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.PixelateEnabled, chkPixelateEnabled.Checked);
        }

        private void chkPreprocessingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            grpPreprocessing.Enabled = chkPreprocessingEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.PreProcessingEnabled, chkPreprocessingEnabled.Checked);
        }

        private void chkSaturationEnabled_CheckedChanged(object sender, EventArgs e)
        {
            trkSaturation.Enabled = chkSaturationEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.SaturationEnabled, chkSaturationEnabled.Checked);
        }

        private void chkTintEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnTintColour.Enabled = chkTintEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.TintEnabled, chkTintEnabled.Checked);
        }

        private void chkVignetteEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnVignetteColour.Enabled = chkVignetteEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.VignetteEnabled, chkVignetteEnabled.Checked);
        }

        private void cmbChannelRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChannelRotation.SelectedItem != null)
            {
                SettingChangedHandler?.Invoke(ProcessingSetting.ChannelRotationValue, cmbChannelRotation.SelectedItem);
            }
        }

        private void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEdgeDetection.SelectedItem != null)
            {
                SettingChangedHandler?.Invoke(ProcessingSetting.EdgeDetectionFilter, cmbEdgeDetection.SelectedItem);
            }
        }

        private void cmbImageFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImageFilter.SelectedItem != null)
            {
                SettingChangedHandler?.Invoke(ProcessingSetting.ImageFilterMatrix, cmbImageFilter.SelectedItem);
            }
        }

        private void numGaussianBlurKernelSize_ValueChanged(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianBlurSize, (int)numGaussianBlurKernelSize.Value);
        }

        private void numGaussianSharpenKernelSize_ValueChanged(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianSharpenSize, (int)numGaussianSharpenKernelSize.Value);
        }

        private void numPixelateSize_ValueChanged(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.PixelateSize, (int)numPixelateSize.Value);
        }

        private void ProcessingSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
            if (Parent is SettingsForm)
                (Parent as SettingsForm).ChildClosed(this);
        }

        private void trkBrightness_Scroll(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.BrightnessValue, trkBrightness.Value);
            lblBrightnessValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.BRIGHTNESS_VALUE", "PREPROCESSING.LABEL.BRIGHTNESS_VALUE {0}"), trkBrightness.Value);
        }

        private void trkContrast_Scroll(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.ContrastValue, trkContrast.Value);
            lblContrastValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.CONTRAST_VALUE", "PREPROCESSING.LABEL.CONTRAST_VALUE {0}"), trkContrast.Value);
        }

        private void trkHue_Scroll(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.HueValue, trkHue.Value);
            lblHueValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.HUE_VALUE", "PREPROCESSING.LABEL.HUE_VALUE {0}"), trkHue.Value);
        }

        private void trkSaturation_Scroll(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.SaturationValue, trkSaturation.Value);
            lblSaturationValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.SATURATION_VALUE", "PREPROCESSING.LABEL.SATURATION_VALUE {0}"), trkSaturation.Value);
        }
    }
}
