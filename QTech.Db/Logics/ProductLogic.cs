using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    class ProductLogic:DbLogic<Product>
    {
        public ProductLogic(QTechDbContext qTechDbContext) : base(qTechDbContext)
        {
        }

    }
}
