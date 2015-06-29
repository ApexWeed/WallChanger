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
            this.grpOffset = new System.Windows.Forms.GroupBox();
            this.lblOffsetHours = new System.Windows.Forms.Label();
            this.cmbOffsetHours = new System.Windows.Forms.NumericUpDown();
            this.lblOffsetMinutes = new System.Windows.Forms.Label();
            this.lblOffsetSeconds = new System.Windows.Forms.Label();
            this.cmbOffsetMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmbOffsetSeconds = new System.Windows.Forms.NumericUpDown();
            this.grpInterval = new System.Windows.Forms.GroupBox();
            this.lblIntervalHours = new System.Windows.Forms.Label();
            this.cmbIntervalHours = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalMinutes = new System.Windows.Forms.Label();
            this.lblIntervalSeconds = new System.Windows.Forms.Label();
            this.cmbIntervalMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmbIntervalSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.grpOffset.Location = new System.Drawing.Point(12, 12);
            this.grpOffset.Name = "grpOffset";
            this.grpOffset.Size = new System.Drawing.Size(260, 100);
            this.grpOffset.TabIndex = 0;
            this.grpOffset.TabStop = false;
            this.grpOffset.Text = "TIMING_LABEL_OFFSET";
            // 
            // lblOffsetHours
            // 
            this.lblOffsetHours.AutoSize = true;
            this.lblOffsetHours.Location = new System.Drawing.Point(113, 58);
            this.lblOffsetHours.Name = "lblOffsetHours";
            this.lblOffsetHours.Size = new System.Drawing.Size(129, 13);
            this.lblOffsetHours.TabIndex = 6;
            this.lblOffsetHours.Text = "TIMING_LABEL_HOURS";
            // 
            // cmbOffsetHours
            // 
            this.cmbOffsetHours.Location = new System.Drawing.Point(70, 74);
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
            this.cmbOffsetHours.Size = new System.Drawing.Size(120, 20);
            this.cmbOffsetHours.TabIndex = 4;
            this.cmbOffsetHours.Tag = "OffsetHours";
            // 
            // lblOffsetMinutes
            // 
            this.lblOffsetMinutes.AutoSize = true;
            this.lblOffsetMinutes.Location = new System.Drawing.Point(172, 16);
            this.lblOffsetMinutes.Name = "lblOffsetMinutes";
            this.lblOffsetMinutes.Size = new System.Drawing.Size(139, 13);
            this.lblOffsetMinutes.TabIndex = 3;
            this.lblOffsetMinutes.Text = "TIMING_LABEL_MINUTES";
            // 
            // lblOffsetSeconds
            // 
            this.lblOffsetSeconds.AutoSize = true;
            this.lblOffsetSeconds.Location = new System.Drawing.Point(44, 16);
            this.lblOffsetSeconds.Name = "lblOffsetSeconds";
            this.lblOffsetSeconds.Size = new System.Drawing.Size(142, 13);
            this.lblOffsetSeconds.TabIndex = 2;
            this.lblOffsetSeconds.Text = "TIMING_LABLE_SECONDS";
            // 
            // cmbOffsetMinutes
            // 
            this.cmbOffsetMinutes.Location = new System.Drawing.Point(134, 32);
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
            this.cmbOffsetMinutes.Size = new System.Drawing.Size(120, 20);
            this.cmbOffsetMinutes.TabIndex = 1;
            this.cmbOffsetMinutes.Tag = "OffsetMinutes";
            this.cmbOffsetMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cmbOffsetSeconds
            // 
            this.cmbOffsetSeconds.Location = new System.Drawing.Point(8, 32);
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
            this.cmbOffsetSeconds.Size = new System.Drawing.Size(120, 20);
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
            this.grpInterval.Location = new System.Drawing.Point(12, 118);
            this.grpInterval.Name = "grpInterval";
            this.grpInterval.Size = new System.Drawing.Size(260, 100);
            this.grpInterval.TabIndex = 7;
            this.grpInterval.TabStop = false;
            this.grpInterval.Text = "TIMING_LABEL_INTERVAL";
            // 
            // lblIntervalHours
            // 
            this.lblIntervalHours.AutoSize = true;
            this.lblIntervalHours.Location = new System.Drawing.Point(113, 58);
            this.lblIntervalHours.Name = "lblIntervalHours";
            this.lblIntervalHours.Size = new System.Drawing.Size(142, 13);
            this.lblIntervalHours.TabIndex = 6;
            this.lblIntervalHours.Text = "TIMING_LABEL_SECONDS";
            // 
            // cmbIntervalHours
            // 
            this.cmbIntervalHours.Location = new System.Drawing.Point(70, 74);
            this.cmbIntervalHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.cmbIntervalHours.Name = "cmbIntervalHours";
            this.cmbIntervalHours.Size = new System.Drawing.Size(120, 20);
            this.cmbIntervalHours.TabIndex = 4;
            this.cmbIntervalHours.Tag = "IntervalHours";
            // 
            // lblIntervalMinutes
            // 
            this.lblIntervalMinutes.AutoSize = true;
            this.lblIntervalMinutes.Location = new System.Drawing.Point(172, 16);
            this.lblIntervalMinutes.Name = "lblIntervalMinutes";
            this.lblIntervalMinutes.Size = new System.Drawing.Size(139, 13);
            this.lblIntervalMinutes.TabIndex = 3;
            this.lblIntervalMinutes.Text = "TIMING_LABEL_MINUTES";
            // 
            // lblIntervalSeconds
            // 
            this.lblIntervalSeconds.AutoSize = true;
            this.lblIntervalSeconds.Location = new System.Drawing.Point(44, 16);
            this.lblIntervalSeconds.Name = "lblIntervalSeconds";
            this.lblIntervalSeconds.Size = new System.Drawing.Size(142, 13);
            this.lblIntervalSeconds.TabIndex = 2;
            this.lblIntervalSeconds.Text = "TIMING_LABEL_SECONDS";
            // 
            // cmbIntervalMinutes
            // 
            this.cmbIntervalMinutes.Location = new System.Drawing.Point(134, 32);
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
            this.cmbIntervalMinutes.Size = new System.Drawing.Size(120, 20);
            this.cmbIntervalMinutes.TabIndex = 1;
            this.cmbIntervalMinutes.Tag = "IntervalMinutes";
            this.cmbIntervalMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cmbIntervalSeconds
            // 
            this.cmbIntervalSeconds.Location = new System.Drawing.Point(8, 32);
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
            this.cmbIntervalSeconds.Size = new System.Drawing.Size(120, 20);
            this.cmbIntervalSeconds.TabIndex = 0;
            this.cmbIntervalSeconds.Tag = "IntervalSeconds";
            this.cmbIntervalSeconds.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "TIMING_BUTTON_SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TimingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpInterval);
            this.Controls.Add(this.grpOffset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimingForm";
            this.Text = "TimingForm";
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

        private System.Windows.Forms.GroupBox grpOffset;
        private System.Windows.Forms.Label lblOffsetHours;
        private System.Windows.Forms.NumericUpDown cmbOffsetHours;
        private System.Windows.Forms.Label lblOffsetMinutes;
        private System.Windows.Forms.Label lblOffsetSeconds;
        private System.Windows.Forms.NumericUpDown cmbOffsetMinutes;
        private System.Windows.Forms.NumericUpDown cmbOffsetSeconds;
        private System.Windows.Forms.GroupBox grpInterval;
        private System.Windows.Forms.Label lblIntervalHours;
        private System.Windows.Forms.NumericUpDown cmbIntervalHours;
        private System.Windows.Forms.Label lblIntervalMinutes;
        private System.Windows.Forms.Label lblIntervalSeconds;
        private System.Windows.Forms.NumericUpDown cmbIntervalMinutes;
        private System.Windows.Forms.NumericUpDown cmbIntervalSeconds;
        private System.Windows.Forms.Button btnSave;
    }
}