using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
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
    public partial class frmCreateInvoice : ExDialog, IDialog
    {
        public Invoice Model { get; set; }
        private decimal Total;
        private List<RepoInvoice> invoices;
        private List<RepoInvoiceDetail> invoiceDetails;
        private List<CustomerPrice> customerPrices;
        private int AllSales = 0, CheckingAmount = 0;

        public GeneralProcess Flag { get; set; }
        public frmCreateInvoice(Invoice model, GeneralProcess flag)
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
            var maxDate = DateTime.Now;
            dtpSearchDate.CustomDateRang = CustomDateRang.None;
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(dtpSearchDate.CustomDateRang, maxDate);
            dtpSearchDate.SetMaxDate(maxDate);
            dtpSearchDate.Items.AddRange(peroids.ToArray());
            dtpSearchDate.Items.Add(customPeroid);
            dtpSearchDate.SetSelectePeroid(DatePeroid.LastMonth);

            dtpInvoicingDate.Items.AddRange(peroids.ToArray());
            dtpInvoicingDate.Items.Add(customPeroid);
            dtpInvoicingDate.SetSelectePeroid(DatePeroid.Today);

            dtpInvoicingDate.SetSelectePeroid(DatePeroid.Today);

            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();

        }
        public void InitEvent()
        {
            this.Text = Base.Properties.Resources.Sales;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            if (Flag == GeneralProcess.Add || Flag == GeneralProcess.Update)
            {
                dgv.EditingControlShowing += dgv_EditingControlShowing;
                cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
                dtpSearchDate.SelectedIndexChanged += dtpSearchDate_SelectedIndexChanged;
                dgv.CellContentClick += Dgv_CellContentClick;
                txtPaidAmount.KeyPress += (s, e) => { txtPaidAmount.validCurrency(s, e); };
            }
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            txtTotal.ReadOnly = txtLeftAmount.ReadOnly = true;
            txtInvoiceNo.ReadOnly = true;
            dtpInvoicingDate.Enabled = false;
            dgv.Columns.OfType<DataGridViewColumn>().Where(x => x.Name != colMark_.Name).ToList().ForEach(x => x.ReadOnly = true);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colMark_.Index)
            {
                var _isCheck = (bool)(dgv.CurrentRow.Cells[colMark_.Name]?.Value);
                dgv.CurrentRow.Cells[colMark_.Name].Value = !_isCheck;

                if (!_isCheck && CheckingAmount < AllSales)
                {
                    CheckingAmount++;
                }
                else
                {
                    CheckingAmount--;
                }
                chkMarkAll_.Checked = CheckingAmount == AllSales ? true : false;

                CalculateTotal();
            }
        }

        private void dtpSearchDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertGridViewData();
        }

        private void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertGridViewData();
        }
        private async void InsertGridViewData()
        {
            AllSales = 0;
            dgv.Rows.Clear();
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            if (customer != null)
            {
            }
            var search = new SaleSearch()
            {
                FromDate = dtpSearchDate.SelectedPeroid.FromDate.Date,
                ToDate = dtpSearchDate.SelectedPeroid.ToDate,
                CustomerId = customer.Id
            };

            List<Site> _site = new List<Site>();
            var sales = await dgv.RunAsync(() =>
            {
                var result = SaleLogic.Instance.GetSaleByCustomerId(search);
                var SitesIds = result?.Select(x => x.SiteId).ToList();
                _site = SiteLogic.Instance.GetSiteByIds(SitesIds);
                return result;
            });

            if (sales.Any())
            {
                sales.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colPurchaseOrderNo.Name].Value = x.PurchaseOrderNo;
                    row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                    row.Cells[colToCompany.Name].Value = customer.Name;
                    row.Cells[colToSite.Name].Value = _site?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                    row.Cells[colTotal.Name].Value = x.Total;
                    row.Cells[colSaleDate.Name].Value = x.SaleDate.ToShortDateString();
                    row.Cells[colIsPaid.Name].Value = x.IsPaid;

                    var cell = row.Cells[colStatus.Name];
                    if (x.IsPaid)
                    {
                        row.Cells[colStatus.Name].Value = BaseReource.IsPaid;
                        cell.Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[colStatus.Name].Value = BaseReource.NotYetPaid;
                        cell.Style.ForeColor = Color.Green;
                    }

                    AllSales++;
                });
                dgv.Sort(dgv.Columns[colSaleDate.Name], ListSortDirection.Descending);

                //Initailize colMark_
                foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
                {
                    row.Cells[colMark_.Name].Value = false;
                }
            }
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }
        private void CalculateTotal()
        {
            Total = 0;
            txtPaidAmount.Text = string.Empty;
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_.Name].Value)
                {
                    Total = Total + decimal.Parse(row.Cells[colTotal.Name].Value?.ToString() ?? "0");
                }
            }
            txtTotal.Text = txtLeftAmount.Text = Total.ToString();
        }

        private async void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? ""))
            {
                return;
            }
            if (!cboCustomer.IsSelected())
            {
                return;
            }

            decimal unitPrice = 0;
            bool IsNotPriceByCustomer = true;
            var _productId = int.Parse(dgv.CurrentCell.Value.ToString());
            if (customerPrices.Any())
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
                    var colPro = sender as ExSearchCombo;
                    var proId = colPro.SelectedObject.ItemObject as Product;
                    var result = ProductLogic.Instance.FindAsync(proId.Id);
                    return result;
                });
                unitPrice = pro.UnitPrice;
            }

        }
        public bool InValid()
        {
            if (!cboCustomer.IsSelected() |
                !txtInvoiceNo.IsValidRequired(lblInvoiceNo.Text)
                )
            {
                return true;
            }

            return false;
        }
       
        public async void Read()
        {
            //txtPurchaseOrderNo.Text = Model.PurchaseOrderNo;
            //txtInvoiceNo.Text = Model.InvoiceNo;
            //txtTotal.Text = Model.Total.ToString();

            //Customer cus = null;
            //Site site = null;
            //List<Product> products = null;
            //List<Employee> drivers = null;
            //var saleDetails = await this.RunAsync(() =>
            //{
            //    cus = CustomerLogic.Instance.FindAsync(Model.CompanyId);
            //    site = SiteLogic.Instance.FindAsync(Model.CompanyId);
            //    var details = SaleDetailLogic.Instance.GetSaleDetailBySaleId(Model.Id);
            //    var productIds = details.Select(x => x.ProductId).Distinct().ToList();
            //    var driverIds = details.Select(x => x.EmployeeId).Distinct().ToList();
            //    products = ProductLogic.Instance.All().Where(x => x.Active && productIds.Contains(x.Id)).ToList();
            //    drivers = EmployeeLogic.Instance.All().Where(x => x.Active && driverIds.Contains(x.Id)).ToList();

            //    return details;
            //});
            //if (cus != null)
            //{
            //    cboCustomer.SetValue(cus);
            //}
            //if (site != null)
            //{
            //    cboSite.SetValue(site);
            //}

            //if (saleDetails.Any())
            //{
            //    Model.SaleDetails = saleDetails;
            //    saleDetails.ForEach(x =>
            //    {
            //        var row = newRow(false);
            //        row.Cells[colId.Name].Value = x.Id;
            //        row.Cells[colSaleId.Name].Value = Model.Id;
            //        row.Cells[colQauntity.Name].Value = x.Qauntity;
            //        row.Cells[colTotal.Name].Value = x.Total;
            //        row.Cells[colUnitPrice.Name].Value = products?.FirstOrDefault(y => y.Id == x.ProductId)?.UnitPrice;


            //        if (products != null)
            //        {
            //            var pro = products?.FirstOrDefault(f => f.Id == x.ProductId);
            //            var lsProdut = new List<DropDownItemModel>()
            //        {
            //            new DropDownItemModel
            //            {
            //                 Id = pro.Id,
            //                Code = pro.Name,
            //                Name = pro.Name,
            //                DisplayText = pro.Name,
            //                ItemObject = pro,
            //            }
            //        };
            //            row.Cells[colProductId.Name].Value = lsProdut;
            //        }
            //        if (drivers != null)
            //        {
            //            var driver = drivers?.FirstOrDefault(f => f.Id == x.EmployeeId);
            //            var lsDriver = new List<DropDownItemModel>()
            //        {
            //            new DropDownItemModel
            //            {
            //                Id = driver.Id,
            //                Code = driver.Name,
            //                Name = driver.Name,
            //                DisplayText = driver.Name,
            //                ItemObject = driver,
            //            }
            //        };
            //            row.Cells[colEmployeeId.Name].Value = lsDriver;
            //        }

            //    });
            //}
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
            //if (Flag == GeneralProcess.View)
            //{
            //    Close();
            //}

            //if (InValid()) { return; }
            //Write();

            //var isExist = await btnSave.RunAsync(() => SaleLogic.Instance.IsExistsAsync(Model));
            //if (isExist == true)
            //{
            //    txtInvoiceNo.IsExists(lblInvoiceNo.Text);
            //    return;
            //}

            //var result = await btnSave.RunAsync(() =>
            //{
            //    if (Flag == GeneralProcess.Add)
            //    {
            //        return SaleLogic.Instance.AddAsync(Model);
            //    }
            //    else if (Flag == GeneralProcess.Update)
            //    {
            //        return SaleLogic.Instance.UpdateAsync(Model);
            //    }
            //    else if (Flag == GeneralProcess.Remove)
            //    {
            //        return SaleLogic.Instance.RemoveAsync(Model);
            //    }

            //    return null;
            //});
            //if (result != null)
            //{
            //    Model = result;
            //    DialogResult = System.Windows.Forms.DialogResult.OK;
            //}
        }
        public void ViewChangeLog()
        {

        }
        public void Write()
        {
            //invoiceDetails = new List<RepoInvoiceDetail>();
            //invoices = new List<RepoInvoice>();
            //var invoice = new RepoInvoice();

            //invoice.PurchaseOrderNo = Model.PurchaseOrderNo = txtPurchaseOrderNo.Text;
            //invoice.InvoiceNo = Model.InvoiceNo = txtInvoiceNo.Text;
            //var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            //var site = cboSite.SelectedObject.ItemObject as Site;
            //Model.CompanyId = customer.Id;
            //Model.SiteId = site.Id;
            //Model.SaleDate = Flag == GeneralProcess.Add ? DateTime.Now : Model.SaleDate;
            //Model.Total = decimal.Parse(txtTotal.Text ?? "0");

            //invoice.Site = site.Name;
            //invoice.Customer = customer.Name;
            //invoice.Total = Model.Total;
            //invoice.SaleId = Model.Id;
            //invoices.Add(invoice);

            //if (Model.SaleDetails == null)
            //{
            //    Model.SaleDetails = new List<SaleDetail>();
            //}
            //foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            //{
            //    var invoiceDt = new RepoInvoiceDetail();
            //    var saleDetail = new SaleDetail();

            //    saleDetail.Active = true;
            //    saleDetail.Id = int.Parse(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
            //    saleDetail.SaleId = Model.Id;
            //    saleDetail.ProductId = int.Parse(row.Cells[colProductId.Name].Value.ToString());
            //    saleDetail.Qauntity = int.Parse(row.Cells[colQauntity.Name].Value.ToString());
            //    saleDetail.EmployeeId = int.Parse(row.Cells[colEmployeeId.Name].Value.ToString());
            //    saleDetail.Total = decimal.Parse(row.Cells[colTotal.Name].Value.ToString());

            //    var _pro = ProductLogic.Instance.FindAsync(saleDetail.ProductId);
            //    invoiceDt.Product = _pro.Name;
            //    invoiceDt.Qauntity = int.Parse(row.Cells[colQauntity.Name].Value.ToString());
            //    invoiceDt.UnitPrice = decimal.Parse(row.Cells[colUnitPrice.Name].Value.ToString());
            //    invoiceDt.Total = decimal.Parse(row.Cells[colTotal.Name].Value.ToString());
            //    invoiceDetails.Add(invoiceDt);

            //    if (Flag == GeneralProcess.Update)
            //    {
            //        var _saleDetail = Model.SaleDetails?.FirstOrDefault(x => x.Id == saleDetail.Id);
            //        Model.SaleDetails[Model.SaleDetails.IndexOf(_saleDetail)] = saleDetail;
            //    }
            //    else
            //    {
            //        Model.SaleDetails.Add(saleDetail);
            //    }
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
            Write();
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

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text))
            {
                return;
            }
            var pay = decimal.Parse(txtPaidAmount.Text);
            var total = decimal.Parse(txtTotal.Text ?? "0");
            txtLeftAmount.Text = (total - pay).ToString();
        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text))
            {
                txtPaidAmount.Text = "0";
            }
        }

        private void chkMarkAll__Click(object sender, EventArgs e)
        {
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                row.Cells[colMark_.Name].Value = chkMarkAll_.Checked;
            }
            CheckingAmount = chkMarkAll_.Checked ? AllSales : 0;

            CalculateTotal();
        }
    }
}
