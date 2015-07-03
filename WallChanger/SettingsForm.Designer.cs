namespace WallChanger
{
    partial class SettingsForm
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
            this.grpCompression = new System.Windows.Forms.GroupBox();
            this.cmbCompressionLevel = new System.Windows.Forms.ComboBox();
            this.lblCompressionLevel = new System.Windows.Forms.Label();
            this.lblCompressionWarning = new System.Windows.Forms.Label();
            this.grpCompression.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCompression
            // 
            this.grpCompression.Controls.Add(this.lblCompressionWarning);
            this.grpCompression.Controls.Add(this.lblCompressionLevel);
            this.grpCompression.Controls.Add(this.cmbCompressionLevel);
            this.grpCompression.Location = new System.Drawing.Point(12, 12);
            this.grpCompression.Name = "grpCompression";
            this.grpCompression.Size = new System.Drawing.Size(741, 225);
            this.grpCompression.TabIndex = 0;
            this.grpCompression.TabStop = false;
            this.grpCompression.Text = "SETTINGS_LABEL_COMPRESSION";
            // 
            // cmbCompressionLevel
            // 
            this.cmbCompressionLevel.FormattingEnabled = true;
            this.cmbCompressionLevel.Location = new System.Drawing.Point(9, 32);
            this.cmbCompressionLevel.Name = "cmbCompressionLevel";
            this.cmbCompressionLevel.Size = new System.Drawing.Size(726, 21);
            this.cmbCompressionLevel.TabIndex = 0;
            this.cmbCompressionLevel.SelectedValueChanged += new System.EventHandler(this.cmbCompressionLevel_SelectedValueChanged);
            // 
            // lblCompressionLevel
            // 
            this.lblCompressionLevel.AutoSize = true;
            this.lblCompressionLevel.Location = new System.Drawing.Point(6, 16);
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            this.lblCompressionLevel.Size = new System.Drawing.Size(224, 13);
            this.lblCompressionLevel.TabIndex = 1;
            this.lblCompressionLevel.Text = "SETTINGS_LABEL_COMPRESSION_LEVEL";
            // 
            // lblCompressionWarning
            // 
            this.lblCompressionWarning.AutoSize = true;
            this.lblCompressionWarning.Location = new System.Drawing.Point(6, 56);
            this.lblCompressionWarning.Name = "lblCompressionWarning";
            this.lblCompressionWarning.Size = new System.Drawing.Size(244, 13);
            this.lblCompressionWarning.TabIndex = 2;
            this.lblCompressionWarning.Text = "SETTINGS_LABEL_COMPRESSION_WARNING";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 411);
            this.Controls.Add(this.grpCompression);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpCompression.ResumeLayout(false);
            this.grpCompression.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCompression;
        private System.Windows.Forms.Label lblCompressionWarning;
        private System.Windows.Forms.Label lblCompressionLevel;
        private System.Windows.Forms.ComboBox cmbCompressionLevel;
    }
}