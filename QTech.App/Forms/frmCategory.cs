using QTech.Base;
using QTech.Base.Helpers;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Forms
{
    public partial class frmCategory : ExDialog, IDialog
    {
        public Employee Model { get; set; }

        public frmCategory(Employee model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            cboPosition.SetDataSource<Base.Enums.Position>();
            colName.Visible = true;
            colName.Width = 100;

            Read();
        }

        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Base.Properties.Resources.Employees;
            txtPhone.RegisterEnglishInput();
            txtName.RegisterPrimaryInputWith(cboPosition,txtNote,txtName);
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
            
        }

        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
                | !cboPosition.IsValidRequired(lblPosition.Text) 
                | !txtPhone.IsValidPhone())
            {
                return true;
            }
            return false;
        }

        public void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
            cboPosition.Text = Model.Position;
        }

        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => EmployeeLogic.Instance.IsExistsAsync(Model));
            if (isExist == null) { return; }
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return EmployeeLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return  EmployeeLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return EmployeeLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.Phone = txtPhone.Text;
            Model.Position = cboPosition.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
