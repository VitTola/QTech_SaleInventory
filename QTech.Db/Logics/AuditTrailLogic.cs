
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
using System.Reflection;
using QTech.Component;
using System.Collections;

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
        public void AddManualAuditTrail(dynamic entity, List<ChangeLog> changeLogs, GeneralProcess flag)
        {
            var type = entity.GetType() as Type;
            var name = type.ToString().Split('.').LastOrDefault();
            if (!string.IsNullOrEmpty(name))
            {
                name = ResourceHelper.Translate($"{name}_op");
            }
            
            var auditTrail = new AuditTrail();
            auditTrail.ClientAddress = GetMacAddress();
            auditTrail.ClientName = Environment.MachineName;
            auditTrail.CreatedBy = ShareValue.User.Name;
            auditTrail.UserId = ShareValue.User.Id;
            auditTrail.UserName = ShareValue.User.Name;
            auditTrail.TransactionDate = DateTime.Now;
            auditTrail.TablePK = entity.Id.ToString();
            auditTrail.TableName = $"{type.FullName}s";
            auditTrail.TableShortName = $"{type.Name}s";
            var opName = flag == GeneralProcess.Add ? BaseResource.Add :
               flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;
            auditTrail.OperatorName = $"{opName} {name}";

            var changes = JsonConvert.SerializeObject(changeLogs);
            auditTrail.ChangeJson = changes;

            this.AddAsync(auditTrail);
        }
        public void AddAuditTrail<T>(T newEntity, T oldEntity, GeneralProcess flag, List<string> ignoreProperties)
        {
            var type = newEntity.GetType() as Type;
            var name = type.ToString().Split('.').LastOrDefault();
            if (!string.IsNullOrEmpty(name))
            {
                name = ResourceHelper.Translate($"{name}_op");
            }


            var changeLogs = GetChangeLogs<T>(newEntity, oldEntity, flag, ignoreProperties);
            dynamic entity = newEntity;
            var auditTrail = new AuditTrail();
            auditTrail.ClientAddress = GetMacAddress();
            auditTrail.ClientName = Environment.MachineName;
            auditTrail.CreatedBy = ShareValue.User.Name;
            auditTrail.UserId = ShareValue.User.Id;
            auditTrail.UserName = ShareValue.User.Name;
            auditTrail.TransactionDate = DateTime.Now;
            auditTrail.TablePK = entity.Id.ToString();
            auditTrail.TableName = $"{type.FullName}s";
            auditTrail.TableShortName = $"{type.Name}s";
            var opName = flag == GeneralProcess.Add ? BaseResource.Add :
               flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;
            auditTrail.OperatorName = $"{opName} {name}";

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
            var test = q.ToList();
            //if (param.Paging?.IsPaging == true)
            //{
            //    q = q.GetPaged(param.Paging.CurrentPage, param.Paging.PageSize,true,true).Results;
            //}

            return q;
        }
        public override List<AuditTrail> SearchAsync(ISearchModel model)
        {
            return Search(model).OrderByDescending(x => x.TransactionDate).ToList();
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

        private List<ChangeLog> GetChangeLogs<T>(T newEntity, T oldEntity, GeneralProcess flag, List<string> ignoreProperties)
        {
            int index = 1;
            var changeLogs = new List<ChangeLog>();
            PropertyInfo[] properties = typeof(T).GetProperties().Where(x => !ignoreProperties.Contains(x.Name)).ToArray();
            if (flag == GeneralProcess.Update)
            {
                properties = properties.Where(o => o.GetValue(oldEntity, null)?.ToString() != o.GetValue(newEntity, null)?.ToString()).ToArray();
            }

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "SaleDetails")
                {
                    int _index = 1;
                    var details = new List<ChangeLog>();
                    Type myListElementType = property.GetType().GetGenericArguments().Single();
                    PropertyInfo[] props = myListElementType.GetProperties().Where(x => !ignoreProperties.Contains(x.Name)).ToArray();

                    foreach (PropertyInfo prop in props)
                    {
                        details.Add(
                           new ChangeLog
                           {
                               Index = _index++,
                               DisplayName = ResourceHelper.Translate(prop.Name),
                               OldValue = flag == GeneralProcess.Add ? string.Empty : property.GetValue(oldEntity, null),
                               NewValue = property.GetValue(newEntity, null),
                           }
                                 );
                    }

                    var opName = flag == GeneralProcess.Add ? BaseResource.Add : flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;
                    var name = myListElementType.ToString().Split('.').LastOrDefault();
                    if (!string.IsNullOrEmpty(name))
                    {
                        name = ResourceHelper.Translate($"{name}_op");
                    }
                    changeLogs.Add(
                           new ChangeLog
                           {
                               Index = index++,
                               DisplayName = $"{opName} {name}",
                               OldValue = string.Empty,
                               NewValue = string.Empty,
                               Details = details
                           }
                               );
                }
                else
                {
                    changeLogs.Add(
                           new ChangeLog
                           {
                               Index = index++,
                               DisplayName = ResourceHelper.Translate(property.Name),
                               OldValue = flag == GeneralProcess.Add ? string.Empty : property.GetValue(oldEntity, null),
                               NewValue = property.GetValue(newEntity, null),
                           }
                               );
                }
            }

            return changeLogs;
        }
        public bool IsGenericList(object prop)
        {
            var type = prop.GetType();
            var result = (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)));
            return result;
        }
    }
    
}
