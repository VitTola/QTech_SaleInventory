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
using BaseResource = QTech.Base.Properties.Resources;
namespace QTech.Db.Logics
{
    public class ReportLogic : DbLogic<Sale, ReportLogic>
    {
        public List<IncomeExpenseOutface> GetIncomeExpensesData(ReportIncomeExpenseSearch model)
        {
            var param = model;
            var result = _db.IncomeExpenses.Where(x => x.Active && x.DoDate >= param.D1 && x.DoDate <= param.D2);
            var r = result.ToList();
            if (param.MiscellaneousType == MiscellaneousType.Expense)
            {
                result = result.Where(x => x.MiscellaneousType == MiscellaneousType.Expense);
            }
            if (param.MiscellaneousType == MiscellaneousType.Income)
            {
                result = result.Where(x => x.MiscellaneousType == MiscellaneousType.Income);
            }
            var incomeExpenses = from e in result
                                 select new IncomeExpenseOutface
                                 {
                                     MiscNo = e.MiscNo,
                                     DoDate = e.DoDate,
                                     Note = e.Note,
                                     Amount = e.Amount,
                                     MiscType = e.MiscellaneousType == MiscellaneousType.Income ? BaseResource.MiscellaneousType_Income
                                     : BaseResource.MiscellaneousType_Expense,
                                 };

            var res = incomeExpenses.ToList();
            return res;
        }

        public List<Income> GetImcomeData(ReportIncomeSearch model)
        {
            var param = model;
            if (param.CustomerId == -1)
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleType == SaleType.General &&
                s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = string.Empty,
                                 Customer = s.CustomerName,
                                 Site = string.Empty,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense
                             };
                var _result = result.GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
                return _result;
            }
            else if (param.CustomerId == 0)
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id into cs
                             from scResult in cs.DefaultIfEmpty()
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id 
                             select new Income
                             {
                                 SaleId = scResult.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = s.PurchaseOrderNo,
                                 Customer = scResult == null ? s.CustomerName : scResult.Name,
                                 Site = ss.Name,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense
                             };
                 var res = result.GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
                return res;
                
            }
            else
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id
                             where
                             s.SaleDate >= param.D1 && s.SaleDate <= param.D2
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
                return result.GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
            }

        }

        public List<Expense> GetExpenseData(ReportExpenseSearch model)
        {
            var param = model;
            var result = from b in _db.EmployeeBills.Where(b => b.InvoiceStatus == InvoiceStatus.Paid)
                         join e in _db.Employees on b.EmployeeId equals e.Id
                         where b.Active
                         && e.Active
                         && b.DoDate >= param.D1 && b.DoDate <= param.D2
                         && param.DiriverId == 0 ? true : b.EmployeeId == param.DiriverId
                         select new Expense
                         {
                             BillId = b.Id,
                             BillNo = b.BillNo,
                             PayTo = e.Name,
                             DoDate = b.DoDate,
                             Amount = b.Total
                         };
            var _result = result.GroupBy(x => x.BillId).Select(x => x.FirstOrDefault()).ToList();
            return _result;
        }
    }
}
