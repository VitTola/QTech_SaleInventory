using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class UserPermission : ActiveBaseModel
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }

    public class Permission : ActiveBaseModel
    {
        public string Name { get; set; } = "";
        public int Level { get; set; }
        public int ParentId { get; set; }
        public PermissionType PermissionType { get; set; }
        public string UiActivator { get; set; }
        public AuthKey AuthKey { get; set; }
        public int Ordering { get; set; }
        public string Note { get; set; } = "";
    }

    public class User : ActiveBaseModel
    {
        public string Name { get; set; } = "";
        public string FullName { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Note { get; set; }
        public List<UserPermission> UserPermissions { get; set; }

    }

}
