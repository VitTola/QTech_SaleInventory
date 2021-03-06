using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class RepoInvoice
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Total { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Site { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
    }
}
