namespace QTech.Forms
{
    partial class frmCreateInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblInvoiceNo = new QTech.Component.ExLabel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblCustomer = new QTech.Component.ExLabel();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.chkMarkAll_ = new System.Windows.Forms.CheckBox();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colMark_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flowLayoutPanelTopGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpSearchDate = new QTech.Component.ExReportDatePicker();
            this.lblInvoicingDate = new QTech.Component.ExLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtLeftAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exLabel4 = new QTech.Component.ExLabel();
            this.exLabel5 = new QTech.Component.ExLabel();
            this.exLabel6 = new QTech.Component.ExLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpInvoicingDate = new QTech.Component.ExDateTimePicker();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flowLayoutPanelTopGrid.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.panelGrid);
            this.container.Controls.Add(this.panel4);
            this.container.Controls.Add(this.panel3);
            this.container.Controls.Add(this.exPanel1);
            this.container.Size = new System.Drawing.Size(1277, 668);
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.exLabel2.Location = new System.Drawing.Point(12, 57);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
            this.exLabel2.Size = new System.Drawing.Size(114, 27);
            this.exLabel2.TabIndex = 11;
            this.exLabel2.Text = "ជ្រើសរើសការលក់";
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 631);
            this.exPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Size = new System.Drawing.Size(1275, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.flowLayoutPanel3.Controls.Add(this.btnPrint);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(279, 36);
            this.flowLayoutPanel3.TabIndex = 2;
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
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1275, 36);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(1198, 3);
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
            this.btnSave.Location = new System.Drawing.Point(1119, 3);
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
            this.lblInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(503, 23);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Required = true;
            this.lblInvoiceNo.Size = new System.Drawing.Size(86, 27);
            this.lblInvoiceNo.TabIndex = 19;
            this.lblInvoiceNo.Text = "លេខវិក្កយបត្រ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(622, 19);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(200, 34);
            this.txtInvoiceNo.TabIndex = 3;
            this.txtInvoiceNo.Text = "លេខវិក័យប័ត្រថ្មី";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(12, 23);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Required = true;
            this.lblCustomer.Size = new System.Drawing.Size(56, 27);
            this.lblCustomer.TabIndex = 22;
            this.lblCustomer.Text = "ក្រុមហ៊ុន";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Choose = "";
            this.cboCustomer.CustomSearchForm = null;
            this.cboCustomer.DataSourceFn = null;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.IsGirdViewColumn = false;
            this.cboCustomer.LoadAll = true;
            this.cboCustomer.Location = new System.Drawing.Point(137, 19);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(200, 35);
            this.cboCustomer.TabIndex = 25;
            this.cboCustomer.TextAll = "";
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.Gray;
            this.panelGrid.Controls.Add(this.chkMarkAll_);
            this.panelGrid.Controls.Add(this.pnlGrid);
            this.panelGrid.Controls.Add(this.flowLayoutPanelTopGrid);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(1, 86);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1275, 432);
            this.panelGrid.TabIndex = 30;
            // 
            // chkMarkAll_
            // 
            this.chkMarkAll_.AutoSize = true;
            this.chkMarkAll_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.chkMarkAll_.Location = new System.Drawing.Point(14, 49);
            this.chkMarkAll_.Name = "chkMarkAll_";
            this.chkMarkAll_.Size = new System.Drawing.Size(15, 14);
            this.chkMarkAll_.TabIndex = 15;
            this.chkMarkAll_.UseVisualStyleBackColor = false;
            this.chkMarkAll_.Click += new System.EventHandler(this.chkMarkAll__Click);
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMark_,
            this.colId,
            this.colPurchaseOrderNo,
            this.colInvoiceNo,
            this.colToCompany,
            this.colToSite,
            this.colSaleDate,
            this.colTotal,
            this.colStatus,
            this.colIsPaid});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1275, 392);
            this.dgv.TabIndex = 2;
            // 
            // colMark_
            // 
            this.colMark_.DataPropertyName = "Mark_";
            this.colMark_.HeaderText = "";
            this.colMark_.Name = "colMark_";
            this.colMark_.ReadOnly = true;
            this.colMark_.Width = 40;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 45;
            // 
            // colPurchaseOrderNo
            // 
            this.colPurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            this.colPurchaseOrderNo.FillWeight = 40F;
            this.colPurchaseOrderNo.HeaderText = "លេខបញ្ជាទិញ";
            this.colPurchaseOrderNo.MinimumWidth = 200;
            this.colPurchaseOrderNo.Name = "colPurchaseOrderNo";
            this.colPurchaseOrderNo.ReadOnly = true;
            this.colPurchaseOrderNo.Width = 250;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceNo";
            this.colInvoiceNo.FillWeight = 40F;
            this.colInvoiceNo.HeaderText = "លេខវិក្កយបត្រ";
            this.colInvoiceNo.MinimumWidth = 100;
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            this.colInvoiceNo.Width = 200;
            // 
            // colToCompany
            // 
            this.colToCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colToCompany.DataPropertyName = "ToCompany";
            this.colToCompany.FillWeight = 60F;
            this.colToCompany.HeaderText = "ទៅកាន់ក្រុមហ៊ុន";
            this.colToCompany.Name = "colToCompany";
            this.colToCompany.ReadOnly = true;
            // 
            // colToSite
            // 
            this.colToSite.DataPropertyName = "Site";
            this.colToSite.HeaderText = "ទៅកាន់គំរោង";
            this.colToSite.Name = "colToSite";
            this.colToSite.ReadOnly = true;
            this.colToSite.Width = 200;
            // 
            // colSaleDate
            // 
            this.colSaleDate.DataPropertyName = "SaleDate";
            this.colSaleDate.HeaderText = "កាលបរិច្ឆេទលក់";
            this.colSaleDate.Name = "colSaleDate";
            this.colSaleDate.ReadOnly = true;
            this.colSaleDate.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "សរុបទឹកប្រាក់";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "ស្ថានភាព";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colIsPaid
            // 
            this.colIsPaid.HeaderText = "IsPaid";
            this.colIsPaid.Name = "colIsPaid";
            this.colIsPaid.ReadOnly = true;
            this.colIsPaid.Visible = false;
            // 
            // flowLayoutPanelTopGrid
            // 
            this.flowLayoutPanelTopGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.flowLayoutPanelTopGrid.Controls.Add(this.dtpSearchDate);
            this.flowLayoutPanelTopGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelTopGrid.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTopGrid.Name = "flowLayoutPanelTopGrid";
            this.flowLayoutPanelTopGrid.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.flowLayoutPanelTopGrid.Size = new System.Drawing.Size(1275, 39);
            this.flowLayoutPanelTopGrid.TabIndex = 0;
            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpSearchDate.FormattingEnabled = true;
            this.dtpSearchDate.Location = new System.Drawing.Point(10, 6);
            this.dtpSearchDate.Margin = new System.Windows.Forms.Padding(6, 6, 2, 4);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.Size = new System.Drawing.Size(200, 27);
            this.dtpSearchDate.TabIndex = 2;
            // 
            // lblInvoicingDate
            // 
            this.lblInvoicingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoicingDate.AutoSize = true;
            this.lblInvoicingDate.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicingDate.Location = new System.Drawing.Point(946, 23);
            this.lblInvoicingDate.Name = "lblInvoicingDate";
            this.lblInvoicingDate.Required = true;
            this.lblInvoicingDate.Size = new System.Drawing.Size(86, 27);
            this.lblInvoicingDate.TabIndex = 31;
            this.lblInvoicingDate.Text = "កាលបរិច្ឋេទធ្វើ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.exLabel4);
            this.panel3.Controls.Add(this.exLabel5);
            this.panel3.Controls.Add(this.exLabel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 518);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1275, 113);
            this.panel3.TabIndex = 34;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.txtLeftAmount);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(1059, 74);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel6.Size = new System.Drawing.Size(200, 27);
            this.panel6.TabIndex = 37;
            // 
            // txtLeftAmount
            // 
            this.txtLeftAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtLeftAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeftAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftAmount.Location = new System.Drawing.Point(0, 1);
            this.txtLeftAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtLeftAmount.Multiline = true;
            this.txtLeftAmount.Name = "txtLeftAmount";
            this.txtLeftAmount.ReadOnly = true;
            this.txtLeftAmount.Size = new System.Drawing.Size(173, 25);
            this.txtLeftAmount.TabIndex = 0;
            this.txtLeftAmount.Text = "0";
            this.txtLeftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(167, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "USD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.txtTotal);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(1059, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel5.Size = new System.Drawing.Size(200, 27);
            this.panel5.TabIndex = 38;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(0, 1);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(173, 25);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(167, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "USD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Controls.Add(this.txtPaidAmount);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(1059, 43);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel7.Size = new System.Drawing.Size(200, 27);
            this.panel7.TabIndex = 35;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaidAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(0, 1);
            this.txtPaidAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtPaidAmount.Multiline = true;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.ReadOnly = true;
            this.txtPaidAmount.Size = new System.Drawing.Size(173, 25);
            this.txtPaidAmount.TabIndex = 0;
            this.txtPaidAmount.Text = "0";
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(167, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "USD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exLabel4
            // 
            this.exLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel4.AutoSize = true;
            this.exLabel4.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel4.Location = new System.Drawing.Point(898, 12);
            this.exLabel4.Name = "exLabel4";
            this.exLabel4.Required = false;
            this.exLabel4.Size = new System.Drawing.Size(89, 27);
            this.exLabel4.TabIndex = 34;
            this.exLabel4.Text = "សរុបទឹកប្រាក់";
            // 
            // exLabel5
            // 
            this.exLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel5.AutoSize = true;
            this.exLabel5.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel5.Location = new System.Drawing.Point(898, 74);
            this.exLabel5.Name = "exLabel5";
            this.exLabel5.Required = false;
            this.exLabel5.Size = new System.Drawing.Size(66, 27);
            this.exLabel5.TabIndex = 39;
            this.exLabel5.Text = "សមតុល្យ";
            // 
            // exLabel6
            // 
            this.exLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel6.AutoSize = true;
            this.exLabel6.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel6.Location = new System.Drawing.Point(898, 44);
            this.exLabel6.Name = "exLabel6";
            this.exLabel6.Required = false;
            this.exLabel6.Size = new System.Drawing.Size(61, 27);
            this.exLabel6.TabIndex = 36;
            this.exLabel6.Text = "បង់ប្រាក់";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.panel4.Controls.Add(this.dtpInvoicingDate);
            this.panel4.Controls.Add(this.cboCustomer);
            this.panel4.Controls.Add(this.txtInvoiceNo);
            this.panel4.Controls.Add(this.lblInvoicingDate);
            this.panel4.Controls.Add(this.lblInvoiceNo);
            this.panel4.Controls.Add(this.exLabel2);
            this.panel4.Controls.Add(this.lblCustomer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1275, 85);
            this.panel4.TabIndex = 35;
            // 
            // dtpInvoicingDate
            // 
            this.dtpInvoicingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoicingDate.Location = new System.Drawing.Point(1059, 23);
            this.dtpInvoicingDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpInvoicingDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpInvoicingDate.Name = "dtpInvoicingDate";
            this.dtpInvoicingDate.Size = new System.Drawing.Size(200, 27);
            this.dtpInvoicingDate.TabIndex = 32;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Gray;
            this.pnlGrid.Controls.Add(this.dgv);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 39);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlGrid.Size = new System.Drawing.Size(1275, 393);
            this.pnlGrid.TabIndex = 16;
            // 
            // frmCreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 688);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCreateInvoice";
            this.Opacity = 0D;
            this.Text = "frmCreateInvoice";
            this.container.ResumeLayout(false);
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flowLayoutPanelTopGrid.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    
        private Component.ExLabel exLabel2;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private Component.ExLabel lblCustomer;
        private Component.ExSearchCombo cboCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTopGrid;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.CheckBox chkMarkAll_;
        private Component.ExLabel lblInvoicingDate;
        private Component.ExReportDatePicker dtpSearchDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnPrint;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Component.ExDateTimePicker dtpInvoicingDate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtLeftAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label3;
        private Component.ExLabel exLabel4;
        private Component.ExLabel exLabel5;
        private Component.ExLabel exLabel6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMark_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPaid;
        private System.Windows.Forms.Panel pnlGrid;
    }
}