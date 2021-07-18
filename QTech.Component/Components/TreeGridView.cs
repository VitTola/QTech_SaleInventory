//---------------------------------------------------------------------
//
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace QTech.Component
{
	/// <summary>
	/// Summary description for TreeGridView.
	/// </summary>
    [System.ComponentModel.DesignerCategory("code"),
    Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
	ComplexBindingProperties(),
    Docking(DockingBehavior.Ask)]
	public class TreeGridView:DataGridView, IAsyncTask
    {
		private int _indentWidth;
		private TreeGridNode _root;
		private TreeGridColumn _expandableColumn;
		private bool _disposing = false;
		internal ImageList _imageList;
		private bool _inExpandCollapse = false;
        internal bool _inExpandCollapseMouseCapture = false;
		private Control hideScrollBarControl;
        private bool _showLines = true;
        private bool _virtualNodes = false;

		internal VisualStyleRenderer rOpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
		internal VisualStyleRenderer rClosed = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);

        #region Constructor
        public TreeGridView()
		{
			// Control when edit occurs because edit mode shouldn't start when expanding/collapsing
			this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.RowTemplate = new TreeGridNode() as DataGridViewRow;
			// This sample does not support adding or deleting rows by the user.
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
			this._root = new TreeGridNode(this);
			this._root.IsRoot = true;

			// Ensures that all rows are added unshared by listening to the CollectionChanged event.
			base.Rows.CollectionChanged += delegate(object sender, System.ComponentModel.CollectionChangeEventArgs e){};
            panel.Controls.Add(picLoading);
            Controls.Add(panel);
           
            panel.Paint += Panel_Paint;
        }
        #endregion

        #region Keyboard F2 to begin edit support
        protected override void OnKeyDown(KeyEventArgs e)
		{
			// Cause edit mode to begin since edit mode is disabled to support
			// expanding/collapsing
			base.OnKeyDown(e);
			if (!e.Handled)
			{
				if (e.KeyCode == Keys.F2 && this.CurrentCellAddress.X > -1 && this.CurrentCellAddress.Y >-1)
				{
					if (!this.CurrentCell.Displayed)
					{
						this.FirstDisplayedScrollingRowIndex = this.CurrentCellAddress.Y;
					}
					else
					{
						// TODO:calculate if the cell is partially offscreen and if so scroll into view
					}
					this.SelectionMode = DataGridViewSelectionMode.CellSelect;
					this.BeginEdit(true);
				}
				else if (e.KeyCode == Keys.Enter && !this.IsCurrentCellInEditMode)
				{
					this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (this.CurrentCell != null)
                    {
                        this.CurrentCell.OwningRow.Selected = true;
                    }
				}
			}
        }
        #endregion

        #region Shadow and hide DGV properties

        // This sample does not support databinding
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataSource
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

		[Browsable(false),
	    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataMember
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows
        {
            get { return base.Rows; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get { return false; }
            set { throw new NotSupportedException("The TreeGridView does not support virtual mode"); }
        }

        // none of the rows/nodes created use the row template, so it is hidden.
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate; }
            set { base.RowTemplate = value; }
        }

        #endregion

        #region Public methods
        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeGridNode GetNodeForRow(DataGridViewRow row)
        {
            return row as TreeGridNode;
        }

        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeGridNode GetNodeForRow(int index)
        {
            return GetNodeForRow(base.Rows[index]);
        }
        #endregion

        #region Public properties
        [Category("Data"),
		Description("The collection of root nodes in the treelist."),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public TreeGridNodeCollection Nodes
		{
			get
			{
				return this._root.Nodes;
			}
		}

		public new TreeGridNode CurrentRow
		{
			get
			{
				return base.CurrentRow as TreeGridNode;
			}
		}

        [DefaultValue(false),
        Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
        public bool VirtualNodes
        {
            get { return _virtualNodes; }
            set { _virtualNodes = value; }
        }

		public TreeGridNode CurrentNode
		{
			get
			{
				return this.CurrentRow;
			}
		}

        [DefaultValue(true)]
        public bool ShowLines
        {
            get { return this._showLines; }
            set {
                if (value != this._showLines) {
                    this._showLines = value;
                    this.Invalidate();
                }
            }
        }

		public ImageList ImageList
		{
			get { return this._imageList; }
			set {
				this._imageList = value;
				//TODO: should we invalidate cell styles when setting the image list?

			}
		}

        public new int RowCount
        {
            get { return this.Nodes.Count; }
            set
            {
                for (int i = 0; i < value; i++)
                    this.Nodes.Add(new TreeGridNode());

            }
        }

        public bool Executing { get; set; }
        #endregion

        #region Site nodes and collapse/expand support
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            // Notify the row when it is added to the base grid
            int count = e.RowCount - 1;
            TreeGridNode row;
            while (count >= 0)
            {
                row = base.Rows[e.RowIndex + count] as TreeGridNode;
                if (row != null)
                {
                    row.Sited();
                }
                count--;
            }
        }

		internal protected void UnSiteAll()
		{
			this.UnSiteNode(this._root);
		}

		internal protected virtual void UnSiteNode(TreeGridNode node)
		{
            if (node.IsSited || node.IsRoot)
			{
				// remove child rows first
				foreach (TreeGridNode childNode in node.Nodes)
				{
					this.UnSiteNode(childNode);
				}

				// now remove this row except for the root
				if (!node.IsRoot)
				{
                    try
                    {
                        base.Rows.Remove(node);
                        // Row isn't sited in the grid anymore after remove. Note that we cannot
                        // Use the RowRemoved event since we cannot map from the row index to
                        // the index of the expandable row/node.
                        node.UnSited();
                    }
                    catch { }
					
				}
			}
		}

		internal protected virtual bool CollapseNode(TreeGridNode node)
		{
			if (node.IsExpanded)
			{
				CollapsingEventArgs exp = new CollapsingEventArgs(node);
				this.OnNodeCollapsing(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = false;

					foreach (TreeGridNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex != -1, "Row is NOT in the grid.");
						this.UnSiteNode(childNode);
					}

					CollapsedEventArgs exped = new CollapsedEventArgs(node);
					this.OnNodeCollapsed(exped);
					//TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);

				}

				return !exp.Cancel;
			}
			else
			{
				// row isn't expanded, so we didn't do anything.
				return false;
			}
		}

		internal protected virtual void SiteNode(TreeGridNode node)
		{
			//TODO: Raise exception if parent node is not the root or is not sited.
			int rowIndex = -1;
			TreeGridNode currentRow;
			node._grid = this;

			if (node.Parent != null && node.Parent.IsRoot == false)
			{
				// row is a child
				Debug.Assert(node.Parent != null && node.Parent.IsExpanded == true);

				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = node.Parent;
				}
			}
			else
			{
				// row is being added to the root
				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = null;
				}

			}

			if (currentRow != null)
			{
				while (currentRow.Level >= node.Level)
				{
					if (currentRow.RowIndex < base.Rows.Count - 1)
					{
						currentRow = base.Rows[currentRow.RowIndex + 1] as TreeGridNode;
						Debug.Assert(currentRow != null);
					}
					else
						// no more rows, site this node at the end.
						break;

				}
				if (currentRow == node.Parent)
					rowIndex = currentRow.RowIndex + 1;
				else if (currentRow.Level < node.Level)
					rowIndex = currentRow.RowIndex;
				else
					rowIndex = currentRow.RowIndex + 1;
			}
			else
				rowIndex = 0;


			Debug.Assert(rowIndex != -1);
			this.SiteNode(node, rowIndex);

			Debug.Assert(node.IsSited);
			if (node.IsExpanded)
			{
				// add all child rows to display
				foreach (TreeGridNode childNode in node.Nodes)
				{
					//TODO: could use the more efficient SiteRow with index.
					this.SiteNode(childNode);
				}
			}
		}


		internal protected virtual void SiteNode(TreeGridNode node, int index)
		{
			if (index < base.Rows.Count)
			{
				base.Rows.Insert(index, node);
			}
			else
			{
				// for the last item.
				base.Rows.Add(node);
			}
		}

		internal protected virtual bool ExpandNode(TreeGridNode node)
		{
            if (!node.IsExpanded || this._virtualNodes)
			{
				ExpandingEventArgs exp = new ExpandingEventArgs(node);
				this.OnNodeExpanding(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = true;

					//TODO Convert this to a InsertRange
					foreach (TreeGridNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex == -1, "Row is already in the grid.");

						this.SiteNode(childNode);
						//this.BaseRows.Insert(rowIndex + 1, childRow);
						//TODO : remove -- just a test.
						//childNode.Cells[0].Value = "child";
					}

					ExpandedEventArgs exped = new ExpandedEventArgs(node);
					this.OnNodeExpanded(exped);
					//TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);
				}

				return !exp.Cancel;
			}
			else
			{
				// row is already expanded, so we didn't do anything.
				return false;
			}
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // used to keep extra mouse moves from selecting more rows when collapsing
            base.OnMouseUp(e);
            this._inExpandCollapseMouseCapture = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // while we are expanding and collapsing a node mouse moves are
            // supressed to keep selections from being messed up.
            if (!this._inExpandCollapseMouseCapture)
                base.OnMouseMove(e);

        }

        //public override DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder, bool isFirstDisplayedColumn, bool isLastVisibleColumn)
        //{
        //    //Data Grid View Advance border column
        //    dataGridViewAdvancedBorderStyleInput.Left = DataGridViewAdvancedCellBorderStyle.None;
        //    dataGridViewAdvancedBorderStyleInput.Right = DataGridViewAdvancedCellBorderStyle.None;
        //    dataGridViewAdvancedBorderStyleInput.Top = DataGridViewAdvancedCellBorderStyle.Single;
        //    dataGridViewAdvancedBorderStyleInput.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        //    return base.AdjustColumnHeaderBorderStyle(dataGridViewAdvancedBorderStyleInput, dataGridViewAdvancedBorderStylePlaceholder, isFirstDisplayedColumn, isLastVisibleColumn);
        //}

        #endregion

        #region Collapse/Expand events
        public event ExpandingEventHandler NodeExpanding;
        public event ExpandedEventHandler NodeExpanded;
        public event CollapsingEventHandler NodeCollapsing;
        public event CollapsedEventHandler NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            if (this.NodeExpanding != null)
            {
                NodeExpanding(this, e);
            }
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            if (this.NodeExpanded != null)
            {
                NodeExpanded(this, e);
            }
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            if (this.NodeCollapsing != null)
            {
                NodeCollapsing(this, e);
            }

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            if (this.NodeCollapsed != null)
            {
                NodeCollapsed(this, e);
            }
        }
        #endregion

        #region Helper methods
        protected override void Dispose(bool disposing)
        {
            this._disposing = true;
            base.Dispose(Disposing);
            this.UnSiteAll();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // this control is used to temporarly hide the vertical scroll bar
            hideScrollBarControl = new Control();
            hideScrollBarControl.Visible = false;
            hideScrollBarControl.Enabled = false;
            hideScrollBarControl.TabStop = false;
            // control is disposed automatically when the grid is disposed
            this.Controls.Add(hideScrollBarControl);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            // ensure full row select
            base.OnRowEnter(e);
            if (this.SelectionMode == DataGridViewSelectionMode.CellSelect ||
                (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect &&
                base.Rows[e.RowIndex].Selected == false))
            {
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                base.Rows[e.RowIndex].Selected = true;
            }
        }

		private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
		{
            // Temporarly hide/show the vertical scroll bar by changing its parent
            if (!this._inExpandCollapse)
            {
                if (lockUpdate)
                {
                    this.VerticalScrollBar.Parent = hideScrollBarControl;
                }
                else
                {
                    this.VerticalScrollBar.Parent = this;
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (typeof(TreeGridColumn).IsAssignableFrom(e.Column.GetType()))
            {
                if (_expandableColumn == null)
                {
                    // identify the expanding column.
                    _expandableColumn = (TreeGridColumn)e.Column;
                }
                else
                {
                   // this.Columns.Remove(e.Column);
                    //throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
                }
            }

            // Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

            base.OnColumnAdded(e);
        }

        Panel panel = new Panel()
        {
            BorderStyle = BorderStyle.None,
            Size = new Size(110, 110),
            BackColor = Color.FromArgb(245, 245, 237),
            Visible = false
        };
        PictureBox picLoading = new PictureBox()
        {
            Enabled = true,
            Image = Properties.Resources.dgvloading,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Visible = true,
            Dock = DockStyle.Fill,
            BorderStyle = BorderStyle.None,
            BackColor = Color.FromArgb(245, 245, 237),
        };
        public void PreExecute(bool block = false)
        {
            if (block)
            {
                Enabled = false;
            }
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            panel.Enabled = true;
            panel.Visible = true;

        }

        public void PostExecute(bool block = false)
        {
            if (block)
            {
                Enabled = true;
            }
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            panel.Enabled = false;
            panel.Visible = false;
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
                BackgroundColor = Color.FromArgb(245, 245, 237);
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
        private static class Win32Helper
        {
            public const int WM_SYSKEYDOWN = 0x0104,
                             WM_KEYDOWN = 0x0100,
                             WM_SETREDRAW = 0x000B;

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern bool PostMessage(System.Runtime.InteropServices.HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            panel.Location = new Point(this.Width / 2 - panel.Width / 2, this.Height / 2 - panel.Height / 2);
        }
        #endregion
    }
}
