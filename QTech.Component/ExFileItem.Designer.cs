namespace QTech.Component
{
    partial class ExFileItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picFileType = new System.Windows.Forms.PictureBox();
            this.menuFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.picEdit = new QTech.Component.ExLoadingImageButton();
            this.picRemove = new QTech.Component.ExLoadingImageButton();
            this.topFlowLayout = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.nameContentLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.LinkLabel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.picRetry = new QTech.Component.ExLoadingImageButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.iconSidePanel = new System.Windows.Forms.Panel();
            this.borderBottomPanel = new QTech.Component.GRAPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picFileType)).BeginInit();
            this.menuFlowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
            this.topFlowLayout.SuspendLayout();
            this.nameContentLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetry)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.bottomFlowLayout.SuspendLayout();
            this.iconSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFileType
            // 
            this.picFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFileType.Image = global::QTech.Component.Properties.Resources.unknown_file;
            this.picFileType.Location = new System.Drawing.Point(5, 7);
            this.picFileType.Name = "picFileType";
            this.picFileType.Size = new System.Drawing.Size(28, 30);
            this.picFileType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFileType.TabIndex = 4;
            this.picFileType.TabStop = false;
            // 
            // menuFlowLayout
            // 
            this.menuFlowLayout.Controls.Add(this.picEdit);
            this.menuFlowLayout.Controls.Add(this.picRemove);
            this.menuFlowLayout.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuFlowLayout.Location = new System.Drawing.Point(319, 0);
            this.menuFlowLayout.Name = "menuFlowLayout";
            this.menuFlowLayout.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.menuFlowLayout.Size = new System.Drawing.Size(25, 43);
            this.menuFlowLayout.TabIndex = 1;
            // 
            // picEdit
            // 
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Executing = false;
            this.picEdit.Image = global::QTech.Component.Properties.Resources.edit;
            this.picEdit.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picEdit.Location = new System.Drawing.Point(0, 1);
            this.picEdit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(23, 20);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picEdit.TabIndex = 2;
            this.picEdit.TabStop = false;
            // 
            // picRemove
            // 
            this.picRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRemove.Executing = false;
            this.picRemove.Image = global::QTech.Component.Properties.Resources.rubbish;
            this.picRemove.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picRemove.Location = new System.Drawing.Point(0, 22);
            this.picRemove.Margin = new System.Windows.Forms.Padding(0);
            this.picRemove.Name = "picRemove";
            this.picRemove.Size = new System.Drawing.Size(23, 20);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRemove.TabIndex = 3;
            this.picRemove.TabStop = false;
            // 
            // topFlowLayout
            // 
            this.topFlowLayout.Controls.Add(this.lblDate);
            this.topFlowLayout.Controls.Add(this.nameContentLayout);
            this.topFlowLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.topFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.topFlowLayout.Margin = new System.Windows.Forms.Padding(2);
            this.topFlowLayout.Name = "topFlowLayout";
            this.topFlowLayout.Padding = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.topFlowLayout.Size = new System.Drawing.Size(319, 23);
            this.topFlowLayout.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(248, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 19);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Upload Date:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameContentLayout
            // 
            this.nameContentLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameContentLayout.Controls.Add(this.lblName);
            this.nameContentLayout.Controls.Add(this.picLoading);
            this.nameContentLayout.Controls.Add(this.picRetry);
            this.nameContentLayout.Location = new System.Drawing.Point(0, 4);
            this.nameContentLayout.Margin = new System.Windows.Forms.Padding(0);
            this.nameContentLayout.Name = "nameContentLayout";
            this.nameContentLayout.Size = new System.Drawing.Size(224, 19);
            this.nameContentLayout.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 19);
            this.lblName.TabIndex = 4;
            this.lblName.TabStop = true;
            this.lblName.Text = "File Name.png";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Image = global::QTech.Component.Properties.Resources.spin;
            this.picLoading.Location = new System.Drawing.Point(84, 0);
            this.picLoading.Margin = new System.Windows.Forms.Padding(0);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(18, 18);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoading.TabIndex = 5;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // picRetry
            // 
            this.picRetry.BackColor = System.Drawing.Color.Transparent;
            this.picRetry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRetry.Executing = false;
            this.picRetry.Image = global::QTech.Component.Properties.Resources.retry;
            this.picRetry.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picRetry.Location = new System.Drawing.Point(102, 0);
            this.picRetry.Margin = new System.Windows.Forms.Padding(0);
            this.picRetry.Name = "picRetry";
            this.picRetry.Size = new System.Drawing.Size(18, 18);
            this.picRetry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRetry.TabIndex = 6;
            this.picRetry.TabStop = false;
            this.picRetry.Visible = false;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.topFlowLayout);
            this.mainPanel.Controls.Add(this.bottomFlowLayout);
            this.mainPanel.Controls.Add(this.menuFlowLayout);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(40, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(344, 43);
            this.mainPanel.TabIndex = 3;
            // 
            // bottomFlowLayout
            // 
            this.bottomFlowLayout.Controls.Add(this.lblInfo);
            this.bottomFlowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomFlowLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomFlowLayout.Location = new System.Drawing.Point(0, 23);
            this.bottomFlowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.bottomFlowLayout.Name = "bottomFlowLayout";
            this.bottomFlowLayout.Size = new System.Drawing.Size(319, 20);
            this.bottomFlowLayout.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(198, 19);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Type: - Size: 0 byte Uploady By: Admin";
            // 
            // iconSidePanel
            // 
            this.iconSidePanel.Controls.Add(this.picFileType);
            this.iconSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconSidePanel.Location = new System.Drawing.Point(1, 1);
            this.iconSidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.iconSidePanel.Name = "iconSidePanel";
            this.iconSidePanel.Padding = new System.Windows.Forms.Padding(1);
            this.iconSidePanel.Size = new System.Drawing.Size(39, 43);
            this.iconSidePanel.TabIndex = 5;
            // 
            // borderBottomPanel
            // 
            this.borderBottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.borderBottomPanel.Border = true;
            this.borderBottomPanel.BorderColor = System.Drawing.Color.LightGray;
            this.borderBottomPanel.ContentPadding = new System.Windows.Forms.Padding(0);
            this.borderBottomPanel.CornerRadius = 5;
            this.borderBottomPanel.Corners = ((QTech.Component.Corners)((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight)));
            this.borderBottomPanel.Gradient = true;
            this.borderBottomPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.borderBottomPanel.GradientOffset = 1F;
            this.borderBottomPanel.GradientSize = new System.Drawing.Size(0, 0);
            this.borderBottomPanel.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.borderBottomPanel.Grayscale = false;
            this.borderBottomPanel.Image = null;
            this.borderBottomPanel.ImageAlpha = 75;
            this.borderBottomPanel.ImagePadding = new System.Windows.Forms.Padding(5);
            this.borderBottomPanel.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.borderBottomPanel.ImageSize = new System.Drawing.Size(48, 48);
            this.borderBottomPanel.Location = new System.Drawing.Point(0, 44);
            this.borderBottomPanel.Name = "borderBottomPanel";
            this.borderBottomPanel.Rounded = true;
            this.borderBottomPanel.Size = new System.Drawing.Size(385, 100);
            this.borderBottomPanel.TabIndex = 1;
            // 
            // ExFileItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.borderBottomPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.iconSidePanel);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Name = "ExFileItem";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(385, 45);
            ((System.ComponentModel.ISupportInitialize)(this.picFileType)).EndInit();
            this.menuFlowLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            this.topFlowLayout.ResumeLayout(false);
            this.topFlowLayout.PerformLayout();
            this.nameContentLayout.ResumeLayout(false);
            this.nameContentLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRetry)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.bottomFlowLayout.ResumeLayout(false);
            this.bottomFlowLayout.PerformLayout();
            this.iconSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFileType;
        private System.Windows.Forms.FlowLayoutPanel menuFlowLayout;
        private System.Windows.Forms.Panel topFlowLayout;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomFlowLayout;
        private System.Windows.Forms.Label lblInfo;
        private GRAPanel borderBottomPanel;
        private System.Windows.Forms.Panel iconSidePanel;
        private System.Windows.Forms.FlowLayoutPanel nameContentLayout;
        public System.Windows.Forms.LinkLabel lblName;
        private System.Windows.Forms.PictureBox picLoading;
        private ExLoadingImageButton picRetry;
        private System.Windows.Forms.Label lblDate;
        public ExLoadingImageButton picEdit;
        public ExLoadingImageButton picRemove;
    }
}
