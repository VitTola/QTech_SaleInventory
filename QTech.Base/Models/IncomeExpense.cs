using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class IncomeExpense : QTech.Base.ActiveBaseModel
    {
        public string MiscNo { get; set; }
        public DateTime DoDate { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public MiscellaneousType MiscellaneousType { get; set; }
    }
}
