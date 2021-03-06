namespace Storm.Component
{
    partial class SelectItemsXXDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Storm.Domain.Models.Paging paging2 = new Storm.Domain.Models.Paging();
            this.colorWithAlpha1 = new Storm.Component.ColorWithAlpha();
            this.graPanel1 = new Storm.Component.GRAPanel();
            this.colorWithAlpha2 = new Storm.Component.ColorWithAlpha();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelect = new Storm.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new Storm.Component.ExTextbox();
            this.dgv = new Storm.Component.ExDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new Storm.Component.ExButtonLoading();
            this.pagination = new Storm.Component.ExPaging();
            this.container.SuspendLayout();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.panel1);
            this.container.Controls.Add(this.graPanel1);
            this.container.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.container.Size = new System.Drawing.Size(920, 599);
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
            this.graPanel1.Corners = ((Storm.Component.Corners)((Storm.Component.Corners.TopLeft | Storm.Component.Corners.TopRight)));
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
            this.graPanel1.ImagePosition = Storm.Component.ImagePositions.BottomRight;
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
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(718, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 35);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Executing = false;
            this.btnSelect.Location = new System.Drawing.Point(96, 4);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ShortcutAligment = Storm.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSelect.ShortcutText = null;
            this.btnSelect.Size = new System.Drawing.Size(100, 27);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "ជ្រើសយក";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnOK_Click);
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
            this.txtSearch.SearchMode = Storm.Component.ExTextbox.SearchModes.OnKeyReturn;
            this.txtSearch.Size = new System.Drawing.Size(160, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.QuickSearch += new System.EventHandler(this.txtSearch_QuickSearch);
            // 
            // dgv
            // 
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colName,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(1, 35);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(918, 530);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "ឈ្មោះ";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DisplayText";
            this.dataGridViewTextBoxColumn3.FillWeight = 20F;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ItemObject";
            this.dataGridViewTextBoxColumn4.HeaderText = "ItemObject";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
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
            this.panel1.Location = new System.Drawing.Point(1, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 33);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnClose);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(320, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(598, 33);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(521, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = Storm.Component.ExButtonLoading.Aligment.Horizontal;
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
            this.pagination.ListModel = null;
            this.pagination.Location = new System.Drawing.Point(0, 0);
            this.pagination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagination.MinimumSize = new System.Drawing.Size(320, 33);
            this.pagination.Name = "pagination";
            paging2.CurrentPage = 1;
            paging2.IsPaging = true;
            paging2.PageSize = 25;
            this.pagination.Paging = paging2;
            this.pagination.ShowAllOption = false;
            this.pagination.Size = new System.Drawing.Size(320, 33);
            this.pagination.TabIndex = 0;
            // 
            // SelectItemsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(920, 620);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SelectItemsDialog";
            this.Text = "ស្វែងរកទិន្នន័យ";
            this.Load += new System.EventHandler(this.SelectItemsDialog_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectItemsDialog_KeyPress);
            this.container.ResumeLayout(false);
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ExButtonLoading btnClose;
    }
}
