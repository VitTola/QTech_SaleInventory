using EasyServer.Domain.Helpers;
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
        private List<PurchaseOrder> purchaseOrders = null;
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
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View && Model.SaleType != SaleType.General);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowRowNotFound(false);
            dgv.ReadOnly = dgvView.ReadOnly = true;
            dgv.SetColumnHeaderDefaultStyle();

            colMark_.ReadOnly = false;
            dgv.SetColumnHeaderDefaultStyle();
            dgvView.SetColumnHeaderDefaultStyle();

            if (Flag == GeneralProcess.Add || Flag == GeneralProcess.Update)
            {
                cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
                dtpSearchDate.SelectedIndexChanged += dtpSearchDate_SelectedIndexChanged;
                dgvView.CellContentClick += dgvView_CellContentClick;
                txtPaidAmount.KeyPress += (s, e) => { txtPaidAmount.validCurrency(s, e); };
                btnLeft_.Click += BtnLeft_Click;
                btnRigt_.Click += BtnRigt_Click;
            }
            txtPaidAmount.ReadOnly = Flag == GeneralProcess.Remove && Flag == GeneralProcess.View;
            txtTotal.ReadOnly = txtLeftAmount.ReadOnly = txtInvoiceNo.ReadOnly = true;
            dtpInvoicingDate.Enabled = false;
            txtPaidAmount.KeyUp += TxtPaidAmount_KeyUp;
            this.Load += FrmCreateInvoice_Load;
            cboCustomer.Enabled = Flag == GeneralProcess.Add;
        }
        private void BtnRigt_Click(object sender, EventArgs e)
        {
            if (dgvView.RowCount == 0) return;
            dgvView.EndEdit();
            var Rows = dgvView.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow && (bool)(x.Cells[colMark2_.Name].Value))?.ToList();
            foreach (DataGridViewRow row in Rows)
            {
                var r = newRow(dgv);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    r.Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }
            Rows.ForEach(r => dgvView.Rows.Remove(r));
            CalculateTotal();
        }
        private void BtnLeft_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            dgv.EndEdit();
            var row = dgv.CurrentRow;
            int index = dgvView.Rows.Add(row.Clone() as DataGridViewRow);
            foreach (DataGridViewCell o in row.Cells)
            {
                dgvView.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
            }
            dgv.Rows.Remove(dgv.CurrentRow);
            CalculateTotal();
        }
        private void FrmCreateInvoice_Load(object sender, EventArgs e)
        {
            if (Flag == GeneralProcess.Remove || Flag == GeneralProcess.View || Model.SaleType == SaleType.General) dgv.Enabled = false;
        }
        private void TxtPaidAmount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotal();
        }
        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colMark2_.Index)
            {
                var _isCheck = (bool)(dgvView.CurrentRow.Cells[colMark2_.Name]?.Value);
                dgvView.CurrentRow.Cells[colMark2_.Name].Value = !_isCheck;

                if (!_isCheck && CheckingAmount < AllSales)
                {
                    CheckingAmount++;
                }
                else
                {
                    CheckingAmount--;
                }
                chkMarkAll_.Checked = CheckingAmount == AllSales ? true : false;
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
            var sales = await dgvView.RunAsync(() =>
            {
                var result = SaleLogic.Instance.GetSaleByCustomerId(search);
                var SitesIds = result?.Select(x => x.SiteId).ToList();
                _sites = SiteLogic.Instance.GetSiteByIds(SitesIds);

                var pSearch = new PurchaseOrderSearch
                {
                    Paging = new Base.BaseModels.Paging { IsPaging = false }
                };
                purchaseOrders = PurchaseOrderLogic.Instance.SearchAsync(pSearch);
                return result;
            });

            FillDgvView(sales, customer, _sites);
        }
        private void FillDgvView(List<Sale> sales, Customer customer = null, List<Site> _sites = null)
        {
            if (sales?.Any() ?? false)
            {
                dgvView.Rows.Clear();
                sales.ForEach(x =>
                {
                    var row = newRow(dgvView);
                    row.Cells[colId2.Name].Value = Model.InvoiceDetails?.FirstOrDefault(s => s.SaleId == x.Id)?.Id ?? 0;
                    row.Cells[colSaleId2.Name].Value = x.Id;
                    row.Cells[colPurchaseOrderNo2.Name].Value = purchaseOrders?.FirstOrDefault(p => p.Id == x.PurchaseOrderId)?.Name ?? ""; ;
                    row.Cells[colInvoiceNo2.Name].Value = x.InvoiceNo;
                    row.Cells[colToCompany2.Name].Value = customer?.Name;
                    row.Cells[colToSite2.Name].Value = _sites?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                    row.Cells[colTotal2.Name].Value = x.Total;
                    row.Cells[colSaleDate2.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                    row.Cells[colIsPaid2.Name].Value = x.PayStatus;
                    if (Flag == GeneralProcess.Add)
                    {
                        row.Cells[colMark2_.Name].Value = false;
                    }
                    else
                    {
                        chkMarkAll_.Checked = true;
                        row.Cells[colMark2_.Name].Value = true;
                    }

                    var cell = row.Cells[colStatus2.Name];
                    if (x.PayStatus == PayStatus.Paid)
                    {
                        row.Cells[colStatus2.Name].Value = BaseResource.IsPaid;
                        cell.Style.ForeColor = Color.Red;
                    }
                    else if (x.PayStatus == PayStatus.WaitPayment)
                    {
                        row.Cells[colStatus2.Name].Value = BaseResource.PayStatus_WaitPayment;
                        cell.Style.ForeColor = Color.Orange;
                    }
                    else
                    {
                        row.Cells[colStatus2.Name].Value = BaseResource.NotYetPaid;
                        cell.Style.ForeColor = Color.Green;
                    }

                    AllSales++;
                });
                dgvView.Sort(dgvView.Columns[colSaleDate2.Name], ListSortDirection.Descending);
            }
            //CalculateTotal();
        }
        private void FillDgv(List<Sale> sales, Customer customer = null, List<Site> _sites = null)
        {
            if (sales?.Any() ?? false)
            {
                sales.ForEach(x =>
                {
                    //var row = dgv.Rows[dgv.Rows.Add()];
                    var row = newRow(dgv);
                    row.Cells[colId.Name].Value = Model.InvoiceDetails?.FirstOrDefault(s => s.SaleId == x.Id)?.Id ?? 0;
                    row.Cells[colSaleId.Name].Value = x.Id;
                    row.Cells[colPurchaseOrderNo.Name].Value = purchaseOrders?.FirstOrDefault(p=>p.Id == x.PurchaseOrderId)?.Name ?? "";
                    row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                    var customerName = Model.SaleType == SaleType.General ? Model.CustomerName : customer.Name;
                    row.Cells[colToCompany.Name].Value = customerName;
                    row.Cells[colToSite.Name].Value = _sites?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                    row.Cells[colTotal.Name].Value = x.Total;
                    row.Cells[colSaleDate.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                    row.Cells[colIsPaid.Name].Value = x.PayStatus;
                    if (Flag == GeneralProcess.Add)
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
            //CalculateTotal();
            dgv.Enabled = true;
        }
        private void CalculateTotal()
        {
            Total = 0;
            //txtPaidAmount.Text = string.Empty;
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                Total = Total + Parse.ToDecimal(row.Cells[colTotal.Name].Value?.ToString() ?? "0");
            }

            var paidAmount = !string.IsNullOrEmpty(txtPaidAmount.Text) ? decimal.Parse(txtPaidAmount.Text) : 0;
            txtLeftAmount.Text = (Total - paidAmount).ToString();
            txtTotal.Text = Total.ToString();
        }
        public bool InValid()
        {
            bool _isValid = true;
            if (cboCustomer.IsSelected())
            {
                _isValid = false;
            }

            if (dgv.RowCount > 0)
            {
                _isValid = false;
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
            List<Sale> sales = null;
            List<Site> sites = null;
            var result = await this.RunAsync(() =>
            {
                customer = CustomerLogic.Instance.FindAsync(Model.CustomerId);
                Model.InvoiceDetails = InvoiceDetailLogic.Instance.GetInvoiceDetailByInvoiceId(Model.Id);
                var saleIds = Model.InvoiceDetails?.Select(x => x.SaleId).ToList();
                sales = SaleLogic.Instance.GetSaleByIds(saleIds);
                sites = SiteLogic.Instance.GetSiteByIds(sales.Select(x => x.SiteId).ToList());

                var pSearch = new PurchaseOrderSearch
                {
                    Paging = new Base.BaseModels.Paging { IsPaging = false }
                };
                purchaseOrders = PurchaseOrderLogic.Instance.SearchAsync(pSearch);
                return customer;
            });
            if (customer != null)
            {
                cboCustomer.SetValue(customer);
            }
            else
            {
                cboCustomer.SetValue(new Customer { Name = Model.CustomerName });
                cboCustomer.Enabled = false;
            }
            txtInvoiceNo.Text = Model.InvoiceNo;
            dtpInvoicingDate.Value = Model.InvoicingDate;
            txtTotal.Text = Model.TotalAmount.ToString();
            txtPaidAmount.Text = Model.PaidAmount.ToString();
            txtLeftAmount.Text = Model.LeftAmount.ToString();
            FillDgv(sales, customer, sites);
            CalculateTotal();
        }
        private DataGridViewRow newRow(ExDataGridView grid, bool isFocus = false)
        {
            var row = grid.Rows[grid.Rows.Add()];
            //row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                grid.Focus();
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

            if (Model.SaleType == SaleType.Company)
            {
                var customer = cboCustomer.SelectedObject?.ItemObject as Customer;
                Model.CustomerId = customer.Id;
            }
            else
            {
                Model.CustomerName = cboCustomer.Text;
            }
            Model.InvoiceNo = txtInvoiceNo.Text;
            Model.InvoicingDate = dtpInvoicingDate.Value;
            Model.TotalAmount = Parse.ToDecimal(txtTotal.Text);
            Model.PaidAmount = Parse.ToDecimal(txtPaidAmount.Text);
            Model.LeftAmount = Parse.ToDecimal(txtLeftAmount.Text);
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

            //Set Existing active to false and if still chect in grid set it again to true
            Model.InvoiceDetails.ForEach(x => x.Active = false);

            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                InvoiceDetail invoiceDt = new InvoiceDetail();
                invoiceDt.SaleId = int.Parse(row.Cells[colSaleId.Name].Value?.ToString() ?? "0");
                invoiceDt.Id = int.Parse(row.Cells[colId.Name].Value?.ToString() ?? "0");

                if (!Model.InvoiceDetails.Any(x => x.Id == invoiceDt.Id) || invoiceDt.Id == 0)
                {
                    invoiceDt.InvoiceId = Model.Id;
                    Model.InvoiceDetails.Add(invoiceDt);
                }
                else
                {
                    Model.InvoiceDetails.ForEach(x =>
                    {
                        if (x.SaleId == invoiceDt.SaleId)
                        {
                            Model.InvoiceDetails[Model.InvoiceDetails.IndexOf(x)].Active = true;
                        }
                    });

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
            if (InValid() || dgv.RowCount == 0) return;

            var reportHeader = new Dictionary<string, object>();
            reportHeader.Add("Supplier", BaseResource.Company);
            reportHeader.Add("SupplierSource", "ឡានដឹក");
            reportHeader.Add("DoDate", DateTime.Now.ToString("dd/MM/yyyy"));
            var AllTotal = decimal.Parse(string.IsNullOrEmpty(txtTotal.Text) ? "0" : txtTotal.Text);
            reportHeader.Add("Total", String.Format("{0:C}", AllTotal));

            var saleIds = new List<int>();
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            Rows.OfType<DataGridViewRow>().ToList().ForEach(row => saleIds.Add(Parse.ToInt(row.Cells[colSaleId.Name].Value?.ToString())));
            var MonthlyInvoices = SaleDetailLogic.Instance.GetMonthlyInvoiceBySaleIds(saleIds);

            DataTable Invoice = new DataTable("MonthlyInvoice");
            using (var reader = ObjectReader.Create(MonthlyInvoices))
            {
                Invoice.Load(reader);
            }
            var Invoices = new List<DataTable>();
            Invoices.Add(Invoice);

            var report = await btnPrint.RunAsync(() =>
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
            var total = decimal.Parse(string.IsNullOrEmpty(txtTotal.Text) ? "0" : txtTotal.Text);
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
            var Rows = dgvView.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                row.Cells[colMark2_.Name].Value = chkMarkAll_.Checked;
            }
            CheckingAmount = chkMarkAll_.Checked ? AllSales : 0;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
            }
            else if (keyData == (Keys.Control | Keys.Q))
            {
                btnClose.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
