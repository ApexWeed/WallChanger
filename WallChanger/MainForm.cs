using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

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

        Dictionary<char, int> TimeMapping = new Dictionary<char, int>();
        List<string> FileList = new List<string>();
        List<string> ConfigList = new List<string>();
        int Interval;
        int Offset;
        BackgroundWorker TimerWorker = new BackgroundWorker();
        bool AutoStarted;
        TimingForm TimingFormChild;
        LanguageForm LanguageFormChild;
        SettingsForm SettingsFormChild;
        int LastIndex = 0;

        LanguageManager LM;
        
        /// <summary>
        /// Creates a new instance of the main form.
        /// </summary>
        /// <param name="Hide">Whether this instance was auto run.</param>
        public MainForm(bool Hide)
        {
            InitializeComponent();

            TimeMapping.Add('f', 1);
            TimeMapping.Add('F', 1);
            TimeMapping.Add('s', 1000);
            TimeMapping.Add('S', 1000);
            TimeMapping.Add('m', 60000);
            TimeMapping.Add('M', 60000);
            TimeMapping.Add('h', 3600000);
            TimeMapping.Add('H', 3600000);
            
            TimerWorker.DoWork += TimerWorker_DoWork;
            TimerWorker.ProgressChanged += TimerWorker_ProgressChanged;
            TimerWorker.WorkerReportsProgress = true;

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
            chkStartup.Checked = (string)Registry.CurrentUser.OpenSubKey(REG_AUTORUN, true).GetValue("WallChanger") == string.Format("\"{0}\" hide", Application.ExecutablePath);

            LoadSettings();
            LocaliseInterface();

            TimerWorker.RunWorkerAsync();

            if (AutoStarted)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                noiTray.Visible = true;
            }
        }

        /// <summary>
        /// Sets the static strings to the chosen language.
        /// </summary>
        public void LocaliseInterface()
        {
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
            chkStartup.Left = (pnlBottomRight.Width / 2) - (chkStartup.Width / 2);

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
                    StreamReader read = new StreamReader(Path.Combine(GlobalVars.ApplicationPath, @"config.cfg"));

                    Properties.Settings.Default.CurrentConfig = read.ReadLine();
                    read.Close();
                    File.Delete(Path.Combine(GlobalVars.ApplicationPath, @"config.cfg"));

                    LoadConfigs();
                    LoadConfig();
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
            FileStream file = File.Create(Path.Combine(GlobalVars.ApplicationPath, string.Format("{0}.cfg", name)));
            file.Close();

            Offset = ParseTime("0 h");
            Interval = ParseTime("1 m");
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
            string[] files = Directory.GetFiles(GlobalVars.ApplicationPath);
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
            StreamReader read = new StreamReader(Path.Combine(GlobalVars.ApplicationPath, string.Format("{0}.cfg", Properties.Settings.Default.CurrentConfig)));

            Offset = ParseTime(read.ReadLine());
            Interval = ParseTime(read.ReadLine());

            FileList.Clear();
            while (!read.EndOfStream)
            {
                FileList.Add(read.ReadLine());
            }

            read.Close();

            FillImageList();
        }

        /// <summary>
        /// Saves the current config file.
        /// </summary>
        private void SaveSettings()
        {
            StreamWriter write = new StreamWriter(Path.Combine(GlobalVars.ApplicationPath, string.Format("{0}.cfg", Properties.Settings.Default.CurrentConfig)));
            write.WriteLine(new DateTime().AddYears(10).AddSeconds(Offset / 1000).ToString(@"H \h m \m s \s"));
            write.WriteLine(new DateTime().AddYears(10).AddSeconds(Interval / 1000).ToString(@"H \h m \m s \s"));
            foreach (string image in FileList)
            {
                write.WriteLine(image);
            }
            write.Close();
        }

        /// <summary>
        /// Refills the list with the current files.
        /// </summary>
        /// <param name="PreserveScrolling">Not yet implemented.</param>
        private void FillImageList(bool PreserveScrolling = false)
        {
            if (lstImages.Items.Count == FileList.Count())
            {
                string outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                int parsedTime = ParseTime(outputTime) - Offset;
                int index = parsedTime / Interval;
                int remainder = FileList.Count == 0 ? 0 : index % FileList.Count;
                int iteration = (index - remainder) / (FileList.Count == 0 ? 1 : FileList.Count);

                DateTime showTime = new DateTime().AddYears(10).AddSeconds((Offset - Interval) / 1000).AddSeconds((Interval * iteration * FileList.Count) / 1000);
                for (int i = 0; i < FileList.Count; i++)
                {
                    showTime = showTime.AddSeconds(Interval / 1000);
                    if (i < remainder)
                        lstImages.Items[i] = string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime.AddSeconds((Interval * FileList.Count) / 1000), FileList[i]);
                    else
                        lstImages.Items[i] = string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]);
                }
            }
            else
            {
                lstImages.Items.Clear();

                string outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                int parsedTime = ParseTime(outputTime) - Offset;
                int index = (int)(parsedTime / Interval);
                int remainder = FileList.Count == 0 ? 0 : index % FileList.Count;
                int iteration = (index - remainder) / (FileList.Count == 0 ? 1 : FileList.Count);

                DateTime showTime = new DateTime().AddYears(10).AddSeconds((Offset - Interval) / 1000).AddSeconds((Interval * iteration * FileList.Count) / 1000);
                for (int i = 0; i < FileList.Count; i++)
                {
                    showTime = showTime.AddSeconds(Interval / 1000);
                    if (i < remainder)
                        lstImages.Items.Add(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime.AddSeconds((Interval * FileList.Count) / 1000), FileList[i]));
                    else
                        lstImages.Items.Add(string.Format(LM.GetStringDefault("MAIN_LABEL_IMAGE", "{0:HH:mm:ss} - {1}"), showTime, FileList[i]));
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
        /// Parses the config file times to seconds.
        /// </summary>
        /// <param name="Time">Time in "xh ym zs" format.</param>
        /// <returns>Number of seconds.</returns>
        private int ParseTime(string Time)
        {
            string[] parts = Time.Split(' ');
            int interval = 0;
            if (parts.Length % 2 == 0)
            {
                for (int i = 0; i < parts.Length / 2; i++)
                {
                    interval += int.Parse(parts[i * 2]) * TimeMapping[parts[i * 2 + 1][0]];
                }
            }
            else
            {
                interval = 10;
            }
            
            return interval;
        }

        /// <summary>
        /// Sets the wallpaper using the current index.
        /// </summary>
        private void SetWallpaper()
        {
            string outputTime = DateTime.Now.ToString(@"H \h m \m s \s");
            int parsedTime = ParseTime(outputTime);
            int index = parsedTime / Interval;

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
                    Wallpaper.Set(FileList[(Index) % FileList.Count], Properties.Settings.Default.WallpaperStyle);
                }
                else
                {
                    FileList.RemoveAt((Index) % FileList.Count);
                    FillImageList();
                    MessageBox.Show(string.Format("The following image cannot be found and has been removed from the current config.\n{0}", FileList[(Index) % FileList.Count]));
                    SetWallpaper(Index);
                }
            }
        }

        /// <summary>
        /// Worker that changes the background image.
        /// </summary>
        /// <param name="sender">Object that sent the event.</param>
        /// <param name="e">Parameters.</param>
        private void TimerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string loadedConfig;
            string outputTime;
            int parsedTime;
            int index;
            int sleepTime;
            int delayTime;
            while (true)
            {
                loadedConfig = Properties.Settings.Default.CurrentConfig;
                outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                parsedTime = ParseTime(outputTime) - Offset;
                index = parsedTime / Interval;

                SetWallpaper(index);

                do
                {
                    outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    parsedTime = ParseTime(outputTime) - Offset;
                    sleepTime = (parsedTime % Interval == 0) ? Interval : (Interval - parsedTime % Interval);
                    delayTime = sleepTime > 1000 ? 1000 : sleepTime;
                    
                    TimerWorker.ReportProgress(sleepTime);
                    System.Threading.Thread.Sleep(delayTime);
                } while (delayTime == 1000 && loadedConfig == Properties.Settings.Default.CurrentConfig);
            }
        }

        /// <summary>
        /// Updates the time until next change label.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void TimerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime nextChange = DateTime.Now.AddMilliseconds(e.ProgressPercentage);
            TimeSpan nextChangeTimeSpan = nextChange - DateTime.Now;
            lblNextChange.Text = string.Format(LM.GetStringDefault("MAIN_LABEL_NEXT_CHANGE", "NEXT_CHANGE: {0:hh\\:mm\\:ss}"), nextChangeTimeSpan);

            string outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
            int parsedTime = ParseTime(outputTime) - Offset;
            int index = parsedTime / Interval;
            if (index != LastIndex)
            {
                LastIndex = index;
                FillImageList();
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
            RegistryKey StartupKey = Registry.CurrentUser.OpenSubKey(REG_AUTORUN, true);
            if (chkStartup.Checked)
            {
                StartupKey.SetValue("WallChanger", string.Format("\"{0}\" hide", Application.ExecutablePath));
            }
            else
            {
                StartupKey.DeleteValue("WallChanger", false);
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
            int[] indexArray = new int[lstImages.SelectedIndices.Count];
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

        /// <summary>
        /// Updates the cursor when the user drags something onto the window.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
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
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
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
            this.Offset = Offset * 1000;
            this.Interval = Interval * 1000;

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
                TimingFormChild = new TimingForm(Offset / 1000, Interval / 1000, this);
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
            LoadConfig(lstConfigs.SelectedItem.ToString());
        }

        /// <summary>
        /// Prompts the user for a new config name.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            string configName = Prompt.ShowStringDialog(LM.GetString("MAIN_MESSAGE_NEW_CONFIG"), LM.GetString("MAIN_MESSAGE_NEW_CONFIG_TITLE"), LM.GetString("MAIN_MESSAGE_NEW_CONFIG_DEFAULT"));
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
            int[] indexArray = new int[lstImages.SelectedIndices.Count];
            lstImages.SelectedIndices.CopyTo(indexArray, 0);
            List<int> newSelection = new List<int>();
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

                    string value = FileList[indexArray[i] - 1] as string;
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

                    string value = FileList[indexArray[i] + 1] as string;
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
        private void SetSelection(ListBox ListBoxControl, int[] Selection)
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
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;
            const int SC_MINIMIZE = 0xF020;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
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
            }

            base.WndProc(ref message);
        }
    }
}
