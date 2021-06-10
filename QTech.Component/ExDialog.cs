using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using QTech.Component.Helpers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QTech.Base.Helpers;
using EDomain = EasyServer.Domain;


namespace QTech.Component
{
    public partial class ExDialog : Form, IMessageFilter, IAsyncTask
    {
        private HashSet<Control> controlsToMove = new HashSet<Control>();
        public ExDialog()
        {
            InitializeComponent();
            /*
             * Setting...
             */
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Icon = Properties.Resources.OoneIcon;
            container.Padding = new Padding(1);
            imgICON.Image = Icon.ToBitmap();
            imgICON.DataBindings.Add("Visible", this, "ShowIcon");
            _bMinimize.DataBindings.Add(nameof(_bMinimize.Visible), this, nameof(this.MinimizeBox));
            _bMaximize.DataBindings.Add(nameof(_bMaximize.Visible), this, nameof(this.MaximizeBox));
            MaximizedBounds = Screen.FromControl(this).WorkingArea;
            StartPosition = FormStartPosition.CenterScreen;
            IsLoading = true;
            bar.Visible = false;
            /*
             * Drag able
             */
            Application.AddMessageFilter(this);
            controlsToMove.Add(this);
            controlsToMove.Add(_lblTITLE);
            controlsToMove.Add(digheader);
            /*
             * Min,Max,Close form.
             */
            _bMinimize.Click += btnMinimize_Click;
            _bMaximize.Click += btnMaximize_Click;
            _bClose.Click += btnClose_Click;
            //_bMaximize.Image = Properties.Resources.maximize;
            _bMinimize.Image = Properties.Resources.hide;

            _bMaximize.Image = new Bitmap(Properties.Resources.hide, new Size(16, 16));
            _bMinimize.Image = new Bitmap(Properties.Resources.hide, new Size(16, 16));
            _bClose.Image = new Bitmap(Properties.Resources.close, new Size(16, 16));

            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);

            this.Move += ExDialog_Move;

        }

        private void ExDialog_Move(object sender, EventArgs e)
        {
            AdaptBackGroundColor();
        }

        private void AdaptBackGroundColor()
        {
            var location = GetLeftLocation(this);
            var color = GetPixelColor(location);
            if (color != null)
            {
                this.digheader.BackColor = color;
            }
        }

        static Color GetPixelColor(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }

        private Point GetLeftLocation(Control c)
        {
            return c.PointToScreen(Point.Empty);
        }



        public virtual void SetDefaultColumnSize() { }

        public virtual void Reload()
        {
        }

        public bool IsLoading { get; set; } = true;

        private bool _applyResource = true;
        public bool ApplyResource { get { return _applyResource; } set { _applyResource = value; } }

        public void ShowControlBox(bool show)
        {
            _bMinimize.Visible =
                _bMaximize.Visible = show;
        }

        

