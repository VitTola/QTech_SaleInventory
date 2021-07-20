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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
            this.lblPurchaseOrderNo = new QTech.Component.ExLabel();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new QTech.Component.ExSearchComboColumn();
            this.colQauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeftQty_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeId = new QTech.Component.ExSearchComboColumn();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblInvoiceNo = new QTech.Component.ExLabel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblSite = new QTech.Component.ExLabel();
            this.lblCustomer = new QTech.Component.ExLabel();
            this.lblTotalAmount = new QTech.Component.ExLabel();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.cboSite = new QTech.Component.ExSearchCombo();
            this.pnlExpect = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblCur2 = new System.Windows.Forms.Label();
            this.cboPurchaseOrderNo = new QTech.Component.ExSearchCombo();
            this.lblExpense_ = new QTech.Component.ExLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabCompany_ = new System.Windows.Forms.TabPage();
            this.tabGeneral_ = new System.Windows.Forms.TabPage();
            this.lblPhone = new QTech.Component.ExLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo1 = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo1 = new QTech.Component.ExLabel();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer1 = new QTech.Component.ExLabel();
            this.container.SuspendLayout();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlExpect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabCompany_.SuspendLayout();
            this.tabGeneral_.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.tabMain);
            this.container.Controls.Add(this.panel1);
            this.container.Controls.Add(this.lblExpense_);
            this.container.Controls.Add(this.pnlExpect);
            this.container.Controls.Add(this.lblTotalAmount);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Size = new System.Drawing.Size(910, 646);
            // 
            // lblPurchaseOrderNo
            // 
            this.lblPurchaseOrderNo.AutoSize = true;
            this.lblPurchaseOrderNo.Location = new System.Drawing.Point(552, 23);
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
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(780, 128);
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
            this.colImportPrice,
            this.colSaleId,
            this.colProductId,
            this.colQauntity,
            this.colLeftQty_,
            this.colUnitPrice,
            this.colTotal,
            this.colEmployeeId});
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
            this.dgv.Location = new System.Drawing.Point(30, 154);
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
            // colImportPrice
            // 
            this.colImportPrice.HeaderText = "ImportPrice";
            this.colImportPrice.Name = "colImportPrice";
            this.colImportPrice.ReadOnly = true;
            this.colImportPrice.Visible = false;
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
            // colLeftQty_
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Green;
            this.colLeftQty_.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLeftQty_.HeaderText = "បរិមាននៅសល់ក្នុង PO";
            this.colLeftQty_.Name = "colLeftQty_";
            this.colLeftQty_.ReadOnly = true;
            this.colLeftQty_.Width = 150;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "តម្ថៃឯកតា";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "សរុប";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
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
            this.exLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.exLabel2.Location = new System.Drawing.Point(27, 128);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
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
            this.exPanel1.Location = new System.Drawing.Point(1, 609);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(908, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnPrint);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(279, 32);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Ivory;
            this.btnPrint.DefaultImage = null;
            this.btnPrint.Executing = false;
            this.btnPrint.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(2, 3);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnPrint.ShortcutText = "P";
            this.btnPrint.Size = new System.Drawing.Size(89, 27);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(451, 2);
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
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(552, 56);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Required = true;
            this.lblInvoiceNo.Size = new System.Drawing.Size(80, 19);
            this.lblInvoiceNo.TabIndex = 19;
            this.lblInvoiceNo.Text = "លេខវិក្កយបត្រ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(671, 52);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(200, 27);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(27, 56);
            this.lblSite.Name = "lblSite";
            this.lblSite.Required = true;
            this.lblSite.Size = new System.Drawing.Size(76, 19);
            this.lblSite.TabIndex = 20;
            this.lblSite.Text = "ទៅកាន់គំរោង";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(27, 23);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Required = true;
            this.lblCustomer.Size = new System.Drawing.Size(52, 19);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "ក្រុមហ៊ុន";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(562, 564);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Required = false;
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 19);
            this.lblTotalAmount.TabIndex = 24;
            this.lblTotalAmount.Text = "សរុបទឹកប្រាក់";
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
            this.cboCustomer.Location = new System.Drawing.Point(146, 19);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(200, 27);
            this.cboCustomer.TabIndex = 0;
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
            this.cboSite.Location = new System.Drawing.Point(146, 52);
            this.cboSite.Name = "cboSite";
            this.cboSite.SearchParamFn = null;
            this.cboSite.SelectedItems = null;
            this.cboSite.SelectedObject = null;
            this.cboSite.ShowAll = false;
            this.cboSite.Size = new System.Drawing.Size(200, 27);
            this.cboSite.TabIndex = 1;
            this.cboSite.TextAll = "";
            // 
            // pnlExpect
            // 
            this.pnlExpect.BackColor = System.Drawing.SystemColors.Control;
            this.pnlExpect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpect.Controls.Add(this.txtTotal);
            this.pnlExpect.Controls.Add(this.lblCur2);
            this.pnlExpect.Location = new System.Drawing.Point(681, 560);
            this.pnlExpect.Margin = new System.Windows.Forms.Padding(2);
            this.pnlExpect.Name = "pnlExpect";
            this.pnlExpect.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlExpect.Size = new System.Drawing.Size(200, 27);
            this.pnlExpect.TabIndex = 29;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(0, 2);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(165, 19);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCur2
            // 
            this.lblCur2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCur2.Location = new System.Drawing.Point(165, 2);
            this.lblCur2.Name = "lblCur2";
            this.lblCur2.Size = new System.Drawing.Size(33, 23);
            this.lblCur2.TabIndex = 1;
            this.lblCur2.Text = "USD";
            this.lblCur2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboPurchaseOrderNo
            // 
            this.cboPurchaseOrderNo.Choose = "";
            this.cboPurchaseOrderNo.CustomSearchForm = null;
            this.cboPurchaseOrderNo.DataSourceFn = null;
            this.cboPurchaseOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurchaseOrderNo.FormattingEnabled = true;
            this.cboPurchaseOrderNo.IsGirdViewColumn = false;
            this.cboPurchaseOrderNo.LoadAll = true;
            this.cboPurchaseOrderNo.Location = new System.Drawing.Point(671, 19);
            this.cboPurchaseOrderNo.Name = "cboPurchaseOrderNo";
            this.cboPurchaseOrderNo.SearchParamFn = null;
            this.cboPurchaseOrderNo.SelectedItems = null;
            this.cboPurchaseOrderNo.SelectedObject = null;
            this.cboPurchaseOrderNo.ShowAll = false;
            this.cboPurchaseOrderNo.Size = new System.Drawing.Size(200, 27);
            this.cboPurchaseOrderNo.TabIndex = 2;
            this.cboPurchaseOrderNo.TextAll = "";
            // 
            // lblExpense_
            // 
            this.lblExpense_.AutoSize = true;
            this.lblExpense_.Location = new System.Drawing.Point(27, 564);
            this.lblExpense_.Name = "lblExpense_";
            this.lblExpense_.Required = false;
            this.lblExpense_.Size = new System.Drawing.Size(85, 19);
            this.lblExpense_.TabIndex = 31;
            this.lblExpense_.Text = "ចំណាយផ្សេងៗ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtExpense);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(146, 560);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 30;
            // 
            // txtExpense
            // 
            this.txtExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpense.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpense.Location = new System.Drawing.Point(0, 2);
            this.txtExpense.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Size = new System.Drawing.Size(165, 19);
            this.txtExpense.TabIndex = 0;
            this.txtExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(165, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "USD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCompany_);
            this.tabMain.Controls.Add(this.tabGeneral_);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(908, 124);
            this.tabMain.TabIndex = 32;
            // 
            // tabCompany_
            // 
            this.tabCompany_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabCompany_.Controls.Add(this.cboCustomer);
            this.tabCompany_.Controls.Add(this.lblPurchaseOrderNo);
            this.tabCompany_.Controls.Add(this.txtInvoiceNo);
            this.tabCompany_.Controls.Add(this.cboPurchaseOrderNo);
            this.tabCompany_.Controls.Add(this.lblInvoiceNo);
            this.tabCompany_.Controls.Add(this.lblSite);
            this.tabCompany_.Controls.Add(this.cboSite);
            this.tabCompany_.Controls.Add(this.lblCustomer);
            this.tabCompany_.Location = new System.Drawing.Point(4, 28);
            this.tabCompany_.Name = "tabCompany_";
            this.tabCompany_.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany_.Size = new System.Drawing.Size(900, 92);
            this.tabCompany_.TabIndex = 0;
            this.tabCompany_.Text = "លក់សម្រាប់ក្រុមហ៊ុន";
            // 
            // tabGeneral_
            // 
            this.tabGeneral_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabGeneral_.Controls.Add(this.lblPhone);
            this.tabGeneral_.Controls.Add(this.txtPhone);
            this.tabGeneral_.Controls.Add(this.txtInvoiceNo1);
            this.tabGeneral_.Controls.Add(this.lblInvoiceNo1);
            this.tabGeneral_.Controls.Add(this.txtCustomer);
            this.tabGeneral_.Controls.Add(this.lblCustomer1);
            this.tabGeneral_.Location = new System.Drawing.Point(4, 28);
            this.tabGeneral_.Name = "tabGeneral_";
            this.tabGeneral_.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral_.Size = new System.Drawing.Size(900, 92);
            this.tabGeneral_.TabIndex = 1;
            this.tabGeneral_.Text = "លក់ទូទៅ";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(557, 21);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Required = true;
            this.lblPhone.Size = new System.Drawing.Size(64, 19);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "លេខទូស័ព្ទ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(671, 18);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            this.txtPhone.TabIndex = 24;
            // 
            // txtInvoiceNo1
            // 
            this.txtInvoiceNo1.Location = new System.Drawing.Point(141, 49);
            this.txtInvoiceNo1.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo1.Name = "txtInvoiceNo1";
            this.txtInvoiceNo1.Size = new System.Drawing.Size(200, 27);
            this.txtInvoiceNo1.TabIndex = 22;
            // 
            // lblInvoiceNo1
            // 
            this.lblInvoiceNo1.AutoSize = true;
            this.lblInvoiceNo1.Location = new System.Drawing.Point(22, 53);
            this.lblInvoiceNo1.Name = "lblInvoiceNo1";
            this.lblInvoiceNo1.Required = true;
            this.lblInvoiceNo1.Size = new System.Drawing.Size(80, 19);
            this.lblInvoiceNo1.TabIndex = 23;
            this.lblInvoiceNo1.Text = "លេខវិក្កយបត្រ";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(142, 18);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(200, 27);
            this.txtCustomer.TabIndex = 20;
            // 
            // lblCustomer1
            // 
            this.lblCustomer1.AutoSize = true;
            this.lblCustomer1.Location = new System.Drawing.Point(23, 22);
            this.lblCustomer1.Name = "lblCustomer1";
            this.lblCustomer1.Required = true;
            this.lblCustomer1.Size = new System.Drawing.Size(83, 19);
            this.lblCustomer1.TabIndex = 21;
            this.lblCustomer1.Text = "ឈ្មោះអតិថិជន";
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 666);
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
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlExpect.ResumeLayout(false);
            this.pnlExpect.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabCompany_.ResumeLayout(false);
            this.tabCompany_.PerformLayout();
            this.tabGeneral_.ResumeLayout(false);
            this.tabGeneral_.PerformLayout();
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
        private Component.ExLabel lblTotalAmount;
        private Component.ExSearchCombo cboCustomer;
        private Component.ExSearchCombo cboSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Panel pnlExpect;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCur2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnPrint;
        private Component.ExSearchCombo cboPurchaseOrderNo;
        private Component.ExLabel lblExpense_;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtExpense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabCompany_;
        private System.Windows.Forms.TabPage tabGeneral_;
        private System.Windows.Forms.TextBox txtInvoiceNo1;
        private Component.ExLabel lblInvoiceNo1;
        private System.Windows.Forms.TextBox txtCustomer;
        private Component.ExLabel lblCustomer1;
        private System.Windows.Forms.TextBox txtPhone;
        private Component.ExLabel lblPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleId;
        private Component.ExSearchComboColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeftQty_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private Component.ExSearchComboColumn colEmployeeId;
    }
}