namespace QTech.Forms
{
    partial class frmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.lblCompany_ = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new QTech.Component.ExLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnAdd = new QTech.Component.ExButtonLoading();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.exLabel3);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.lblPhone);
            this.container.Controls.Add(this.txtPhone);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Controls.Add(this.lblCompany_);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(375, 399);
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.Location = new System.Drawing.Point(26, 132);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
            this.exLabel2.Size = new System.Drawing.Size(44, 19);
            this.exLabel2.TabIndex = 16;
            this.exLabel2.Text = "គំរោង";
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSite,
            this.colPhone});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(28, 154);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(315, 184);
            this.dgv.TabIndex = 14;
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(210, 132);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(133, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 13;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(101, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(29, 19);
            this.lblRemove.TabIndex = 0;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(64, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // lblCompany_
            // 
            this.lblCompany_.AutoSize = true;
            this.lblCompany_.Location = new System.Drawing.Point(24, 24);
            this.lblCompany_.Name = "lblCompany_";
            this.lblCompany_.Required = true;
            this.lblCompany_.Size = new System.Drawing.Size(83, 19);
            this.lblCompany_.TabIndex = 15;
            this.lblCompany_.Text = "ឈ្មោះក្រុមហ៊ុន";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 12;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(24, 55);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Required = false;
            this.lblPhone.Size = new System.Drawing.Size(68, 19);
            this.lblPhone.TabIndex = 22;
            this.lblPhone.Text = "លេខទូរស័ព្ទ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(143, 52);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            this.txtPhone.TabIndex = 21;
            // 
            // exLabel3
            // 
            this.exLabel3.AutoSize = true;
            this.exLabel3.Location = new System.Drawing.Point(24, 86);
            this.exLabel3.Name = "exLabel3";
            this.exLabel3.Required = false;
            this.exLabel3.Size = new System.Drawing.Size(41, 19);
            this.exLabel3.TabIndex = 24;
            this.exLabel3.Text = "ចំណាំ";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(143, 83);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 46);
            this.txtNote.TabIndex = 23;
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 362);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(373, 36);
            this.exPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnAdd);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(369, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(292, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DefaultImage = null;
            this.btnAdd.Executing = false;
            this.btnAdd.Location = new System.Drawing.Point(213, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnAdd.ShortcutText = null;
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "រក្សាទុក";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colSite
            // 
            this.colSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSite.HeaderText = "ឈ្មោះគំរោង";
            this.colSite.Name = "colSite";
            this.colSite.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "លេខទូរស័ព្ទ";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 150;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 420);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCustomer";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Component.ExLabel exLabel2;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private Component.ExLabel lblCompany_;
        private System.Windows.Forms.TextBox txtName;
        private Component.ExLabel lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private Component.ExLabel exLabel3;
        private System.Windows.Forms.TextBox txtNote;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    }
}