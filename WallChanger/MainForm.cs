using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace WallChanger
{
    enum MoveDirection
    {
        Up,
        Down
    }

    public partial class MainForm : Form
    {
        const string REG_AUTORUN = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        readonly bool SupportsSpan = Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1);

        // Allow background thread to finish to avoid GDI+ errors.
        bool IsClosing;

        readonly Version AssemblyVersion;

        readonly List<string> FileList = new List<string>();
        readonly List<string> ConfigList = new List<string>();

        int Interval;
        int Offset;

        readonly bool AutoStarted;
        TimingForm TimingFormChild;
        LanguageForm LanguageFormChild;
        SettingsForm SettingsFormChild;
        int LastIndex;

        readonly LanguageManager LM;

        /// <summary>
        /// Creates a new instance of the main form.
        /// </summary>
        /// <param name="Hide">Whether this instance was auto run.</param>
        public MainForm(bool Hide)
        {
            InitializeComponent();

            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            AssemblyVersion = new Version(ProductVersion);

            AutoStarted = Hide;

            GlobalVars.ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);
            LM = GlobalVars.LanguageManager;
            Library.Load();
        }

        /// <summary>
        /// Initialises the form.
        /// </summary>
        /// <param name="sender">Sender that fired the event.</param>
        /// <param name="e">Event args associated with this event.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            chkStartup.Checked = (string)Registry.CurrentUser.OpenSubKey(REG_AUTORUN, true).GetValue(nameof(WallChanger)) == $"\"{Application.ExecutablePath}\" hide";

            LocaliseInterface();
            LoadSettings();

            //TimerWorker.RunWorkerAsync();

            if (AutoStarted)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                noiTray.Visible = true;
            }

            UpdateWallpaperAsync();
        }

        /// <summary>
        /// Sets the static strings to the chosen language.
        /// </summary>
        public void LocaliseInterface()
        {
            // Title.
            this.Text = LM.GetString("TITLE_MAIN");
            // Buttons.
            btnNewConfig.Text = LM.GetString("MAIN_BUTTON_NEW");
            btnRemoveConfig.Text = LM.GetString("MAIN_BUTTON_REMOVE");
            btnTiming.Text = LM.GetString("MAIN_BUTTON_TIMING");
            btnTray.Text = LM.GetString("MAIN_BUTTON_TRAY");
            btnReload.Text = LM.GetString("MAIN_BUTTON_RELOAD");
            btnSave.Text = LM.GetString("MAIN_BUTTON_SAVE");
            // Tooltips.
            ToolTips.SetToolTip(btnAddImage, LM.GetString("MAIN_TOOLTIP_ADD"));
            ToolTips.SetToolTip(btnRemoveImage, LM.GetString("MAIN_TOOLTIP_REMOVE"));
            ToolTips.SetToolTip(btnMoveUp, LM.GetString("MAIN_TOOLTIP_MOVE_UP"));
            ToolTips.SetToolTip(btnMoveDown, LM.GetString("MAIN_TOOLTIP_MOVE_DOWN"));
            ToolTips.SetToolTip(btnClear, LM.GetString("MAIN_TOOLTIP_CLEAR"));
            ToolTips.SetToolTip(btnLibrary, LM.GetString("MAIN_TOOLTIP_LIBRARY"));
            ToolTips.SetToolTip(btnAddToLibrary, LM.GetString("MAIN_TOOLTIP_LIBRARY_ADD"));
            ToolTips.SetToolTip(btnLanguage, LM.GetString("MAIN_TOOLTIP_LANGUAGE"));
            ToolTips.SetToolTip(btnSettings, LM.GetString("MAIN_TOOLTIP_SETTINGS"));
            // Labels.
            grpConfig.Text = LM.GetString("MAIN_LABEL_CONFIGS");
            grpImages.Text = string.Format(LM.GetString("MAIN_LABEL_IMAGES"), Properties.Settings.Default.CurrentConfig);
            chkStartup.Text = LM.GetString("MAIN_LABEL_STARTUP");
            chkRandomise.Text = LM.GetString("MAIN_LABEL_RANDOMISE");
            chkFade.Text = LM.GetString("MAIN_LABEL_FADE");

            Wallpaper.WallpaperStyle style;
            style = cmbWallpaperStyle.SelectedItem != null ? (WallpaperStyleWrapper)cmbWallpaperStyle.SelectedItem : new WallpaperStyleWrapper(Properties.Settings.Default.DefaultWallpaperStyle);

            cmbWallpaperStyle.Items.Clear();
            cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Fill));
            cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Fit));
            cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Stretched));
            cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Tiled));
            cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Centered));
            if (Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1))
                cmbWallpaperStyle.Items.Add(new WallpaperStyleWrapper(Wallpaper.WallpaperStyle.Span));
            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == style);

            // Cascade.
            if (TimingFormChild != null)
                TimingFormChild.LocaliseInterface();
            if (SettingsFormChild != null)
                SettingsFormChild.LocaliseInterface();
            if (GlobalVars.LibraryForm != null)
                GlobalVars.LibraryForm.LocaliseInterface();
        }

        /// <summary>
        /// Loads the settings and converts the old settings selection to the new storage format.
        /// </summary>
        private void LoadSettings()
        {
            if (Properties.Settings.Default.CurrentConfig == "")
            {
                if (File.Exists(Path.Combine(GlobalVars.ApplicationPath, @"config.cfg")))
                {
                    using (var read = new StreamReader(Path.Combine(GlobalVars.ApplicationPath, @"config.cfg")))
                    {
                        Properties.Settings.Default.CurrentConfig = read.ReadLine();
                        read.Close();
                        File.Delete(Path.Combine(GlobalVars.ApplicationPath, @"config.cfg"));

                        LoadConfigs();
                        LoadConfig();
                    }
                }
                else
                {
                    CreateConfig("default");
                }
            }
            else
            {
                LoadConfigs();
                LoadConfig();
            }
        }

        /// <summary>
        /// Creates a blank configuration file witn the specified name.
        /// </summary>
        /// <param name="name">The name to call the config.</param>
        private void CreateConfig(string name)
        {
            var file = File.Create(Path.Combine(GlobalVars.ApplicationPath, $"{name}.cfg"));
            file.Close();

            Offset = Timing.ParseTime(Properties.Settings.Default.DefaultOffset);
            Interval = Timing.ParseTime(Properties.Settings.Default.DefaultInterval);
            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == Properties.Settings.Default.DefaultWallpaperStyle);
            Properties.Settings.Default.CurrentConfig = name;
            FileList.Clear();

            SaveSettings();
            LoadConfig();
            LoadConfigs();
        }

        /// <summary>
        /// Loads the list of config files.
        /// </summary>
        private void LoadConfigs()
        {
            ConfigList.Clear();
            var files = Directory.GetFiles(GlobalVars.ApplicationPath);
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".cfg" && Path.GetFileNameWithoutExtension(file) != "library" && Path.GetFileNameWithoutExtension(file) != "sizecache")
                    ConfigList.Add(Path.GetFileNameWithoutExtension(file));
            }
            FillConfigList();
        }

        /// <summary>
        /// Loads the config file with the specified name.
        /// </summary>
        /// <param name="Config">Name of the config to load.</param>
        private void LoadConfig(string Config)
        {
            Properties.Settings.Default.CurrentConfig = Config;
            LoadConfig();
        }

        /// <summary>
        /// Loads the currently active config file.
        /// </summary>
        private void LoadConfig()
        {
            grpImages.Text = string.Format(LM.GetString("MAIN_LABEL_IMAGES"), Properties.Settings.Default.CurrentConfig);

            if (!File.Exists(Path.Combine(GlobalVars.ApplicationPath, $"{Properties.Settings.Default.CurrentConfig}.cfg")))
            {
                MessageBox.Show(string.Format(LM.GetString("MAIN_MESSAGE_CONFIG_MISSING"), Properties.Settings.Default.CurrentConfig));
                CreateConfig(Properties.Settings.Default.CurrentConfig);
                return;
            }

            using (
            var read = new StreamReader(Path.Combine(GlobalVars.ApplicationPath, $"{Properties.Settings.Default.CurrentConfig}.cfg")))
            {

                // Set defaults.
                Offset = Timing.ParseTime(Properties.Settings.Default.DefaultOffset);
                Interval = Timing.ParseTime(Properties.Settings.Default.DefaultInterval);
                chkRandomise.Checked = Properties.Settings.Default.DefaultRandomise;
                chkFade.Checked = Properties.Settings.Default.DefaultFading;
                cmbWallpaperStyle.SelectedIndex = 0;

                var firstLine = read.ReadLine().Trim();
                if (firstLine.StartsWith("Version="))
                {
                    // New format.
                    var FileVersion = new Version(firstLine.Split('=')[1].Trim());
                    if (FileVersion.Major > AssemblyVersion.Major)
                    {
                        MessageBox.Show(string.Format(LM.GetStringDefault("MAIN_MESSAGE_VERSION_TOO_LOW", "MAIN_MESSAGE_TOO_LOW {0} {1}.{2} > {3}"), Properties.Settings.Default.CurrentConfig, FileVersion.Major, FileVersion.Minor, AssemblyVersion));
                        read.Close();
                        return;
                    }
                    else
                    {
                        if (FileVersion.Minor > AssemblyVersion.Minor)
                        {
                            MessageBox.Show(string.Format(LM.GetStringDefault("MAIN_MESSAGE_VERSION_TOO_LOW", "MAIN_MESSAGE_TOO_LOW {0} {1}.{2} > {3}"), Properties.Settings.Default.CurrentConfig, FileVersion.Major, FileVersion.Minor, AssemblyVersion));
                            read.Close();
                            return;
                        }
                        else
                        {
                            FileList.Clear();
                            while (!read.EndOfStream)
                            {
                                var Line = read.ReadLine().Trim();
                                var Parts = Line.Split('=');
                                if (Parts.Count() != 2)
                                    continue;

                                switch (Parts[0].Trim())
                                {
#pragma warning disable CC0021 // Use nameof
                                    case "Offset":
#pragma warning restore CC0021 // Use nameof
                                        Offset = Timing.ParseTime(Parts[1].Trim());
                                        break;
#pragma warning disable CC0021 // Use nameof
                                    case "Interval":
#pragma warning restore CC0021 // Use nameof
                                        Interval = Timing.ParseTime(Parts[1].Trim());
                                        break;
                                    case "Randomise":
                                        var randomiseValue = false;
                                        bool.TryParse(Parts[1].Trim(), out randomiseValue);
                                        chkRandomise.Checked = randomiseValue;
                                        break;
                                    case "Fade":
                                        var fadeValue = false;
                                        bool.TryParse(Parts[1].Trim(), out fadeValue);
                                        chkFade.Checked = fadeValue;
                                        break;
                                    case "WallpaperStyle":
                                        var style = Parts[1].Trim().ToEnum(Properties.Settings.Default.DefaultWallpaperStyle);
                                        if (style != Wallpaper.WallpaperStyle.Span || SupportsSpan)
                                        {
                                            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == style);
                                        }
                                        else
                                        {
                                            // Span is not supported on Windows 7.
                                            MessageBox.Show(string.Format(LM.GetString("MAIN_MESSAGE_SPAN_UNSUPPORTED"), new WallpaperStyleWrapper(Properties.Settings.Default.DefaultWallpaperStyle)));
                                            cmbWallpaperStyle.SelectedItem = cmbWallpaperStyle.Items.Find(x => (WallpaperStyleWrapper)x == Properties.Settings.Default.DefaultWallpaperStyle);
                                        }
                                        break;
                                    case "Image":
                                        FileList.Add(Parts[1].Trim());
                                        break;
                                }
                            }
                        }
                    }
                    read.Close();
                }
                else
                {
                    // Old format.
                    Offset = Timing.ParseTime(firstLine);
                    Interval = Timing.ParseTime(read.ReadLine());

                    FileList.Clear();
                    while (!read.EndOfStream)
                    {
                        FileList.Add(read.ReadLine());
                    }

                    read.Close();

                    // Immediately save updated version.
                    SaveSettings();
                }

                FillImageList();
            }
        }

        /// <summary>
        /// Saves the current config file.
        /// </summary>
        private void SaveSettings()
        {
            if (Interval == 0)
            {
                // Application has just started up, don't overwrite with blank config.
                return;
            }
            using (var write = new StreamWriter(Path.Combine(GlobalVars.ApplicationPath, $"{Properties.Settings.Default.CurrentConfig}.cfg")))
            {
                write.WriteLine($"Version={AssemblyVersion}");
                write.WriteLine($"Offset={Timing.ToString(Offset)}");
                write.WriteLine($"Interval={Timing.ToString(Interval)}");
                write.WriteLine($"Randomise={chkRandomise.Checked}");
                write.WriteLine($"Fade={chkFade.Checked}");
                write.WriteLine($"WallpaperStyle={(Wallpaper.WallpaperStyle)(WallpaperStyleWrapper)cmbWallpaperStyle.SelectedItem}");
                foreach (string image in FileList)
                {
                    write.WriteLine($"Image={image}");
                }
            }
        }

