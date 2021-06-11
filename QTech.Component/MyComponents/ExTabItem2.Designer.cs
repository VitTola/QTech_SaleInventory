namespace QTech.Component
{
    partial class ExTabItem2
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.exPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBox.Location = new System.Drawing.Point(2, 2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(66, 47);
            this.picBox.TabIndex = 4;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCaption.ForeColor = System.Drawing.Color.Black;
            this.lblCaption.Location = new System.Drawing.Point(2, 52);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(66, 41);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaption.Click += new System.EventHandler(this.lblCaption_Click);
            this.lblCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCaption_MouseDown);
            this.lblCaption.MouseEnter += new System.EventHandler(this.lblCaption_MouseEnter);
            this.lblCaption.MouseLeave += new System.EventHandler(this.lblCaption_MouseLeave);
            this.lblCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCaption_MouseMove);
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.lblCaption);
            this.exPanel1.Controls.Add(this.picBox);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exPanel1.Location = new System.Drawing.Point(0, 0);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(70, 95);
            this.exPanel1.TabIndex = 8;
            // 
            // ExTabItem2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.exPanel1);
            this.Name = "ExTabItem2";
            this.Size = new System.Drawing.Size(70, 95);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.exPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblCaption;
        private Components.ExPanel exPanel1;
    }
}
