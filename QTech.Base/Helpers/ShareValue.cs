using QTech.Base.Enums;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Helpers
{
    public class ShareValue
    {
        public static List<Permission> permissions{ get; set; }
        public static User User { get; set; }
        public static string ServerVersion { get; set; }
        public static string CurrentAppVersion { get; set; } = "v1.0.0";

        public static bool IsAuthorized(AuthKey authKey)
        {
            return permissions.Any(x => (int)x.AuthKey == (int)authKey);
        }


    }
}
