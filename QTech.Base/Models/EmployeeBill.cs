using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class EmployeeBill : QTech.Base.ActiveBaseModel
    {
        public string BillNo { get; set; }
        public DateTime DoDate{ get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int SiteId { get; set; }
        public int EmployeeId { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal LeftAmount { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public List<SaleDetail> SaleDetails{ get; set; }
    }
}
