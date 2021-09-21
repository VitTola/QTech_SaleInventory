using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.OutFaceModels
{
    public class DriverDeliveryDetail
    {
        public int saleDetailId { get; set; }
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Company { get; set; }
        public string Site { get; set; }
        public decimal SubTotal { get; set; }
        public string Product { get; set; }
        public decimal Qauntity { get; set; }
    }
}
