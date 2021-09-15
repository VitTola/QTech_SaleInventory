using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class AuditTrail : QTech.Base.ActiveBaseModel
    {
        public int UserId { get; set; }
        //2019-03-16 Chamroeun
        public Guid SessionId { get; set; }
        public string ClientAddress { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string OperatorName { get; set; } = "";
        public string OperatorGroup { get; set; } = "";
        public string TableName { get; set; } = "";
        public string TablePK { get; set; } = "";
        public string OldObjectJson { get; set; } = "";
        public string NewObjectJson { get; set; } = "";
        public string ChangeJson { get; set; } = "";
        public string TableValue { get; set; } = "";
        public string TableShortName { get; set; } = "";
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string UserName { get; set; } = "";
    }
    public class ChangeLog
    {
        public string DisplayName { get; set; } = "";
        public dynamic OldValue { get; set; } = "";
        public dynamic NewValue { get; set; } = "";
        public int Index { get; set; }
        public List<ChangeLog> Details { get; set; }
    }
}
