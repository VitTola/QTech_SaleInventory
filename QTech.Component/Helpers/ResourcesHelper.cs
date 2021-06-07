using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace QTech.Component
{ 
        public class ResourceHelper
        {
            private static List<ResourceManager> resxmgr = new List<ResourceManager>();

            public static void Register(ResourceManager resourceManager)
            { 
                if (!resxmgr.Contains(resourceManager))
                {
                    resxmgr.Add(resourceManager);
                } 
            }
        public static void ApplyResource(Control control, params Type[] types)
        {
            if (control is TabControl)
            {
                foreach (TabPage tab in ((TabControl)control).TabPages)
                {
                    if (!IsNotApplyRes(tab.Name))
                    {
                        tab.Text = Translate(ToResouceKey(tab.Name));
                    }

                    ApplyResource(tab);
                }
                return;
            }
            if (control is DataGridView)
            {
                foreach (DataGridViewColumn col in ((DataGridView)control).Columns)
                {
                    if (!IsNotApplyRes(col.Name))
                    {
                        col.HeaderText = Translate(ToResouceKey(col.Name));
                    }
                }
                return;
            }
            if (control is PlaceholderTextBox)
            {
                ApplyResource(control as PlaceholderTextBox);
                return;
            }
            if (control is ExDialog)
            {
                var diag = (ExDialog)control;
                //if (!IsNotApplyRes(diag.Name))
                //{
                //    diag.Text = Translate(IdentifierToResourceKey(diag.Name));
                //}
                ApplyResource(diag.container);
                return;
            }
            if (control is SplitContainer)
            {
                var split = (SplitContainer)control;
                ApplyResource(split.Panel1);
                ApplyResource(split.Panel2);
            }
            if (control is ContextMenuStrip)
            {
                foreach (ToolStripItem item in ((ContextMenuStrip)control).Items)
                {
                    ApplyResource(item);
                }

            } 
            foreach (Control c in control.Controls)
            {
                if (c is Label
                    || c is LinkLabel
                    || c is CheckBox
                    || c is Button
                    || c is RadioButton
                    || c is Panel
                    || c is DataGridView
                    //|| c is TabPage
                    || c is TabControl
                    //|| c is ExMenuItem
                    || c is SplitContainer
                    || c is SplitterPanel
                    || c is Form
                    || c is GroupBox 
                    || c is PlaceholderTextBox
                    || types.Any(x => x == c.GetType()))
                {
                    ApplyResource(c, types);
                }
            }

            if (IsNotApplyRes(control.Name))
            {
                return;
            }

            // control name must no be end with _ or number
            if ((control is TabPage || control is Panel || control is TabControl || control is SplitContainer) )
            {
                return; 
            }
            
            
            string key = ToResouceKey(control.Name);
            string res = Translate(key);
            if (res != null)
            {
                control.Text = res;
            }
        }
        static void ApplyResource(ToolStripItem item)
        {
            string key = ToResouceKey(item.Name);
            string res = Translate(key);
            if (res != null)
            {
                item.Text = res;
            }
        }

        static void ApplyResource(PlaceholderTextBox item)
        {
            string key = ToResouceKey(item.Name);
            if (item.Name.StartsWith("txt"))
            {
                key = item.Name.Replace("txt", "");
            }
            string res = Translate(key);
            if (res != null)
            {
                item.PlaceHolder = res;
            }
        }

        /// <summary>
        /// Converts from identifier to resource e.g from DialogItemCategory to ITEM_CATEGORY.
        /// </summary>
        /// <param name="text">identifier name.</param>
        /// <returns></returns>
        public static string IdentifierToResourceKey(string text)
            {
                //text = text.Replace("Dialog", "");
                //StringBuilder s = new StringBuilder();
                //foreach (var c in text.ToCharArray())
                //{
                //    if (Char.IsUpper(c) && s.Length>0)
                //    {
                //        s.Append("_");
                //    }
                //    s.Append(c.ToString().ToUpper());
                //}
                //return s.ToString();
                return text;
            }

            public static string ToResouceKey(string text)
            {
                return text
                        .Replace("btn", "")
                        .Replace("lbl", "")
                        .Replace("chk", "")
                        .Replace("Dialog", "")
                        .Replace("tab", "") //Tab
                        .Replace("nav", "")
                        .Replace("Page", "")
                        .Replace("col", "") // DataGridViewColumn
                        .Replace("rdb", "") // RadioButton
                        .Replace("grb","") // GroupBox
                        //.ToUpper()
                        .Replace(" ", "_")
                        .Replace("_1", "") // 5 same resources
                        .Replace("_2", "")
                        .Replace("_3", "")
                        .Replace("_4", "")
                        .Replace("_5", "");
            }

            public static bool IsNotApplyRes(string key)
            {
                key = key.Replace("_1", "") // 5 same resources
                    .Replace("_2", "")
                    .Replace("_3", "")
                    .Replace("_4", "")
                    .Replace("_5", "");

                return  key.StartsWith("txt") ||  // some label start with txt
                        key.EndsWith("_") ||
                        key.StartsWith("_") ||
                        key.EndsWith("0") ||
                        key.EndsWith("1") ||
                        key.EndsWith("2") ||
                        key.EndsWith("3") ||
                        key.EndsWith("4") ||
                        key.EndsWith("5") ||
                        key.EndsWith("6") ||
                        key.EndsWith("7") ||
                        key.EndsWith("8") ||
                        key.EndsWith("9");
            }
            public static string Translate(string key)
            {
                object res = key; 
                if (resxmgr.Any())
                {
                    foreach (var mgr in resxmgr)
                    {
                        res = mgr.GetObject(key);
                        if (res != null & (res is string))
                        {
                            return res.ToString();
                        }
                    }
                }
                return key;
            }
            public static string Translate(Enum @enum)
            {
                var key = $"{@enum.GetType().Name}_{@enum.ToString()}";
                return Translate(key); 
            }
        }
    } 