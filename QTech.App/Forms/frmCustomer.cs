using QTech.Base;
using QTech.Base.Helpers;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db;
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
    public partial class frmCustomer : ExDialog, IDialog
    {
        Customer model=new Customer();
        Site site = new Site();
        QTechDbContext db = new QTechDbContext();
        public frmCustomer()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
           
        }

        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Base.Properties.Resources.Employees;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPhone.RegisterEnglishInput();

            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.RegisterEnglishInputColumns(colPhone);

            dgv.EditingControlShowing += dgv_EditingControlShowing;

        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv?.SelectedRows?.Count < 0)
            {
                return;
            }
        }

        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblCompany_.Text) | txtPhone.IsValidRequired(lblPhone.Text) 
                | txtPhone.IsValidPhone())
            {
                return false;
            }
            return true;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public async void Save()
        {
            await btnAdd.RunAsync(() => new CustomerLogic(db).AddAsync(model));
        }

        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            if (InValid())
            {
                return;
            }
            model.Active = true;
            model.Name = txtName.Text;
            model.Phone = txtPhone.Text;
            model.Note = txtNote.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Write();
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgv.BeginEdit(true);
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0] == null)
            {
                return;
            }
            var row = dgv.SelectedRows[0];
            dgv.Rows.Remove(row);
        }
    }
}
