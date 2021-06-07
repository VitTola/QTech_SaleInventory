using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class TreeViewCheck : TreeView
    {
        public bool CheckParentChild { get; set; } = false;
        public TreeViewCheck()
        {
            InitializeComponent();
        }

        public TreeViewCheck(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203)
            {
                var localPos = PointToClient(Cursor.Position);
                var hitTestInfo = HitTest(localPos);
                if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                    m.Result = IntPtr.Zero;
                else
                    base.WndProc(ref m);
            }
            else base.WndProc(ref m);
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            if (CheckParentChild && e.Action == TreeViewAction.ByMouse)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                    SetChild(node, e.Node.Checked);
                }
                if (e.Node.Parent != null)
                    SetParent(e.Node.Parent);
            }
        }

        private void SetChild(TreeNode Node, bool Check)
        {
            foreach (TreeNode node in Node.Nodes)
            {
                node.Checked = Node.Checked;
                SetChild(node, Check);
            }
        }

        private void SetParent(TreeNode Node)
        {
            bool IsCheck = false;
            foreach (TreeNode node in Node.Nodes)
            {
                if (node.Checked)
                {
                    IsCheck = true;
                    break;
                }
            }
            Node.Checked = IsCheck;
            if (Node.Parent != null)
                SetParent(Node.Parent);
        }
    }
}
