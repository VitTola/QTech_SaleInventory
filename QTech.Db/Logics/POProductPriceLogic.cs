using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class POProductPriceLogic : DbLogic<POProductPrice,POProductPriceLogic>
    {
        public List<POProductPrice> GetPOProductPriceByPO(int PoId)
        {
            var result = All().Where(x => x.PurchaseOrderId == PoId);
            return result.ToList();
        }
        public override POProductPrice AddAsync(POProductPrice entity)
        {
            return base.AddAsync(entity);
        }
        public override POProductPrice UpdateAsync(POProductPrice entity)
        {
            return base.UpdateAsync(entity);
        }

    }
}
