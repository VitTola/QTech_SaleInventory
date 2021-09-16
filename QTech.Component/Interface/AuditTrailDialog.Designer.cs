using QDomain = QTech.Base;
namespace QTech.Component
{
    partial class AuditTrailDialog
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
            QTech.Base.BaseModels.Paging paging1 = new QTech.Base.BaseModels.Paging();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditTrailDialog));
            this.dgv = new QTech.Component.TreeGridView();
            this.colEditor = new QTech.Component.TreeGridColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exPanel = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagination = new QTech.Component.ExPaging();
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpDate = new QTech.Component.ReportDatePicker();
            this.btnExportAsExcel_ = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExpand_ = new QTech.Component.ExButtonLoading();
            //this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.exPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.graPanel1);
            this.container.Controls.Add(this.exPanel);
            this.container.Size = new System.Drawing.Size(920, 599);
            this.container.Text = "container";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEditor,
            this.colId,
            this.colDate,
            this.colHostName,
            this.colTransaction,
            this.colOldValue,
            this.colNewValue});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.ImageList = null;
            this.dgv.Location = new System.Drawing.Point(1, 36);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowLines = false;
            this.dgv.Size = new System.Drawing.Size(918, 527);
            this.dgv.TabIndex = 1;
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgv.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // 
            // colEditor
            // 
            this.colEditor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditor.DefaultNodeImage = null;
            this.colEditor.FillWeight = 40F;
            this.colEditor.HeaderText = "Editor";
            this.colEditor.MinimumWidth = 100;
            this.colEditor.Name = "colEditor";
            this.colEditor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Visible = false;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 100;
            this.colDate.Name = "colDate";
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colHostName
            // 
            this.colHostName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHostName.HeaderText = "MachineName";
            this.colHostName.MinimumWidth = 100;
            this.colHostName.Name = "colHostName";
            this.colHostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTransaction
            // 
            this.colTransaction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransaction.FillWeight = 50F;
            this.colTransaction.HeaderText = "Transaction";
            this.colTransaction.MinimumWidth = 100;
            this.colTransaction.Name = "colTransaction";
            this.colTransaction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOldValue
            // 
            this.colOldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOldValue.FillWeight = 25F;
            this.colOldValue.HeaderText = "OldValue";
            this.colOldValue.Name = "colOldValue";
            this.colOldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNewValue
            // 
            this.colNewValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNewValue.FillWeight = 25F;
            this.colNewValue.HeaderText = "NewValue";
            this.colNewValue.Name = "colNewValue";
            this.colNewValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // exPanel
            // 
            this.exPanel.BackColor = System.Drawing.Color.Transparent;
            this.exPanel.Controls.Add(this.flowLayoutPanel3);
            this.exPanel.Controls.Add(this.flowLayoutPanel5);
            this.exPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel.Location = new System.Drawing.Point(1, 563);
            this.exPanel.Margin = new System.Windows.Forms.Padding(0);
            this.exPanel.Name = "exPanel";
            this.exPanel.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel.Size = new System.Drawing.Size(918, 35);
            this.exPanel.TabIndex = 22;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnClose);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(344, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(572, 31);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(495, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.pagination);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(342, 31);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // pagination
            // 
            this.pagination.Action = null;
            this.pagination.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagination.ListModel = null;
            this.pagination.Location = new System.Drawing.Point(0, 0);
            this.pagination.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.pagination.MinimumSize = new System.Drawing.Size(320, 33);
            this.pagination.Name = "pagination";
            paging1.CurrentPage = 1;
            paging1.IsPaging = true;
            paging1.PageSize = 25;
            this.pagination.Paging = paging1;
            this.pagination.ShowAllOption = false;
            this.pagination.Size = new System.Drawing.Size(320, 33);
            this.pagination.TabIndex = 6;
            // 
            // graPanel1
            // 
            this.graPanel1.BackColor = System.Drawing.Color.Transparent;
            this.graPanel1.Border = false;
            this.graPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.graPanel1.Colors.Add(this.colorWithAlpha1);
            this.graPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.Controls.Add(this.flowLayoutPanel2);
            this.graPanel1.Controls.Add(this.flowLayoutPanel4);
            this.graPanel1.CornerRadius = 3;
            this.graPanel1.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight)
            | QTech.Component.Corners.BottomLeft)
            | QTech.Component.Corners.BottomRight)));
            this.graPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.graPanel1.Gradient = false;
            this.graPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
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
            this.graPanel1.Size = new System.Drawing.Size(918, 35);
            this.graPanel1.TabIndex = 24;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.ControlLight;
            this.colorWithAlpha1.Parent = this.graPanel1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.dtpDate);
            this.flowLayoutPanel2.Controls.Add(this.btnExportAsExcel_);
            this.flowLayoutPanel2.Controls.Add(this.btnExpand_);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(808, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.AutoSave = true;
            this.dtpDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dtpDate.DateFilterTypes = QTech.Component.ReportDatePicker.DateFilterType.Period;
            this.dtpDate.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.dtpDate.FromDate = new System.DateTime(2020, 1, 26, 16, 13, 51, 349);
            this.dtpDate.Location = new System.Drawing.Point(3, 4);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 2, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 27);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ToDate = new System.DateTime(2020, 2, 1, 23, 59, 59, 0);
            this.dtpDate.Value = QTech.Component.ReportDatePicker.DateRanges.ThisWeek;
            // 
            // btnExportAsExcel_
            // 
            this.btnExportAsExcel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAsExcel_.AutoSize = true;
            this.btnExportAsExcel_.DefaultImage = null;
            this.btnExportAsExcel_.Executing = false;
            this.btnExportAsExcel_.Image = ((System.Drawing.Image)(resources.GetObject("btnExportAsExcel_.Image")));
            this.btnExportAsExcel_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportAsExcel_.Location = new System.Drawing.Point(205, 3);
            this.btnExportAsExcel_.Margin = new System.Windows.Forms.Padding(0, 3, 1, 2);
            this.btnExportAsExcel_.Name = "btnExportAsExcel_";
            this.btnExportAsExcel_.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnExportAsExcel_.ShortcutText = "E";
            this.btnExportAsExcel_.Size = new System.Drawing.Size(33, 29);
            this.btnExportAsExcel_.TabIndex = 1;
            this.btnExportAsExcel_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportAsExcel_.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(808, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(110, 35);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // btnExpand_
            // 
            this.btnExpand_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand_.AutoSize = true;
            this.btnExpand_.DefaultImage = null;
            this.btnExpand_.Executing = false;
            this.btnExpand_.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand_.Image")));
            this.btnExpand_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpand_.Location = new System.Drawing.Point(239, 3);
            this.btnExpand_.Margin = new System.Windows.Forms.Padding(0, 3, 2, 2);
            this.btnExpand_.Name = "btnExpand_";
            this.btnExpand_.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnExpand_.ShortcutText = "M";
            this.btnExpand_.Size = new System.Drawing.Size(33, 29);
            this.btnExpand_.TabIndex = 2;
            this.btnExpand_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpand_.UseVisualStyleBackColor = true;
            // 
            // AuditTrailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 620);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AuditTrailDialog";
            this.Text = "ប្រវត្តិការកែប្រែ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AuditTrailDialog_Load);
            this.container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.exPanel.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TreeGridView dgv;
        private Components.ExPanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private ExButtonLoading btnClose;
        private GRAPanel graPanel1;
        private ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ReportDatePicker dtpDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private ExPaging pagination;
        private TreeGridColumn colEditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewValue;
        private ExButtonLoading btnExportAsExcel_;
        private ExButtonLoading btnExpand_;
    }
}