namespace QTech.Component
{
    partial class ExReportViewer
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
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pdfViewer = new QTech.Component.ExPdfReportViewer();
            this.panel = new System.Windows.Forms.Panel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = -1;
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewer.Location = new System.Drawing.Point(0, 0);
            this.crViewer.Name = "crViewer";
            this.crViewer.Size = new System.Drawing.Size(793, 522);
            this.crViewer.TabIndex = 0;
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.pdfViewer.Report = null;
            this.pdfViewer.Size = new System.Drawing.Size(793, 522);
            this.pdfViewer.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel.Controls.Add(this.picLoading);
            this.panel.Location = new System.Drawing.Point(346, 211);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(5);
            this.panel.Size = new System.Drawing.Size(100, 100);
            this.panel.TabIndex = 2;
            // 
            // picLoading
            // 
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoading.Image = global::QTech.Component.Properties.Resources.dgvloading;
            this.picLoading.Location = new System.Drawing.Point(5, 5);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(90, 90);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 0;
            this.picLoading.TabStop = false;
            // 
            // ExReportViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.crViewer);
            this.Name = "ExReportViewer";
            this.Size = new System.Drawing.Size(793, 522);
            this.Load += new System.EventHandler(this.ExReportViewer_Load);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewer;
        private ExPdfReportViewer pdfViewer;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox picLoading;
    }
}
