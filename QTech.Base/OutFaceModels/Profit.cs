using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModels
{
    public class Profit
    {
        public string Customer { get; set; } = string.Empty;
        public decimal CustomerAmount { get; set; } = 0;
        public decimal GeneralIncome { get; set; } = 0;
        public string Driver { get; set; } = string.Empty;
        public decimal DriverAmount { get; set; } = 0;
        public decimal GeneralExpense { get; set; }=0;
        public decimal Expense { get; set; } = 0;
        public int Key { get; set; } = 0;
    }
}
