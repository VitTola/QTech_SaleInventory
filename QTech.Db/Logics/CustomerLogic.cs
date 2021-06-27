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
    public class CustomerLogic : DbLogic<Customer, CustomerLogic>
    {
        public CustomerLogic()
        {

        }
        public override Customer AddAsync(Customer entity)
        {
            var Customer = base.AddAsync(entity);
            var sites = entity.Sites;
            if (sites != null && sites.Any())
            {
                foreach (var s in sites)
                {
                    SiteLogic.Instance.AddAsync(s);
                }
            }
            return entity;
        }
        public override Customer FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Customer entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Customer> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            if (result.Any())
            {
                foreach (var cus in result)
                {
                    var sites = SiteLogic.Instance.SearchAsync(cus.Id);
                    if (sites.Any())
                    {
                        cus.Sites = sites;
                    }
                }
            }
            return result;
        }
        public override IQueryable<Customer> Search(ISearchModel model)
        {
            var param = model as CustomerSearch;
            var par = param.Search;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }

            return q;
        }
        public override Customer UpdateAsync(Customer entity)
        {
            var Customer = base.UpdateAsync(entity);
            var sites = entity.Sites;
            UpdateSite(sites, Customer);
            AddOrUpdateCustomerPrice(entity.CustomerPrices);
            return entity;
        }
        private void UpdateSite(List<Site> sites,Customer customer)
        {
            if (sites.Any())
            {
                foreach (var s in sites)
                {
                    var isExist = SiteLogic.Instance.IsExistsAsync(s);
                    if (isExist)
                    {
                        SiteLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.CustomerId = customer.Id;
                        SiteLogic.Instance.AddAsync(s);
                    }
                }
            }
        }
        private void AddOrUpdateCustomerPrice(List<CustomerPrice> customerPrices)
        {
            if (!customerPrices.Any())
            {
                return;
            }
            customerPrices.ForEach(x =>
            {
                bool isExist = CustomerPriceLogic.Instance.IsExistsAsync(x);
                if (isExist)
                {
                    CustomerPriceLogic.Instance.AddAsync(x);
                }
                else
                {
                    CustomerPriceLogic.Instance.AddAsync(x);
                }
            });
        }
        public List<Customer> GetCustomersById(List<int> Ids)
        {
            var customers = _db.Customers.Where(cus => cus.Active && Ids.Any(id => id == cus.Id));
            return customers.ToList();
        }
}
}
