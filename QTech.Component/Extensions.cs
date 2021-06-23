using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Text;
using System.Data;
using QRCoder;
using System.Threading;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using Newtonsoft.Json;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using System.Net;
using QTech.Component.Interfaces;
using QTech.Component.Helpers;
using QTech.Component.Properties;
using EDomain = EasyServer.Domain;
using EasyServer.Domain.Helpers;
using Easy.Domain.Helpers;
using EasyServer.Domain.Models;
using QTech.Base.Helpers;

namespace QTech.Component
{
    public static class DataGridViewExt
    {
        /// <summary>
        /// Move cursor to next editable column, 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="outFromColumnIndex">Is the current column index on Data Gridview</param>
        public static void MoveToNextEditableColumn(this DataGridView dgv, int outFromColumnIndex, int currentRowIndex = 0)
        {
            DebounceDispatcher debounce = new DebounceDispatcher();
            if (currentRowIndex == 0)
            {
                currentRowIndex = dgv.CurrentRow.Index;
            }
            var cur = dgv.Columns[dgv.CurrentCell.ColumnIndex];
            if (cur.Name != DGV_ROW_NUMBER_COLUMN/*"__row_number__"*/)
            {
                if (dgv.CurrentCell != null)
                {
                    var curCol = dgv.Columns[outFromColumnIndex];
                    if (curCol != null)
                    {
                        debounce.Debounce(100, p =>
                        {
                            var nextCol = dgv.Columns.Cast<DataGridViewColumn>()
                            .Where(x => x.Visible && x.Name != curCol.Name && x.ReadOnly == false && x.Index > outFromColumnIndex)
                            .OrderBy(x => x.Index).FirstOrDefault();

                            if (nextCol != null)
                            {
                                dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[nextCol.Index];
                                dgv.BeginEdit(true);
                            }
                        });
                    }
                }
            }
        }
        /// <summary>
        /// Converts an IEnumerable type collection into a DataTable
        /// </summary>
        /// <param name=”collection”>Collection type that implements IEnumberable</param>
        /// <returns>Datatable representing IEnumerable collection</returns>
        public static DataTable _ToDataTable<T>(this IEnumerable<T> collection, bool canReadWrite = true)
        {
            // Create DataTable to Fill
            DataTable _newDataTable = new DataTable();
            
            // Retrieve the Type passed into the Method
            Type _impliedType = typeof(T);

            var _propInfo = _impliedType.GetProperties().ToList();
            if (canReadWrite)
            {
                _propInfo = _impliedType.GetProperties().Where(x => x.CanRead).ToList();
            }
            
            //Create the columns in the DataTable
            foreach (PropertyInfo pi in _propInfo)
            {
                _newDataTable.Columns.Add(pi.Name, pi.PropertyType);
            }

            if (collection != null)
            {
                //Populate the table
                foreach (T item in collection)
                {
                    DataRow _newDataRow = _newDataTable.NewRow();
                    _newDataRow.BeginEdit();

                    foreach (PropertyInfo pi in _propInfo)
                    {
                        var value = pi.GetValue(item, null);
                        _newDataRow[pi.Name] = value;
                    }

                    _newDataRow.EndEdit();
                    _newDataTable.Rows.Add(_newDataRow);
                }
            }

            return _newDataTable;
        }

