namespace QTech.Component
{
    partial class ExToast
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
            this.img = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.SystemColors.Window;
            this.container.Controls.Add(this.label1);
            this.container.Controls.Add(this.img);
            this.container.Size = new System.Drawing.Size(320, 129);
            this.container.Text = "container";
            // 
            // img
            // 
            this.img.Location = new System.Drawing.Point(22, 40);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(48, 48);
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(123)))));
            this.label1.Location = new System.Drawing.Point(73, 40);
            this.label1.MaximumSize = new System.Drawing.Size(220, 48);
            this.label1.MinimumSize = new System.Drawing.Size(220, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "ព្រះរាជាណាចក្រកម្ពុជា ជាតិសាសនា ព្រះមហាក្សត្រ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExToast";
            this.ShowIcon = false;
            this.Text = "ព័ត៌មាន";
            this.Load += new System.EventHandler(this.ExToast_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Label label1;
    }
}
