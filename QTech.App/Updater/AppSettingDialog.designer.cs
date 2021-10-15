using System.ComponentModel;


namespace QTech.Forms
{
    partial class AppSettingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettingDialog));
            this.txtUserName = new QTech.Component.ExInputTextBox();
            this.txtPassword = new QTech.Component.ExInputTextBox();
            this.exPanel = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.container.SuspendLayout();
            this.exPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.exPanel);
            this.container.Controls.Add(this.txtPassword);
            this.container.Controls.Add(this.txtUserName);
            this.container.Size = new System.Drawing.Size(534, 181);
            this.container.Text = "container";
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.container_Paint);
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUserName.BorderColor = System.Drawing.Color.Gray;
            this.txtUserName.Location = new System.Drawing.Point(179, 28);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(308, 27);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(179, 61);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(308, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // exPanel
            // 
            this.exPanel.BackColor = System.Drawing.Color.Transparent;
            this.exPanel.Controls.Add(this.flowLayoutPanel3);
            this.exPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel.Location = new System.Drawing.Point(1, 144);
            this.exPanel.Name = "exPanel";
            this.exPanel.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel.Size = new System.Drawing.Size(532, 36);
            this.exPanel.TabIndex = 22;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.btnClose);
            this.flowLayoutPanel3.Controls.Add(this.btnSave);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(4, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(526, 32);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnClose.Location = new System.Drawing.Point(449, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnSave.Location = new System.Drawing.Point(345, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = "S";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(30, 31);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(129, 19);
            this.exLabel1.TabIndex = 23;
            this.exLabel1.Text = "តំណភ្ជាប់ទាញយកកម្មវិធី";
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Location = new System.Drawing.Point(30, 64);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = true;
            this.exLabel2.Size = new System.Drawing.Size(68, 19);
            this.exLabel2.TabIndex = 24;
            this.exLabel2.Text = "ជំនាន់កម្មវិធី";
            // 
            // AppSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 201);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettingDialog";
            this.Text = "កំណត់ App Settings";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.exPanel.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExInputTextBox txtPassword;
        private Component.ExInputTextBox txtUserName;
        private QTech.Component.Components.ExPanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private QTech.Component.ExButtonLoading btnClose;
        private QTech.Component.ExButtonLoading btnSave;
        private Component.ExLabel exLabel1;
        private Component.ExLabel exLabel2;
    }
}