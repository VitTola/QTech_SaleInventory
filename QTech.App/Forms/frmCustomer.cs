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
        QTechDbContext db=new QTechDbContext();
        Customer model=new Customer();
        public frmCustomer()
        {
            InitializeComponent();
            CustomerLogic logic = new CustomerLogic(db);
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            throw new NotImplementedException();
        }

        public void InitEvent()
        {
            throw new NotImplementedException();
        }

        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblCompany.Text) | txtPhone.IsValidRequired(lblPhone.Text) 
                | txtPhone.IsValidPhone())
            {
                return true;
            }
            return false;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public async void Save()
        {
           await new CustomerLogic(db).AddAsync(model);
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
            model.Phone = txtNote.Text;
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
    }
}
