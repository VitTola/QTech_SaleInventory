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
    public class InvoiceDetailLogic : DbLogic<InvoiceDetail, InvoiceDetailLogic>
    {
        public InvoiceDetailLogic()
        {
        }
        public override InvoiceDetail AddAsync(InvoiceDetail entity)
        {
            return base.AddAsync(entity);
        }
        public override InvoiceDetail UpdateAsync(InvoiceDetail entity)
        {
            return base.UpdateAsync(entity);
        }
        public override InvoiceDetail FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(InvoiceDetail entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override bool IsExistsAsync(InvoiceDetail entity)
        {
            var result = _db.InvoiceDetails.Any(x => x.Id == entity.Id);
            return result;
        }
  
        public override List<InvoiceDetail> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<InvoiceDetail> Search(ISearchModel model)
        {
            var param = model as SaleDetailSearch;
            var q = All().Where(x => x.Active);
            if (param.SaleId != 0)
            {
                q = q.Where(x => x.SaleId == param.SaleId);
            }
            return q;
        }
        public List<InvoiceDetail> GetInvoiceDetailByInvoiceId(int invoiceId)
        {
            var q = All().Where(x => x.Active);
            q = q.Where(x => x.InvoiceId == invoiceId);
            return q.ToList();
        }

    }
}
