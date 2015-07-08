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
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.None);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Fast);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Low);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Normal);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.High);
            cmbCompressionLevel.Items.Add(SevenZip.CompressionLevel.Ultra);

            cmbCompressionLevel.SelectedItem = cmbCompressionLevel.Items.Find(x => (SevenZip.CompressionLevel)x == Properties.Settings.Default.CompressionLevel);
            
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Fill);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Fit);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Stretched);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Tiled);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Centered);
            if (Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1))
                cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Span);

            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (Wallpaper.WallpaperStyle)x == Properties.Settings.Default.WallpaperStyle);

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Buttons.
            btnChangeDefaultTiming.Text = LM.GetString("SETTINGS_BUTTON_DEFAULT_TIMING");
            // Tooltips.

            // Labels.
            grpCompression.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION");
            lblCompressionLevel.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_LEVEL");
            lblCompressionWarning.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_WARNING");

            grpWallpaper.Text = LM.GetString("SETTINGS_LABEL_WALLPAPER");
            lblWallpaperStyle.Text = LM.GetString("SETTINGS_LABEL_WALLPAPER_STYLE");

            grpDefaults.Text = LM.GetString("SETTINGS_LABEL_DEFAULT");
            lblDefaultOffset.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_OFFSET"), Properties.Settings.Default.DefaultOffset);
            lblDefaultInterval.Text = string.Format(LM.GetString("SETTINGS_LABEL_DEFAULT_INTERVAL"), Properties.Settings.Default.DefaultInterval);
            chkDefaultRandomise.Text = LM.GetString("SETTINGS_LABEL_DEFAULT_RANDOMISE");
            chkDefaultFade.Text = LM.GetString("SETTINGS_LABEL_DEFAULT_FADE");

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
                Properties.Settings.Default.CompressionLevel = (SevenZip.CompressionLevel)cmbCompressionLevel.SelectedItem;
            }
        }

        /// <summary>
        /// Updates the wallpaper style setting.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void cmbWallpaperStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbWallpaperStyle.SelectedItem != null)
            {
                Properties.Settings.Default.WallpaperStyle = (Wallpaper.WallpaperStyle)cmbWallpaperStyle.SelectedItem;
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
    }
}