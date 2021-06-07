namespace QTech.Component
{
    partial class ExTextboxPattern
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
            this.button = new System.Windows.Forms.Panel();
            this.txtSearch = new QTech.Component.ExRichTextBox();
            this.menuPattern = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button.BackgroundImage = global::QTech.Component.Properties.Resources.icon_search;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button.Location = new System.Drawing.Point(131, 1);
            this.button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(25, 23);
            this.button.TabIndex = 1;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(3, 2);
            this.txtSearch.MaxLength = 250;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtSearch.Size = new System.Drawing.Size(126, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // menuPattern
            // 
            this.menuPattern.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.menuPattern.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.menuPattern.Name = "menuPattern";
            this.menuPattern.Size = new System.Drawing.Size(61, 4);
            // 
            // ExTextboxPattern
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.button);
            this.Name = "ExTextboxPattern";
            this.Size = new System.Drawing.Size(154, 26);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel button;
        private ExRichTextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip menuPattern;
    }
}