#pragma warning disable CC0057 // Unused parameters
                              /// <summary>
                              /// Refills the list with the current files.
                              /// </summary>
                              /// <param name="PreserveScrolling">Not yet implemented.</param>
        private void FillImageList(bool PreserveScrolling = false)
#pragma warning restore CC0057 // Unused parameters
        {
            lstImages.HighlightColour = Properties.Settings.Default.HighlightColour;
            lstImages.HighlightMode = Properties.Settings.Default.HighlightMode;
            if (lstImages.Items.Count == FileList.Count())
            {
                if ((Properties.Settings.Default.GlobalRandomise && Properties.Settings.Default.DefaultRandomise) || (!Properties.Settings.Default.GlobalRandomise && chkRandomise.Checked))
                {
                    for (int i = 0; i < FileList.Count; i++)
                    {
                        lstImages.Items[i] = FileList[i];
                    }
                }
                else
                {
                    var outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    var parsedTime = Timing.ParseTime(outputTime) - Offset;
                    var index = parsedTime / Interval;
                    var remainder = FileList.Count == 0 ? 0 : index % FileList.Count;
                    var iteration = (index - remainder) / (FileList.Count == 0 ? 1 : FileList.Count);

                    var showTime = new DateTime().AddYears(10).AddSeconds((Offset - Interval) / 1000).AddSeconds((Interval * iteration * FileList.Count) / 1000);
                    for (int i = 0; i < FileList.Count; i++)
                    {
                        showTime = showTime.AddSeconds(Interval / 1000);
                        if (i < remainder)
                            lstImages.Items[i] = new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime.AddSeconds((Interval * FileList.Count) / 1000), FileList[i]), false);
                        else if (i == remainder)
                            lstImages.Items[i] = new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]), true);
                        else
                            lstImages.Items[i] = new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]), false);
                    }
                }
            }
            else
            {
                lstImages.Items.Clear();

                if ((Properties.Settings.Default.GlobalRandomise && Properties.Settings.Default.DefaultRandomise) || (!Properties.Settings.Default.GlobalRandomise && chkRandomise.Checked))
                {
                    foreach (var File in FileList)
                    {
                        lstImages.Items.Add(File);
                    }
                }
                else
                {
                    var outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    var parsedTime = Timing.ParseTime(outputTime) - Offset;
                    var index = parsedTime / Interval;
                    var remainder = FileList.Count == 0 ? 0 : index % FileList.Count;
                    var iteration = (index - remainder) / (FileList.Count == 0 ? 1 : FileList.Count);

                    var showTime = new DateTime().AddYears(10).AddSeconds((Offset - Interval) / 1000).AddSeconds((Interval * iteration * FileList.Count) / 1000);
                    for (int i = 0; i < FileList.Count; i++)
                    {
                        showTime = showTime.AddSeconds(Interval / 1000);
                        if (i < remainder)
                            lstImages.Items.Add(new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime.AddSeconds((Interval * FileList.Count) / 1000), FileList[i]), false));
                        else if (i == remainder)
                            lstImages.Items.Add(new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]), true));
                        else
                            lstImages.Items.Add(new ImageEntry(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]), false));
                    }
                }
            }
        }

        /// <summary>
        /// Fills the config list.
        /// </summary>
        private void FillConfigList()
        {
            lstConfigs.Items.Clear();
            foreach (string config in ConfigList)
            {
                lstConfigs.Items.Add(config);
            }

            lstConfigs.SelectedIndex = lstConfigs.FindStringExact(Properties.Settings.Default.CurrentConfig, 0);
        }

        /// <summary>
        /// Sets the wallpaper using the current index.
        /// </summary>
        private void SetWallpaper()
        {
            var outputTime = DateTime.Now.ToString(@"H \h m \m s \s");
            var parsedTime = Timing.ParseTime(outputTime);
            var index = parsedTime / Interval;

            SetWallpaper(index);
        }

        /// <summary>
        /// Sets the wallpaper to the specified index.
        /// </summary>
        /// <param name="Index">Index in the file list.</param>
        private void SetWallpaper(int Index)
        {
            if (FileList.Count > 0)
            {
                while (Index < 0)
                {
                    Index = FileList.Count + Index;
                }
                if (Index >= FileList.Count)
                    Index = Index % FileList.Count;
                if (File.Exists(FileList[(Index) % FileList.Count]))
                {
                    Wallpaper.Set(FileList[(Index) % FileList.Count], (Wallpaper.WallpaperStyle)cmbWallpaperStyle.SelectedItem);
                }
                else
                {
                    FileList.RemoveAt((Index) % FileList.Count);
                    FillImageList();
                    MessageBox.Show(string.Format(LM.GetStringDefault("MAIN_MESSAGE_IMAGE_MISSING", "MAIN_MESSAGE_IMAGE_MISSING\n{0}"), FileList[(Index) % FileList.Count]));
                    SetWallpaper(Index);
                }
            }
        }

        private async void UpdateWallpaperAsync()
        {
            string loadedConfig;
            string outputTime;
            int parsedTime;
            int index;
            int sleepTime;
            int delayTime;
            var rnd = new Random();
            while (true)
            {
                loadedConfig = Properties.Settings.Default.CurrentConfig;
                if (chkRandomise.Checked)
                {
                    index = rnd.Next(FileList.Count);
                }
                else
                {
                    outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    parsedTime = Timing.ParseTime(outputTime) - Offset;
                    index = parsedTime / Interval;
                }

                // Set wallpaper.
                var wallpaperChanged = false;
                while (!wallpaperChanged && FileList.Count > 0)
                {
                    while (index < 0)
                    {
                        index = FileList.Count + index;
                    }
                    if (index >= FileList.Count)
                        index = index % FileList.Count;
                    if (File.Exists(FileList[(index) % FileList.Count]))
                    {
                        if ((Properties.Settings.Default.GlobalFading && Properties.Settings.Default.DefaultFading) || (!Properties.Settings.Default.GlobalFading && chkFade.Checked))
                            Wallpaper.FadeSet(FileList[(index) % FileList.Count], (WallpaperStyleWrapper)cmbWallpaperStyle.SelectedItem);
                        else
                            Wallpaper.SetAsync(FileList[(index) % FileList.Count], (WallpaperStyleWrapper)cmbWallpaperStyle.SelectedItem);

                        wallpaperChanged = true;
                    }
                    else
                    {
                        MessageBox.Show(string.Format(LM.GetStringDefault("MAIN_MESSAGE_IMAGE_MISSING", "MAIN_MESSAGE_IMAGE_MISSING\n{0}"), FileList[(index) % FileList.Count]));
                        FileList.RemoveAt((index) % FileList.Count);
                        try
                        {
                            FillImageList();
                        }
                        catch (ObjectDisposedException)
                        {
                            // Program is closing.
                            return;
                        }
                    }
                }

                do
                {
                    outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    parsedTime = Timing.ParseTime(outputTime) - Offset;
                    sleepTime = (parsedTime % Interval == 0) ? Interval : (Interval - parsedTime % Interval);
                    delayTime = sleepTime > 1000 ? 1000 : sleepTime;

                    // Report progress.
                    var nextChange = DateTime.Now.AddMilliseconds(sleepTime);
                    var nextChangeTimeSpan = nextChange - DateTime.Now;
                    lblNextChange.Text = string.Format(LM.GetStringDefault("MAIN_LABEL_NEXT_CHANGE", "NEXT_CHANGE: {0:hh\\:mm\\:ss}"), nextChangeTimeSpan);
                    noiTray.Text = string.Format(LM.GetStringDefault("TRAY_LABEL_NEXT_CHANGE", "NEXT_CHANGE: {0:hh\\:mm\\:ss}"), nextChangeTimeSpan);
                    LastIndex = index;

                    try
                    {
                        FillImageList();
                    }
                    catch (ObjectDisposedException)
                    {
                        // Program is closing.
                        return;
                    }

                    await Task.Run(() => System.Threading.Thread.Sleep(delayTime));
                    if (IsClosing)
                        this.Close();
                } while (delayTime == 1000 && loadedConfig == Properties.Settings.Default.CurrentConfig);
            }
        }

        /// <summary>
        /// Makes the main window visible.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void noiTray_Click(object sender, EventArgs e)
        {
            noiTray.Visible = false;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        /// <summary>
        /// Updates the startup key in the registry.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            var StartupKey = Registry.CurrentUser.OpenSubKey(REG_AUTORUN, true);
            if (chkStartup.Checked)
            {
                StartupKey.SetValue(nameof(WallChanger), $"\"{Application.ExecutablePath}\" hide");
            }
            else
            {
                StartupKey.DeleteValue(nameof(WallChanger), false);
            }
        }

        /// <summary>
        /// Asks the user to select images to add to the active config.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (ofdAdd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofdAdd.FileNames)
                {
                    using (Stream read = File.Open(file, FileMode.Open))
                    {
                        if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                            continue;
                        FileList.Add(file);
                    }
                }
                FillImageList();
            }
        }

        /// <summary>
        /// Removes selected images from the current config.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            var indexArray = new int[lstImages.SelectedIndices.Count];
            lstImages.SelectedIndices.CopyTo(indexArray, 0);
            Array.Sort(indexArray, (a, b) => b.CompareTo(a));
            foreach (int index in indexArray)
            {
                FileList.RemoveAt(index);
            }

            FillImageList();
        }

        /// <summary>
        /// Minimises the form to the tray.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnTray_Click(object sender, EventArgs e)
        {
            Minimise();
        }

        /// <summary>
        /// Minimises the form.
        /// </summary>
        private void Minimise()
        {
            this.Hide();
            this.ShowInTaskbar = false;
            noiTray.Visible = true;
        }

        /// <summary>
        /// Saves the settings to disk.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Reloads the settings from disk.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

