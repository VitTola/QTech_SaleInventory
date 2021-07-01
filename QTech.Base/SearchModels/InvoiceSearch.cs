﻿using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class InvoiceSearch : QTechSearch.BasicSearchModel
    {
        public SaleSearchKey saleSearchKey { get; set; }
        public PayStatus payStatus { get; set; }

        public int Id { get; set; }
    }
}
