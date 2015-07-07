using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class SettingsForm : Form
    {
        new Form Parent;
        LanguageManager LM = GlobalVars.LanguageManager;

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

            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Centered);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Fill);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Fit);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Stretched);
            cmbWallpaperStyle.Items.Add(Wallpaper.WallpaperStyle.Tiled);

            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (Wallpaper.WallpaperStyle)x == Properties.Settings.Default.WallpaperStyle);

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Buttons.

            // Tooltips.

            // Labels.
            grpCompression.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION");
            lblCompressionLevel.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_LEVEL");
            lblCompressionWarning.Text = LM.GetString("SETTINGS_LABEL_COMPRESSION_WARNING");

            grpWallpaper.Text = LM.GetString("SETTINGS_LABEL_WALLPAPER");
            lblWallpaperStyle.Text = LM.GetString("SETTINGS_LABEL_WALLPAPER_STYLE");
            
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

        private void cmbWallpaperStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbWallpaperStyle.SelectedItem != null)
            {
                Properties.Settings.Default.WallpaperStyle = (Wallpaper.WallpaperStyle)cmbWallpaperStyle.SelectedItem;
            }
        }
    }
}
