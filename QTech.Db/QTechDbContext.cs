namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using QTech.Base;

    public class QTechDbContext : DbContext
    {
        public QTechDbContext()
            : base("QTechDbContext")
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}