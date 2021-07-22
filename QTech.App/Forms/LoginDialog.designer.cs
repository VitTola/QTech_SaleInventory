using System.ComponentModel;


namespace QTech.Forms
{
    partial class LoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.txtUserName = new QTech.Component.ExInputTextBox();
            this.txtPassword = new QTech.Component.ExInputTextBox();
            this.picKeyLogin = new System.Windows.Forms.PictureBox();
            this._lblEmail = new System.Windows.Forms.Label();
            this._lblPassword = new System.Windows.Forms.Label();
            this.btnServerUrlSetting = new System.Windows.Forms.PictureBox();
            this.exPanel = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnLogin = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKeyLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnServerUrlSetting)).BeginInit();
            this.exPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.exPanel);
            this.container.Controls.Add(this._lblPassword);
            this.container.Controls.Add(this._lblEmail);
            this.container.Controls.Add(this.txtPassword);
            this.container.Controls.Add(this.txtUserName);
            this.container.Controls.Add(this.picKeyLogin);
            this.container.Size = new System.Drawing.Size(347, 144);
            this.container.Text = "container";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUserName.BorderColor = System.Drawing.Color.Gray;
            this.txtUserName.Location = new System.Drawing.Point(139, 23);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(185, 27);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(139, 53);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // picKeyLogin
            // 
            this.picKeyLogin.Image = global::QTech.Properties.Resources.login;
            this.picKeyLogin.Location = new System.Drawing.Point(17, 23);
            this.picKeyLogin.Name = "picKeyLogin";
            this.picKeyLogin.Size = new System.Drawing.Size(49, 54);
            this.picKeyLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picKeyLogin.TabIndex = 5;
            this.picKeyLogin.TabStop = false;
            // 
            // _lblEmail
            // 
            this._lblEmail.AutoSize = true;
            this._lblEmail.Location = new System.Drawing.Point(60, 27);
            this._lblEmail.Name = "_lblEmail";
            this._lblEmail.Size = new System.Drawing.Size(72, 19);
            this._lblEmail.TabIndex = 7;
            this._lblEmail.Text = "ឈ្មោះអ្នកប្រើ";
            // 
            // _lblPassword
            // 
            this._lblPassword.AutoSize = true;
            this._lblPassword.Location = new System.Drawing.Point(60, 57);
            this._lblPassword.Name = "_lblPassword";
            this._lblPassword.Size = new System.Drawing.Size(65, 19);
            this._lblPassword.TabIndex = 8;
            this._lblPassword.Text = "លេខសំងាត់";
            // 
            // btnServerUrlSetting
            // 
            this.btnServerUrlSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerUrlSetting.Location = new System.Drawing.Point(3, 3);
            this.btnServerUrlSetting.Name = "btnServerUrlSetting";
            this.btnServerUrlSetting.Size = new System.Drawing.Size(26, 25);
            this.btnServerUrlSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnServerUrlSetting.TabIndex = 11;
            this.btnServerUrlSetting.TabStop = false;
            // 
            // exPanel
            // 
            this.exPanel.BackColor = System.Drawing.Color.Transparent;
            this.exPanel.Controls.Add(this.flowLayoutPanel3);
            this.exPanel.Controls.Add(this.flowLayoutPanel2);
            this.exPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel.Location = new System.Drawing.Point(1, 107);
            this.exPanel.Name = "exPanel";
            this.exPanel.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel.Size = new System.Drawing.Size(345, 36);
            this.exPanel.TabIndex = 22;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.btnClose);
            this.flowLayoutPanel3.Controls.Add(this.btnLogin);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(138, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(205, 32);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(128, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.DefaultImage = null;
            this.btnLogin.Executing = false;
            this.btnLogin.Location = new System.Drawing.Point(24, 3);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnLogin.ShortcutText = null;
            this.btnLogin.Size = new System.Drawing.Size(100, 27);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "យល់ព្រម";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnServerUrlSetting);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(136, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 164);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.Text = "ចូលប្រើប្រាស់";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKeyLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnServerUrlSetting)).EndInit();
            this.exPanel.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExInputTextBox txtPassword;
        private Component.ExInputTextBox txtUserName;
        private System.Windows.Forms.Label _lblPassword;
        private System.Windows.Forms.Label _lblEmail;
        private System.Windows.Forms.PictureBox picKeyLogin;
        private System.Windows.Forms.PictureBox btnServerUrlSetting;
        private QTech.Component.Components.ExPanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private QTech.Component.ExButtonLoading btnClose;
        private QTech.Component.ExButtonLoading btnLogin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}