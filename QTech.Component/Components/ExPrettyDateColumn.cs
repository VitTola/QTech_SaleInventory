using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace QTech.Component
{
    public class ExPrettyDateColumn : DataGridViewColumn
    {
        public ExPrettyDateColumn() : base(new ExPrettyDateCell())
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
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(ExPrettyDateCell)))
                {
                    throw new InvalidCastException("Must be a ExPrettyDateCell");
                }
                base.CellTemplate = value;
            }
        } 
         
        public class ExPrettyDateCell : DataGridViewTextBoxCell
        {

            public ExPrettyDateCell()
                : base()
            {
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                ExPrettyDateEditingControl ctl =
                    DataGridView.EditingControl as ExPrettyDateEditingControl;
                // Use the default row value when Value property is null.
                if (Value == null)
                {
                    ctl.Value = (DateTime)DefaultNewRowValue;
                }
                else
                {
                    ctl.Value = (DateTime)Value; 
                }
            }

            protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
            {
                if (value is DateTime val)
                {
                    this.ToolTipText = val.ToString("F");
                    return val.GetPrettyDate();
                } 
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing control that CalendarCell uses.
                    return typeof(ExPrettyDateEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.

                    return typeof(DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return DateTime.Now;
                }
            }
        }

        class ExPrettyDateEditingControl : ExPrettyDate, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public ExPrettyDateEditingControl()
            {
                
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Value.GetPrettyDate();
                }
                set
                {
                    if (value is String val)
                    {
                        try
                        {
                            Value = DateTime.Parse(val);
                        }
                        catch
                        {
                            Value = DateTime.Now;
                        }
                        
                         
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
                //var col = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex] as ExPrettyDateColumn;
                //if (col == null)
                //{
                //    throw new InvalidCastException("Must be in a ExPrettyDateColumn");
                //}
                //this.DataBindings.Add(nameof(Value), dataGridView.DataSource, nameof(col.DataPropertyName));
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
