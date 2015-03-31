namespace WallChanger
{
    partial class LibraryForm
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
            this.components = new System.ComponentModel.Container();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.spcContainer = new System.Windows.Forms.SplitContainer();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.Tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.pnlTags = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShowName = new System.Windows.Forms.ComboBox();
            this.btnAddShowName = new System.Windows.Forms.Button();
            this.btnClearCategory = new System.Windows.Forms.Button();
            this.btnClearShowName = new System.Windows.Forms.Button();
            this.btnClearCharacters = new System.Windows.Forms.Button();
            this.btnRemoveCharacter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.btnAddNewCharacter = new System.Windows.Forms.Button();
            this.lblImageSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).BeginInit();
            this.spcContainer.Panel1.SuspendLayout();
            this.spcContainer.Panel2.SuspendLayout();
            this.spcContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.pnlBottomRight.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstImages
            // 
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.FormattingEnabled = true;
            this.lstImages.Location = new System.Drawing.Point(0, 0);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(651, 503);
            this.lstImages.TabIndex = 0;
            this.lstImages.SelectedIndexChanged += new System.EventHandler(this.lstImages_SelectedIndexChanged);
            // 
            // spcContainer
            // 
            this.spcContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContainer.Location = new System.Drawing.Point(0, 0);
            this.spcContainer.Name = "spcContainer";
            // 
            // spcContainer.Panel1
            // 
            this.spcContainer.Panel1.Controls.Add(this.lstImages);
            // 
            // spcContainer.Panel2
            // 
            this.spcContainer.Panel2.Controls.Add(this.pnlBottomRight);
            this.spcContainer.Panel2.Controls.Add(this.picPreview);
            this.spcContainer.Size = new System.Drawing.Size(857, 503);
            this.spcContainer.SplitterDistance = 651;
            this.spcContainer.TabIndex = 1;
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(202, 202);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(7, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(192, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectionChangeCommitted += new System.EventHandler(this.cmbCategory_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddCategory.Location = new System.Drawing.Point(145, 20);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 24);
            this.btnAddCategory.TabIndex = 3;
            this.Tooltips.SetToolTip(this.btnAddCategory, "Add new category.");
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.pnlTags);
            this.pnlBottomRight.Controls.Add(this.pnlCategory);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomRight.Location = new System.Drawing.Point(0, 202);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(202, 301);
            this.pnlBottomRight.TabIndex = 5;
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.lblImageSize);
            this.pnlCategory.Controls.Add(this.btnAddNewCharacter);
            this.pnlCategory.Controls.Add(this.lstCharacters);
            this.pnlCategory.Controls.Add(this.btnClearCharacters);
            this.pnlCategory.Controls.Add(this.btnRemoveCharacter);
            this.pnlCategory.Controls.Add(this.label3);
            this.pnlCategory.Controls.Add(this.btnClearShowName);
            this.pnlCategory.Controls.Add(this.btnClearCategory);
            this.pnlCategory.Controls.Add(this.btnAddShowName);
            this.pnlCategory.Controls.Add(this.cmbShowName);
            this.pnlCategory.Controls.Add(this.label2);
            this.pnlCategory.Controls.Add(this.label1);
            this.pnlCategory.Controls.Add(this.btnAddCategory);
            this.pnlCategory.Controls.Add(this.cmbCategory);
            this.pnlCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategory.Location = new System.Drawing.Point(0, 0);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(202, 267);
            this.pnlCategory.TabIndex = 5;
            // 
            // pnlTags
            // 
            this.pnlTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTags.Location = new System.Drawing.Point(0, 267);
            this.pnlTags.Name = "pnlTags";
            this.pnlTags.Size = new System.Drawing.Size(202, 34);
            this.pnlTags.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Show Name";
            // 
            // cmbShowName
            // 
            this.cmbShowName.FormattingEnabled = true;
            this.cmbShowName.Location = new System.Drawing.Point(7, 106);
            this.cmbShowName.Name = "cmbShowName";
            this.cmbShowName.Size = new System.Drawing.Size(192, 21);
            this.cmbShowName.TabIndex = 5;
            this.cmbShowName.SelectionChangeCommitted += new System.EventHandler(this.cmbShowName_SelectionChangeCommitted);
            // 
            // btnAddShowName
            // 
            this.btnAddShowName.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddShowName.Location = new System.Drawing.Point(145, 76);
            this.btnAddShowName.Name = "btnAddShowName";
            this.btnAddShowName.Size = new System.Drawing.Size(24, 24);
            this.btnAddShowName.TabIndex = 6;
            this.Tooltips.SetToolTip(this.btnAddShowName, "Add new show name.");
            this.btnAddShowName.UseVisualStyleBackColor = true;
            this.btnAddShowName.Click += new System.EventHandler(this.btnAddShowName_Click);
            // 
            // btnClearCategory
            // 
            this.btnClearCategory.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCategory.Location = new System.Drawing.Point(175, 20);
            this.btnClearCategory.Name = "btnClearCategory";
            this.btnClearCategory.Size = new System.Drawing.Size(24, 24);
            this.btnClearCategory.TabIndex = 7;
            this.Tooltips.SetToolTip(this.btnClearCategory, "Clear category.");
            this.btnClearCategory.UseVisualStyleBackColor = true;
            this.btnClearCategory.Click += new System.EventHandler(this.btnClearCategory_Click);
            // 
            // btnClearShowName
            // 
            this.btnClearShowName.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearShowName.Location = new System.Drawing.Point(175, 76);
            this.btnClearShowName.Name = "btnClearShowName";
            this.btnClearShowName.Size = new System.Drawing.Size(24, 24);
            this.btnClearShowName.TabIndex = 8;
            this.Tooltips.SetToolTip(this.btnClearShowName, "Clear show name.");
            this.btnClearShowName.UseVisualStyleBackColor = true;
            this.btnClearShowName.Click += new System.EventHandler(this.btnClearShowName_Click);
            // 
            // btnClearCharacters
            // 
            this.btnClearCharacters.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCharacters.Location = new System.Drawing.Point(176, 133);
            this.btnClearCharacters.Name = "btnClearCharacters";
            this.btnClearCharacters.Size = new System.Drawing.Size(24, 24);
            this.btnClearCharacters.TabIndex = 11;
            this.Tooltips.SetToolTip(this.btnClearCharacters, "Clear characters.");
            this.btnClearCharacters.UseVisualStyleBackColor = true;
            this.btnClearCharacters.Click += new System.EventHandler(this.btnClearCharacters_Click);
            // 
            // btnRemoveCharacter
            // 
            this.btnRemoveCharacter.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveCharacter.Location = new System.Drawing.Point(145, 133);
            this.btnRemoveCharacter.Name = "btnRemoveCharacter";
            this.btnRemoveCharacter.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveCharacter.TabIndex = 10;
            this.Tooltips.SetToolTip(this.btnRemoveCharacter, "Remove character.");
            this.btnRemoveCharacter.UseVisualStyleBackColor = true;
            this.btnRemoveCharacter.Click += new System.EventHandler(this.btnRemoveCharacter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Characters";
            // 
            // lstCharacters
            // 
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.Location = new System.Drawing.Point(6, 163);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(192, 56);
            this.lstCharacters.TabIndex = 12;
            // 
            // btnAddNewCharacter
            // 
            this.btnAddNewCharacter.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddNewCharacter.Location = new System.Drawing.Point(115, 133);
            this.btnAddNewCharacter.Name = "btnAddNewCharacter";
            this.btnAddNewCharacter.Size = new System.Drawing.Size(24, 24);
            this.btnAddNewCharacter.TabIndex = 13;
            this.Tooltips.SetToolTip(this.btnAddNewCharacter, "Add new character.");
            this.btnAddNewCharacter.UseVisualStyleBackColor = true;
            this.btnAddNewCharacter.Click += new System.EventHandler(this.btnAddNewCharacter_Click);
            // 
            // lblImageSize
            // 
            this.lblImageSize.AutoSize = true;
            this.lblImageSize.Location = new System.Drawing.Point(4, 3);
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Size = new System.Drawing.Size(93, 13);
            this.lblImageSize.TabIndex = 14;
            this.lblImageSize.Text = "Image Size: 0x0px";
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 503);
            this.Controls.Add(this.spcContainer);
            this.Name = "LibraryForm";
            this.Text = "LibraryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryForm_FormClosed);
            this.spcContainer.Panel1.ResumeLayout(false);
            this.spcContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).EndInit();
            this.spcContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.SplitContainer spcContainer;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ToolTip Tooltips;
        private System.Windows.Forms.Panel pnlBottomRight;
        private System.Windows.Forms.Panel pnlTags;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Button btnAddNewCharacter;
        private System.Windows.Forms.ListBox lstCharacters;
        private System.Windows.Forms.Button btnClearCharacters;
        private System.Windows.Forms.Button btnRemoveCharacter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearShowName;
        private System.Windows.Forms.Button btnClearCategory;
        private System.Windows.Forms.Button btnAddShowName;
        private System.Windows.Forms.ComboBox cmbShowName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImageSize;
    }
}