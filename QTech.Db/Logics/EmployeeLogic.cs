using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class EmployeeLogic: DbLogic<Employee,EmployeeLogic>
    {
        public override Employee FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override Employee AddAsync(Employee entity)
        {
            var employee = base.AddAsync(entity);
            return employee;
        }
        public override Employee UpdateAsync(Employee entity)
        {
            var employee = base.UpdateAsync(entity);
            if (entity.SupplierGeneralPaids?.Any() ?? false)
            {
                employee.SupplierGeneralPaids.ForEach(x=>
                {
                    if (x.Id == 0)
                    {
                        x.EmployeeId = employee.Id;
                        SupplierGeneralPaidLogic.Instance.AddAsync(x);
                    }
                    else
                    {
                        SupplierGeneralPaidLogic.Instance.RemoveAsync(x);
                    }
                });
            }

            return entity;
        }
        public override Employee RemoveAsync(Employee entity)
        {
            var employee = base.RemoveAsync(entity);
            if (entity.SupplierGeneralPaids?.Any() ?? false)
            {
                entity.SupplierGeneralPaids.ForEach(x => SupplierGeneralPaidLogic.Instance.RemoveAsync(x));
            }
            return employee;
        }
        public override bool CanRemoveAsync(Employee entity)
        {
            if (!All().Any(x => x.Active && x.Id == entity.Id))
            {
                return false;
            }
            else if(_db.SaleDetails.Any(x=>x.EmployeeId == entity.Id))
            {
                return false;
            }
            return true;
        }
        public override List<Employee> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Employee> Search(ISearchModel model)
        {
            var param = model as EmployeeSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        public override bool CanRemoveAsync(int id)
        {
            return _db.EmployeeBills.Any(x=>x.Id == id && x.InvoiceStatus == InvoiceStatus.WaitPayment);
        }
        public List<Employee> GetEmployeesByIds(List<int>ids)
        {
            return _db.Employees.Where(x => x.Active && ids.Any(i => i == x.Id)).ToList();
        }
    }
}
