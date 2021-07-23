using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class IncomExpenseSearch : QTechSearch.BasicSearchModel
    {
        public MiscellaneousType MiscellaneousType { get; set; }
        public DateTime D1 { get; set; }
        public DateTime D2 { get; set; }

    }
}
