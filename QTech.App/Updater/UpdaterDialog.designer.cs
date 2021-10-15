using System.ComponentModel;


namespace QTech.Forms
{
    partial class UpdaterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterDialog));
            this.exLabel1 = new QTech.Component.ExLabel();
            this._lblVersion = new QTech.Component.ExLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDownloaded = new QTech.Component.ExLabel();
            this.lblTransferRate = new QTech.Component.ExLabel();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblrootname = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.lblrootname);
            this.container.Controls.Add(this.lblFileSize);
            this.container.Controls.Add(this.lblTransferRate);
            this.container.Controls.Add(this.lblDownloaded);
            this.container.Controls.Add(this.pictureBox1);
            this.container.Controls.Add(this.progressBar);
            this.container.Controls.Add(this._lblVersion);
            this.container.Controls.Add(this.exLabel1);
            this.container.Padding = new System.Windows.Forms.Padding(2);
            this.container.Size = new System.Drawing.Size(649, 250);
            this.container.Text = "container";
            // 
            // exLabel1
            // 
            this.exLabel1.ForeColor = System.Drawing.Color.Blue;
            this.exLabel1.Location = new System.Drawing.Point(27, 28);
            this.exLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(352, 32);
            this.exLabel1.TabIndex = 23;
            this.exLabel1.Text = "កំពុងធ្វើបច្ចុប្បន្នភាព QTech Sale .  .  .  .  .  .";
            // 
            // _lblVersion
            // 
            this._lblVersion.AutoSize = true;
            this._lblVersion.ForeColor = System.Drawing.Color.Blue;
            this._lblVersion.Location = new System.Drawing.Point(27, 71);
            this._lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblVersion.Name = "_lblVersion";
            this._lblVersion.Required = false;
            this._lblVersion.Size = new System.Drawing.Size(83, 24);
            this._lblVersion.TabIndex = 24;
            this._lblVersion.Text = "ជំនាន់កម្មវិធី";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 179);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(589, 13);
            this.progressBar.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QTech.Properties.Resources.UpateIcon;
            this.pictureBox1.Location = new System.Drawing.Point(465, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 141);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // lblDownloaded
            // 
            this.lblDownloaded.ForeColor = System.Drawing.Color.Blue;
            this.lblDownloaded.Location = new System.Drawing.Point(27, 209);
            this.lblDownloaded.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloaded.Name = "lblDownloaded";
            this.lblDownloaded.Required = false;
            this.lblDownloaded.Size = new System.Drawing.Size(172, 24);
            this.lblDownloaded.TabIndex = 28;
            this.lblDownloaded.Text = "0.00M(0%)";
            this.lblDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransferRate
            // 
            this.lblTransferRate.ForeColor = System.Drawing.Color.Blue;
            this.lblTransferRate.Location = new System.Drawing.Point(438, 207);
            this.lblTransferRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransferRate.Name = "lblTransferRate";
            this.lblTransferRate.Required = false;
            this.lblTransferRate.Size = new System.Drawing.Size(172, 24);
            this.lblTransferRate.TabIndex = 29;
            this.lblTransferRate.Text = "0.00kb/s";
            this.lblTransferRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileSize
            // 
            this.lblFileSize.ForeColor = System.Drawing.Color.Blue;
            this.lblFileSize.Location = new System.Drawing.Point(502, 148);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(108, 27);
            this.lblFileSize.TabIndex = 30;
            this.lblFileSize.Text = "0.00MB";
            this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblrootname
            // 
            this.lblrootname.AutoSize = true;
            this.lblrootname.ForeColor = System.Drawing.Color.Blue;
            this.lblrootname.Location = new System.Drawing.Point(27, 151);
            this.lblrootname.Name = "lblrootname";
            this.lblrootname.Size = new System.Drawing.Size(77, 24);
            this.lblrootname.TabIndex = 31;
            this.lblrootname.Text = "3.0.0..zip";
            // 
            // UpdaterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 270);
            this.Font = new System.Drawing.Font("Hanuman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterDialog";
            this.Text = "កំណត់ App Settings";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel exLabel1;
        private Component.ExLabel _lblVersion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblrootname;
        private System.Windows.Forms.Label lblFileSize;
        private Component.ExLabel lblTransferRate;
        private Component.ExLabel lblDownloaded;
    }
}