using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.Helpers
{
    public static class ExcelHelper
    {
        public static async void ToExcelAsync(this ExDataGridView dgv, string title = "", string createBy = "")
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(title);
            var cols = dgv.Columns.OfType<DataGridViewColumn>().Count(x => x.Visible);
            var rows = dgv.Rows.Count;
            var savePath = Path.GetTempFileName().Replace(".tmp", ".xlsx");

            await dgv.RunAsync(() => {
                var rowTitle = ws.Range(1, 1, 1, cols);
                rowTitle.Value = title;
                rowTitle.Style.Font.FontName = "Khmer OS Muol Light";
                rowTitle.Style.Font.FontSize = 10;
                rowTitle.Style.Alignment.WrapText = true;
                rowTitle.Merge(false);

                var rowDate = ws.Range(2, 1, 2, cols);
                rowDate.Style.Font.FontName = dgv.Font.Name;
                rowDate.Style.Font.FontSize = dgv.Font.Size;
                rowDate.Value = $"កាលបរិច្ឆេទ៖ {DateTime.Now.ToString("F")}";
                rowDate.Style.Font.Bold = true;
                rowDate.Merge(false);

                var rowBy = ws.Range(3, 1, 3, cols);
                rowBy.Style.Font.FontName = dgv.Font.Name;
                rowBy.Style.Font.FontSize = dgv.Font.Size;
                rowBy.Style.Font.Bold = true;
                rowBy.Style.Font.Underline = XLFontUnderlineValues.Single;
                rowBy.Value = $"បង្កើតដោយ៖ {createBy}";
                rowBy.Merge(false);

                var renderIndex = 5;
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
                            var header = ws.Range(4, headerCellIndex, 4, headerCellIndex);
                            header.Value = index == 0 ? "ល.រ" : headerObj.HeaderText;
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
                        var rowStyle = row.Cells[index].Style;
                        if (!cellObj.Visible)
                        {
                            continue;
                        }
                        var rowValue = ws.Range(renderIndex, cellIndex, renderIndex, cellIndex);
                        rowValue.Value = row.Cells[index].FormattedValue;
                        rowValue.Style.Font.FontSize = dgv.Font.Size;
                        rowValue.Style.Font.FontName = dgv.Font.Name;
                        rowValue.Style.Font.FontColor = XLColor.FromColor(rowStyle.ForeColor);
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
                System.Diagnostics.Process.Start(savePath);
                return true;
            });

            //dgv.MultiSelect = true;
            //dgv.SelectAll();
            //DataObject dataObj = dgv.GetClipboardContent();
            //if (dataObj != null)
            //    Clipboard.SetDataObject(dataObj);
            //dgv.MultiSelect = false;

            //var cols = dgv.Columns.OfType<DataGridViewColumn>().Count(x => x.Visible);
            //var rows = dgv.Rows.Count;
            //var excel = new Microsoft.Office.Interop.Excel.Application()
            //{
            //    StandardFont = dgv.Font.FontFamily.Name,
            //    StandardFontSize = dgv.Font.Size,
            //    DisplayAlerts = false
            //};
            //await dgv.RunAsync(() =>
            //{
            //    var misValue = System.Reflection.Missing.Value;
            //    var workbooks = excel.Workbooks.Add(misValue);
            //    var worksheets = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Worksheets.get_Item(1);
            
            //    var rowTitle = (Microsoft.Office.Interop.Excel.Range)worksheets.Range[worksheets.Cells[1, 1], worksheets.Cells[1, cols]];
            //    rowTitle.Font.Name = "Khmer OS Muol Light";
            //    rowTitle.Font.Size = 10;
            //    rowTitle.Value = title;
            //    rowTitle.Merge(misValue);

            //    var rowDate = (Microsoft.Office.Interop.Excel.Range)worksheets.Range[worksheets.Cells[2, 1], worksheets.Cells[2, cols]];
            //    rowDate.Font.Bold = true;
            //    rowDate.Value = $"កាលបរិច្ឆេទ៖ {DateTime.Now.ToString("F")}";
            //    rowDate.Merge(misValue);

            //    var rowBy = (Microsoft.Office.Interop.Excel.Range)worksheets.Range[worksheets.Cells[3, 1], worksheets.Cells[3, cols]];
            //    rowBy.Font.Bold = true;
            //    rowBy.Font.Underline = true;
            //    rowBy.Value = $"បង្កើតដោយ៖ {createBy}";
            //    rowBy.Merge(misValue);

            //    var startRow = 4;
            //    var CR = (Microsoft.Office.Interop.Excel.Range)worksheets.Cells[startRow, 1];
            //    CR.Select();
            //    worksheets.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            //    /*
            //     * Header columns style.
            //     */
            //    var header = (Microsoft.Office.Interop.Excel.Range)worksheets.Range[worksheets.Cells[startRow, 1], worksheets.Cells[startRow, cols]];
            //    header.Font.Bold = true;
            //    header.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);

            //    /*
            //     * Autofit columns.
            //     */
            //    if (dgv.AllowRowNumber)
            //    {
            //        ((Microsoft.Office.Interop.Excel.Range)worksheets.Cells[startRow, 1]).Value = "ល.រ";
            //        var rowNo = (Microsoft.Office.Interop.Excel.Range)worksheets.Range[worksheets.Cells[startRow, 1], worksheets.Cells[rows + startRow, 1]];
            //        rowNo.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //        rowNo.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //        //for (int i = 1; i <= rows; i++)
            //        //{
            //        //    ((Microsoft.Office.Interop.Excel.Range)worksheets.Cells[startRow + i, 1]).Value = i;
            //        //}
            //    }
            //    worksheets.UsedRange.Columns.AutoFit();
            //    excel.Visible = true;
            //    return true;
            //});
        }
    }
}
