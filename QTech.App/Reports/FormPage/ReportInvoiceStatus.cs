using QTech.Base;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using System.Collections.Generic;
using System.Drawing;
using QTech.Component.Interfaces;
using System.Data;
using FastMember;
using QTech.ReportModels;
using Storm.CC.Report.Helpers;
using QTech.Component.Helpers;
using QTech.Base.Enums;

namespace QTech.Reports
{
    public partial class ReportInvoiceStatus : ExPage
    {

        public ReportInvoiceStatus()
        {
            InitializeComponent();
            Bind();
        }


        private void Bind()
        {
            var maxDate = DateTime.Now;
            dtpPeroid.CustomDateRang = CustomDateRang.None;
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(dtpPeroid.CustomDateRang, maxDate);
            dtpPeroid.SetMaxDate(maxDate);
            dtpPeroid.Items.AddRange(peroids.ToArray());
            dtpPeroid.Items.Add(customPeroid);
            dtpPeroid.SetSelectePeroid(DatePeroid.Today);

            cboCustomer.TextAll = BaseResource.Customer;
            var customers = CustomerLogic.Instance.SearchAsync(new CustomerSearch())?.ToList() ?? new List<Customer>();
            var customer = new Customer() {Id = -1, Name = BaseResource.GeneralCustomer };
            customers.Add(customer);
            cboCustomer.DataSourceFn = p =>customers.ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
            cboCustomer.Choose = BaseResource.Customer;

            cboPayStatus.SetDataSource<PayStatus>();

        }
        
        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }

            var _payStatus = (PayStatus)cboPayStatus.SelectedValue;
            var customer = cboCustomer.SelectedObject?.ItemObject as Customer;
            var searchParam = new QTech.Base.SearchModels.ReportIncomeSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
               CustomerId = customer==null? 0 : customer.Id,
               PayStatus = _payStatus
            };
            
            var incomes = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetInvoiceStatuses(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };


            DataTable invoiceStatusDt = new DataTable("Income");
            using (var reader = ObjectReader.Create(incomes))
            {
                invoiceStatusDt.Load(reader);
            }
            var invoiceStatusDts = new List<DataTable>();
            invoiceStatusDts.Add(invoiceStatusDt);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportInvoiceStatus), invoiceStatusDts, reportHeader);
                r.SummaryInfo.ReportTitle =BaseResource.ReportIncome;
                return r;
            });

            if (report != null)
            {
                viewer.View(report);
            }
        }
        private bool inValid()
        {
            if (!dtpPeroid.IsSelected())
            {
                return true;
            }
            return false;
        }
        private void dig_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                View();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }
    }
}
