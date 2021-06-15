using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    class SiteLogic : DbLogic<Site, SiteLogic>
    {
        public SiteLogic()
        {

        }

        public override Site FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Site entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Site> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public List<Site> SearchAsync(int id)
        {
            var q = All();
            q = q.Where(x => x.CustomerId == id);
            return q.ToList();
        }
        public override IQueryable<Site> Search(ISearchModel model)
        {
            var param = model as SiteSearch;
            var par = param.Search;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.CustomerId == param.CustomerId);
            }
            return q;
        }
    }
}
