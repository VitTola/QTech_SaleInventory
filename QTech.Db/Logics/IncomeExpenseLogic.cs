using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class IncomeExpenseLogic : DbLogic<IncomeExpense, IncomeExpenseLogic>
    {
        public override IQueryable<IncomeExpense> Search(ISearchModel model)
        {
            var param = model as IncomExpenseSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Note.ToLower().Contains(param.Search.ToLower()));
            }
            if (param.MiscellaneousType == MiscellaneousType.Expense )
            {
                q = q.Where(x => x.MiscellaneousType == MiscellaneousType.Expense);
            }
            if (param.MiscellaneousType == MiscellaneousType.Income)
            {
                q = q.Where(x => x.MiscellaneousType == MiscellaneousType.Income);
            }
            return q;
        }
        public override List<IncomeExpense> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override bool CanRemoveAsync(IncomeExpense entity)
        {
            return All().Any(x => x.Active && x.Id == entity.Id);
        }
        public override IncomeExpense AddAsync(IncomeExpense entity)
        {
            entity.MiscNo = NewInvoiceNumber();
            var result = base.AddAsync(entity);
            return result;
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.IncomeExpenses.Max(x => x.MiscNo);

                if (lastInvoiceNo == null)
                {
                    invoiceNo = "MISC-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(5, 6));
                    interval = interval + 1;
                    invoiceNo = string.Format("MISC-{0:000000}", interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
