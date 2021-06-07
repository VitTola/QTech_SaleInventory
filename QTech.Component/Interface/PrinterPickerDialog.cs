using QTech.Base.Helpers;
using QTech.Component.Helpers;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using QTech.Base.Helpers;

namespace QTech.Component.Interface
{
    public partial class PrinterPickerDialog : ExDialog, IDialog
    {
        public PrinterPickerDialog(string selectedPrinter = "")
        {
            InitializeComponent();
            SelectedPrinter = selectedPrinter;

            Bind();
            InitEvent();
            Text = Properties.Resources.SelectPrinter;
        }

        public GeneralProcess Flag { get; set; }
        public string SelectedPrinter { get; set; } = string.Empty;

        public void Bind()
        {
            dgv.DataSource = PrinterSettings.InstalledPrinters.OfType<string>().Select(x => new { Name = x }).ToList();
            if (!string.IsNullOrEmpty(SelectedPrinter))
            {
                dgv.RowSelected(nameof(colName), SelectedPrinter);
            }
        }

        public void InitEvent()
        {
            btnClose.Click += (sender, e) => Close();
            btnSelect.Click += (sender, e) => selectedPrinter();

            dgv.CellDoubleClick += dgv_CellDoubleClick;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPrinter();
        }

        private void selectedPrinter()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedObject = dgv.SelectedRows[0].Cells[colName.Name].Value?.ToString();
            if (!string.IsNullOrEmpty(selectedObject))
            {
                SelectedPrinter = selectedObject;
                DialogResult = DialogResult.OK;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                selectedPrinter();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                selectedPrinter();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Q))
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool InValid() => false;

        public void Read() { }

        public void Save() { }

        public void ViewChangeLog() { }

        public void Write() { }
    }
}
