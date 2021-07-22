using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Linq;

namespace QTech.Component
{
    partial class ExDialog
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
            this.container = new System.Windows.Forms.Panel();
            this.digheader = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._bClose = new QTech.Component.CotrolDialogButton();
            this._bMaximize = new QTech.Component.CotrolDialogButton();
            this._bMinimize = new QTech.Component.CotrolDialogButton();
            this.bar = new System.Windows.Forms.ProgressBar();
            this._lblTITLE = new System.Windows.Forms.Label();
            this.imgICON = new System.Windows.Forms.PictureBox();
            this.digheader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgICON)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.Transparent;
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 20);
            this.container.Margin = new System.Windows.Forms.Padding(0);
            this.container.Name = "container";
            this.container.Padding = new System.Windows.Forms.Padding(1);
            this.container.Size = new System.Drawing.Size(1290, 727);
            this.container.TabIndex = 0;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.container_Paint);
            this.container.Resize += new System.EventHandler(this.container_Resize);
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.Transparent;
            this.digheader.Border = true;
            this.digheader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.digheader.Colors.Add(this.colorWithAlpha1);
            this.digheader.Colors.Add(this.colorWithAlpha2);
            this.digheader.Colors.Add(this.colorWithAlpha3);
            this.digheader.ContentPadding = new System.Windows.Forms.Padding(0);
            this.digheader.Controls.Add(this.flowLayoutPanel1);
            this.digheader.Controls.Add(this.bar);
            this.digheader.Controls.Add(this._lblTITLE);
            this.digheader.Controls.Add(this.imgICON);
            this.digheader.CornerRadius = 10;
            this.digheader.Corners = ((QTech.Component.Corners)((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight)));
            this.digheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.digheader.Gradient = true;
            this.digheader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.digheader.GradientOffset = 1F;
            this.digheader.GradientSize = new System.Drawing.Size(0, 0);
            this.digheader.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.digheader.Grayscale = false;
            this.digheader.Image = null;
            this.digheader.ImageAlpha = 75;
            this.digheader.ImagePadding = new System.Windows.Forms.Padding(5);
            this.digheader.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.digheader.ImageSize = new System.Drawing.Size(48, 48);
            this.digheader.Location = new System.Drawing.Point(0, 0);
            this.digheader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.digheader.Name = "digheader";
            this.digheader.Rounded = true;
            this.digheader.Size = new System.Drawing.Size(1290, 20);
            this.digheader.TabIndex = 1;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.colorWithAlpha1.Parent = this.digheader;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.colorWithAlpha2.Parent = this.digheader;
            // 
            // colorWithAlpha3
            // 
            this.colorWithAlpha3.Alpha = 255;
            this.colorWithAlpha3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.colorWithAlpha3.Parent = this.digheader;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this._bClose);
            this.flowLayoutPanel1.Controls.Add(this._bMaximize);
            this.flowLayoutPanel1.Controls.Add(this._bMinimize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1222, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(68, 18);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // _bClose
            // 
            this._bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bClose.BackColor = System.Drawing.Color.Transparent;
            this._bClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._bClose.FlatAppearance.BorderSize = 0;
            this._bClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._bClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bClose.Location = new System.Drawing.Point(48, 3);
            this._bClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this._bClose.Name = "_bClose";
            this._bClose.Size = new System.Drawing.Size(15, 15);
            this._bClose.TabIndex = 3;
            this._bClose.TabStop = false;
            this._bClose.UseVisualStyleBackColor = false;
            // 
            // _bMaximize
            // 
            this._bMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bMaximize.BackColor = System.Drawing.Color.Transparent;
            this._bMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this._bMaximize.FlatAppearance.BorderSize = 0;
            this._bMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._bMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._bMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bMaximize.Location = new System.Drawing.Point(27, 3);
            this._bMaximize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this._bMaximize.Name = "_bMaximize";
            this._bMaximize.Size = new System.Drawing.Size(15, 15);
            this._bMaximize.TabIndex = 4;
            this._bMaximize.TabStop = false;
            this._bMaximize.UseVisualStyleBackColor = false;
            // 
            // _bMinimize
            // 
            this._bMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bMinimize.BackColor = System.Drawing.Color.Transparent;
            this._bMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this._bMinimize.FlatAppearance.BorderSize = 0;
            this._bMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this._bMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this._bMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bMinimize.Location = new System.Drawing.Point(6, 3);
            this._bMinimize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this._bMinimize.Name = "_bMinimize";
            this._bMinimize.Size = new System.Drawing.Size(15, 15);
            this._bMinimize.TabIndex = 2;
            this._bMinimize.TabStop = false;
            this._bMinimize.UseVisualStyleBackColor = false;
            // 
            // bar
            // 
            this.bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar.Location = new System.Drawing.Point(0, 18);
            this.bar.Maximum = 10000;
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1290, 2);
            this.bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bar.TabIndex = 0;
            this.bar.Value = 9999;
            this.bar.Visible = false;
            // 
            // _lblTITLE
            // 
            this._lblTITLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblTITLE.BackColor = System.Drawing.Color.Transparent;
            this._lblTITLE.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTITLE.ForeColor = System.Drawing.Color.White;
            this._lblTITLE.Location = new System.Drawing.Point(24, 1);
            this._lblTITLE.Name = "_lblTITLE";
            this._lblTITLE.Size = new System.Drawing.Size(1242, 19);
            this._lblTITLE.TabIndex = 1;
            this._lblTITLE.Text = "ឃ្យូតិច";
            this._lblTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgICON
            // 
            this.imgICON.BackColor = System.Drawing.Color.Transparent;
            this.imgICON.Location = new System.Drawing.Point(5, 2);
            this.imgICON.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgICON.Name = "imgICON";
            this.imgICON.Size = new System.Drawing.Size(16, 17);
            this.imgICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgICON.TabIndex = 0;
            this.imgICON.TabStop = false;
            this.imgICON.Visible = false;
            // 
            // ExDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1290, 747);
            this.Controls.Add(this.container);
            this.Controls.Add(this.digheader);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HDialog";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.SizeChanged += new System.EventHandler(this.HDialog_SizeChanged);
            this.digheader.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgICON)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GRAPanel digheader;
        private System.Windows.Forms.PictureBox imgICON;
        private System.Windows.Forms.Label _lblTITLE;
        private CotrolDialogButton _bMinimize;
        private CotrolDialogButton _bMaximize;
        private CotrolDialogButton _bClose;
        private ColorWithAlpha colorWithAlpha1;
        private ColorWithAlpha colorWithAlpha2;
        private ColorWithAlpha colorWithAlpha3;
        public System.Windows.Forms.Panel container;
        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        //private System.Windows.Forms.ProgressBar bar;
        //private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}