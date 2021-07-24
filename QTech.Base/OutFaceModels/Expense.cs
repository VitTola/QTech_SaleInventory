using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.OutFaceModels
{
    public class Expense
    {
        public int BillId { get; set; }
        public string BillNo { get; set; }
        public string PayTo { get; set; }
        public DateTime DoDate { get; set; }
        public decimal Amount { get; set; }
    }
}
