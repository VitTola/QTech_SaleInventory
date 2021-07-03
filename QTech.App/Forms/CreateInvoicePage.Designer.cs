namespace QTech.Forms
{
    partial class CreateInvoicePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new QTech.Component.ExTextboxIconPattern();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new QTech.Component.ExButtonLoading();
            this.btnUpdate = new QTech.Component.ExButtonLoading();
            this.btnAdd = new QTech.Component.ExButtonLoading();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.dgv = new QTech.Component.TreeGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.colInvoiceNo = new QTech.Component.TreeGridColumn();
            this.colParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoicingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeftAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // graPanel1
            // 
            this.graPanel1.BackColor = System.Drawing.Color.Transparent;
            this.graPanel1.Border = false;
            this.graPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.graPanel1.Colors.Add(this.colorWithAlpha1);
            this.graPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.Controls.Add(this.flowLayoutPanel2);
            this.graPanel1.Controls.Add(this.flowLayoutPanel1);
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
            this.graPanel1.Location = new System.Drawing.Point(0, 0);
            this.graPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.graPanel1.Name = "graPanel1";
            this.graPanel1.Rounded = true;
            this.graPanel1.Size = new System.Drawing.Size(1320, 35);
            this.graPanel1.TabIndex = 0;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha1.Parent = this.graPanel1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Controls.Add(this.cboCustomer);
            this.flowLayoutPanel2.Controls.Add(this.cboStatus);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(879, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(3, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 2, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.SearchMode = QTech.Component.ExTextboxIconPattern.SearchModes.OnKeyReturn;
            this.txtSearch.SelectedMenuPattern = null;
            this.txtSearch.Size = new System.Drawing.Size(222, 26);
            this.txtSearch.SizeIcon = new System.Drawing.Size(16, 16);
            this.txtSearch.TabIndex = 1;
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
            this.cboCustomer.Location = new System.Drawing.Point(230, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(233, 27);
            this.cboCustomer.TabIndex = 26;
            this.cboCustomer.TextAll = "";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(469, 3);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(222, 27);
            this.cboStatus.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRemove);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1033, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Ivory;
            this.btnRemove.DefaultImage = null;
            this.btnRemove.Executing = false;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(193, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0, 4, 4, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnRemove.ShortcutText = null;
            this.btnRemove.Size = new System.Drawing.Size(90, 27);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "លុប";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Ivory;
            this.btnUpdate.DefaultImage = null;
            this.btnUpdate.Executing = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(101, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0, 4, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnUpdate.ShortcutText = null;
            this.btnUpdate.Size = new System.Drawing.Size(90, 27);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "កែប្រែ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Ivory;
            this.btnAdd.DefaultImage = null;
            this.btnAdd.Executing = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(9, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 4, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnAdd.ShortcutText = null;
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "បន្ថែម";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceNo,
            this.colParentId,
            this.colId,
            this.colInvoicingDate,
            this.colCustomer,
            this.colTotalAmount,
            this.colPaidAmount,
            this.colLeftAmount,
            this.colStatus});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.ImageList = null;
            this.dgv.Location = new System.Drawing.Point(0, 35);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1320, 570);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceNo";
            this.colInvoiceNo.DefaultNodeImage = null;
            this.colInvoiceNo.HeaderText = "លេខវិក័យប័ត្រ";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            this.colInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceNo.Width = 200;
            // 
            // colParentId
            // 
            this.colParentId.HeaderText = "colParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.ReadOnly = true;
            this.colParentId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParentId.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Visible = false;
            // 
            // colInvoicingDate
            // 
            this.colInvoicingDate.DataPropertyName = "InvoicingDate";
            this.colInvoicingDate.HeaderText = "ថ្ងៃចេញវិក័យប័ត្រ";
            this.colInvoicingDate.Name = "colInvoicingDate";
            this.colInvoicingDate.ReadOnly = true;
            this.colInvoicingDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInvoicingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoicingDate.Width = 150;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "Customer";
            this.colCustomer.HeaderText = "អតិថិជន";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCustomer.Width = 350;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalAmount.DataPropertyName = "TotalAmout";
            this.colTotalAmount.HeaderText = "សរុបទឹកប្រាក់";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTotalAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPaidAmount
            // 
            this.colPaidAmount.HeaderText = "ទឹកប្រាក់បានបង់";
            this.colPaidAmount.Name = "colPaidAmount";
            this.colPaidAmount.ReadOnly = true;
            this.colPaidAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPaidAmount.Width = 200;
            // 
            // colLeftAmount
            // 
            this.colLeftAmount.HeaderText = "ទឹកប្រាក់នៅសល់";
            this.colLeftAmount.Name = "colLeftAmount";
            this.colLeftAmount.ReadOnly = true;
            this.colLeftAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLeftAmount.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "ស្ថានភាព";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CreateInvoicePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 605);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.graPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateInvoicePage";
            this.Text = "CreateInvoicePage";
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Component.GRAPanel graPanel1;
        private Component.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Component.ExButtonLoading btnAdd;
        private Component.ExButtonLoading btnRemove;
        private Component.ExButtonLoading btnUpdate;
        private Component.ColorWithAlpha colorWithAlpha2;
        private Component.ColorWithAlpha colorWithAlpha3;
        private Component.TreeGridView dgv;
        private System.Windows.Forms.ImageList imageList1;
        private Component.ExTextboxIconPattern txtSearch;
        private System.Windows.Forms.ComboBox cboStatus;
        private Component.ExSearchCombo cboCustomer;
        private Component.TreeGridColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoicingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeftAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}