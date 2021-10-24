using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.OutFaceModels
{
    public class Income
    {
        public int SaleId { get; set; }
        public string InvoiceNo { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Customer { get; set; }
        public string Site { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
        public decimal Expense { get; set; }
        public decimal LeftAmount { get; set; }
        public string Status { get; set; }
    }
}
