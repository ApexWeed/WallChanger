using System;
using System.Windows.Forms;
using WallChanger.Translation;

namespace WallChanger
{
    public partial class TimingForm : Form
    {
        readonly LanguageManager LM = GlobalVars.LanguageManager;
        new readonly Form Parent;
        readonly string Source;

        /// <summary>
        /// Creates a new TimingForm with the specified offset and interval.
        /// </summary>
        /// <param name="Source">The string to display in the title.</param>
        /// <param name="Offset">Offset to initialise the form to.</param>
        /// <param name="Interval">Interval to initialise the form to.</param>
        /// <param name="Parent">The parent of this form.</param>
        public TimingForm(string Source, int Offset, int Interval, Form Parent)
        {
            InitializeComponent();

            Offset /= 1000;
            Interval /= 1000;

            cmbOffsetSeconds.Value = Offset % 60;
            cmbOffsetMinutes.Value = (Offset / 60) % 60;
            cmbOffsetHours.Value = (Offset / 3600);

            cmbIntervalSeconds.Value = Interval % 60;
            cmbIntervalMinutes.Value = (Interval / 60) % 60;
            cmbIntervalHours.Value = (Interval / 3600);

            this.Parent = Parent;
            this.Source = Source;

            TimingTitle.Parameters = new object[] { Source };
            TimingTitle.LanguageManager = LM;

            grpOffset.LanguageManager = LM;
            grpInterval.LanguageManager = LM;

            lblIntervalSeconds.StringChanged += LabelLanguageChanged;
            lblIntervalMinutes.StringChanged += LabelLanguageChanged;
            lblIntervalHours.StringChanged += LabelLanguageChanged;
            lblOffsetSeconds.StringChanged += LabelLanguageChanged;
            lblOffsetMinutes.StringChanged += LabelLanguageChanged;
            lblOffsetHours.StringChanged += LabelLanguageChanged;

            lblIntervalSeconds.LanguageManager = LM;
            lblIntervalMinutes.LanguageManager = LM;
            lblIntervalHours.LanguageManager = LM;
            lblOffsetSeconds.LanguageManager = LM;
            lblOffsetMinutes.LanguageManager = LM;
            lblOffsetHours.LanguageManager = LM;
            btnSave.LanguageManager = LM;
        }

        private void LabelLanguageChanged(object sender, EventArgs e)
        {
            if (sender is Translation.Controls.TranslatableLabel)
            {
                var label = sender as Translation.Controls.TranslatableLabel;
                var comboBox = Controls.Find("cmb" + label.Name.Substring(3), true);
                if (comboBox.Length == 1)
                {
                    label.Left = comboBox[0].Left + ((comboBox[0].Width / 2) - (TextRenderer.MeasureText(label.Text, label.Font).Width / 2));
                }
            }
        }

        /// <summary>
        /// Saves the interval and offset values.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// Sends the interval and offset values to the main form.
        /// </summary>
        private void Save()
        {
            var offset = 0;
            offset += ((int)cmbOffsetSeconds.Value);
            offset += ((int)cmbOffsetMinutes.Value * 60);
            offset += ((int)cmbOffsetHours.Value * 3600);
            offset *= 1000;

            var interval = 0;
            interval += ((int)cmbIntervalSeconds.Value);
            interval += ((int)cmbIntervalMinutes.Value * 60);
            interval += ((int)cmbIntervalHours.Value * 3600);
            interval *= 1000;

            if (offset < -interval)
            {
                MessageBox.Show(string.Format(LM.GetStringDefault("TIMING.MESSAGE.OFFSET_ERROR", "TIMING.MESSAGE.OFFSET_ERROR {0} - {1}"), offset, interval));
            }
            else
            {
                if (Parent is MainForm)
                    (Parent as MainForm).SetTimes(offset, interval);
                else if (Parent is SettingsForm)
                    (Parent as SettingsForm).SetTimes(offset, interval);
            }
        }

        /// <summary>
        /// Saves the offset and interval and notifies the parent of closingness. Closure. Closingosity.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void TimingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            if (Parent is MainForm)
                (Parent as MainForm).ChildClosed(this);
            else if (Parent is SettingsForm)
                (Parent as SettingsForm).ChildClosed(this);
        }

        /// <summary>
        /// Updates the offset or interval values, looping numeric selectors where appropriate.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void ValueChanged(object sender, EventArgs e)
        {
            var Control = sender as NumericUpDown;

            switch (Control.Tag as string)
            {
                case "OffsetSeconds":
                    {
                        if ((int)Control.Value == -60)
                        {
                            cmbOffsetMinutes.Value--;
                            Control.Value = 0;
                        }
                        else if ((int)Control.Value == 60)
                        {
                            cmbOffsetMinutes.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "OffsetMinutes":
                    {
                        if ((int)Control.Value == -60)
                        {
                            cmbOffsetHours.Value--;
                            Control.Value = 0;
                        }
                        else if ((int)Control.Value == 60)
                        {
                            cmbOffsetHours.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "IntervalSeconds":
                    {
                        if ((int)Control.Value == -1)
                        {
                            if (cmbIntervalMinutes.Value > 0)
                            {
                                cmbIntervalMinutes.Value--;
                                Control.Value = 59;
                            }
                        }
                        else if ((int)Control.Value == 60)
                        {
                            cmbIntervalMinutes.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "IntervalMinutes":
                    {
                        if ((int)Control.Value == -1)
                        {
                            if (cmbIntervalHours.Value > 0)
                            {
                                cmbIntervalHours.Value--;
                                Control.Value = 59;
                            }
                        }
                        else if ((int)Control.Value == 60)
                        {
                            cmbIntervalHours.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
            }
        }
    }
}
