namespace QTech.Forms
{
    partial class frmEmployee
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
            this.exLabel2 = new QTech.Component.ExLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(555, 406);
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.Location = new System.Drawing.Point(26, 61);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = false;
            this.exLabel2.Size = new System.Drawing.Size(44, 19);
            this.exLabel2.TabIndex = 16;
            this.exLabel2.Text = "គំរោង";
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
            this.colSite});
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
            this.dgv.Location = new System.Drawing.Point(28, 83);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(315, 280);
            this.dgv.TabIndex = 14;
            // 
            // colSite
            // 
            this.colSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSite.HeaderText = "ឈ្មោះគំរោង";
            this.colSite.Name = "colSite";
            this.colSite.ReadOnly = true;
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(210, 61);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(133, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 13;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(101, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(29, 19);
            this.lblRemove.TabIndex = 0;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(64, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(24, 17);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(83, 19);
            this.exLabel1.TabIndex = 15;
            this.exLabel1.Text = "ឈ្មោះក្រុមហ៊ុន";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 14);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 12;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 427);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Component.ExLabel exLabel2;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private Component.ExLabel exLabel1;
        private System.Windows.Forms.TextBox txtName;
    }
}