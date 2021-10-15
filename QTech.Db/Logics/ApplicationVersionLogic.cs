using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class ApplicationVersionLogic : DbLogic<ApplicationSetting, ApplicationVersionLogic>
    {
        public string GetCurrentAppVersion()
        {
            return All().LastOrDefault().CurrentAppVersion;
        }
        public string GetCurrentServerVersion()
        {
            return All().LastOrDefault().ServerVersion;
        }
        public string GetDownloadLink()
        {
            return All().LastOrDefault().AppDownloadLink;
        }
    }
}
