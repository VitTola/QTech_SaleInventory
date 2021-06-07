using QTech.Component.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Base.Helpers;

namespace QTech.Component.Interfaces
{
    public partial class CustomAdvanceFilter : ExDialog, IDialog
    {
        public static Dictionary<string, Control> LastFilter = new Dictionary<string, Control>();

        public Dictionary<string, Control> _exSearchCombos = new Dictionary<string, Control>();

        private Func<bool> FuncInValid;
        public GeneralProcess Flag { get; set; } 

        public CustomAdvanceFilter(Dictionary<string, Control> exSearchCombo,Func<bool> funcInValid, bool isSelectDefautValue = false)
        {
            InitializeComponent();
            this._exSearchCombos = exSearchCombo;
            FuncInValid = funcInValid;
            Bind();
            if (isSelectDefautValue)
            {
                initDefaultValue();
            }
        }

        public void Read() { }

        private void initDefaultValue()
        {
            if (_exSearchCombos == null)
            {
                return;
            }
            foreach (var item in _exSearchCombos.Values)
            {
                if (item is ExSearchCombo cbo)
                {
                    if (!item.IsHandleCreated)
                    {
                        item.CreateControl();
                    }
                    if (cbo.SelectedItems.Any())
                    {
                        cbo.SelectedValue = cbo.SelectedItems[0].Id;
                    }
                }
                else if (item is ExSearchListCombo cboList)
                {
                    if (!item.IsHandleCreated)
                    {
                        item.CreateControl();
                    }
                    if (cboList.SelectedItems.Any())
                    {
                        cboList.SelectedValue = cboList.SelectedItems[0].Id;
                    }
                }
            }
        }

        public void InitEvent() { }

        public void Bind()
        {
            CreateSearchCombo();
        }

        //int align_top = 1;
        public void CreateSearchCombo()
        {
            if (_exSearchCombos.Any())
            {
                var i = 0;
                foreach (var item in _exSearchCombos)
                {  
                    DrawLabel(item.Key);
                    
                    //item.Value.Top = align_top;
                    item.Value.Margin = new Padding(4, 3, 4, 4);
                    item.Value.Width = 305-8;
                    item.Value.Left = 25;
                    item.Value.TabIndex = i;
                    i++;
                    //align_top = align_top + 1;
                    this.flowLayoutPanel4.Controls.Add(item.Value);
                    ResizeDialog();
                }
            }
        }

        private void DrawLabel(string name)
        {
            var label = new Label();
            //label.Top = /*align_top * 50*/ 100;
            //label.Location = new Point(y:align_top*20, x: 0 );
            label.Margin = new Padding(0, 6, 0, 0);
            label.Height = 16;
            label.Width = 305;
            label.Left = 25;
            label.ForeColor = Color.FromArgb(135, 90, 123);
            label.Name = name.Replace("cbo", "lbl");
            label.Font = new Font("Khmer Os Siemreap", emSize: 7, style: FontStyle.Bold);
            this.flowLayoutPanel4.Controls.Add(label);
        }

        private void ResizeDialog()
        {
            this.flowLayoutPanel4.Height += 48;
            this.Height += 48;
        }

        public void Save()
        {
            //Check validation
            if (FuncInValid?.Invoke()==true)
            {
                return;
            }


            if (_exSearchCombos.Any())
            {
                foreach (var item in _exSearchCombos)
                {
                    LastFilter[item.Key] = item.Value;
                }
            }

            DialogResult = DialogResult.OK;
        }

        public bool InValid() => false;

        public void ViewChangeLog() { }

        public void Write() { }


        private void btnOK_Click_1(object sender, EventArgs e)
        {
            Save();
        }

        public void SetVisible(bool visible, int controlDisplayCount,params string[] keys)
        {
            var controls = flowLayoutPanel4.GetAllControls().ToList();
            foreach (var item in keys)
            {
                var lbl = $"lbl{item}";
                var cbo = $"cbo{item}";
                var visibles = controls.Where(x => x.Name == lbl || x.Name == cbo).ToList();
                visibles.ForEach(x => x.Visible = visible);
            }

            this.flowLayoutPanel4.Height = 42 + controlDisplayCount * 48;
            this.Height = 132 + controlDisplayCount * 48;
        }
    }
}
