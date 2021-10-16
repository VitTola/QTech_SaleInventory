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
    public class ApplicationSettingLogic : DbLogic<ApplicationSetting, ApplicationSettingLogic>
    {
        public string GetCurrentVersion()
        {
            var version = _db.ApplicationSettings.Where(x => x.Active).OrderByDescending(x=>x.Id).FirstOrDefault();
            return version?.CurrentAppVersion;
        }
    }
}
