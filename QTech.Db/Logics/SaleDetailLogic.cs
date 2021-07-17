using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
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
        public override bool IsExistsAsync(SaleDetail entity)
        {
            var result = _db.SaleDetails.Any(x => x.Id == entity.Id);
            return result;
        }
        public List<SaleDetail> GetSaleDetailBySaleId(int s)
        {
            var result = _db.SaleDetails.Where(x => x.SaleId == s && x.Active).ToList();
            return result;
        }
        public override List<SaleDetail> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<SaleDetail> Search(ISearchModel model)
        {
            var param = model as SaleDetailSearch;
            var q = All().Where(x => x.Active);
            if (param.SaleId != 0)
            {
                q = q.Where(x => x.SaleId == param.SaleId);
            }
            return q;
        }

        public List<EmployeeBillOutFace> GetEmployeeBillOutFaces(ISearchModel model)
        {
            var param = model as EmployeeBillSearch;
            var q = All();
            var result = from saleDetail in q
                         join employee in _db.Employees on saleDetail.EmployeeId equals employee.Id
                         join sale in _db.Sales on saleDetail.SaleId equals sale.Id
                         join customer in _db.Customers on sale.CompanyId equals customer.Id
                         join site in _db.Sites on sale.SiteId equals site.Id
                         join product in _db.Products on saleDetail.ProductId equals product.Id
                         join category in _db.Categories on product.CategoryId equals category.Id
                         where sale.SaleDate >= param.D1 && sale.SaleDate <= param.D2
                         && (param.DriverId == 0 ? true : employee.Id == param.DriverId) 
                         && (param.CustomerId == 0 ? true : customer.Id == param.CustomerId) 
                         && (param.SiteId == 0 ? true : site.Id == param.SiteId)
                         select new EmployeeBillOutFace()
                         {
                             PurchaseOrderNo = sale.PurchaseOrderNo,
                             InvoiceNo = sale.InvoiceNo,
                             ToCompany = customer.Name,
                             ToSite = site.Name,
                             SaleDate = sale.SaleDate,
                             Product = product.Name,
                             Category = category.Name,
                             ImportPrice = product.ImportPrice,
                             Qauntity = saleDetail.Qauntity,
                             ImportTotalAmount = saleDetail.ImportTotalAmount,
                             
                             SaleDetailId = saleDetail.Id
                         };

            var res =result.GroupBy(x => x.SaleDetailId).Select(y => y.FirstOrDefault()).ToList();
            return res;
        }
    }
}
