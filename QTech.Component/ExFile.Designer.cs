namespace QTech.Component
{
    partial class ExFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExFile));
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.topFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.leftFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this._btnAdd = new System.Windows.Forms.Button();
            this.mainContainerLayout = new System.Windows.Forms.Panel();
            this.picDgvLoading = new System.Windows.Forms.PictureBox();
            this.lblMsgRowNotFound = new System.Windows.Forms.Label();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.topFlowLayout.SuspendLayout();
            this.leftFlowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDgvLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Download";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.MinimumWidth = 35;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.MinimumWidth = 35;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 35;
            // 
            // picAdd
            // 
            this.picAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picAdd.BackColor = System.Drawing.Color.White;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = global::QTech.Component.Properties.Resources.plus_in_circle;
            this.picAdd.Location = new System.Drawing.Point(436, 106);
            this.picAdd.Margin = new System.Windows.Forms.Padding(0);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(16, 17);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdd.TabIndex = 2;
            this.picAdd.TabStop = false;
            // 
            // topFlowLayout
            // 
            this.topFlowLayout.BackColor = System.Drawing.Color.Transparent;
            this.topFlowLayout.Controls.Add(this.lblAdd);
            this.topFlowLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.topFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.topFlowLayout.Location = new System.Drawing.Point(25, 0);
            this.topFlowLayout.Margin = new System.Windows.Forms.Padding(1);
            this.topFlowLayout.Name = "topFlowLayout";
            this.topFlowLayout.Padding = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.topFlowLayout.Size = new System.Drawing.Size(429, 25);
            this.topFlowLayout.TabIndex = 3;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(388, 4);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            // 
            // leftFlowLayout
            // 
            this.leftFlowLayout.BackColor = System.Drawing.Color.Transparent;
            this.leftFlowLayout.Controls.Add(this._btnAdd);
            this.leftFlowLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.leftFlowLayout.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.leftFlowLayout.Name = "leftFlowLayout";
            this.leftFlowLayout.Size = new System.Drawing.Size(25, 125);
            this.leftFlowLayout.TabIndex = 4;
            // 
            // _btnAdd
            // 
            this._btnAdd.Image = global::QTech.Component.Properties.Resources.attachment;
            this._btnAdd.Location = new System.Drawing.Point(1, 0);
            this._btnAdd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(23, 24);
            this._btnAdd.TabIndex = 0;
            this._btnAdd.UseVisualStyleBackColor = true;
            // 
            // mainContainerLayout
            // 
            this.mainContainerLayout.AllowDrop = true;
            this.mainContainerLayout.AutoScroll = true;
            this.mainContainerLayout.BackColor = System.Drawing.Color.White;
            this.mainContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainerLayout.Location = new System.Drawing.Point(25, 25);
            this.mainContainerLayout.Name = "mainContainerLayout";
            this.mainContainerLayout.Size = new System.Drawing.Size(429, 100);
            this.mainContainerLayout.TabIndex = 5;
            // 
            // picDgvLoading
            // 
            this.picDgvLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picDgvLoading.BackColor = System.Drawing.Color.Transparent;
            this.picDgvLoading.Image = global::QTech.Component.Properties.Resources.dgvloading;
            this.picDgvLoading.Location = new System.Drawing.Point(191, 45);
            this.picDgvLoading.Name = "picDgvLoading";
            this.picDgvLoading.Size = new System.Drawing.Size(81, 58);
            this.picDgvLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDgvLoading.TabIndex = 3;
            this.picDgvLoading.TabStop = false;
            this.picDgvLoading.Visible = false;
            // 
            // lblMsgRowNotFound
            // 
            this.lblMsgRowNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsgRowNotFound.BackColor = System.Drawing.SystemColors.Window;
            this.lblMsgRowNotFound.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgRowNotFound.ForeColor = System.Drawing.Color.Gray;
            this.lblMsgRowNotFound.Location = new System.Drawing.Point(30, 60);
            this.lblMsgRowNotFound.Name = "lblMsgRowNotFound";
            this.lblMsgRowNotFound.Size = new System.Drawing.Size(419, 19);
            this.lblMsgRowNotFound.TabIndex = 0;
            this.lblMsgRowNotFound.Text = "មិនមានទិន្នន័យបង្ហាញ";
            this.lblMsgRowNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.Color.LightGray;
            this.colorWithAlpha1.Parent = null;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.LightGray;
            this.colorWithAlpha2.Parent = null;
            // 
            // ExFile
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.picDgvLoading);
            this.Controls.Add(this.lblMsgRowNotFound);
            this.Controls.Add(this.mainContainerLayout);
            this.Controls.Add(this.topFlowLayout);
            this.Controls.Add(this.leftFlowLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExFile";
            this.Size = new System.Drawing.Size(454, 125);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.topFlowLayout.ResumeLayout(false);
            this.topFlowLayout.PerformLayout();
            this.leftFlowLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDgvLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private ColorWithAlpha colorWithAlpha1;
        private ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.FlowLayoutPanel topFlowLayout;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.FlowLayoutPanel leftFlowLayout;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Panel mainContainerLayout;
        private System.Windows.Forms.PictureBox picDgvLoading;
        private System.Windows.Forms.Label lblMsgRowNotFound;
    }
}
