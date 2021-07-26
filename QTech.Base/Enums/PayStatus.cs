using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Enums
{
    public enum PayStatus
    {
        NotYetPaid = 0,
        Paid =1,
        WaitPayment = 2,
        All =3,
    }

    public enum InvoiceStatus
    {
        WaitPayment = 0,
        PaySome = 1,
        Paid =2,
        All = 3
    }


}
