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

namespace QTech.Reports
{
    public partial class ReportImcomePage : ExPage
    {

        public ReportImcomePage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
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
        }

        private void InitEvent()
        {
        }
        
        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }

            var customer = cboCustomer.SelectedObject?.ItemObject as Customer;
            var searchParam = new ReportIncomeSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
               CustomerId = customer==null? 0 : customer.Id,
            };
            
            var incomes = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetImcomeData(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };


            DataTable incomeDt = new DataTable("Income");
            using (var reader = ObjectReader.Create(incomes))
            {
                incomeDt.Load(reader);
            }
            var incomeDts = new List<DataTable>();
            incomeDts.Add(incomeDt);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportProfitExpense), incomeDts, reportHeader);
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
