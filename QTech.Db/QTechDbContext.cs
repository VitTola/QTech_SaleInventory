namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using QTech.Base;
    using QTech.Base.Models;

    public class QTechDbContext : DbContext
    {
        //public QTechDbContext()
        //    : base("QTechDbContext")
        //{
        //}
        public QTechDbContext()
            : base("data source=TOLA;initial catalog=QTech_SaleDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
    }
}