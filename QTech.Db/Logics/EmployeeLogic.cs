using QTech.Base;
using QTech.Base.BaseModels;
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
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
    }
}
