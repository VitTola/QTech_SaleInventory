namespace QTech.Forms
{
    partial class frmEmployeeBilling
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeBilling));
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.btnView = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpPeroid = new QTech.Component.ExReportDatePicker();
            this.btnAdvanceSearch = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.colName = new QTech.Component.TreeGridColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.chkMarkAll_ = new System.Windows.Forms.CheckBox();
            this.dgv = new QTech.Component.ExDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlExpect = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblCur2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLeftAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new QTech.Component.ExLabel();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.colMark_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQauntity_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.container.SuspendLayout();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlExpect.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.panel3);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.panelGrid);
            this.container.Controls.Add(this.graPanel1);
            this.container.Size = new System.Drawing.Size(1296, 641);
            // 
            // graPanel1
            // 
            this.graPanel1.BackColor = System.Drawing.Color.Transparent;
            this.graPanel1.Border = false;
            this.graPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.graPanel1.Colors.Add(this.colorWithAlpha1);
            this.graPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.Controls.Add(this.btnView);
            this.graPanel1.Controls.Add(this.flowLayoutPanel2);
            this.graPanel1.CornerRadius = 3;
            this.graPanel1.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.graPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.graPanel1.Gradient = false;
            this.graPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.graPanel1.GradientOffset = 1F;
            this.graPanel1.GradientSize = new System.Drawing.Size(0, 0);
            this.graPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.graPanel1.Grayscale = false;
            this.graPanel1.Image = null;
            this.graPanel1.ImageAlpha = 75;
            this.graPanel1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.graPanel1.ImageSize = new System.Drawing.Size(48, 48);
            this.graPanel1.Location = new System.Drawing.Point(1, 1);
            this.graPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.graPanel1.Name = "graPanel1";
            this.graPanel1.Rounded = true;
            this.graPanel1.Size = new System.Drawing.Size(1294, 35);
            this.graPanel1.TabIndex = 0;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha1.Parent = this.graPanel1;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.DefaultImage = null;
            this.btnView.Executing = false;
            this.btnView.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnView.Location = new System.Drawing.Point(1209, 3);
            this.btnView.Margin = new System.Windows.Forms.Padding(0, 3, 4, 4);
            this.btnView.Name = "btnView";
            this.btnView.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnView.ShortcutText = "O";
            this.btnView.Size = new System.Drawing.Size(81, 29);
            this.btnView.TabIndex = 31;
            this.btnView.Text = "មើល";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.dtpPeroid);
            this.flowLayoutPanel2.Controls.Add(this.btnAdvanceSearch);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(313, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // dtpPeroid
            // 
            this.dtpPeroid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpPeroid.FormattingEnabled = true;
            this.dtpPeroid.Location = new System.Drawing.Point(3, 3);
            this.dtpPeroid.Name = "dtpPeroid";
            this.dtpPeroid.Size = new System.Drawing.Size(200, 27);
            this.dtpPeroid.TabIndex = 29;
            // 
            // btnAdvanceSearch
            // 
            this.btnAdvanceSearch.DefaultImage = null;
            this.btnAdvanceSearch.Executing = false;
            this.btnAdvanceSearch.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnAdvanceSearch.Location = new System.Drawing.Point(206, 3);
            this.btnAdvanceSearch.Margin = new System.Windows.Forms.Padding(0, 3, 4, 4);
            this.btnAdvanceSearch.Name = "btnAdvanceSearch";
            this.btnAdvanceSearch.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnAdvanceSearch.ShortcutText = "F3";
            this.btnAdvanceSearch.Size = new System.Drawing.Size(94, 29);
            this.btnAdvanceSearch.TabIndex = 19;
            this.btnAdvanceSearch.Text = "ស្វែងរកបន្ថែម";
            this.btnAdvanceSearch.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(954, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colorWithAlpha2.Parent = null;
            // 
            // colorWithAlpha3
            // 
            this.colorWithAlpha3.Alpha = 255;
            this.colorWithAlpha3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colorWithAlpha3.Parent = null;
            // 
            // colName
            // 
            this.colName.DefaultNodeImage = null;
            this.colName.Name = "colName";
            // 
            // colId
            // 
            this.colId.Name = "colId";
            // 
            // colParentId
            // 
            this.colParentId.Name = "colParentId";
            // 
            // colPhone
            // 
            this.colPhone.Name = "colPhone";
            // 
            // colNote
            // 
            this.colNote.Name = "colNote";
            // 
            // panelGrid
            // 
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.chkMarkAll_);
            this.panelGrid.Controls.Add(this.dgv);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(1, 36);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1294, 604);
            this.panelGrid.TabIndex = 31;
            // 
            // chkMarkAll_
            // 
            this.chkMarkAll_.AutoSize = true;
            this.chkMarkAll_.Location = new System.Drawing.Point(14, 10);
            this.chkMarkAll_.Name = "chkMarkAll_";
            this.chkMarkAll_.Size = new System.Drawing.Size(15, 14);
            this.chkMarkAll_.TabIndex = 15;
            this.chkMarkAll_.UseVisualStyleBackColor = true;
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
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMark_,
            this.dataGridViewTextBoxColumn1,
            this.colPurchaseOrderNo,
            this.colInvoiceNo,
            this.colToCompany,
            this.colToSite,
            this.colSaleDate,
            this.colProducts,
            this.colCategory,
            this.colImportPrice,
            this.colQauntity_3,
            this.colTotal});
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
            this.dgv.Size = new System.Drawing.Size(1292, 602);
            this.dgv.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlExpect);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.exLabel3);
            this.panel3.Controls.Add(this.exLabel1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 113);
            this.panel3.TabIndex = 35;
            // 
            // pnlExpect
            // 
            this.pnlExpect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExpect.BackColor = System.Drawing.SystemColors.Control;
            this.pnlExpect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpect.Controls.Add(this.txtTotal);
            this.pnlExpect.Controls.Add(this.lblCur2);
            this.pnlExpect.Location = new System.Drawing.Point(1083, 12);
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
            this.txtTotal.Text = "0";
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtLeftAmount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1083, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(200, 27);
            this.panel2.TabIndex = 33;
            // 
            // txtLeftAmount
            // 
            this.txtLeftAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeftAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLeftAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftAmount.Location = new System.Drawing.Point(0, 2);
            this.txtLeftAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtLeftAmount.Name = "txtLeftAmount";
            this.txtLeftAmount.ReadOnly = true;
            this.txtLeftAmount.Size = new System.Drawing.Size(165, 19);
            this.txtLeftAmount.TabIndex = 0;
            this.txtLeftAmount.Text = "0";
            this.txtLeftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(165, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "USD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(962, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Required = false;
            this.lblTotal.Size = new System.Drawing.Size(89, 27);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "សរុបទឹកប្រាក់";
            // 
            // exLabel3
            // 
            this.exLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel3.AutoSize = true;
            this.exLabel3.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel3.Location = new System.Drawing.Point(964, 78);
            this.exLabel3.Name = "exLabel3";
            this.exLabel3.Required = false;
            this.exLabel3.Size = new System.Drawing.Size(66, 27);
            this.exLabel3.TabIndex = 32;
            this.exLabel3.Text = "សមតុល្យ";
            // 
            // exLabel1
            // 
            this.exLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel1.AutoSize = true;
            this.exLabel1.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel1.Location = new System.Drawing.Point(963, 47);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(100, 27);
            this.exLabel1.TabIndex = 30;
            this.exLabel1.Text = "ទឹកប្រាក់បានបង់";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPaidAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1083, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 31;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaidAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaidAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(0, 2);
            this.txtPaidAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.ReadOnly = true;
            this.txtPaidAmount.Size = new System.Drawing.Size(165, 19);
            this.txtPaidAmount.TabIndex = 0;
            this.txtPaidAmount.Text = "0";
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel4);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 604);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(1294, 36);
            this.exPanel1.TabIndex = 36;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnPrint);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(279, 32);
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
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnClose);
            this.flowLayoutPanel4.Controls.Add(this.btnSave);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1290, 32);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(1213, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Location = new System.Drawing.Point(1134, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // colMark_
            // 
            this.colMark_.HeaderText = "";
            this.colMark_.Name = "colMark_";
            this.colMark_.ReadOnly = true;
            this.colMark_.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // colPurchaseOrderNo
            // 
            this.colPurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            this.colPurchaseOrderNo.FillWeight = 40F;
            this.colPurchaseOrderNo.HeaderText = "លេខបញ្ជាទិញ";
            this.colPurchaseOrderNo.MinimumWidth = 200;
            this.colPurchaseOrderNo.Name = "colPurchaseOrderNo";
            this.colPurchaseOrderNo.ReadOnly = true;
            this.colPurchaseOrderNo.Width = 200;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceNo";
            this.colInvoiceNo.FillWeight = 40F;
            this.colInvoiceNo.HeaderText = "លេខវិក្កយបត្រ";
            this.colInvoiceNo.MinimumWidth = 100;
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            this.colInvoiceNo.Width = 150;
            // 
            // colToCompany
            // 
            this.colToCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colToCompany.DataPropertyName = "ToCompany";
            this.colToCompany.FillWeight = 60F;
            this.colToCompany.HeaderText = "ទៅកាន់ក្រុមហ៊ុន";
            this.colToCompany.MinimumWidth = 150;
            this.colToCompany.Name = "colToCompany";
            this.colToCompany.ReadOnly = true;
            // 
            // colToSite
            // 
            this.colToSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colToSite.DataPropertyName = "Site";
            this.colToSite.HeaderText = "ទៅកាន់គំរោង";
            this.colToSite.MinimumWidth = 150;
            this.colToSite.Name = "colToSite";
            this.colToSite.ReadOnly = true;
            // 
            // colSaleDate
            // 
            this.colSaleDate.DataPropertyName = "SaleDate";
            this.colSaleDate.HeaderText = "កាលបរិច្ឆេទលក់";
            this.colSaleDate.Name = "colSaleDate";
            this.colSaleDate.ReadOnly = true;
            this.colSaleDate.Width = 150;
            // 
            // colProducts
            // 
            this.colProducts.DataPropertyName = "Products";
            this.colProducts.HeaderText = "ទំនិញ";
            this.colProducts.Name = "colProducts";
            this.colProducts.ReadOnly = true;
            this.colProducts.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "ប្រភេទ";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Visible = false;
            // 
            // colImportPrice
            // 
            this.colImportPrice.DataPropertyName = "ImportPrice";
            this.colImportPrice.HeaderText = "តម្លៃនាំចូល";
            this.colImportPrice.Name = "colImportPrice";
            this.colImportPrice.ReadOnly = true;
            // 
            // colQauntity_3
            // 
            this.colQauntity_3.HeaderText = "ចំនួន";
            this.colQauntity_3.Name = "colQauntity_3";
            this.colQauntity_3.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.HeaderText = "សរុបទឹកប្រាក់";
            this.colTotal.MinimumWidth = 100;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // frmEmployeeBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 661);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEmployeeBilling";
            this.Text = "frmEmployeeBilling";
            this.container.ResumeLayout(false);
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlExpect.ResumeLayout(false);
            this.pnlExpect.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Component.GRAPanel graPanel1;
        private Component.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Component.ColorWithAlpha colorWithAlpha2;
        private Component.ColorWithAlpha colorWithAlpha3;
        private Component.TreeGridColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private Component.ExReportDatePicker dtpPeroid;
        private Component.ExButtonLoading btnAdvanceSearch;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.CheckBox chkMarkAll_;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlExpect;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCur2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLeftAmount;
        private System.Windows.Forms.Label label2;
        private Component.ExLabel lblTotal;
        private Component.ExLabel exLabel3;
        private Component.ExLabel exLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label1;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnPrint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExButtonLoading btnView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMark_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducts;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}