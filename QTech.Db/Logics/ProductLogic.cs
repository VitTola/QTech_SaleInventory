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
    class ProductLogic:DbLogic<Product,ProductLogic>
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
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Product> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        //public List<Product> SearchAsync(int id)
        //{
        //    var q = All();
        //    q = q.Where(x => x.CustomerId == id);
        //    var result = q.ToList();
        //    return result;
        //}
        public override IQueryable<Product> Search(ISearchModel model)
        {
            var param = model as ProductSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        //public override bool IsExistsAsync(Site entity)
        //{
        //    var result = _db.Sites.Any(x => x.Id == entity.Id);
        //    return result;
        //}
    }
}
