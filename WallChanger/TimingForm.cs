using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class TimingForm : Form
    {
        MainForm ParentForm;

        public TimingForm(int Offset, int Interval, MainForm Parent)
        {
            InitializeComponent();

            OffsetSeconds.Value = Offset % 60;
            OffsetMinutes.Value = (Offset / 60) % 60;
            OffsetHours.Value = (Offset / 3600);

            IntervalSeconds.Value = Interval % 60;
            IntervalMinutes.Value = (Interval / 60) % 60;
            IntervalHours.Value = (Interval / 3600);

            ParentForm = Parent;
        }

        private void Save()
        {
            int offset = 0;
            offset += ((int)OffsetSeconds.Value);
            offset += ((int)OffsetMinutes.Value * 60);
            offset += ((int)OffsetHours.Value * 3600);

            int interval = 0;
            interval += ((int)IntervalSeconds.Value);
            interval += ((int)IntervalMinutes.Value * 60);
            interval += ((int)IntervalHours.Value * 3600);

            if (offset < -interval)
                MessageBox.Show(string.Format("Offset ({0} - Interval ({1}) cannot be less than zero.", offset, interval));
            else
                ParentForm.SetTimes(offset, interval);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void TimingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown Control = sender as NumericUpDown;

            switch (Control.Tag as string)
            {
                case "OffsetSeconds":
                    {
                        if ((int)Control.Value == -60)
                        {
                            OffsetMinutes.Value--;
                            Control.Value = 0;
                        }
                        else if ((int)Control.Value == 60)
                        {
                            OffsetMinutes.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "OffsetMinutes":
                    {
                        if ((int)Control.Value == -60)
                        {
                            OffsetHours.Value--;
                            Control.Value = 0;
                        }
                        else if ((int)Control.Value == 60)
                        {
                            OffsetHours.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "IntervalSeconds":
                    {
                        if ((int)Control.Value == -1)
                        {
                            if (IntervalMinutes.Value > 0)
                            {
                                IntervalMinutes.Value--;
                                Control.Value = 59;
                            }
                        }
                        else if ((int)Control.Value == 60)
                        {
                            IntervalMinutes.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
                case "IntervalMinutes":
                    {
                        if ((int)Control.Value == -1)
                        {
                            if (IntervalHours.Value > 0)
                            {
                                IntervalHours.Value--;
                                Control.Value = 59;
                            }
                        }
                        else if ((int)Control.Value == 60)
                        {
                            IntervalHours.Value++;
                            Control.Value = 0;
                        }
                        break;
                    }
            }
        }
    }
}
