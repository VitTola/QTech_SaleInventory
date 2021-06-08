using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class ActiveBaseModel : QTech.Base.BaseModel
    {
        public ActiveBaseModel() { }

        public bool Active { get; set; }
    }
}
