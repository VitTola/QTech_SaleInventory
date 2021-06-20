using QTech.Base;
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
    public partial class frmSale : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        public frmSale(Sale model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            
            cboPosition.SetDataSource<Base.Enums.Position>();
            
        }

        public void InitEvent()
        {
            this.Text = Base.Properties.Resources.Sales;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            e.Control.RegisterEnglishInput();

            

        }

        public bool InValid()
        {
            //var 
            //if (!colCurrency.IsValidNumberic)
            //{

            //}

            return false;
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
            dgv.BeginEdit(true);
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv?.SelectedRows?.Count > 0)
            {




            }
        }


        private void container_Paint(object sender, PaintEventArgs e)
        {

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
