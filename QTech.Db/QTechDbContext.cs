namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using QTech.Db.Models;

    public class QTechDbContext : DbContext
    {
        public QTechDbContext()
            : base("name=QTechDbContext")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
    }
}