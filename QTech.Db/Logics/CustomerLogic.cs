using QTech.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class CustomerLogic : DbLogic<Customer,CustomerLogic>
    {
        public CustomerLogic()
        {

        }

        public override Customer FindAsync(int id)
        {
            
            return base.FindAsync(id);
        }
    }
}
