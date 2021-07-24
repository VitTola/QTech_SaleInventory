using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.OutFaceModels
{
   public class IncomeExpenseOutface
    {
        public string MiscNo { get; set; }
        public DateTime DoDate { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public string MiscType { get; set; }
    }
}