        public static void ApplyDefaultStyle(this DataGridView dgv, bool applyrow = true, bool applyNotify = true)
        {
            dgv.RowHeadersVisible =
                 dgv.AllowUserToAddRows =
                 dgv.AllowUserToDeleteRows =
                 dgv.AllowUserToResizeRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.MultiSelect = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.WhiteSmoke };
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeight = 28;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ShowCellToolTips = true;
        }
        public static void ApplyDropdownFocus(this DataGridView dgv, DataGridViewExComboBoxColumn dropDownColumn, DataGridViewColumn focusColumn)
        {
            dgv.CellValueChanged += (object sender, DataGridViewCellEventArgs e) =>
            {
                // To focus next cell after select ExDropDown
                if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex].Name == dropDownColumn.Name)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        //dgv.Parent.Focus();
                        dgv.Focus();
                        dgv.CurrentCell = dgv[focusColumn.Index, e.RowIndex];
                        dgv.CurrentCell.Selected = true;
                    }
                }
            };
        }
        public const string DGV_ROW_NUMBER_COLUMN = "__row_number__";

        public static void AllowRowNumber(this ExDataGridView dgv, bool register)
        {
            var col = DGV_ROW_NUMBER_COLUMN;
            if (register)
            {
                var headers = dgv.Columns.OfType<DataGridViewColumn>().Where(x => x.Tag?.ToString() == col).ToList();
                for (int i = 0; i < headers?.Count; i++)
                {
                    dgv.Columns.Remove(headers[i]);
                }

                var header = new DataGridViewTextBoxColumn
                {
                    Name = col,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    MinimumWidth = 35,
                    Width = 35,
                    HeaderText = "",
                    ReadOnly = true,
                    Tag = col,
                };
                header.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
                dgv.Columns.Insert(0, header);

                /*
                 * Find pagination Controls
                 */
                var pagination = dgv.FindForm().GetAllControls().OfType<ExPaging>().FirstOrDefault();
                if (pagination != null)
                {
                    dgv.Paging = pagination.Paging;
                }
                dgv.DataBindingComplete += dgv_DataBindingComplete;
                //dgv.RowPostPaint += dgv_RowPostPaint;
            }
            else
            {
                var header = dgv.Columns.OfType<DataGridViewColumn>().Where(x => x.Tag?.ToString() == col).ToList();
                for (int i = 0; i < header?.Count; i++)
                {
                    dgv.Columns.Remove(header[i]);
                }
                dgv.Paging = null;
                dgv.DataBindingComplete -= dgv_DataBindingComplete;
                //dgv.RowPostPaint -= dgv_RowPostPaint;
            }
        }

        private static void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != System.ComponentModel.ListChangedType.Reset)
            {
                return;
            }
            var dgv = (ExDataGridView)sender;
            var start = 1;
            //dgv.SuspendLayout();
            if (dgv.Paging != null)
            {
                if (dgv.Paging.IsPaging)
                {
                    start = ((dgv.Paging.CurrentPage - 1) * dgv.Paging.PageSize) + 1;
                }
                
            }
            foreach (var row in dgv.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[DGV_ROW_NUMBER_COLUMN].Value = (row.Index + start).ToString();
            }
            //dgv.ResumeLayout();
            dgv.AutoResizeColumn(0);
        }

        //private static void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{ 
        //    var dgv = sender as ExDataGridView;
        //    var start = 1;
        //    if (dgv.Paging != null)
        //    {
        //        start = ((dgv.Paging.CurrentPage - 1) * dgv.Paging.PageSize) + 1;
        //    } 
        //    dgv.Rows[e.RowIndex].Cells[DGV_ROW_NUMBER_COLUMN].Value = (e.RowIndex + start).ToString();

        //}

        private static void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as ExDataGridView;
            SolidBrush forebrush = null;
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.SelectionForeColor);
            }
            else
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.ForeColor);
            }
            var start = 1;
            if (dgv.Paging != null)
            {
                start = ((dgv.Paging.CurrentPage - 1) * dgv.Paging.PageSize) + 1;
            }
            var rowNo = (e.RowIndex + start).ToString();
            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new RectangleF(e.RowBounds.X, e.RowBounds.Y + 1, 35, e.RowBounds.Height);
            e.Graphics.DrawString(rowNo, e.InheritedRowStyle.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        public static void AllowRowNotFound(this DataGridView dgv,bool register)
        {
            if (register)
            {
                var lbl = new Label()
                {
                    Name = "_ROW_Nótify",
                    AutoSize = false,
                    ForeColor = SystemColors.ControlDark,
                    BackColor = Color.Transparent,
                    Visible = false,
                    Text = EDomain.Resources.MsgRowNotFound,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                if (!dgv.Controls.Contains(lbl))
                {
                    dgv.Controls.Add(lbl);
                }
                dgv.DataSourceChanged += dgv_DataSourceChanged;
            }
            else
            {
                dgv.DataSourceChanged -= dgv_DataSourceChanged;
            } 
        }

        private static void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            var lbl = dgv.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "_ROW_Nótify");
            if (lbl!=null)
            {
                lbl.Size = new Size(dgv.Size.Width, 160);
                lbl.Location = new Point(0, 30);
                lbl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                lbl.Font = dgv.DefaultCellStyle.Font;
                lbl.Visible = dgv.Rows.Count == 0;
                lbl.BringToFront();
            }
        }

        public static void ShowRowNotFound(this DataGridView dgv)
        {
            var lbl = dgv.Controls.OfType<Label>().FirstOrDefault(x => x.Name == "_ROW_Nótify");

            if (lbl==null)
            {
                lbl = new Label()
                {
                    Name = "_ROW_Nótify",
                    AutoSize = false,
                    Size = new Size(dgv.Size.Width, 160),
                    Location = new Point(0, 30),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Font = dgv.DefaultCellStyle.Font,
                    ForeColor = SystemColors.ControlDark,
                    BackColor = Color.Transparent,
                    Visible = false,
                    Text =EDomain.Resources.MsgRowNotFound,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                dgv.Controls.Add(lbl);
            }

            if (lbl != null)
            {
                lbl.Size = new Size(dgv.Size.Width, 160);
                lbl.Location = new Point(0, 30);
                lbl.Visible = dgv.Rows.Count == 0;
                lbl.BringToFront();
            }
        }

        public static void RowSelected(this DataGridView dgv, int index)
        {
            if (index < 0) return;

            dgv.FirstDisplayedScrollingRowIndex = index;
            dgv.Rows[index].Selected = true;
            dgv.CurrentCell = dgv.Rows[index].Cells
                    .OfType<DataGridViewCell>()
                    .FirstOrDefault(x => x.Visible);
        }


        public static void RowSelected(this DataGridView dgv,string cellName, object value)
        {
            if (!dgv.Columns.OfType<DataGridViewColumn>().Any(x=>x.Name == cellName))
            {
                return;
            }
            var row = dgv.Rows.OfType<DataGridViewRow>()
                .FirstOrDefault(x =>x.Cells[cellName].Value?.Equals(value) == true);
            if (row!=null)
            { 
                dgv.FirstDisplayedScrollingRowIndex = row.Index;
                row.Selected = true;
                dgv.CurrentCell = dgv.Rows[row.Index].Cells
                    .OfType<DataGridViewCell>()
                    .FirstOrDefault(x => x.Visible);
            } 
        }

        public static void RowSelected(this TreeGridView dgv, string cellName, object value)
        {
            if (!dgv.Columns.OfType<DataGridViewColumn>().Any(x => x.Name == cellName))
            {
                return;
            }
            var row = dgv.Rows.OfType<DataGridViewRow>()
                .FirstOrDefault(x => x.Cells[cellName].Value?.Equals(value) == true);
            if (row != null)
            {
                dgv.FirstDisplayedScrollingRowIndex = row.Index;
                row.Selected = true;
                dgv.CurrentCell = dgv.Rows[row.Index].Cells
                    .OfType<DataGridViewCell>()
                    .FirstOrDefault(x => x.Visible);
            }
        }

        public static void RowSelected<T>(this DataGridView dgv, T entity)
            where T : EDomain.Models.BaseModel
        {
            // auto detect column 
            // by default use Id
            // if id not fould use colId 
            var columnName = nameof(entity.Id);
            if (!dgv.Columns.OfType<DataGridViewColumn>().Any(x => x.Name == columnName))
            {
                columnName = "colId";
            } 
            dgv.RowSelected(columnName, entity.Id); 
        }

        
        public static void RowSelected<T,Tkey>(this DataGridView dgv,T entity) 
            where T: EDomain.Models.TBaseModel<Tkey>
            where Tkey:struct
        { 
            dgv.RowSelected(nameof(entity.Id), entity.Id);
        }

        public static void Format(this DataGridViewColumn col,string format, DataGridViewContentAlignment alignment= DataGridViewContentAlignment.MiddleLeft)
        {
            col.HeaderCell.Style.Alignment = alignment;
            col.DefaultCellStyle.Format = format;
            col.DefaultCellStyle.Alignment = alignment;
        }
        public static void FormatWith(this DataGridViewColumn col,string format, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft, params DataGridViewColumn[] cols)
        {
            col.Format(format, alignment);
            foreach (var c in cols)
            {
                c.Format(format, alignment);
            }
        }
         
        public static void FormatWith(this DataGridView dgv
            , string format
            , DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft
            , params DataGridViewColumn[] columns)
        {
            foreach (var c in columns)
            {
                dgv.Columns[c.Name].HeaderCell.Style.Alignment = alignment;
                dgv.Columns[c.Name].DefaultCellStyle.Format = format;
                dgv.Columns[c.Name].DefaultCellStyle.Alignment = alignment;
            }
        }

        public static void DisplayColumnsIndex(this DataGridView dgv,params DataGridViewColumn[] cols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                dgv.Columns[cols[i].Name].DisplayIndex = i;
            }             
        }

        public static void EditColumnIcon(this DataGridView dgv, Image editIcon = null, params DataGridViewColumn[] columns)
        {
            if (editIcon ==null)
            {
                editIcon = Properties.Resources.img_pencil;
            }
            
            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);

            foreach (var column in dgv.Columns.OfType<DataGridViewColumn>())
            {
                if (columns.Any(x => x.Name == column.Name))
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }
            }

            dgv.CellPainting += (sender,e)=>
            {
                if (index.Contains(e.ColumnIndex) && e.RowIndex == -1)
                {
                    //var padding = dgv.Columns[e.ColumnIndex].HeaderCell.InheritedStyle.Padding; 
                    //dgv.Columns[e.ColumnIndex].HeaderCell.Style.Padding = new Padding(padding.Left, padding.Top, editIcon.Size.Width, padding.Bottom);
                    
                    e.PaintBackground(e.ClipBounds, false); 
                    var pt = e.CellBounds.Location;  // where you want the bitmap in the cell 
                    pt.X += (e.CellBounds.Width - editIcon.Size.Width) - 4;
                    pt.Y += (e.CellBounds.Height-editIcon.Size.Height)/2+2;
                     
                    e.PaintContent(e.ClipBounds);
                    e.Graphics.DrawImage(editIcon, pt.X,pt.Y,editIcon.Size.Width,editIcon.Size.Height);
                    e.Handled = true;
                }
            };
        }

        public static void ColumnIcon(this DataGridView dgv, Image editIcon, params DataGridViewColumn[] columns)
        {
            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);

            dgv.CellPainting += (sender, e) =>
            {
                if (index.Contains(e.ColumnIndex) && e.RowIndex == -1)
                {
                    //var padding = dgv.Columns[e.ColumnIndex].HeaderCell.InheritedStyle.Padding; 
                    //dgv.Columns[e.ColumnIndex].HeaderCell.Style.Padding = new Padding(padding.Left, padding.Top, editIcon.Size.Width, padding.Bottom);

                    e.PaintBackground(e.ClipBounds, false);
                    var pt = e.CellBounds.Location;  // where you want the bitmap in the cell 
                    pt.X += (e.CellBounds.Width - editIcon.Size.Width) - 4;
                    pt.Y += (e.CellBounds.Height - editIcon.Size.Height) / 2 + 2;

                    e.PaintContent(e.ClipBounds);
                    e.Graphics.DrawImage(editIcon, pt.X, pt.Y, editIcon.Size.Width, editIcon.Size.Height);
                    e.Handled = true;
                }
            };
        }

        public static void EditColumnIcon(this DataGridView dgv, params DataGridViewColumn[] columns)
        {
            dgv.EditColumnIcon(null, columns);
        }

        public static void RemoveEditColumnIcon(this DataGridView dgv, params DataGridViewColumn[] columns)
        {
            var editIcon = Properties.Resources.img_pencil;

            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);

            foreach (var column in dgv.Columns.OfType<DataGridViewColumn>())
            {
                if (columns.Any(x => x.Name == column.Name))
                {
                    column.ReadOnly = false;
                }
            }

            dgv.CellPainting += (sender, e) =>
            {
                if (index.Contains(e.ColumnIndex) && e.RowIndex == -1)
                {
                    //var padding = dgv.Columns[e.ColumnIndex].HeaderCell.InheritedStyle.Padding; 
                    //dgv.Columns[e.ColumnIndex].HeaderCell.Style.Padding = new Padding(padding.Left, padding.Top, editIcon.Size.Width, padding.Bottom);

                    e.PaintBackground(e.ClipBounds, false);
                    var pt = e.CellBounds.Location;  // where you want the bitmap in the cell 
                    pt.X += (e.CellBounds.Width - editIcon.Size.Width) - 4;
                    pt.Y += (e.CellBounds.Height - editIcon.Size.Height) / 2 + 2;

                    e.PaintContent(e.ClipBounds);
                    var col = dgv.Columns.OfType<DataGridViewColumn>().FirstOrDefault(x => x.Index == e.ColumnIndex);
                    e.Graphics.DrawString(string.Empty, 
                        col.InheritedStyle.Font, 
                        new SolidBrush(col.InheritedStyle.ForeColor),
                        pt.X, pt.Y);
                    e.Handled = true;
                }
            };
        }

        public static void ChangeCursor(this DataGridView dgv,Cursor cursor, params DataGridViewColumn[] columns)
        {
            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);
            dgv.CellMouseEnter += (sender, e)=>
            {
                if (index.Contains(e.ColumnIndex) && e.RowIndex != -1)
                {
                    dgv.Cursor = cursor;
                }
            };
            dgv.CellMouseLeave += (sender, e) =>
            {
                if (index.Contains(e.ColumnIndex))
                {
                    dgv.Cursor = Cursors.Default;
                }
            };
        }

        public static void RegisterSortColumns<T>(this DataGridView dgv)
        {
            dgv.ColumnHeaderMouseClick += (s, e) =>
            {
                var col = dgv.Columns[e.ColumnIndex];
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
                var direction = col.HeaderCell.SortGlyphDirection;
                if (direction == SortOrder.None || direction == SortOrder.Descending)
                {
                    direction = SortOrder.Ascending;
                }
                else
                {
                    direction = SortOrder.Descending;
                }
                var propertyName = col.DataPropertyName;
                List<T> source = null;
                try
                {
                    source = (List<T>)dgv.DataSource;
                }
                catch
                {
                    return;
                }
                
                if (source == null)
                {
                    return;
                }
                if (!source.Any())
                {
                    return;
                }
                var property = source.GetType().GetGenericArguments()[0].GetProperty(propertyName);
                if (direction == SortOrder.Ascending)
                {
                    source = source.OrderBy(x => property.GetValue(x, null)).ToList<T>();
                    direction = SortOrder.Ascending;
                }
                else
                {
                    source = source.OrderByDescending(x => property.GetValue(x, null)).ToList<T>();
                    direction = SortOrder.Descending;
                }

                dgv.DataSource = source;
                col.HeaderCell.SortGlyphDirection = direction;
            };
        }

        public static void RegisterDecimalOnly(this DataGridView dgv, DataGridViewColumn column)
        {
            //dgv.EditingControlShowing += (sender, e) =>
            //{
            //    if (dgv.CurrentCell.ColumnIndex == column.Index)
            //    {
            //        e.Control.KeyPress += (s, even) =>
            //        {
            //            if (!char.IsControl(even.KeyChar) && !char.IsDigit(even.KeyChar) && even.KeyChar != '.')
            //            {
            //                even.Handled = true;
            //            }
            //        };
            //    }
            //};
        }
    }

    public static class DataGridViewComboBoxColumnExt
    {
        public static void SetDataSource<T>(this DataGridViewComboBoxColumn cbo, IEnumerable<T> source)
        {
            if (source != null)
            {
                cbo.DataSource = source.ToList();
                PropertyInfo[] pis = typeof(T).GetProperties();
                if (pis.Count() > 0)
                {
                    cbo.ValueMember = pis[0].Name;
                    cbo.DisplayMember = pis.Count() > 1 ? pis[1].Name : pis[0].Name;
                } 
            }
        }

        public static void SetDataSource(this DataGridViewComboBoxColumn cbo, IEnumerable<string> source, string all = "")
        {
            var temp = source.Select(x => new KeyValuePair<string, string>(x, x)).ToList();
            if (!string.IsNullOrEmpty(all))
            {
                temp.Insert(0, new KeyValuePair<string, string>(string.Empty, string.Format(EDomain.Resources.All_, all)));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }

        public static void SetDataSource<T>(this DataGridViewComboBoxColumn cbo, string all = "", params Enum[] ignores) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T is not an Enum type");

            var source = Enum.GetValues(typeof(T))
                .Cast<object>()
                .Where(x => !ignores.Contains(x))
                .Select(k => new KeyValuePair<T?, string>((T)k, ResourceHelper.Translate((Enum)k))).ToList();

            if (!string.IsNullOrEmpty(all))
            {
                source.Insert(0, new KeyValuePair<T?, string>(null, all));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = source;
        }
    }

    public static class UISettingExt
    {
        public static string GetFullName(this TreeGridView tgv)
        {
            return $"{GetLastParent(tgv).Name}.{tgv.Name}";
        }

        public static string GetFullName(this DataGridView dgv)
        {
            return $"{GetLastParent(dgv).Name}.{dgv.Name}";
        }

        public static string GetFullName(this ReportDatePicker dp)
        {
            return $"{GetLastParent(dp)?.Name}.{dp.Name}";
        }

        public static Control GetLastParent(Control child)
        {
            return child.FindForm();
        }

    }

    public static class ControlExt
    {
        public static void IniAdvanceFilter(this Dictionary<string,ComboBox> filters)
        {
            foreach (var item in filters)
            {
                if (CustomAdvanceFilter.LastFilter.ContainsKey(item.Key))
                {
                    if ((item.Value is ExSearchCombo exCombo) &&
                        (CustomAdvanceFilter.LastFilter[item.Key] is ExSearchCombo lastExCombo))
                    {
                        exCombo.SetValue(lastExCombo.SelectedItems);
                    }
                    else if ((item.Value is ComboBox cbo) &&
                        (CustomAdvanceFilter.LastFilter[item.Key] is ComboBox lastCbo))
                    {
                        cbo.SelectedValue = lastCbo.SelectedValue;
                    }
                }

            }
        }
        public static void IniAdvanceFilter(this Dictionary<string, Control> filters)
        {
            return;
            foreach (var item in filters)
            {
                if (CustomAdvanceFilter.LastFilter.ContainsKey(item.Key))
                {
                    if ((item.Value is ExSearchCombo exCbo) &&
                        (CustomAdvanceFilter.LastFilter[item.Key] is ExSearchCombo lastExCombo))
                    {
                        if (!exCbo.IsHandleCreated)
                        {
                            exCbo.CreateControl();
                        } 
                        exCbo.SetValue(lastExCombo.SelectedItems);
                    }
                    else if ((item.Value is ComboBox cbo) &&
                        (CustomAdvanceFilter.LastFilter[item.Key] is ComboBox lastCbo))
                    {
                        if (!cbo.IsHandleCreated)
                        {
                            cbo.CreateControl();
                        }
                        cbo.SelectedValue = lastCbo.SelectedValue;
                    }
                }

            }
        }


        public static IEnumerable<Control> GetAllControls(this Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in control.GetAllControls())
                {
                    yield return descendant;
                }
            }
        }
        public static void SetEnabled(this ExDialog diag, bool enable)
        {
            SetEnabled(diag.container, enable); 
        }
        public static void SetEnabled(this Control panel, bool enabled)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.ReadOnly = !enabled;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.ReadOnly = !enabled;
                }
                else if (c is ComboBox ||
                   c is DateTimePicker || 
                   c is ExTextbox​ ||
                  // c is ExAddressPicker ||
                   c is CheckBox ||
                   //c is ExPointPicker ||
                   c is ExSearchCombo ||
                   //c is ExProfilePicture ||
                   //c is ExFile ||
                   c is LinkLabel ||
                   c is ExTextboxSearch ||
                  // c is ReportDatePicker ||
                   c is ExTextboxPattern)
                {
                    c.Enabled = enabled;
                }
                else
                {
                    if (c.Controls.Count > 0)
                    {
                        SetEnabled(c, enabled);
                    }
                }
            }
        }
        public static void DefaultEnglishInputControls(this Control panel)
        {
            var allControls = panel.GetAllControls();
            foreach (var ctrl in allControls)
            {
                if (ctrl is DateTimePicker)
                {
                    ctrl.RegisterEnglishInput();
                }
            }
        }
        public static void RegisterPrimaryInput(this Control control)
        {
            control.Enter += (object send, EventArgs e) =>
            {
                InputLanguage.CurrentInputLanguage = UI.Primary;
                if (control is TextBox txt)
                {
                    if (!txt.Multiline)
                    {
                        txt.SelectAll();
                    }
                }
            };
        }
        public static void RegisterPrimaryInputWith(this Control control,params Control[] controls)
        {
            control.RegisterPrimaryInput();
            foreach (var ctl in controls)
            {
                ctl.RegisterPrimaryInput();
            }
        }
        public static void RegisterEnglishInput(this Control control)
        {
            control.Enter += (object send, EventArgs e) =>
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                if (control is TextBox txt)
                {
                    txt.SelectAll();
                }
            };
        }
        public static void RegisterEnglishInputWith(this Control control,params Control[] controls)
        {
            control.RegisterEnglishInput();
            foreach (var ctl in controls)
            {
                ctl.RegisterEnglishInput();
            }
        }
        public static void RegisterEnglishInputColumns(this DataGridView dgv, params DataGridViewColumn[] columns)
        {
            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);
            dgv.CellBeginEdit += (s, e) =>
            {
                if (index.Contains(e.ColumnIndex))
                {
                    InputLanguage.CurrentInputLanguage = UI.English;
                }
            };
        }
        public static void RegisterPrimaryInputColumns(this DataGridView dgv, params DataGridViewColumn[] columns)
        {
            var index = dgv.Columns.OfType<DataGridViewColumn>()
                .Where(x => columns.Any(c => c.Name == x.Name))
                .Select(x => x.Index);
            dgv.CellBeginEdit += (s, e) =>
            {
                if (index.Contains(e.ColumnIndex))
                {
                    InputLanguage.CurrentInputLanguage = UI.Primary;
                }
            };
        }
        public static void RegisterKeyEnterNextControl(this Control control)
        { 
            control.KeyDown += (object sender, KeyEventArgs e)=>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        return;
                    }

                    if (control is TextBox txt)
                    {
                        if (txt.Multiline)
                        {
                            e.SuppressKeyPress = true;
                        } 
                    }
                    control.Parent.SelectNextControl(control, true, true, true, true);
                }
            };
        }
        public static void RegisterKeyEnterNextControlWith(this Control control,params Control[] controls)
        {
            control.RegisterKeyEnterNextControl();
            foreach (var ctl in controls)
            {
                ctl.RegisterKeyEnterNextControl();
            }
        }

        public static void RegisterKeyArrowDown(this Control control, Control nextControl)
        {
            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    nextControl.Focus();
                }
            };
            nextControl.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (sender is DataGridView dgv) 
                    {
                        if (dgv.SelectedRows.Count ==0)
                        {
                            return;
                        }

                        if(dgv.SelectedRows[0].Index ==0)
                        {
                            control.Focus();
                        } 
                    }
                } 
            };
        }
        public static string GetTextDialog(this GeneralProcess flag, string dialogText)
        {
            switch (flag)
            {
                case GeneralProcess.Add:
                    return string.Format(EDomain.Resources.Add_, dialogText);
                case GeneralProcess.Update:
                    return string.Format(EDomain.Resources.Form_Operation_, dialogText, EDomain.Resources.Edit);
                case GeneralProcess.Remove:
                    return string.Format(EDomain.Resources.Form_Operation_, dialogText, EDomain.Resources.Remove);
                case GeneralProcess.View:
                    return string.Format(EDomain.Resources.Form_Operation_, dialogText, EDomain.Resources.View);
                case GeneralProcess.Copy:
                    return string.Format(EDomain.Resources.Form_Operation_, dialogText, EDomain.Resources.Copy);
                default:
                    return dialogText;
            }
        }

        public static void RegisterInputPhone(this Control control)
        {
            control.KeyPress += (sender, e) =>
            {
                if (Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
                {
                    e.Handled = true;
                }
                else if (!char.IsControl(e.KeyChar) 
                    && !char.IsDigit(e.KeyChar) 
                    && e.KeyChar.ToString() != "/" 
                    && e.KeyChar.ToString() != "+" 
                    && e.KeyChar.ToString() != "-"
                    && e.KeyChar.ToString() != " ")
                {
                    e.Handled = true;
                }
            };
        }

        public static void RegisterInputNumberOnly(this Control control, bool useAbbreviation = true)
        {
            control.KeyPress += (s, e) =>
            {
                if (Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
                {
                    e.Handled = true;
                }
                else if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar.ToString().ToUpper() != "K"
                    && e.KeyChar.ToString().ToUpper() != "M")
                {
                    e.Handled = true;
                }
            };
            if (useAbbreviation)
            {
                control.TextChanged += (s, e) => control.Text = control.Text.ToUpper().Replace("K", "000").Replace("M", "000000");
            }
        }

        public static void RegisterInputNumberOnlyWith(this Control control, params Control[] controls)
        {
            control.RegisterInputNumberOnly();
            foreach (Control ctl in controls)
            {
                ctl.RegisterInputNumberOnly();
            }
        }

        public static void InputDecimalOnly(this Control control)
        {
            control.KeyPress += (s, e) =>
            {
                if (Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '.' && control.Text.Contains("."))
                {
                    // Stop more than one dot Char
                    e.Handled = true;
                }
                else if (e.KeyChar == '.' && control.Text.Length == 0)
                {
                    // Stop first char as a dot input
                    e.Handled = true;
                }
                else if(e.KeyChar == '-' && control.Text.Contains("-"))
                {
                    // Stop first char as negative
                    e.Handled = true;
                }
                else if (!char.IsControl(e.KeyChar) &&
                        !char.IsDigit(e.KeyChar) &&
                        e.KeyChar != '.' &&
                        e.KeyChar != '-')
                {
                    // Stop allow other than digit and control
                    e.Handled = true;
                }
                //else if (!char.IsControl(e.KeyChar) && 
                //        !char.IsDigit(e.KeyChar) && 
                //        e.KeyChar != '.' &&
                //        e.KeyChar != '-' &&
                //        e.KeyChar.ToString().ToUpper() != "K" && 
                //        e.KeyChar.ToString().ToUpper() != "M")
                //{
                //    // Stop allow other than digit and control
                //    e.Handled = true;
                //}
            };
        }

        public static void RegisterDecimalSeparater(this TextBox control)
        {
            control.MaxLength = 30;
            control.InputDecimalOnly();
            var byUser = false;
            var seletionStart = 0;
            control.KeyDown += (s, e) =>
            {
                seletionStart = control.TextLength - control.SelectionStart;
                if (e.KeyCode == Keys.Delete)
                {
                    seletionStart--;
                }
                if(control.SelectionLength > 0)
                {
                    seletionStart -= control.SelectionLength;
                    //seletionStart -= control.Text.Count(x => x == ',');
                }
                var dotIndex = control.Text.IndexOf(".");
                try
                {
                    if (e.KeyCode == Keys.Back && control.SelectionStart < control.TextLength - 1
                        && control.Text[control.SelectionStart - 1] == ',')
                    {
                        seletionStart++;
                    }
                }
                catch (Exception) { }
                byUser = !(e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal || dotIndex > seletionStart);
            };
            control.TextChanged += (s, e) =>
            {
                if (control.Text.StartsWith(","))
                {
                    control.Text = control.Text.Replace(",", "");
                }
                if (control.Text.ToUpper().Contains("M") || control.Text.ToUpper().Contains("K"))
                {
                    control.Text = control.Text.ToUpper().Replace("K", "000").Replace("M", "000000");
                }
                if (byUser)
                {
                    byUser = false;
                    if(control.Text == "-0" || control.Text == "0-")
                    {
                        control.Text = "-";
                    }

                    if(control.Text != "-")
                    {
                        var value = Parse.ToDecimal(control.Text);
                        control.Text = value.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N7]);
                    }
                }
                try
                {
                    control.SelectionStart = control.TextLength - seletionStart;
                }
                catch (Exception){}
            };
        }


        //public static void RegisterInputDecimal(this Control control)
        //{
        //    if (control is TextBox txt)
        //    {
        //        control.RegisterEnglishInput();
        //        control.InputDecimalOnly();
        //        var lenght = 0;
        //        txt.KeyDown += (s, e) => lenght = txt.TextLength - txt.SelectionStart;
        //        txt.TextChanged += (sender, e) =>
        //        {
        //            try
        //            {
        //                if (txt.Text.ToUpper().Contains("M") || txt.Text.ToUpper().Contains("K") || txt.Text.Length > 3)
        //                {
        //                    var containDot = txt.Text.Contains(".");
        //                    var charAfterDot = "";
        //                    var fullStopIndex = txt.Text.IndexOf(".");
        //                    var cusorIndex = txt.SelectionStart;
        //                    var splittedString = txt.Text.Split('.');
        //                    if (containDot)
        //                    {
        //                        if (cusorIndex > fullStopIndex)
        //                        {
        //                            charAfterDot = splittedString[splittedString.Length - 1];
        //                        }
        //                    }
        //                    var d = Convert.ToDouble(txt.Text.ToUpper().Replace(",", "").Replace("M", "000000").Replace("K", "000"));
        //                    txt.Text = (!containDot && !txt.Text.EndsWith("0")) ?
        //                        d.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N7]) :
        //                        d.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N]) + (containDot ? $".{charAfterDot}" : "");
        //                    txt.SelectionStart = (txt.TextLength - lenght);
        //                }
        //            }
        //            catch (Exception) { }
        //        };
        //    }
        //}

        public static void RegisterDecimalSeparaterWith(this TextBox control, params TextBox[] controls)
        {
            control.RegisterDecimalSeparater();
            foreach(TextBox ctrl in controls)
            {
                ctrl.RegisterDecimalSeparater();
            }
        }

        public static void ProtectNumericValueWith(this NumericUpDown numeric, params NumericUpDown[] numerics)
        {
            numeric.ProtectNumericValue();
            foreach(NumericUpDown upDown in numerics)
            {
                upDown.ProtectNumericValue();
            }
        }
        public static void ProtectNumericValue(this NumericUpDown numeric)
        {
            //DebounceDispatcher debounce = new DebounceDispatcher();
            //numeric.KeyDown += (s, e) =>
            //{
            //    debounce.Debounce(100, p =>
            //    {
            //        if (numeric.Value > numeric.Maximum)
            //        {
            //            numeric.Value = numeric.Maximum;
            //            numeric.Select(numeric.Value.ToString().Length, 0);
            //            return;
            //        }
            //        else if (numeric.Value < numeric.Minimum)
            //        {
            //            numeric.Value = numeric.Minimum;
            //            return;
            //        }
            //    });
            //};
        }
    }

    public static class DateTimePickerExt
    {
        public static void CustomFormat(this DateTimePicker dtp, string format)
        {
            dtp.CustomFormat = format;
            dtp.Format = DateTimePickerFormat.Custom;
        }
        public static void CustomFormatWith(this DateTimePicker dtp, string format, params DateTimePicker[] dtps)
        {
            dtp.CustomFormat(format);
            foreach (var item in dtps)
            {
                item.CustomFormat(format);
            }
        } 
        /// <summary>
        /// Set the value to datetime picker to blank
        /// </summary>
        public static void ClearValue(this DateTimePicker dtp, DateTime noneValue, string noneValueMessage = "")
        { 
            dtp.Value = noneValue;
            dtp.CustomFormat((string.IsNullOrEmpty(noneValueMessage)) ? 
                FormatHelper.DateTime[FormatHelper.DateTimeType.None] : noneValueMessage);
            dtp.Checked = false;
        }
        
        /// <summary>
        /// Set value to DateTimePicker with none format value.
        /// </summary>
        /// <param name="dtp">DateTimePicker Control</param>
        /// <param name="datDate">Value set to Control</param>
        /// <param name="noneValue">Value to clear format display of DateTimePicker</param>
        /// <param name="format">Custom date/time format string.</param>
        public static void SetValue(this DateTimePicker dtp, DateTime datDate,DateTime noneValue, string format = "", string noneValueMessage = "")
        {
            if (datDate.Date.Equals(noneValue))
            {
                dtp.ClearValue(noneValue, noneValueMessage);
            }
            else
            {
                dtp.Value = datDate;
                // Set defualt format.
                if (string.IsNullOrEmpty(dtp.CustomFormat) ||
                    dtp.CustomFormat==FormatHelper.DateTime[FormatHelper.DateTimeType.None] ||
                    dtp.CustomFormat == noneValueMessage)
                {
                    dtp.CustomFormat = FormatHelper.CurrentCulture.DateTimeFormat.ShortDatePattern;
                }
                // Apply defualt format if not set.
                if (string.IsNullOrEmpty(format))
                {
                    format = dtp.CustomFormat;
                } 
                dtp.CustomFormat(format);
                dtp.Checked = true;
                dtp.Value = datDate;
            }
        }
        public static void RegisterChangeValue(this DateTimePicker dtp, DateTime value,DateTime noneValue ,string format = "", string noneValueMessage = "", bool showCheckBox = true)
        {
            dtp.ShowCheckBox = showCheckBox;
            dtp.SetValue(dtp.Value, noneValue, format, noneValueMessage);
            bool isChanging = false;
            bool isFirst = true;
            dtp.ValueChanged += ( sender, e) =>
            {

                var dtpValue = dtp.Value;
                if (!dtp.Checked)
                {
                    dtpValue = noneValue;
                }
                else if (dtp.Checked && dtpValue.Date.Equals(noneValue))
                {
                    dtpValue = value;
                }
                if (isChanging)
                {
                    isChanging = false; 
                    // Capture value change.
                    if (!dtpValue.Equals(noneValue))
                    {
                        value = dtpValue;
                    }
                    dtp.SetValue(dtpValue, noneValue, format, noneValueMessage);
                    isChanging = true;
                }
                if (isFirst)
                {
                    dtp.SetValue(dtp.Value, noneValue, format, noneValueMessage);
                    isFirst = false;
                    isChanging = true;
                }
            };
            
        }
        
        public static string GetPrettyDate(this DateTime postDate)
        {
            if (postDate<= Consts.MIN_DATE)
            {
                return string.Empty;
            }
             
            TimeSpan diff = DateTime.Now.Subtract(postDate);
            double days = diff.Days;
            double hours = diff.Hours + days * 24;
            double minutes = diff.Minutes + hours * 60;
            if (minutes <= 1)
            {
                return EDomain.Resources.JustNow;
            } 
            //double years = Math.Floor(diff.TotalDays / 365);
            //if (years >= 1)
            //{
            //    return string.Format(Resources.XYAgo, years, Resources.Year);
            //}

            //double months = Math.Floor(diff.TotalDays / 30);
            //if(months>=1)
            //{
            //    return string.Format(Resources.XYAgo, months, Resources.Month);
            //}

            //double weeks = Math.Floor(diff.TotalDays / 7);
            //if (weeks >= 1)
            //{
            //    return string.Format(Resources.XYAgo, weeks, Resources.Week);
            //}
            if (days >= 1)
            {
                return postDate.ToShortDateString();
            }
            if (hours >= 1)
            {
                return string.Format(EDomain.Resources.XYAgo, hours, EDomain.Resources.Hour);
            }

            // Only condition left is minutes > 1
            return string.Format(EDomain.Resources.XYAgo, minutes, EDomain.Resources.Minute);
        }
    }

    public static class IAsyncTaskExt
    {
        public static async Task<TResult> RunAsync<TResult>(this IAsyncTask task, Func<TResult> action, bool blockUI = false, bool throwException = false, CancellationTokenSource source =null,   params IAsyncTask[] joiner)
        {
            var type = typeof(TResult);
            try
            {
                task.PreExecute(blockUI);
                task.Executing = true;
                foreach (var j in joiner)
                {
                    j.PreExecute(blockUI);
                    j.Executing = true;
                }
                if (source!=null)
                {
                    var result = await Task.Run(() =>
                    {
                        var r = action();
                        return r;
                    }, source.Token);
                    task.PostExecute(blockUI);
                    task.Executing = false;
                    foreach (var j in joiner)
                    {
                        j.PostExecute(blockUI);
                        j.Executing = false;
                    }

                    return result;
                }
                else
                {
                    var result = await Task.Run(() =>
                    {
                        var r = action();
                        return r;
                    });
                    task.PostExecute(blockUI);
                    task.Executing = false;
                    foreach (var j in joiner)
                    {
                        j.PostExecute(blockUI);
                        j.Executing = false;
                    } 
                    return result;
                } 
            }
            catch (Exception exp)
            {
                // exception thrown
                if (throwException)
                {
                    task.PostExecute(blockUI);
                    task.Executing = false;
                    foreach (var j in joiner)
                    {
                        j.PostExecute(blockUI);
                        j.Executing = false;
                    }
                    throw exp;
                }
                // message will display if exception is not thron 
                task.PostExecute(blockUI);
                task.Executing = false;
                //
                foreach (var j in joiner)
                {
                    j.PostExecute(blockUI);
                    j.Executing = false;
                }
                string title = string.Empty;
                if (task is ExDialog dig)
                {
                    title = dig.Text;
                }
                else if (task is Control ctr)
                {
                    title = ctr.FindForm()?.Text ?? string.Empty;
                } 
                MsgBox.ShowError(exp, title);

                if (type.GetInterfaces().Any(x => x == typeof(IList)))
                {
                    return (TResult)Activator.CreateInstance(typeof(TResult));
                }
                else
                {
                    return default;
                }
            }
        }
    }

    public static class FormExt
    {
        public static void InitForm(this Form frm, int delay = 20)
        {
            frm.Opacity = 0;
            var timer = new System.Windows.Forms.Timer() { Interval = delay };
            timer.Start();
            timer.Tick += (object sender, EventArgs e) =>
            {
                frm.Opacity = 100;
                timer.Stop();
                timer.Dispose();
            };
        }

        public static void OptimizeLoadUI(this Form frm, int delay = 20)
        {
            var _lastWindowsState = frm.WindowState;
            frm.Shown += (sender, e) =>
            {
                frm.ClientSizeChanged += (s, ee) =>
                {
                    if (_lastWindowsState == FormWindowState.Normal)
                    {
                        _lastWindowsState = frm.WindowState;
                        return;
                    }
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.Opacity = 0;
                    }
                    else if (frm.WindowState == FormWindowState.Maximized)
                    {
                        //System.Diagnostics.Debug.WriteLine($"InitForm {DateTime.Now.ToLongTimeString()}");
                        frm.InitForm(delay);
                    }
                    _lastWindowsState = frm.WindowState;
                };
            };
        }
        public static void ApplyResource(this Control control)
        {
            ResourceHelper.ApplyResource(control); 
        }

        public static void ChangeInput(this Form frm, InputLanguage inputType)
        {
            InputLanguage.CurrentInputLanguage = inputType;
        }
    }

    public static class NumericExt
    {
        public static string ReadDigit(this double value, int currencyId = 0)
        {
            return ((decimal)value).ReadDigit(currencyId); ;
        }
        public static string ReadDigit(this decimal value,int currencyId =0)
        {
            return ReadNumber.ReadKhmer(value);
        }
        public static string ReadDigit(this float value, int currencyId = 0)
        {
            return ((decimal)value).ReadDigit(currencyId);
        }
        public static string ReadDigit(this long value, int currencyId = 0)
        {
            return ((decimal)value).ReadDigit(currencyId);
        }
        public static string ReadDigit(this int value, int currencyId = 0)
        {
            return ((decimal)value).ReadDigit(currencyId);
        }

        public static string ReadDigit(this double value, string suffix="")
        {
            return ((decimal)value).ReadDigit(suffix);
        }
        public static string ReadDigit(this decimal value, string suffix = "")
        {
            return $"{ReadNumber.ReadKhmer(value)} {suffix}";
        }
        public static string ReadDigit(this float value, string suffix = "")
        {
            return ((decimal)value).ReadDigit(suffix); 
        }
        public static string ReadDigit(this long value, string suffix = "")
        {
            return ((decimal)value).ReadDigit(suffix);
        }
        public static string ReadDigit(this int value, string suffix = "")
        {
            return ((decimal)value).ReadDigit(suffix);
        }
        
    }

    public static class ModelExt
    {
        //public static Address CopyAddress(this Address source,LocationType locationType)
        //{
        //    //if (source == null)
        //    //{
        //    //    return new Address() { Id = Guid.Empty};
        //    //}

        //    //var des = new Address();
        //    //source.CopyTo(des);

        //    //des.Id = Guid.NewGuid();
        //    //des.Latitute = 0m;
        //    //des.Longtitute = 0m;
        //    //des.Street = string.Empty;
        //    //des.Building = string.Empty;
        //    //des.Room = string.Empty;
        //    //des.Floor = string.Empty;
        //    //des.Group = string.Empty;
        //    //des.LongText = source.LongText;
        //    //return des;

        //    return new Address();
        //}

        //public static string ToLongText(this Address address,String locationText,LocationType locationType = LocationType.Address)
        //{
        //    if (address == null)
        //    {
        //        return string.Empty;
        //    }

        //    var fullText = locationText;// LocationAPI.Instance.GetLocationText(address.LocationCode);
        //    fullText = fullText.Replace("\"", "").Replace("កម្ពុជា", "").Trim();

        //    var lines = new List<string>();
        //    if (locationType == LocationType.Address)
        //    {
        //        if (!string.IsNullOrEmpty(address.Room))
        //        {
        //            lines.Add($"{Resources.Room}{address.Room} ");
        //        }
        //        if (!string.IsNullOrEmpty(address.Floor))
        //        {
        //            lines.Add($"{Resources.Floor}{address.Floor} ");
        //        }
        //        if (!string.IsNullOrEmpty(address.Building))
        //        {
        //            lines.Add($"{Resources.Building}{address.Building} ");
        //        }
        //        if (!string.IsNullOrEmpty(address.Street))
        //        {
        //            lines.Add($"{Resources.Street}{address.Street} ");
        //        }
        //        if (!string.IsNullOrEmpty(address.Group))
        //        {
        //            lines.Add($"{Resources.Group}{address.Group} ");
        //        }
        //        if (!string.IsNullOrEmpty(address.Postal))
        //        {
        //            lines.Add($"{Resources.PostCode}{address.Postal} ");
        //        }
        //        if (lines.Any())
        //        {
        //            lines.Add(" ");
        //        }
                

        //        lines.Add(fullText);
        //        if (!string.IsNullOrEmpty(address.Postal))
        //        {
        //            //lines.Add($" ({address.Postal})");
        //        }
        //        return string.Join("", lines.ToArray());
        //    }
        //    else if(locationType == LocationType.Location)
        //    {
        //        return fullText;
        //    }
        //    else 
        //    {
        //        var shortText = address.ShortText;

        //        if (address.Latitute!=0 && address.Longtitute !=0)
        //        {
        //            return $"{shortText}({address.Latitute.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N7])},{address.Longtitute.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N7])})";
        //        }
        //        return shortText;
        //    } 
        //}

        public static T Find<T>(this IEnumerable<T> entities,int id) where T:BaseModel
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public static T Find<T>(this IEnumerable<T> entities,Guid id) where T:GuidBaseModel
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public static IEnumerable<List<T>> SplitList<T>(this List<T> locations, int nSize = 100)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        //public static T Reload<T>(this T current) where T : BaseModel, new()
        //{
        //    //current = ShareAPI.Instance.Find<T>(current.Id);
        //    return ShareAPI.Instance.Find<T>(current.Id);
        //}
    }

    public static class WebBrowserExt
    {
        public static string GetLatitude(this WebBrowser web)
        {
            var lat = web.Document.GetElementById("lat");
            return  lat?.GetAttribute("value") ?? string.Empty; 
        }
        public static string GetLongitude(this WebBrowser web)
        {
            var lng = web.Document.GetElementById("lng");
            return lng?.GetAttribute("value") ?? string.Empty;
        }

        public static void ChangeIEVersion(this WebBrowser web)
        {
            int BrowserVer, RegVal;

            // get the installed IE version 
                BrowserVer = web.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
        }
    }

    public static class ModuleExt
    {
        //public static ExDialog GetDialog(this ModuleManager module, 
        //    AuthKey moduleKey,string className , params object[] args)
        //{
        //    return module.GetInstanceObject(moduleKey,className, args) as ExDialog;
        //}

        //public static ExDialog GetDialog(this ModuleManager module,
        //    AuthKey moduleKey, Type t, params object[] args)
        //{
        //    var className = $"{t.Name}Dialog";
        //    return module.GetDialog(moduleKey, className, args);
        //}
    }

    public static class StringExt
    {
        public static string GenerateQRCodeFile(this string data, string fileName="")
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = System.IO.Path.GetTempFileName().Replace(".TMP", ".jpg");
            }  
            Bitmap img = data.GenerateQRCode(); 
            img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            return fileName;
        }

        public static Bitmap GenerateQRCode(this string data)
        {   
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            var qrCode = new QRCode(qrData);
            return qrCode.GetGraphic(4);
        }

        public static string ToStringCsv(this decimal dec)
        {
            return dec.ToString(FormatHelper.Decimal[FormatHelper.DecimalType.N3N]);
        }
    }

    public static class BulkOperationExt
    {
        public static void WriteTextFile(this string content, string filenameWithExtension)
        {
            var tmpPath = Path.Combine(Path.GetTempPath().Replace(".tmp", string.Empty), filenameWithExtension);
            File.WriteAllText(tmpPath, content, Encoding.UTF8);
            System.Diagnostics.Process.Start(tmpPath);
        }

        public static string ReadAllText(this string filePath)
        {
            string content = string.Empty;
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
                {
                    content = streamReader.ReadToEnd();
                }
            }
            catch (Exception err)
            {
                MsgBox.ShowError(err);
            }
            return content;
        }

        public static void IsValidType<T>(List<string> headers)
        {
            var fieldNames = typeof(T).GetProperties().Select(x => x.Name).ToList();
            foreach (var header in headers)
            {
                var field = header.Replace(" ","");
                if (fieldNames.Contains(field)) continue;
                throw new Exception(EDomain.Resources.InvalidFileType);
            }
        }

        public static List<T> ReadExcel<T>(this string excelPath) where T : new()
        {
            FileStream fs = new FileStream(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var headers = new List<string>();
            var data = new List<List<string>>();
            using (XLWorkbook workBook = new XLWorkbook(fs))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);
                var header = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (row.IsEmpty())
                    {
                        continue;
                    }
                    var ls = new List<string>();
                    if (header)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            headers.Add(cell.Value.ToString());
                        }
                        IsValidType<T>(headers);
                        header = false;
                        continue;
                    }
                    else
                    {
                        // ignore blank cell
                        //foreach (IXLCell cell in row.Cells())
                        //{
                        //    var val = cell.Value.ToString();
                        //    ls.Add(val);
                        //}
                        foreach (IXLCell cell in row.Cells(1, headers.Count()))
                        {
                            var val = cell.Value.ToString();
                            ls.Add(val);
                        }
                    }
                    data.Add(ls);
                }
            }
            var obj = data.Select(line => ToModel<T>(headers, line)).ToList();
            return obj;
        }

        public static List<T> ReadCsv<T>(this string csvPath, ICsvMapping<T> mapping = null) where T : new()
        {
            FileStream fs = new FileStream(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var headers = new List<string>();
            var data = new List<T>();
            using (StreamReader reader = new StreamReader(fs))
            {
                var lines = reader.ReadLine().Split(',').ToList();
                headers.AddRange(lines);
                IsValidType<T>(headers);

                var parserOptions = new CsvParserOptions(true, ',');
                var readerOptions = new CsvReaderOptions(new[] { "\r", "\n" });
                var parser = new CsvParser<T>(parserOptions, mapping);
                //var records = parser.ReadFromString(readerOptions, content);
                var records = parser.ReadFromFile(csvPath, Encoding.UTF8);
                data = records.Select(x => x.Result).ToList();
            }
            return data;
        }

        public static List<T> ReadXml<T>(this string xmlPath) where T : new()
        {
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var headers = new List<string>();
                var data = new List<T>();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fs);
                XmlNodeList nodeList = xmldoc.GetElementsByTagName(typeof(T).Name);
                foreach (XmlNode parentNode in nodeList)
                {
                    if (!headers.Any())
                    {
                        headers.AddRange(parentNode.ChildNodes.Cast<XmlNode>().Select(x => x.Name));
                        IsValidType<T>(headers);
                    }
                    var row = parentNode.ChildNodes.Cast<XmlNode>().Select(x => x.InnerText).ToList();
                    data.Add(ToModel<T>(headers, row));
                }
                return data;
            }
        }

        public static List<T> ReadJson<T>(this string jsonPath) where T : new()
        {
            using (FileStream fs = new FileStream(jsonPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var headers = new List<string>();
                var data = new List<T>();
                using (StreamReader reader = new StreamReader(fs))
                {
                    var serializer = new JsonSerializer();
                    var jsonTextReader = new JsonTextReader(reader);
                    try
                    {
                        data = serializer.Deserialize<List<T>>(jsonTextReader);
                    }
                    catch (Exception)
                    {
                        throw new Exception(Properties.Resources.FormatIncorrect);
                    }
                }
                return data;
            }
        }

        public static async Task<List<T>> ReadTextAsync<T>(this string path, List<string> headers, char[] delimiter, bool isRemoveEmpty = true,
            Dictionary<string, string> replaceNullOrEmptyValue = null) where T: new()
        {
            List<T> lst = new List<T>();

            DataTable datatable = new DataTable();
            StreamReader streamreader = new StreamReader(path);

            foreach (string header in headers)
            {
                // save column header
                datatable.Columns.Add(header);
            }

            while (streamreader.Peek() > 0)
            {
                DataRow datarow = datatable.NewRow();
                var line = await streamreader.ReadLineAsync();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var row = line.Split(delimiter ,options: (isRemoveEmpty) ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
                //Replace Null Or Empty Values
                if (replaceNullOrEmptyValue?.Any() ?? false)
                {
                    var rowAsList = row.ToList();
                    
                    replaceNullOrEmptyValue.ToList().ForEach(x =>
                    {
                        var index = headers.IndexOf(x.Key);
                        if (row.Count() != headers.Count)
                        {
                            rowAsList.Insert(index, null);
                        }
                        if (rowAsList[index] == null)
                        {
                            rowAsList[index] = x.Value;
                        }
                    });
                    row = rowAsList.ToArray();
                }
                //If don't replace any header, throw error
                if (row.Count() != headers.Count/* && replaceNullOrEmptyValue == null*/)
                {
                    throw new Exception($"{EDomain.ErrResx.InvalideDataFormatInList} {Environment.NewLine} {path}");
                }
                datarow.ItemArray = row;
                datatable.Rows.Add(datarow);
            }

            // go through each row
            foreach (DataRow r in datatable.Rows)
            {
                //var lines = r.ItemArray.Select(x => x.ToString()).ToList();
                lst.Add(DataRowToModel<T>(headers, r));
            }

            streamreader.Close();
            return lst;
        }

        public static T DataRowToModel<T>(List<string> columns, DataRow row) where T : new()
        {
            var tmp = Activator.CreateInstance(typeof(T));
            foreach (string column in columns)
            {
                // find the property for the column
                PropertyInfo p = tmp.GetType().GetProperty(column);
                string value = row[column].ToString();
                // if exists, set the value
                if (p != null | value != null)
                {
                    if (p.PropertyType == typeof(string))
                    {
                        p.SetValue(tmp, value);
                    }
                    else if (p.PropertyType == typeof(decimal))
                    {
                        p.SetValue(tmp, Parse.ToDecimal(value));
                    }
                    else if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(tmp, Parse.ToInt(value));
                    }
                    else if (p.PropertyType == typeof(DateTime))
                    {
                        DateTime result;
                        DateTime.TryParse(value, out result);
                        p.SetValue(tmp, result);
                    }
                }
            }
            return (T)tmp;
        }


        public static T ToModel<T>(List<string> columns, List<string> values) where T : new()
        {
            var tmp = Activator.CreateInstance(typeof(T));
            for (var i = 0; i < columns.Count; i++)
            {
                var field = columns[i];
                var value = values[i];
                var pi = typeof(T).GetProperties().FirstOrDefault(x => x.Name == field);
                if (pi == null) continue;
                if (pi.PropertyType.Name == "String")
                {
                    pi.SetValue(tmp, value);
                }
                else if (pi.PropertyType.Name == "Decimal")
                {
                    pi.SetValue(tmp, Parse.ToDecimal(value));
                }
                else if (pi.PropertyType.Name == "Int32")
                {
                    pi.SetValue(tmp, Parse.ToInt(value));
                }
                else if (pi.PropertyType.Name == "DateTime")
                {
                    DateTime result;
                    DateTime.TryParse(value, out result);
                    pi.SetValue(tmp, result);
                }
            }
            return (T)tmp;
        }

        public static List<T> ToListModel<T>(this FileInfo fileInfo, ICsvMapping<T> mapping = null) where T : new()
        {
            var entries = new List<T>();
            if (Conts.FileTypeExtension[Conts.FileExtension.Excel].Contains(fileInfo.Extension))
            {
                entries = fileInfo.FullName.ReadExcel<T>();
            }
            else if (Conts.FileTypeExtension[Conts.FileExtension.Csv].Contains(fileInfo.Extension))
            {
                entries = fileInfo.FullName.ReadCsv<T>(mapping);
            }
            else if (Conts.FileTypeExtension[Conts.FileExtension.Xml].Contains(fileInfo.Extension))
            {
                entries = fileInfo.FullName.ReadXml<T>();
            }
            else if (Conts.FileTypeExtension[Conts.FileExtension.Json].Contains(fileInfo.Extension))
            {
                entries = fileInfo.FullName.ReadJson<T>();
            }
            return entries;
        }

        public async static void BulkResultToExcel(this ExDataGridView dgv, string title)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(title);
            var cols = dgv.Columns.OfType<DataGridViewColumn>().Count(x => x.Visible);
            var rows = dgv.Rows.Count;
            var savePath = Path.GetTempFileName().Replace(".tmp", ".xlsx");

            await dgv.RunAsync(() =>
            {
                var renderIndex = 2;
                var headergenerated = false;
                var colsdgv = dgv.Columns.OfType<DataGridViewColumn>().Count();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!headergenerated)
                    {
                        var headerCellIndex = 1;
                        for (var index = 0; index < colsdgv; index++)
                        {
                            var headerObj = dgv.Columns[index];
                            if (!headerObj.Visible)
                            {
                                continue;
                            }
                            var header = ws.Range(1, headerCellIndex, 1, headerCellIndex);
                            header.Value = headerObj.HeaderText;
                            header.Style.Font.FontName = dgv.Font.Name;
                            header.Style.Font.FontSize = dgv.Font.Size;
                            header.Style.Font.Bold = true;
                            header.Style.Fill.BackgroundColor = XLColor.FromName(Color.Silver.Name);
                            headerCellIndex++;
                        }
                        headergenerated = true;
                    }
                    var cellIndex = 1;
                    for (var index = 0; index < colsdgv; index++)
                    {
                        var cellObj = dgv.Columns[index];
                        if (!cellObj.Visible)
                        {
                            continue;
                        }
                        var rowValue = ws.Range(renderIndex, cellIndex, renderIndex, cellIndex);
                        rowValue.Value = row.Cells[index].FormattedValue;
                        rowValue.Style.Font.FontSize = dgv.Font.Size;
                        rowValue.Style.Font.FontName = dgv.Font.Name;
                        rowValue.Style.Alignment.Horizontal = cellObj.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight
                                                              ? XLAlignmentHorizontalValues.Right : cellObj.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter
                                                              ? XLAlignmentHorizontalValues.Center : XLAlignmentHorizontalValues.Left;
                        rowValue.Style.Font.Bold = row.DefaultCellStyle.Font?.Bold ?? false;
                        cellIndex++;
                    }
                    renderIndex++;
                }
                ws.Columns().AdjustToContents();
                wb.SaveAs(savePath);
                return true;
            });

            
            System.Diagnostics.Process.Start(savePath);
        }
        
        public static Image GetImageFromUrl(this string url)
        {
            try
            {
                var httpWebRequest = HttpWebRequest.Create(url);
                // if you have proxy server, you may need to set proxy details like below 
                //httpWebRequest.Proxy = new WebProxy("proxyserver",port){ Credentials = new NetworkCredential(){ UserName ="uname", Password = "pw"}};

                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebReponse.GetResponseStream())
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception)
            {
                return Properties.Resources.img_placeholder;
            }
        }

        public static void RenameDictionaryKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
                                     TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        public static void validCurrency(this TextBox txt, object sender, KeyPressEventArgs e)
        {
            decimal x;
            char ch = e.KeyChar;
            if (ch == (char)8)    //Backspace
                e.Handled = false;//Remember think "Handled" like barrier to stop any unexpected charactor
            else if (!char.IsDigit(ch) && ch != '.' || !decimal.TryParse(txt.Text + ch, out x))
                e.Handled = true;
        }

        public static void SetControlsReadOnly(this Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox c)
                {
                    c.ReadOnly = true;
                }
                if (control is ComboBox com)
                {
                    com.Enabled = false;
                }
                if (control is DataGrid g)
                {
                   g.ReadOnly  = true;
                }
            }
        }

    }



}

