using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class DbConfig 
    {
        public int Id { get; set; }
        public string DataSource{ get; set; }
        public string DataBase { get; set; }
        public string UserName{ get; set; }
        public string Password { get; set; }


    }
}
