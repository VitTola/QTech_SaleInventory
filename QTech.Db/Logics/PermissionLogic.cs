using QTech.Base.BaseModels;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class PermissionLogic : DbLogic<Permission,PermissionLogic>
    {
        public override IQueryable<Permission> Search(ISearchModel model)
        {
            return All();
        }
        public override List<Permission> SearchAsync(ISearchModel model)
        {
            var result = _db.Permissions.Where(x => x.Active).ToList();
            return result;
        }
        public List<Permission> GetPermissionByIds(List<int> ids)
        {
            return _db.Permissions.Where(p=> ids.Any(i=>i == p.Id)).ToList();
        }
    }
}
