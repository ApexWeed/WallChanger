using System;
using System.Drawing;
using System.Windows.Forms;
using WallChanger.Layout;
using WallChanger.Translation;
using WallChanger.Translation.Controls;

namespace WallChanger
{
    public partial class SettingsForm : Form
    {
        readonly LanguageManager LM = GlobalVars.LanguageManager;
        new readonly Form Parent;
        ProcessingSettingsForm ProcessingSettingsFormChild;

        TimingForm TimingFormChild;

        new readonly LayoutEngine Layout;

        #region "Compression"
        TranslatableGroupBox grpCompression;
        TranslatableLabel lblCompression;
        TranslatableComboBox cmbCompressionLevel;
        TranslatableLabel lblCompressionWarning;
        #endregion

        #region "Defaults"
        TranslatableGroupBox grpDefaults;
        TranslatableLabelFormat lblDefaultOffset;
        TranslatableLabelFormat lblDefaultInterval;
        TranslatableButton btnDefaultTiming;
        TranslatableCheckBox chkDefaultRandomise;
        TranslatableCheckBox chkGlobalRandomise;
        TranslatableCheckBox chkDefaultFading;
        TranslatableCheckBox chkGlobalFading;
        TranslatableLabel lblDefaultWallpaperStyle;
        TranslatableCheckBox chkGlobalWallpaperStyle;
        TranslatableComboBox cmbDefaultWallpaperStyle;
        #endregion
        #region "Highlight"
        TranslatableGroupBox grpHighlight;
        TranslatableLabel lblHighlightMode;
        TranslatableComboBox cmbHighlightMode;
        TranslatableLabel lblHighlightColour;
        PictureBox picHighlightColour;
        TranslatableButton btnHighlightColour;
        #endregion
        #region "Pre Processing"
        TranslatableGroupBox grpPreprocessing;
        TranslatableCheckBox chkGlobalPreprocessing;
        TranslatableButton btnPreprocessingDefaults;
        #endregion
        #region "Miscellaneous"
        TranslatableGroupBox grpMiscellaneous;
        TranslatableLabel lblColourChanging;
        TranslatableCheckBox chkDefaultColourChanging;
        TranslatableCheckBox chkGlobalColourChanging;
        TranslatableCheckBox chkRainbowMode;
        #endregion

        /// <summary>
        /// Initialises a new settings form.
        /// </summary>
        /// <param name="Parent">The parent that owns this form.</param>
        public SettingsForm(Form Parent)
        {
            InitializeComponent();

            this.Parent = Parent;

            SettingsTitle.LanguageManager = LM;

            Layout = new LayoutEngine(this)
            {
                Padding = new Padding(5),
                UpdateContainerSize = true
            };

            #region "Compression"
            grpCompression = new TranslatableGroupBox
            {
                TranslationString = "SETTINGS.LABEL.COMPRESSION",
                LanguageManager = LM
            };
            lblCompression = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.COMPRESSION.LEVEL",
                LanguageManager = LM,
                AutoSize = true
            };
            cmbCompressionLevel = new TranslatableComboBox
            {
                LanguageManager = LM
            };
            lblCompressionWarning = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.COMPRESSION.WARNING",
                LanguageManager = LM,
                AutoSize = true
            };

