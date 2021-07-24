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
using QTech.Base.Models;

namespace QTech.Reports
{
    public partial class ReportIncomeExpensePage : ExPage
    {
        public ReportIncomeExpensePage()
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

            cboMiscellaneousType.SetDataSource<MiscellaneousType>();
        }
        private void InitEvent()
        {
        }
        private async void CboMiscellaneousType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        public async void Reload()
        {
            await Search();
        }
        public async Task Search()
        {
             View();
        }
        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }
            var searchParam = new ReportIncomeExpenseSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
                MiscellaneousType = (MiscellaneousType)cboMiscellaneousType.SelectedValue
            };
            
            var incomeExpenses = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetIncomeExpensesData(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };
            
            DataTable _incomeExpense = new DataTable("IncomeExpense");
            using (var reader = ObjectReader.Create(incomeExpenses))
            {
                _incomeExpense.Load(reader);
            }
            var incomeExpensesDts = new List<DataTable>();
            incomeExpensesDts.Add(_incomeExpense);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportGeneralInOut), incomeExpensesDts, reportHeader);
                r.SummaryInfo.ReportTitle = BaseResource.IncomeOutcome;
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
