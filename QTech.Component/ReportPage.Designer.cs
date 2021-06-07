namespace Storm.Component
{
    partial class ReportPage
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.reportGroupsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.reportFormContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 408);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // reportGroupsContainer
            // 
            this.reportGroupsContainer.AutoScroll = true;
            this.reportGroupsContainer.BackColor = System.Drawing.Color.White;
            this.reportGroupsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGroupsContainer.Location = new System.Drawing.Point(0, 0);
            this.reportGroupsContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportGroupsContainer.Name = "reportGroupsContainer";
            this.reportGroupsContainer.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.reportGroupsContainer.Size = new System.Drawing.Size(226, 79);
            this.reportGroupsContainer.TabIndex = 0;
            // 
            // reportFormContainer
            // 
            this.reportFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportFormContainer.Location = new System.Drawing.Point(0, 0);
            this.reportFormContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportFormContainer.Name = "reportFormContainer";
            this.reportFormContainer.Size = new System.Drawing.Size(226, 79);
            this.reportFormContainer.TabIndex = 0;
            // 
            // ReportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 79);
            this.Controls.Add(this.reportFormContainer);
            this.Controls.Add(this.reportGroupsContainer);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportPage";
            this.Text = "ReportPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel reportGroupsContainer;
        private System.Windows.Forms.Panel reportFormContainer;
    }
}