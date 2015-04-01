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
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.pnlTagContainer = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblImageSize = new System.Windows.Forms.Label();
            this.btnAddNewCharacter = new System.Windows.Forms.Button();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.btnClearCharacters = new System.Windows.Forms.Button();
            this.btnRemoveCharacter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearShowName = new System.Windows.Forms.Button();
            this.btnClearCategory = new System.Windows.Forms.Button();
            this.btnAddShowName = new System.Windows.Forms.Button();
            this.cmbShowName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.Tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.lstTags = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddNewTag = new System.Windows.Forms.Button();
            this.btnClearTags = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.pnlTagButtons = new System.Windows.Forms.Panel();
            this.pnlTagList = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).BeginInit();
            this.spcContainer.Panel1.SuspendLayout();
            this.spcContainer.Panel2.SuspendLayout();
            this.spcContainer.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.pnlTagContainer.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.pnlTagButtons.SuspendLayout();
            this.pnlTagList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstImages
            // 
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.FormattingEnabled = true;
            this.lstImages.Location = new System.Drawing.Point(0, 0);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(651, 522);
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
            this.spcContainer.Panel2MinSize = 202;
            this.spcContainer.Size = new System.Drawing.Size(857, 522);
            this.spcContainer.SplitterDistance = 651;
            this.spcContainer.TabIndex = 1;
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.pnlTagContainer);
            this.pnlBottomRight.Controls.Add(this.pnlDetails);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomRight.Location = new System.Drawing.Point(0, 202);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(202, 320);
            this.pnlBottomRight.TabIndex = 5;
            // 
            // pnlTagContainer
            // 
            this.pnlTagContainer.Controls.Add(this.pnlTagList);
            this.pnlTagContainer.Controls.Add(this.pnlTagButtons);
            this.pnlTagContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagContainer.Location = new System.Drawing.Point(0, 225);
            this.pnlTagContainer.Name = "pnlTagContainer";
            this.pnlTagContainer.Padding = new System.Windows.Forms.Padding(7, 0, 9, 0);
            this.pnlTagContainer.Size = new System.Drawing.Size(202, 95);
            this.pnlTagContainer.TabIndex = 6;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblImageSize);
            this.pnlDetails.Controls.Add(this.btnAddNewCharacter);
            this.pnlDetails.Controls.Add(this.lstCharacters);
            this.pnlDetails.Controls.Add(this.btnClearCharacters);
            this.pnlDetails.Controls.Add(this.btnRemoveCharacter);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.btnClearShowName);
            this.pnlDetails.Controls.Add(this.btnClearCategory);
            this.pnlDetails.Controls.Add(this.btnAddShowName);
            this.pnlDetails.Controls.Add(this.cmbShowName);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.btnAddCategory);
            this.pnlDetails.Controls.Add(this.cmbCategory);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(202, 225);
            this.pnlDetails.TabIndex = 5;
            this.pnlDetails.Resize += new System.EventHandler(this.pnlDetails_Resize);
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
            // btnAddNewCharacter
            // 
            this.btnAddNewCharacter.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddNewCharacter.Location = new System.Drawing.Point(108, 133);
            this.btnAddNewCharacter.Name = "btnAddNewCharacter";
            this.btnAddNewCharacter.Size = new System.Drawing.Size(24, 24);
            this.btnAddNewCharacter.TabIndex = 13;
            this.Tooltips.SetToolTip(this.btnAddNewCharacter, "Add new character.");
            this.btnAddNewCharacter.UseVisualStyleBackColor = true;
            this.btnAddNewCharacter.Click += new System.EventHandler(this.btnAddNewCharacter_Click);
            // 
            // lstCharacters
            // 
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.Location = new System.Drawing.Point(7, 163);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(186, 56);
            this.lstCharacters.TabIndex = 12;
            // 
            // btnClearCharacters
            // 
            this.btnClearCharacters.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCharacters.Location = new System.Drawing.Point(169, 133);
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
            this.btnRemoveCharacter.Location = new System.Drawing.Point(138, 133);
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
            // btnClearShowName
            // 
            this.btnClearShowName.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearShowName.Location = new System.Drawing.Point(169, 76);
            this.btnClearShowName.Name = "btnClearShowName";
            this.btnClearShowName.Size = new System.Drawing.Size(24, 24);
            this.btnClearShowName.TabIndex = 8;
            this.Tooltips.SetToolTip(this.btnClearShowName, "Clear show name.");
            this.btnClearShowName.UseVisualStyleBackColor = true;
            this.btnClearShowName.Click += new System.EventHandler(this.btnClearShowName_Click);
            // 
            // btnClearCategory
            // 
            this.btnClearCategory.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearCategory.Location = new System.Drawing.Point(169, 19);
            this.btnClearCategory.Name = "btnClearCategory";
            this.btnClearCategory.Size = new System.Drawing.Size(24, 24);
            this.btnClearCategory.TabIndex = 7;
            this.Tooltips.SetToolTip(this.btnClearCategory, "Clear category.");
            this.btnClearCategory.UseVisualStyleBackColor = true;
            this.btnClearCategory.Click += new System.EventHandler(this.btnClearCategory_Click);
            // 
            // btnAddShowName
            // 
            this.btnAddShowName.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddShowName.Location = new System.Drawing.Point(139, 76);
            this.btnAddShowName.Name = "btnAddShowName";
            this.btnAddShowName.Size = new System.Drawing.Size(24, 24);
            this.btnAddShowName.TabIndex = 6;
            this.Tooltips.SetToolTip(this.btnAddShowName, "Add new show name.");
            this.btnAddShowName.UseVisualStyleBackColor = true;
            this.btnAddShowName.Click += new System.EventHandler(this.btnAddShowName_Click);
            // 
            // cmbShowName
            // 
            this.cmbShowName.FormattingEnabled = true;
            this.cmbShowName.Location = new System.Drawing.Point(7, 106);
            this.cmbShowName.Name = "cmbShowName";
            this.cmbShowName.Size = new System.Drawing.Size(186, 21);
            this.cmbShowName.TabIndex = 5;
            this.cmbShowName.SelectedValueChanged += new System.EventHandler(this.cmbShowName_SelectedValueChanged);
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
            this.btnAddCategory.Location = new System.Drawing.Point(139, 19);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 24);
            this.btnAddCategory.TabIndex = 3;
            this.Tooltips.SetToolTip(this.btnAddCategory, "Add new category.");
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(7, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(186, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
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
            // lstTags
            // 
            this.lstTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(0, 0);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(186, 65);
            this.lstTags.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tags";
            // 
            // btnAddNewTag
            // 
            this.btnAddNewTag.Image = global::WallChanger.Properties.Resources.plus_button;
            this.btnAddNewTag.Location = new System.Drawing.Point(101, 0);
            this.btnAddNewTag.Name = "btnAddNewTag";
            this.btnAddNewTag.Size = new System.Drawing.Size(24, 24);
            this.btnAddNewTag.TabIndex = 17;
            this.Tooltips.SetToolTip(this.btnAddNewTag, "Add new character.");
            this.btnAddNewTag.UseVisualStyleBackColor = true;
            this.btnAddNewTag.Click += new System.EventHandler(this.btnAddNewTag_Click);
            // 
            // btnClearTags
            // 
            this.btnClearTags.Image = global::WallChanger.Properties.Resources.cross_button;
            this.btnClearTags.Location = new System.Drawing.Point(162, 0);
            this.btnClearTags.Name = "btnClearTags";
            this.btnClearTags.Size = new System.Drawing.Size(24, 24);
            this.btnClearTags.TabIndex = 16;
            this.Tooltips.SetToolTip(this.btnClearTags, "Clear characters.");
            this.btnClearTags.UseVisualStyleBackColor = true;
            this.btnClearTags.Click += new System.EventHandler(this.btnClearTags_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Image = global::WallChanger.Properties.Resources.minus_button;
            this.btnRemoveTag.Location = new System.Drawing.Point(131, 0);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveTag.TabIndex = 15;
            this.Tooltips.SetToolTip(this.btnRemoveTag, "Remove character.");
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // pnlTagButtons
            // 
            this.pnlTagButtons.Controls.Add(this.label4);
            this.pnlTagButtons.Controls.Add(this.btnAddNewTag);
            this.pnlTagButtons.Controls.Add(this.btnRemoveTag);
            this.pnlTagButtons.Controls.Add(this.btnClearTags);
            this.pnlTagButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTagButtons.Location = new System.Drawing.Point(7, 0);
            this.pnlTagButtons.Name = "pnlTagButtons";
            this.pnlTagButtons.Size = new System.Drawing.Size(186, 30);
            this.pnlTagButtons.TabIndex = 18;
            this.pnlTagButtons.Resize += new System.EventHandler(this.pnlTagButtons_Resize);
            // 
            // pnlTagList
            // 
            this.pnlTagList.Controls.Add(this.lstTags);
            this.pnlTagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagList.Location = new System.Drawing.Point(7, 30);
            this.pnlTagList.Name = "pnlTagList";
            this.pnlTagList.Size = new System.Drawing.Size(186, 65);
            this.pnlTagList.TabIndex = 19;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 522);
            this.Controls.Add(this.spcContainer);
            this.MinimumSize = new System.Drawing.Size(0, 560);
            this.Name = "LibraryForm";
            this.Text = "LibraryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryForm_FormClosed);
            this.spcContainer.Panel1.ResumeLayout(false);
            this.spcContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).EndInit();
            this.spcContainer.ResumeLayout(false);
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlTagContainer.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.pnlTagButtons.ResumeLayout(false);
            this.pnlTagButtons.PerformLayout();
            this.pnlTagList.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlTagContainer;
        private System.Windows.Forms.Panel pnlDetails;
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
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Panel pnlTagList;
        private System.Windows.Forms.Panel pnlTagButtons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNewTag;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnClearTags;
    }
}