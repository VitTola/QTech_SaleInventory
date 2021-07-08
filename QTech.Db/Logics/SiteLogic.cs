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
    public class SiteLogic : DbLogic<Site, SiteLogic>
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
        public override bool CanRemoveAsync(int id)
        {
            if (_db.Sales.Any(x=>x.Active && x.SiteId == id))
            {
                return false;
            }
            return true;
        }
        public override List<Site> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public List<Site> SearchAsync(int cusId)
        {
            var q = All().Where(x=>x.Active);
            q = q.Where(x => x.CustomerId == cusId);
            var result = q.ToList();
            return result;
        }
        public override IQueryable<Site> Search(ISearchModel model)
        {
            var param = model as SiteSearch;
            var q = All().Where(x => x.Active);
            q = q.Where(x => x.CustomerId == param.CustomerId);
            return q;
        }
        public override bool IsExistsAsync(Site entity)
        {
            var result = _db.Sites.Any(x=>x.Id == entity.Id);
            return result;
        }
        public List<Site> GetSiteByIds(List<int> Ids)
        {
            var sites = _db.Sites
             .Where(site => site.Active && Ids.Any(id => id == site.Id));
            return sites.ToList();
        }
        public List<Site> GetSiteByCustomerIds(int id)
        {
            var sites = _db.Sites
             .Where(site => site.Active && site.CustomerId == id);
            return sites.ToList();
        }

    }
}
