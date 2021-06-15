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
    public class CustomerLogic : DbLogic<Customer,CustomerLogic>
    {
        public CustomerLogic()
        {

        }

        public override Customer FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Customer entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Customer> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Customer> Search(ISearchModel model)
        {
            var param = model as CustomerSearch;
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
