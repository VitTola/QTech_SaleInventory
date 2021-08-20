using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QTech.Component
{
    public class ExSearchComboColumn : DataGridViewColumn
    {
        public ExSearchComboColumn() : base(new ExSearchComboCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                ExSearchComboCell dataGridViewComboBoxCell = value as ExSearchComboCell;
                // Ensure that the cell used for the template is a TimeCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(ExSearchComboCell)))
                {
                    throw new InvalidCastException("Must be a ExSearchComboCell");
                }
                base.CellTemplate = value;
            }
        }
        public Func<QTech.Base.BaseModels.ISearchModel, List<DropDownItemModel>> DataSourceFn { get; set; }
        public Func<QTech.Base.BaseModels.ISearchModel> SearchParamFn { get; set; }
        public Func<Form> CustomSearchForm { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ItemAction> ItemActions { get; set; } = new List<ItemAction>();
        public string TextAll { get; set; }
        public string Choose { get; set; }

        /// <summary>
        /// 2020-03-26 @LYHORNG.
        /// for show all option on pagination.
        /// </summary>
        public bool ShowAll { get; set; } = false;
    }
    public class ExSearchComboCell : DataGridViewTextBoxCell
    {
        public ExSearchComboCell() : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            var editor = DataGridView.EditingControl as ExSearchComboCellEditingControl;
            var col = OwningColumn as ExSearchComboColumn;
            if (editor.DataSourceFn == null)
            {
                editor.DataSourceFn = col.DataSourceFn;
            }
            if (editor.SearchParamFn == null)
            {
                editor.SearchParamFn = col.SearchParamFn;
            }
            if (string.IsNullOrEmpty(editor.TextAll) && !string.IsNullOrEmpty(col.TextAll))
            {
                editor.TextAll = col.TextAll;
            }
            if (string.IsNullOrEmpty(editor.Choose) && !string.IsNullOrEmpty(col.Choose))
            {
                editor.Choose = col.Choose;
            }
            editor.ShowAll = col.ShowAll;
            if (Value is QTech.Base.BaseModel baseModel)
            {
                SelectedObject = baseModel.ToDropDownItemModel();
                editor.SetValue(baseModel);
            }
            else if (Value == null)
            {
                DropDownItems = new List<DropDownItemModel>();
                SelectedObject = null;
                editor.SetValue(null);
            }
            else
            {
                SelectedObject = DropDownItems?.FirstOrDefault();
                editor.SetValue(DropDownItems);
            }
        }

        public List<DropDownItemModel> DropDownItems { get; set; }
        public DropDownItemModel SelectedObject { get; set; }

        public override Type EditType
        {
            get
            {
                return typeof(ExSearchComboCellEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(object);
            }
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(object);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }

        //protected override object GetValue(int rowIndex)
        //{
        //    return SelectedObject?.Id;
        //} 

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is QTech.Base.BaseModel val)
            {
                SelectedObject = val.ToDropDownItemModel();
                DropDownItems = new List<DropDownItemModel>() { SelectedObject };
                Value = SelectedObject.Id;
            }
            else if (value is List<DropDownItemModel> list)
            {
                SelectedObject = list.FirstOrDefault();
                DropDownItems = list;
                Value = SelectedObject.Id;
            }
            else if (value == null)
            {
                SelectedObject = null;
                DropDownItems = new List<DropDownItemModel>(); 
            }
            return SelectedObject?.Code ?? "";
        }
    }

    public class ExSearchComboCellEditingControl : ExSearchCombo, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public ExSearchComboCellEditingControl()
        {
        }


        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return SelectedValue;
            }
            set
            {
                if (value is QTech.Base.BaseModel val)
                {
                    SetValue(val);
                }
                else if (value is List<DropDownItemModel> valList)
                {
                    SetValue(valList);
                }
                else if (value is int valInt)
                {
                    SelectedValue = valInt;
                }
            }
        }
        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            ExSearchComboColumn col = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex] as ExSearchComboColumn;
            if (col == null)
            {
                throw new InvalidCastException("Must be in a DropDownComboBoxColumn");
            }
            DataSourceFn = col.DataSourceFn; 
            SearchParamFn = col.SearchParamFn;
            ItemActions = col.ItemActions;
            CustomSearchForm = col.CustomSearchForm;
            IsGirdViewColumn = true;
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            valueChanged = true;
            var cell = EditingControlDataGridView.CurrentCell as ExSearchComboCell;
            cell.DropDownItems = SelectedItems;
            cell.SelectedObject = SelectedObject;
            this.EditingControlDataGridView.CurrentCell.Value = this.SelectedValue;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnSelectedIndexChanged(e);
        }

    }
}
