using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.OutFaceModels
{
    public class EmployeeBillOutFace
    {
        public string PurchaseOrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public string ToCompany { get; set; }
        public string ToSite { get; set; }
        public DateTime SaleDate { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal Qauntity { get; set; }
        public decimal ImportTotalAmount { get; set; }
        public decimal EmployeeOweAmount { get; set; }

        //Query in use
        public SaleDetail saleDetail{ get; set; }
    }
}
