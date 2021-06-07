namespace QTech.Component
{
    partial class ExTextboxSearch
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
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new QTech.Component.PlaceholderTextBox();
            this.button = new System.Windows.Forms.Panel();
            this.imgPattern = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuPattern = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgPattern)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(2, 4);
            this.txtSearch.MaxLength = 250;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceHolder = "";
            this.txtSearch.Size = new System.Drawing.Size(175, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // button
            // 
            this.button.BackgroundImage = global::QTech.Component.Properties.Resources.icon_search;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.Dock = System.Windows.Forms.DockStyle.Right;
            this.button.Location = new System.Drawing.Point(197, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(25, 26);
            this.button.TabIndex = 1;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // imgPattern
            // 
            this.imgPattern.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgPattern.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgPattern.Location = new System.Drawing.Point(0, 0);
            this.imgPattern.Name = "imgPattern";
            this.imgPattern.Size = new System.Drawing.Size(20, 26);
            this.imgPattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPattern.TabIndex = 2;
            this.imgPattern.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 0, 0);
            this.panel1.Size = new System.Drawing.Size(177, 26);
            this.panel1.TabIndex = 3;
            // 
            // menuPattern
            // 
            this.menuPattern.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.menuPattern.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.menuPattern.Name = "menuPattern";
            this.menuPattern.Size = new System.Drawing.Size(61, 4);
            // 
            // ExTextboxSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgPattern);
            this.Controls.Add(this.button);
            this.Name = "ExTextboxSearch";
            this.Size = new System.Drawing.Size(222, 26);
            ((System.ComponentModel.ISupportInitialize)(this.imgPattern)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PlaceholderTextBox txtSearch;
        private System.Windows.Forms.Panel button;
        private System.Windows.Forms.PictureBox imgPattern;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip menuPattern;
    }
}
