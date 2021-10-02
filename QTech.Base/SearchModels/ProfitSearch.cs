using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class ProfitSearch : QTechSearch.BasicSearchModel
    {
        public DateTime D1 { get; set; }
        public DateTime D2 { get; set; }
    }
}
