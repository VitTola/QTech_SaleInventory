using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.MyComponents
{
    public partial class CurrencyTextboxPanel : UserControl
    {
        public CurrencyTextboxPanel()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public override string Text
        {

            get => txtValue.Text;

            set {
                txtValue.Text = value;
            }
        }

        [Browsable(true)]
        public string Currency { get; set; } = "USD";
        
    }
}
