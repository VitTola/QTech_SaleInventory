using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class SupplierGeneralPaid : QTech.Base.ActiveBaseModel
    {
        public DateTime DoDate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        
    }
}
