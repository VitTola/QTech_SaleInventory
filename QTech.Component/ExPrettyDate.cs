using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    public class ExPrettyDate:Label
    {
        private DateTime _value = DateTime.Now;
        public DateTime Value { get =>_value; set
            {
                _value = value;
                this.Invalidate();
            }
        }

        public override string Text { get => Value.GetPrettyDate(); set => base.Text = value; } 
    }
}
