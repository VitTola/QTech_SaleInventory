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
    public class CustomerPriceLogic : DbLogic<CustomerPrice, CustomerPriceLogic>
    {
        public CustomerPriceLogic()
        {

        }
        public override CustomerPrice AddAsync(CustomerPrice entity)
        {
            var result = base.AddAsync(entity);
            return result;
        }
        public override CustomerPrice FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(CustomerPrice entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override CustomerPrice UpdateAsync(CustomerPrice entity)
        {
            var Customer = base.UpdateAsync(entity);
            return entity;
        }
        public List<CustomerPrice> GetCustomerPriceByCustomerId(int customerId)
        {
            var result = _db.CustomerPrices.Where(x => x.Active && x.CustomerId == customerId).ToList();
            return result;
        }
        public override bool IsExistsAsync(CustomerPrice entity)
        {
            return _db.CustomerPrices.Any(x=>x.Id == entity.Id);
        }
    }
}
