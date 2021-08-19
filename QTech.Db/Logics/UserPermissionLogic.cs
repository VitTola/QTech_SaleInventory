using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class UserPermissionLogic : DbLogic<UserPermission,UserPermissionLogic>
    {
        public List<UserPermission> GetUserPermissionsByUserId(int id)
        {
            return _db.UserPermissions.Where(x => x.Active && x.UserId == id).ToList();
        }
        public override IQueryable<UserPermission> Search(ISearchModel model)
        {
            var param = model as UserPermissionSearch;
            var q = All();
            if (param.UserId != 0)
            {
                q = q.Where(x => x.UserId == param.UserId);
            }
            return q;
        }
        public override UserPermission AddAsync(UserPermission entity)
        {
            if (IsExisted(entity))
            {
                return null;
            }
            return base.AddAsync(entity);
        }
        public override List<UserPermission> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        private  bool IsExisted(UserPermission entity)
        {
            var result =  _db.UserPermissions.AsNoTracking().Any(x =>x.Active && x.UserId == entity.UserId && x.PermissionId == entity.PermissionId);
            return result;
        }
    }
}
