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
            var invoice = base.AddAsync(entity);
            var invoiceDetail = entity.InvoiceDetails;
            if (invoiceDetail != null && invoiceDetail.Any())
            {
                foreach (var s in invoiceDetail)
                {
                    InvoiceDetailLogic.Instance.AddAsync(s);
                }
            }
            return invoice;
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
