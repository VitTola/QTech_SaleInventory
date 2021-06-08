using QTech.Base.Helpers;
using QTech.Component;
using QTech.Component.Helpers;
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
    public partial class frmCustomer : ExDialog,IDialog
    {
        public frmCustomer()
        {
            InitializeComponent();
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            InitEvent();
        }

        public GeneralProcess Flag { get ; set; }

        public void Bind()
        {
            throw new NotImplementedException();
        }

        public void InitEvent()
        {
            txtPhone.RegisterEnglishInput();
            txtName.RegisterPrimaryInputWith(cboPosition);

            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
           
            
            

            if (Flag == GeneralProcess.Add || Flag == GeneralProcess.Update)
            {
                dgv.EditingControlShowing += dgv_EditingControlShowing;
            }
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        public bool InValid()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        private void lblAdd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           //dgv.BeginEdit(true);
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