#pragma warning disable CC0091 // Use static method
                              /// <summary>
                              /// Updates the cursor when the user drags something onto the window.
                              /// </summary>
                              /// <param name="sender">Object that triggered the event.</param>
                              /// <param name="e">Arguments.</param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
#pragma warning restore CC0091 // Use static method
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Loads the dropped files into the current config.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in paths)
            {
                LoadImages(path);
            }
            FillImageList();
        }

        /// <summary>
        /// Loads the files in the supplied path into the current config if they are images.
        /// </summary>
        /// <param name="FilePath">Path to load images from.</param>
        private void LoadImages(string FilePath)
        {
            if (Directory.Exists(FilePath))
            {
                foreach (string directory in Directory.GetDirectories(FilePath))
                    LoadImages(directory);

                foreach (string file in Directory.GetFiles(FilePath))
                {
                    using (Stream read = File.Open(file, FileMode.Open))
                    {
                        if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                        {
                            read.Close();
                            continue;
                        }
                        FileList.Add(file);
                    }
                }
            }
            else
            {
                using (Stream read = File.Open(FilePath, FileMode.Open))
                {
                    if (Imaging.GetImageFormat(read) == Imaging.ImageFormat.unknown)
                    {
                        read.Close();
                        return;
                    }
                    FileList.Add(FilePath);
                }
            }
        }

        /// <summary>
        /// Updates the times in the image list.
        /// </summary>
        /// <param name="Offset">The offset from 0 that should be applied.</param>
        /// <param name="Interval">The interval that the images should change at.</param>
        public void SetTimes(int Offset, int Interval)
        {
            this.Offset = Offset;
            this.Interval = Interval;

            FillImageList();
        }

        /// <summary>
        /// Opens the timing form or swaps to it if it is already open.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnTiming_Click(object sender, EventArgs e)
        {
            if (TimingFormChild == null)
            {
                TimingFormChild = new TimingForm(Offset, Interval, this);
                TimingFormChild.Show();
            }
            else
            {
                TimingFormChild.BringToFront();
            }
        }

        /// <summary>
        /// Updates the current config when the user selects a new one.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void lstConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSettings();
            LoadConfig(lstConfigs.SelectedItem.ToString());
        }

        /// <summary>
        /// Prompts the user for a new config name.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            var configName = Prompt.ShowStringDialog(LM.GetString("MAIN_MESSAGE_NEW_CONFIG"), LM.GetString("MAIN_MESSAGE_NEW_CONFIG_TITLE"), LM.GetString("MAIN_MESSAGE_NEW_CONFIG_DEFAULT"));
            if (configName != null)
                CreateConfig(configName);
        }

        /// <summary>
        /// Removes the selected config from disk.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnRemoveConfig_Click(object sender, EventArgs e)
        {
            if (Prompt.ShowStringDialog(string.Format(LM.GetString("MAIN_MESSAGE_DELETE_CONFIG"), lstConfigs.SelectedItem as string), LM.GetString("MAIN_MESSAGE_DELETE_CONFIG_TITLE")) == lstConfigs.SelectedItem as string)
            {
                File.Delete(GlobalVars.ApplicationPath + "\\" + lstConfigs.SelectedItem as string + ".cfg");
                LoadConfigs();
                LoadConfig(ConfigList[0]);
            }
        }

        /// <summary>
        /// Moves the current selection up or down.
        /// </summary>
        /// <param name="Direction">Direction to move the selection.</param>
        private void MoveSelection(MoveDirection Direction)
        {
            var indexArray = new int[lstImages.SelectedIndices.Count];
            lstImages.SelectedIndices.CopyTo(indexArray, 0);
            var newSelection = new List<int>();
            if (Direction == MoveDirection.Up)
            {
                Array.Sort(indexArray, (a, b) => a.CompareTo(b));
                for (int i = 0; i < indexArray.Length; i++)
                {
                    // Can't move above first index.
                    if (indexArray[i] == 0)
                    {
                        newSelection.Add(indexArray[i]);
                        indexArray[i] = -1;
                        continue;
                    }

                    // Last index was unable to move. Either first index or group is already at the top.
                    if (i > 0 && indexArray[i - 1] == -1)
                    {
                        newSelection.Add(indexArray[i]);
                        indexArray[i] = -1;
                        continue;
                    }

                    var value = FileList[indexArray[i] - 1] as string;
                    FileList[indexArray[i] - 1] = FileList[indexArray[i]];
                    FileList[indexArray[i]] = value;
                    newSelection.Add(indexArray[i] - 1);
                }
            }
            else if (Direction == MoveDirection.Down)
            {
                Array.Sort(indexArray, (a, b) => b.CompareTo(a));
                for (int i = 0; i < indexArray.Length; i++)
                {
                    // Can't move below last index.
                    if (indexArray[i] == FileList.Count - 1)
                    {
                        newSelection.Add(indexArray[i]);
                        indexArray[i] = -1;
                        continue;
                    }

                    // Last index was unable to move. Either first index or group is already at the top.
                    if (i > 0 && indexArray[i - 1] == -1)
                    {
                        newSelection.Add(indexArray[i]);
                        indexArray[i] = -1;
                        continue;
                    }

                    var value = FileList[indexArray[i] + 1] as string;
                    FileList[indexArray[i] + 1] = FileList[indexArray[i]];
                    FileList[indexArray[i]] = value;
                    newSelection.Add(indexArray[i] + 1);
                }
            }
            FillImageList();
            SetSelection(lstImages, newSelection.ToArray());
        }

        /// <summary>
        /// Sets the selection in a listbox.
        /// </summary>
        /// <param name="ListBoxControl">The listbox to update.</param>
        /// <param name="Selection">The indexes to select.</param>
        private static void SetSelection(ListBox ListBoxControl, int[] Selection)
        {
            foreach (int Index in Selection)
            {
                ListBoxControl.SetSelected(Index, true);
            }
        }

        /// <summary>
        /// Moves the selection up.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelection(MoveDirection.Up);
        }

        /// <summary>
        /// Move sthe selection down.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelection(MoveDirection.Down);
        }

        /// <summary>
        /// Removes all images from the current config.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            FillImageList();
        }

        /// <summary>
        /// Opens the library form.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnLibrary_Click(object sender, EventArgs e)
        {
            if (GlobalVars.LibraryForm == null)
            {
                GlobalVars.LibraryForm = new LibraryForm(this);
                GlobalVars.LibraryForm.Show();
            }
            else
            {
                GlobalVars.LibraryForm.BringToFront();
            }
        }

        /// <summary>
        /// Used by children to allow new copies to be opened.
        /// </summary>
        /// <param name="Child">The child that has closed.</param>
        public void ChildClosed(Form Child)
        {
            if (Child is LibraryForm)
                GlobalVars.LibraryForm = null;
            if (Child is LanguageForm)
                LanguageFormChild = null;
            if (Child is SettingsForm)
                SettingsFormChild = null;
            if (Child is TimingForm)
                TimingFormChild = null;
        }

        /// <summary>
        /// Adds the list of iamges to the current config.
        /// </summary>
        /// <param name="Images">The images to add to the list.</param>
        public void AddImages(IEnumerable<string> Images)
        {
            FileList.AddRange(Images);
            FillImageList();
        }

        /// <summary>
        /// Adds the selected images to the library and triggers and update of the library form if it is open.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnAddToLibrary_Click(object sender, EventArgs e)
        {
            foreach (string image in FileList)
            {
                GlobalVars.LibraryItems.AddDistinct(new LibraryItem(image));
            }

            Library.Save();

            if (GlobalVars.LibraryForm != null)
                GlobalVars.LibraryForm.UpdateList();
        }

        /// <summary>
        /// Opens the language form.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (LanguageFormChild == null)
            {
                LanguageFormChild = new LanguageForm(this);
                LanguageFormChild.Show();
            }
            else
            {
                LanguageFormChild.BringToFront();
            }
        }

        /// <summary>
        /// Opens the settings form.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (SettingsFormChild == null)
            {
                SettingsFormChild = new SettingsForm(this);
                SettingsFormChild.Show();
            }
            else
            {
                SettingsFormChild.BringToFront();
            }
        }

        /// <summary>
        /// Saves the library and configuration files.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.Save();
            Properties.Settings.Default.Save();
            SaveSettings();
        }

        /// <summary>
        /// Handles windows message for minimise.
        /// </summary>
        /// <param name="message">The windows message.</param>
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int WM_CLOSE = 0x0010;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;
            const int SC_MINIMIZE = 0xF020;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    var command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MAXIMIZE)
                    {

                    }
                    if (command == SC_RESTORE)
                    {

                    }
                    if (command == SC_MINIMIZE)
                    {
                        Minimise();
                        return;
                    }
                    break;
                case WM_CLOSE:
                    if (IsClosing)
                        base.WndProc(ref message);
                    else
                        IsClosing = true;
                    return;
            }

            base.WndProc(ref message);
        }

        private void chkRandomise_CheckedChanged(object sender, EventArgs e)
        {
            FillImageList();
        }
    }
}
