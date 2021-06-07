namespace QTech.Component
{
    partial class ReportDatePicker
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
            this.cbo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbo
            // 
            this.cbo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo.DropDownWidth = 300;
            this.cbo.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(0, 0);
            this.cbo.Margin = new System.Windows.Forms.Padding(0);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(200, 48);
            this.cbo.TabIndex = 0;
            // 
            // ReportDatePicker
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.cbo);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReportDatePicker";
            this.Size = new System.Drawing.Size(200, 27);
            this.Load += new System.EventHandler(this.ReportDatePicker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo;
    }
}
