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
            this.Text = Base.Properties.Resources.Products;
            txtUnitPrice.RegisterEnglishInput();
            txtName.RegisterPrimaryInputWith(txtNote, txtName);
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();

        }

        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text)
                |!txtUnitPrice.IsValidNumberic()
                |!cboCategory.IsValidRequired(lblCategorys.Text))
            {
                return true;
            }
            return false;
        }

        public void Read()
        {
            txtName.Text = Model.Name;
            txtNote.Text = Model.Note;
            txtUnitPrice.Text = Model.UnitPrice.ToString();

            var _result = this.RunAsync(() =>
            {
                var result = CategoryLogic.Instance.FindAsync(Model.Id);
                return result;
            }
            );
            var _category = _result.Result;
            cboCategory.SetValue(_category);

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
            if (isExist == null) { return; }
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
            //Model.CategoryId = cboPosition.Text;
        }

    }
}
