using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Component
{
    public class ItemAction
    {
        public string Keyword { get; set; }
        public string ItemText { get; set; }
        public Action Action { get; set; }
    }
}
