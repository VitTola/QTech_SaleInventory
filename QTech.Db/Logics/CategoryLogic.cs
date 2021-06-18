using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class CategoryLogic : DbLogic<Category, CategoryLogic>
    {
        public override Category FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Category entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Category> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Category> Search(ISearchModel model)
        {
            var param = model as CategorySearch;
            var q = All();
            if (!string.IsNullOrEmpty(param?.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
    }
}
