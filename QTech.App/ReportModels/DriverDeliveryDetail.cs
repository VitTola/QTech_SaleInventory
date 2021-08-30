using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class DriverDeliveryDetail
    {
        public string SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Company { get; set; }
        public string Site { get; set; }
        public decimal SubTotal { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal ImportPrice { get; set; }
        public int Qauntity { get; set; }
    }
}
