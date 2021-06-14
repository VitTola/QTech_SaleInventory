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
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Employee> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Employee> Search(ISearchModel model)
        {
            var param = model as EmployeeSearch;
            var par = param.Search;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
    }
}
