namespace QTech.Forms
{
    partial class frmProduct
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
            this.lblName = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUnitPrice_ = new QTech.Component.ExLabel();
            this.lblNote = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblCategorys = new QTech.Component.ExLabel();
            this.cboCategory = new QTech.Component.ExSearchCombo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtImportPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.panel2);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.panel1);
            this.container.Controls.Add(this.cboCategory);
            this.container.Controls.Add(this.lblCategorys);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.lblUnitPrice_);
            this.container.Controls.Add(this.lblName);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(378, 272);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 24);
            this.lblName.Name = "lblName";
            this.lblName.Required = true;
            this.lblName.Size = new System.Drawing.Size(43, 19);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "ឈ្មោះ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(142, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 0;
            // 
            // lblUnitPrice_
            // 
            this.lblUnitPrice_.AutoSize = true;
            this.lblUnitPrice_.Location = new System.Drawing.Point(24, 123);
            this.lblUnitPrice_.Name = "lblUnitPrice_";
            this.lblUnitPrice_.Required = true;
            this.lblUnitPrice_.Size = new System.Drawing.Size(68, 19);
            this.lblUnitPrice_.TabIndex = 22;
            this.lblUnitPrice_.Text = "តម្លៃរាយ/m³";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(24, 156);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(41, 19);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "ចំណាំ";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(142, 153);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 58);
            this.txtNote.TabIndex = 4;
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 235);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(376, 36);
            this.exPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(372, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(295, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Location = new System.Drawing.Point(216, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCategorys
            // 
            this.lblCategorys.AutoSize = true;
            this.lblCategorys.Location = new System.Drawing.Point(24, 57);
            this.lblCategorys.Name = "lblCategorys";
            this.lblCategorys.Required = true;
            this.lblCategorys.Size = new System.Drawing.Size(44, 19);
            this.lblCategorys.TabIndex = 27;
            this.lblCategorys.Text = "ប្រភេទ";
            // 
            // cboCategory
            // 
            this.cboCategory.Choose = "";
            this.cboCategory.CustomSearchForm = null;
            this.cboCategory.DataSourceFn = null;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.IsGirdViewColumn = false;
            this.cboCategory.LoadAll = true;
            this.cboCategory.Location = new System.Drawing.Point(142, 54);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.SearchParamFn = null;
            this.cboCategory.SelectedItems = null;
            this.cboCategory.SelectedObject = null;
            this.cboCategory.ShowAll = false;
            this.cboCategory.Size = new System.Drawing.Size(200, 27);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.TextAll = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(142, 120);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 29;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(0, 2);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPrice.Multiline = true;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(154, 23);
            this.txtUnitPrice.TabIndex = 0;
            this.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "USD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtImportPrice);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(142, 87);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(200, 27);
            this.panel2.TabIndex = 31;
            // 
            // txtImportPrice
            // 
            this.txtImportPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImportPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImportPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportPrice.Location = new System.Drawing.Point(0, 2);
            this.txtImportPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtImportPrice.Multiline = true;
            this.txtImportPrice.Name = "txtImportPrice";
            this.txtImportPrice.Size = new System.Drawing.Size(154, 23);
            this.txtImportPrice.TabIndex = 0;
            this.txtImportPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "USD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(23, 90);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(80, 19);
            this.exLabel1.TabIndex = 30;
            this.exLabel1.Text = "តម្លៃនាំចូល/m³";
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 292);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProduct";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel lblName;
        private System.Windows.Forms.TextBox txtName;
        private Component.ExLabel lblUnitPrice_;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblCategorys;
        private Component.ExSearchCombo cboCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtImportPrice;
        private System.Windows.Forms.Label label2;
        private Component.ExLabel exLabel1;
    }
}