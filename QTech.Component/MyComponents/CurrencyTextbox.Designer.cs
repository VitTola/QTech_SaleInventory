namespace QTech.Component.MyComponents
{
    partial class CurrencyTextboxPanel
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblCur1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(183, 27);
            this.txtValue.TabIndex = 0;
            // 
            // lblCur1
            // 
            this.lblCur1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCur1.Location = new System.Drawing.Point(189, 0);
            this.lblCur1.Name = "lblCur1";
            this.lblCur1.Size = new System.Drawing.Size(44, 27);
            this.lblCur1.TabIndex = 2;
            this.lblCur1.Text = "USD";
            this.lblCur1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrencyTextboxPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCur1);
            this.Controls.Add(this.txtValue);
            this.Name = "CurrencyTextboxPanel";
            this.Size = new System.Drawing.Size(233, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblCur1;
    }
}
