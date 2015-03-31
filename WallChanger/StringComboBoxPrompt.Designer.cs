namespace WallChanger
{
    partial class StringComboBoxPrompt
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
            this.cmbComboBox = new System.Windows.Forms.ComboBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtTextBox = new System.Windows.Forms.TextBox();
            this.rdbComboBox = new System.Windows.Forms.RadioButton();
            this.rdbTextBox = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbComboBox
            // 
            this.cmbComboBox.FormattingEnabled = true;
            this.cmbComboBox.Location = new System.Drawing.Point(12, 25);
            this.cmbComboBox.Name = "cmbComboBox";
            this.cmbComboBox.Size = new System.Drawing.Size(419, 21);
            this.cmbComboBox.TabIndex = 0;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(60, 13);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "Prompt text";
            // 
            // txtTextBox
            // 
            this.txtTextBox.Enabled = false;
            this.txtTextBox.Location = new System.Drawing.Point(12, 75);
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(419, 20);
            this.txtTextBox.TabIndex = 2;
            // 
            // rdbComboBox
            // 
            this.rdbComboBox.AutoSize = true;
            this.rdbComboBox.Checked = true;
            this.rdbComboBox.Location = new System.Drawing.Point(15, 52);
            this.rdbComboBox.Name = "rdbComboBox";
            this.rdbComboBox.Size = new System.Drawing.Size(113, 17);
            this.rdbComboBox.TabIndex = 3;
            this.rdbComboBox.TabStop = true;
            this.rdbComboBox.Text = "Use Existing Value";
            this.rdbComboBox.UseVisualStyleBackColor = true;
            this.rdbComboBox.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // rdbTextBox
            // 
            this.rdbTextBox.AutoSize = true;
            this.rdbTextBox.Location = new System.Drawing.Point(134, 53);
            this.rdbTextBox.Name = "rdbTextBox";
            this.rdbTextBox.Size = new System.Drawing.Size(111, 17);
            this.rdbTextBox.TabIndex = 4;
            this.rdbTextBox.Text = "Create New Value";
            this.rdbTextBox.UseVisualStyleBackColor = true;
            this.rdbTextBox.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(356, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(275, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // StringComboBoxPrompt
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(443, 136);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rdbTextBox);
            this.Controls.Add(this.rdbComboBox);
            this.Controls.Add(this.txtTextBox);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.cmbComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StringComboBoxPrompt";
            this.Text = "StringComboBoxPrompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbComboBox;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtTextBox;
        private System.Windows.Forms.RadioButton rdbComboBox;
        private System.Windows.Forms.RadioButton rdbTextBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}