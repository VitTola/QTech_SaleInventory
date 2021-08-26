using FastMember;
using QTech.Base.BaseReport;
using QTech.Component;
using QTech.Db.Logics;
using Storm.CC.Report.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public static class ReportExtensions
    {
        public async static void PrintReportEmployeePrepaid(this IAsyncTask task, int employeeId, int billId = 0, bool loadAll = false)
        {
            var emp = EmployeeLogic.Instance.FindAsync(employeeId);
            if (emp == null) return;
            var prepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaid(emp.Id, billId, loadAll);
            if (prepaids?.Any() ?? false)
            {
                DataTable prepaid = new DataTable("EmployeePrepaid");
                using (var reader = ObjectReader.Create(prepaids))
                {
                    prepaid.Load(reader);
                }

                var Prepaids = new List<DataTable>();
                Prepaids.Add(prepaid);

                var reportHeader = new Dictionary<string, object>()
            {
                { "Driver" , emp.Name ?? string.Empty },
            };
                var report = await task.RunAsync(() =>
                {
                    var r = ReportHelper.Instance.Load(nameof(PrintReportEmployeePrepaid), Prepaids, reportHeader);
                    r.SummaryInfo.ReportTitle = nameof(PrintReportEmployeePrepaid);
                    return r;
                });

                if (report != null)
                {
                    var dig = new DialogReportViewer(report);
                    dig.Text = "របាយការណ៍ប្រាក់ខ្ចីមុន";
                    dig.ShowDialog();
                }
            }

        }



    }
}
