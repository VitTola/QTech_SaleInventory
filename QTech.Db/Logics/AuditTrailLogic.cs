
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using QTech.Base.Helpers;
using QTech.Base;

namespace QTech.Db.Logics
{
    public class AuditTrailLogic : LongDbLogic<AuditTrail, AuditTrailLogic>
    {
        public AuditTrailLogic()
        {

        }

        public override AuditTrail AddAsync(AuditTrail entity)
        {
            entity = UpdateCommonValues(entity,GeneralProcess.Add);
            return base.AddAsync(entity);
        }
        
        public void AddManualAuditTrail(BaseModel model)
        {

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

        private List<ChangeLog> GetChangeLog()
        {
            var changeLogs = new List<ChangeLog>();



            return changeLogs;
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
