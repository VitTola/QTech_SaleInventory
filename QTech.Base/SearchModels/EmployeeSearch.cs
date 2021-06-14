using EasyServer.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class EmployeeSearch : QTechSearch.BasicSearchModel
    {
        public string Name { get; set; }


    }
}
