using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyServer.Domain.Models;
using QTech.Base.BaseModels;
//using EasyServer.Domain.SearchModels;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public partial class ExPaging : UserControl
    {
        public Paging Paging { get; set; } = new Paging() { IsPaging = true, CurrentPage = 1, PageSize = 25 };
        private dynamic _listModel;
        public dynamic ListModel
        {
            get => _listModel;
            set
            {
                if (Paging.IsPaging)
                {
                    var list = value;
                    if (value is DataTable table)
                    {
                        list = table.Rows.Cast<DataRow>().ToList();
                    }
                    if (value == null && Paging.CurrentPage > 1)
                    {
                        lblNextPaging.Enabled = false;
                    }
                    else if (value != null && Enumerable.Any(list) == false && Paging.CurrentPage > 1)
                    {
                        lblNextPaging.Enabled = false;
                    }
                    else
                    {
                        lblNextPaging.Enabled = true;
                    }
                    _lblCurrentPage.Text = $"ទំព័រទី៖{Paging.CurrentPage}";
                    if (lblNextPaging.Enabled == false)
                    {
                        Paging.CurrentPage = Math.Max(Paging.CurrentPage - 1, 1);
                        _lblCurrentPage.Text = $"ទំព័រទី៖{Paging.CurrentPage}";
                        return;
                    }
                }
                else
                {
                    _lblCurrentPage.Text = "គ្រប់ទំព័រ";
                }
                _listModel = value;
            }
        }
        public int CurrentPage { get; }
        public bool IsPaging { get; set; }
        private bool _isShowAll=false;
        public bool ShowAllOption
        {
            get => _isShowAll; set
            {
                if (value == false)
                {
                    Repaging();
                    lblShowAllPaging.Visible = lblShowAllPaging.Enabled = false;
                }
                else
                {
                    lblShowAllPaging.Visible = lblShowAllPaging.Enabled = true;
                }
                _isShowAll = value;
            }
        }

        public Func<Task> Action { get; set; }
        public ExPaging()
        {
            InitializeComponent();
            this.MinimumSize = new Size(380, 33);
            this.ApplyResource();
        } 

        private void lblNextPaging__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             NextPage();
        }
        private void lblPreviousPaging_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PreviousPage();
        }
        private void lblShowAllPaging_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAll();
        }
        public void Repaging()
        {
            if (Paging.IsPaging)
            {
                Paging.CurrentPage = 1;
                lblPreviousPaging.Enabled =
                lblNextPaging.Enabled = true;
            }         
        }

        public void NextPage()
        {
            if (!(lblNextPaging.Enabled&&lblNextPaging.Visible)||!Paging.IsPaging)
            {
                return;
            }
            Paging.CurrentPage++; 
            if (this.FindForm() is IPage page)
            {
                 page.Search();
            }
            else
            {
                if (Action != null)
                {
                    Action.Invoke();
                }
            }
            _lblCurrentPage.Text = $"ទំព័រទី៖ {Paging.CurrentPage}";
        }

        public void PreviousPage()
        {
            if (!(lblPreviousPaging.Enabled&&lblPreviousPaging.Visible)||!Paging.IsPaging)
            {
                return;
            }

            Paging.CurrentPage = Math.Max(Paging.CurrentPage - 1, 1);
            Paging.IsPaging = true;
            if (this.FindForm() is IPage page)
            {
                page.Search();
            }
            else
            {
                if (Action != null)
                {
                    Action.Invoke();
                }
            }
            _lblCurrentPage.Text = $"ទំព័រទី៖ {Paging.CurrentPage}";

        }

        public void ShowAll()
        {
            if (!lblShowAllPaging.Visible)
            {
                return;
            }
            Paging.IsPaging = !Paging.IsPaging;

            if (Paging.IsPaging)
            {
                Repaging();
                lblPreviousPaging.Visible =
                lblNextPaging.Visible = true;
                lblShowAllPaging.Text = EDomain.Resources.ShowAllPaging;
            }
            else
            {
                lblNextPaging.Visible =
                lblPreviousPaging.Visible = true;
                lblShowAllPaging.Text = EDomain.Resources.ShowByPaging;
            }

            if (this.FindForm() is IPage page)
            {
                page.Search();
            }
            else
            {
                if (Action != null)
                {
                    Action.Invoke();
                }
            }
        }

        public void ForceShowAll()
        {
            Paging.IsPaging = !Paging.IsPaging;

            if (Paging.IsPaging)
            {
                Repaging();
                lblPreviousPaging.Visible =
                lblNextPaging.Visible = true;
                lblShowAllPaging.Text = EDomain.Resources.ShowAllPaging;
            }
            else
            {
                lblNextPaging.Visible =
                lblPreviousPaging.Visible = true;
                lblShowAllPaging.Text = EDomain.Resources.ShowByPaging;
            }

            if (this.FindForm() is IPage page)
            {
                page.Search();
            }
            else
            {
                if (Action != null)
                {
                    Action.Invoke();
                }
            }
        }
    }
}
