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
            this.lstDuplicates = new System.Windows.Forms.ListBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnKeep = new System.Windows.Forms.Button();
            this.lblImageSize = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lstDuplicateImages = new System.Windows.Forms.ListBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
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
            this.lstDuplicates.Location = new System.Drawing.Point(0, 0);
            this.lstDuplicates.Name = "lstDuplicates";
            this.lstDuplicates.Size = new System.Drawing.Size(186, 534);
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
            this.pnlRight.Size = new System.Drawing.Size(593, 534);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlControls);
            this.pnlDetails.Controls.Add(this.picPreview);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(186, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(407, 534);
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
            this.pnlControls.Location = new System.Drawing.Point(0, 476);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(407, 58);
            this.pnlControls.TabIndex = 5;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(313, 29);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 6;
            this.btnAuto.Text = "DUPE_BUTTON_AUTO";
            this.ToolTips.SetToolTip(this.btnAuto, "Automatically resolves duplicates.");
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnKeep
            // 
            this.btnKeep.Location = new System.Drawing.Point(70, 29);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(75, 23);
            this.btnKeep.TabIndex = 5;
            this.btnKeep.Text = "DUPE_BUTTON_KEEP";
            this.btnKeep.UseVisualStyleBackColor = true;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // lblImageSize
            // 
            this.lblImageSize.AutoSize = true;
            this.lblImageSize.Location = new System.Drawing.Point(52, 0);
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Size = new System.Drawing.Size(146, 13);
            this.lblImageSize.TabIndex = 1;
            this.lblImageSize.Text = "DUPE_LABEL_IMAGE_SIZE";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "DUPE_BUTTON_DELETE";
            this.ToolTips.SetToolTip(this.btnDelete, "Delete from disk.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(66, 13);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(133, 13);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "DUPE_LABEL_FILEPATH";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(151, 29);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "DUPE_BUTTON_REMOVE";
            this.ToolTips.SetToolTip(this.btnRemove, "Remove from library.");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(407, 476);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // lstDuplicateImages
            // 
            this.lstDuplicateImages.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstDuplicateImages.FormattingEnabled = true;
            this.lstDuplicateImages.HorizontalScrollbar = true;
            this.lstDuplicateImages.Location = new System.Drawing.Point(0, 0);
            this.lstDuplicateImages.Name = "lstDuplicateImages";
            this.lstDuplicateImages.Size = new System.Drawing.Size(186, 534);
            this.lstDuplicateImages.TabIndex = 0;
            this.lstDuplicateImages.SelectedValueChanged += new System.EventHandler(this.lstDuplicateImages_SelectedValueChanged);
            // 
            // DuplicateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 534);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.lstDuplicates);
            this.Name = "DuplicateForm";
            this.Text = "DuplicateForm";
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
        private System.Windows.Forms.Label lblImageSize;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.Button btnAuto;
    }
}