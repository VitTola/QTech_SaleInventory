﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Category : QTech.Base.ActiveBaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

    }
}
