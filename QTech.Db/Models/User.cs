using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Models
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsPasswordExpire { get; set; }
        public DateTime PasswordExpireDate { get; set; }
        public bool IsLocked { get; set; }
        public bool IsNeedChangePassword { get; set; }
        public Guid CurrentSessionId { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime CreateDate { get; set; } = Easy.Domain.Helpers.Consts.MIN_DATE;
        public string CreateBy { get; set; } = string.Empty;
        public DateTime LastModifyDate { get; set; } = Easy.Domain.Helpers.Consts.MIN_DATE;
        public string LastModifyBy { get; set; } = string.Empty;

    }

    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
        public int ModuleId { get; set; }
        public EasyServer.Domain.Enums.PermissionType PermissionType { get; set; }
        public string UiActivator { get; set; }
        public string ApiEndPoint { get; set; }
        public int Ordering { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
    }

    public class Module : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string ModuleNote { get; set; }
    }
}
