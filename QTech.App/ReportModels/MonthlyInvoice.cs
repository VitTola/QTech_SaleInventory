using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class MonthlyInvoice
    {
        public string SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public string TotalInKh { get; set; }
        public string TotalInUSD { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Site { get; set; }
        public decimal UnitPrice { get; set; }
        public string Product { get; set; }
        public int Qauntity { get; set; }

    }
}
