using EasyServer.Domain.Models;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Invoice: QTech.Base.ActiveBaseModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoicingDate { get; set; }
        public int CustomerId { get; set; }
        public int SiteId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal LeftAmount { get; set; }
        public List<InvoiceDetail> InvoiceDetails{ get; set; }
    }

    public class InvoiceDetail : ActiveBaseModel
    {
        public int InvoiceId { get; set; }
        public int SaleId { get; set; }
    }
}
