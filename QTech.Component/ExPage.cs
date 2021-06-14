using QTech.Base.Helpers;
using QTech.Component.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExPage:Form
    {

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this is IPage page)
            {
                if (keyData == Conts.PageKey[GeneralProcess.Add])
                {
                    var btnAdd = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Add)}");
                    if (btnAdd?.Visible == true 
                        && btnAdd?.Enabled == true
                        && btnAdd?.Executing == false)
                    {
                        page.AddNew();
                        return true;
                    }
                }
                else if (keyData == Conts.PageKey[GeneralProcess.Update])
                {
                    var btnUpdate = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Update)}");
                    if (btnUpdate?.Visible == true 
                        && btnUpdate?.Enabled == true
                        && btnUpdate?.Executing ==false)
                    {
                        page.EditAsync();
                        return true;
                    }
                }
                //else if (keyData == Conts.PageKey[GeneralProcess.View])
                //{
                //    var dgv = this.GetAllControls().OfType<ExDataGridView>().FirstOrDefault();
                //    if (dgv != null
                //        && dgv.Executing==false)
                //    {
                //        dgv.ToExcelAsync(Text, ShareAPI.Instance.FormalUserName);
                //    }
                //    return true; 
                //}
                else if (keyData == Conts.PageKey[GeneralProcess.Remove])
                {
                    var btnRemove = this.GetAllControls().OfType<ExButtonLoading>()
                  .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Remove)}");
                    if (btnRemove?.Visible == true 
                        && btnRemove?.Enabled == true
                        && btnRemove?.Executing ==false)
                    {
                        page.Remove();
                        return true;
                    }
                }
                else if (keyData == Conts.PaginationKey[Pagination.Next])
                {
                    var pagination = this.GetAllControls().OfType<ExPaging>()
                        .FirstOrDefault();
                    if (pagination !=null)
                    {
                        pagination.NextPage();
                    }
                    return true; 
                }
                else if(keyData == Conts.PaginationKey[Pagination.Previous])
                {
                    var pagination = this.GetAllControls().OfType<ExPaging>()
                       .FirstOrDefault();
                    if (pagination != null)
                    {
                        pagination.PreviousPage();
                    }
                    return true;
                }
                else if (keyData == Conts.PaginationKey[Pagination.ShowAll])
                {
                    var pagination = this.GetAllControls().OfType<ExPaging>()
                       .FirstOrDefault();
                    if (pagination != null)
                    {
                        pagination.ShowAll();
                    }
                    return true;
                }
            }
            if (this is IPageReport pageReport) 
            {
                if (keyData == Conts.PageReportKey[PageReport.View] )
                {
                    var btnView = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.View)}");
                    if (btnView?.Visible == true
                        && btnView?.Enabled == true
                        && btnView?.Executing == false)
                    {
                        pageReport.View();
                        return true;
                    }
                }
                else if (keyData == Conts.PageReportKey[PageReport.Find])
                {
                    var btnFind = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.AdvanceSearch)}");
                    if (btnFind?.Visible == true
                        && btnFind?.Enabled == true
                        && btnFind?.Executing == false)
                    {
                        pageReport.Find();
                        return true;
                    }
                }
                else if (keyData == Conts.PageReportKey[PageReport.DownloadCsv]) 
                {
                    var btnDownloadCsv = this.GetAllControls().OfType<ExButtonLoading>()
                  .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.DownLoadCsv)}");
                    if (btnDownloadCsv?.Visible == true
                        && btnDownloadCsv?.Enabled == true
                        && btnDownloadCsv?.Executing == false)
                    {
                        pageReport.DownloadCsv();
                        return true;
                    }
                }   
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        protected override void OnLoad(EventArgs e)
        {
            this.DefaultEnglishInputControls();
            if (this is IPage page)
            {
                var btnAdd = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Add)}");
                var btnUpdate = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Update)}");
                var btnRemove = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Remove)}");

                if (btnAdd!=null)
                {
                    btnAdd.ShortcutText = Conts.PageKeyText[GeneralProcess.Add];
                }
                if (btnUpdate!=null)
                {
                    btnUpdate.ShortcutText = Conts.PageKeyText[GeneralProcess.Update];
                }
                if (btnRemove!=null)
                {
                    btnRemove.ShortcutText = Conts.PageKeyText[GeneralProcess.Remove];
                }

            }
            if (this is IPageReport pageReport)
            {
                var btnFind = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.AdvanceSearch)}");
                var btnView = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.View)}"); 
                var btnDownloadCsv = this.GetAllControls().OfType<ExButtonLoading>()
                  .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.DownLoadCsv)}");

                if (btnFind != null)
                {
                    btnFind.ShortcutText = Conts.PageReportKeyText[PageReport.Find]; 

                }
                if (btnView != null)
                {
                    btnView.ShortcutText = Conts.PageReportKeyText[PageReport.View]; 
                }
                if (btnDownloadCsv != null)
                {
                    btnDownloadCsv.ShortcutText = Conts.PageReportKeyText[PageReport.DownloadCsv];
                    //var menu = new ContextMenuStrip
                    //{
                    //    Font = this.Font
                    //};
                    //var menuDownload = new ToolStripMenuItem()
                    //{
                    //    Name = "menuDownload",
                    //    Text = Resources.DownLoadCsv
                    //};
                    //var menuRedownload = new ToolStripMenuItem()
                    //{
                    //    Name = "menuRedownload",
                    //    Text = "ទាញយកឡើងវិញ"
                    //}; 
                    //menu.Items.Add(menuDownload);
                    //menu.Items.Add(menuRedownload);
                    //btnDownloadCsv.Click += (s, ec) =>
                    //{
                    //    var clt = (Control)s;
                    //    var location = clt.ClientRectangle.Location;
                    //    location.Y = clt.Height;
                    //    location.X = clt.Width;
                    //    menu.Show(clt, location, ToolStripDropDownDirection.BelowLeft);
                    //};
                } 
            }
            base.OnLoad(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ExPage
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ExPage";
            this.ResumeLayout(false);

        }
    }
}
