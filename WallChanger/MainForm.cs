using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace WallChanger
{
    public partial class MainForm : Form
    {
        Dictionary<char, int> TimeMapping = new Dictionary<char, int>();
        List<string> FileList = new List<string>();
        List<string> ConfigList = new List<string>();
        int Interval;
        int Offset;
        BackgroundWorker TimerWorker = new BackgroundWorker();
        bool AutoStarted;
        string CurrentConfig;
        TimingForm TimingFormChild;
        int LastIndex = 0;
        
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
            Library.Load();
        }

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

        private void btnDeleteImage_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            chkStartup.Checked = (string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("WallChanger") == string.Format("\"{0}\" hide", Application.ExecutablePath);

            LoadSettings();

            TimerWorker.RunWorkerAsync();

            if (AutoStarted)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                noiTray.Visible = true;
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(GlobalVars.ApplicationPath + "\\config.cfg"))
            {
                StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\config.cfg");

                CurrentConfig = read.ReadLine();
                read.Close();

                LoadConfigs();
                LoadConfig();
            }
            else
            {
                FileStream file = File.Create(GlobalVars.ApplicationPath + "\\config.cfg");
                file.Close();

                CreateConfig("default");
            }
        }

        private void CreateConfig(string name)
        {
            FileStream file = File.Create(GlobalVars.ApplicationPath + "\\" + name + ".cfg");
            file.Close();

            Offset = ParseTime("0 h");
            Interval = ParseTime("1 m");
            CurrentConfig = name;
            FileList.Clear();

            SaveSettings();
            LoadConfig();
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            ConfigList.Clear();
            string[] files = Directory.GetFiles(GlobalVars.ApplicationPath);
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".cfg" && Path.GetFileNameWithoutExtension(file) != "config" && Path.GetFileNameWithoutExtension(file) != "library" && Path.GetFileNameWithoutExtension(file) != "sizecache")
                    ConfigList.Add(Path.GetFileNameWithoutExtension(file));
            }
            FillConfigList();
        }

        private void LoadConfig(string Config)
        {
            CurrentConfig = Config;
            LoadConfig();
        }

        private void LoadConfig()
        {
            grpImages.Text = string.Format("Images ({0})", CurrentConfig);
            StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\" + CurrentConfig + ".cfg");

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

        private void SaveSettings(bool OnlyConfig)
        {
            StreamWriter write = new StreamWriter(GlobalVars.ApplicationPath + "\\config.cfg");
            write.Write(CurrentConfig);
            write.Close();

            if (OnlyConfig)
                return;

            write = new StreamWriter(GlobalVars.ApplicationPath + "\\" + CurrentConfig + ".cfg");
            write.WriteLine(new DateTime().AddYears(10).AddSeconds(Offset / 1000).ToString(@"H \h m \m s \s"));
            write.WriteLine(new DateTime().AddYears(10).AddSeconds(Interval / 1000).ToString(@"H \h m \m s \s"));
            foreach (string image in FileList)
            {
                write.WriteLine(image);
            }
            write.Close();
        }

        private void SaveSettings()
        {
            SaveSettings(false);
        }

        private void FillImageList(bool PreserveScrolling = false)
        {
            if (lstImages.Items.Count == FileList.Count())
            {
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
                        lstImages.Items[i] = string.Format("{0} - {1}", showTime.AddSeconds((Interval * FileList.Count) / 1000).ToString("hh:mm:ss tt"), FileList[i]);
                    else
                        lstImages.Items[i] = string.Format("{0} - {1}", showTime.ToString("hh:mm:ss tt"), FileList[i]);
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
                        lstImages.Items.Add(string.Format("{0} - {1}", showTime.AddSeconds((Interval * FileList.Count) / 1000).ToString("hh:mm:ss tt"), FileList[i]));
                    else
                        lstImages.Items.Add(string.Format("{0} - {1}", showTime.ToString("hh:mm:ss tt"), FileList[i]));
                }
            }
        }

        private void FillConfigList()
        {
            lstConfigs.Items.Clear();
            foreach (string config in ConfigList)
            {
                lstConfigs.Items.Add(config);
            }

            lstConfigs.SelectedIndex = lstConfigs.FindString(CurrentConfig, 0);
        }

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

        private void SetWallpaper()
        {
            string outputTime = DateTime.Now.ToString(@"H \h m \m s \s");
            int parsedTime = ParseTime(outputTime);
            int index = (int)(parsedTime / Interval);

            SetWallpaper(index);
        }

        private void SetWallpaper(int Index)
        {
            if (FileList.Count > 0)
            {
                if (Index < 0)
                    Index = FileList.Count + Index;
                Wallpaper.Set(FileList[(Index) % FileList.Count], Wallpaper.Style.Fill);
            }
        }

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
                loadedConfig = CurrentConfig;
                outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                parsedTime = ParseTime(outputTime) - Offset;
                index = (int)(parsedTime / Interval);

                SetWallpaper(index);

                do
                {
                    outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    parsedTime = ParseTime(outputTime) - Offset;
                    sleepTime = (parsedTime % Interval == 0) ? Interval : (Interval - parsedTime % Interval);
                    delayTime = sleepTime > 1000 ? 1000 : sleepTime;
                    System.Diagnostics.Debug.Print(string.Format("outputTime: {0} parsedTime: {1} index: {2} interval: {3} delayTime: {4} sleepTime: {5} minutes: {6}", outputTime, parsedTime, index, Interval, delayTime, sleepTime, sleepTime / 1000 / 60));
                    TimerWorker.ReportProgress(sleepTime);
                    System.Threading.Thread.Sleep(delayTime);
                } while (delayTime == 1000 && loadedConfig == CurrentConfig);
            }
        }

        private void TimerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //SetWallpaper(e.ProgressPercentage);
            //noiTray.BalloonTipText = string.Format("Next wallpaper change at: {0}", new DateTime().AddSeconds((Interval * (e.ProgressPercentage + 2)) / 1000).AddSeconds(Offset).ToString("hh:mm:ss tt"));
            //noiTray.BalloonTipTitle = "Next Wallpaper Change";
            //noiTray.ShowBalloonTip(1000);
            DateTime nextChange = DateTime.Now.AddMilliseconds(e.ProgressPercentage);
            TimeSpan nextChangeTimeSpan = nextChange - DateTime.Now;
            lblNextChange.Text = string.Format("Next change: {0}", nextChangeTimeSpan.ToString());

            string outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
            int parsedTime = ParseTime(outputTime) - Offset;
            int index = (int)(parsedTime / Interval);
            if (index != LastIndex)
            {
                LastIndex = index;
                FillImageList();
            }
        }

        private void noiTray_Click(object sender, EventArgs e)
        {
            noiTray.Visible = false;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey StartupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chkStartup.Checked)
            {
                StartupKey.SetValue("WallChanger", string.Format("\"{0}\" hide", Application.ExecutablePath));
            }
            else
            {
                StartupKey.DeleteValue("WallChanger", false);
            }
        }

        private void btnTray_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        private void Minimize()
        {
            this.Hide();
            this.ShowInTaskbar = false;
            noiTray.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in paths)
            {
                LoadImages(path);
            }
            FillImageList();
        }

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

        public void SetTimes(int Offset, int Interval)
        {
            this.Offset = Offset * 1000;
            this.Interval = Interval * 1000;

            FillImageList();
        }

        private void btnTiming_Click(object sender, EventArgs e)
        {
            if (TimingFormChild == null)
            {
                TimingFormChild = new TimingForm(Offset / 1000, Interval / 1000, this);
                TimingFormChild.FormClosed += TimingFormClosed;
                TimingFormChild.Show();
            }
            else
            {
                TimingFormChild.BringToFront();
            }
        }

        private void TimingFormClosed(object sender, EventArgs e)
        {
            TimingFormChild = null;
        }

        private void lstConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadConfig(lstConfigs.SelectedItem.ToString());
            SaveSettings(true);
        }

        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            string configName = Prompt.ShowStringDialog("Enter config name", "Config Name", "default");
            CreateConfig(configName);
        }

        private void btnRemoveConfig_Click(object sender, EventArgs e)
        {
            if (Prompt.ShowStringDialog(string.Format("Are you sure you want to delete \"{0}\"? Write the config name to confirm.", lstConfigs.SelectedItem as string), "Confirm Delete") == lstConfigs.SelectedItem as string)
            {
                File.Delete(GlobalVars.ApplicationPath + "\\" + lstConfigs.SelectedItem as string + ".cfg");
                LoadConfigs();
                LoadConfig(ConfigList[0]);
                SaveSettings(true);
            }
        }

        private void MoveSelection(string Direction)
        {
            int[] indexArray = new int[lstImages.SelectedIndices.Count];
            lstImages.SelectedIndices.CopyTo(indexArray, 0);
            List<int> newSelection = new List<int>();
            if (Direction == "Up")
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
            else if (Direction == "Down")
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

        private void SetSelection(ListBox ListBoxControl, int[] Selection)
        {
            foreach (int Index in Selection)
            {
                ListBoxControl.SetSelected(Index, true);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelection("Up");
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelection("Down");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            FillImageList();
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            if (GlobalVars.LibraryForm == null)
            {
                GlobalVars.LibraryForm = new LibraryForm(this);
                GlobalVars.LibraryForm.Show();
            }
        }

        public void ChildClosed(Form Child)
        {
            if (Child is LibraryForm)
                GlobalVars.LibraryForm = null;
        }

        public void AddImages(List<string> Images)
        {
            FileList.AddRange(Images.ToArray());
            FillImageList();
        }

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.Save();
        }

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
                        Minimize();
                        return;
                    }
                    break;
            }

            base.WndProc(ref message);
        }

    }
}
