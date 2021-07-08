namespace QTech.App.Reports
{
    partial class ReportDriverDiliveryPage

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
            this.cboBranch = new QTech.Component.ExSearchListCombo();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnView = new QTech.Component.ExButtonLoading();
            this.viewer = new QTech.Component.ExReportViewer();
            this.cboStation = new QTech.Component.ExSearchCombo();
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
            this.graPanel1.Size = new System.Drawing.Size(1042, 35);
            this.graPanel1.TabIndex = 11;
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
            this.flowLayoutPanel2.Controls.Add(this.cboBranch);
            this.flowLayoutPanel2.Controls.Add(this.cboStation);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(897, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // dtpPeroid
            // 
            this.dtpPeroid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpPeroid.FormattingEnabled = true;
            this.dtpPeroid.Location = new System.Drawing.Point(0, 4);
            this.dtpPeroid.Margin = new System.Windows.Forms.Padding(0, 4, 3, 3);
            this.dtpPeroid.Name = "dtpPeroid";
            this.dtpPeroid.Size = new System.Drawing.Size(200, 27);
            this.dtpPeroid.TabIndex = 3;
            // 
            // cboBranch
            // 
            this.cboBranch.AllowNoSelected = false;
            this.cboBranch.AllowShowAll = true;
            this.cboBranch.Choose = "";
            this.cboBranch.CustomSearchForm = null;
            this.cboBranch.DataSourceFn = null;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.IsGirdViewColumn = false;
            this.cboBranch.LoadAll = true;
            this.cboBranch.Location = new System.Drawing.Point(205, 4);
            this.cboBranch.Margin = new System.Windows.Forms.Padding(2, 4, 3, 3);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.SearchParamFn = null;
            this.cboBranch.SelectedItems = null;
            this.cboBranch.SelectedObject = null;
            this.cboBranch.Size = new System.Drawing.Size(200, 27);
            this.cboBranch.TabIndex = 4;
            this.cboBranch.TextAll = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(897, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.DefaultImage = null;
            this.btnView.Executing = false;
            this.btnView.Location = new System.Drawing.Point(51, 4);
            this.btnView.Margin = new System.Windows.Forms.Padding(0, 4, 4, 2);
            this.btnView.Name = "btnView";
            this.btnView.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnView.ShortcutText = "O";
            this.btnView.Size = new System.Drawing.Size(90, 27);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "មើល";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // viewer
            // 
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Executing = false;
            this.viewer.IsNotDrillSubReport = true;
            this.viewer.Location = new System.Drawing.Point(0, 35);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(1042, 637);
            this.viewer.TabIndex = 12;
            this.viewer.Viewer = QTech.Component.ExReportViewer.ViewerType.Crystal;
            // 
            // cboStation
            // 
            this.cboStation.Choose = "";
            this.cboStation.CustomSearchForm = null;
            this.cboStation.DataSourceFn = null;
            this.cboStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStation.FormattingEnabled = true;
            this.cboStation.IsGirdViewColumn = false;
            this.cboStation.LoadAll = true;
            this.cboStation.Location = new System.Drawing.Point(410, 4);
            this.cboStation.Margin = new System.Windows.Forms.Padding(2, 4, 3, 3);
            this.cboStation.Name = "cboStation";
            this.cboStation.SearchParamFn = null;
            this.cboStation.SelectedItems = null;
            this.cboStation.SelectedObject = null;
            this.cboStation.ShowAll = false;
            this.cboStation.Size = new System.Drawing.Size(200, 27);
            this.cboStation.TabIndex = 5;
            this.cboStation.TextAll = "";
            // 
            // ReportDriverDiliveryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 672);
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.graPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReportDriverDiliveryPage";
            this.Text = "ReportDriverDiliveryPage";
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QTech.Component.GRAPanel graPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private QTech.Component.ExButtonLoading btnView;
        private QTech.Component.ColorWithAlpha colorWithAlpha1;
        private QTech.Component.ExReportViewer viewer;
        private QTech.Component.ExReportDatePicker dtpPeroid;
        private QTech.Component.ExSearchListCombo cboBranch;
        private QTech.Component.ExSearchCombo cboStation;
    }
}