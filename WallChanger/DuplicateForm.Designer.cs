namespace WallChanger
{
    partial class DuplicateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateForm));
            this.lstDuplicates = new System.Windows.Forms.ListBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnAuto = new WallChanger.Translation.Controls.TranslatableButton();
            this.btnKeep = new WallChanger.Translation.Controls.TranslatableButton();
            this.lblImageSize = new WallChanger.Translation.Controls.TranslatableLabelFormat();
            this.btnDelete = new WallChanger.Translation.Controls.TranslatableButton();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnRemove = new WallChanger.Translation.Controls.TranslatableButton();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lstDuplicateImages = new System.Windows.Forms.ListBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.DuplicateTitle = new WallChanger.Translation.Controls.TranslatableTitle();
            this.trtToolTips = new WallChanger.Translation.Controls.TranslatableTooltips();
            this.pnlRight.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lstDuplicates
            // 
            this.lstDuplicates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstDuplicates.FormattingEnabled = true;
            this.lstDuplicates.ItemHeight = 12;
            this.lstDuplicates.Location = new System.Drawing.Point(0, 0);
            this.lstDuplicates.Name = "lstDuplicates";
            this.lstDuplicates.Size = new System.Drawing.Size(186, 493);
            this.lstDuplicates.TabIndex = 0;
            this.lstDuplicates.SelectedValueChanged += new System.EventHandler(this.lstDuplicates_SelectedValueChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlDetails);
            this.pnlRight.Controls.Add(this.lstDuplicateImages);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(186, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(593, 493);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlControls);
            this.pnlDetails.Controls.Add(this.picPreview);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(186, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(407, 493);
            this.pnlDetails.TabIndex = 1;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnAuto);
            this.pnlControls.Controls.Add(this.btnKeep);
            this.pnlControls.Controls.Add(this.lblImageSize);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.lblFilePath);
            this.pnlControls.Controls.Add(this.btnRemove);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 439);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(407, 54);
            this.pnlControls.TabIndex = 5;
            // 
            // btnAuto
            // 
            this.btnAuto.DefaultString = null;
            this.btnAuto.Location = new System.Drawing.Point(313, 27);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 21);
            this.btnAuto.TabIndex = 6;
            this.btnAuto.Text = "DUPE.BUTTON.AUTO";
            this.ToolTips.SetToolTip(this.btnAuto, "Automatically resolves duplicates.");
            this.btnAuto.TranslationString = "DUPE.BUTTON.AUTO";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnKeep
            // 
            this.btnKeep.DefaultString = null;
            this.btnKeep.Location = new System.Drawing.Point(70, 27);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(75, 21);
            this.btnKeep.TabIndex = 5;
            this.btnKeep.Text = "DUPE.BUTTON.KEEP";
            this.btnKeep.TranslationString = "DUPE.BUTTON.KEEP";
            this.btnKeep.UseVisualStyleBackColor = true;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // lblImageSize
            // 
            this.lblImageSize.AutoSize = true;
            this.lblImageSize.DefaultString = "DUPE.LABEL.IMAGE_SIZE {0}x{1}px";
            this.lblImageSize.Location = new System.Drawing.Point(52, 0);
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Parameters = new object[0];
            this.lblImageSize.Size = new System.Drawing.Size(137, 12);
            this.lblImageSize.TabIndex = 1;
            this.lblImageSize.Text = "DUPE.LABEL.IMAGE_SIZE";
            this.lblImageSize.TranslationString = "DUPE.LABEL.IMAGE_SIZE";
            // 
            // btnDelete
            // 
            this.btnDelete.DefaultString = null;
            this.btnDelete.Location = new System.Drawing.Point(232, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 21);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "DUPE.BUTTON.DELETE";
            this.ToolTips.SetToolTip(this.btnDelete, "Delete from disk.");
            this.btnDelete.TranslationString = "DUPE.BUTTON.DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(66, 12);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(127, 12);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "DUPE.LABEL.FILEPATH";
            // 
            // btnRemove
            // 
            this.btnRemove.DefaultString = null;
            this.btnRemove.Location = new System.Drawing.Point(151, 27);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 21);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "DUPE.BUTTON.REMOVE";
            this.ToolTips.SetToolTip(this.btnRemove, "Remove from library.");
            this.btnRemove.TranslationString = "DUPE.BUTTON.REMOVE";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(407, 439);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // lstDuplicateImages
            // 
            this.lstDuplicateImages.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstDuplicateImages.FormattingEnabled = true;
            this.lstDuplicateImages.HorizontalScrollbar = true;
            this.lstDuplicateImages.ItemHeight = 12;
            this.lstDuplicateImages.Location = new System.Drawing.Point(0, 0);
            this.lstDuplicateImages.Name = "lstDuplicateImages";
            this.lstDuplicateImages.Size = new System.Drawing.Size(186, 493);
            this.lstDuplicateImages.TabIndex = 0;
            this.lstDuplicateImages.SelectedValueChanged += new System.EventHandler(this.lstDuplicateImages_SelectedValueChanged);
            // 
            // DuplicateTitle
            // 
            this.DuplicateTitle.DefaultString = "Duplicate Viewer";
            this.DuplicateTitle.ParentForm = this;
            this.DuplicateTitle.TranslationString = "TITLE.DUPLICATE";
            // 
            // trtToolTips
            // 
            this.trtToolTips.DefaultStrings = ((System.Collections.Generic.Dictionary<System.Windows.Forms.Control, string>)(resources.GetObject("trtToolTips.DefaultStrings")));
            this.trtToolTips.ToolTips = this.ToolTips;
            this.trtToolTips.TranslationStrings = ((System.Collections.Generic.Dictionary<System.Windows.Forms.Control, string>)(resources.GetObject("trtToolTips.TranslationStrings")));
            // 
            // DuplicateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 493);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.lstDuplicates);
            this.Name = "DuplicateForm";
            this.Text = "TITLE.DUPLICATE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DuplicateForm_FormClosed);
            this.Resize += new System.EventHandler(this.DuplicateForm_Resize);
            this.pnlRight.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDuplicates;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListBox lstDuplicateImages;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.PictureBox picPreview;
        private WallChanger.Translation.Controls.TranslatableLabelFormat lblImageSize;
        private System.Windows.Forms.Label lblFilePath;
        private WallChanger.Translation.Controls.TranslatableButton btnDelete;
        private System.Windows.Forms.ToolTip ToolTips;
        private WallChanger.Translation.Controls.TranslatableButton btnRemove;
        private System.Windows.Forms.Panel pnlControls;
        private WallChanger.Translation.Controls.TranslatableButton btnKeep;
        private WallChanger.Translation.Controls.TranslatableButton btnAuto;
        private Translation.Controls.TranslatableTitle DuplicateTitle;
        private Translation.Controls.TranslatableTooltips trtToolTips;
    }
}