using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db;
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
    public partial class frmCustomer : ExDialog, IDialog
    {
        public Customer Model = new Customer();
        List<Site> sites = new List<Site>();
        List<Site> _removeSites = new List<Site>();

        public frmCustomer(Customer model, GeneralProcess flage)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flage;

            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            Read();
        }

        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Base.Properties.Resources.Customer;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPhone.RegisterEnglishInput();

            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.RegisterEnglishInputColumns(colPhone);
            dgv.RegisterEnglishInputColumns(colPhone);
            dgv.RegisterPrimaryInputColumns(colName);
           

            if (Flag == GeneralProcess.View)
            {
                txtName.ReadOnly = txtNote.ReadOnly = txtPhone.ReadOnly =  dgv.ReadOnly = true;
                flowLayOutLabelRemoveAdd.Enabled = false;
            }
        }
        
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) | !txtPhone.IsValidRequired(lblPhone.Text)
                | !txtPhone.IsValidPhone() | !inValidGridView())
            {
                return false;
            }
            return true;
        }

        private bool inValidGridView()
        {
            var invalidRow = false;
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var cellname = row?.Cells[colName.Name];
                var cellphone = row?.Cells[colPhone.Name];
                if (string.IsNullOrEmpty(cellname?.Value?.ToString()) && !string.IsNullOrEmpty(cellphone.Value?.ToString()))
                {
                    cellname.ErrorText = BaseResource.MsgNotInputSite;
                    invalidRow = true;
                }
                if (string.IsNullOrEmpty(cellname?.Value?.ToString()) && string.IsNullOrEmpty(cellphone.Value?.ToString()))
                {
                    invalidRow = true;
                }
            }
            if (invalidRow)
            {
                return false;
            }

            return true;
        }

        public async void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;

            var search = new SiteSearch() { CustomerId = Model.Id };
            var sites = await dgv.RunAsync(() => SiteLogic.Instance.SearchAsync(search));
            if (sites.Any())
            {
                Model.Sites = sites;
                foreach (var site in sites)
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = site.Id;
                    row.Cells[colName.Name].Value = site.Name;
                    row.Cells[colPhone.Name].Value = site.Phone;
                }
            }
            
        }
        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            if (!InValid())
            {
                return;
            }
            Model.Active = true;
            Model.Name = txtName.Text;
            Model.Phone = txtPhone.Text;
            Model.Note = txtNote.Text;

            if (Model.Sites == null)
            {
                Model.Sites = new List<Site>();
            }
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var Id =int.Parse(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
                var site = Model.Sites?.FirstOrDefault(x => x.Id == Id);
                var _name = row?.Cells[colName.Name]?.Value?.ToString() ?? string.Empty;
                var _phone = row?.Cells[colPhone.Name]?.Value?.ToString() ?? string.Empty;
                if (site != null)
                {
                    var id = (int)(row?.Cells[colId.Name]?.Value ?? 0);
                    var s = new Site()
                    {
                        Id = id,
                        Active = true,
                        Name = _name,
                        Phone = _phone,
                        CustomerId = Model.Id
                      
                    };
                    Model.Sites[Model.Sites.IndexOf(site)] = s;
                }
                else
                {
                    var s = new Site()
                    {
                        Active = true,
                        Name = _name,
                        Phone = _phone
                    };
                    Model.Sites.Add(s);
                }
               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!dgv.CurrentCell?.IsInEditMode ?? true)
            {
                if (dgv.Rows.OfType<DataGridViewRow>().Where(x => x.IsNewRow).Count() == 1 && dgv.CurrentCell == null)
                {
                    dgv.Rows.Clear();
                }
                var index = dgv.Rows[dgv.NewRowIndex].Cells[colName.Name];
                dgv.CurrentCell = index;
                dgv.BeginEdit(true);
            }

        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv?.SelectedRows?.Count > 0)
            {
                var row = dgv.SelectedRows[0];
                if (row.Cells[colName.Name].Value == null ||
                 row.Cells[colPhone.Name].Value == null)
                {
                    return;
                }
                var idValue = row.Cells[colId.Name].Value;
                if (idValue == null)
                {
                    dgv.Rows.Remove(dgv.CurrentRow);
                    return;
                }

                Model.Sites.ForEach(x =>
                {
                    if (x.Id == int.Parse(idValue.ToString()))
                    {
                        x.Active = false;
                    }
                }
                );
                if (!row.IsNewRow)
                {
                    dgv.Rows.Remove(row);
                    dgv.EndEdit();
                }
            }

        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (!InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => CustomerLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return CustomerLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return CustomerLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return CustomerLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
