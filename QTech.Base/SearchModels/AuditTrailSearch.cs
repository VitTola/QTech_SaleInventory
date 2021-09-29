using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class AuditTrailSearch : QTechSearch.BasicSearchModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