            cmbCompressionLevel.Items.Clear();
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.None));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Fast));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Low));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Normal));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.High));
            cmbCompressionLevel.Items.Add(new CompressionLevelWrapper(SevenZip.CompressionLevel.Ultra));

            cmbCompressionLevel.SelectedItem = cmbCompressionLevel.Items.Find(x => (CompressionLevelWrapper)x == Properties.Settings.Default.CompressionLevel);

            cmbCompressionLevel.SelectedValueChanged += cmbCompressionLevel_SelectedValueChanged;
            #endregion

            #region "Defaults"
            grpDefaults = new TranslatableGroupBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT",
                LanguageManager = LM
            };
            lblDefaultOffset = new TranslatableLabelFormat
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.OFFSET",
                LanguageManager = LM,
                Parameters = new object[] { Properties.Settings.Default.DefaultOffset },
                AutoSize = true
            };
            lblDefaultInterval = new TranslatableLabelFormat
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.INTERVAL",
                LanguageManager = LM,
                Parameters = new object[] { Properties.Settings.Default.DefaultInterval },
                AutoSize = true
            };
            btnDefaultTiming = new TranslatableButton
            {
                TranslationString = "SETTINGS.BUTTON.DEFAULT_TIMING",
                LanguageManager = LM
            };
            chkDefaultRandomise = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.RANDOMISE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.DefaultRandomise,
                AutoSize = true
            };
            chkGlobalRandomise = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.GLOBAL_RANDOMISE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.GlobalRandomise,
                AutoSize = true
            };
            chkDefaultFading = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.FADING",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.DefaultFading,
                AutoSize = true
            };
            chkGlobalFading = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.GLOBAL_FADING",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.GlobalFading,
                AutoSize = true
            };
            lblDefaultWallpaperStyle = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.WALLPAPER_STYLE",
                LanguageManager = LM,
                AutoSize = true
            };
            chkGlobalWallpaperStyle = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.GLOBAL_WALLPAPER_STYLE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.GlobalWallpaperStyle,
                AutoSize = true
            };
            cmbDefaultWallpaperStyle = new TranslatableComboBox
            {
                LanguageManager = LM
            };

            btnDefaultTiming.Click += btnChangeDefaultTiming_Click;

            chkDefaultRandomise.CheckedChanged += chkDefaultRandomise_CheckedChanged;
            chkGlobalRandomise.CheckedChanged += chkGlobalRandomise_CheckedChanged;
            chkDefaultFading.CheckedChanged += chkDefaultFade_CheckedChanged;
            chkGlobalFading.CheckedChanged += chkGlobalFading_CheckedChanged;
            chkGlobalWallpaperStyle.CheckedChanged += chkGlobalPreProcessing_CheckedChanged;

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

            cmbDefaultWallpaperStyle.SelectedValueChanged += cmbDefaultWallpaperStyle_SelectedValueChanged;
            #endregion

            #region "Highlight"
            grpHighlight = new TranslatableGroupBox
            {
                TranslationString = "SETTINGS.LABEL.HIGHLIGHT",
                LanguageManager = LM
            };
            lblHighlightMode = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.HIGHLIGHT.MODE",
                LanguageManager = LM,
                AutoSize = true
            };
            cmbHighlightMode = new TranslatableComboBox
            {
                LanguageManager = LM
            };
            lblHighlightColour = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.HIGHLIGHT.COLOUR",
                LanguageManager = LM,
                AutoSize = true
            };
            picHighlightColour = new PictureBox
            {
                Height = 21,
                BackColor = Properties.Settings.Default.HighlightColour
            };
            btnHighlightColour = new TranslatableButton
            {
                TranslationString = "SETTINGS.BUTTON.HIGHLIGHT_COLOUR",
                LanguageManager = LM
            };

            btnHighlightColour.Click += btnHighlightColour_Click;

            cmbHighlightMode.Items.Clear();
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Bold));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Italic));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Foreground));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.Background));
            cmbHighlightMode.Items.Add(new HighlightModeWrapper(HighlightListBox.HighlightMode.None));

            cmbHighlightMode.SelectedItem = cmbHighlightMode.Items.Find(x => (HighlightModeWrapper)x == Properties.Settings.Default.HighlightMode);

            cmbHighlightMode.SelectedValueChanged += cmbHighlightMode_SelectedValueChanged;
            #endregion

            #region "Pre Processing"
            grpPreprocessing = new TranslatableGroupBox
            {
                TranslationString = "SETTINGS.LABEL.PREPROCESSING",
                LanguageManager = LM
            };
            chkGlobalPreprocessing = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.GLOBAL_PREPROCESSING",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.GlobalPreProcessing,
                AutoSize = true
            };
            btnPreprocessingDefaults = new TranslatableButton
            {
                TranslationString = "SETTINGS.BUTTON.PREPROCESSING_DEFAULTS",
                LanguageManager = LM
            };

            btnPreprocessingDefaults.Click += btnPreprocessingDefaults_Click;

            chkGlobalPreprocessing.Click += chkGlobalPreProcessing_CheckedChanged;
            #endregion

            #region "Miscellaneous"
            grpMiscellaneous = new TranslatableGroupBox
            {
                TranslationString = "SETTINGS.LABEL.MISCELLANEOUS",
                LanguageManager = LM
            };
            lblColourChanging = new TranslatableLabel
            {
                TranslationString = "SETTINGS.LABEL.COLOUR_CHANGE_DESC",
                LanguageManager = LM,
                AutoSize = true
            };
            chkDefaultColourChanging = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.DEFAULT.COLOUR_CHANGE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.DefaultColourSchemeEnabled,
                AutoSize = true
            };
            chkGlobalColourChanging = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.GLOBAL_COLOUR_CHANGE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.GlobalColourSchemeEnabled,
                AutoSize = true
            };
            chkRainbowMode = new TranslatableCheckBox
            {
                TranslationString = "SETTINGS.LABEL.RAINBOW_MODE",
                LanguageManager = LM,
                Checked = Properties.Settings.Default.RainbowModeEnabled,
                AutoSize = true
            };

            chkDefaultColourChanging.CheckedChanged += chkDefaultColourChanging_CheckedChanged;
            chkGlobalColourChanging.CheckedChanged += chkGlobalColourChanging_CheckedChanged;
            chkRainbowMode.CheckedChanged += chkRainbowMode_CheckedChanged;
            #endregion

            #region "Layout"
            using (Layout.BeginGroupBox(grpCompression))
            {
                Layout.AddControl(lblCompression);
                Layout.AddControl(cmbCompressionLevel);
                Layout.AddControl(lblCompressionWarning);
            }

            using (Layout.BeginGroupBox(grpDefaults))
            {
                using (Layout.BeginRow())
                {
                    Layout.AddControl(lblDefaultOffset);
                    Layout.ColumnWidth(25);
                    Layout.AddControl(btnDefaultTiming);
                }
                Layout.OffsetY(-7);
                Layout.AddControl(lblDefaultInterval);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkDefaultRandomise);
                    Layout.AddControl(chkGlobalRandomise);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkDefaultFading);
                    Layout.AddControl(chkGlobalFading);
                }
                using (Layout.BeginRow())
                {
                    Layout.AddControl(lblDefaultWallpaperStyle);
                    Layout.AddControl(chkGlobalWallpaperStyle);
                }
                Layout.AddControl(cmbDefaultWallpaperStyle);
            }

            using (Layout.BeginGroupBox(grpHighlight))
            {
                Layout.AddControl(lblHighlightMode);
                Layout.AddControl(cmbHighlightMode);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(lblHighlightColour);
                    Layout.AddControl(picHighlightColour);
                    Layout.ColumnWidth(25);
                    Layout.AddControl(btnHighlightColour);
                }
            }

            using (Layout.BeginGroupBox(grpPreprocessing))
            {
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkGlobalPreprocessing);
                    Layout.ColumnWidth(25);
                    Layout.AddControl(btnPreprocessingDefaults);
                }
            }

            using (Layout.BeginGroupBox(grpMiscellaneous))
            {
                Layout.AddControl(lblColourChanging);
                using (Layout.BeginRow())
                {
                    Layout.AddControl(chkDefaultColourChanging);
                    Layout.AddControl(chkGlobalColourChanging);
                }
                Layout.AddControl(chkRainbowMode);
            }

            Layout.ProcessLayout();
            #endregion
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
        /// Saves the time settings as the default.
        /// </summary>
        /// <param name="Offset">The default offset value in milliseconds.</param>
        /// <param name="Interval">The default interval value in milliseconds.</param>
        public void SetTimes(int Offset, int Interval)
        {
            Properties.Settings.Default.DefaultOffset = Timing.ToString(Offset);
            Properties.Settings.Default.DefaultInterval = Timing.ToString(Interval);
            lblDefaultOffset.Parameters = new object[] { Properties.Settings.Default.DefaultOffset };
            lblDefaultInterval.Parameters = new object[] { Properties.Settings.Default.DefaultInterval };
        }

        private static void ProcessingSettingsChanged(ProcessingSetting Setting, object Value)
        {
            switch (Setting)
            {
                case ProcessingSetting.PreProcessingEnabled:
                    {
                        Properties.Settings.Default.DefaultPreProcessingEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.BrightnessEnabled:
                    {
                        Properties.Settings.Default.DefaultBrightnessEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.BrightnessValue:
                    {
                        Properties.Settings.Default.DefaultBrightnessValue = (int)Value;
                        break;
                    }
                case ProcessingSetting.SaturationEnabled:
                    {
                        Properties.Settings.Default.DefaultSaturationEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.SaturationValue:
                    {
                        Properties.Settings.Default.DefaultSaturationValue = (int)Value;
                        break;
                    }
                case ProcessingSetting.ContrastEnabled:
                    {
                        Properties.Settings.Default.DefaultContrastEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.ContrastValue:
                    {
                        Properties.Settings.Default.DefaultContrastValue = (int)Value;
                        break;
                    }
                case ProcessingSetting.HueEnabled:
                    {
                        Properties.Settings.Default.DefaultHueEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.HueValue:
                    {
                        Properties.Settings.Default.DefaultHueValue = (int)Value;
                        break;
                    }
                case ProcessingSetting.GaussianBlurEnabled:
                    {
                        Properties.Settings.Default.DefaultGaussianBlurEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.GaussianBlurSize:
                    {
                        Properties.Settings.Default.DefaultGaussianBlurSize = (int)Value;
                        break;
                    }
                case ProcessingSetting.GaussianSharpenEnabled:
                    {
                        Properties.Settings.Default.DefaultGaussianSharpenEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.GaussianSharpenSize:
                    {
                        Properties.Settings.Default.DefaultGaussianSharpenSize = (int)Value;
                        break;
                    }
                case ProcessingSetting.PixelateEnabled:
                    {
                        Properties.Settings.Default.DefaultPixelateEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.PixelateSize:
                    {
                        Properties.Settings.Default.DefaultPixelateSize = (int)Value;
                        break;
                    }
                case ProcessingSetting.VignetteEnabled:
                    {
                        Properties.Settings.Default.DefaultVignetteEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.VignetteColour:
                    {
                        Properties.Settings.Default.DefaultVignetteColour = (Color)Value;
                        break;
                    }
                case ProcessingSetting.TintEnabled:
                    {
                        Properties.Settings.Default.DefaultTintEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.TintColour:
                    {
                        Properties.Settings.Default.DefaultTintColour = (Color)Value;
                        break;
                    }
                case ProcessingSetting.EdgeDetectionEnabled:
                    {
                        Properties.Settings.Default.DefaultEdgeDetectionEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.EdgeDetectionFilter:
                    {
                        Properties.Settings.Default.DefaultEdgeDetectionFilter = (EdgeDetectionFilterWrapper)Value;
                        break;
                    }
                case ProcessingSetting.ImageFilterEnabled:
                    {
                        Properties.Settings.Default.DefaultImageFilterEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.ImageFilterMatrix:
                    {
                        Properties.Settings.Default.DefaultImageFilterMatrix = (ImageFilterMatrixWrapper)Value;
                        break;
                    }
                case ProcessingSetting.ChannelRotationEnabled:
                    {
                        Properties.Settings.Default.DefaultChannelRotationEnabled = (bool)Value;
                        break;
                    }
                case ProcessingSetting.ChannelRotationValue:
                    {
                        Properties.Settings.Default.DefaultChannelRotationValue = (ChannelRotationWrapper)Value;
                        break;
                    }
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

        private void btnPreprocessingDefaults_Click(object sender, EventArgs e)
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
            Properties.Settings.Default.GlobalPreProcessing = chkGlobalPreprocessing.Checked;
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
    }
}
