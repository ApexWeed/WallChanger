namespace WallChanger
{
    partial class ProcessingSettingsForm
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
            this.cdgColourDialog = new System.Windows.Forms.ColorDialog();
            this.ProcessingSettingsTitle = new WallChanger.Translation.Controls.TranslatableTitleFormat();
            this.SuspendLayout();
            // 
            // ProcessingSettingsTitle
            // 
            this.ProcessingSettingsTitle.DefaultString = null;
            this.ProcessingSettingsTitle.Parameters = new object[0];
            this.ProcessingSettingsTitle.ParentForm = this;
            this.ProcessingSettingsTitle.TranslationString = "TITLE.PREPROCESSING";
            // 
            // ProcessingSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 480);
            this.Name = "ProcessingSettingsForm";
            this.Text = "TITLE.PREPROCESSING";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProcessingSettingsForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog cdgColourDialog;
        private Translation.Controls.TranslatableTitleFormat ProcessingSettingsTitle;
    }
}