using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class PurchaseOrder : QTech.Base.ActiveBaseModel
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
        public bool IsReachQty { get; set; }
        public List<POProductPrice>POProductPrices { get; set; }

    }

    public class POProductPrice : ActiveBaseModel
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal StartQauntity { get; set; }
        public decimal LeftQauntity { get; set; }
        public decimal SalePrice { get; set; }
        public string Note { get; set; }
    }
}

