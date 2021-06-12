namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using QTech.Base;
    using QTech.Base.Models;

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
        
    }

    public static class DataBaseSetting
    {
        public static DbConfig config = new DbConfig() {
            DataSource = "TOLA",
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