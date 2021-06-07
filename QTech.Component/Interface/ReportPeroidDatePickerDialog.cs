using QTech.Component.Helpers;
using Storm.Domain;
using System;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public partial class ReportPeroidDatePickerDialog : ExDialog
    {
        public ReportPeroidDatePickerDialog(DateTime d1, DateTime d2)
        {
            InitializeComponent();
            //ResourceHelper.ApplyResource(this);
            //dtpFromDate.FormatSortDate();
            //dtpToDate.FormatSortDate();
            MinimizeBox = false;
            MaximizeBox = false;

            dtpFromDate.CustomFormatWith(FormatHelper.CurrentCulture.DateTimeFormat.ShortDatePattern, dtpToDate);

            dtpFromDate.Value = d1;
            dtpToDate.Value = d2;
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        private bool Invalid()
        {
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                dtpToDate.ShowValidation(string.Format(EDomain.Resources.MsgPleaseInputGreater_, EDomain.Resources.FromDate));
                return true;
            }

            return false;
        }

        private void btnAgree_Click_1(object sender, EventArgs e)
        {
            if (Invalid()) return;

            FromDate = dtpFromDate.Value.Date;
            ToDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
            DialogResult = DialogResult.OK;
        }

        private void btnDisagree_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
