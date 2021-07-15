using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class EmployeeBillLogic : DbLogic<EmployeeBill,EmployeeBillLogic>
    {
        public override EmployeeBill FindAsync(int id)
        {
            return _db.EmployeeBills.FirstOrDefault(x=>x.Id == id);
        }
        public override EmployeeBill AddAsync(EmployeeBill entity)
        {
            return base.AddAsync(entity);
        }

    }
}
