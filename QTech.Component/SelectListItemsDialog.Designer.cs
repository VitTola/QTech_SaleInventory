using QTech.Base.BaseModels;
using EDomain = EasyServer.Domain;
namespace QTech.Component
{
    partial class SelectListItemsDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            QTech.Base.BaseModels.Paging paging1 = new QTech.Base.BaseModels.Paging();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectListItemsDialog));
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelect = new QTech.Component.ExButtonLoading();
            this.lblChoosed_ = new System.Windows.Forms.LinkLabel();
            this.lblChoosed1 = new QTech.Component.ExLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new QTech.Component.ExTextbox();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMark_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayText_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.pagination = new QTech.Component.ExPaging();
            this.chkCheckAll_ = new System.Windows.Forms.CheckBox();
            this.dgvSelected = new QTech.Component.ExDataGridView();
            this.colSelectedId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectedName_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectedItemObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemove_ = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.container.SuspendLayout();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelected)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.panel2);
            this.container.Controls.Add(this.panel1);
            this.container.Controls.Add(this.graPanel1);
            this.container.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.container.Size = new System.Drawing.Size(920, 600);
            this.container.Text = "container";
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha1.Parent = this.graPanel1;
            // 
            // graPanel1
            // 
            this.graPanel1.BackColor = System.Drawing.Color.Transparent;
            this.graPanel1.Border = true;
            this.graPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.graPanel1.Colors.Add(this.colorWithAlpha1);
            this.graPanel1.Colors.Add(this.colorWithAlpha2);
            this.graPanel1.ContentPadding = new System.Windows.Forms.Padding(0, 0, 0, -1);
            this.graPanel1.Controls.Add(this.flowLayoutPanel3);
            this.graPanel1.Controls.Add(this.flowLayoutPanel2);
            this.graPanel1.CornerRadius = 2;
            this.graPanel1.Corners = ((QTech.Component.Corners)((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight)));
            this.graPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.graPanel1.Gradient = false;
            this.graPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.graPanel1.GradientOffset = 1F;
            this.graPanel1.GradientSize = new System.Drawing.Size(0, 0);
            this.graPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.graPanel1.Grayscale = false;
            this.graPanel1.Image = null;
            this.graPanel1.ImageAlpha = 75;
            this.graPanel1.ImagePadding = new System.Windows.Forms.Padding(5);
            this.graPanel1.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.graPanel1.ImageSize = new System.Drawing.Size(48, 48);
            this.graPanel1.Location = new System.Drawing.Point(1, 0);
            this.graPanel1.Name = "graPanel1";
            this.graPanel1.Rounded = true;
            this.graPanel1.Size = new System.Drawing.Size(918, 35);
            this.graPanel1.TabIndex = 0;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha2.Parent = this.graPanel1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnSelect);
            this.flowLayoutPanel3.Controls.Add(this.lblChoosed_);
            this.flowLayoutPanel3.Controls.Add(this.lblChoosed1);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(517, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(401, 35);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.DefaultImage = null;
            this.btnSelect.Executing = false;
            this.btnSelect.Location = new System.Drawing.Point(297, 4);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSelect.ShortcutText = "S";
            this.btnSelect.Size = new System.Drawing.Size(100, 27);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "ជ្រើសរើស";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblChoosed_
            // 
            this.lblChoosed_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChoosed_.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblChoosed_.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblChoosed_.Location = new System.Drawing.Point(215, 5);
            this.lblChoosed_.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.lblChoosed_.Name = "lblChoosed_";
            this.lblChoosed_.Size = new System.Drawing.Size(80, 29);
            this.lblChoosed_.TabIndex = 8;
            this.lblChoosed_.TabStop = true;
            this.lblChoosed_.Text = "0";
            this.lblChoosed_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChoosed1
            // 
            this.lblChoosed1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChoosed1.AutoSize = true;
            this.lblChoosed1.Location = new System.Drawing.Point(142, 10);
            this.lblChoosed1.Margin = new System.Windows.Forms.Padding(2, 6, 0, 2);
            this.lblChoosed1.Name = "lblChoosed1";
            this.lblChoosed1.Required = false;
            this.lblChoosed1.Size = new System.Drawing.Size(73, 19);
            this.lblChoosed1.TabIndex = 7;
            this.lblChoosed1.Text = "បានជ្រើសរើស";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(918, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(4, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(4);
            this.txtSearch.PlaceHolderText = "";
            this.txtSearch.SearchMode = QTech.Component.ExTextbox.SearchModes.OnKeyReturn;
            this.txtSearch.Size = new System.Drawing.Size(160, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.QuickSearch += new System.EventHandler(this.txtSearch_QuickSearch);
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
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Ivory;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMark_,
            this.colName,
            this.colDisplayText_,
            this.colItemObject});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(646, 531);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colMark_
            // 
            this.colMark_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMark_.HeaderText = "";
            this.colMark_.MinimumWidth = 25;
            this.colMark_.Name = "colMark_";
            this.colMark_.ReadOnly = true;
            this.colMark_.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMark_.Width = 25;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "ឈ្មោះ";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDisplayText_
            // 
            this.colDisplayText_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDisplayText_.DataPropertyName = "DisplayText";
            this.colDisplayText_.FillWeight = 20F;
            this.colDisplayText_.HeaderText = "";
            this.colDisplayText_.Name = "colDisplayText_";
            this.colDisplayText_.ReadOnly = true;
            // 
            // colItemObject
            // 
            this.colItemObject.DataPropertyName = "ItemObject";
            this.colItemObject.HeaderText = "ItemObject";
            this.colItemObject.Name = "colItemObject";
            this.colItemObject.ReadOnly = true;
            this.colItemObject.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ColumName
            // 
            this.ColumName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumName.DataPropertyName = "Name";
            this.ColumName.HeaderText = "ឈ្មោះ";
            this.ColumName.Name = "ColumName";
            this.ColumName.ReadOnly = true;
            // 
            // DisplayText
            // 
            this.DisplayText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DisplayText.DataPropertyName = "DisplayText";
            this.DisplayText.HeaderText = "កត់ចំណាំ";
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.ReadOnly = true;
            // 
            // ItemObject
            // 
            this.ItemObject.DataPropertyName = "ItemObject";
            this.ItemObject.HeaderText = "ItemObject";
            this.ItemObject.Name = "ItemObject";
            this.ItemObject.ReadOnly = true;
            this.ItemObject.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel4);
            this.panel1.Controls.Add(this.pagination);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 33);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnClose);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(467, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(451, 33);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(374, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pagination
            // 
            this.pagination.Action = null;
            this.pagination.Dock = System.Windows.Forms.DockStyle.Left;
            this.pagination.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagination.IsPaging = false;
            this.pagination.ListModel = null;
            this.pagination.Location = new System.Drawing.Point(0, 0);
            this.pagination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagination.MinimumSize = new System.Drawing.Size(320, 33);
            this.pagination.Name = "pagination";
            paging1.CurrentPage = 1;
            paging1.IsPaging = true;
            paging1.PageSize = 25;
            this.pagination.Paging = paging1;
            this.pagination.ShowAllOption = false;
            this.pagination.Size = new System.Drawing.Size(467, 33);
            this.pagination.TabIndex = 0;
            this.pagination.Visible = false;
            // 
            // chkCheckAll_
            // 
            this.chkCheckAll_.AutoSize = true;
            this.chkCheckAll_.Location = new System.Drawing.Point(6, 6);
            this.chkCheckAll_.Name = "chkCheckAll_";
            this.chkCheckAll_.Size = new System.Drawing.Size(15, 14);
            this.chkCheckAll_.TabIndex = 5;
            this.chkCheckAll_.UseVisualStyleBackColor = true;
            // 
            // dgvSelected
            // 
            this.dgvSelected.AllowEnterToNextCell = false;
            this.dgvSelected.AllowRowNotFound = true;
            this.dgvSelected.AllowRowNumber = false;
            this.dgvSelected.AllowUserToAddRows = false;
            this.dgvSelected.AllowUserToDeleteRows = false;
            this.dgvSelected.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSelected.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSelected.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Ivory;
            this.dgvSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectedId,
            this.colSelectedName_,
            this.colSelectedItemObject,
            this.colRemove_});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelected.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelected.EnableHeadersVisualStyles = false;
            this.dgvSelected.Executing = false;
            this.dgvSelected.Location = new System.Drawing.Point(3, 0);
            this.dgvSelected.MultiSelect = false;
            this.dgvSelected.Name = "dgvSelected";
            this.dgvSelected.Paging = null;
            this.dgvSelected.ReadOnly = true;
            this.dgvSelected.RowHeadersVisible = false;
            this.dgvSelected.RowTemplate.Height = 28;
            this.dgvSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelected.Size = new System.Drawing.Size(269, 531);
            this.dgvSelected.TabIndex = 6;
            // 
            // colSelectedId
            // 
            this.colSelectedId.DataPropertyName = "Id";
            this.colSelectedId.HeaderText = "Id";
            this.colSelectedId.Name = "colSelectedId";
            this.colSelectedId.ReadOnly = true;
            this.colSelectedId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelectedId.Visible = false;
            // 
            // colSelectedName_
            // 
            this.colSelectedName_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSelectedName_.DataPropertyName = "Name";
            this.colSelectedName_.HeaderText = "បានជ្រើសរើស";
            this.colSelectedName_.Name = "colSelectedName_";
            this.colSelectedName_.ReadOnly = true;
            this.colSelectedName_.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colSelectedItemObject
            // 
            this.colSelectedItemObject.DataPropertyName = "ItemObject";
            this.colSelectedItemObject.HeaderText = "ItemObject";
            this.colSelectedItemObject.Name = "colSelectedItemObject";
            this.colSelectedItemObject.ReadOnly = true;
            this.colSelectedItemObject.Visible = false;
            // 
            // colRemove_
            // 
            this.colRemove_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRemove_.HeaderText = "";
            this.colRemove_.MinimumWidth = 15;
            this.colRemove_.Name = "colRemove_";
            this.colRemove_.ReadOnly = true;
            this.colRemove_.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRemove_.Width = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkCheckAll_);
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Controls.Add(this.pnlRight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 531);
            this.panel2.TabIndex = 7;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvSelected);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(646, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(272, 531);
            this.pnlRight.TabIndex = 8;
            this.pnlRight.Visible = false;
            // 
            // SelectListItemsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(920, 620);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SelectListItemsDialog";
            this.Text = "ស្វែងរកទិន្នន័យ";
            this.Load += new System.EventHandler(this.SelectItemsDialog_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectItemsDialog_KeyPress);
            this.container.ResumeLayout(false);
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelected)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ExDataGridView dgv;
        private ColorWithAlpha colorWithAlpha1;
        private ColorWithAlpha colorWithAlpha2;
        private ExTextbox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemObject;
        private ExButtonLoading btnSelect;
        private System.Windows.Forms.Panel panel1;
        private ExPaging pagination;
        private GRAPanel graPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ExButtonLoading btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMark_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayText_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemObject;
        private System.Windows.Forms.CheckBox chkCheckAll_;
        private ExLabel lblChoosed1;
        private System.Windows.Forms.Panel panel2;
        private ExDataGridView dgvSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectedId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectedName_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectedItemObject;
        private System.Windows.Forms.DataGridViewImageColumn colRemove_;
        private System.Windows.Forms.LinkLabel lblChoosed_;
        private System.Windows.Forms.Panel pnlRight;
    }
}
