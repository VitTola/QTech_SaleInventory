using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using ClosedXML.Excel;
using System.IO;
using QTech.Component.Helpers;
using QTech.Base.Helpers;
using QTech.Base;
using QTech.Base.Models;
using QTech.Base.SearchModels;


namespace QTech.Component
{
    public partial class AuditTrailDialog : ExDialog, IPage
    {
        public AuditTrailDialog()
        {
            InitializeComponent();
            InitEvent();
        }

        Color[] _alternative = new Color[] { Color.White, Color.WhiteSmoke };
        public GeneralProcess Flag { get; set; } = GeneralProcess.View;
        public BaseModel Model { get; set; }
        public void InitEvent()
        {
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 28;
            dgv.BackgroundColor = Color.White;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpDate.Value = ReportDatePicker.DateRanges.ThisMonth;

            // export list to excel
            btnExpand_.Click += btnExpand__Click;
            btnExportAsExcel_.Click += btnExportAsExcel__Click;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Ivory,
                SelectionBackColor = Color.Ivory
            };
        }

        private void btnExpand__Click(object sender, EventArgs e)
        {
            if (dgv.Executing || !btnExpand_.Enabled)
            {
                return;
            }
            var nodes = dgv.Rows.OfType<TreeGridNode>().ToList();
            if (nodes == null)
            {
                return;
            }
            if (nodes.Any(x => x.IsExpanded))
            {
                nodes.Where(x => x.Nodes.Any() && x.Level == 1).ToList().ForEach((node) => node?.Collapse());
            }
            else
            {
                nodes.ForEach((node) =>
                {
                    node?.Expand();
                    expandingNode(node);
                });
            }
        }

        private void btnExportAsExcel__Click(object sender, EventArgs e)
        {
            if (!dgv.Executing || btnExpand_.Enabled)
            {
                auditTrailToExcel();
            }
        }

