using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class CustomerPrice : QTech.Base.ActiveBaseModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal SalePrice { get; set; }
    }
}
