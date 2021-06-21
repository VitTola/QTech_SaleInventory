using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Base.Helpers
{
    public static class Constants
    {
        public static Dictionary<SaleSearchKey, Keys> KeyShortcut => new Lazy<Dictionary<SaleSearchKey, Keys>>(() =>
           new Dictionary<SaleSearchKey, Keys>()
           {
                {SaleSearchKey.PurchaseOrderNo, Keys.F2 },
                {SaleSearchKey.InvoiceNo, Keys.F3 },
                {SaleSearchKey.CompanyName, Keys.F4 },
                {SaleSearchKey.SiteName, Keys.F5 },
           }).Value;



    }
}
