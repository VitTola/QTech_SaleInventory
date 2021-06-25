using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
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
using BaseReource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmSale : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        private decimal Total;

        public frmSale(Sale model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Read();
            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
            cboSite.DataSourceFn = p => SiteLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboSite.SearchParamFn = () => new SiteSearch() { };
            colProductId.DataSourceFn = p => ProductLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            colProductId.SearchParamFn = () => new ProductSearch();
            colEmployeeId.DataSourceFn = p => EmployeeLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            colEmployeeId.SearchParamFn = () => new EmployeeSearch();
        }
        public void InitEvent()
        {
            this.Text = Base.Properties.Resources.Sales;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPurchaseOrderNo.RegisterPrimaryInputWith(cboSite);
            txtPurchaseOrderNo.RegisterEnglishInputWith(txtPurchaseOrderNo);
            dgv.RegisterEnglishInputColumns(colQauntity);
            colUnitPrice.ReadOnly = colTotal.ReadOnly = true;
            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            if (Flag == GeneralProcess.Add || Flag == GeneralProcess.Update)
            {
                dgv.EditingControlShowing += dgv_EditingControlShowing;
                cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
            }
            else
            {
                txtInvoiceNo.ReadOnly = txtPurchaseOrderNo.ReadOnly = true;
                cboCustomer.Enabled = cboSite.Enabled = dgv.Enabled = flowLayOutLabelRemoveAdd.Enabled = false;
            }
        }

        private void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            if (customer != null)
            {
                cboSite.SearchParamFn = () => new SiteSearch() { CustomerId = customer.Id };
            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            colUnitPrice.ReadOnly = colTotal.ReadOnly = true;
            e.Control.RegisterEnglishInput();
            if (e.Control is ExSearchCombo cbo)
            {
                cbo.SelectedIndexChanged += Cbo_SelectedIndexChanged;
            }

            if (e.Control is TextBox txt)
            {
                txt.KeyPress += (o, ee) => { txt.validCurrency(sender, ee); };
                if (dgv.CurrentCell.ColumnIndex == colQauntity.Index)
                {
                    txt.Leave += txtQauntity_Leave;
                }
                txt.TextChanged += txtTotal_TextChanged;
            }
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
            {
            Total = 0;
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                if (string.IsNullOrEmpty(row.Cells[colTotal.Name]?.Value?.ToString() ?? ""))
                {
                    continue;
                }
                Total += decimal.Parse(row.Cells[colTotal.Name]?.Value?.ToString());
            }
                
            txtTotal.Text = Total.ToString();
        }
        private void txtQauntity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? ""))
            {
                return;
            }
            var unitPrice = decimal.Parse(dgv.CurrentRow?.Cells[colUnitPrice.Name].Value?.ToString() ?? "0");
            var qty = int.Parse(dgv.CurrentRow?.Cells[colQauntity.Name]?.Value?.ToString() ?? "0");
            dgv.CurrentRow.Cells[colTotal.Name].Value = (unitPrice * qty).ToString();
        }
        private async void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? "") || dgv.CurrentCell.ColumnIndex != colProductId.Index)
            {
                return;
            }
            var unitPrice = await dgv.RunAsync(() =>
            {
                var colPro = sender as ExSearchCombo;
                var proId = colPro.SelectedObject.ItemObject as Product;
                var result = ProductLogic.Instance.FindAsync(proId.Id);
                return result?.UnitPrice;
            });
            dgv.CurrentRow.Cells[colUnitPrice.Name].Value = unitPrice.ToString();
        }
        public bool InValid()
        {
            if (!cboCustomer.IsSelected() | !cboSite.IsSelected() |
                !txtPurchaseOrderNo.IsValidRequired(lblPurchaseOrderNo.Text) |
                !txtInvoiceNo.IsValidRequired(lblInvoiceNo.Text)
                | !validSaleDetail()
                )
            {
                return true;
            }

            return false;
        }
        private bool validSaleDetail()
        {
            var invalidCell = false;
            var rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv.RowCount - 1);
            if (rows?.Any() != true)
            {
                MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_, BaseReource.SaleDetail));
                return false;
            }

            foreach (DataGridViewRow row in rows)
            {
                var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                x.ColumnIndex != row.Cells[colId.Name].ColumnIndex && x.ColumnIndex != row.Cells[colSaleId.Name].ColumnIndex).ToList();
                cells.ForEach(x =>
                {
                    if (x.Value == null)
                    {
                        x.ErrorText = BaseReource.MsgPleaseInputValue;
                        invalidCell = true;
                    }
                    else
                    {
                        x.ErrorText = string.Empty;
                    }
                });
            }
            if (invalidCell)
            {
                return false;
            }

            return true;
        }
        public async void Read()
        {
            txtPurchaseOrderNo.Text = Model.PurchaseOrderNo;
            txtInvoiceNo.Text = Model.InvoiceNo;
            txtTotal.Text = Model.Total.ToString();

            Customer cus = null;
            Site site = null;
            List<Product> products = null;
            List<Employee> drivers = null;
            var saleDetails = await this.RunAsync(() =>
            {
                cus = CustomerLogic.Instance.FindAsync(Model.CompanyId);
                site = SiteLogic.Instance.FindAsync(Model.CompanyId);
                var details = SaleDetailLogic.Instance.GetSaleDetailBySaleId(Model.Id);
                var productIds = details.Select(x => x.ProductId).Distinct().ToList();
                var driverIds = details.Select(x => x.EmployeeId).Distinct().ToList();
                products = ProductLogic.Instance.All().Where(x => x.Active && productIds.Contains(x.Id)).ToList();
                drivers = EmployeeLogic.Instance.All().Where(x => x.Active && driverIds.Contains(x.Id)).ToList();

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
                Model.SaleDetails = saleDetails;
                saleDetails.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colSaleId.Name].Value = Model.Id;
                    row.Cells[colQauntity.Name].Value = x.Qauntity;
                    row.Cells[colTotal.Name].Value = x.Total;
                    row.Cells[colUnitPrice.Name].Value = products?.FirstOrDefault(y => y.Id == x.ProductId)?.UnitPrice;


                    if (products != null)
                    {
                        var pro = products?.FirstOrDefault(f => f.Id == x.ProductId);
                        var lsProdut = new List<DropDownItemModel>()
                    {
                        new DropDownItemModel
                        {
                             Id = pro.Id,
                            Code = pro.Name,
                            Name = pro.Name,
                            DisplayText = pro.Name,
                            ItemObject = pro,
                        }
                    };
                        row.Cells[colProductId.Name].Value = lsProdut;
                    }
                    if (drivers != null)
                    {
                        var driver = drivers?.FirstOrDefault(f => f.Id == x.EmployeeId);
                        var lsDriver = new List<DropDownItemModel>()
                    {
                        new DropDownItemModel
                        {
                            Id = driver.Id,
                            Code = driver.Name,
                            Name = driver.Name,
                            DisplayText = driver.Name,
                            ItemObject = driver,
                        }
                    };
                        row.Cells[colEmployeeId.Name].Value = lsDriver;
                    }

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
            Model.PurchaseOrderNo = txtPurchaseOrderNo.Text;
            Model.InvoiceNo = txtInvoiceNo.Text;
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            var site = cboSite.SelectedObject.ItemObject as Site;
            Model.CompanyId = customer.Id;
            Model.SiteId = site.Id;
            Model.SaleDate = DateTime.Now;
            Model.Total = decimal.Parse(txtTotal.Text ?? "0");

            var saleDetail = new SaleDetail();
            if (Model.SaleDetails == null)
            {
                Model.SaleDetails = new List<SaleDetail>();
            }
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                saleDetail.Active = true;
                saleDetail.Id = int.Parse(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
                saleDetail.SaleId = Model.Id;
                saleDetail.ProductId = int.Parse(row.Cells[colProductId.Name].Value.ToString());
                saleDetail.Qauntity = int.Parse(row.Cells[colQauntity.Name].Value.ToString());
                saleDetail.EmployeeId = int.Parse(row.Cells[colEmployeeId.Name].Value.ToString());
                saleDetail.Total = decimal.Parse(row.Cells[colTotal.Name].Value.ToString());

                var _saleDetail = Model.SaleDetails?.FirstOrDefault(x => x.Id == saleDetail.Id);
                if (_saleDetail != null)
                {
                    Model.SaleDetails[Model.SaleDetails.IndexOf(_saleDetail)] = saleDetail;
                }
                else
                {
                    Model.SaleDetails.Add(saleDetail);
                }
            }
        }
        private void lblAdd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.RowCount == 0 || !string.IsNullOrEmpty(dgv.Rows[dgv.RowCount - 1].Cells[colProductId.Name].Value?.ToString()))
            {
                var row = newRow(true);
            }
            else
            {
                var row = dgv.Rows[dgv.RowCount - 1];
                if (row != null)
                {
                    dgv.Focus();
                    dgv.CurrentCell = row.Cells[colProductId.Name];
                }
            }
        }
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0] == null)
            {
                return;
            }

            var row = dgv.SelectedRows[0];
            var idValue = row.Cells[colId.Name].Value;
            if (idValue == null)
            {
                dgv.Rows.Remove(row);
                return;
            }
            Model.SaleDetails.ForEach(x =>
            {
                if (x.Id == int.Parse(idValue.ToString()))
                {
                    x.Active = false;
                }
            });
            if (!row.IsNewRow)
            {
                dgv.Rows.Remove(row);
                txtTotal_TextChanged(sender,e);
                dgv.EndEdit();
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
        private void lblPrintInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
