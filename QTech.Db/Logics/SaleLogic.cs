using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (entity.SaleDetails.Any() && result.PurchaseOrderId !=0)
            {
                UpdatePOProductPriceQty(result.PurchaseOrderId, entity.SaleDetails, GeneralProcess.Add);
            }
            entity.SaleDetails.ForEach(x =>
            {
                x.SaleId = result.Id;
                SaleDetailLogic.Instance.AddAsync(x);
            });
            if (entity.SaleType == SaleType.General)
            {
                AddInvoice(result, GeneralProcess.Add);
            }
            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            var result = base.UpdateAsync(entity);
            if (entity.SaleDetails?.Any() ?? false && result.PurchaseOrderId != 0)
            {
                UpdatePOProductPriceQty(result.PurchaseOrderId, entity.SaleDetails, GeneralProcess.Update);
            }
            UpdateSaleDetail(result.SaleDetails, result);
            return result;
        }
        private void UpdateSaleDetail(List<SaleDetail> saleDetails, Sale sale)
        {
            if (saleDetails?.Any() ?? false)
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
            if (!All().Any(x => x.Active && x.Id == entity.Id))
            {
                return false;
            }
            else if (_db.InvoiceDetails.Any(x=>x.Active && x.SaleId ==entity.Id))
            {
                return false;
            }
            return true;
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
                q = q.Where(x => siteIds.Any(y => x.SiteId == y));
            }
            if (param.payStatus == PayStatus.Paid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.Paid);
            }
            else if (param.payStatus == PayStatus.NotYetPaid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.NotYetPaid);
            }
            else if (param.payStatus == PayStatus.WaitPayment)
            {
                q = q.Where(x => x.PayStatus == PayStatus.WaitPayment);
            }
            if (param.ImportPrice == ImportPrice.Inserted)
            {
                q = q.Where(x => x.ImportPrice == ImportPrice.Inserted);
            }
            else if (param.ImportPrice == ImportPrice.NotInserted)
            {
                q = q.Where(x => x.ImportPrice == ImportPrice.NotInserted);
            }
            if (param?.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging).Results.OrderBy(x=>x.Id);
            }
            return q;
        }
        public List<Sale> GetSaleByCustomerId(ISearchModel model)
        {
            var param = model as SaleSearch;

            if (param.FromDate != null && param.ToDate !=null )
            {
                var result = _db.Sales.Where(x =>x.Active && x.CompanyId == param.CustomerId &&
                x.SaleDate>= param.FromDate && x.SaleDate <= param.ToDate && x.PayStatus == PayStatus.NotYetPaid).ToList();
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
        public override Sale RemoveAsync(Sale entity)
        {
            var result = base.RemoveAsync(entity);
            if (entity.SaleDetails.Any() && result.PurchaseOrderId != 0)
            {
                UpdatePOProductPriceQty(result.PurchaseOrderId, entity.SaleDetails, GeneralProcess.Remove);
            }
            return result;
        }
        private void AddInvoice(Sale sale, GeneralProcess flag)
        {
            var Model = new Invoice();
            if (Model.InvoiceDetails == null)
            {
                Model.InvoiceDetails = new List<InvoiceDetail>();
            }
            Model.CustomerId = sale.CompanyId;
            Model.InvoicingDate = sale.SaleDate ;
            Model.TotalAmount = sale.Total;
            Model.PaidAmount = 0;
            Model.LeftAmount = sale.Total;
            Model.InvoiceStatus = InvoiceStatus.WaitPayment;
            Model.SaleType = SaleType.General;
            Model.CustomerName = sale.CustomerName;
            
            Model.InvoiceDetails.Add(
                new InvoiceDetail()
                {
                    SaleId = sale.Id,

                });
            InvoiceLogic.Instance.AddAsync(Model);
        }
        public override bool CanRemoveAsync(int id)
        {
            var entity = base.FindAsync(id);
            if (entity.PayStatus != PayStatus.NotYetPaid)
            {
                return false;
            }
            return true;
        }

        //UPDATE QAUNTITY IN POProductPrice
        private void UpdatePOProductPriceQty(int POId, List<SaleDetail> saleDetails, GeneralProcess flag)
        {
            if (saleDetails == null)
            {
                return;
            }
            var pOProductPrices = POProductPriceLogic.Instance.GetPOProductPriceByPO(POId);
            List<SaleDetail> currentSaleDetails = null;
            if (flag == GeneralProcess.Update)
            {
                var saleId = saleDetails.FirstOrDefault().SaleId;
                currentSaleDetails = SaleDetailLogic.Instance.GetSaleDetailBySaleId(saleId);
            }
            if (pOProductPrices.Any())
            {
                pOProductPrices.ForEach(x=> {
                    var saleDetail = saleDetails?.FirstOrDefault(r=>r.ProductId == x.ProductId);
                    if (saleDetail == null) return;
                    if (flag == GeneralProcess.Add)
                    {
                        x.LeftQauntity = x.LeftQauntity - saleDetail.Qauntity;
                    }
                    else if(flag == GeneralProcess.Update)
                    {
                        int currentSaleDetail = (int)currentSaleDetails?.FirstOrDefault(r=>r.ProductId == x.ProductId)?.Qauntity;
                        int newSaleDetail =(int) saleDetails?.FirstOrDefault(r=>r.ProductId == x.ProductId)?.Qauntity;
                        if (currentSaleDetail > newSaleDetail)
                        {
                            x.LeftQauntity = x.LeftQauntity + (currentSaleDetail - newSaleDetail);
                        }
                        else
                        {
                            x.LeftQauntity = x.LeftQauntity - (newSaleDetail - currentSaleDetail);
                        }
                    }
                    else
                    {
                        x.LeftQauntity = x.LeftQauntity + saleDetail.Qauntity;
                    }
                    
                    POProductPriceLogic.Instance.UpdateAsync(x);
                });
            }

            //After doing all stuff check wether PurchaseOrder is ReachLimitQty
            var finalPOProductPrices = POProductPriceLogic.Instance.GetPOProductPriceByPO(POId);
            var isReachLimitQty = !finalPOProductPrices.Any(x=>x.LeftQauntity > 0);
            if (isReachLimitQty)
            {
                var po = PurchaseOrderLogic.Instance.FindAsync(POId);
                if (po != null)
                {
                    po.IsReachQty = true;
                    PurchaseOrderLogic.Instance.UpdateAsync(po);
                }
            }
        }

        public bool IsExistedInvoiceNo(Sale sale)
        {
            return _db.Sales.Any(x => x.Active && x.InvoiceNo == sale.InvoiceNo && x.Id != sale.Id);
        }
    }
}