        protected override void OnLoad(EventArgs e)
        {
            this.ApplyResource();
            this.InitForm();
            this.OptimizeLoadUI();
            this.DefaultEnglishInputControls();
            this.Reload();
            if (this is IPage page)
            {
                var btnAdd = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Add)}");
                var btnUpdate = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Update)}");
                var btnRemove = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Remove)}");
                if (btnAdd != null)
                {
                    btnAdd.ShortcutText = Conts.PageKeyText[GeneralProcess.Add];
                }
                if (btnUpdate != null)
                {
                    btnUpdate.ShortcutText = Conts.PageKeyText[GeneralProcess.Update];
                }
                if (btnRemove != null)
                {
                    btnRemove.ShortcutText = Conts.PageKeyText[GeneralProcess.Remove];
                }
            }

            /*
             * Visible Change log button.
             */
            if (this is IDialog dig)
            {
                var flag = dig.Flag;
                var btnChangeLog = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.ChangeLog)}");
                var btnOk = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.OK)}");
                var btnClose = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Close)}");
                var btnSave = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Save)}");
                var exPagings = this.GetAllControls().OfType<ExPaging>();
                if (exPagings != null)
                {
                    foreach(var paging in exPagings)
                    {
                        paging.Repaging();
                    }
                }
                //if (flag == GeneralProcess.View)
                //{
                //    if (btnOk != null)
                //    {
                //        btnOk.Select();
                //    }
                //    else if (btnSave != null)
                //    {
                //        btnSave.Select();
                //    }
                //}
                if (flag == GeneralProcess.Remove | flag == GeneralProcess.View)
                {
                    if (btnClose != null)
                    {
                        btnClose.Select();
                    }
                }
                if (btnChangeLog != null)
                {
                    btnChangeLog.Visible = !(flag == GeneralProcess.Add || flag == GeneralProcess.Copy);
                    btnChangeLog.ShortcutText = Conts.DialogKeyText[DialogProcess.ViewChangeLog];
                }
                if (btnOk != null)
                {
                    btnOk.Visible = (flag != GeneralProcess.View);
                    btnOk.ShortcutText = Conts.DialogKeyText[DialogProcess.Save];
                }
                if (btnClose != null)
                {
                    btnClose.ShortcutText = Conts.DialogKeyText[DialogProcess.Close];
                }
                if (btnSave != null)
                {
                    btnSave.Visible = (flag != GeneralProcess.View);
                    btnSave.ShortcutText = Conts.DialogKeyText[DialogProcess.Save];
                }
            }

            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        { 
            base.OnClosing(e);

            if (Executing)
            {
                e.Cancel = true;
                return;
            }

            if(this.GetAllControls().OfType<IAsyncTask>().Any(x=>x.Executing))
            {
                e.Cancel = true;
                return;
            }

            foreach (var viewer in this.GetAllControls().OfType<CrystalReportViewer>())
            {
                if (!viewer.IsDisposed)
                {
                    if (viewer.ReportSource is ReportDocument report)
                    {
                        report.Close();
                        report.Dispose();
                        viewer.ReportSource = null;
                    } 
                }
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == UI.WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                UI.ReleaseCapture();
                UI.SendMessage(Handle, UI.WM_NCLBUTTONDOWN, UI.HT_CAPTION, 0);
                return true;
            }
            return false;
        }


        private const int CS_DROPSHADOW = 0x20000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.Style |= CS_DROPSHADOW;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

     

        protected override void WndProc(ref Message m)
        {
            //const int RESIZE_HANDLE_SIZE = 10;

            //switch (m.Msg)
            //{
            //    case 0x0084/*NCHITTEST*/ :
            //        base.WndProc(ref m);

            //        if ((int)m.Result == 0x01/*HTCLIENT*/)
            //        {
            //            Point screenPoint = new Point(m.LParam.ToInt32());
            //            Point clientPoint = PointToClient(screenPoint);
            //            if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
            //            {
            //                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
            //                    m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
            //                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
            //                    m.Result = (IntPtr)12/*HTTOP*/ ;
            //                else
            //                    m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
            //            }
            //            else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
            //            {
            //                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
            //                    m.Result = (IntPtr)10/*HTLEFT*/ ;
            //                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
            //                    m.Result = (IntPtr)2/*HTCAPTION*/ ;
            //                else
            //                    m.Result = (IntPtr)11/*HTRIGHT*/ ;
            //            }
            //            else
            //            {
            //                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
            //                    m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
            //                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
            //                    m.Result = (IntPtr)15/*HTBOTTOM*/ ;
            //                else
            //                    m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
            //            }
            //        }
            //        return;
            //}
            base.WndProc(ref m);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                MaximizedBounds = new Rectangle(new Point(0, 0), Screen.FromControl(this).WorkingArea.Size);
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (_lblTITLE.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        _lblTITLE.Text = value;
                        base.Text = value;
                    }));
                }
                else
                {
                    _lblTITLE.Text = value;
                    base.Text = value;
                }
            }
        }

        public bool Executing { get; set; }

        private void container_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(container.ClientRectangle.X, container.ClientRectangle.Y - 1, container.ClientRectangle.Width, container.ClientRectangle.Height + 1);
            //rect = container.ClientRectangle;
            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
        }

        private void container_Resize(object sender, EventArgs e)
        {
            //Invalidate();
            //this.Refresh();
        }

        private void HDialog_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                _bMaximize.Image = Properties.Resources.minimize;
            }
            else
            {
                _bMaximize.Image = Properties.Resources.maximize;
            }
            Invalidate();
            Refresh();
        }

        public virtual void PreExecute(bool block = false)
        {
            if (block)
            {
                _bClose.Enabled =
                container.Enabled = false;
            }
            bar.Value = bar.Maximum - 1;
            bar.Visible = true;
            Text = Text.Replace($" {EDomain.Resources.Processing}", "") + $" {EDomain.Resources.Processing}";
        }

        public virtual void PostExecute(bool block = false)
        {
            if (block)
            {
                _bClose.Enabled =
                container.Enabled = true;
            }

            bar.Value = bar.Maximum;
            bar.Visible = false;
            Text = Text.Replace($" {EDomain.Resources.Processing}", "");
            container.Invalidate();

        }
         
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this is IDialog dialog)
            {

                if (keyData == Conts.DialogKey[DialogProcess.Save])
                {
                    var btnOk = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.OK)}");
                    var btnSave = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Save)}");
                    if (btnSave?.Visible == true
                        && btnSave?.Enabled == true
                        && btnSave?.Executing == false)
                    {
                        dialog.Save();
                        return true;
                    }
                    else if (btnOk?.Visible == true
                        && btnOk?.Enabled == true
                        && btnOk?.Executing == false)
                    {
                        dialog.Save();
                        return true;
                    }
                }
                else if (keyData == Conts.DialogKey[DialogProcess.ViewChangeLog])
                {
                    var btnChangeLog = this.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.ChangeLog)}");
                    if (btnChangeLog?.Visible == true 
                        && btnChangeLog?.Enabled == true
                        && btnChangeLog?.Executing==false)
                    {
                        dialog.ViewChangeLog();
                        return true;
                    }

                }
                else if (keyData == Conts.DialogKey[DialogProcess.Close])
                {
                    var btnClose = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Close)}");
                    if (btnClose?.Visible == true 
                        && btnClose?.Enabled == true
                        && btnClose?.Executing == false)
                    {
                        this.Close();
                        return true;
                    }
                }
            }
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
                        && btnUpdate?.Executing == false)
                    {
                        page.Edit();
                        return true;
                    }
                }
                else if (keyData == Conts.PageKey[GeneralProcess.View])
                {
                    var btnUpdate = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Update)}");
                    if (btnUpdate?.Visible == true
                        && btnUpdate?.Enabled == true
                        && btnUpdate?.Executing == false)
                    {
                        page.View();
                        return true;
                    }
                }
                else if (keyData == Conts.PageKey[GeneralProcess.Remove])
                {
                    var btnRemove = this.GetAllControls().OfType<ExButtonLoading>()
                   .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Remove)}");
                    if (btnRemove?.Visible == true
                        && btnRemove?.Enabled == true
                        && btnRemove?.Executing == false)
                    {
                        page.Remove();
                        return true;
                    }
                }
                else if (keyData == Conts.PaginationKey[Pagination.Next])
                {
                    var pagination = this.GetAllControls().OfType<ExPaging>()
                        .FirstOrDefault();
                    if (pagination != null)
                    {
                        pagination.NextPage();
                    }
                    return true;
                }
                else if (keyData == Conts.PaginationKey[Pagination.Previous])
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
         
    }

    internal class CotrolDialogButton : Button
    {
        public CotrolDialogButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
