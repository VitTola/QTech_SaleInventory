using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Product : ActiveBaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
    }
}
