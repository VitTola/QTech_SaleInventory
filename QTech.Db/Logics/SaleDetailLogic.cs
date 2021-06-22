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
    public class SaleDetailLogic:DbLogic<SaleDetail, SaleDetailLogic>
    {
        public SaleDetailLogic()
        {
        }
        public override SaleDetail AddAsync(SaleDetail entity)
        {
            return base.AddAsync(entity);
        }
        public override SaleDetail UpdateAsync(SaleDetail entity)
        {
            return base.UpdateAsync(entity);
        }
        public override SaleDetail FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(SaleDetail entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        //public override List<SaleDetail> SearchAsync(ISearchModel model)
        //{
        //    var result = Search(model).ToList();
        //    return result;
        //}

        //public override IQueryable<SaleDetail> Search(ISearchModel model)
        //{
        //    var param = model as ProductSearch;
        //    var q = All();
        //    if (!string.IsNullOrEmpty(param.Search))
        //    {
        //        q = q.Where(x => x.Id.ToLower().Contains(param.Search.ToLower()));
        //    }
        //    return q;
        //}

        public List<SaleDetail> GetSaleDetailBySaleId(int s)
        {
            var result = _db.SaleDetails.Where(x => x.SaleId == s).ToList();
            return result;
        }
    }
}
