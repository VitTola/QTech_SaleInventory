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

namespace QTech.Forms
{
    public partial class frmProduct : ExDialog, IDialog
    {
        public Product Model { get; set; }

        public frmProduct(Product model, GeneralProcess flag)
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
            cboCategory.DataSourceFn = p => CategoryLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCategory.SearchParamFn = () => new CategorySearch();

        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text =Flag.GetTextDialog(Base.Properties.Resources.Products);
            txtUnitPrice.RegisterEnglishInputWith(txtImportPrice);
            txtName.RegisterPrimaryInputWith(txtNote, txtName);
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            txtUnitPrice.KeyPress += (sender, e) => txtUnitPrice.validCurrency(sender, e);
            txtImportPrice.KeyPress += (sender, e) => txtImportPrice.validCurrency(sender,e);
            txtName.RegisterKeyEnterNextControlWith(cboCategory, txtImportPrice, txtUnitPrice, txtNote);

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text)
                |!cboCategory.IsValidRequired(lblCategorys.Text)
                |!txtUnitPrice.IsValidNumberic()
                |!txtImportPrice.IsValidNumberic())
            {
                return true;
            }
            return false;
        }
        public async void Read()
        {
            txtName.Text = Model.Name;
            txtNote.Text = Model.Note;
            txtUnitPrice.Text = Model.UnitPrice.ToString();
            txtImportPrice.Text = Model.ImportPrice.ToString();

            var _result = await this.RunAsync(() =>
            {
                var result = CategoryLogic.Instance.FindAsync(Model.CategoryId);
                return result;
            }
            );
            cboCategory.SetValue(_result);

        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() =>ProductLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return ProductLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return ProductLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return ProductLogic.Instance.RemoveAsync(Model);
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
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            Model.ImportPrice = decimal.Parse(txtImportPrice.Text);
            var selectedCat = cboCategory.SelectedObject.ItemObject as Category;
            Model.CategoryId = selectedCat.Id;
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
