using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
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
    public class InvoiceLogic : DbLogic<Invoice, InvoiceLogic>
    {
        public InvoiceLogic()
        {
        }
        public override Invoice FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Invoice entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override List<Invoice> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Invoice> Search(ISearchModel model)
        {
            var param = model as ProductSearch;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.InvoiceNo.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        public override Invoice AddAsync(Invoice entity)
        {
            entity.InvoiceNo = NewInvoiceNumber();
            var invoice = base.AddAsync(entity);
            var invoiceDetail = entity.InvoiceDetails;
            if (invoiceDetail.Any())
            {
                foreach (var s in invoiceDetail)
                {
                    s.InvoiceId = invoice.Id;
                    InvoiceDetailLogic.Instance.AddAsync(s);
                }

                //Update Sale Payment Status
                var saleIds = invoiceDetail.Select(x => x.SaleId).ToList();
                _db.Sales.Where(x => x.Active && saleIds.Any(y => y == x.Id)).ToList()
                    .ForEach(x =>
                    {
                        x.PayStatus = PayStatus.WaitPayment;
                    });
                _db.SaveChanges();
            }

            return invoice;
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.Invoices.Max(x => x.InvoiceNo);
                      
                if (lastInvoiceNo == null)
                {
                    invoiceNo = "SYSINV-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(7,6));
                    interval = interval + 1;
                    invoiceNo = string.Format("SYSINV-{0:000000}",interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public override Invoice UpdateAsync(Invoice entity)
        {
            var invoice = base.UpdateAsync(entity);
            var invoiceDetails = entity.InvoiceDetails;
            UpdateInvoiceDetail(invoiceDetails, invoice);
            return entity;
        }
        private void UpdateInvoiceDetail(List<InvoiceDetail> invoiceDetails, Invoice invoice)
        {
            if (invoiceDetails.Any())
            {
                foreach (var s in invoiceDetails)
                {
                    var isExist = InvoiceDetailLogic.Instance.IsExistsAsync(s);
                    if (isExist)
                    {
                        InvoiceDetailLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.InvoiceId = invoice.Id;
                        InvoiceDetailLogic.Instance.AddAsync(s);
                    }
                }
            }
        }

    }
}