        private void expandingNode(TreeGridNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Nodes?.Any() ?? false)
            {
                foreach (var node1 in node.Nodes)
                {
                    if (node1 == null)
                    {
                        continue;
                    }
                    node1.Expand();
                    expandingNode(node1);
                }
            }
        }

        private async void auditTrailToExcel()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(QTech.Base.Properties.Resources.AuditTrail);
            var cols = dgv.Columns.OfType<DataGridViewColumn>().Count(x => x.Visible);
            var rows = dgv.Rows.Count;
            var savePath = Path.GetTempFileName().Replace(".tmp", ".xlsx");

            await dgv.RunAsync(() =>
            {
                var rowTitle = ws.Range(1, 1, 1, cols);
                rowTitle.Value = Text;
                rowTitle.Style.Font.FontName = "Khmer OS Muol Light";
                rowTitle.Style.Font.FontSize = 10;
                rowTitle.Style.Alignment.WrapText = true;
                rowTitle.Merge(false);

                var rowDate = ws.Range(2, 1, 2, cols);
                rowDate.Style.Font.FontName = dgv.Font.Name;
                rowDate.Style.Font.FontSize = dgv.Font.Size;
                rowDate.Value = $"{QTech.Base.Properties.Resources.Dated}៖ {DateTime.Now.ToString("F")}";
                rowDate.Style.Font.Bold = false;
                rowDate.Merge(false);

                var rowBy = ws.Range(3, 1, 3, cols);
                rowBy.Style.Font.FontName = dgv.Font.Name;
                rowBy.Style.Font.FontSize = dgv.Font.Size;
                rowBy.Style.Font.Bold = false;
                rowBy.Style.Font.Underline = XLFontUnderlineValues.Single;
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
                        rowValue.Style.Font.FontColor = index == colOldValue.Index
                            ? XLColor.Red : (index == colNewValue.Index
                            ? XLColor.Blue : XLColor.FromColor(row.DefaultCellStyle.ForeColor));

                        rowValue.Style.Font.Bold = index == colTransaction.Index && ((TreeGridNode)row).Nodes.Any();
                        rowValue.Style.Alignment.Horizontal = cellObj.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight
                            ? XLAlignmentHorizontalValues.Right : cellObj.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter
                            ? XLAlignmentHorizontalValues.Center : XLAlignmentHorizontalValues.Left;
                        cellIndex++;
                    }
                    renderIndex++;
                }
                ws.Columns().AdjustToContents();
                wb.SaveAs(savePath);
                System.Diagnostics.Process.Start(savePath);
                return true;
            });
        }

        public string ItemName { get; set; }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Q))
            {
                this.Close();
            }
            if (keyData == Conts.PaginationKey[Pagination.Next])
            {
                if (pagination != null)
                {
                    pagination.NextPage();
                }
                return true;
            }
            else if (keyData == Conts.PaginationKey[Pagination.Previous])
            {
                if (pagination != null)
                {
                    pagination.PreviousPage();
                }
                return true;
            }
            else if (keyData == Conts.PaginationKey[Pagination.ShowAll])
            {
                if (pagination != null)
                {
                    pagination.ShowAll();
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                btnExportAsExcel__Click(btnExportAsExcel_, EventArgs.Empty);
            }
            else if (keyData == (Keys.Control | Keys.M))
            {
                btnExpand__Click(btnExpand_, EventArgs.Empty);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            pagination.Repaging();
            await Search();
        }

        public static void ShowChangeLog<T>(T model, string displayItemName = "") where T : BaseModel
        {
            var dialog = new AuditTrailDialog
            {
                Model = model,
                ItemName = displayItemName,
            };
            dialog.ShowDialog();
        }

        private async void AuditTrailDialog_Load(object sender, EventArgs e)
        {
            pagination.Repaging();
            await Search();
        }

        private void AddDataGridViewRow(TreeGridNode node, ChangeLog changeLog)
        {
            var nodeChange = node.Nodes.Add();
            nodeChange.Height = dgv.RowTemplate.Height;
            nodeChange.Tag = changeLog;
            nodeChange.DefaultCellStyle.BackColor = node.DefaultCellStyle.BackColor;

            nodeChange.Cells[dgv.Columns[colTransaction.Name].Index].Value = ResourceHelper.Translate(changeLog.DisplayName);
            var oldNode = nodeChange.Cells[dgv.Columns[colOldValue.Name].Index];
            var newNode = nodeChange.Cells[dgv.Columns[colNewValue.Name].Index];
            oldNode.Value = changeLog.OldValue;
            newNode.Value = changeLog.NewValue;
            oldNode.Style.ForeColor = oldNode.Style.SelectionForeColor = Color.Red;
            newNode.Style.ForeColor = newNode.Style.SelectionForeColor = Color.Blue;

            if (changeLog.Details != null)
            {
                nodeChange.Tag = changeLog;
                nodeChange.Cells[dgv.Columns[colTransaction.Name].Index].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                foreach (var change in changeLog.Details)
                {
                    AddDataGridViewRow(nodeChange, change);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dgv.CurrentNode?.Expand();
            }
            else if (e.KeyCode == Keys.Left)
            {
                dgv.CurrentNode?.Collapse();
            }
        }


        public bool InValid()
        {
            return false;
        }


        public void AddNew()
        {

        }

        public void Remove()
        {

        }

        public void View()
        {

        }

        public void Edit()
        {

        }

        public async Task Search()
        {
            //this.Text = string.Format(QTech.Base.Properties.Resources.UpdateHistory__, ResourceHelper.Translate(Model.GetType().Name), ((string.IsNullOrEmpty(ItemName)) ? Model.ToString() : ItemName));
            //var TableName = Model.GetType().Namespace + "." + Model.GetType().Name + "s";
            //var search = new AuditTrailHistorySearch()
            //{
            //    Paging = pagination.Paging,
            //    FromDate = dtpDate.FromDate,
            //    ToDate = dtpDate.ToDate,
            //    Pk = Model.Id.ToString(),
            //    TableName = TableName
            //};

            //var auditTrail = await dgv.RunAsync(() => AuditTrailLogic.Instance.SearchAsync(search));
            //pagination.ListModel = auditTrail;
            //dgv.Nodes.Clear();
            //foreach (var audit in auditTrail)
            //{
            //    var font = dgv.DefaultCellStyle.Font;
            //    var node = dgv.Nodes.Add();
            //    node.Height = dgv.RowTemplate.Height;
            //    var backColor = _alternative[(node.Index % 2)];
            //    node.Tag = audit;
            //    node.DefaultCellStyle.BackColor = backColor;
            //    node.Cells[colTransaction.Name].Style.Font = new Font(font, FontStyle.Bold);
            //    node.Cells[colTransaction.Name].Value = $"{audit.OperatorName}";
            //    node.Cells[colId.Name].Value = audit.Id;
            //    node.Cells[colDate.Name].Value = audit.TransactionDate;
            //    node.Cells[colEditor.Name].Value = audit.UserName;
            //    node.Cells[colHostName.Name].Value = audit.ClientName;

            //    var json = JsonConvert.DeserializeObject<List<ChangeLog>>(audit.ChangeJson);
            //    if (json == null)
            //    {
            //        continue;
            //    }
            //    foreach (var changeLog in json)
            //    {
            //        AddDataGridViewRow(node, changeLog);
            ////    }
            //}

            ///*
            // * Auto Expend first node.
            // */
            //if (dgv.Nodes.Count > 0)
            //{
            //    dgv.Nodes[0].Expand();
            //}

        }

        public void EditAsync()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }
       
    }
}
