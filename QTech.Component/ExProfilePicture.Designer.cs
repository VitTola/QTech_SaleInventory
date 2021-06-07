namespace QTech.Component
{
    partial class ExProfilePicture
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
            this.menuLayout = new System.Windows.Forms.Panel();
            this.picRemove = new QTech.Component.ExLoadingImageButton();
            this.picDownload = new QTech.Component.ExLoadingImageButton();
            this.picEdit = new QTech.Component.ExLoadingImageButton();
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.menuLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuLayout
            // 
            this.menuLayout.BackColor = System.Drawing.Color.Transparent;
            this.menuLayout.Controls.Add(this.picRemove);
            this.menuLayout.Controls.Add(this.picDownload);
            this.menuLayout.Controls.Add(this.picEdit);
            this.menuLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuLayout.Location = new System.Drawing.Point(0, 129);
            this.menuLayout.Name = "menuLayout";
            this.menuLayout.Size = new System.Drawing.Size(114, 20);
            this.menuLayout.TabIndex = 10;
            // 
            // picRemove
            // 
            this.picRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picRemove.BackColor = System.Drawing.Color.Transparent;
            this.picRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRemove.Executing = false;
            this.picRemove.Image = global::QTech.Component.Properties.Resources.rubbish;
            this.picRemove.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picRemove.Location = new System.Drawing.Point(95, 3);
            this.picRemove.Margin = new System.Windows.Forms.Padding(0);
            this.picRemove.Name = "picRemove";
            this.picRemove.Size = new System.Drawing.Size(19, 13);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRemove.TabIndex = 7;
            this.picRemove.TabStop = false;
           // this.picRemove.Click += new System.EventHandler(this.picRemove_Click);
            // 
            // picDownload
            // 
            this.picDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picDownload.BackColor = System.Drawing.Color.Transparent;
            this.picDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDownload.Executing = false;
            this.picDownload.Image = global::QTech.Component.Properties.Resources.download;
            this.picDownload.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picDownload.Location = new System.Drawing.Point(74, 3);
            this.picDownload.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.picDownload.Name = "picDownload";
            this.picDownload.Size = new System.Drawing.Size(19, 13);
            this.picDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDownload.TabIndex = 8;
            this.picDownload.TabStop = false;
           // this.picDownload.Click += new System.EventHandler(this.picDownload_Click);
            // 
            // picEdit
            // 
            this.picEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picEdit.BackColor = System.Drawing.Color.Transparent;
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Executing = false;
            this.picEdit.Image = global::QTech.Component.Properties.Resources.openFolder;
            this.picEdit.LoadingImage = global::QTech.Component.Properties.Resources.spin;
            this.picEdit.Location = new System.Drawing.Point(53, 3);
            this.picEdit.Margin = new System.Windows.Forms.Padding(0);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(19, 13);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEdit.TabIndex = 9;
            this.picEdit.TabStop = false;
           // this.picEdit.Click += new System.EventHandler(this.profilePicture_Click);
            // 
            // profilePicture
            // 
            this.profilePicture.BackColor = System.Drawing.Color.WhiteSmoke;
            this.profilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profilePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePicture.ErrorImage = global::QTech.Component.Properties.Resources.photoPlaceHolder;
            this.profilePicture.Image = global::QTech.Component.Properties.Resources.photoPlaceHolder;
            this.profilePicture.InitialImage = global::QTech.Component.Properties.Resources.photoPlaceHolder;
            this.profilePicture.Location = new System.Drawing.Point(0, 0);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(114, 129);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            //this.profilePicture.Click += new System.EventHandler(this.profilePicture_Click);
            // 
            // ExProfilePicture
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.menuLayout);
            this.Name = "ExProfilePicture";
            this.Size = new System.Drawing.Size(114, 149);
            this.menuLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private QTech.Component.ExLoadingImageButton picRemove;
        private QTech.Component.ExLoadingImageButton picDownload;
        private QTech.Component.ExLoadingImageButton picEdit;
        private System.Windows.Forms.Panel menuLayout;
    }
}
