using QTech.Base;
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
        }

        
    }
}
