using QTech.Base;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Configs
{
    public static class QTechDbConfigs
    {
        public static void ConfigureDatabase(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Ignore(x => x.Sites);
            modelBuilder.Entity<Sale>().Ignore(x => x.SaleDetails);
            modelBuilder.Entity<Customer>().Ignore(x => x.CustomerPrices);
            modelBuilder.Entity<Invoice>().Ignore(x => x.InvoiceDetails);
            modelBuilder.Entity<Employee>().Ignore(x => x.SupplierGeneralPaids);
            modelBuilder.Entity<EmployeeBill>().Ignore(x => x.SaleDetailIds);
            modelBuilder.Entity<QTech.Base.Models.User>().Ignore(x => x.UserPermissions);
            modelBuilder.Entity<QTech.Base.Models.PurchaseOrder>().Ignore(x => x.POProductPrices);

        }
    }
}
