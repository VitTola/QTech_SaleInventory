using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class SaleSearch : QTechSearch.BasicSearchModel
    {
        public string PurchaseOrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public string customerName { get; set; }
        public string SiteName { get; set; }
    }
}
