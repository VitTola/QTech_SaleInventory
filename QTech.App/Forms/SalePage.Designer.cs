using QTech.Base.BaseModels;

namespace QTech.Forms
{
    partial class SalePage
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
            QTech.Base.BaseModels.Paging paging1 = new QTech.Base.BaseModels.Paging();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new QTech.Component.ExDataGridView();
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new QTech.Component.ExTextboxIconPattern();
            this.cboPayStatus = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new QTech.Component.ExButtonLoading();
            this.btnUpdate = new QTech.Component.ExButtonLoading();
            this.btnAdd = new QTech.Component.ExButtonLoading();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagination = new QTech.Component.ExPaging();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colRow,
            this.colRowDate,
            this.colPurchaseOrderNo,
            this.colInvoiceNo,
            this.colToCompany,
            this.colToSite,
            this.colSaleDate,
            this.colTotal,
            this.colStatus,
            this.colIsPaid});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.dgv.Location = new System.Drawing.Point(0, 35);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1096, 413);
            this.dgv.TabIndex = 1;
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
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
            this.graPanel1.Size = new System.Drawing.Size(1096, 35);
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
            this.flowLayoutPanel2.Controls.Add(this.cboPayStatus);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(498, 35);
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
            this.txtSearch.TabIndex = 0;
            // 
            // cboPayStatus
            // 
            this.cboPayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayStatus.FormattingEnabled = true;
            this.cboPayStatus.Location = new System.Drawing.Point(230, 3);
            this.cboPayStatus.Name = "cboPayStatus";
            this.cboPayStatus.Size = new System.Drawing.Size(237, 27);
            this.cboPayStatus.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRemove);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(809, 0);
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
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.pagination);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 448);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1096, 33);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // pagination
            // 
            this.pagination.Action = null;
            this.pagination.Dock = System.Windows.Forms.DockStyle.Left;
            this.pagination.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagination.IsPaging = false;
            this.pagination.ListModel = null;
            this.pagination.Location = new System.Drawing.Point(3, 4);
            this.pagination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagination.MinimumSize = new System.Drawing.Size(380, 33);
            this.pagination.Name = "pagination";
            paging1.CurrentPage = 1;
            paging1.IsPaging = true;
            paging1.PageSize = 25;
            this.pagination.Paging = paging1;
            this.pagination.ShowAllOption = false;
            this.pagination.Size = new System.Drawing.Size(485, 33);
            this.pagination.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colRow
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRow.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRow.HeaderText = "ល.រ";
            this.colRow.Name = "colRow";
            this.colRow.ReadOnly = true;
            this.colRow.Width = 30;
            // 
            // colRowDate
            // 
            this.colRowDate.HeaderText = "RowDate";
            this.colRowDate.Name = "colRowDate";
            this.colRowDate.ReadOnly = true;
            this.colRowDate.Visible = false;
            // 
            // colPurchaseOrderNo
            // 
            this.colPurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            this.colPurchaseOrderNo.FillWeight = 40F;
            this.colPurchaseOrderNo.HeaderText = "លេខបញ្ជាទិញ";
            this.colPurchaseOrderNo.MinimumWidth = 150;
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
            this.colInvoiceNo.Width = 200;
            // 
            // colToCompany
            // 
            this.colToCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colToCompany.DataPropertyName = "ToCompany";
            this.colToCompany.FillWeight = 60F;
            this.colToCompany.HeaderText = "ទៅកាន់ក្រុមហ៊ុន";
            this.colToCompany.MinimumWidth = 100;
            this.colToCompany.Name = "colToCompany";
            this.colToCompany.ReadOnly = true;
            // 
            // colToSite
            // 
            this.colToSite.DataPropertyName = "Site";
            this.colToSite.HeaderText = "ទៅកាន់គំរោង";
            this.colToSite.Name = "colToSite";
            this.colToSite.ReadOnly = true;
            this.colToSite.Width = 300;
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
            // SalePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 481);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.graPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SalePage";
            this.Text = "SalePage";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
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
        private Component.ExDataGridView dgv;
        private Component.ColorWithAlpha colorWithAlpha2;
        private Component.ColorWithAlpha colorWithAlpha3;
        private Component.ExTextboxIconPattern txtSearch;
        private System.Windows.Forms.ComboBox cboPayStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExPaging pagination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPaid;
    }
}