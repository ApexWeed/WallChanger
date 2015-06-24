namespace WallChanger
{
    partial class AutoResolveForm
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
            this.rdbRemove = new System.Windows.Forms.RadioButton();
            this.rdbDelete = new System.Windows.Forms.RadioButton();
            this.btnProcess = new System.Windows.Forms.Button();
            this.infoProgressBar1 = new Otokei_Doujin_Downloader.InfoProgressBar();
            this.SuspendLayout();
            // 
            // rdbRemove
            // 
            this.rdbRemove.AutoSize = true;
            this.rdbRemove.Checked = true;
            this.rdbRemove.Location = new System.Drawing.Point(12, 41);
            this.rdbRemove.Name = "rdbRemove";
            this.rdbRemove.Size = new System.Drawing.Size(118, 17);
            this.rdbRemove.TabIndex = 1;
            this.rdbRemove.TabStop = true;
            this.rdbRemove.Text = "Remove from library";
            this.rdbRemove.UseVisualStyleBackColor = true;
            // 
            // rdbDelete
            // 
            this.rdbDelete.AutoSize = true;
            this.rdbDelete.Location = new System.Drawing.Point(136, 41);
            this.rdbDelete.Name = "rdbDelete";
            this.rdbDelete.Size = new System.Drawing.Size(101, 17);
            this.rdbDelete.TabIndex = 2;
            this.rdbDelete.Text = "Delete from disk";
            this.rdbDelete.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(243, 41);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // infoProgressBar1
            // 
            this.infoProgressBar1.CustomText = "Wow";
            this.infoProgressBar1.DisplayStyle = Otokei_Doujin_Downloader.ProgressBarDisplayText.CustomText;
            this.infoProgressBar1.Location = new System.Drawing.Point(12, 12);
            this.infoProgressBar1.Name = "infoProgressBar1";
            this.infoProgressBar1.Size = new System.Drawing.Size(306, 23);
            this.infoProgressBar1.TabIndex = 0;
            // 
            // AutoResolveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 73);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.rdbDelete);
            this.Controls.Add(this.rdbRemove);
            this.Controls.Add(this.infoProgressBar1);
            this.Name = "AutoResolveForm";
            this.Text = "AutoResolveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Otokei_Doujin_Downloader.InfoProgressBar infoProgressBar1;
        private System.Windows.Forms.RadioButton rdbRemove;
        private System.Windows.Forms.RadioButton rdbDelete;
        private System.Windows.Forms.Button btnProcess;
    }
}