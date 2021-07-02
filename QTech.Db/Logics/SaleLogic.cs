using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
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
                x.SaleId = result.Id;
                SaleDetailLogic.Instance.AddAsync(x);
            });
            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            var result = base.UpdateAsync(entity);
            UpdateSaleDetail(result.SaleDetails, result);
            return result;
        }
        private void UpdateSaleDetail(List<SaleDetail> saleDetails, Sale sale)
        {
            if (saleDetails.Any())
            {
                foreach (var s in saleDetails)
                {
                    var isExist = SaleDetailLogic.Instance.IsExistsAsync(s);
                    if (isExist)
                    {
                        SaleDetailLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.SaleId = sale.Id;
                        SaleDetailLogic.Instance.AddAsync(s);
                    }
                }
            }
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
            var _saleSearchKey = param.saleSearchKey;
            var q = All().Where(x=>x.Active);
            if (_saleSearchKey == SaleSearchKey.PurchaseOrderNo && !string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.PurchaseOrderNo == param.Search);
            }
            if (_saleSearchKey == SaleSearchKey.InvoiceNo && !string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.InvoiceNo == param.Search);
            }
            if (_saleSearchKey == SaleSearchKey.CompanyName && !string.IsNullOrEmpty(param.Search))
            {
                var cusIds = _db.Customers.Where(c => c.Name.ToLower().Contains(param.Search.ToLower())).Select(y => y.Id).ToList();
                q = q.Where(x => cusIds.Any(y=>x.CompanyId == y));
            }
            if (_saleSearchKey == SaleSearchKey.SiteName && !string.IsNullOrEmpty(param.Search))
            {
                var siteIds = _db.Sites.Where(c => c.Name.ToLower().Contains(param.Search.ToLower())).Select(y => y.Id).ToList();
                q = q.Where(x => siteIds.Any(y => x.CompanyId == y));
            }
            if (param.payStatus == PayStatus.Paid)
            {
                q = q.Where(x => x.IsPaid);
            }
            else if(param.payStatus == PayStatus.NotYetPaid)
            {
                q = q.Where(x => !x.IsPaid);
            }
            return q;
        }
        public List<Sale> GetSaleByCustomerId(ISearchModel model)
        {
            var param = model as SaleSearch;

            if (param.FromDate != null && param.ToDate !=null )
            {
                var result = _db.Sales.Where(x => x.CompanyId == param.CustomerId &&
                x.SaleDate>= param.FromDate && x.SaleDate <= param.ToDate && !x.IsPaid).ToList();
                return result;
            }
            return null;
        }
        public List<Sale> GetSaleByIds(List<int> saleIds)
        {
            var q = All().Where(x => x.Active);
            q = q.Where(s=> saleIds.Any(i=> i == s.Id));
            return q.ToList();
        }

    }
}
