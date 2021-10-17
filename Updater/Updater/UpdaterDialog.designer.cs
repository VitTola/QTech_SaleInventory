using System.ComponentModel;


namespace Updater
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
            this.label5 = new System.Windows.Forms.Label();
            this._lblVersion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this._lblrootname = new System.Windows.Forms.Label();
            this._lblFileSize = new System.Windows.Forms.Label();
            this._lblTransferRate = new System.Windows.Forms.Label();
            this._lblDownloaded = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "កំពុងធ្វើបច្ចុប្បន្នភាព QTech Sale .  .  .  .  .  .";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblVersion
            // 
            this._lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lblVersion.ForeColor = System.Drawing.Color.Blue;
            this._lblVersion.Location = new System.Drawing.Point(13, 42);
            this._lblVersion.Name = "_lblVersion";
            this._lblVersion.Size = new System.Drawing.Size(239, 19);
            this._lblVersion.TabIndex = 5;
            this._lblVersion.Text = "ជំនាន់កម្មវិធី";
            this._lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Updater.Properties.Resources.UpateIcon;
            this.pictureBox2.Location = new System.Drawing.Point(259, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 113);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(334, 11);
            this.progressBar.TabIndex = 7;
            // 
            // _lblrootname
            // 
            this._lblrootname.AutoSize = true;
            this._lblrootname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lblrootname.ForeColor = System.Drawing.Color.Blue;
            this._lblrootname.Location = new System.Drawing.Point(12, 91);
            this._lblrootname.Name = "_lblrootname";
            this._lblrootname.Size = new System.Drawing.Size(65, 19);
            this._lblrootname.TabIndex = 8;
            this._lblrootname.Text = "ជំនាន់កម្មវិធី";
            this._lblrootname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblFileSize
            // 
            this._lblFileSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lblFileSize.ForeColor = System.Drawing.Color.Blue;
            this._lblFileSize.Location = new System.Drawing.Point(249, 91);
            this._lblFileSize.Name = "_lblFileSize";
            this._lblFileSize.Size = new System.Drawing.Size(95, 19);
            this._lblFileSize.TabIndex = 9;
            this._lblFileSize.Text = "100k/b";
            this._lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblTransferRate
            // 
            this._lblTransferRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lblTransferRate.ForeColor = System.Drawing.Color.Blue;
            this._lblTransferRate.Location = new System.Drawing.Point(253, 127);
            this._lblTransferRate.Name = "_lblTransferRate";
            this._lblTransferRate.Size = new System.Drawing.Size(91, 19);
            this._lblTransferRate.TabIndex = 10;
            this._lblTransferRate.Text = "1000kb/s";
            this._lblTransferRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblDownloaded
            // 
            this._lblDownloaded.AutoSize = true;
            this._lblDownloaded.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lblDownloaded.ForeColor = System.Drawing.Color.Blue;
            this._lblDownloaded.Location = new System.Drawing.Point(12, 127);
            this._lblDownloaded.Name = "_lblDownloaded";
            this._lblDownloaded.Size = new System.Drawing.Size(53, 19);
            this._lblDownloaded.TabIndex = 11;
            this._lblDownloaded.Text = "20mp/s";
            this._lblDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdaterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 157);
            this.Controls.Add(this._lblDownloaded);
            this.Controls.Add(this._lblTransferRate);
            this.Controls.Add(this._lblFileSize);
            this.Controls.Add(this._lblrootname);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._lblVersion);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Hanuman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblVersion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label _lblrootname;
        private System.Windows.Forms.Label _lblFileSize;
        private System.Windows.Forms.Label _lblTransferRate;
        private System.Windows.Forms.Label _lblDownloaded;
    }
}