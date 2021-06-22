using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
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

            cboSite.SetDataSource<Base.Enums.Position>();

        }

        public void InitEvent()
        {
            this.Text = Base.Properties.Resources.Sales;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPurchaseOrderNo.RegisterPrimaryInputWith(cboSite);

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

        public async void Read()
        {
            txtPurchaseOrderNo.Text = Model.PurchaseOrderNo;
            txtInvoiceNo.Text = Model.InvoiceNo;

            Customer cus = null;
            Site site = null;
            List<Product> products = null;
            List<Customer> drives = null;
            var saleDetails = await this.RunAsync(()=>
            {
                cus = CustomerLogic.Instance.FindAsync(Model.CompanyId);
                site = SiteLogic.Instance.FindAsync(Model.CompanyId);
                var details = SaleDetailLogic.Instance.GetSaleDetailBySaleId(Model.Id);
                var productIds = details.Select(x => x.ProductId).Distinct().ToList();
                var driveIds = details.Select(x => x.EmployeeId).Distinct().ToList();
                products = ProductLogic.Instance.All().Where(x => x.Active && productIds.Contains(x.Id)).ToList();
                drives = CustomerLogic.Instance.All().Where(x => x.Active && driveIds.Contains(x.Id)).ToList();

                return details;
            });
            if (cus != null)
            {
                cboCustomer.SetValue(cus);
            }
            if (site != null)
            {
                cboSite.SetValue(site);
            }

            if (saleDetails.Any())
            {
                saleDetails.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    var pro = products?.FirstOrDefault(f => f.Id == x.ProductId);
                    row.Cells[colName.Name].Value = pro?.Name ?? string.Empty;
                    row.Cells[colQauntity.Name].Value = x.Qauntity;
                    var drive = drives?.FirstOrDefault(f => f.Id == x.EmployeeId);
                    row.Cells[colDriver.Name].Value = drive?.Name ?? string.Empty;
                    row.Cells[colDriver.Name].Value = drive?.Name ?? string.Empty;
                    row.Cells[colTotal.Name].Value = x.Total;
                });
            }


        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => SaleLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtInvoiceNo.IsExists(lblInvoiceNo.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return SaleLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return SaleLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return SaleLogic.Instance.RemoveAsync(Model);
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

        }

        public void Write()
        {

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
