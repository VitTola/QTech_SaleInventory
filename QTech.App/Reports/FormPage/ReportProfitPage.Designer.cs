namespace QTech.Reports
{
    partial class ReportProfitPage
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
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpPeroid = new QTech.Component.ExReportDatePicker();
            this.btnAdvanceSearch = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnView = new QTech.Component.ExButtonLoading();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.colName = new QTech.Component.TreeGridColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewer = new QTech.Component.ExReportViewer();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.graPanel1.Size = new System.Drawing.Size(1297, 35);
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
            this.flowLayoutPanel2.Controls.Add(this.dtpPeroid);
            this.flowLayoutPanel2.Controls.Add(this.btnAdvanceSearch);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1057, 35);
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
            this.btnAdvanceSearch.TabIndex = 30;
            this.btnAdvanceSearch.Text = "ស្វែងរកបន្ថែម";
            this.btnAdvanceSearch.UseVisualStyleBackColor = true;
            this.btnAdvanceSearch.Click += new System.EventHandler(this.btnAdvanceSearch_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1297, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.DefaultImage = null;
            this.btnView.Executing = false;
            this.btnView.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnView.Location = new System.Drawing.Point(1212, 3);
            this.btnView.Margin = new System.Windows.Forms.Padding(0, 3, 4, 4);
            this.btnView.Name = "btnView";
            this.btnView.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnView.ShortcutText = "O";
            this.btnView.Size = new System.Drawing.Size(81, 29);
            this.btnView.TabIndex = 30;
            this.btnView.Text = "មើល";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
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
            // viewer
            // 
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Executing = false;
            this.viewer.IsNotDrillSubReport = true;
            this.viewer.Location = new System.Drawing.Point(0, 35);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(1297, 550);
            this.viewer.TabIndex = 1;
            this.viewer.Viewer = QTech.Component.ExReportViewer.ViewerType.Crystal;
            // 
            // ReportProfitPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 585);
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.graPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReportProfitPage";
            this.Text = "ReportDriverDeliveryPage";
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private Component.ExReportViewer viewer;
        private Component.ExReportDatePicker dtpPeroid;
        private Component.ExButtonLoading btnView;
        private Component.ExButtonLoading btnAdvanceSearch;
    }
}