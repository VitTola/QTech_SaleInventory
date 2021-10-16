namespace QTech.Component
{
    partial class AddAttachmentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAttachmentDialog));
            this._lblAttachmentName = new QTech.Component.ExLabel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this._lblAttachementType = new QTech.Component.ExLabel();
            this.cboAttachmentType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._lblFilePath = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.flowLayoutPanel2);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.groupBox1);
            this.container.Controls.Add(this.cboAttachmentType);
            this.container.Controls.Add(this._lblAttachementType);
            this.container.Controls.Add(this.txtFileName);
            this.container.Controls.Add(this._lblAttachmentName);
            this.container.Size = new System.Drawing.Size(365, 240);
            this.container.Text = "container";
            // 
            // _lblAttachmentName
            // 
            this._lblAttachmentName.AutoSize = true;
            this._lblAttachmentName.Location = new System.Drawing.Point(19, 29);
            this._lblAttachmentName.Name = "_lblAttachmentName";
            this._lblAttachmentName.Required = true;
            this._lblAttachmentName.Size = new System.Drawing.Size(71, 19);
            this._lblAttachmentName.TabIndex = 0;
            this._lblAttachmentName.Text = "ឈ្មោះឯកសារ";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(138, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(200, 28);
            this.txtFileName.TabIndex = 0;
            // 
            // _lblAttachementType
            // 
            this._lblAttachementType.AutoSize = true;
            this._lblAttachementType.Location = new System.Drawing.Point(19, 60);
            this._lblAttachementType.Name = "_lblAttachementType";
            this._lblAttachementType.Required = true;
            this._lblAttachementType.Size = new System.Drawing.Size(75, 19);
            this._lblAttachementType.TabIndex = 2;
            this._lblAttachementType.Text = "ប្រភេទឯកសារ";
            // 
            // cboAttachmentType
            // 
            this.cboAttachmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttachmentType.FormattingEnabled = true;
            this.cboAttachmentType.Location = new System.Drawing.Point(138, 56);
            this.cboAttachmentType.Name = "cboAttachmentType";
            this.cboAttachmentType.Size = new System.Drawing.Size(200, 27);
            this.cboAttachmentType.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(1, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(363, 46);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnSave.Location = new System.Drawing.Point(181, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = "S";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnClose.Location = new System.Drawing.Point(285, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(138, 87);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 75);
            this.txtNote.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(19, 90);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(73, 19);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "កំណត់សំគាល់";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this._lblFilePath);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(23, 167);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(314, 22);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // _lblFilePath
            // 
            this._lblFilePath.AutoEllipsis = true;
            this._lblFilePath.AutoSize = true;
            this._lblFilePath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._lblFilePath.Location = new System.Drawing.Point(276, 1);
            this._lblFilePath.Margin = new System.Windows.Forms.Padding(0);
            this._lblFilePath.Name = "_lblFilePath";
            this._lblFilePath.Size = new System.Drawing.Size(36, 19);
            this._lblFilePath.TabIndex = 0;
            this._lblFilePath.Text = "label1";
            this._lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddAttachmentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 260);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAttachmentDialog";
            this.Text = "AddAttachmentDialog";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Component.ExLabel _lblAttachmentName;
        private Component.ExLabel _lblAttachementType;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cboAttachmentType;
        private System.Windows.Forms.GroupBox groupBox1;
        private ExButtonLoading btnSave;
        private ExButtonLoading btnClose;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label _lblFilePath;
    }
}