using QTech.Component.Helpers;
using Storm.Domain;
using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EasyServer.Domain.SearchModels;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public partial class ExSearchListCombo : ComboBox
    {
        private bool textSearching = false;
        private List<ItemAction> _itemActions = new List<ItemAction>();
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ItemAction> ItemActions { get => _itemActions; set =>_itemActions = value; }
        public List<DropDownItemModel> SelectedItems { get; set; } 
        public DropDownItemModel SelectedObject { get; set; }

        public Func<ISearchModel, List<DropDownItemModel>> DataSourceFn { get; set; }
        public Func<ISearchModel> SearchParamFn { get; set; }
        public Func<Form> CustomSearchForm { get; set; }
        public bool IsGirdViewColumn { get; set; } = false;
        public bool AllowShowAll { get; set; } = true;
        public bool AllowNoSelected { get; set; } = false;

        string _textAll = string.Empty;
        [Browsable(false)]
        public string TextAll { get => _textAll;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _textAll = value;
                }
                else
                {
                    _textAll = string.Format(EDomain.Resources.All_, value);
                    bind(new List<DropDownItemModel>() { GetDropDownForAllText() });
                }
            }
        }

        string _choose = string.Empty;
        [Browsable(false)]
        public string Choose { get => _choose;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _choose = value;
                }
                else
                {
                    _choose = value;
                    bind(new List<DropDownItemModel>() { GetDropDownForAllText() });
                }

            }
        }
        private string OptionalItemText
        {
            get
            {
                return !string.IsNullOrEmpty(TextAll) ? TextAll : (!string.IsNullOrEmpty(Choose) ? Choose : string.Empty);
            }
        }

        public bool LoadAll { get; set; } = true;

        private bool _showSelected = false;

        public void SetValue<T>(T entity) 
            where T: QTech.Base.BaseModel
        {
            if (entity == null)
            {
                if (!string.IsNullOrEmpty(OptionalItemText))
                {
                    bind(new List<DropDownItemModel>() { GetDropDownForAllText() });
                    //this.Text = OptionalItemText;
                }
                else
                {
                    bind(null);
                }
                return;
            }
            if (entity is Lookup)
            {
                bind(new List<DropDownItemModel>() { (entity as Lookup).ToDropDownItemModel() });
                return;
            }
            //else if (entity is Location)
            //{
            //    bind(new List<DropDownItemModel>() { (entity as Location).ToDropDownItemModel() });
            //    return;
            //}
            var list = new List<DropDownItemModel>() { entity.ToDropDownItemModel() };
            bind(list);
        }

        public void SetValue(List<DropDownItemModel> list) 
        {
            if (list?.Count == 0)
            {
                if (!string.IsNullOrEmpty(OptionalItemText))
                {
                    bind(new List<DropDownItemModel>() { GetDropDownForAllText() });
                }
                return;
            } 
            bind(list);
        }

        public void SetEnumValue(Enum value)
        {
            if (value == null)
            {
                return;
            }
            var lst = new List<DropDownItemModel>()
            {
                new DropDownItemModel()
                {
                    Id = Convert.ToInt32(value),
                    Code = ResourceHelper.Translate(value),
                    Name = ResourceHelper.Translate(value),
                }
            };
            SetValue(lst);
        }

        public void SetGUIValue<T>(T entity)
            where T : GuidBaseModel
        {
            if (entity == null)
            {
                return;
            }
            var list = new List<DropDownItemModel>() { entity.ToDropDownItemModel() };
            bind(list);
        }

        public DropDownItemModel GetDropDownForAllText()
        {
            return new DropDownItemModel()
            {
                Id = 0,
                DisplayText =  OptionalItemText,
                Name = OptionalItemText,
                Code = OptionalItemText,
                ItemObject = null
            }; 
        }

        public ExSearchListCombo()
        {
            InitializeComponent();
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.Normal;
        }
         
        public void ShowDropDown()
        {
            this.HideValidationOnLeave();
            
            //Whe use default search dialog
            if (SearchParamFn == null || DataSourceFn == null)
            {
                return;
            }
            var searchParam = SearchParamFn();

            //var action = ItemActions?.FirstOrDefault(x => x.Keyword == Text);
            //if (action!=null)
            //{
            //    action.Action?.Invoke();
            //    return;
            //}


            // If user set request change search value.
            if (string.IsNullOrEmpty(searchParam.Search)&&Text!= OptionalItemText
                && Text !=SelectedObject?.Name)
            {
                searchParam.Search = Text;
            }
            // If Combo in TextAll mode.
            if (Text== OptionalItemText && string.IsNullOrEmpty(searchParam.Search))
            {
                searchParam.Search = "";
            }
            // User Search
            List<DropDownItemModel> list = null;
            if (textSearching && (!string.IsNullOrEmpty(searchParam.Search)))
            {
                list = DataSourceFn.Invoke(searchParam);
                if (list.Count == 1)
                {
                    bind(list);
                    searchParam.Search = string.Empty;
                    SendKeys.Send("{tab}");
                    return;
                }
            }

            //if (list == null && string.IsNullOrEmpty(searchParam.Search)
            //    && SelectedObject?.Name != OptionalItemText)
            //{
            //    searchParam.Search = SelectedObject?.Name;
            //}

            var itemForAll = string.IsNullOrEmpty(OptionalItemText) ? null : GetDropDownForAllText();
            if (SelectedItems?.Count() == 1 && !SelectedItems.FirstOrDefault().Id.Equals(itemForAll?.Id))
            {
                searchParam.Search = SelectedItems?.FirstOrDefault()?.Name ?? string.Empty;
            }

            using (var dig = new SelectListItemsDialog(DataSourceFn,
                searchParam,
                list,
                ItemActions,
                SelectedItems,
                LoadAll, _showSelected))
            {
                //When use custom search dialog
                if (CustomSearchForm != null)
                {
                    var cus = CustomSearchForm();
                    if (cus is ISearchForm form)
                    {
                        if (cus.ShowDialog() == DialogResult.OK)
                        {
                            if (form.SelectedObject != null)
                            {
                                var obj = form.SelectedObject;
                                List<DropDownItemModel> dropDownList = null;
                                if (obj is QTech.Base.BaseModel model)
                                {
                                    dropDownList = new List<QTech.Base.BaseModel>() { model }.ToDropDownItemModelList();
                                }
                                else if (obj is GuidBaseModel guidModel)
                                {
                                    dropDownList = new List<GuidBaseModel>() { guidModel }.ToDropDownItemModelListGui();
                                }
                                else if (obj is LongBaseModel longModel)
                                {
                                    dropDownList = new List<LongBaseModel>() { longModel }.ToDropDownItemModelListLong();
                                }
                                bind(dropDownList);
                                SendKeys.Send("{tab}");
                            }
                            else
                            {
                                bind(null);
                            }
                        }
                    }
                    return;
                }

                dig.AllowTextAll = !string.IsNullOrEmpty(TextAll);
                dig.MultiSelect = true;
                dig.AllowShowAll = AllowShowAll;
                dig.SelectAll = itemForAll?.Id.Equals(SelectedItems?.FirstOrDefault()?.Id) ?? false;
                dig.AllowNoSelected = AllowNoSelected;
                var result = dig.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _showSelected = dig.ShowSelected;
                    // this.SelectedList = dig.SelectedList;
                    if (dig.SelectedItems?.FirstOrDefault()?.ItemObject is ItemAction itemAction)
                    {
                        itemAction.Action?.Invoke();

                        return;
                    }
                    if (dig.SelectAll)
                    {
                        bind(new List<DropDownItemModel>() { itemForAll });
                    }
                    else if (dig.SelectedItems?.Count == 1)
                    {
                        bind(dig.SelectedItems);
                    }
                    else
                    {
                        var seleteds = dig.SelectedItems?.Select(x => new DropDownItemModel
                        {
                            Id = x.Id,
                            Code = x.Code,
                            Name = x.Name,
                            DisplayText = x.DisplayText,
                            ItemObject = x.ItemObject,
                        }).ToList();
                        var text = string.Format(Properties.Resources.Choosed_, seleteds?.Count().ToString("N0") ?? "0");

                        SelectedItems = seleteds;
                        bindList(new List<DropDownItemModel>()
                        {
                            new DropDownItemModel()
                            {
                                Id = 0,
                                Code = text,    
                                Name = text,
                                DisplayText = text,
                                ItemObject = seleteds,
                            }
                        });
                    }
                    this.Focus();
                    searchParam.Search = string.Empty;
                    SendKeys.Send("{tab}");

                }
                else
                {
                    if (Items.Count > 0)
                    {
                        SelectedIndex = 0;
                        this.Focus();
                        searchParam.Search = string.Empty;
                        // SendKeys.Send("{tab}");
                    }
                    if (!IsGirdViewColumn)
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }
        }

        // If change this, pls also change bindList().
        private void bind(List<DropDownItemModel> list)
        {
            SelectedItems = list;
            SelectedObject = list?.FirstOrDefault();
            if (list!=null)
            {
                this.SetDataSource2(SelectedItems);
                SelectedValue = SelectedObject?.Id;

                //SelectedItem = null;
                //SelectedObject = null;
            }
            else
            {
                DataSource = null;
            }
            DropDownStyle = ComboBoxStyle.DropDownList;
            textSearching = false;
        }

        private void bindList(List<DropDownItemModel> list)
        {
            SelectedObject = list?.FirstOrDefault();
            if (list != null)
            {
                this.SetDataSource2(list);
                SelectedValue = SelectedObject?.Id;
            }
            else
            {
                DataSource = null;
            }
            DropDownStyle = ComboBoxStyle.DropDownList;
            textSearching = false;
        }

        protected override void OnEnter(EventArgs e)
        {  
            if (DropDownStyle!= ComboBoxStyle.DropDown)
            {
                DropDownStyle = ComboBoxStyle.DropDown;
            }
            base.OnEnter(e);

            //DropDownStyle = ComboBoxStyle.DropDown;
        }
        
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
                 
            //    e.IsInputKey = false;
            //    if (DataSourceFn == null)
            //    {
            //        return;
            //    }
            //    ShowDropDown();
            //}
            //if (e.KeyData == Keys.Tab)
            //{
            //    e.IsInputKey = false;
            //    DropDownStyle = ComboBoxStyle.DropDownList;
            //}
            //if (e.KeyData == (Keys.Tab | Keys.Shift))
            //{
            //    DropDownStyle = ComboBoxStyle.DropDownList;
            //    e.IsInputKey = false;
            //} 
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            { 
                if (DataSourceFn == null)
                {
                    return base.ProcessCmdKey(ref msg,keyData);
                }
                ShowDropDown();
                return true;
            }
            if (keyData == Keys.Tab)
            {
                DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (keyData == (Keys.Tab | Keys.Shift))
            {
                DropDownStyle = ComboBoxStyle.DropDownList;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            int WM_SYSKEYDOWN = 0x104;

            bool handled = false;

            if (msg.Msg == WM_SYSKEYDOWN)
            {
                Keys keyCode = (Keys)msg.WParam & Keys.KeyCode;

                switch (keyCode)
                {
                    case Keys.Down:
                        handled = true;
                        break;
                }
            }

            if (false == handled)
                handled = base.PreProcessMessage(ref msg);

            return handled;
        }

        // [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == 0x201)
            {
                ShowDropDown();
                return;
            }

            if (m.Msg == 0x203)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void ExSearchCombo_TextChanged(object sender, EventArgs e)
        {
            textSearching = true;
        }
    }
}
