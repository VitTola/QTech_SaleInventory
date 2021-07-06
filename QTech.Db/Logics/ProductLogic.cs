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
    public class ProductLogic:DbLogic<Product,ProductLogic>
    {
        public ProductLogic()
        {
        }
        public override Product FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Product entity)
        {
            if (!All().Any(x =>x.Active && x.Id == entity.Id))
            {
                return false;
            }
            else if (_db.SaleDetails.Any(x=>x.Active && x.ProductId ==entity.Id))
            {
                return false;
            }
            return true;
        }
        public override List<Product> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Product> Search(ISearchModel model)
        {
            var param = model as ProductSearch;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
    }
}
