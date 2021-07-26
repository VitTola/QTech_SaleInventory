namespace QTech.Forms
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPurchaseOrderNo = new System.Windows.Forms.TextBox();
            this.lblPurchaseOrderNo = new QTech.Component.ExLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeftQauntity_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblCustomer = new QTech.Component.ExLabel();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.lblNote = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.cboCustomer);
            this.container.Controls.Add(this.lblCustomer);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.lblPurchaseOrderNo);
            this.container.Controls.Add(this.txtPurchaseOrderNo);
            this.container.Size = new System.Drawing.Size(858, 564);
            // 
            // txtPurchaseOrderNo
            // 
            this.txtPurchaseOrderNo.Location = new System.Drawing.Point(149, 22);
            this.txtPurchaseOrderNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPurchaseOrderNo.Name = "txtPurchaseOrderNo";
            this.txtPurchaseOrderNo.Size = new System.Drawing.Size(200, 27);
            this.txtPurchaseOrderNo.TabIndex = 0;
            // 
            // lblPurchaseOrderNo
            // 
            this.lblPurchaseOrderNo.AutoSize = true;
            this.lblPurchaseOrderNo.Location = new System.Drawing.Point(30, 26);
            this.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo";
            this.lblPurchaseOrderNo.Required = true;
            this.lblPurchaseOrderNo.Size = new System.Drawing.Size(81, 19);
            this.lblPurchaseOrderNo.TabIndex = 5;
            this.lblPurchaseOrderNo.Text = "លេខបញ្ជាទិញ";
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProductId_,
            this.colProductId,
            this.colCategory_,
            this.colQauntity,
            this.colLeftQauntity_,
            this.colUnitPrice_,
            this.colNote});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.dgv.Location = new System.Drawing.Point(30, 110);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(797, 392);
            this.dgv.TabIndex = 3;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colProductId_
            // 
            this.colProductId_.HeaderText = "colProductId_";
            this.colProductId_.Name = "colProductId_";
            this.colProductId_.ReadOnly = true;
            this.colProductId_.Visible = false;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ឈ្មោះទំនិញ";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductId.Width = 150;
            // 
            // colCategory_
            // 
            this.colCategory_.DataPropertyName = "Category";
            this.colCategory_.HeaderText = "ប្រភេទ";
            this.colCategory_.Name = "colCategory_";
            this.colCategory_.ReadOnly = true;
            // 
            // colQauntity
            // 
            this.colQauntity.DataPropertyName = "Qauntity";
            this.colQauntity.HeaderText = "បរិមាណ";
            this.colQauntity.Name = "colQauntity";
            this.colQauntity.ReadOnly = true;
            this.colQauntity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colLeftQauntity_
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Green;
            this.colLeftQauntity_.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLeftQauntity_.HeaderText = "បរិមាណនៅសល់";
            this.colLeftQauntity_.Name = "colLeftQauntity_";
            this.colLeftQauntity_.ReadOnly = true;
            // 
            // colUnitPrice_
            // 
            this.colUnitPrice_.DataPropertyName = "UnitPrice";
            this.colUnitPrice_.HeaderText = "តម្ថៃឯកតា(USD)";
            this.colUnitPrice_.Name = "colUnitPrice_";
            this.colUnitPrice_.ReadOnly = true;
            this.colUnitPrice_.Width = 150;
            // 
            // colNote
            // 
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.DataPropertyName = "Note";
            this.colNote.HeaderText = "ចំណាំ";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.exLabel2.Location = new System.Drawing.Point(33, 85);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = true;
            this.exLabel2.Size = new System.Drawing.Size(92, 19);
            this.exLabel2.TabIndex = 11;
            this.exLabel2.Text = "មុខទំនិញលម្អិត";
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 527);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(856, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(391, 32);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(399, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(455, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(378, 3);
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
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Location = new System.Drawing.Point(299, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(30, 58);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Required = true;
            this.lblCustomer.Size = new System.Drawing.Size(52, 19);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "ក្រុមហ៊ុន";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Choose = "";
            this.cboCustomer.CustomSearchForm = null;
            this.cboCustomer.DataSourceFn = null;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.IsGirdViewColumn = false;
            this.cboCustomer.LoadAll = true;
            this.cboCustomer.Location = new System.Drawing.Point(149, 54);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(200, 27);
            this.cboCustomer.TabIndex = 1;
            this.cboCustomer.TextAll = "";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(508, 22);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(41, 19);
            this.lblNote.TabIndex = 27;
            this.lblNote.Text = "ចំណាំ";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(627, 18);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 63);
            this.txtNote.TabIndex = 2;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 584);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "frmPurchaseOrder";
            this.Text = "frmPurchaseOrder";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtPurchaseOrderNo;
        private Component.ExDataGridView dgv;
        private Component.ExLabel lblPurchaseOrderNo;
        private Component.ExLabel exLabel2;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblCustomer;
        private Component.ExSearchCombo cboCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeftQauntity_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}