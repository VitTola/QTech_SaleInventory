using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class RepoInvoiceDetail
    {
        public int SaleId { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public string UnitPrice { get; set; }
        public decimal Qauntity { get; set; }
        public string Total { get; set; }

    }
}
