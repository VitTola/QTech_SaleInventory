using EasyServer.Domain.Models;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Customer: QTech.Base.ActiveBaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public List<Site> Sites{ get; set; }
        public List<CustomerPrice> CustomerPrices { get; set; }
    }

    public class Site : ActiveBaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
    }
}
