namespace WallChanger
{
    partial class TimingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpOffset = new WallChanger.Translation.Controls.TranslatableGroupBoxFormat();
            this.lblOffsetHours = new WallChanger.Translation.Controls.TranslatableLabel();
            this.cmbOffsetHours = new System.Windows.Forms.NumericUpDown();
            this.lblOffsetMinutes = new WallChanger.Translation.Controls.TranslatableLabel();
            this.lblOffsetSeconds = new WallChanger.Translation.Controls.TranslatableLabel();
            this.cmbOffsetMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmbOffsetSeconds = new System.Windows.Forms.NumericUpDown();
            this.grpInterval = new WallChanger.Translation.Controls.TranslatableGroupBoxFormat();
            this.lblIntervalHours = new WallChanger.Translation.Controls.TranslatableLabel();
            this.cmbIntervalHours = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalMinutes = new WallChanger.Translation.Controls.TranslatableLabel();
            this.lblIntervalSeconds = new WallChanger.Translation.Controls.TranslatableLabel();
            this.cmbIntervalMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmbIntervalSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new WallChanger.Translation.Controls.TranslatableButton();
            this.TimingTitle = new WallChanger.Translation.Controls.TranslatableTitleFormat();
            this.grpOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetSeconds)).BeginInit();
            this.grpInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOffset
            // 
            this.grpOffset.Controls.Add(this.lblOffsetHours);
            this.grpOffset.Controls.Add(this.cmbOffsetHours);
            this.grpOffset.Controls.Add(this.lblOffsetMinutes);
            this.grpOffset.Controls.Add(this.lblOffsetSeconds);
            this.grpOffset.Controls.Add(this.cmbOffsetMinutes);
            this.grpOffset.Controls.Add(this.cmbOffsetSeconds);
            this.grpOffset.DefaultString = null;
            this.grpOffset.Location = new System.Drawing.Point(12, 11);
            this.grpOffset.Name = "grpOffset";
            this.grpOffset.Parameters = new object[0];
            this.grpOffset.Size = new System.Drawing.Size(260, 92);
            this.grpOffset.TabIndex = 0;
            this.grpOffset.TabStop = false;
            this.grpOffset.Text = "TIMING.LABEL.OFFSET";
            this.grpOffset.TranslationString = "TIMING.LABEL.OFFSET";
            // 
            // lblOffsetHours
            // 
            this.lblOffsetHours.AutoSize = true;
            this.lblOffsetHours.DefaultString = null;
            this.lblOffsetHours.Location = new System.Drawing.Point(113, 54);
            this.lblOffsetHours.Name = "lblOffsetHours";
            this.lblOffsetHours.Size = new System.Drawing.Size(121, 12);
            this.lblOffsetHours.TabIndex = 6;
            this.lblOffsetHours.Text = "TIMING.LABEL.HOURS";
            this.lblOffsetHours.TranslationString = "TIMING.LABEL.HOURS";
            // 
            // cmbOffsetHours
            // 
            this.cmbOffsetHours.Location = new System.Drawing.Point(70, 68);
            this.cmbOffsetHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.cmbOffsetHours.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.cmbOffsetHours.Name = "cmbOffsetHours";
            this.cmbOffsetHours.Size = new System.Drawing.Size(120, 19);
            this.cmbOffsetHours.TabIndex = 4;
            this.cmbOffsetHours.Tag = "OffsetHours";
            // 
            // lblOffsetMinutes
            // 
            this.lblOffsetMinutes.AutoSize = true;
            this.lblOffsetMinutes.DefaultString = null;
            this.lblOffsetMinutes.Location = new System.Drawing.Point(172, 15);
            this.lblOffsetMinutes.Name = "lblOffsetMinutes";
            this.lblOffsetMinutes.Size = new System.Drawing.Size(131, 12);
            this.lblOffsetMinutes.TabIndex = 3;
            this.lblOffsetMinutes.Text = "TIMING.LABEL.MINUTES";
            this.lblOffsetMinutes.TranslationString = "TIMING.LABEL.MINUTES";
            // 
            // lblOffsetSeconds
            // 
            this.lblOffsetSeconds.AutoSize = true;
            this.lblOffsetSeconds.DefaultString = null;
            this.lblOffsetSeconds.Location = new System.Drawing.Point(44, 15);
            this.lblOffsetSeconds.Name = "lblOffsetSeconds";
            this.lblOffsetSeconds.Size = new System.Drawing.Size(135, 12);
            this.lblOffsetSeconds.TabIndex = 2;
            this.lblOffsetSeconds.Text = "TIMING.LABEL.SECONDS";
            this.lblOffsetSeconds.TranslationString = "TIMING.LABEL.SECONDS";
            // 
            // cmbOffsetMinutes
            // 
            this.cmbOffsetMinutes.Location = new System.Drawing.Point(134, 30);
            this.cmbOffsetMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.cmbOffsetMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cmbOffsetMinutes.Name = "cmbOffsetMinutes";
            this.cmbOffsetMinutes.Size = new System.Drawing.Size(120, 19);
            this.cmbOffsetMinutes.TabIndex = 1;
            this.cmbOffsetMinutes.Tag = "OffsetMinutes";
            this.cmbOffsetMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cmbOffsetSeconds
            // 
            this.cmbOffsetSeconds.Location = new System.Drawing.Point(8, 30);
            this.cmbOffsetSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.cmbOffsetSeconds.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.cmbOffsetSeconds.Name = "cmbOffsetSeconds";
            this.cmbOffsetSeconds.Size = new System.Drawing.Size(120, 19);
            this.cmbOffsetSeconds.TabIndex = 0;
            this.cmbOffsetSeconds.Tag = "OffsetSeconds";
            this.cmbOffsetSeconds.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // grpInterval
            // 
            this.grpInterval.Controls.Add(this.lblIntervalHours);
            this.grpInterval.Controls.Add(this.cmbIntervalHours);
            this.grpInterval.Controls.Add(this.lblIntervalMinutes);
            this.grpInterval.Controls.Add(this.lblIntervalSeconds);
            this.grpInterval.Controls.Add(this.cmbIntervalMinutes);
            this.grpInterval.Controls.Add(this.cmbIntervalSeconds);
            this.grpInterval.DefaultString = null;
            this.grpInterval.Location = new System.Drawing.Point(12, 109);
            this.grpInterval.Name = "grpInterval";
            this.grpInterval.Parameters = new object[0];
            this.grpInterval.Size = new System.Drawing.Size(260, 92);
            this.grpInterval.TabIndex = 7;
            this.grpInterval.TabStop = false;
            this.grpInterval.Text = "TIMING.LABEL.INTERVAL";
            this.grpInterval.TranslationString = "TIMING.LABEL.INTERVAL";
            // 
            // lblIntervalHours
            // 
            this.lblIntervalHours.AutoSize = true;
            this.lblIntervalHours.DefaultString = null;
            this.lblIntervalHours.Location = new System.Drawing.Point(113, 54);
            this.lblIntervalHours.Name = "lblIntervalHours";
            this.lblIntervalHours.Size = new System.Drawing.Size(135, 12);
            this.lblIntervalHours.TabIndex = 6;
            this.lblIntervalHours.Text = "TIMING.LABEL.SECONDS";
            this.lblIntervalHours.TranslationString = "TIMING.LABEL.SECONDS";
            // 
            // cmbIntervalHours
            // 
            this.cmbIntervalHours.Location = new System.Drawing.Point(70, 68);
            this.cmbIntervalHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.cmbIntervalHours.Name = "cmbIntervalHours";
            this.cmbIntervalHours.Size = new System.Drawing.Size(120, 19);
            this.cmbIntervalHours.TabIndex = 4;
            this.cmbIntervalHours.Tag = "IntervalHours";
            // 
            // lblIntervalMinutes
            // 
            this.lblIntervalMinutes.AutoSize = true;
            this.lblIntervalMinutes.DefaultString = null;
            this.lblIntervalMinutes.Location = new System.Drawing.Point(172, 15);
            this.lblIntervalMinutes.Name = "lblIntervalMinutes";
            this.lblIntervalMinutes.Size = new System.Drawing.Size(131, 12);
            this.lblIntervalMinutes.TabIndex = 3;
            this.lblIntervalMinutes.Text = "TIMING.LABEL.MINUTES";
            this.lblIntervalMinutes.TranslationString = "TIMING.LABEL.MINUTES";
            // 
            // lblIntervalSeconds
            // 
            this.lblIntervalSeconds.AutoSize = true;
            this.lblIntervalSeconds.DefaultString = null;
            this.lblIntervalSeconds.Location = new System.Drawing.Point(44, 15);
            this.lblIntervalSeconds.Name = "lblIntervalSeconds";
            this.lblIntervalSeconds.Size = new System.Drawing.Size(135, 12);
            this.lblIntervalSeconds.TabIndex = 2;
            this.lblIntervalSeconds.Text = "TIMING.LABEL.SECONDS";
            this.lblIntervalSeconds.TranslationString = "TIMING.LABEL.SECONDS";
            // 
            // cmbIntervalMinutes
            // 
            this.cmbIntervalMinutes.Location = new System.Drawing.Point(134, 30);
            this.cmbIntervalMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.cmbIntervalMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cmbIntervalMinutes.Name = "cmbIntervalMinutes";
            this.cmbIntervalMinutes.Size = new System.Drawing.Size(120, 19);
            this.cmbIntervalMinutes.TabIndex = 1;
            this.cmbIntervalMinutes.Tag = "IntervalMinutes";
            this.cmbIntervalMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cmbIntervalSeconds
            // 
            this.cmbIntervalSeconds.Location = new System.Drawing.Point(8, 30);
            this.cmbIntervalSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.cmbIntervalSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cmbIntervalSeconds.Name = "cmbIntervalSeconds";
            this.cmbIntervalSeconds.Size = new System.Drawing.Size(120, 19);
            this.cmbIntervalSeconds.TabIndex = 0;
            this.cmbIntervalSeconds.Tag = "IntervalSeconds";
            this.cmbIntervalSeconds.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.DefaultString = null;
            this.btnSave.Location = new System.Drawing.Point(105, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "TIMING.BUTTON.SAVE";
            this.btnSave.TranslationString = "TIMING.BUTTON.SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TimingTitle
            // 
            this.TimingTitle.Parameters = new object[0];
            this.TimingTitle.ParentForm = this;
            this.TimingTitle.TranslationString = "TITLE.TIMING";
            // 
            // TimingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 238);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpInterval);
            this.Controls.Add(this.grpOffset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimingForm";
            this.Text = "TITLE.TIMING";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimingForm_FormClosed);
            this.grpOffset.ResumeLayout(false);
            this.grpOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffsetSeconds)).EndInit();
            this.grpInterval.ResumeLayout(false);
            this.grpInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIntervalSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WallChanger.Translation.Controls.TranslatableGroupBoxFormat grpOffset;
        private WallChanger.Translation.Controls.TranslatableLabel lblOffsetHours;
        private System.Windows.Forms.NumericUpDown cmbOffsetHours;
        private WallChanger.Translation.Controls.TranslatableLabel lblOffsetMinutes;
        private WallChanger.Translation.Controls.TranslatableLabel lblOffsetSeconds;
        private System.Windows.Forms.NumericUpDown cmbOffsetMinutes;
        private System.Windows.Forms.NumericUpDown cmbOffsetSeconds;
        private WallChanger.Translation.Controls.TranslatableGroupBoxFormat grpInterval;
        private WallChanger.Translation.Controls.TranslatableLabel lblIntervalHours;
        private System.Windows.Forms.NumericUpDown cmbIntervalHours;
        private WallChanger.Translation.Controls.TranslatableLabel lblIntervalMinutes;
        private WallChanger.Translation.Controls.TranslatableLabel lblIntervalSeconds;
        private System.Windows.Forms.NumericUpDown cmbIntervalMinutes;
        private System.Windows.Forms.NumericUpDown cmbIntervalSeconds;
        private WallChanger.Translation.Controls.TranslatableButton btnSave;
        private Translation.Controls.TranslatableTitleFormat TimingTitle;
    }
}