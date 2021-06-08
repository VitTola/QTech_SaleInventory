using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Postition { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PayDate { get; set; }
    }
}
