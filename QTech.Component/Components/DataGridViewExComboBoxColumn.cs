using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QTech.Component
{
    public class DataGridViewExComboBoxColumn : DataGridViewColumn
    {
        public DataGridViewExComboBoxColumn(): base(new DataGridViewExComboBoxCell())
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
                DataGridViewExComboBoxCell dataGridViewComboBoxCell = value as DataGridViewExComboBoxCell;
                // Ensure that the cell used for the template is a TimeCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewExComboBoxCell)))
                {
                    throw new InvalidCastException("Must be a ExComboBox");
                }
                base.CellTemplate = value;
            }
        }

        public Func<IDropDownPanel> DropDownPanel { get; set; }
        


    }

    public class DataGridViewExComboBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewExComboBoxCell(): base()
        {
            Style.Format = "#";
        } 
        
        public new object Value
        {
            get
            {
                return base.Value; 
            }
            set
            {
                // this.SelectedValue = value; 
                if (DropDownPanel.Parent != null)
                {
                    DropDownPanel.Parent.Value = value;
                }
                base.Value = value; 
            }
        }

        public new object FormattedValue
        {
            get
            {
                return DropDownPanel.GetDisplayText(base.Value);
            } 
        }

        private IDropDownPanel dropDownPanel = null;
        public IDropDownPanel DropDownPanel
        {
            get { 
                if (OwningColumn is DataGridViewExComboBoxColumn)
                {
                    var col = (DataGridViewExComboBoxColumn)OwningColumn;
                    if (dropDownPanel == null && col.DropDownPanel!=null)
                    {
                        dropDownPanel = col.DropDownPanel();
                    }
                    return dropDownPanel;
                }
                return null;
            }
        }

        

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
           
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            var editor = DataGridView.EditingControl as DataGridViewExComboBoxCellEditingControl;
            if (editor.DropDownPanel == null)
            {
                editor.DropDownPanel = DropDownPanel;
            }
            editor.Value = Value; 
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        { 
            var fv = DropDownPanel?.GetDisplayText(value);
            return fv;
        } 

        public override Type EditType
        {
            get
            { 
                return typeof(DataGridViewExComboBoxCellEditingControl);
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
    }

    public class DataGridViewExComboBoxCellEditingControl : ExComboBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public DataGridViewExComboBoxCellEditingControl()
        {
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            { 
                var val = Value;
                return val;
            }
            set
            {
                if (value is String)
                {
                    var v = 0;
                    int.TryParse(value.ToString(),out v);
                    Value = v;
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
            // No preparation needs to be done.
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

        protected override void OnValueChanged(EventArgs eventargs)
        { 
            valueChanged = true;
            EditingControlDataGridView.CurrentCell.Value = Value;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs); 
        }
    }

}
