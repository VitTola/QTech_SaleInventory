using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class InvoiceDetail
    {
        public int SaleId { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public int Qauntity { get; set; }
        public decimal Total { get; set; }

    }
}
