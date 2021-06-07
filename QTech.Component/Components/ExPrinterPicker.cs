//using QTech.Base.Helpers;
//using QTech.Component.Interface;
//using Storm.Domain;
//using System;
//using System.Windows.Forms;
//using EDomain = EasyServer.Domain;

//namespace QTech.Component.Components
//{
//    public partial class ExPrinterPicker : UserControl
//    {
//        public ExPrinterPicker()
//        {
//            InitializeComponent();

//            bind();
//            initEvent();
//        }

//        private bool _isCheck = false;

//        public bool IsCheck
//        {
//            get { return _isCheck; }
//            set
//            {
//                _isCheck = value;
//                chkPrintInvoice.Checked = value;
//            }
//        }

//        public string FormName { get; set; } = string.Empty;

//        public override string Text
//        {
//            get => base.Text;
//            set
//            {
//                base.Text = value;
//                chkPrintInvoice.Text = value;
//            }
//        }

//        public string SelectedPrinter { get; set; } = string.Empty;

//        private void bind()
//        {
//            chkPrintInvoice.Text = $"{EDomain.Resources.PrintInvoice} (P)";
//        }

//        private void initEvent()
//        {
//            _lblSelectedPrinter.Click += _lblChoose_Click;
//            chkPrintInvoice.CheckedChanged += _chkPrint_CheckedChanged;
//            if (!DesignMode)
//            {
//                Load += (sender, e) => loadPrinterSetting();
//            }
//        }

//        private void loadPrinterSetting()
//        {
//            Properties.Settings.Default.USER_DATA = Properties.Settings.Default.USER_DATA ?? new UISetting();
//            if (Properties.Settings.Default.USER_DATA.DefaultPrinter[FormName] is DefaultPrinterSetting defaultPrinter)
//            {
//                SelectedPrinter = _lblSelectedPrinter.Text = string.IsNullOrEmpty(defaultPrinter.PrinterName) ? Properties.Resources.SelectPrinter : defaultPrinter.PrinterName;
//            }

//            //if (Properties.Settings.Default.PrinterSettting.DefaultPrinterSetting.ContainsKey(key))
//            //{
//            //    value = !string.IsNullOrEmpty(value)
//            //        ? value
//            //        : Properties.Settings.Default.PrinterSettting.DefaultPrinterSetting[key];
//            //    Properties.Settings.Default.PrinterSettting.DefaultPrinterSetting[key] = value;
//            //}
//            //else
//            //{
//            //    Properties.Settings.Default.PrinterSettting.DefaultPrinterSetting.Add(key, value);
//            //}

//            //SelectedPrinter = _lblSelectedPrinter.Text = Properties.Settings.Default.PrinterSettting.DefaultPrinterSetting[key];
//        }

//        private void _lblChoose_Click(object sender, EventArgs e)
//        {
//            ShowInstalledPrinter();
//        }

//        public void ShowInstalledPrinter()
//        {
//            var dig = new PrinterPickerDialog(SelectedPrinter);
//            if (dig.ShowDialog() == DialogResult.OK)
//            {
//                if (!string.IsNullOrEmpty(dig.SelectedPrinter))
//                {
//                    Properties.Settings.Default.USER_DATA = Properties.Settings.Default.USER_DATA ?? new UISetting();
//                    var defaultSetting = Properties.Settings.Default.USER_DATA.DefaultPrinter[FormName];
//                    if (defaultSetting == null)
//                    {
//                        Properties.Settings.Default.USER_DATA.DefaultPrinter[FormName] = new DefaultPrinterSetting()
//                        {
//                            Name = FormName,
//                            PrinterName = dig.SelectedPrinter
//                        };
//                    }
//                    else
//                    {
//                        defaultSetting.Name = FormName;
//                        defaultSetting.PrinterName = dig.SelectedPrinter;
//                    }
//                    Properties.Settings.Default.Save();
//                    _lblSelectedPrinter.Text = string.IsNullOrEmpty(dig.SelectedPrinter) ? Properties.Resources.SelectPrinter : dig.SelectedPrinter;
//                    SelectedPrinter = string.IsNullOrEmpty(dig.SelectedPrinter) ? Properties.Resources.SelectPrinter : dig.SelectedPrinter;
//                }
//            }
//        }

//        private void _chkPrint_CheckedChanged(object sender, EventArgs e)
//        {
//            IsCheck = chkPrintInvoice.Checked;
//            _lblSelectedPrinter.Visible = chkPrintInvoice.Checked;
//            _lblSelectedPrinter.Text = string.IsNullOrWhiteSpace(SelectedPrinter) ? Properties.Resources.SelectPrinter : SelectedPrinter;
//        }

//        public void StateChanged() => chkPrintInvoice.Checked = !chkPrintInvoice.Checked;
//    }
//}
