﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class SiteSearch : QTechSearch.BasicSearchModel
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
    }
}
