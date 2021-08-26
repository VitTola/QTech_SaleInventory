using QTech.Base.BaseModels;
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
    public class EmployeeBillLogic : DbLogic<EmployeeBill, EmployeeBillLogic>
    {
        public override EmployeeBill FindAsync(int id)
        {
            return _db.EmployeeBills.FirstOrDefault(x => x.Id == id);
        }
        public override EmployeeBill AddAsync(EmployeeBill entity)
        {
            entity.BillNo = NewInvoiceNumber();
            var result = base.AddAsync(entity);
            if (entity.SaleDetails.Any())
            {
                entity.SaleDetails.ForEach(x =>
                {
                    x.EmployeeBillId = result.Id;
                    SaleDetailLogic.Instance.UpdateAsync(x);
                });
            }

            //Update Prepaid
            var SupplierGeneralPrepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaidByEmpId(result.EmployeeId);
            SupplierGeneralPrepaids.ForEach(x =>
            {
                x.IsCalculated = result.InvoiceStatus == InvoiceStatus.Paid ? true : false;
                x.EmployeeBillId = result.Id;
                SupplierGeneralPaidLogic.Instance.UpdateAsync(x);
            });

            return result;
        }
        public override EmployeeBill UpdateAsync(EmployeeBill entity)
        {
            var result = base.UpdateAsync(entity);
            if (entity.SaleDetails.Any())
            {
                entity.SaleDetails.ForEach(x =>
                {
                    if (x.PayStatus == PayStatus.WaitPayment || x.PayStatus == PayStatus.Paid) x.EmployeeBillId = result.Id;
                    SaleDetailLogic.Instance.UpdateAsync(x);
                });
            }

            //Update Prepaid
            if (result.InvoiceStatus == InvoiceStatus.Paid)
            {
                var SupplierGeneralPrepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaidByBillId(result.Id);
                SupplierGeneralPrepaids.ForEach(x =>
                {
                    x.IsCalculated = true;
                    SupplierGeneralPaidLogic.Instance.UpdateAsync(x);
                });
            }
            return result;
        }
        public override EmployeeBill RemoveAsync(EmployeeBill entity)
        {
            var result = base.RemoveAsync(entity);
            if (entity?.SaleDetails.Any() ?? false)
            {
                entity.SaleDetails.ForEach(x =>
                {
                    x.EmployeeBillId = 0;
                    x.PayStatus = PayStatus.NotYetPaid;
                    SaleDetailLogic.Instance.UpdateAsync(x);
                });
            }

            //Supplier Prepaid
            var SupplierGeneralPrepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaidByBillId(result.Id);
            SupplierGeneralPrepaids.ForEach(x =>
            {
                x.IsCalculated = false;
                x.EmployeeBillId = 0;
                SupplierGeneralPaidLogic.Instance.UpdateAsync(x);
            });

            return result;
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.EmployeeBills.Max(x => x.BillNo);

                if (lastInvoiceNo == null)
                {
                    invoiceNo = "SYSB-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(5, 6));
                    interval = interval + 1;
                    invoiceNo = string.Format("SYSB-{0:000000}", interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override IQueryable<EmployeeBill> Search(ISearchModel model)
        {
            var q = All();
            var param = model as EmployeeBillSearch;

            if (!string.IsNullOrEmpty(param.Search))
            {
                q = from b in q
                    join e in _db.Employees on b.EmployeeId equals e.Id
                    where e.Name.ToLower().Contains(param.Search.ToLower())
                    select b;
            }
            if (param.PayStatus == InvoiceStatus.Paid)
            {
                q = q.Where(x => x.InvoiceStatus == InvoiceStatus.Paid);
            }
            else if (param.PayStatus == InvoiceStatus.PaySome)
            {
                q = q.Where(x => x.InvoiceStatus == InvoiceStatus.PaySome);
            }
            else if (param.PayStatus == InvoiceStatus.WaitPayment)
            {
                q = q.Where(x => x.InvoiceStatus == InvoiceStatus.WaitPayment);
            }
            if (param?.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging).Results.OrderBy(x => x.Id);
            }
            return q.GroupBy(x => x.Id).Select(x => x.FirstOrDefault());
        }
        public override List<EmployeeBill> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override bool CanRemoveAsync(int id)
        {
            var entity = base.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                if (entity.InvoiceStatus != InvoiceStatus.WaitPayment)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
