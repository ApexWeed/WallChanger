using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        public static ImageFormat GetImageFormat(Stream stream)
        {
            // see http://www.mikekunz.com/image_file_header.html
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            var buffer = new byte[4];
            stream.Read(buffer, 0, buffer.Length);

            if (bmp.SequenceEqual(buffer.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(buffer.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(buffer.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(buffer.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(buffer.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(buffer.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(buffer.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }


        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (ofdAdd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofdAdd.FileNames)
                {
                    using (Stream read = File.Open(file, FileMode.Open))
                    {
                        if (GetImageFormat(read) == ImageFormat.unknown)
                            continue;
                        FileList.Add(file);
                    }
                }
                FillImageList();
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            int[] indexArray = new int[lstFiles.SelectedIndices.Count];
            lstFiles.SelectedIndices.CopyTo(indexArray, 0);
            Array.Sort(indexArray, (a, b) => b.CompareTo(a));
            foreach (int index in indexArray)
            {
                FileList.RemoveAt(index);
            }

            FillImageList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkStartup.Checked = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("WallChanger") == null ? false : true;

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
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\config.cfg"))
            {
                StreamReader read = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + "\\config.cfg");

                CurrentConfig = read.ReadLine();
                read.Close();

                LoadConfigs();
                LoadConfig();
            }
            else
            {
                FileStream file = File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "\\config.cfg");
                file.Close();

                CreateConfig("default");
            }
        }

        private void CreateConfig(string name)
        {
            FileStream file = File.Create(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + name + ".cfg");
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
            string[] files = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath));
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".cfg" && Path.GetFileNameWithoutExtension(file) != "config")
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
            StreamReader read = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + CurrentConfig + ".cfg");

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
            StreamWriter write = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\config.cfg");
            write.Write(CurrentConfig);
            write.Close();

            if (OnlyConfig)
                return;

            write = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + CurrentConfig + ".cfg");
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

        private void FillImageList()
        {
            lstFiles.Items.Clear();

            DateTime showTime = new DateTime().AddYears(10).AddSeconds((Offset - Interval) / 1000);
            for (int i = 0; i < FileList.Count; i++)
            {
                showTime = showTime.AddSeconds(Interval / 1000);
                lstFiles.Items.Add(string.Format("{0} - {1}", showTime.ToString("hh:mm:ss tt"), FileList[i]));
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

            SetWallpaper(index - 1);
        }

        private void SetWallpaper(int Index)
        {
            if (FileList.Count > 0)
            {
                Wallpaper.Set(new Uri(FileList[(Index) % FileList.Count]), Wallpaper.Style.Fill);
            }
        }

        private void TimerWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
                index = (int)(parsedTime / Interval) - 1;
                //TimerWorker.ReportProgress(index);

                SetWallpaper(index);

                do
                {
                    outputTime = DateTime.Now.ToString(@"H \h m \m s \s fff \f");
                    parsedTime = ParseTime(outputTime) - Offset;
                    sleepTime = (parsedTime % Interval == 0) ? Interval : (Interval - parsedTime % Interval);
                    delayTime = sleepTime > 1000 ? 1000 : sleepTime;
                    System.Diagnostics.Debug.Print(string.Format("outputTime: {0} parsedTime: {1} index: {2} interval: {3} delayTime: {4} sleepTime: {5} minutes: {6}", outputTime, parsedTime, index, Interval, delayTime, sleepTime, sleepTime / 1000 / 60));
                    System.Threading.Thread.Sleep(delayTime);
                } while (sleepTime == 1000 && loadedConfig == CurrentConfig);
            }
        }

        private void TimerWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //SetWallpaper(e.ProgressPercentage);
            noiTray.BalloonTipText = string.Format("Next wallpaper change at: {0}", new DateTime().AddSeconds((Interval * (e.ProgressPercentage + 2)) / 1000).AddSeconds(Offset).ToString("hh:mm:ss tt"));
            noiTray.BalloonTipTitle = "Next Wallpaper Change";
            noiTray.ShowBalloonTip(1000);
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                using (Stream read = File.Open(file, FileMode.Open))
                {
                    if (GetImageFormat(read) == ImageFormat.unknown)
                        continue;
                    FileList.Add(file);
                }
            }
            FillImageList();
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
                File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + lstConfigs.SelectedItem as string + ".cfg");
                LoadConfigs();
                LoadConfig(ConfigList[0]);
                SaveSettings(true);
            }
        }

        private void MoveSelection(string Direction)
        {
            int[] indexArray = new int[lstFiles.SelectedIndices.Count];
            lstFiles.SelectedIndices.CopyTo(indexArray, 0);
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
            SetSelection(lstFiles, newSelection.ToArray());
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
    }
}
