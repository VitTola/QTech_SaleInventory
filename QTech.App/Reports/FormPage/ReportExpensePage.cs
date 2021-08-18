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
    public partial class ReportExpensePage : ExPage
    {
        public ReportExpensePage()
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

            cboEmployee.Name = BaseResource.Driver;
            cboEmployee.TextAll = BaseResource.Driver;
            cboEmployee.DataSourceFn = p => EmployeeLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboEmployee.SearchParamFn = () => new EmployeeSearch();
            cboEmployee.Choose = BaseResource.Driver;

        }
        
        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }

            var employee = cboEmployee.SelectedObject.ItemObject as Employee;
            var searchParam = new ReportExpenseSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
                DiriverId = employee == null ? 0 : employee.Id
            };
            
            var _expenses = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetExpenseData(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };
            
            DataTable expenseDt = new DataTable("Expense");
            using (var reader = ObjectReader.Create(_expenses))
            {
                expenseDt.Load(reader);
            }
            var expenseDts = new List<DataTable>();
            expenseDts.Add(expenseDt);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportExpense), expenseDts, reportHeader);
                r.SummaryInfo.ReportTitle = BaseResource.ReportExpense;
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

        public void EditAsync()
        {
            throw new NotImplementedException();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }
    }
}
