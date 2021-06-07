using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Models
{
    public class Customer: BaseModel
    {
        public string Name { get; set; }

    }

    public class Site : BaseModel
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
    }
}
