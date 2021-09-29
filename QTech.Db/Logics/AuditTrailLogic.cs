
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using QTech.Base.Helpers;
using QTech.Base;
using BaseResource = QTech.Base.Properties.Resources;
using Newtonsoft.Json;
using QTech.Base.BaseModels;
using QTech.Base.SearchModels;

namespace QTech.Db.Logics
{
    public class AuditTrailLogic : LongDbLogic<AuditTrail, AuditTrailLogic>
    { 
        public AuditTrailLogic()
        {

        }

        public override AuditTrail AddAsync(AuditTrail entity)
        {
            return base.AddAsync(entity);
        }
        
        public void AddManualAuditTrail(List<ChangeLog> changeLogs,BaseModel model, GeneralProcess flag)
        {
            var type = model.GetType() as Type;
            var auditTrail = new AuditTrail();
            auditTrail.ClientAddress = GetMacAddress();
            auditTrail.ClientName = Environment.MachineName;
            auditTrail.CreatedBy = ShareValue.User.Name;
            auditTrail.UserId = ShareValue.User.Id;
            auditTrail.UserName = ShareValue.User.Name;
            auditTrail.TransactionDate = DateTime.Now;
            auditTrail.TablePK = model.Id.ToString();
            auditTrail.TableName = $"{type.FullName}s";
            auditTrail.TableShortName = $"{type.Name}s";
            auditTrail.OperatorName = flag == GeneralProcess.Add ? BaseResource.Add :
               flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;

            var changes = JsonConvert.SerializeObject(changeLogs);
            auditTrail.ChangeJson = changes;

            this.AddAsync(auditTrail);
        }

        public override IQueryable<AuditTrail> Search(ISearchModel model)
        {
            var param = model as AuditTrailHistorySearch;
            var q = All();
            q = q.Where(x =>
                   x.TableName == param.TableName &&
                   x.TablePK == param.Pk && x.TransactionDate >= param.FromDate && x.TransactionDate <= param.ToDate);
            if (param.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging.CurrentPage, param.Paging.PageSize,true,true).Results;
            }
            return q;
        }
        public override List<AuditTrail> SearchAsync(ISearchModel model)
        {
            return  Search(model).OrderBy(o => o.TransactionDate).ToList();
        }

        private AuditTrail UpdateCommonValues(AuditTrail entity, GeneralProcess flage)
        {
            var auditTrail = new AuditTrail();
            auditTrail.ClientAddress = GetMacAddress();
            auditTrail.ClientName = Environment.MachineName;
            auditTrail.CreatedBy = ShareValue.User.Name;
            auditTrail.UserId = ShareValue.User.Id;
            auditTrail.UserName = ShareValue.User.Name;
            auditTrail.TransactionDate = DateTime.Now;

            return auditTrail;
        }
        
        static string _macAddress = null;
        public static string GetMacAddress()
        {
            if (_macAddress != null)
            {
                return _macAddress;
            }

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    _macAddress += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            if (_macAddress == null)
            {
                _macAddress = "Unknown";
            }
            return _macAddress;
        }
    }

}
