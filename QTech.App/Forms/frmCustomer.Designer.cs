namespace QTech.Forms
{
    partial class frmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colPayDate = new QTech.Component.ExPrettyDateColumn();
            this.colAmount = new QTech.Component.Components.NumericUpDownColumn();
            this.colCurrency = new QTech.Component.DropDownComboBoxColumn();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.exLabel4 = new QTech.Component.ExLabel();
            this.cboPosition = new QTech.Component.ExComboBox();
            this.container.SuspendLayout();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.cboPosition);
            this.container.Controls.Add(this.exLabel4);
            this.container.Controls.Add(this.exLabel3);
            this.container.Controls.Add(this.txtPhone);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(706, 454);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "UserId";
            this.colUserId.HeaderText = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            this.colUserId.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "FullName";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCreatedBy.DataPropertyName = "CreatedBy";
            this.colCreatedBy.HeaderText = "CreateBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn2.HeaderText = "UserId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CreatedBy";
            this.dataGridViewTextBoxColumn4.HeaderText = "CreateBy";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 0;
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(24, 28);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(43, 19);
            this.exLabel1.TabIndex = 5;
            this.exLabel1.Text = "ឈ្មោះ";
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(580, 103);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(99, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 1;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(67, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(29, 19);
            this.lblRemove.TabIndex = 0;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(30, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked_1);
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPayDate,
            this.colAmount,
            this.colCurrency});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(28, 128);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(651, 297);
            this.dgv.TabIndex = 2;
            // 
            // colPayDate
            // 
            this.colPayDate.HeaderText = "ថ្ងៃទូទាត់";
            this.colPayDate.Name = "colPayDate";
            this.colPayDate.ReadOnly = true;
            this.colPayDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPayDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPayDate.Width = 280;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "ទឹកប្រាក់";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAmount.Width = 280;
            // 
            // colCurrency
            // 
            this.colCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.colCurrency.HeaderText = "រូបីប័ណ្ណ";
            this.colCurrency.Items = ((System.Collections.Generic.List<object>)(resources.GetObject("colCurrency.Items")));
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.Location = new System.Drawing.Point(27, 103);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
            this.exLabel2.Size = new System.Drawing.Size(178, 19);
            this.exLabel2.TabIndex = 11;
            this.exLabel2.Text = "ទឹកប្រាក់ដែលបានទូទាន់ប្រចាំខែ";
            // 
            // exLabel3
            // 
            this.exLabel3.AutoSize = true;
            this.exLabel3.Location = new System.Drawing.Point(360, 28);
            this.exLabel3.Name = "exLabel3";
            this.exLabel3.Required = false;
            this.exLabel3.Size = new System.Drawing.Size(68, 19);
            this.exLabel3.TabIndex = 13;
            this.exLabel3.Text = "លេខទូរស័ព្ទ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(479, 25);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            this.txtPhone.TabIndex = 12;
            // 
            // exLabel4
            // 
            this.exLabel4.AutoSize = true;
            this.exLabel4.Location = new System.Drawing.Point(24, 59);
            this.exLabel4.Name = "exLabel4";
            this.exLabel4.Required = false;
            this.exLabel4.Size = new System.Drawing.Size(40, 19);
            this.exLabel4.TabIndex = 15;
            this.exLabel4.Text = "តួនាទី";
            // 
            // cboPosition
            // 
            this.cboPosition.BackColor = System.Drawing.SystemColors.Window;
            this.cboPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboPosition.DropDownPanel = null;
            this.cboPosition.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPosition.Location = new System.Drawing.Point(143, 55);
            this.cboPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.cboPosition.SearchMode = QTech.Component.ExComboBox.SearchModes.OnKeyUp;
            this.cboPosition.Size = new System.Drawing.Size(200, 27);
            this.cboPosition.TabIndex = 16;
            this.cboPosition.Value = null;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 475);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCustomer";
            this.Text = "frmCustomer";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtName;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private Component.ExLabel exLabel1;
        private Component.ExLabel exLabel2;
        private Component.ExLabel exLabel4;
        private Component.ExLabel exLabel3;
        private System.Windows.Forms.TextBox txtPhone;
        private Component.ExPrettyDateColumn colPayDate;
        private Component.Components.NumericUpDownColumn colAmount;
        private Component.DropDownComboBoxColumn colCurrency;
        private Component.ExComboBox cboPosition;
    }
}