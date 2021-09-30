using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using QTech.Component;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SaleLogic : DbLogic<Sale, SaleLogic>
    {
        List<string>ignoreProperties=null;
        public SaleLogic()
        {
            Sale sale = new Sale();
            ignoreProperties = new List<string>() {
                nameof(sale.Active),nameof(sale.CreatedBy), nameof(sale.PayStatus),
                nameof(sale.SaleType),nameof(sale.Profit),nameof(sale.IsInvoiced),nameof(sale.TotalImportPrice)
               ,nameof(sale.Id),nameof(sale.RowDate)

            };
        }

        private Sale oldEntity = null;
       
        public override Sale AddAsync(Sale entity)
        {
            var result = base.AddAsync(entity);
            if (entity.SaleDetails.Any() && result.PurchaseOrderId != 0)
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

            AuditTrailLogic.Instance.AddManualAuditTrail(result, GetChangeLogs(result,null,GeneralProcess.Add), GeneralProcess.Add);

            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            oldEntity = FindAsync(entity.Id);
            var result = base.UpdateAsync(entity);
            if (entity.SaleDetails?.Any() ?? false && result.PurchaseOrderId != 0)
            {
                UpdatePOProductPriceQty(result.PurchaseOrderId, entity.SaleDetails, GeneralProcess.Update);
            }
            UpdateSaleDetail(result.SaleDetails, result);

            AuditTrailLogic.Instance.AddManualAuditTrail(entity, GetChangeLogs(result,oldEntity,GeneralProcess.Update), GeneralProcess.Update);

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
            else if (_db.InvoiceDetails.Any(x => x.Active && x.SaleId == entity.Id))
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
            var q = All().Where(x => x.Active);
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
                q = q.Where(x => cusIds.Any(y => x.CompanyId == y));
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
                q = q.GetPaged(param.Paging).Results.OrderBy(x => x.Id);
            }
            return q;
        }
        public List<Sale> GetSaleByCustomerId(ISearchModel model)
        {
            var param = model as SaleSearch;

            if (param.FromDate != null && param.ToDate != null)
            {
                var result = _db.Sales.Where(x => x.Active && x.CompanyId == param.CustomerId &&
                x.SaleDate >= param.FromDate && x.SaleDate <= param.ToDate && x.PayStatus == PayStatus.NotYetPaid).ToList();
                return result;
            }
            return null;
        }
        public List<Sale> GetSaleByIds(List<int> saleIds)
        {
            var q = All().Where(x => x.Active);
            q = q.Where(s => saleIds.Any(i => i == s.Id));
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
            Model.InvoicingDate = sale.SaleDate;
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
                pOProductPrices.ForEach(x =>
                {
                    var saleDetail = saleDetails?.FirstOrDefault(r => r.ProductId == x.ProductId);
                    if (saleDetail == null) return;
                    if (flag == GeneralProcess.Add)
                    {
                        x.LeftQauntity = x.LeftQauntity - saleDetail.Qauntity;
                    }
                    else if (flag == GeneralProcess.Update)
                    {
                        int currentSaleDetail = (int)currentSaleDetails?.FirstOrDefault(r => r.ProductId == x.ProductId)?.Qauntity;
                        int newSaleDetail = (int)saleDetails?.FirstOrDefault(r => r.ProductId == x.ProductId)?.Qauntity;
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
            var isReachLimitQty = !finalPOProductPrices.Any(x => x.LeftQauntity > 0);
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
        private List<ChangeLog> GetChangeLogs(Sale newEntity,Sale oldEntity, GeneralProcess flag)
        {
            int index = 1;
            var changeLogs = new List<ChangeLog>();
            var saleDetails = new List<ChangeLog>();
            var ignoreProperties = new List<string>() {
               nameof(newEntity.Active),nameof(newEntity.CreatedBy), nameof(newEntity.PayStatus),
                nameof(newEntity.SaleType),nameof(newEntity.Profit),nameof(newEntity.IsInvoiced),nameof(newEntity.TotalImportPrice)
               ,nameof(newEntity.Id),nameof(newEntity.RowDate)
            };

            PropertyInfo[] properties = typeof(Sale).GetProperties().Where(x => !ignoreProperties.Contains(x.Name)).ToArray();
            PropertyInfo[] _properties = typeof(SaleDetail).GetProperties().Where(x => !ignoreProperties.Contains(x.Name)).ToArray();

            if (flag == GeneralProcess.Update)
            {
                properties = properties.Where(o => o.GetValue(oldEntity, null)?.ToString() != o.GetValue(newEntity, null)?.ToString()).ToArray();
            }
            foreach (PropertyInfo property in properties.Where(x => !ignoreProperties.Contains(nameof(newEntity.SaleDetails))).ToArray())
            {
                changeLogs.Add(
                new ChangeLog
                {
                    Index = index++,
                    DisplayName = ResourceHelper.Translate(property.Name),
                    OldValue = flag == GeneralProcess.Add ? string.Empty : property.GetValue(oldEntity, null),
                    NewValue = property.GetValue(newEntity, null),
                }
                               );
            }
            foreach (var saleDetail in newEntity.SaleDetails)
            {
                foreach (PropertyInfo _property in _properties)
                {
                    int _index = 1;
                    saleDetails.Add(
                    new ChangeLog
                    {
                        Index = _index++,
                        DisplayName = ResourceHelper.Translate(_property.Name),
                        OldValue = flag == GeneralProcess.Add ? string.Empty : _property.GetValue(oldEntity.SaleDetails[oldEntity.SaleDetails.IndexOf(saleDetail)], null) ?? string.Empty,
                        NewValue = _property.GetValue(saleDetail, null),
                    }
                   );
                }
            }
            if (saleDetails?.Any() ?? false)
            {
                changeLogs.Add(
                          new ChangeLog
                          {
                              Index = index++,
                              DisplayName = Base.Properties.Resources.SaleDetail_op,
                              OldValue = string.Empty,
                              NewValue = string.Empty,
                              Details = saleDetails
                          }
                              );
            }

            return changeLogs;
        }
    }
}
