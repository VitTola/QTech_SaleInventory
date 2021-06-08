using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Customer: QTech.Base.ActiveBaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Site : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CustomerId { get; set; }
    }
}
