namespace WallChanger
{
    partial class LanguageForm
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
            this.btnSave = new WallChanger.Translation.Controls.TranslatableButton();
            this.cmbCurrentLanguage = new System.Windows.Forms.ComboBox();
            this.lblCurrentLanguage = new WallChanger.Translation.Controls.TranslatableLabel();
            this.lblFallbackLanguage = new WallChanger.Translation.Controls.TranslatableLabel();
            this.cmbFallbackLanguage = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.LanguageTitle = new WallChanger.Translation.Controls.TranslatableTitle();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DefaultString = null;
            this.btnSave.Location = new System.Drawing.Point(105, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "LANG.BUTTON.SAVE";
            this.btnSave.TranslationString = "LANG.BUTTON.SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCurrentLanguage
            // 
            this.cmbCurrentLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrentLanguage.FormattingEnabled = true;
            this.cmbCurrentLanguage.Location = new System.Drawing.Point(12, 23);
            this.cmbCurrentLanguage.Name = "cmbCurrentLanguage";
            this.cmbCurrentLanguage.Size = new System.Drawing.Size(260, 20);
            this.cmbCurrentLanguage.TabIndex = 1;
            this.cmbCurrentLanguage.SelectedValueChanged += new System.EventHandler(this.LanguageChanged);
            // 
            // lblCurrentLanguage
            // 
            this.lblCurrentLanguage.AutoSize = true;
            this.lblCurrentLanguage.DefaultString = null;
            this.lblCurrentLanguage.Location = new System.Drawing.Point(12, 8);
            this.lblCurrentLanguage.Name = "lblCurrentLanguage";
            this.lblCurrentLanguage.Size = new System.Drawing.Size(193, 12);
            this.lblCurrentLanguage.TabIndex = 2;
            this.lblCurrentLanguage.Text = "LANG.LABEL.CURRENT_LANGUAGE";
            this.lblCurrentLanguage.TranslationString = "LANG.LABEL.CURRENT_LANGUAGE";
            // 
            // lblFallbackLanguage
            // 
            this.lblFallbackLanguage.AutoSize = true;
            this.lblFallbackLanguage.DefaultString = null;
            this.lblFallbackLanguage.Location = new System.Drawing.Point(12, 45);
            this.lblFallbackLanguage.Name = "lblFallbackLanguage";
            this.lblFallbackLanguage.Size = new System.Drawing.Size(197, 12);
            this.lblFallbackLanguage.TabIndex = 4;
            this.lblFallbackLanguage.Text = "LANG.LABEL.FALLBACK_LANGUAGE";
            this.lblFallbackLanguage.TranslationString = "LANG.LABEL.FALLBACK_LANGUAGE";
            // 
            // cmbFallbackLanguage
            // 
            this.cmbFallbackLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFallbackLanguage.FormattingEnabled = true;
            this.cmbFallbackLanguage.Location = new System.Drawing.Point(12, 60);
            this.cmbFallbackLanguage.Name = "cmbFallbackLanguage";
            this.cmbFallbackLanguage.Size = new System.Drawing.Size(260, 20);
            this.cmbFallbackLanguage.TabIndex = 3;
            this.cmbFallbackLanguage.SelectedValueChanged += new System.EventHandler(this.LanguageChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 85);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(257, 119);
            this.txtDescription.TabIndex = 5;
            // 
            // LanguageTitle
            // 
            this.LanguageTitle.DefaultString = "Language Settings";
            this.LanguageTitle.ParentForm = this;
            this.LanguageTitle.TranslationString = "TITLE.LANGUAGE";
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 242);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblFallbackLanguage);
            this.Controls.Add(this.cmbFallbackLanguage);
            this.Controls.Add(this.lblCurrentLanguage);
            this.Controls.Add(this.cmbCurrentLanguage);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LanguageForm";
            this.Text = "LanguageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LanguageForm_FormClosing);
            this.Load += new System.EventHandler(this.LanguageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WallChanger.Translation.Controls.TranslatableButton btnSave;
        private System.Windows.Forms.ComboBox cmbCurrentLanguage;
        private WallChanger.Translation.Controls.TranslatableLabel lblCurrentLanguage;
        private WallChanger.Translation.Controls.TranslatableLabel lblFallbackLanguage;
        private System.Windows.Forms.ComboBox cmbFallbackLanguage;
        private System.Windows.Forms.TextBox txtDescription;
        private Translation.Controls.TranslatableTitle LanguageTitle;
    }
}