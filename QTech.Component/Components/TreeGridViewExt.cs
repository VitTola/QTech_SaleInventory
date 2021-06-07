using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QTech.Component
{
    //public static class TreeGridViewExt
    //{
    //    public static void EnableExpandContextMenuScript(this TreeGridView tgv)
    //    {
    //        var contextMenu = new ContextMenuStrip();
    //        contextMenu.Cursor = Cursors.Hand;
    //        contextMenu.Font = new Font("Khmer Kep", 9.75F);

    //        contextMenu.Items.Add(Resources.Level0);
    //        contextMenu.Items.Add(Resources.Level1);
    //        contextMenu.Items.Add(Resources.Level2);
    //        contextMenu.Items.Add(Resources.Level3);
    //        contextMenu.Items.Add(Resources.Level4);
    //        contextMenu.Items.Add(Resources.LevelAll);

    //        contextMenu.Items[0].Image =
    //            contextMenu.Items[1].Image =
    //                contextMenu.Items[2].Image =
    //                    contextMenu.Items[3].Image =
    //                        contextMenu.Items[4].Image =
    //                            contextMenu.Items[5].Image = Resources.imgSubsitemap;

    //        contextMenu.Items[0].Click += (object s, EventArgs e) => ExpandNode(tgv, 0);
    //        contextMenu.Items[1].Click += (object s, EventArgs e) => ExpandNode(tgv, 1);
    //        contextMenu.Items[2].Click += (object s, EventArgs e) => ExpandNode(tgv, 2);
    //        contextMenu.Items[3].Click += (object s, EventArgs e) => ExpandNode(tgv, 3);
    //        contextMenu.Items[4].Click += (object s, EventArgs e) => ExpandNode(tgv, 4);
    //        contextMenu.Items[5].Click += (object s, EventArgs e) => ExpandNode(tgv, 100);

    //        tgv.ContextMenuStrip = contextMenu;
    //    }

    //    public static void ExpandNode(this TreeGridView tgv,int nested=1)
    //    {
    //        foreach(TreeGridNode node in tgv.Nodes)
    //        {
    //            ExpandNode(node, nested);
    //        }
    //    }

    //    private static void ExpandNode(TreeGridNode node, int nested=0)
    //    {
    //        if (node.Nodes.Count == 0)
    //        {
    //            return;
    //        }
    //        if (nested > 0)
    //        {
    //            node.Expand();
    //        }
    //        else
    //        {
    //            node.Collapse();
    //        }
    //        if (nested < 1)
    //        {
    //            return;
    //        }
    //        foreach (TreeGridNode child in node.Nodes)
    //        {
    //            if (nested > 0)
    //            {
    //                ExpandNode(child, nested - 1);
    //            }
    //            else
    //            {
    //                child.Collapse();
    //            }
    //        }
    //    }
    //}
}
