using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
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
    public partial class frmCategory : ExDialog, IDialog
    {
        public Category Model { get; set; }

        public frmCategory(Category model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Bind();
            InitEvent();
        }
        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            colName.Visible = true;
            colName.Width = 100;

            Read();
        }
        public void InitEvent()
        {
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Categorys);
            txtNote.RegisterPrimaryInput();
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
            
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
              )
            {
                return true;
            }
            return false;
        }
        public void Read()
        {
            txtName.Text = Model.Name;
            txtNote.Text = Model.Note;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => CategoryLogic.Instance.IsExistsAsync(Model));
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
                    return CategoryLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return CategoryLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return CategoryLogic.Instance.RemoveAsync(Model);
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
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
