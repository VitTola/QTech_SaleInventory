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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeBilling));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.colParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.chkMarkAll_ = new System.Windows.Forms.CheckBox();
            this.dgv = new QTech.Component.ExDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exLabel4 = new QTech.Component.ExLabel();
            this.lblTotal = new QTech.Component.ExLabel();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtLeftAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrePaid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDriver = new QTech.Component.ExLabel();
            this.colMark_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQauntity_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exLinkLabel1 = new QTech.Component.Components.ExLinkLabel();
            this.container.SuspendLayout();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.chkMarkAll_.CheckedChanged += new System.EventHandler(this.chkMarkAll__CheckedChanged);
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
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMark_,
            this.colId,
            this.colPurchaseOrderNo,
            this.colInvoiceNo,
            this.colToCompany,
            this.colToSite,
            this.colSaleDate,
            this.colProducts,
            this.colCategory_,
            this.colImportPrice,
            this.colQauntity_3,
            this.colTotal});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Khmer Kep", 9.75F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle25;
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
            this.dgv.Size = new System.Drawing.Size(1294, 604);
            this.dgv.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.exLinkLabel1);
            this.panel3.Controls.Add(this.lblDriver);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.exLabel4);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.exLabel3);
            this.panel3.Controls.Add(this.exLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 113);
            this.panel3.TabIndex = 35;
            // 
            // exLabel4
            // 
            this.exLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel4.AutoSize = true;
            this.exLabel4.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel4.Location = new System.Drawing.Point(372, 13);
            this.exLabel4.Name = "exLabel4";
            this.exLabel4.Required = false;
            this.exLabel4.Size = new System.Drawing.Size(74, 27);
            this.exLabel4.TabIndex = 35;
            this.exLabel4.Text = "អ្នកបើកបរ";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(921, 10);
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
            this.exLabel3.Location = new System.Drawing.Point(921, 72);
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
            this.exLabel1.Location = new System.Drawing.Point(921, 42);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(61, 27);
            this.exLabel1.TabIndex = 30;
            this.exLabel1.Text = "បង់ប្រាក់";
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txtPaidAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1082, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 30;
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(167, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "USD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.txtTotal);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(1082, 10);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel5.Size = new System.Drawing.Size(200, 27);
            this.panel5.TabIndex = 31;
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
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.txtLeftAmount);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(1082, 72);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel6.Size = new System.Drawing.Size(200, 27);
            this.panel6.TabIndex = 31;
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImage = global::QTech.Properties.Resources.lineDown1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.txtPrePaid);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(540, 42);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(200, 27);
            this.panel2.TabIndex = 31;
            // 
            // txtPrePaid
            // 
            this.txtPrePaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtPrePaid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrePaid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrePaid.Location = new System.Drawing.Point(0, 1);
            this.txtPrePaid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtPrePaid.Multiline = true;
            this.txtPrePaid.Name = "txtPrePaid";
            this.txtPrePaid.ReadOnly = true;
            this.txtPrePaid.Size = new System.Drawing.Size(173, 25);
            this.txtPrePaid.TabIndex = 0;
            this.txtPrePaid.Text = "0";
            this.txtPrePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(167, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "USD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDriver
            // 
            this.lblDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDriver.AutoSize = true;
            this.lblDriver.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriver.Location = new System.Drawing.Point(561, 13);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Required = false;
            this.lblDriver.Size = new System.Drawing.Size(74, 27);
            this.lblDriver.TabIndex = 36;
            this.lblDriver.Text = "អ្នកបើកបរ";
            // 
            // colMark_
            // 
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
            this.colPurchaseOrderNo.MinimumWidth = 150;
            this.colPurchaseOrderNo.Name = "colPurchaseOrderNo";
            this.colPurchaseOrderNo.ReadOnly = true;
            this.colPurchaseOrderNo.Width = 150;
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
            dataGridViewCellStyle23.NullValue = null;
            this.colSaleDate.DefaultCellStyle = dataGridViewCellStyle23;
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
            // colCategory_
            // 
            this.colCategory_.DataPropertyName = "Category";
            this.colCategory_.HeaderText = "ប្រភេទ";
            this.colCategory_.Name = "colCategory_";
            this.colCategory_.ReadOnly = true;
            this.colCategory_.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCategory_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            dataGridViewCellStyle24.Format = "C2";
            dataGridViewCellStyle24.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle24;
            this.colTotal.HeaderText = "សរុបទឹកប្រាក់";
            this.colTotal.MinimumWidth = 150;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 150;
            // 
            // exLinkLabel1
            // 
            this.exLinkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exLinkLabel1.AutoSize = true;
            this.exLinkLabel1.Font = new System.Drawing.Font("Khmer Kep", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLinkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.exLinkLabel1.Location = new System.Drawing.Point(372, 42);
            this.exLinkLabel1.Name = "exLinkLabel1";
            this.exLinkLabel1.RightSpace = 10;
            this.exLinkLabel1.ShortcutText = "";
            this.exLinkLabel1.ShowShortcutText = false;
            this.exLinkLabel1.Size = new System.Drawing.Size(147, 27);
            this.exLinkLabel1.TabIndex = 37;
            this.exLinkLabel1.TabStop = true;
            this.exLinkLabel1.Text = "សរុបទឹកប្រាក់បានបង់មុន";
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
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private Component.ExReportDatePicker dtpPeroid;
        private Component.ExButtonLoading btnAdvanceSearch;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.CheckBox chkMarkAll_;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.Panel panel3;
        private Component.ExLabel lblTotal;
        private Component.ExLabel exLabel3;
        private Component.ExLabel exLabel1;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnPrint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExButtonLoading btnView;
        private Component.ExLabel exLabel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtLeftAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPrePaid;
        private System.Windows.Forms.Label label2;
        private Component.ExLabel lblDriver;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMark_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private Component.Components.ExLinkLabel exLinkLabel1;
    }
}