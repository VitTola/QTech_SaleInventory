namespace QTech.Forms
{
    partial class frmUser
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
            this.components = new System.ComponentModel.Container();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this._lblAccount = new QTech.Component.ExLabel();
            this._lblPassword = new QTech.Component.ExLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grbPermission = new System.Windows.Forms.GroupBox();
            this.trvPermission = new QTech.Component.TriStateTreeView();
            this.exPanel = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._lblUserName = new QTech.Component.ExLabel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblNote = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.container.SuspendLayout();
            this.grbPermission.SuspendLayout();
            this.exPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.container.Controls.Add(this.txtConfirmPassword);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this._lblUserName);
            this.container.Controls.Add(this.txtUserName);
            this.container.Controls.Add(this.exPanel);
            this.container.Controls.Add(this.grbPermission);
            this.container.Controls.Add(this._lblAccount);
            this.container.Controls.Add(this._lblPassword);
            this.container.Controls.Add(this.txtPassword);
            this.container.Controls.Add(this.txtAccount);
            this.container.Dock = System.Windows.Forms.DockStyle.None;
            this.container.Margin = new System.Windows.Forms.Padding(2);
            this.container.Size = new System.Drawing.Size(920, 600);
            this.container.Text = "container";
            // 
            // txtAccount
            // 
            this.txtAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAccount.Location = new System.Drawing.Point(129, 27);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccount.MaxLength = 200;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(200, 27);
            this.txtAccount.TabIndex = 0;
            // 
            // _lblAccount
            // 
            this._lblAccount.AutoSize = true;
            this._lblAccount.Location = new System.Drawing.Point(20, 31);
            this._lblAccount.Margin = new System.Windows.Forms.Padding(2);
            this._lblAccount.Name = "_lblAccount";
            this._lblAccount.Required = true;
            this._lblAccount.Size = new System.Drawing.Size(76, 19);
            this._lblAccount.TabIndex = 17;
            this._lblAccount.Text = "ឈ្មោះគណនី";
            // 
            // _lblPassword
            // 
            this._lblPassword.AutoSize = true;
            this._lblPassword.BackColor = System.Drawing.SystemColors.Control;
            this._lblPassword.Location = new System.Drawing.Point(20, 61);
            this._lblPassword.Margin = new System.Windows.Forms.Padding(2);
            this._lblPassword.Name = "_lblPassword";
            this._lblPassword.Required = true;
            this._lblPassword.Size = new System.Drawing.Size(68, 19);
            this._lblPassword.TabIndex = 40;
            this._lblPassword.Text = "លេខសំងាត់";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(129, 58);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 1000;
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 27);
            this.txtPassword.TabIndex = 1;
            // 
            // grbPermission
            // 
            this.grbPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPermission.Controls.Add(this.trvPermission);
            this.grbPermission.Location = new System.Drawing.Point(21, 120);
            this.grbPermission.Margin = new System.Windows.Forms.Padding(2);
            this.grbPermission.Name = "grbPermission";
            this.grbPermission.Size = new System.Drawing.Size(878, 427);
            this.grbPermission.TabIndex = 7;
            this.grbPermission.TabStop = false;
            this.grbPermission.Text = "សិទ្ធិប្រើប្រាស់";
            // 
            // trvPermission
            // 
            this.trvPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.trvPermission.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvPermission.CheckBoxes = true;
            this.trvPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvPermission.Location = new System.Drawing.Point(3, 23);
            this.trvPermission.Margin = new System.Windows.Forms.Padding(2);
            this.trvPermission.Name = "trvPermission";
            this.trvPermission.PreventCheckEvent = false;
            this.trvPermission.Size = new System.Drawing.Size(872, 401);
            this.trvPermission.TabIndex = 0;
            this.trvPermission.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvPermission_BeforeCheck);
            // 
            // exPanel
            // 
            this.exPanel.BackColor = System.Drawing.Color.Transparent;
            this.exPanel.Controls.Add(this.flowLayoutPanel3);
            this.exPanel.Controls.Add(this.flowLayoutPanel2);
            this.exPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel.Location = new System.Drawing.Point(1, 563);
            this.exPanel.Name = "exPanel";
            this.exPanel.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel.Size = new System.Drawing.Size(918, 36);
            this.exPanel.TabIndex = 41;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnClose);
            this.flowLayoutPanel3.Controls.Add(this.btnSave);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(138, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(778, 32);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnClose.Location = new System.Drawing.Point(701, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(622, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = "S";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(136, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // _lblUserName
            // 
            this._lblUserName.AutoSize = true;
            this._lblUserName.Location = new System.Drawing.Point(584, 31);
            this._lblUserName.Margin = new System.Windows.Forms.Padding(2);
            this._lblUserName.Name = "_lblUserName";
            this._lblUserName.Required = true;
            this._lblUserName.Size = new System.Drawing.Size(103, 19);
            this._lblUserName.TabIndex = 43;
            this._lblUserName.Text = "ឈ្មោះអ្នកប្រើប្រាស់";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserName.Location = new System.Drawing.Point(699, 27);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.MaxLength = 200;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 27);
            this.txtUserName.TabIndex = 3;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(584, 61);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(41, 19);
            this.lblNote.TabIndex = 45;
            this.lblNote.Text = "ចំណាំ";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNote.Location = new System.Drawing.Point(699, 57);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.MaxLength = 200;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 59);
            this.txtNote.TabIndex = 4;
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.exLabel1.Location = new System.Drawing.Point(20, 92);
            this.exLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(101, 19);
            this.exLabel1.TabIndex = 47;
            this.exLabel1.Text = "បញ្ជាក់លេខសំងាត់";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPassword.Location = new System.Drawing.Point(129, 89);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.MaxLength = 1000;
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 27);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 620);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUser";
            this.Text = "តួនាទី";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.grbPermission.ResumeLayout(false);
            this.exPanel.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAccount;
        private QTech.Component.ExLabel _lblAccount;
        private QTech.Component.ExLabel _lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grbPermission;
        private Component.TriStateTreeView trvPermission;
        private Component.Components.ExPanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExLabel _lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private Component.ExLabel exLabel1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
    }
}