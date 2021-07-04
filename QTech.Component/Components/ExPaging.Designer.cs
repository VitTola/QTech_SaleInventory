namespace QTech.Component
{
    partial class ExPaging
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
            this.lblNextPaging = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPreviousPaging = new System.Windows.Forms.LinkLabel();
            this.lblShowAllPaging = new System.Windows.Forms.LinkLabel();
            this._lblCurrentPage = new QTech.Component.ExLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNextPaging
            // 
            this.lblNextPaging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNextPaging.AutoSize = true;
            this.lblNextPaging.Image = global::QTech.Component.Properties.Resources.Forward;
            this.lblNextPaging.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNextPaging.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblNextPaging.Location = new System.Drawing.Point(109, 5);
            this.lblNextPaging.Margin = new System.Windows.Forms.Padding(3, 5, 10, 0);
            this.lblNextPaging.Name = "lblNextPaging";
            this.lblNextPaging.Padding = new System.Windows.Forms.Padding(0, 4, 20, 0);
            this.lblNextPaging.Size = new System.Drawing.Size(81, 23);
            this.lblNextPaging.TabIndex = 1;
            this.lblNextPaging.TabStop = true;
            this.lblNextPaging.Text = "មើលបន្ទាប់";
            this.lblNextPaging.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNextPaging__LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblPreviousPaging);
            this.flowLayoutPanel1.Controls.Add(this.lblNextPaging);
            this.flowLayoutPanel1.Controls.Add(this.lblShowAllPaging);
            this.flowLayoutPanel1.Controls.Add(this._lblCurrentPage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 33);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblPreviousPaging
            // 
            this.lblPreviousPaging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPreviousPaging.AutoSize = true;
            this.lblPreviousPaging.Image = global::QTech.Component.Properties.Resources.Backward;
            this.lblPreviousPaging.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblPreviousPaging.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPreviousPaging.Location = new System.Drawing.Point(3, 5);
            this.lblPreviousPaging.Margin = new System.Windows.Forms.Padding(3, 5, 10, 0);
            this.lblPreviousPaging.Name = "lblPreviousPaging";
            this.lblPreviousPaging.Padding = new System.Windows.Forms.Padding(20, 4, 0, 0);
            this.lblPreviousPaging.Size = new System.Drawing.Size(93, 23);
            this.lblPreviousPaging.TabIndex = 2;
            this.lblPreviousPaging.TabStop = true;
            this.lblPreviousPaging.Text = "ត្រលប់ក្រោយ";
            this.lblPreviousPaging.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPreviousPaging_LinkClicked);
            // 
            // lblShowAllPaging
            // 
            this.lblShowAllPaging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShowAllPaging.AutoSize = true;
            this.lblShowAllPaging.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblShowAllPaging.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblShowAllPaging.Location = new System.Drawing.Point(203, 5);
            this.lblShowAllPaging.Margin = new System.Windows.Forms.Padding(3, 5, 10, 0);
            this.lblShowAllPaging.Name = "lblShowAllPaging";
            this.lblShowAllPaging.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblShowAllPaging.Size = new System.Drawing.Size(81, 23);
            this.lblShowAllPaging.TabIndex = 3;
            this.lblShowAllPaging.TabStop = true;
            this.lblShowAllPaging.Text = "បង្ហាញទាំងអស់";
            this.lblShowAllPaging.Visible = false;
            this.lblShowAllPaging.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowAllPaging_LinkClicked);
            // 
            // _lblCurrentPage
            // 
            this._lblCurrentPage.AutoSize = true;
            this._lblCurrentPage.Location = new System.Drawing.Point(297, 5);
            this._lblCurrentPage.Margin = new System.Windows.Forms.Padding(3, 5, 10, 0);
            this._lblCurrentPage.Name = "_lblCurrentPage";
            this._lblCurrentPage.Padding = new System.Windows.Forms.Padding(0, 4, 20, 0);
            this._lblCurrentPage.Required = false;
            this._lblCurrentPage.Size = new System.Drawing.Size(66, 23);
            this._lblCurrentPage.TabIndex = 4;
            this._lblCurrentPage.Text = "ទំព័រទី៖";
            // 
            // ExPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(380, 33);
            this.Name = "ExPaging";
            this.Size = new System.Drawing.Size(380, 33);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblNextPaging;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel lblPreviousPaging;
        private System.Windows.Forms.LinkLabel lblShowAllPaging;
        private ExLabel _lblCurrentPage;
    }
}
