namespace QTech.Forms
{
    partial class ReportViewPage
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
            this.exLabel1 = new QTech.Component.ExLabel();
            this.SuspendLayout();
            // 
            // exLabel1
            // 
            this.exLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exLabel1.Font = new System.Drawing.Font("Khmer OS Battambang", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exLabel1.Location = new System.Drawing.Point(0, 0);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(800, 450);
            this.exLabel1.TabIndex = 0;
            this.exLabel1.Text = "របាយការណ៍កំពុងធ្វើ..................\r\n";
            this.exLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exLabel1.Click += new System.EventHandler(this.exLabel1_Click);
            // 
            // ReportViewPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exLabel1);
            this.Name = "ReportViewPage";
            this.Text = "ReportViewPage";
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel exLabel1;
    }
}