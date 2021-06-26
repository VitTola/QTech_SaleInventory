namespace QTech.Forms
{
    partial class frmSale
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
            this.txtPurchaseOrderNo = new System.Windows.Forms.TextBox();
            this.lblPurchaseOrderNo = new QTech.Component.ExLabel();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new QTech.Component.ExSearchComboColumn();
            this.colQauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeId = new QTech.Component.ExSearchComboColumn();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblInvoiceNo = new QTech.Component.ExLabel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblSite = new QTech.Component.ExLabel();
            this.lblCustomer = new QTech.Component.ExLabel();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblCurrency_ = new System.Windows.Forms.Label();
            this.lblTotal = new QTech.Component.ExLabel();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.cboSite = new QTech.Component.ExSearchCombo();
            this.lblPrintInvoice = new QTech.Component.Components.ExLinkLabel();
            this.container.SuspendLayout();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.lblPrintInvoice);
            this.container.Controls.Add(this.cboSite);
            this.container.Controls.Add(this.cboCustomer);
            this.container.Controls.Add(this.lblTotal);
            this.container.Controls.Add(this.panelTotal);
            this.container.Controls.Add(this.lblCustomer);
            this.container.Controls.Add(this.lblSite);
            this.container.Controls.Add(this.lblInvoiceNo);
            this.container.Controls.Add(this.txtInvoiceNo);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Controls.Add(this.lblPurchaseOrderNo);
            this.container.Controls.Add(this.txtPurchaseOrderNo);
            this.container.Size = new System.Drawing.Size(911, 603);
            // 
            // txtPurchaseOrderNo
            // 
            this.txtPurchaseOrderNo.Location = new System.Drawing.Point(679, 21);
            this.txtPurchaseOrderNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPurchaseOrderNo.Name = "txtPurchaseOrderNo";
            this.txtPurchaseOrderNo.Size = new System.Drawing.Size(200, 27);
            this.txtPurchaseOrderNo.TabIndex = 2;
            // 
            // lblPurchaseOrderNo
            // 
            this.lblPurchaseOrderNo.AutoSize = true;
            this.lblPurchaseOrderNo.Location = new System.Drawing.Point(560, 25);
            this.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo";
            this.lblPurchaseOrderNo.Required = true;
            this.lblPurchaseOrderNo.Size = new System.Drawing.Size(81, 19);
            this.lblPurchaseOrderNo.TabIndex = 5;
            this.lblPurchaseOrderNo.Text = "លេខបញ្ជាទិញ";
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(780, 85);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(99, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 3;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(67, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(29, 19);
            this.lblRemove.TabIndex = 1;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(30, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked_1);
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
            this.colId,
            this.colSaleId,
            this.colProductId,
            this.colQauntity,
            this.colUnitPrice,
            this.colTotal,
            this.colEmployeeId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgv.Size = new System.Drawing.Size(849, 392);
            this.dgv.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colSaleId
            // 
            this.colSaleId.HeaderText = "SaleId";
            this.colSaleId.Name = "colSaleId";
            this.colSaleId.ReadOnly = true;
            this.colSaleId.Visible = false;
            // 
            // colProductId
            // 
            this.colProductId.Choose = null;
            this.colProductId.CustomSearchForm = null;
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.DataSourceFn = null;
            this.colProductId.HeaderText = "ឈ្មោះទំនិញ";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductId.SearchParamFn = null;
            this.colProductId.ShowAll = false;
            this.colProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProductId.TextAll = null;
            this.colProductId.Width = 200;
            // 
            // colQauntity
            // 
            this.colQauntity.DataPropertyName = "Qauntity";
            this.colQauntity.HeaderText = "បរិមាណ";
            this.colQauntity.Name = "colQauntity";
            this.colQauntity.ReadOnly = true;
            this.colQauntity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "តម្ថៃឯកតា";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "សរុប";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 200;
            // 
            // colEmployeeId
            // 
            this.colEmployeeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmployeeId.Choose = null;
            this.colEmployeeId.CustomSearchForm = null;
            this.colEmployeeId.DataPropertyName = "EmployeeId";
            this.colEmployeeId.DataSourceFn = null;
            this.colEmployeeId.HeaderText = "អ្នកដឹក";
            this.colEmployeeId.Name = "colEmployeeId";
            this.colEmployeeId.ReadOnly = true;
            this.colEmployeeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEmployeeId.SearchParamFn = null;
            this.colEmployeeId.ShowAll = false;
            this.colEmployeeId.TextAll = null;
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.Location = new System.Drawing.Point(33, 85);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
            this.exLabel2.Size = new System.Drawing.Size(92, 19);
            this.exLabel2.TabIndex = 11;
            this.exLabel2.Text = "មុខទំនិញលម្អិត";
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 566);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(909, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(905, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(828, 3);
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
            this.btnSave.Location = new System.Drawing.Point(749, 3);
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
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(560, 58);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Required = true;
            this.lblInvoiceNo.Size = new System.Drawing.Size(80, 19);
            this.lblInvoiceNo.TabIndex = 19;
            this.lblInvoiceNo.Text = "លេខវិក្កយបត្រ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(679, 54);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(200, 27);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(30, 58);
            this.lblSite.Name = "lblSite";
            this.lblSite.Required = true;
            this.lblSite.Size = new System.Drawing.Size(76, 19);
            this.lblSite.TabIndex = 20;
            this.lblSite.Text = "ទៅកាន់គំរោង";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(30, 25);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Required = true;
            this.lblCustomer.Size = new System.Drawing.Size(52, 19);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "ក្រុមហ៊ុន";
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.Ivory;
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.txtTotal);
            this.panelTotal.Controls.Add(this.lblCurrency_);
            this.panelTotal.Location = new System.Drawing.Point(659, 513);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.panelTotal.Size = new System.Drawing.Size(220, 27);
            this.panelTotal.TabIndex = 23;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(0, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(215, 19);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCurrency_
            // 
            this.lblCurrency_.AutoSize = true;
            this.lblCurrency_.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrency_.Location = new System.Drawing.Point(215, 3);
            this.lblCurrency_.Name = "lblCurrency_";
            this.lblCurrency_.Size = new System.Drawing.Size(0, 19);
            this.lblCurrency_.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(560, 519);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Required = false;
            this.lblTotal.Size = new System.Drawing.Size(76, 19);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "សរុបទឹកប្រាក់";
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
            this.cboCustomer.Location = new System.Drawing.Point(149, 21);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(233, 27);
            this.cboCustomer.TabIndex = 25;
            this.cboCustomer.TextAll = "";
            // 
            // cboSite
            // 
            this.cboSite.Choose = "";
            this.cboSite.CustomSearchForm = null;
            this.cboSite.DataSourceFn = null;
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.FormattingEnabled = true;
            this.cboSite.IsGirdViewColumn = false;
            this.cboSite.LoadAll = true;
            this.cboSite.Location = new System.Drawing.Point(149, 54);
            this.cboSite.Name = "cboSite";
            this.cboSite.SearchParamFn = null;
            this.cboSite.SelectedItems = null;
            this.cboSite.SelectedObject = null;
            this.cboSite.ShowAll = false;
            this.cboSite.Size = new System.Drawing.Size(233, 27);
            this.cboSite.TabIndex = 27;
            this.cboSite.TextAll = "";
            // 
            // lblPrintInvoice
            // 
            this.lblPrintInvoice.AutoSize = true;
            this.lblPrintInvoice.Location = new System.Drawing.Point(30, 513);
            this.lblPrintInvoice.Name = "lblPrintInvoice";
            this.lblPrintInvoice.RightSpace = 10;
            this.lblPrintInvoice.ShortcutText = "";
            this.lblPrintInvoice.ShowShortcutText = false;
            this.lblPrintInvoice.Size = new System.Drawing.Size(94, 19);
            this.lblPrintInvoice.TabIndex = 28;
            this.lblPrintInvoice.TabStop = true;
            this.lblPrintInvoice.Text = "បោះពុម្ភវិក័យប័ត្រ";
            this.lblPrintInvoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPrintInvoice_LinkClicked);
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 624);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "frmSale";
            this.Text = "frmEmployeePay";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private Component.ExLabel lblPurchaseOrderNo;
        private Component.ExLabel exLabel2;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private Component.ExLabel lblCustomer;
        private Component.ExLabel lblSite;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCurrency_;
        private Component.ExLabel lblTotal;
        private Component.ExSearchCombo cboCustomer;
        private Component.ExSearchCombo cboSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleId;
        private Component.ExSearchComboColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private Component.ExSearchComboColumn colEmployeeId;
        private Component.Components.ExLinkLabel lblPrintInvoice;
    }
}