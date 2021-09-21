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
        public PayStatus PayStatus { get; set; }
        public  decimal Expense { get; set; }
        public int PurchaseOrderId { get; set; }
        public SaleType SaleType { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public decimal Profit { get; set; }
        public bool IsInvoiced { get; set; } = false;
        public decimal TotalImportPrice { get; set; }
        public ImportPrice ImportPrice { get; set; }

    }

    public class SaleDetail : ActiveBaseModel
    {
        public int EmployeeId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public decimal Qauntity { get; set; }
        public decimal Total{ get; set; }
        public PayStatus PayStatus { get; set; }
        public int EmployeeBillId { get; set; }
        public decimal Expense { get; set; }
        public decimal ImportTotalAmount { get; set; }
        public decimal Profit { get; set; }
        public bool IsBilled { get; set; } = false;
        public decimal ImportPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}






