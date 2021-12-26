using EasyServer.Domain.SearchModels;
using QTech.Base;
using QTech.Base.Enums;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.ReportModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var result = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleDate >= param.D1 && s.SaleDate <= param.D2 && s.SaleType == SaleType.Company)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id into cs
                             from scResult in cs.DefaultIfEmpty()
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id into sss
                             from ssResult in sss.DefaultIfEmpty()
                             join p in _db.PurchaseOrders.Where(p => p.Active) on s.PurchaseOrderId equals p.Id
                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = p.Name,
                                 Customer = scResult == null ? s.CustomerName : scResult.Name,
                                 Site = ssResult.Name,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense
                             };

                var result1 = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleType == SaleType.General &&
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

                var res = result.Union(result1).GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
                return res;

            }
            else
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id
                             join p in _db.PurchaseOrders.Where(p => p.Active) on s.PurchaseOrderId equals p.Id
                             where param.CustomerId == 0 ? true
                             :
                             s.CompanyId == param.CustomerId
                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = p.Name,
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
            var result = from b in _db.EmployeeBills.Where(b => b.InvoiceStatus == InvoiceStatus.Paid && b.DoDate >= param.D1 && b.DoDate <= param.D2)
                         join e in _db.Employees on b.EmployeeId equals e.Id

                         where b.Active
                         && e.Active
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

        //GET REPORTS
        public List<DriverDeliveryDetail> GetDriverDeliveryDetails(ReportDriverDeliverySearch param)
        {
            if (param.CustomerId == -1)
            {
                var q = from sal in _db.Sales.Where(x => x.Active)
                        join sad in _db.SaleDetails.Where(x => x.Active) on sal.Id equals sad.SaleId
                        join pro in _db.Products.Where(p => p.Active) on sad.ProductId equals pro.Id
                        join cat in _db.Categories.Where(c => c.Active) on pro.CategoryId equals cat.Id
                        where sal.SaleDate >= param.D1 && sal.SaleDate <= param.D2
                        && (param.DriverId == 0 ? true : sad.EmployeeId == param.DriverId)
                        && (sal.SaleType == SaleType.General)
                        && (param.ProductId == 0 ? true : sad.ProductId == param.ProductId)
                        select new DriverDeliveryDetail()
                        {
                            saleDetailId = sad.Id,
                            SaleDate = sal.SaleDate,
                            InvoiceNo = sal.InvoiceNo.ToString(),
                            PurchaseOrderNo = string.Empty,
                            Company = sal.CustomerName,
                            Site = string.Empty,
                            Qauntity = sad.Qauntity,
                            Product = pro.Name + cat.Name,
                            ImportPrice = sad.ImportPrice,
                            SubTotal = sad.ImportTotalAmount
                        };
                return q.ToList();
            }
            else if (param.CustomerId == 0)
            {
                var q = from sal in _db.Sales.Where(x => x.Active && x.SaleDate >= param.D1 && x.SaleDate <= param.D2 && x.SaleType == SaleType.Company)
                        join sad in _db.SaleDetails.Where(x => x.Active) on sal.Id equals sad.SaleId
                        join emp in _db.Employees.Where(x => x.Active) on sad.EmployeeId equals emp.Id
                        join cus in _db.Customers.Where(x => x.Active) on sal.CompanyId equals cus.Id into customers
                        from cusResult in customers.DefaultIfEmpty()
                        join sit in _db.Sites.Where(x => x.Active) on sal.SiteId equals sit.Id into sites
                        from sitResult in sites.DefaultIfEmpty()
                        join pro in _db.Products.Where(p => p.Active) on sad.ProductId equals pro.Id
                        join cat in _db.Categories.Where(c => c.Active) on pro.CategoryId equals cat.Id
                        join p in _db.PurchaseOrders.Where(p => p.Active) on sal.PurchaseOrderId equals p.Id

                        where
                        (param.DriverId == 0 ? true : sad.EmployeeId == param.DriverId)
                        && (param.SiteId == 0 ? true : sitResult.Id == param.SiteId)
                        && (param.CustomerId == 0 ? true : sal.CompanyId == param.CustomerId)
                        && (param.ProductId == 0 ? true : sad.ProductId == param.ProductId)
                        select new DriverDeliveryDetail()
                        {
                            saleDetailId = sad.Id,
                            SaleDate = sal.SaleDate,
                            InvoiceNo = sal.InvoiceNo.ToString(),
                            PurchaseOrderNo = p.Name,
                            Company = cusResult == null ? sal.CustomerName : cusResult.Name,
                            Site = sitResult == null ? string.Empty : sitResult.Name,
                            Qauntity = sad.Qauntity,
                            Product = pro.Name + cat.Name,
                            ImportPrice = sad.ImportPrice,
                            SubTotal = sad.ImportTotalAmount
                        };

                var q1 = from sal in _db.Sales.Where(x => x.Active && x.SaleDate >= param.D1 && x.SaleDate <= param.D2 && x.SaleType == SaleType.General)
                         join sad in _db.SaleDetails.Where(x => x.Active) on sal.Id equals sad.SaleId
                         join pro in _db.Products.Where(p => p.Active) on sad.ProductId equals pro.Id
                         join cat in _db.Categories.Where(c => c.Active) on pro.CategoryId equals cat.Id
                         where
                         (param.DriverId == 0 ? true : sad.EmployeeId == param.DriverId)
                         && (param.ProductId == 0 ? true : sad.ProductId == param.ProductId)
                         select new DriverDeliveryDetail()
                         {
                             saleDetailId = sad.Id,
                             SaleDate = sal.SaleDate,
                             InvoiceNo = sal.InvoiceNo.ToString(),
                             PurchaseOrderNo = string.Empty,
                             Company = sal.CustomerName,
                             Site = string.Empty,
                             Qauntity = sad.Qauntity,
                             Product = pro.Name + cat.Name,
                             ImportPrice = sad.ImportPrice,
                             SubTotal = sad.ImportTotalAmount
                         };

                return q.Union(q1).ToList();
            }
            else
            {

                var q = from sal in _db.Sales.Where(x => x.Active)
                        join sad in _db.SaleDetails.Where(x => x.Active) on sal.Id equals sad.SaleId
                        join emp in _db.Employees.Where(x => x.Active) on sad.EmployeeId equals emp.Id
                        join cus in _db.Customers.Where(x => x.Active) on sal.CompanyId equals cus.Id
                        join sit in _db.Sites.Where(x => x.Active) on sal.SiteId equals sit.Id
                        join pro in _db.Products.Where(p => p.Active) on sad.ProductId equals pro.Id
                        join cat in _db.Categories.Where(c => c.Active) on pro.CategoryId equals cat.Id
                        join p in _db.PurchaseOrders.Where(p => p.Active) on sal.PurchaseOrderId equals p.Id

                        where sal.SaleDate >= param.D1 && sal.SaleDate <= param.D2
                        && (param.DriverId == 0 ? true : sad.EmployeeId == param.DriverId)
                        && (sal.CompanyId == param.CustomerId)
                        && (param.SiteId == 0 ? true : sit.Id == param.SiteId)
                        && (param.ProductId == 0 ? true : sad.ProductId == param.ProductId)
                        select new DriverDeliveryDetail()
                        {
                            saleDetailId = sad.Id,
                            SaleDate = sal.SaleDate,
                            InvoiceNo = sal.InvoiceNo.ToString(),
                            PurchaseOrderNo = p.Name,
                            Company = cus.Name,
                            Site = sit.Name,
                            Qauntity = sad.Qauntity,
                            Product = pro.Name + cat.Name,
                            SubTotal = sad.Total
                        };
                return q.ToList();
            }
        }

        public List<Profit> GetProfitData(ProfitSearch param)
        {
            // Get all incomes
            var temp1 = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleType == SaleType.General && s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                        join sd in _db.SaleDetails.Where(x => x.Active) on s.Id equals sd.SaleId
                        join p in _db.Products.Where(x => x.Active) on sd.ProductId equals p.Id
                        where
                        (param.PaymentSource != PaymentSource.Miscellaneous)
                        && (param.CustomerId == 0 || param.CustomerId == -1)
                        && (param.ProductId == 0 ? true : p.Id == param.ProductId)
                        select new
                        {
                            Customer = QTech.Base.Properties.Resources.GeneralCustomer,
                            CustomerAmount = s.Total,
                            Expense = s.Expense
                        };

            var temp2 = from s in _db.Sales.Where(s => s.Active && s.PayStatus == PayStatus.Paid && s.SaleType == SaleType.Company && s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                        join c in _db.Customers.Where(x => x.Active) on s.CompanyId equals c.Id
                        join ss in _db.Sites.Where(x => x.Active) on s.SiteId equals ss.Id
                        join sd in _db.SaleDetails.Where(x => x.Active) on s.Id equals sd.SaleId
                        join p in _db.Products.Where(x => x.Active) on sd.ProductId equals p.Id
                        where
                        (param.PaymentSource != PaymentSource.Miscellaneous)
                        && (param.CustomerId == 0 ? true : s.CompanyId == param.CustomerId)
                        && (param.SiteId == 0 ? true : ss.Id == param.SiteId)
                        && (param.ProductId == 0 ? true : p.Id == param.ProductId)

                        select new
                        {
                            Customer = c.Name,
                            CustomerAmount = s.Total,
                            Expense = s.Expense
                        };
            var saleIncomes = temp2.GroupBy(x => x.Customer).Select(n => new
            {
                Key = 1,
                Customer = n.FirstOrDefault().Customer,
                CustomerAmount = n.Sum(c => c.CustomerAmount) - n.Sum(c => c.Expense)
            }).Union
          (
              temp1.GroupBy(x => x.Customer).Select(s => new
              {
                  Key = 1,
                  Customer = s.FirstOrDefault().Customer,
                  CustomerAmount = s.Sum(c => c.CustomerAmount) - s.Sum(d => d.Expense)
              })
            ).ToList();

            var temp3 = from e in _db.IncomeExpenses.Where(x => x.Active && x.DoDate >= param.D1 && x.DoDate <= param.D2 &&
                                  x.MiscellaneousType == MiscellaneousType.Income)
                        where param.PaymentSource != PaymentSource.Sale
                        select new
                        {
                            Customer = "temp",
                            GeneralIncome = e.Amount
                        };

            var generalIncomes = temp3.GroupBy(x => x.Customer).Select(x => new
            {
                Key = 1,
                GeneralIncome = x.Sum(y => y.GeneralIncome)
            }).ToList();

            var sTotal = saleIncomes.Sum(x => x.CustomerAmount);

            //Get all expense
            var temp4 = from s in _db.Sales.Where(x => x.Active && x.SaleDate <= param.D2 && x.SaleDate >= param.D1 && x.PayStatus == PayStatus.Paid && x.SaleType == SaleType.Company)
                        join c in _db.Customers.Where(x => x.Active) on s.CompanyId equals c.Id
                        join ss in _db.Sites.Where(x => x.Active) on s.SiteId equals ss.Id
                        join sd in _db.SaleDetails.Where(x => x.Active) on s.Id equals sd.SaleId
                        join p in _db.Products.Where(x => x.Active) on sd.ProductId equals p.Id
                        join e in _db.Employees.Where(x => x.Active) on sd.EmployeeId equals e.Id
                        where
                        (param.PaymentSource != PaymentSource.Miscellaneous)
                        && (param.CustomerId == 0 ? true : s.CompanyId == param.CustomerId)
                        && (param.SiteId == 0 ? true : ss.Id == param.SiteId)
                        && (param.ProductId == 0 ? true : p.Id == param.ProductId)
                        select new
                        {
                            Driver = e.Name,
                            DriverAmount = sd.ImportTotalAmount
                        };
            var res1 = temp4.ToList();

            var tempGeneral = from s in _db.Sales.Where(x => x.Active && x.SaleDate <= param.D2 && x.SaleDate >= param.D1 && x.PayStatus == PayStatus.Paid && x.SaleType == SaleType.General)
                              join sd in _db.SaleDetails.Where(x => x.Active) on s.Id equals sd.SaleId
                              join p in _db.Products.Where(x => x.Active) on sd.ProductId equals p.Id
                              join e in _db.Employees.Where(x => x.Active) on sd.EmployeeId equals e.Id
                              where
                                    (param.PaymentSource != PaymentSource.Miscellaneous)
                                    && (param.CustomerId == 0 || param.CustomerId == -1)
                                    && (param.ProductId == 0 ? true : p.Id == param.ProductId)
                              select new
                              {
                                  Driver = e.Name,
                                  DriverAmount = sd.ImportTotalAmount
                              };

            var totalExpenses = temp4.Concat(tempGeneral);
            var driverExpenses = totalExpenses.GroupBy(x => x.Driver).Select(x => new
            {
                Key = 1,
                Driver = x.FirstOrDefault().Driver,
                DriverAmount = x.Sum(y => y.DriverAmount),
            }).ToList();

            var temp5 = from e in _db.IncomeExpenses.Where(x => x.Active && x.DoDate >= param.D1 && x.DoDate <= param.D2 &&
                                 x.MiscellaneousType == MiscellaneousType.Expense)
                        where param.PaymentSource != PaymentSource.Sale
                        select new
                        {
                            Key = e.Amount > 0 ? 1 : 0,
                            Customer = "temp",
                            GeneralExpense = e.Amount
                        };
            var generalExpenses = temp5.GroupBy(x => x.Customer).Select(x => new
            {
                Key = 1,
                GeneralExpense = x.Sum(y => y.GeneralExpense)
            }).ToList();

            var profits = new List<Profit>();
            int si = saleIncomes.Count(), gi = generalIncomes.Count(), de = driverExpenses.Count(), ge = generalExpenses.Count();
            int maxCount = new[] { si, gi, de, ge }.Max();
            for (int i = 0; i < maxCount; i++)
            {
                profits.Add(
                    new Profit
                    {
                        Customer = i < si ? saleIncomes[i].Customer : string.Empty,
                        CustomerAmount = i < si ? saleIncomes[i].CustomerAmount : 0,
                        GeneralIncome = i < gi ? generalIncomes[i].GeneralIncome : 0,
                        Driver = i < de ? driverExpenses[i]?.Driver : string.Empty,
                        DriverAmount = i < de ? driverExpenses[i].DriverAmount : 0,
                        GeneralExpense = i < ge ? generalExpenses[i].GeneralExpense : 0
                    }
                    );
            }

            return profits;
        }

        public List<Income> GetInvoiceStatuses(ReportIncomeSearch model)
        {
            var param = model;
            if (param.CustomerId == -1)
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.SaleType == SaleType.General &&
                s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                             where (s.PayStatus == param.PayStatus || param.PayStatus == PayStatus.All)
                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = string.Empty,
                                 Customer = s.CustomerName,
                                 Site = string.Empty,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense,
                                 Status = s.PayStatus == PayStatus.NotYetPaid ? BaseResource.PayStatus_NotYetPaid :
                                 (s.PayStatus == PayStatus.All ? BaseResource.PayStatus_All : (s.PayStatus == PayStatus.Paid ? BaseResource.PayStatus_Paid : BaseResource.PayStatus_WaitPayment))

                             };
                var _result = result.GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
                return _result;
            }
            else if (param.CustomerId == 0)
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.SaleType == SaleType.Company && s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id into cs
                             from scResult in cs.DefaultIfEmpty()
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id into sss
                             from ssResult in sss.DefaultIfEmpty()
                             join p in _db.PurchaseOrders.Where(p => p.Active) on s.PurchaseOrderId equals p.Id

                             where (s.PayStatus == param.PayStatus || param.PayStatus == PayStatus.All)

                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = p.Name,
                                 Customer = scResult == null ? s.CustomerName : scResult.Name,
                                 Site = ssResult.Name,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense,
                                 Status = s.PayStatus == PayStatus.NotYetPaid ? BaseResource.PayStatus_NotYetPaid :
                                 (s.PayStatus == PayStatus.All ? BaseResource.PayStatus_All : (s.PayStatus == PayStatus.Paid ? BaseResource.PayStatus_Paid : BaseResource.PayStatus_WaitPayment))

                             };

                var result1 = from s in _db.Sales.Where(s => s.Active && s.SaleType == SaleType.General &&
               s.SaleDate >= param.D1 && s.SaleDate <= param.D2)
                              where (s.PayStatus == param.PayStatus || param.PayStatus == PayStatus.All)
                              select new Income
                              {
                                  SaleId = s.Id,
                                  InvoiceNo = s.InvoiceNo,
                                  PurchaseOrderNo = string.Empty,
                                  Customer = s.CustomerName,
                                  Site = string.Empty,
                                  SaleDate = s.SaleDate,
                                  Total = s.Total,
                                  Expense = s.Expense,
                                  Status = s.PayStatus == PayStatus.NotYetPaid ? BaseResource.PayStatus_NotYetPaid :
                                  (s.PayStatus == PayStatus.All ? BaseResource.PayStatus_All : (s.PayStatus == PayStatus.Paid ? BaseResource.PayStatus_Paid : BaseResource.PayStatus_WaitPayment))

                              };

                var res = result.Union(result1).GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
                return res;

            }
            else
            {
                var result = from s in _db.Sales.Where(s => s.Active && s.SaleDate >= param.D1 && s.SaleDate <= param.D2 && s.SaleType == SaleType.Company)
                             join c in _db.Customers.Where(c => c.Active) on s.CompanyId equals c.Id
                             join ss in _db.Sites.Where(ss => ss.Active) on s.SiteId equals ss.Id
                             join p in _db.PurchaseOrders.Where(p => p.Active) on s.PurchaseOrderId equals p.Id

                             where param.CustomerId == 0 ? true
                             :
                             s.CompanyId == param.CustomerId
                             && (s.PayStatus == param.PayStatus || param.PayStatus == PayStatus.All)

                             select new Income
                             {
                                 SaleId = s.Id,
                                 InvoiceNo = s.InvoiceNo,
                                 PurchaseOrderNo = p.Name,
                                 Customer = c.Name,
                                 Site = ss.Name,
                                 SaleDate = s.SaleDate,
                                 Total = s.Total,
                                 Expense = s.Expense,
                                 Status = s.PayStatus == PayStatus.NotYetPaid ? BaseResource.PayStatus_NotYetPaid :
                                 (s.PayStatus == PayStatus.All ? BaseResource.PayStatus_All : (s.PayStatus == PayStatus.Paid ? BaseResource.PayStatus_Paid : BaseResource.PayStatus_WaitPayment))

                             };
                return result.GroupBy(x => x.SaleId).Select(x => x.FirstOrDefault()).ToList();
            }

        }
    }
}
