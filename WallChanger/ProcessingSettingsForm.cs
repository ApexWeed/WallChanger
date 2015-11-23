using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class ProcessingSettingsForm : Form
    {

        private readonly LanguageManager LM = GlobalVars.LanguageManager;
        new private readonly Form Parent;
        private EdgeDetectionFilter SelectedEDF;
        private ImageFilterMatrix SelectedMatrix;
        private ChannelRotation SelectedCR;
        private readonly SettingChanged SettingChangedHandler;
        private readonly string Source;

        public ProcessingSettingsForm(string Source, ProcessingSettings Settings, SettingChanged SettingChangedHandler, Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
            this.Source = Source;
            this.SettingChangedHandler = SettingChangedHandler;

            // Set control values.
            chkProcessingEnabled.Checked = Settings.PreProcessingEnabled;
            chkBrightnessEnabled.Checked = Settings.BrightnessEnabled;
            trkBrightness.Value = Settings.BrightnessValue.Clamp(trkBrightness.Minimum, trkBrightness.Maximum);
            chkSaturationEnabled.Checked = Settings.SaturationEnabled;
            trkSaturation.Value = Settings.SaturationValue.Clamp(trkSaturation.Minimum, trkSaturation.Maximum);
            chkContrastEnabled.Checked = Settings.ContrastEnabled;
            trkContrast.Value = Settings.ContrastValue.Clamp(trkContrast.Minimum, trkContrast.Maximum);
            chkHueEnabled.Checked = Settings.HueEnabled;
            trkHue.Value = Settings.HueValue.Clamp(trkHue.Minimum, trkHue.Maximum);
            chkGaussianBlurEnabled.Checked = Settings.GaussianBlurEnabled;
            numGaussianBlurKernel.Value = Settings.GaussianBlurSize.Clamp((int)numGaussianBlurKernel.Minimum, (int)numGaussianBlurKernel.Maximum);
            chkGaussianSharpenEnabled.Checked = Settings.GaussianSharpenEnabled;
            numGaussianSharpenKernel.Value = Settings.GaussianSharpenSize.Clamp((int)numGaussianSharpenKernel.Minimum, (int)numGaussianSharpenKernel.Maximum);
            chkPixelateEnabled.Checked = Settings.PixelateEnabled;
            numPixelateSize.Value = Settings.PixelateSize.Clamp((int)numPixelateSize.Minimum, (int)numPixelateSize.Maximum);
            chkVignetteEnabled.Checked = Settings.VignetteEnabled;
            picVignetteColour.BackColor = Settings.VignetteColour;
            chkTintEnabled.Checked = Settings.TintEnabled;
            picTintColour.BackColor = Settings.TintColour;
            chkEdgeDetectionEnabled.Checked = Settings.EdgeDetectionEnabled;
            SelectedEDF = Settings.EdgeDetectionFilter;
            chkImageFilterEnabled.Checked = Settings.ImageFilterEnabled;
            SelectedMatrix = Settings.ImageFilterMatrix;
            chkChannelRotationEnabled.Checked = Settings.ChannelRotationEnabled;
            SelectedCR = Settings.ChannelRotationValue;

            // Enable / disable initial state of controls.
            grpPreProcessing.Enabled = chkProcessingEnabled.Checked;
            trkBrightness.Enabled = chkBrightnessEnabled.Checked;
            trkSaturation.Enabled = chkSaturationEnabled.Checked;
            trkContrast.Enabled = chkContrastEnabled.Checked;
            trkHue.Enabled = chkHueEnabled.Checked;
            numGaussianBlurKernel.Enabled = chkGaussianBlurEnabled.Checked;
            numGaussianSharpenKernel.Enabled = chkGaussianSharpenEnabled.Checked;
            numPixelateSize.Enabled = chkPixelateEnabled.Checked;
            btnVignetteColour.Enabled = chkVignetteEnabled.Checked;
            btnTintColour.Enabled = chkVignetteEnabled.Checked;
            cmbEdgeDetection.Enabled = chkEdgeDetectionEnabled.Checked;
            cmbImageFilter.Enabled = chkImageFilterEnabled.Checked;
            cmbChannelRotation.Enabled = chkChannelRotationEnabled.Checked;

            LocaliseInterface();
        }
        /// <summary>
        /// Handles settings updating.
        /// </summary>
        /// <param name="ChangedSetting">The setting that has changed.</param>
        /// <param name="Value">The value the setting has been changed to.</param>
        public delegate void SettingChanged(ProcessingSetting ChangedSetting, object Value);

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = string.Format(LM.GetStringDefault("TITLE.PREPROCESSING", "TITLE.PREPROCESSING - {0}"), Source);

            // Buttons.
            btnTintColour.Text = LM.GetString("PREPROCESSING.BUTTON.TINT_COLOUR");
            btnVignetteColour.Text = LM.GetString("PREPROCESSING.BUTTON.VIGNETTE_COLOUR");

            // Tooltips.

            // Labels.
            grpPreProcessing.Text = LM.GetString("PREPROCESSING.LABEL.PREPROCESSING");

            chkProcessingEnabled.Text = LM.GetString("PREPROCESSING.LABEL.PREPROCESSING_ENABLED");
            chkBrightnessEnabled.Text = LM.GetString("PREPROCESSING.LABEL.BRIGHTNESS_ENABLED");
            chkSaturationEnabled.Text = LM.GetString("PREPROCESSING.LABEL.SATURATION_ENABLED");
            chkContrastEnabled.Text = LM.GetString("PREPROCESSING.LABEL.CONTRAST_ENABLED");
            chkHueEnabled.Text = LM.GetString("PREPROCESSING.LABEL.HUE_ENABLED");
            chkGaussianBlurEnabled.Text = LM.GetString("PREPROCESSING.LABEL.GAUSSIAN_BLUR_ENABLED");
            chkGaussianSharpenEnabled.Text = LM.GetString("PREPROCESSING.LABEL.GAUSSIAN_SHARPEN_ENABLED");
            chkPixelateEnabled.Text = LM.GetString("PREPROCESSING.LABEL.PIXELATE_ENABLED");
            chkVignetteEnabled.Text = LM.GetString("PREPROCESSING.LABEL.VIGNETTE_ENABLED");
            chkTintEnabled.Text = LM.GetString("PREPROCESSING.LABEL.TINT_ENABLED");
            chkEdgeDetectionEnabled.Text = LM.GetString("PREPROCESSING.LABEL.EDGE_DETECTION_ENABLED");
            chkImageFilterEnabled.Text = LM.GetString("PREPROCESSING.LABEL.IMAGE_FILTER_ENABLED");
            chkChannelRotationEnabled.Text = LM.GetString("PREPROCESSING.LABEL.CHANNEL_ROTATION_ENABLED");

            lblBrightnessValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.BRIGHTNESS_VALUE", "PREPROCESSING.LABEL.BRIGHTNESS_VALUE {0}"), trkBrightness.Value);
            lblSaturationValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.SATURATION_VALUE", "PREPROCESSING.LABEL.SATURATION_VALUE {0}"), trkSaturation.Value);
            lblContrastValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.CONTRAST_VALUE", "PREPROCESSING.LABEL.CONTRAST_VALUE {0}"), trkContrast.Value);
            lblHueValue.Text = string.Format(LM.GetStringDefault("PREPROCESSING.LABEL.HUE_VALUE", "PREPROCESSING.LABEL.HUE_VALUE {0}"), trkHue.Value);

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

            cmbEdgeDetection.SelectedItem = cmbEdgeDetection.Items.Find(x => (EdgeDetectionFilterWrapper)x == SelectedEDF);

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

            cmbImageFilter.SelectedItem = cmbImageFilter.Items.Find(x => (ImageFilterMatrixWrapper)x == SelectedMatrix);

            cmbChannelRotation.Items.Clear();
            cmbChannelRotation.Items.Add(new ChannelRotationWrapper(ChannelRotation.RotateOnce));
            cmbChannelRotation.Items.Add(new ChannelRotationWrapper(ChannelRotation.RotateTwice));

            cmbChannelRotation.SelectedItem = cmbChannelRotation.Items.Find(x => (ChannelRotationWrapper)x == SelectedCR);

            // Cascade.
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
            numGaussianBlurKernel.Enabled = chkGaussianBlurEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianBlurEnabled, chkGaussianBlurEnabled.Checked);
        }

        private void chkGaussianSharpenEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numGaussianSharpenKernel.Enabled = chkGaussianSharpenEnabled.Checked;
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

        private void chkProcessingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            grpPreProcessing.Enabled = chkProcessingEnabled.Checked;
            SettingChangedHandler?.Invoke(ProcessingSetting.PreProcessingEnabled, chkProcessingEnabled.Checked);
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
                SelectedCR = (ChannelRotationWrapper)cmbChannelRotation.SelectedItem;
            }
        }

        private void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEdgeDetection.SelectedItem != null)
            {
                SettingChangedHandler?.Invoke(ProcessingSetting.EdgeDetectionFilter, cmbEdgeDetection.SelectedItem);
                SelectedEDF = (EdgeDetectionFilterWrapper)cmbEdgeDetection.SelectedItem;
            }
        }

        private void cmbImageFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImageFilter.SelectedItem != null)
            {
                SettingChangedHandler?.Invoke(ProcessingSetting.ImageFilterMatrix, cmbImageFilter.SelectedItem);
                SelectedMatrix = (ImageFilterMatrixWrapper)cmbImageFilter.SelectedItem;
            }
        }

        private void numGaussianBlurKernel_ValueChanged(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianBlurSize, (int)numGaussianBlurKernel.Value);
        }

        private void numGaussianSharpenKernel_ValueChanged(object sender, EventArgs e)
        {
            SettingChangedHandler?.Invoke(ProcessingSetting.GaussianSharpenSize, (int)numGaussianSharpenKernel.Value);
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
