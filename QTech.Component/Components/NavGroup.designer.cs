namespace QTech.Component
{
    partial class NavGroup
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
            this._body = new System.Windows.Forms.Panel();
            this._title = new QTech.Component.NavItem();
            this.SuspendLayout();
            // 
            // _body
            // 
            this._body.Dock = System.Windows.Forms.DockStyle.Fill;
            this._body.Location = new System.Drawing.Point(0, 29);
            this._body.Name = "_body";
            this._body.Size = new System.Drawing.Size(220, 177);
            this._body.TabIndex = 7;
            this._body.VisibleChanged += new System.EventHandler(this.body_VisibleChanged);
            // 
            // _title
            // 
            this._title._IsCheck = false;
            this._title.AutoEllipsis = true;
            this._title.AutoSize = true;
            this._title.BackColor = System.Drawing.Color.LightGray;
            this._title.ColorBgSelected = System.Drawing.Color.DarkGray;
            this._title.Cursor = System.Windows.Forms.Cursors.Hand;
            this._title.Dock = System.Windows.Forms.DockStyle.Top;
            this._title.FlatAppearance.BorderSize = 0;
            this._title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._title.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._title.ForeColor = System.Drawing.Color.Black;
            this._title.HoverColor = System.Drawing.Color.Red;
            this._title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._title.LeaveColor = System.Drawing.Color.Black;
            this._title.Location = new System.Drawing.Point(0, 0);
            this._title.Name = "_title";
            this._title.NonSelected = System.Drawing.Color.Black;
            this._title.Selected = System.Drawing.Color.Black;
            this._title.Size = new System.Drawing.Size(220, 29);
            this._title.TabIndex = 6;
            this._title.Text = " Group";
            this._title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._title.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._title.UseVisualStyleBackColor = false;
            this._title.Click += new System.EventHandler(this._title_Click);
            this._title.MouseEnter += new System.EventHandler(this._title_MouseEnter);
            this._title.MouseLeave += new System.EventHandler(this._title_MouseLeave);
            // 
            // NavGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._body);
            this.Controls.Add(this._title);
            this.Name = "NavGroup";
            this.Size = new System.Drawing.Size(220, 206);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel _body;
        public NavItem _title;
    }
}
