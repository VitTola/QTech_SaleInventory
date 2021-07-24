using EasyServer.Domain.SearchModels;
using QTech.Base;
using QTech.Base.Enums;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    class ReportLogic : DbLogic<Sale, ReportLogic>
    {
        public List<IncomeExpense> GetIncomeExpensesData(ISearchModel model)
        {
            var param = model as ReportIncomeExpenseSearch;
            var result = _db.IncomeExpenses.Where(x => x.Active && x.DoDate >= param.D1 && x.DoDate <= param.D2);
            if (param.MiscellaneousType == MiscellaneousType.Expense)
            {
                result = result.Where(x => x.MiscellaneousType == MiscellaneousType.Expense);
            }
            if (param.MiscellaneousType == MiscellaneousType.Income)
            {
                result = result.Where(x => x.MiscellaneousType == MiscellaneousType.Income);
            }
            return result.ToList();
        }

        public List<Income> GetImcomeData(ISearchModel model)
        {
            var param = model as ReportIncomeSearch;
            var result = from s in _db.Sales
                         join c in _db.Customers on s.CompanyId equals c.Id
                         join ss in _db.Sites on s.SiteId equals ss.Id
                         where s.Active && s.SaleDate >= param.D1 && s.SaleDate <= param.D2
                         && param.CustomerId == 0 ? true
                         :
                         s.CompanyId == param.CustomerId
                         select new Income
                         {
                             SaleId = s.Id,
                             InvoiceNo = s.InvoiceNo,
                             PurchaseOrderNo = s.PurchaseOrderNo,
                             Customer = c.Name,
                             Site = ss.Name,
                             SaleDate = s.SaleDate,
                             Total = s.Total,
                             Expense = s.Expense
                         };
            return result.GroupBy(x=>x.SaleId).Select(x=>x.FirstOrDefault()).ToList();
        }

        public List<Expense> GetExpenseData(ISearchModel model)
        {
            var param = model as ReportExpenseSearch;
            var result = from b in _db.EmployeeBills
                         join e in _db.Employees on b.EmployeeId equals e.Id
                         where b.Active && b.DoDate >= param.D1 && b.DoDate <= param.D2
                         && param.DiriverId == 0 ? true
                         :
                         b.EmployeeId == param.DiriverId
                         select new Expense
                         {
                             BillId = b.Id,
                             BillNo = b.BillNo,
                             PayTo = e.Name,
                             DoDate = b.DoDate,
                             Amount = b.Total
                         };
            return result.GroupBy(x => x.BillId).Select(x => x.FirstOrDefault()).ToList();
        }
    }
}
