using EasyServer.Domain.Models;
using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Sale: ActiveBaseModel
    {
        public DateTime SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Total { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public List<SaleDetail> SaleDetails{ get; set; }
        public decimal PaymentRecieve { get; set; }
        public decimal PaymentLeft { get; set; }
       // public bool IsPaid { get; set; } = false;
        public PayStatus PayStatus { get; set; }
    }

    public class SaleDetail : ActiveBaseModel
    {
        public int EmployeeId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Qauntity { get; set; }
        public decimal Total{ get; set; }
    }
}
