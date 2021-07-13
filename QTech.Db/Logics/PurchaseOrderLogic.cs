using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class PurchaseOrderLogic : DbLogic<PurchaseOrder,PurchaseOrderLogic>
    {
        public override PurchaseOrder AddAsync(PurchaseOrder entity)
        {
            var purchaseOrder = base.AddAsync(entity);
            if (purchaseOrder.POProductPrices.Any())
            {
                purchaseOrder.POProductPrices.ForEach(x => {
                    x.PurchaseOrderId = purchaseOrder.Id;
                    //x.LeftQauntity = x.StartQauntity;
                    POProductPriceLogic.Instance.AddAsync(x);
                });
            }
            return purchaseOrder;
        }
        public override PurchaseOrder UpdateAsync(PurchaseOrder entity)
        {
            var purchaseOrder = base.UpdateAsync(entity);

            if (purchaseOrder.POProductPrices.Any())
            {
                purchaseOrder.POProductPrices.ForEach(x => {
                    if (x.Id == 0)
                    {
                        x.PurchaseOrderId = purchaseOrder.Id;
                        //x.LeftQauntity = x.StartQauntity;
                        POProductPriceLogic.Instance.AddAsync(x);
                    }
                    else
                    {
                        POProductPriceLogic.Instance.UpdateAsync(x);
                    }
                });
            }

            return purchaseOrder;
        }
        public override IQueryable<PurchaseOrder> Search(ISearchModel model)
        {
            var  q = All();
            var param = model as PurchaseOrderSearch;
            if (param?.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging).Results.OrderBy(x => x.Id);
            }
            return q;
        }
        public override List<PurchaseOrder> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override PurchaseOrder FindAsync(int id)
        {
            return _db.PurchaseOrders.FirstOrDefault(x=>x.Id == id);
        }
    }
}
