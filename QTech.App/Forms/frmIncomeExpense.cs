using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmIncomeExpense : ExDialog, IDialog
    {
        public IncomeExpense Model { get; set; }

        public frmIncomeExpense(IncomeExpense model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Read();
            Bind();
            InitEvent();
        }
        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            cboMiscType.SetDataSource<MiscellaneousType>("",MiscellaneousType.All);
            
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text =Flag.GetTextDialog(Base.Properties.Resources.IncomeOutcome);
            txtNote.RegisterPrimaryInput();
            txtAmount.RegisterEnglishInput();
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            txtAmount.KeyPress += (sender, e) => txtAmount.validCurrency(sender, e);
            txtMiscNo.ReadOnly = true;
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
        }
        public bool InValid()
        {
            if (!cboMiscType.IsSelected()
                |!txtAmount.IsValidNumberic())
            {
                return true;
            }
            return false;
        }
        public void Read()
        {
            if (Flag == GeneralProcess.Add)
            {
                txtMiscNo.Text = BaseResource.NewMisNo;
                return;
            }
            txtMiscNo.Text = Model.MiscNo;
            txtNote.Text = Model.Note;
            txtAmount.Text = Model.Amount.ToString();
            cboMiscType.SelectedValue = Model.MiscellaneousType;

        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => IncomeExpenseLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtMiscNo.IsExists(_lblMiscNo.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return IncomeExpenseLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return IncomeExpenseLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return IncomeExpenseLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }
        public void Write()
        {
            Model.MiscNo = txtMiscNo.Text;
            Model.Note = txtNote.Text;
            Model.Amount = decimal.Parse(txtAmount.Text);
            Model.MiscellaneousType = (MiscellaneousType)cboMiscType.SelectedValue;
            Model.DoDate = DateTime.Now;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
