namespace LanguageEditor
{
    partial class MainForm
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
            this.cmbFallbackLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEditFallback = new System.Windows.Forms.CheckBox();
            this.cmbCurrentLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewLanguage = new System.Windows.Forms.Button();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.txtFallback = new System.Windows.Forms.TextBox();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.txtString = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.treStrings = new LanguageEditor.ColourableTreeView();
            this.pnlEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFallbackLanguage
            // 
            this.cmbFallbackLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFallbackLanguage.FormattingEnabled = true;
            this.cmbFallbackLanguage.Location = new System.Drawing.Point(118, 14);
            this.cmbFallbackLanguage.Name = "cmbFallbackLanguage";
            this.cmbFallbackLanguage.Size = new System.Drawing.Size(218, 20);
            this.cmbFallbackLanguage.TabIndex = 0;
            this.cmbFallbackLanguage.SelectedValueChanged += new System.EventHandler(this.chkEditFallback_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fallback Language";
            // 
            // chkEditFallback
            // 
            this.chkEditFallback.AutoSize = true;
            this.chkEditFallback.Location = new System.Drawing.Point(342, 16);
            this.chkEditFallback.Name = "chkEditFallback";
            this.chkEditFallback.Size = new System.Drawing.Size(143, 16);
            this.chkEditFallback.TabIndex = 2;
            this.chkEditFallback.Text = "Edit Fallback Language";
            this.chkEditFallback.UseVisualStyleBackColor = true;
            this.chkEditFallback.CheckedChanged += new System.EventHandler(this.chkEditFallback_CheckedChanged);
            // 
            // cmbCurrentLanguage
            // 
            this.cmbCurrentLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrentLanguage.FormattingEnabled = true;
            this.cmbCurrentLanguage.Location = new System.Drawing.Point(548, 14);
            this.cmbCurrentLanguage.Name = "cmbCurrentLanguage";
            this.cmbCurrentLanguage.Size = new System.Drawing.Size(218, 20);
            this.cmbCurrentLanguage.TabIndex = 3;
            this.cmbCurrentLanguage.SelectedValueChanged += new System.EventHandler(this.chkEditFallback_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Language";
            // 
            // btnNewLanguage
            // 
            this.btnNewLanguage.Location = new System.Drawing.Point(772, 12);
            this.btnNewLanguage.Name = "btnNewLanguage";
            this.btnNewLanguage.Size = new System.Drawing.Size(75, 23);
            this.btnNewLanguage.TabIndex = 5;
            this.btnNewLanguage.Text = "New";
            this.btnNewLanguage.UseVisualStyleBackColor = true;
            this.btnNewLanguage.Click += new System.EventHandler(this.btnNewLanguage_Click);
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.txtFallback);
            this.pnlEditor.Controls.Add(this.txtPreview);
            this.pnlEditor.Controls.Add(this.btnSave);
            this.pnlEditor.Controls.Add(this.grpParameters);
            this.pnlEditor.Controls.Add(this.txtString);
            this.pnlEditor.Controls.Add(this.lblTitle);
            this.pnlEditor.Location = new System.Drawing.Point(355, 40);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(499, 485);
            this.pnlEditor.TabIndex = 7;
            // 
            // txtFallback
            // 
            this.txtFallback.Enabled = false;
            this.txtFallback.Location = new System.Drawing.Point(3, 57);
            this.txtFallback.Name = "txtFallback";
            this.txtFallback.Size = new System.Drawing.Size(489, 19);
            this.txtFallback.TabIndex = 6;
            this.txtFallback.Text = "Fallback";
            this.txtFallback.TextChanged += new System.EventHandler(this.txtFallback_TextChanged);
            // 
            // txtPreview
            // 
            this.txtPreview.Location = new System.Drawing.Point(3, 82);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(489, 56);
            this.txtPreview.TabIndex = 5;
            this.txtPreview.Text = "Preview";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(417, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpParameters
            // 
            this.grpParameters.Location = new System.Drawing.Point(3, 144);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(489, 338);
            this.grpParameters.TabIndex = 3;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Parameters";
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(3, 32);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(489, 19);
            this.txtString.TabIndex = 1;
            this.txtString.Text = "String";
            this.txtString.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Identifier";
            // 
            // treStrings
            // 
            this.treStrings.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treStrings.EmphasisByDefault = true;
            this.treStrings.Location = new System.Drawing.Point(14, 40);
            this.treStrings.Name = "treStrings";
            this.treStrings.PathSeparator = ".";
            this.treStrings.Size = new System.Drawing.Size(335, 485);
            this.treStrings.TabIndex = 6;
            this.treStrings.TertiaryColour = System.Drawing.Color.DarkOrange;
            this.treStrings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treStrings_AfterSelect);
            this.treStrings.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treStrings_NodeMouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 537);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.treStrings);
            this.Controls.Add(this.btnNewLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCurrentLanguage);
            this.Controls.Add(this.chkEditFallback);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFallbackLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Language Editor";
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFallbackLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEditFallback;
        private System.Windows.Forms.ComboBox cmbCurrentLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewLanguage;
        private ColourableTreeView treStrings;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.TextBox txtFallback;
    }
}

