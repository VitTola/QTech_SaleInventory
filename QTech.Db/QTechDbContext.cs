namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using QTech.Base;
    using QTech.Base.Models;
    using QTech.Db.Configs;

    public class QTechDbContext : DbContext
    {
        //public QTechDbContext()
        //    : base("QTechDbContext")
        //{
        //}
       
        public QTechDbContext()
            : base("data source="+DataBaseSetting.config.DataSource+";initial catalog="+DataBaseSetting.config.DataBase+";" +
                  "integrated security=True;MultipleActiveResultSets=True;" +"App=EntityFramework")
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerPrice> CustomerPrices { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<SupplierGeneralPaid> SupplierGeneralPaids { get; set; }
        public virtual DbSet<EmployeeBill> EmployeeBills { get; set; }
        public virtual DbSet<QTech.Base.Models.User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<POProductPrice> POProductPrices { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<IncomeExpense> IncomeExpenses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            QTechDbConfigs.ConfigureDatabase(modelBuilder);
        }

    }

    public static class DataBaseSetting
    {
        public static DbConfig config = new DbConfig() {
            DataSource = "Pheng Ry",
            DataBase = "QTech_SaleDb",
            
        };

        public static void ReadSetting()
        {
            try
            {
                var jsonData = File.ReadAllText("Setting.json");
                config = JsonConvert.DeserializeObject<DbConfig>(jsonData);
            }
            catch (Exception ex)
            {
                
            }
        }
        
        public static void WriteSetting()
        {
            var jsonData = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("Setting.json", jsonData);
        }
    }
}