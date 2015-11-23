using System;
using System.Drawing;
using System.Windows.Forms;
using WallChanger.Translation;

namespace WallChanger
{
    public partial class SettingsForm : Form
    {
        readonly LanguageManager LM = GlobalVars.LanguageManager;
        new readonly Form Parent;
        ProcessingSettingsForm ProcessingSettingsFormChild;

        TimingForm TimingFormChild;

        /// <summary>
        /// Initialises a new settings form.
        /// </summary>
        /// <param name="Parent">The parent that owns this form.</param>
        public SettingsForm(Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        /// <summary>
        /// Allows a new instance of the timing form to be opened.
        /// </summary>
        /// <param name="Child">The child that closed.</param>
        public void ChildClosed(Form Child)
        {
            if (Child is TimingForm)
                TimingFormChild = null;
            if (Child is ProcessingSettingsForm)
                ProcessingSettingsFormChild = null;
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE.SETTINGS");
            // Buttons.
            btnChangeDefaultTiming.Text = LM.GetString("SETTINGS.BUTTON.DEFAULT_TIMING");
            btnHighlightColour.Text = LM.GetString("SETTINGS.BUTTON.HIGHLIGHT_COLOUR");
            btnPreProcessingDefaults.Text = LM.GetString("SETTINGS.BUTTON.PREPROCESSING_DEFAULTS");
            // Tooltips.

            // Labels.
            grpCompression.Text = LM.GetString("SETTINGS.LABEL.COMPRESSION");
            lblCompressionLevel.Text = LM.GetString("SETTINGS.LABEL.COMPRESSION.LEVEL");
            lblCompressionWarning.Text = LM.GetString("SETTINGS.LABEL.COMPRESSION.WARNING");

            grpDefaults.Text = LM.GetString("SETTINGS.LABEL.DEFAULT");
            lblDefaultOffset.Text = string.Format(LM.GetString("SETTINGS.LABEL.DEFAULT.OFFSET"), Properties.Settings.Default.DefaultOffset);
            lblDefaultInterval.Text = string.Format(LM.GetString("SETTINGS.LABEL.DEFAULT.INTERVAL"), Properties.Settings.Default.DefaultInterval);
            chkDefaultRandomise.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.RANDOMISE");
            chkDefaultFading.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.FADING");
            lblDefaultWallpaperStyle.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.WALLPAPER_STYLE");
            chkGlobalRandomise.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.GLOBAL_RANDOMISE");
            chkGlobalFading.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.GLOBAL_FADING");
            chkGlobalWallpaperStyle.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.GLOBAL_WALLPAPER_STYLE");

            grpHighlight.Text = LM.GetString("SETTINGS.LABEL.HIGHLIGHT");
            lblHighlightMode.Text = LM.GetString("SETTINGS.LABEL.HIGHLIGHT.MODE");
            lblHighlightColour.Text = LM.GetString("SETTINGS.LABEL.HIGHLIGHT.COLOUR");
            picHighlightColour.Left = lblHighlightColour.Left + lblHighlightColour.Width + 6;

            cmbCompressionLevel.Items.Clear();
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.None));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Fast));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Low));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Normal));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.High));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Ultra));

            cmbCompressionLevel.SelectedItem = cmbCompressionLevel.Items.Find(x => (CompressionLevelWrapper)x == Properties.Settings.Default.CompressionLevel);

            cmbDefaultWallpaperStyle.Items.Clear();
            cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Fill));
            cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Fit));
            cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Stretched));
            cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Tiled));
            cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Centered));
            // Span only supported on windows 8+.
            if (Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1))
                cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Span));

            cmbDefaultWallpaperStyle.SelectedItem = cmbDefaultWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == Properties.Settings.Default.DefaultWallpaperStyle);

            cmbHighlightMode.Items.Clear();
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Bold));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Italic));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Foreground));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Background));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.None));

            cmbHighlightMode.SelectedItem = cmbHighlightMode.Items.Find(x => (HighlightModeWrapper)x == Properties.Settings.Default.HighlightMode);

            grpPreProcessing.Text = LM.GetString("SETTINGS.LABEL.PREPROCESSING");
            chkGlobalPreProcessing.Text = LM.GetString("SETTINGS.LABEL.GLOBAL_PREPROCESSING");

            grpMisc.Text = LM.GetString("SETTINGS.LABEL.MISCELLANEOUS");
            lblColourChangingDesc.Text = LM.GetString("SETTINGS.LABEL.COLOUR_CHANGE_DESC");
            chkDefaultColourChanging.Text = LM.GetString("SETTINGS.LABEL.DEFAULT.COLOUR_CHANGE");
            chkGlobalColourChanging.Text = LM.GetString("SETTINGS.LABEL.GLOBAL_COLOUR_CHANGE");
            chkRainbowMode.Text = LM.GetString("SETTINGS.LABEL.RAINBOW_MODE");

            // Cascade.
            if (TimingFormChild != null)
                TimingFormChild.LocaliseInterface();
            if (ProcessingSettingsFormChild != null)
                ProcessingSettingsFormChild.LocaliseInterface();
        }

        /// <summary>
        /// Saves the time settings as the default.
        /// </summary>
        /// <param name="Offset">The default offset value in milliseconds.</param>
        /// <param name="Interval">The default interval value in milliseconds.</param>
        public void SetTimes(int Offset, int Interval)
        {
            Properties.Settings.Default.DefaultOffset = Timing.ToString(Offset);
            Properties.Settings.Default.DefaultInterval = Timing.ToString(Interval);
            lblDefaultOffset.Text = string.Format(LM.GetString("SETTINGS.LABEL.DEFAULT.OFFSET"), Properties.Settings.Default.DefaultOffset);
            lblDefaultInterval.Text = string.Format(LM.GetString("SETTINGS.LABEL.DEFAULT.INTERVAL"), Properties.Settings.Default.DefaultInterval);
        }

        private static void ProcessingSettingsChanged(ProcessingSetting Setting, object Value)
        {
            switch (Setting)
            {
                case ProcessingSetting.PreProcessingEnabled:
                    Properties.Settings.Default.DefaultPreProcessingEnabled = (bool)Value;
                    break;
                case ProcessingSetting.BrightnessEnabled:
                    Properties.Settings.Default.DefaultBrightnessEnabled = (bool)Value;
                    break;
                case ProcessingSetting.BrightnessValue:
                    Properties.Settings.Default.DefaultBrightnessValue = (int)Value;
                    break;
                case ProcessingSetting.SaturationEnabled:
                    Properties.Settings.Default.DefaultSaturationEnabled = (bool)Value;
                    break;
                case ProcessingSetting.SaturationValue:
                    Properties.Settings.Default.DefaultSaturationValue = (int)Value;
                    break;
                case ProcessingSetting.ContrastEnabled:
                    Properties.Settings.Default.DefaultContrastEnabled = (bool)Value;
                    break;
                case ProcessingSetting.ContrastValue:
                    Properties.Settings.Default.DefaultContrastValue = (int)Value;
                    break;
                case ProcessingSetting.HueEnabled:
                    Properties.Settings.Default.DefaultHueEnabled = (bool)Value;
                    break;
                case ProcessingSetting.HueValue:
                    Properties.Settings.Default.DefaultHueValue = (int)Value;
                    break;
                case ProcessingSetting.GaussianBlurEnabled:
                    Properties.Settings.Default.DefaultGaussianBlurEnabled = (bool)Value;
                    break;
                case ProcessingSetting.GaussianBlurSize:
                    Properties.Settings.Default.DefaultGaussianBlurSize = (int)Value;
                    break;
                case ProcessingSetting.GaussianSharpenEnabled:
                    Properties.Settings.Default.DefaultGaussianSharpenEnabled = (bool)Value;
                    break;
                case ProcessingSetting.GaussianSharpenSize:
                    Properties.Settings.Default.DefaultGaussianSharpenSize = (int)Value;
                    break;
                case ProcessingSetting.PixelateEnabled:
                    Properties.Settings.Default.DefaultPixelateEnabled = (bool)Value;
                    break;
                case ProcessingSetting.PixelateSize:
                    Properties.Settings.Default.DefaultPixelateSize = (int)Value;
                    break;
                case ProcessingSetting.VignetteEnabled:
                    Properties.Settings.Default.DefaultVignetteEnabled = (bool)Value;
                    break;
                case ProcessingSetting.VignetteColour:
                    Properties.Settings.Default.DefaultVignetteColour = (Color)Value;
                    break;
                case ProcessingSetting.TintEnabled:
                    Properties.Settings.Default.DefaultTintEnabled = (bool)Value;
                    break;
                case ProcessingSetting.TintColour:
                    Properties.Settings.Default.DefaultTintColour = (Color)Value;
                    break;
                case ProcessingSetting.EdgeDetectionEnabled:
                    Properties.Settings.Default.DefaultEdgeDetectionEnabled = (bool)Value;
                    break;
                case ProcessingSetting.EdgeDetectionFilter:
                    Properties.Settings.Default.DefaultEdgeDetectionFilter = (EdgeDetectionFilterWrapper)Value;
                    break;
                case ProcessingSetting.ImageFilterEnabled:
                    Properties.Settings.Default.DefaultImageFilterEnabled = (bool)Value;
                    break;
                case ProcessingSetting.ImageFilterMatrix:
                    Properties.Settings.Default.DefaultImageFilterMatrix = (ImageFilterMatrixWrapper)Value;
                    break;
                case ProcessingSetting.ChannelRotationEnabled:
                    Properties.Settings.Default.DefaultChannelRotationEnabled = (bool)Value;
                    break;
                case ProcessingSetting.ChannelRotationValue:
                    Properties.Settings.Default.DefaultChannelRotationValue = (ChannelRotation)Value;
                    break;
            }
        }

        /// <summary>
        /// Opens a new timing form or swaps to an existing one.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnChangeDefaultTiming_Click(object sender, EventArgs e)
        {
            if (TimingFormChild == null)
            {
                TimingFormChild = new TimingForm(LM.GetString("STRING.DEFAULTS"), Timing.ParseTime(Properties.Settings.Default.DefaultOffset), Timing.ParseTime(Properties.Settings.Default.DefaultInterval), this);
                TimingFormChild.Show();
            }
            else
            {
                TimingFormChild.BringToFront();
            }
        }

        /// <summary>
        /// Prompts the user for a highlight colour.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnHighlightColour_Click(object sender, EventArgs e)
        {
            cdgColourDialog.Color = picHighlightColour.BackColor;
            if (cdgColourDialog.ShowDialog() == DialogResult.OK)
            {
                picHighlightColour.BackColor = cdgColourDialog.Color;
                Properties.Settings.Default.HighlightColour = cdgColourDialog.Color;
            }
        }

        private void btnPreProcessingDefaults_Click(object sender, EventArgs e)
        {
            if (ProcessingSettingsFormChild == null)
            {
                ProcessingSettingsFormChild = new ProcessingSettingsForm(LM.GetString("STRING.DEFAULTS"), ProcessingSettings.FromDefaults(), ProcessingSettingsChanged, this);
                ProcessingSettingsFormChild.Show();
            }
            else
            {
                ProcessingSettingsFormChild.BringToFront();
            }
        }

        private void chkDefaultColourChanging_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultColourSchemeEnabled = chkDefaultColourChanging.Checked;
        }

        /// <summary>
        /// Updates the default fade setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void chkDefaultFade_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultFading = chkDefaultFading.Checked;
        }

        /// <summary>
        /// Update the default randomisation setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void chkDefaultRandomise_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultRandomise = chkDefaultRandomise.Checked;
        }

        private void chkGlobalColourChanging_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlobalColourSchemeEnabled = chkGlobalColourChanging.Checked;
        }

        private void chkGlobalFading_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlobalFading = chkGlobalFading.Checked;
        }

        private void chkGlobalPreProcessing_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlobalPreProcessing = chkGlobalPreProcessing.Checked;
        }

        private void chkGlobalRandomise_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlobalRandomise = chkGlobalRandomise.Checked;
        }

        private void chkGlobalWallpaperStyle_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GlobalWallpaperStyle = chkGlobalWallpaperStyle.Checked;
        }

        private void chkRainbowMode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RainbowModeEnabled = chkRainbowMode.Checked;
            if (Properties.Settings.Default.RainbowModeEnabled)
            {
                System.Threading.Tasks.Task.Run(MainForm.Rainbow);
            }
        }

        /// <summary>
        /// Updates the compression setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void cmbCompressionLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCompressionLevel.SelectedItem != null)
            {
                Properties.Settings.Default.CompressionLevel = (CompressionLevelWrapper)cmbCompressionLevel.SelectedItem;
            }
        }

        /// <summary>
        /// Updates the wallpaper style setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void cmbDefaultWallpaperStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDefaultWallpaperStyle.SelectedItem != null)
            {
                Properties.Settings.Default.DefaultWallpaperStyle = (WallpaperStyleWrapper)cmbDefaultWallpaperStyle.SelectedItem;
            }
        }

        /// <summary>
        /// Updates the highlight mode setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void cmbHighlightMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbHighlightMode.SelectedItem != null)
            {
                Properties.Settings.Default.HighlightMode = (HighlightModeWrapper)cmbHighlightMode.SelectedItem;
            }
        }

        /// <summary>
        /// Notifies the parent of closure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
        }

        /// <summary>
        /// Sets up the form for use.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            picHighlightColour.BackColor = Properties.Settings.Default.HighlightColour;
            chkDefaultRandomise.Checked = Properties.Settings.Default.DefaultRandomise;
            chkDefaultFading.Checked = Properties.Settings.Default.DefaultFading;
            chkGlobalRandomise.Checked = Properties.Settings.Default.GlobalRandomise;
            chkGlobalFading.Checked = Properties.Settings.Default.GlobalFading;
            chkGlobalWallpaperStyle.Checked = Properties.Settings.Default.GlobalWallpaperStyle;
            chkGlobalPreProcessing.Checked = Properties.Settings.Default.GlobalPreProcessing;
            chkDefaultColourChanging.Checked = Properties.Settings.Default.DefaultColourSchemeEnabled;
            chkGlobalColourChanging.Checked = Properties.Settings.Default.GlobalColourSchemeEnabled;
            chkRainbowMode.Checked = Properties.Settings.Default.RainbowModeEnabled;
            LocaliseInterface();
        }
    }
}