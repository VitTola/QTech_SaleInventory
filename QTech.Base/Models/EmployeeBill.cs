using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class EmployeeBill : QTech.Base.ActiveBaseModel
    {
        public DateTime DoDate{ get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int SiteId { get; set; }
        public int EmployeeId { get; set; }
        public List<int> SaleDetailIds{ get; set; }
    }
}
