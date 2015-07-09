using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class SettingsForm : Form
    {
        new Form Parent;
        LanguageManager LM = GlobalVars.LanguageManager;

        TimingForm TimingFormChild = null;

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
        /// Sets up the form for use.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            picHighlightColour.BackColor = Properties.Settings.Default.HighlightColour;
            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE_SETTINGS");
            // Buttons.
            btnChangeDefaultTiming.Text = LM.GetString("SETTINGS_BUTTON_DEFAULT_TIMING");
            btnHighlightColour.Text = LM.GetString("SETTINGS_BUTTON_HIGHLIGHT_COLOUR");
            // Tooltips.

            // Labels.
            grpCompression.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION");
            lblCompressionLevel.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_LEVEL");
            lblCompressionWarning.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_WARNING");
            
            grpDefaults.Text = LM.GetString("SETTINGS_LABEL_DEFAULT");
            lblDefaultOffset.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_OFFSET"), Properties.Settings.Default.DefaultOffset);
            lblDefaultInterval.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_INTERVAL"), Properties.Settings.Default.DefaultInterval);
            chkDefaultRandomise.Text = LM.GetString("SETTINGS_LABEL_DEFAULT_RANDOMISE");
            chkDefaultFade.Text = LM.GetString("SETTINGS_LABEL_DEFAULT_FADE");
            lblDefaultWallpaperStyle.Text = LM.GetString("SETTINGS_LABEL_DEFAULT_WALLPAPER_STYLE");

            grpHighlight.Text = LM.GetString("SETTINGS_LABEL_HIGHLIGHT");
            lblHighlightMode.Text = LM.GetString("SETTINGS_LABEL_HIGHLIGHT_MODE");
            lblHighlightColour.Text = LM.GetString("SETTINGS_LABEL_HIGHLIGHT_COLOUR");
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
            if (Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1))
                cmbDefaultWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Span));

            cmbDefaultWallpaperStyle.SelectedItem = cmbDefaultWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == Properties.Settings.Default.DefaultWallpaperStyle);

            cmbHighlightMode.Items.Clear();
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode_.Bold));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode_.Italic));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode_.Foreground));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode_.Background));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode_.None));

            cmbHighlightMode.SelectedItem = cmbHighlightMode.Items.Find(x => (HighlightModeWrapper)x == Properties.Settings.Default.HighlightMode);

            // Cascade.
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
        /// Saves the time settings as the default.
        /// </summary>
        /// <param name="Offset">The default offset value in milliseconds.</param>
        /// <param name="Interval">The default interval value in milliseconds.</param>
        public void SetTimes(int Offset, int Interval)
        {
            Properties.Settings.Default.DefaultOffset = Timing.ToString(Offset);
            Properties.Settings.Default.DefaultInterval = Timing.ToString(Interval);
            lblDefaultOffset.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_OFFSET"), Properties.Settings.Default.DefaultOffset);
            lblDefaultInterval.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_INTERVAL"), Properties.Settings.Default.DefaultInterval);
        }

        /// <summary>
        /// Allows a new instance of the timing for to be opened.
        /// </summary>
        /// <param name="Child">The child that closed.</param>
        public void ChildClosed(Form Child)
        {
            TimingFormChild = null;
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

        /// <summary>
        /// Updates the default fade setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void chkDefaultFade_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultFade = chkDefaultFade.Checked;
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
                TimingFormChild = new TimingForm(Timing.ParseTime(Properties.Settings.Default.DefaultOffset), Timing.ParseTime(Properties.Settings.Default.DefaultInterval), this);
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
    }
}