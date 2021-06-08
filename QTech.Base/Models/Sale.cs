using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Sale: BaseModel
    {
        public DateTime SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Total { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }

    }
}
