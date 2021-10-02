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
    public partial class ReportProfitPage : ExPage
    {
        public ReportProfitPage()
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
        }
        
        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }
            
            var searchParam = new ProfitSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
            };
            
            var _Profits = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetProfitData(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };
            
            DataTable profitDt = new DataTable("Profit");
            using (var reader = ObjectReader.Create(_Profits))
            {
                profitDt.Load(reader);
            }
            var profitDts = new List<DataTable>();
            profitDts.Add(profitDt);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportProfit), profitDts, reportHeader);
                r.SummaryInfo.ReportTitle = BaseResource.ReportProfit;
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
