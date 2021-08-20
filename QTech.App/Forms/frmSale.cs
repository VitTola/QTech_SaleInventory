using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using QTech.Reports;
using Storm.CC.Report.Helpers;
using System;
using System.Collections;
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
        private List<RepoInvoice> invoices;
        private List<RepoInvoiceDetail> invoiceDetails;
        private List<CustomerPrice> customerPrices;
        private List<Category> categories;
        private List<Product> products;
        public GeneralProcess Flag { get; set; }
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
        public void Bind()
        {
            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
            cboSite.DataSourceFn = p => SiteLogic.Instance.GetSites(p).ToDropDownItemModelList();
            cboSite.SearchParamFn = () => new SiteSearch() { };
            colProductId.DataSourceFn = p => ProductLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            colProductId.SearchParamFn = () => new ProductSearch();
            colProductId.CustomSearchForm = () => new SelectProductDialog(new ProductSearch());
            colEmployeeId.DataSourceFn = p => EmployeeLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            colEmployeeId.SearchParamFn = () => new EmployeeSearch();
            cboPurchaseOrderNo.DataSourceFn = p => PurchaseOrderLogic.Instance.GetPurchaseOrder(p).ToDropDownItemModelList();
            cboPurchaseOrderNo.SearchParamFn = () => new PurchaseOrderSearch();

        }
        public void InitEvent()
        {
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Sales);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cboPurchaseOrderNo.RegisterPrimaryInputWith(cboSite);
            cboPurchaseOrderNo.RegisterEnglishInputWith(cboPurchaseOrderNo, txtInvoiceNo, txtInvoiceNo1, txtCustomer, txtPhone);
            dgv.RegisterEnglishInputColumns(colQauntity);
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.EditingControlShowing += dgv_EditingControlShowing;
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv.EditingControlShowing += Dgv_EditingControlShowing;
            dgv.MouseClick += Dgv_MouseClick;
            dgv.EditColumnIcon(colProductId, colQauntity, colUnitPrice, colEmployeeId);
            dgv.SetColumnHeaderDefaultStyle();
            dgv.Enter += (s, e) => { dgv.Rows.Add();dgv.BeginEdit(true); };
            //dgv.CellValueChanged += Dgv_CellValueChanged;

            txtTotal.ReadOnly = colLeftQty_.ReadOnly = true;
            cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
            this.Load += FrmSale_Load;
            
            if (Flag != GeneralProcess.Add)
            {
                tabMain.Controls.Remove(Model.SaleType == SaleType.Company ? tabGeneral_ : tabCompany_);
            }
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount == 0)
            {
                return;
            }
            dgv.EndEdit();
            var unitPrice = decimal.Parse(dgv.CurrentRow?.Cells[colUnitPrice.Name]?.Value?.ToString() ?? "0");
            var qty = int.Parse(dgv.CurrentRow?.Cells[colQauntity.Name]?.Value?.ToString() ?? "0");
            if (unitPrice == 0 || qty == 0)
            {
                return;
            }

            dgv.CurrentRow.Cells[colTotal.Name].Value = (unitPrice * qty).ToString();
            CheckValidProductByPO();
            CalculateTotal();
            dgv.BeginEdit(true);
        }

        private async void FrmSale_Load(object sender, EventArgs e)
        {
            var dummy = await this.RunAsync(() =>
            {
                categories = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                products = ProductLogic.Instance.SearchAsync(new ProductSearch());
                return products;
            });
        }
        private void Dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPurchaseOrderNo.Text) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
            if (tabMain.SelectedTab.Equals(tabGeneral_) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
        }
        private void Dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (string.IsNullOrEmpty(cboPurchaseOrderNo.Text) && tabMain.SelectedTab.Equals(tabCompany_))
            {
                dgv.EndEdit();
                dgv.ReadOnly = true;
                cboPurchaseOrderNo.IsSelected();
            }
            else
            {
                dgv.ReadOnly = false;
                dgv.BeginEdit(true);
            }
        }
        private bool firstLoad = true;
        private async void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            if (customer != null)
            {
                var cusId = customer.Id == 0 ? -1 : customer.Id;
                cboSite.SearchParamFn = () => new SiteSearch() { CustomerId = cusId };
                cboPurchaseOrderNo.SearchParamFn = () => new PurchaseOrderSearch() { CustomerId = cusId };
            }

            customerPrices = await dgv.RunAsync(() =>
            {
                var result = CustomerPriceLogic.Instance.GetCustomerPriceByCustomerId(customer.Id);
                return result;
            });

            if (firstLoad) { firstLoad = false; return; }
            cboSite.SetValue(null);
            cboPurchaseOrderNo.SetValue(null);
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            colTotal.ReadOnly = colLeftQty_.ReadOnly = true;
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
                    txt.KeyUp += txtQauntity_KeyUp;
                }
                else if (dgv.CurrentCell.ColumnIndex == colUnitPrice.Index)
                {
                    txt.KeyUp += Txt_KeyUp;
                }

            }
        }
        private void Txt_KeyUp(object sender, EventArgs e)
        {
            txtQauntity_KeyUp(sender, e);
        }
        private void CalculateTotal()
        {
            Total = 0;
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                if (string.IsNullOrEmpty(row.Cells[colTotal.Name]?.Value?.ToString() ?? "")) continue;
                Total += decimal.Parse(row.Cells[colTotal.Name]?.Value?.ToString());
            }

            txtTotal.Text = Total.ToString();
        }
        private void txtQauntity_KeyUp(object sender, EventArgs e)
        {
            dgv.EndEdit();
            var unitPrice = decimal.Parse(dgv.CurrentRow.Cells[colUnitPrice.Name].Value?.ToString() ?? "0");
            var qty = int.Parse(dgv.CurrentRow.Cells[colQauntity.Name].Value?.ToString() ?? "0");
            if (unitPrice == 0 || qty == 0)
            {
                return;
            }

            dgv.CurrentRow.Cells[colTotal.Name].Value = (unitPrice * qty).ToString();
            CheckValidProductByPO();
            CalculateTotal();
            dgv.BeginEdit(true);
        }
        private async void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? "") || dgv.CurrentCell.ColumnIndex != colProductId.Index)
                {
                    return;
                }
                if (!cboCustomer.IsSelected() && tabMain.SelectedTab.Equals(tabCompany_))
                {
                    return;
                }
                CheckValidProductByPO();

                decimal unitPrice = 0;
                bool IsNotPriceByPO = true;
                var _productId = int.Parse(dgv.CurrentCell.Value.ToString());

                //set category
                var product = products?.FirstOrDefault(x => x.Id == _productId);
                dgv.CurrentRow.Cells[colCategory_.Name].Value = categories.FirstOrDefault(x => x.Id == product?.CategoryId)?.Name ?? string.Empty;
                dgv.CurrentRow.Cells[colImportPrice.Name].Value = products?.FirstOrDefault(y => y.Id == product.Id)?.ImportPrice;


                if (!string.IsNullOrEmpty(cboPurchaseOrderNo.Text) && tabMain.SelectedTab.Equals(tabCompany_))
                {
                    var purchaseOrderNo = cboPurchaseOrderNo.SelectedObject?.ItemObject as PurchaseOrder;
                    if (purchaseOrderNo != null)
                    {
                        var pOProductPrice = await dgv.RunAsync(() =>
                        {
                            var result = POProductPriceLogic.Instance.GetPOProductPriceByPO(purchaseOrderNo.Id);
                            return result;
                        });
                        if (pOProductPrice?.Any() ?? false)
                        {
                            var _poPrice = pOProductPrice.FirstOrDefault(x => x.ProductId == _productId);
                            if (_poPrice != null)
                            {
                                unitPrice = _poPrice.SalePrice;
                                IsNotPriceByPO = false;
                            }
                        }
                        dgv.CurrentRow.Cells[colLeftQty_.Name].Value = pOProductPrice.FirstOrDefault(x => x.ProductId == _productId).LeftQauntity;

                    }
                }
                if (IsNotPriceByPO)
                {
                    bool IsNotPriceByCustomer = true;
                    if (customerPrices?.Any() ?? false)
                    {
                        var _cusPrice = customerPrices.FirstOrDefault(x => x.ProductId == _productId);
                        if (_cusPrice != null)
                        {
                            unitPrice = _cusPrice.SalePrice;
                            IsNotPriceByCustomer = false;
                        }
                    }
                    if (IsNotPriceByCustomer)
                    {
                        var pro = await dgv.RunAsync(() =>
                        {
                            var result = ProductLogic.Instance.FindAsync(_productId);
                            return result;
                        });
                        unitPrice = pro?.UnitPrice ?? 0;
                    }
                }
                dgv.CurrentRow.Cells[colUnitPrice.Name].Value = unitPrice.ToString();
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message,BaseReource.Sales);
            }
           
        }
        DataGridViewCell Err = null;
        private async void CheckValidProductByPO()
        {
            try
            {
                var purchaseOrderNo = cboPurchaseOrderNo.SelectedObject?.ItemObject as PurchaseOrder;
                if (purchaseOrderNo != null)
                {
                    var pOProductPrices = await dgv.RunAsync(() =>
                    {
                        var result = POProductPriceLogic.Instance.GetPOProductPriceByPO(purchaseOrderNo.Id);
                        return result;
                    });
                    if (pOProductPrices?.Any() ?? false)
                    {
                        var inputQty = int.Parse(dgv.CurrentRow.Cells[colQauntity.Name].Value?.ToString() ?? "0");

                        var _productId = int.Parse(dgv.CurrentRow.Cells[colProductId.Name].Value.ToString());
                        if (_productId != 0)
                        {
                            var pOProductPrice = pOProductPrices.FirstOrDefault(x => x.ProductId == _productId);
                            if (pOProductPrice?.LeftQauntity == 0)
                            {
                                Err = ((DataGridViewCell)(dgv.CurrentRow.Cells[colProductId.Name]));
                                Err.ErrorText = BaseReource.MsgProductQtyReachLimit;
                            }
                            else if (inputQty > pOProductPrice?.LeftQauntity)
                            {
                                Err = ((DataGridViewCell)dgv.CurrentRow.Cells[colProductId.Name]);
                                Err.ErrorText = BaseReource.MsgProductOverQty + $" (ចំនួននៅសល់ {pOProductPrice.LeftQauntity})";
                            }
                            else
                            {
                                if (Err != null)
                                {
                                    Err.ErrorText = string.Empty;
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message,BaseReource.Sales);
            }
           
        }
        public bool InValid()
        {
            if (tabMain.SelectedTab.Equals(tabCompany_))
            {
                if (!cboCustomer.IsSelected() 
                    | !cboSite.IsSelected() 
                    | !cboPurchaseOrderNo.IsSelected()
                    | !txtInvoiceNo.IsValidRequired(lblInvoiceNo.Text) )
                {
                    return true;
                }
            }
            else
            {
                if (!txtCustomer.IsValidRequired(lblCustomer1.Text) | !txtInvoiceNo1.IsValidRequired(lblInvoiceNo1.Text))
                {
                    return true;
                }
            }

            if (!validSaleDetail())
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
                x.ColumnIndex == row.Cells[colProductId.Name].ColumnIndex || x.ColumnIndex == row.Cells[colQauntity.Name].ColumnIndex
                || x.ColumnIndex == row.Cells[colUnitPrice.Name].ColumnIndex || x.ColumnIndex == row.Cells[colEmployeeId.Name].ColumnIndex).ToList();
                cells.ForEach(x =>
                {
                    if (x.Value == null)
                    {
                        x.ErrorText = BaseReource.MsgPleaseInputValue;
                        invalidCell = true;
                    }
                });
            }
            if (invalidCell)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(Err.ErrorText))
            {
                return false;
            }

            return true;
        }
        public async void Read()
        {
            if (Flag == GeneralProcess.Add)
            {
                return;
            }

            Customer cus = null;
            Site site = null;
            List<Product> products = null;
            List<Employee> drivers = null;
            PurchaseOrder purchaseOrder = null;
            List<POProductPrice> pOProductPrices = null;
            var saleDetails = await this.RunAsync(() =>
            {
                cus = CustomerLogic.Instance.FindAsync(Model.CompanyId);
                site = SiteLogic.Instance.FindAsync(Model.SiteId);
                var details = SaleDetailLogic.Instance.GetSaleDetailBySaleId(Model.Id);
                var productIds = details.Select(x => x.ProductId).Distinct().ToList();
                var driverIds = details.Select(x => x.EmployeeId).Distinct().ToList();
                products = ProductLogic.Instance.All().Where(x => x.Active && productIds.Contains(x.Id)).ToList();
                drivers = EmployeeLogic.Instance.All().Where(x => x.Active && driverIds.Contains(x.Id)).ToList();
                categories = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                products = ProductLogic.Instance.SearchAsync(new ProductSearch());

                if (Model.PurchaseOrderId != 0)
                {
                    purchaseOrder = PurchaseOrderLogic.Instance.FindAsync(Model.PurchaseOrderId);
                    pOProductPrices = POProductPriceLogic.Instance.GetPOProductPriceByPO(Model.PurchaseOrderId);
                }
                return details;
            });

            //Read Sale
            if (Model?.SaleType == SaleType.Company)
            {
                txtInvoiceNo.Text = Model.InvoiceNo;
                txtTotal.Text = Model.Total.ToString();
                txtExpense.Text = Model.Expense.ToString();
                if (cus != null)
                {
                    cboCustomer.SetValue(cus);
                }
                if (purchaseOrder != null)
                {
                    cboPurchaseOrderNo.SetValue(purchaseOrder);
                }

                if (site != null)
                {
                    cboSite.SetValue(site);
                }
            }
            else
            {
                txtCustomer.Text = Model.CustomerName;
                txtInvoiceNo1.Text = Model.InvoiceNo;
                txtPhone.Text = Model.Phone;
            }

            //Read SaleDetail
            if (saleDetails?.Any() ?? false)
            {
                Model.SaleDetails = saleDetails;
                saleDetails.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colSaleId.Name].Value = Model.Id;
                    row.Cells[colQauntity.Name].Value = x.Qauntity;
                    row.Cells[colTotal.Name].Value = x.Total;
                    var product = products?.FirstOrDefault(y => y.Id == x.ProductId) ?? new Product();
                    row.Cells[colUnitPrice.Name].Value = product.UnitPrice;
                    row.Cells[colImportPrice.Name].Value = product.ImportPrice;
                    row.Cells[colLeftQty_.Name].Value = pOProductPrices?.FirstOrDefault(r => r.ProductId == x.ProductId)?.LeftQauntity;
                    row.Cells[colCategory_.Name].Value = categories?.FirstOrDefault(r => r.Id == product.CategoryId)?.Name;

                    if (products?.Any() ?? false)
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
                    if (drivers?.Any() ?? false)
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

                    //Init this event after fill in data
                    //cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
                });
            }
        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
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
            if (tabMain.SelectedTab.Equals(tabCompany_))
            {
                var customer = cboCustomer.SelectedObject.ItemObject as Customer;
                var site = cboSite?.SelectedObject?.ItemObject as Site;
                Model.CompanyId = customer.Id;
                Model.SiteId = site?.Id ?? 0;
                Model.PurchaseOrderNo = cboPurchaseOrderNo.Text;
                Model.InvoiceNo = txtInvoiceNo.Text;
                var purchaseOrder = cboPurchaseOrderNo.SelectedObject?.ItemObject as PurchaseOrder;
                Model.PurchaseOrderId = purchaseOrder == null ? 0 : purchaseOrder.Id;
                Model.SaleType = SaleType.Company;
            }
            else
            {
                Model.CustomerName = txtCustomer.Text;
                Model.Phone = txtPhone.Text;
                Model.SaleType = SaleType.General;
                Model.InvoiceNo = txtInvoiceNo1.Text;
            }

            Model.SaleDate = Flag == GeneralProcess.Add ? DateTime.Now : Model.SaleDate;
            Model.Total = decimal.Parse(!string.IsNullOrEmpty(txtTotal.Text) ? txtTotal.Text : "0");
            Model.Expense = decimal.Parse(!string.IsNullOrEmpty(txtExpense.Text) ? txtExpense.Text : "0");

            if (Model.SaleDetails == null)
            {
                Model.SaleDetails = new List<SaleDetail>();
            }

            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var saleDetail = new SaleDetail();

                saleDetail.Active = true;
                saleDetail.Id = int.Parse(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
                saleDetail.SaleId = Model.Id;
                saleDetail.ProductId = int.Parse(row.Cells[colProductId.Name].Value?.ToString() ?? "0");
                saleDetail.Qauntity = int.Parse(row.Cells[colQauntity.Name].Value?.ToString() ?? "0");
                saleDetail.EmployeeId = int.Parse(row.Cells[colEmployeeId.Name].Value?.ToString() ?? "0");
                saleDetail.Total = decimal.Parse(row.Cells[colTotal.Name].Value?.ToString() ?? "0");

                //ImportTotal & Profit
                var importPrice = decimal.Parse(row.Cells[colImportPrice.Name].Value?.ToString() ?? "0");
                saleDetail.ImportTotalAmount = importPrice * saleDetail.Qauntity;
                saleDetail.Profit = saleDetail.Total - saleDetail.ImportTotalAmount;

                if (Flag == GeneralProcess.Update)
                {
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
                else
                {
                    Model.SaleDetails.Add(saleDetail);
                }
            }
        }
        private void WriteInvoice()
        {
            invoiceDetails = new List<RepoInvoiceDetail>();
            invoices = new List<RepoInvoice>();
            var invoice = new RepoInvoice();

            if (tabMain.SelectedTab.Equals(tabCompany_))

            {
                invoice.PurchaseOrderNo = cboPurchaseOrderNo.Text;
                invoice.InvoiceNo = Model.InvoiceNo = txtInvoiceNo.Text;
                var customer = cboCustomer.SelectedObject.ItemObject as Customer;
                var site = cboSite?.SelectedObject?.ItemObject as Site;
                var purchaseOrder = cboPurchaseOrderNo.SelectedObject?.ItemObject as PurchaseOrder;
                Model.PurchaseOrderId = purchaseOrder == null ? 0 : purchaseOrder.Id;
                invoice.Site = site?.Name;
                invoice.Customer = customer.Name;
            }
            else
            {
                invoice.InvoiceNo = txtInvoiceNo1.Text;
                invoice.Customer = txtCustomer.Text;
            }

            invoice.Total = String.Format("{0:C}", Model.Total);
            invoice.SaleId = Model.Id;
            invoices.Add(invoice);

            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var invoiceDt = new RepoInvoiceDetail();

                var proId = int.Parse(row.Cells[colProductId.Name].Value.ToString());
                var _pro = ProductLogic.Instance.FindAsync(proId);
                invoiceDt.Product = _pro.Name;
                invoiceDt.Qauntity = int.Parse(row.Cells[colQauntity.Name].Value.ToString());
                var unitP = decimal.Parse(row.Cells[colUnitPrice.Name].Value.ToString());
                var totalP = decimal.Parse(row.Cells[colTotal.Name].Value.ToString());
                invoiceDt.UnitPrice = String.Format("{0:C}", unitP);
                invoiceDt.Total = String.Format("{0:C}", totalP);
                invoiceDetails.Add(invoiceDt);
            }
        }
        private void lblAdd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabGeneral_) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
            if (!string.IsNullOrEmpty(cboPurchaseOrderNo.Text))
            {
                dgv.ReadOnly = false;
            }
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
            if (dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0] == null || dgv.CurrentRow.Cells[colProductId.Name].Value == null)
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
                CalculateTotal();
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
        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (InValid()) return;
            WriteInvoice();
            DataTable Invoice = new DataTable("Invoice");
            using (var reader = ObjectReader.Create(invoices))
            {
                Invoice.Load(reader);
            }
            DataTable InvoiceDetail = new DataTable("InvoiceDetail");
            using (var reader = ObjectReader.Create(invoiceDetails))
            {
                InvoiceDetail.Load(reader);
            }
            var Invoices = new List<DataTable>();
            Invoices.Add(Invoice);
            Invoices.Add(InvoiceDetail);

            var report = await dgv.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportInvoice), Invoices);
                r.SummaryInfo.ReportTitle = nameof(ReportInvoice);
                return r;
            });

            if (report != null)
            {
                var dig = new DialogReportViewer(report);
                dig.Text = QTech.Base.Properties.Resources.Invoice;
                dig.ShowDialog();
            }
        }
        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //var cell = dgv.CurrentCell;
            //if (cell.Value != null)
            //{
            //    cell.ErrorText = string.Empty;
            //}
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                int icolumn = dgv.CurrentCell.ColumnIndex;
                int irow = dgv.CurrentCell.RowIndex;

                if (keyData == Keys.Enter)
                {
                    if (icolumn == dgv.Columns.Count - 1)
                    {
                        dgv.CurrentCell = dgv[0, irow + 1];
                    }
                    else
                    {
                        dgv.CurrentCell = dgv[icolumn + 1, irow];
                    }
                    return true;
                }
                else
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
          
        }
    }
}

