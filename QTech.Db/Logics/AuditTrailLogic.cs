
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

using System.Collections;
using EasyServer.Domain.Helpers;
using EDomain = EasyServer.Domain;
using Easy.Domain.Helpers;

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
        public void AddManualAuditTrail(dynamic entity, ChangeLog changeLogs, GeneralProcess flag)
        {
            var type = entity.GetType() as Type;
            var name = type.ToString().Split('.').LastOrDefault();
            if (!string.IsNullOrEmpty(name))
            {
                //name = ResourceHelper.Translate($"{name}_op");
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
      
        public List<ChangeLog> GetChangeLogs<T, TKey>(T entity, T oldEntity, GeneralProcess flag, List<string> ignoredFields) where T : TBaseModel<TKey> where TKey : struct
        {
            var changeLogs = new List<ChangeLog>();
            var properties = entity.GetType().GetProperties().OrderBy(x => ((AuditDataAttribute)x.GetCustomAttributes(typeof(AuditDataAttribute), true).Cast<AuditDataAttribute>().SingleOrDefault())?.Index ?? 0);
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name.EndsWith("Id") || ignoredFields.Contains(propertyInfo.Name)) continue;
                var changelog = GetChangeLog<T, TKey>(entity, oldEntity, propertyInfo, flag);
                if (changelog != null)
                {
                    changeLogs.Add(changelog);
                }
            }
            return changeLogs;
        }

        private ChangeLog GetChangeLog<T, TKey>(T entity, T oldObject, PropertyInfo propertyInfo, GeneralProcess flag) where T : TBaseModel<TKey> where TKey : struct
        {
            ChangeLog changeLog = null;
            dynamic newValue = propertyInfo.GetValue(entity)?.ToString() ?? "";
            dynamic oldValue = null;
            var isNullValueAllField = (AuditTrailIsNullReturnValueAllField.IsNullReturnValueAllFields.Contains(propertyInfo.Name));

            if (flag != GeneralProcess.Add)
            {
                if (oldObject != null)
                {
                    oldValue = propertyInfo.GetValue(oldObject)?.ToString() ?? "";
                }
                if (isNullValueAllField)
                {
                    oldValue = string.IsNullOrEmpty(oldValue) ? (string.Format(EDomain.Resources.All_, DomainResourceHelper.Translate(propertyInfo.Name))) : oldValue;
                }
            }

            if (isNullValueAllField)
            {
                newValue = string.IsNullOrEmpty(newValue) ? (string.Format(EDomain.Resources.All_, DomainResourceHelper.Translate(propertyInfo.Name))) : newValue;
            }

            if (flag == GeneralProcess.Remove)
            {
                newValue = null;
            }
            var propertyType = (propertyInfo.GetValue(entity) == null)
                ? typeof(object)
                : propertyInfo.GetValue(entity).GetType();

            if (propertyType.IsGenericType &&
                    (propertyType.GetGenericTypeDefinition() == typeof(List<>) || propertyType.GetGenericTypeDefinition() == typeof(IQueryable<>))) { return null; }

            if (typeof(decimal) == propertyType)
            {
                oldValue = Parse.ToDecimal(oldValue);
                newValue = Parse.ToDecimal(newValue);
            }
            else if (typeof(DateTime) == propertyType)
            {
                oldValue = (oldValue == null) ? Consts.MIN_DATE : DateTime.Parse(oldValue);
                newValue = (newValue == null) ? Consts.MIN_DATE : DateTime.Parse(newValue);

                if (oldValue != newValue)
                {
                    if (oldValue <= Consts.MIN_DATE || oldValue <= Consts.MIN_DATE)
                    {
                        oldValue = "";
                    }
                    else if (oldValue == Consts.MAX_DATE)
                    {
                        oldValue = EDomain.Resources.MaxedDate;
                    }
                    else
                    {
                        oldValue = (oldValue.TimeOfDay.TotalSeconds == 0) ? oldValue.ToString("dd/MM/yyyy") : oldValue.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }

                    if (newValue <= Consts.MIN_DATE || newValue <= Consts.MIN_DATE)
                    {
                        newValue = "";
                    }
                    else if (newValue == Consts.MAX_DATE)
                    {
                        newValue = EDomain.Resources.MaxedDate;
                    }
                    else
                    {
                        newValue = (newValue.TimeOfDay.TotalSeconds == 0) ? newValue.ToString("dd/MM/yyyy") : newValue.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                }
            }
            else if (typeof(int) == propertyType)
            {
                oldValue = Parse.ToInt(oldValue);
                newValue = Parse.ToInt(newValue);
            }
            if (oldValue != newValue)
            {
                AuditDataAttribute dp = propertyInfo.GetCustomAttributes(typeof(AuditDataAttribute), true).Cast<AuditDataAttribute>().SingleOrDefault();
                
                var displayname = (!string.IsNullOrEmpty(dp?.ResourceName ?? "")) ? dp.ResourceName : propertyInfo.Name;
                if (propertyType.BaseType == typeof(Enum))
                {
                    // *** Translate ***
                    oldValue = string.IsNullOrEmpty(oldValue) ? "" : DomainResourceHelper.Translate(propertyInfo.PropertyType.Name + "_" + oldValue);
                    newValue = string.IsNullOrEmpty(newValue) ? "" : DomainResourceHelper.Translate(propertyInfo.PropertyType.Name + "_" + newValue);
                    
                }
                else if (typeof(int) == propertyType)
                {
                    oldValue = (oldValue == 0) ? ((flag == GeneralProcess.Update) ? "0" : "") : oldValue.ToString();
                    newValue = (newValue == 0) ? ((flag == GeneralProcess.Update) ? "0" : "") : newValue.ToString();
                }
                else if (typeof(decimal) == propertyType)
                {
                    oldValue = (oldValue == 0m) ? ((flag == GeneralProcess.Update) ? "0" : "") : oldValue.ToString(Formats.DecimalFormat);
                    newValue = (newValue == 0m) ? ((flag == GeneralProcess.Update) ? "0" : "") : newValue.ToString(Formats.DecimalFormat);
                }
                changeLog = new ChangeLog() { DisplayName = $"{displayname}", NewValue = newValue, OldValue = oldValue };
            }
            return changeLog;
        }
        public class AuditTrailIsNullReturnValueAllField
        {
            /// <summary>
            /// ZoroValueAllFields = if field type is object and value = null and flag not remove for newValue and flag not add for oldValue =>  return value ALl + Type.Name ; eg AllCompany,AllBranch.....
            /// </summary>
            public static List<string> IsNullReturnValueAllFields = new List<string>()
            {
              
            };
        }
    }

}
