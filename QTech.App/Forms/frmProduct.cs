using QTech.Base.Helpers;
using QTech.Component;
using QTech.Component.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Forms
{
    public partial class frmProduct : ExDialog, IDialog
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        public GeneralProcess Flag { get; set; }


        public void Bind()
        {
            throw new NotImplementedException();
        }

        public void InitEvent()
        {
            throw new NotImplementedException();
        }

        public bool InValid()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
