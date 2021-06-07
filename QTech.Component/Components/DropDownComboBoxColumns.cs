using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QTech.Component
{
    public class DropDownComboBoxColumn : DataGridViewColumn
    {
        public DropDownComboBoxColumn() : base(new DropDownComboBoxCell())
        {
            
        }
        public ComboBoxStyle DropDownStyle { get; set; }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DropDownComboBoxCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }

        public List<object> Items { get; set; } = new List<object>();
         
        public class DropDownComboBoxCell : DataGridViewTextBoxCell
        {

            public DropDownComboBoxCell()
                : base()
            {
                
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                DropDownComboBoxEditingControl ctl =
                    DataGridView.EditingControl as DropDownComboBoxEditingControl;
                // Use the default row value when Value property is null.
                if (Value == null)
                {
                    ctl.Text = DefaultNewRowValue.ToString();
                }
                else
                {
                    ctl.Text =  Value.ToString();
                }
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing control that CalendarCell uses.
                    return typeof(DropDownComboBoxEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.

                    return typeof(string);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return string.Empty;
                }
            }

            
        }

        class DropDownComboBoxEditingControl : ComboBox, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public DropDownComboBoxEditingControl()
            {
                
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return Text;
                }
                set
                {
                    if (value is String val)
                    { 
                            Text = val;
                         
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
                ForeColor = dataGridViewCellStyle.ForeColor;
                BackColor = dataGridViewCellStyle.BackColor;
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
                DropDownComboBoxColumn col = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex] as DropDownComboBoxColumn;
                if (col == null)
                {
                    throw new InvalidCastException("Must be in a DropDownComboBoxColumn");
                }
                Items.Clear(); 
                DropDownStyle = col.DropDownStyle;
                Items.AddRange(col.Items.ToArray());

                
                //foreach (var item in col.Items)
                //{
                //    Items.Add(item);
                //}
                // (If you don't explicitly set the Text then the current value is
                // always replaced with one from the drop-down list when edit begins.)
                Text = dataGridView.CurrentCell.Value as string;
                SelectAll();
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
            

            protected override void OnTextChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnTextChanged(eventargs);
            }
        } 
    }
}
