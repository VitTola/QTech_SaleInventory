using QTech.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class CustomerLogic : DbLogic<Customer>
    {
        Customer c = new Customer();
        public CustomerLogic(QTechDbContext qTechDbContext): base(qTechDbContext)
        {
            c.Name = "Gipmong";
            c.Phone = "010889944";
            this.AddAsync(c);
        }

        public override Task<Customer> FindAsync(int id)
        {
            
            return base.FindAsync(id);
        }
    }
}
