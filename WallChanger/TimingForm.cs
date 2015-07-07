﻿using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class TimingForm : Form
    {
        new MainForm ParentForm;
        LanguageManager LM = GlobalVars.LanguageManager;

        /// <summary>
        /// Creates a new TimingForm with the specified offset and interval.
        /// </summary>
        /// <param name="Offset">Offset to initialise the form to.</param>
        /// <param name="Interval">Interval to initialise the form to.</param>
        /// <param name="Parent">The parent of this form.</param>
        public TimingForm(int Offset, int Interval, MainForm Parent)
        {
            InitializeComponent();

            cmbOffsetSeconds.Value = Offset % 60;
            cmbOffsetMinutes.Value = (Offset / 60) % 60;
            cmbOffsetHours.Value = (Offset / 3600);

            cmbIntervalSeconds.Value = Interval % 60;
            cmbIntervalMinutes.Value = (Interval / 60) % 60;
            cmbIntervalHours.Value = (Interval / 3600);

            ParentForm = Parent;

            LocaliseInterface();
        }

        /// <summary>
        /// Sets the static strings to the chosen language and cascades to the main window.
        /// </summary>
        public void LocaliseInterface()
        {
            // Buttons.
            btnSave.Text = LM.GetString("TIMING_BUTTON_SAVE");
            // Tooltips.
            // Labels.
            lblOffsetSeconds.Text = LM.GetString("TIMING_LABEL_SECONDS");
            lblOffsetSeconds.Left = cmbOffsetSeconds.Left + ((cmbOffsetSeconds.Width / 2) - (TextRenderer.MeasureText(lblOffsetSeconds.Text, lblOffsetSeconds.Font).Width / 2));
            lblOffsetMinutes.Text = LM.GetString("TIMING_LABEL_MINUTES");
            lblOffsetMinutes.Left = cmbOffsetMinutes.Left + ((cmbOffsetMinutes.Width / 2) - (TextRenderer.MeasureText(lblOffsetMinutes.Text, lblOffsetMinutes.Font).Width / 2));
            lblOffsetHours.Text = LM.GetString("TIMING_LABEL_HOURS");
            lblOffsetHours.Left = cmbOffsetHours.Left + ((cmbOffsetHours.Width / 2) - (TextRenderer.MeasureText(lblOffsetHours.Text, lblOffsetHours.Font).Width / 2));
            lblIntervalSeconds.Text = LM.GetString("TIMING_LABEL_SECONDS");
            lblIntervalSeconds.Left = cmbIntervalSeconds.Left + ((cmbIntervalSeconds.Width / 2) - (TextRenderer.MeasureText(lblIntervalSeconds.Text, lblIntervalSeconds.Font).Width / 2));
            lblIntervalMinutes.Text = LM.GetString("TIMING_LABEL_MINUTES");
            lblIntervalMinutes.Left = cmbIntervalMinutes.Left + ((cmbIntervalMinutes.Width / 2) - (TextRenderer.MeasureText(lblIntervalMinutes.Text, lblIntervalMinutes.Font).Width / 2));
            lblIntervalHours.Text = LM.GetString("TIMING_LABEL_HOURS");
            lblIntervalHours.Left = cmbIntervalHours.Left + ((cmbIntervalHours.Width / 2) - (TextRenderer.MeasureText(lblIntervalHours.Text, lblIntervalHours.Font).Width / 2));
            grpOffset.Text = LM.GetString("TIMING_LABEL_OFFSET");
            grpInterval.Text = LM.GetString("TIMING_LABEL_INTERVAL");

            // Cascade.
        }

        /// <summary>
        /// Sends the interval and offset values to the main form.
        /// </summary>
        private void Save()
        {
            int offset = 0;
            offset += ((int)cmbOffsetSeconds.Value);
            offset += ((int)cmbOffsetMinutes.Value * 60);
            offset += ((int)cmbOffsetHours.Value * 3600);

            int interval = 0;
            interval += ((int)cmbIntervalSeconds.Value);
            interval += ((int)cmbIntervalMinutes.Value * 60);
            interval += ((int)cmbIntervalHours.Value * 3600);

            if (offset < -interval)
                MessageBox.Show(string.Format(LM.GetStringDefault("TIMING_MESSAGE_OFFSET_ERROR", "TIMING_MESSAGE_OFFSET_ERROR {0} - {1}"), offset, interval));
            else
                ParentForm.SetTimes(offset, interval);
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
        /// Saves the offset and interval and notifies the parent of closingness. Closure. Closingosity.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void TimingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            ParentForm.ChildClosed(this);
        }

        /// <summary>
        /// Updates the offset or interval values, looping numeric selectors where appropriate.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Arguments.</param>
        private void ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown Control = sender as NumericUpDown;

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
