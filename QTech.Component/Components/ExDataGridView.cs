using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using EasyServer.Domain.SearchModels;
using EasyServer.Domain.Helpers;
using QTech.Component.Properties;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExDataGridView: DataGridView,IAsyncTask
   {
        public bool Executing { get; set; }
        public bool AllowEnterToNextCell { get; set; } = false;

        private bool _allowRowNumber = false;
        [Browsable(false)]
        public bool AllowRowNumber
        {
            get
            {
                return _allowRowNumber;
            }
            set
            {
                _allowRowNumber = value;
                this.AllowRowNumber(_allowRowNumber);
            }
        }
        private bool _allowRowNotFound = true;
        [Browsable(true)]
        public bool AllowRowNotFound {
            get { return _allowRowNotFound; }
            set
            {
                _allowRowNotFound = value;
                this.AllowRowNotFound(_allowRowNotFound);
            }
        }

        [Browsable(false)]
        public Paging Paging { get; set; }

        public ExDataGridView()
        {
            this.ApplyDefaultStyle();
            ReadOnly = true;
            EnableHeadersVisualStyles = false;
#if DEBUG
            KeyDown += new KeyEventHandler(ExDataGridView_KeyDown);
#endif
            CellDoubleClick += new DataGridViewCellEventHandler(ExDataGridView_CellDoubleClick);
            Sorted += new EventHandler(ExDataGridView_Sorted);
            DataError += ExDataGridView_DataError;
            DataSourceChanged += new EventHandler(ExDataGridView_DataSourceChanged);
            panel.Controls.Add(picLoading);
            Controls.Add(panel);
            panel.Paint += Panel_Paint;
            CellFormatting += exDataGridView_CellFormatting;
            //LostFocus += ExDataGridView_LostFocus;
            //Leave += ExDataGridView_LostFocus;

            BackgroundColor = Color.FromArgb(245, 245, 237);
            ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            EnableHeadersVisualStyles = false;
        }

        private void exDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cell = this[e.ColumnIndex, e.RowIndex];
            
            if (cell.Value!=null)
            {
                
                if (cell.OwningColumn.CellType == typeof(DataGridViewImageCell))
                {
                    if (string.IsNullOrEmpty(cell.ToolTipText))
                    {
                        cell.ToolTipText = Columns[e.ColumnIndex].ToolTipText;
                        return;
                    }
                    return;
                }
                var hederText = cell.OwningColumn.HeaderText;
                var conten =  string.Format($"{{0:{e.CellStyle.Format}}}", e.Value);
                if (e.DesiredType == typeof(DateTime))
                {
                    conten = string.Format("{0:D}", e.Value);
                } 
                cell.ToolTipText = string.IsNullOrEmpty(hederText) ? conten : $"{hederText}: {conten}";
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //DrawBackground(e.Graphics, picThin.ClientSize);

            // Make the smiley path.
            using (GraphicsPath path = graphicsPath(picLoading.DisplayRectangle, 5))
            {
                // Draw the shadow.
                e.Graphics.TranslateTransform(2, 2);
                //Color color = Color.FromArgb(64, 0, 0, 0);
                var color = Color.FromArgb(234, 234, 234);
                using (Pen thick_pen = new Pen(color, 4))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
                e.Graphics.ResetTransform();
            }
        }
        private GraphicsPath graphicsPath(Rectangle bounds, int radius)
        {
            bounds.Location = new Point(bounds.Location.X + 4, bounds.Location.Y + 4);
            bounds.Size = new Size(bounds.Size.Width - 1, bounds.Size.Height - 1);

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            GraphicsPath path = new GraphicsPath();
            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        } 

        private void ExDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // intentionally blank.
            e.ThrowException = false;
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    // overides ProcessDataGridViewKey &  ProcessDialogKey work more smoothly than ProcessCmdKey
        //    // But work with ExDropDownColumn work more functional with Process CmdKey.
        //    if (AllowEnterToNextCell)
        //    {
        //        if (keyData == Keys.Enter)
        //        {
        //            //SendKeys.Send("{up}");
        //            //SendKeys.Send("{tab}");
        //            var currentCell = this.CurrentCell;
        //            this.MoveToNextEditableColumn(currentCell.ColumnIndex, currentCell.RowIndex);
        //            return false;
        //        }
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
       

        void ExDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            MarkDefaultColor();
        }

        void ExDataGridView_Sorted(object sender, EventArgs e)
        {
            MarkDefaultColor();
        }

        public void MarkDefaultColor()
        {
            var cells = Rows.OfType<DataGridViewRow>()
                .SelectMany(x => x.Cells.OfType<DataGridViewCell>())
                .Where(x => x.ValueType == typeof(decimal)
                    && x.Value != null
                    && Parse.ToDecimal(x.Value.ToString()) < 0);
            foreach (var cell in cells)
            {
                cell.Style.ForeColor = Color.Red;
                cell.Style.SelectionForeColor = Color.Red;
            }
        }

        void ExDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && SelectedRows.Count>0)
            {
                if (Parent is IPage parent)
                {
                    parent.View();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Font = new Font("Khmer OS Siemreap", 8);

        }

        void ExDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (Parent is IPage parent)
            {
                if (e.KeyCode == Keys.A)
                {
                    var btnAdd = this.FindForm()?.GetAllControls().OfType<ExButtonLoading>()
                    .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Add)}");
                    if (btnAdd?.Visible == true
                        && btnAdd?.Enabled == true
                        && btnAdd?.Executing == false)
                    {
                        parent.AddNew();
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    var btnRemove = this.FindForm()?.GetAllControls().OfType<ExButtonLoading>()
                     .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Remove)}");
                    if (btnRemove?.Visible == true
                        && btnRemove?.Enabled == true
                        && btnRemove?.Executing == false)
                    {
                        parent.Remove();
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    var btnUpdate = this.FindForm()?.GetAllControls().OfType<ExButtonLoading>()
                      .FirstOrDefault(x => x.Name == $"btn{nameof(EDomain.Resources.Update)}");
                    if (btnUpdate?.Visible == true
                        && btnUpdate?.Enabled == true
                        && btnUpdate?.Executing == false)
                    {
                        parent.EditAsync();
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    parent.View();
                    //var btnUpdate = this.FindForm()?.GetAllControls().OfType<ExButtonLoading>()
                    //  .FirstOrDefault(x => x.Name == $"btn{nameof(Resources.Update)}");
                    //if (btnUpdate?.Visible == true
                    //    && btnUpdate?.Enabled == true
                    //    && btnUpdate?.Executing == false)
                    //{
                    //    e.Handled = true;
                    //    parent.View();
                    //}
                }
            }
        }

        Panel panel = new Panel()
        {
            BackColor = Color.Transparent,
            Size = new Size(110, 110),
            Padding = new Padding(5),
            Visible = false,
        };

        PictureBox picLoading = new PictureBox()
        {
            Enabled = true,
            Image = Properties.Resources.point_loading,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Visible = true,
            Dock = DockStyle.Fill
        };

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            panel.Location = new Point(this.Width / 2 - panel.Width / 2, this.Height / 2 - panel.Height / 2);
        }

        public void PreExecute(bool block = false)
        {
            if (block)
            {
                foreach (var row in Rows.OfType<DataGridViewRow>())
                {
                    row.ReadOnly = true;
                }
            }
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x,y);
            panel.Enabled = true;
            panel.Visible = true;
        }

        public void PostExecute(bool block = false)
        {
            if (block)
            {
                foreach (var row in Rows.OfType<DataGridViewRow>())
                {
                    row.ReadOnly = false;
                }
            }
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            panel.Enabled = false;
            panel.Visible = false; 
        }
    }
}
