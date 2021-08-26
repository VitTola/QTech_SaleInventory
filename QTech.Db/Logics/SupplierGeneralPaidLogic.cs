using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SupplierGeneralPaidLogic : DbLogic<SupplierGeneralPaid, SupplierGeneralPaidLogic>
    {
        public override List<SupplierGeneralPaid> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override IQueryable<SupplierGeneralPaid> Search(ISearchModel model)
        {
            var param = model as SupplierGeneralPaidSearch;
            var q = All();
            if (param.EmployeeId != 0)
            {
                q = q.Where(x =>!x.IsCalculated && x.EmployeeId == param.EmployeeId);
            }
            return q;
        }
        public List<SupplierGeneralPaid> GetSupplierGeneralPaid(int employeeId, int billId, bool loadAll = false)
        {
            var q = All().Where(x => x.EmployeeId == employeeId);
            if (billId != 0)
            {
                q = q.Where(x => x.EmployeeBillId == billId);
            }
            return q.ToList();
        }
        public List<SupplierGeneralPaid> GetSupplierGeneralPaidByEmpId(int employeeId)
        {
            return _db.SupplierGeneralPaids.Where(x => !x.IsCalculated && x.EmployeeBillId == 0 && x.EmployeeId == employeeId).ToList();
        }
        public List<SupplierGeneralPaid> GetSupplierGeneralPaidByBillId(int BillId)
        {
            return _db.SupplierGeneralPaids.Where(x => !x.IsCalculated && x.EmployeeBillId == BillId).ToList();
        }
    }
}