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
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmCreateInvoice : ExDialog, IDialog
    {
        public Invoice Model { get; set; }
        private decimal Total;
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

            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();

        }
        public void InitEvent()
        {
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.CreateInvoice);
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
            //txtPaidAmount.SetTextBoxValueWhenMouseInOut("0");
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
            if (!cboCustomer.IsSelected())
            {
                return;
            }
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

            List<Site> _sites = null;
            var sales = await dgv.RunAsync(() =>
            {
                var result = SaleLogic.Instance.GetSaleByCustomerId(search);
                var SitesIds = result?.Select(x => x.SiteId).ToList();
                _sites = SiteLogic.Instance.GetSiteByIds(SitesIds);
                return result;
            });
            DataGridFillValue(sales,customer,_sites);
        }
        private void DataGridFillValue(List<Sale> sales, Customer customer = null,List<Site> _sites = null)
        {
            if (sales.Any())
            {
                sales.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colPurchaseOrderNo.Name].Value = x.PurchaseOrderNo;
                    row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                    row.Cells[colToCompany.Name].Value = customer.Name;
                    row.Cells[colToSite.Name].Value = _sites?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                    row.Cells[colTotal.Name].Value = x.Total;
                    row.Cells[colSaleDate.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                    row.Cells[colIsPaid.Name].Value = x.PayStatus;
                    if (Flag ==GeneralProcess.Add)
                    {
                        row.Cells[colMark_.Name].Value = false;
                    }
                    else
                    {
                        chkMarkAll_.Checked = true;
                        row.Cells[colMark_.Name].Value = true;
                    }

                    var cell = row.Cells[colStatus.Name];
                    if (x.PayStatus == PayStatus.Paid)
                    {
                        row.Cells[colStatus.Name].Value = BaseResource.IsPaid;
                        cell.Style.ForeColor = Color.Red;
                    }
                    else if (x.PayStatus == PayStatus.WaitPayment)
                    {
                        row.Cells[colStatus.Name].Value = BaseResource.PayStatus_WaitPayment;
                        cell.Style.ForeColor = Color.Orange;
                    }
                    else
                    {
                        row.Cells[colStatus.Name].Value = BaseResource.NotYetPaid;
                        cell.Style.ForeColor = Color.Green;
                    }

                    AllSales++;
                });
                dgv.Sort(dgv.Columns[colSaleDate.Name], ListSortDirection.Descending);
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
        public bool InValid()
        {
            bool _isValid = true;
            if (cboCustomer.IsSelected())
            {
                _isValid = false;
            }

            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_.Name]?.Value)
                {
                    _isValid = false;
                    break;
                }
            }
            return _isValid;
        }
        public async void Read()
        {
            if (Flag == GeneralProcess.Add)
            {
                return;
            }
            Customer customer = null;
            List<InvoiceDetail> invoiceDetails = null ;
            List<Sale> sales = null;
            List<Site> sites = null;
            var result = await this.RunAsync(() =>
            {
                customer = CustomerLogic.Instance.FindAsync(Model.CustomerId);
                invoiceDetails = InvoiceDetailLogic.Instance.GetInvoiceDetailByInvoiceId(Model.Id);
                var saleIds = invoiceDetails?.Select(x => x.SaleId).ToList();
                sales = SaleLogic.Instance.GetSaleByIds(saleIds);
                sites = SiteLogic.Instance.GetSiteByIds(sales.Select(x=>x.SiteId).ToList());
                return customer;
            });
            if (customer != null)
            {
                cboCustomer.SetValue(customer);
            }
            txtInvoiceNo.Text = Model.InvoiceNo;
            dtpInvoicingDate.Value = Model.InvoicingDate;
            txtTotal.Text = Model.TotalAmount.ToString();
            txtPaidAmount.Text = Model.PaidAmount.ToString();
            txtLeftAmount.Text = Model.LeftAmount.ToString();
            DataGridFillValue(sales, customer, sites);
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

            var isExist = await btnSave.RunAsync(() => InvoiceLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtInvoiceNo.IsExists(lblInvoiceNo.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return InvoiceLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return InvoiceLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return InvoiceLogic.Instance.RemoveAsync(Model);
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
            if (Model.InvoiceDetails == null)
            {
                Model.InvoiceDetails = new List<InvoiceDetail>();
            }
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            Model.CustomerId = customer.Id;
            Model.InvoiceNo = txtInvoiceNo.Text;
            Model.InvoicingDate = dtpInvoicingDate.Value;
            Model.TotalAmount = decimal.Parse(txtTotal.Text);
            Model.PaidAmount = decimal.Parse(string.IsNullOrEmpty(txtPaidAmount.Text) ? "0" : txtPaidAmount.Text);
            Model.LeftAmount = decimal.Parse(txtLeftAmount.Text);
            if (Model.PaidAmount == 0)
            {
                Model.InvoiceStatus = InvoiceStatus.WaitPayment;
            }
            else if (Model.LeftAmount == 0)
            {
                Model.InvoiceStatus = InvoiceStatus.Paid;
            }
            else
            {
                Model.InvoiceStatus = InvoiceStatus.PaySome;
            }

            dgv.EndEdit();
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                InvoiceDetail invoiceDt = new InvoiceDetail();
                var _isChecked = (bool)(row.Cells[colMark_.Name].Value ?? false);
                if (_isChecked)
                {
                    invoiceDt.SaleId = int.Parse(row.Cells[colId.Name].Value?.ToString());
                    invoiceDt.InvoiceId = Model.Id;
                    Model.InvoiceDetails.Add(invoiceDt);
                }
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

            var reportHeader = new Dictionary<string, object>();
            reportHeader.Add("Supplier", BaseResource.Company);
            reportHeader.Add("SupplierSource", "ឡានដឹក");
            reportHeader.Add("DoDate", DateTime.Now.ToString("dd/MM/yyyy"));
            var AllTotal = decimal.Parse(txtTotal.Text);
            reportHeader.Add("Total", String.Format("{0:C}", AllTotal));

            var MonthlyInvoices = new List<MonthlyInvoice>();
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                var total = decimal.Parse(row.Cells[colTotal.Name].Value?.ToString());
                MonthlyInvoices.Add(
                new MonthlyInvoice()
                {
                    SaleDate = row.Cells[colSaleDate.Name].Value.ToString(),
                    InvoiceNo = row.Cells[colInvoiceNo.Name].Value?.ToString(),
                    
                    TotalInUSD = String.Format("{0:C}", total),
                    PurchaseOrderNo = row.Cells[colPurchaseOrderNo.Name].Value?.ToString(),
                    Site = row.Cells[colToSite.Name].Value?.ToString()
                });
            }
            DataTable Invoice = new DataTable("MonthlyInvoice");
            using (var reader = ObjectReader.Create(MonthlyInvoices))
            {
                Invoice.Load(reader);
            }
            var Invoices = new List<DataTable>();
            Invoices.Add(Invoice);

            var report = await dgv.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportMonthlyInvoice), Invoices, reportHeader);
                r.SummaryInfo.ReportTitle = nameof(ReportMonthlyInvoice);
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
