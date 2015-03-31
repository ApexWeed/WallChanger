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
            this.label4 = new System.Windows.Forms.Label();
            this.OffsetHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OffsetMinutes = new System.Windows.Forms.NumericUpDown();
            this.OffsetSeconds = new System.Windows.Forms.NumericUpDown();
            this.grpInterval = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IntervalHours = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IntervalMinutes = new System.Windows.Forms.NumericUpDown();
            this.IntervalSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetSeconds)).BeginInit();
            this.grpInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOffset
            // 
            this.grpOffset.Controls.Add(this.label4);
            this.grpOffset.Controls.Add(this.OffsetHours);
            this.grpOffset.Controls.Add(this.label2);
            this.grpOffset.Controls.Add(this.label1);
            this.grpOffset.Controls.Add(this.OffsetMinutes);
            this.grpOffset.Controls.Add(this.OffsetSeconds);
            this.grpOffset.Location = new System.Drawing.Point(12, 12);
            this.grpOffset.Name = "grpOffset";
            this.grpOffset.Size = new System.Drawing.Size(260, 100);
            this.grpOffset.TabIndex = 0;
            this.grpOffset.TabStop = false;
            this.grpOffset.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hours";
            // 
            // OffsetHours
            // 
            this.OffsetHours.Location = new System.Drawing.Point(70, 74);
            this.OffsetHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.OffsetHours.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.OffsetHours.Name = "OffsetHours";
            this.OffsetHours.Size = new System.Drawing.Size(120, 20);
            this.OffsetHours.TabIndex = 4;
            this.OffsetHours.Tag = "OffsetHours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minutes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seconds";
            // 
            // OffsetMinutes
            // 
            this.OffsetMinutes.Location = new System.Drawing.Point(134, 32);
            this.OffsetMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.OffsetMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.OffsetMinutes.Name = "OffsetMinutes";
            this.OffsetMinutes.Size = new System.Drawing.Size(120, 20);
            this.OffsetMinutes.TabIndex = 1;
            this.OffsetMinutes.Tag = "OffsetMinutes";
            this.OffsetMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // OffsetSeconds
            // 
            this.OffsetSeconds.Location = new System.Drawing.Point(8, 32);
            this.OffsetSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.OffsetSeconds.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.OffsetSeconds.Name = "OffsetSeconds";
            this.OffsetSeconds.Size = new System.Drawing.Size(120, 20);
            this.OffsetSeconds.TabIndex = 0;
            this.OffsetSeconds.Tag = "OffsetSeconds";
            this.OffsetSeconds.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // grpInterval
            // 
            this.grpInterval.Controls.Add(this.label3);
            this.grpInterval.Controls.Add(this.IntervalHours);
            this.grpInterval.Controls.Add(this.label5);
            this.grpInterval.Controls.Add(this.label6);
            this.grpInterval.Controls.Add(this.IntervalMinutes);
            this.grpInterval.Controls.Add(this.IntervalSeconds);
            this.grpInterval.Location = new System.Drawing.Point(12, 118);
            this.grpInterval.Name = "grpInterval";
            this.grpInterval.Size = new System.Drawing.Size(260, 100);
            this.grpInterval.TabIndex = 7;
            this.grpInterval.TabStop = false;
            this.grpInterval.Text = "Interval";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hours";
            // 
            // IntervalHours
            // 
            this.IntervalHours.Location = new System.Drawing.Point(70, 74);
            this.IntervalHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.IntervalHours.Name = "IntervalHours";
            this.IntervalHours.Size = new System.Drawing.Size(120, 20);
            this.IntervalHours.TabIndex = 4;
            this.IntervalHours.Tag = "IntervalHours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minutes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Seconds";
            // 
            // IntervalMinutes
            // 
            this.IntervalMinutes.Location = new System.Drawing.Point(134, 32);
            this.IntervalMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.IntervalMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.IntervalMinutes.Name = "IntervalMinutes";
            this.IntervalMinutes.Size = new System.Drawing.Size(120, 20);
            this.IntervalMinutes.TabIndex = 1;
            this.IntervalMinutes.Tag = "IntervalMinutes";
            this.IntervalMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // IntervalSeconds
            // 
            this.IntervalSeconds.Location = new System.Drawing.Point(8, 32);
            this.IntervalSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.IntervalSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.IntervalSeconds.Name = "IntervalSeconds";
            this.IntervalSeconds.Size = new System.Drawing.Size(120, 20);
            this.IntervalSeconds.TabIndex = 0;
            this.IntervalSeconds.Tag = "IntervalSeconds";
            this.IntervalSeconds.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
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
            ((System.ComponentModel.ISupportInitialize)(this.OffsetHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetSeconds)).EndInit();
            this.grpInterval.ResumeLayout(false);
            this.grpInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown OffsetHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown OffsetMinutes;
        private System.Windows.Forms.NumericUpDown OffsetSeconds;
        private System.Windows.Forms.GroupBox grpInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IntervalHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown IntervalMinutes;
        private System.Windows.Forms.NumericUpDown IntervalSeconds;
        private System.Windows.Forms.Button btnSave;
    }
}