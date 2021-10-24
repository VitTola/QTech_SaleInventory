using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class ApplicationSetting : QTech.Base.ActiveBaseModel
    {
        public string AppDownloadLink { get; set; }
        public string CurrentAppVersion { get; set; }
    }
}
