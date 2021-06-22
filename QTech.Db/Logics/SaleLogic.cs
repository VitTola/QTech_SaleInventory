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
    public class SaleLogic : DbLogic<Sale,SaleLogic>
    {
        public SaleLogic()
        {
        }

        public override Sale AddAsync(Sale entity)
        {
           var result =  base.AddAsync(entity);
            entity.SaleDetails.ForEach(x =>
            {
                SaleDetailLogic.Instance.AddAsync(x);
            });
            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            var result = base.UpdateAsync(entity);
            entity.SaleDetails.ForEach(x =>
            {
                SaleDetailLogic.Instance.UpdateAsync(x);
            });
            return result;
        }
        public override Sale FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Sale entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Sale> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Sale> Search(ISearchModel model)
        {
            var param = model as SaleSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.PurchaseOrderNo))
            {
                q = q.Where(x => x.PurchaseOrderNo == param.PurchaseOrderNo);
            }
            if (!string.IsNullOrEmpty(param.InvoiceNo))
            {
                q = q.Where(x => x.InvoiceNo == param.InvoiceNo);
            }
            if (!string.IsNullOrEmpty(param.customerName))
            {
                var cusIds = _db.Customers.Where(c => c.Name.ToLower().Contains(param.customerName.ToLower())).Select(y => y.Id).ToList();
                q = q.Where(x => cusIds.Any(y=>x.CompanyId == y));
            }
            if (!string.IsNullOrEmpty(param.SiteName))
            {
                var siteIds = _db.Sites.Where(c => c.Name.ToLower().Contains(param.customerName.ToLower())).Select(y => y.Id).ToList();
                q = q.Where(x => siteIds.Any(y => x.CompanyId == y));
            }
            return q;
        }

    }
}
