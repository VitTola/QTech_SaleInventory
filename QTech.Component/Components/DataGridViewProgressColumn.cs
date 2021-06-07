using EasyServer.Domain.Helpers;
using Storm.Component.Components;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.Components
{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }
}

namespace Storm.Component.Components
{
    public class DataGridViewProgressCell: DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
        }

        public override object DefaultNewRowValue => new ProgressInfo() { Message = string.Empty, Progress = 0 };
        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            
            try
            {
                int progressVal = 0;
                string info = "";
                if (value == null)
                {
                    value = DefaultNewRowValue;
                }
                if (value.GetType().Name == typeof(ProgressInfo).Name)
                {
                    var pInfo = (ProgressInfo)value;
                    info = pInfo.Message;
                    progressVal = (int)pInfo.Progress;
                }
                else
                {
                    info = value.ToString();
                }

                float percentage = ((float)progressVal / 100.0f); // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                Brush foreColorBrushWhite = new SolidBrush(Color.White);
                // Draws the cell grid
                base.Paint(g, clipBounds, cellBounds,
                 rowIndex, cellState, value, formattedValue, errorText,
                 cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                if (progressVal > 0 && progressVal<=100)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100,135, 90, 123)), cellBounds.X + 2, cellBounds.Y + 10, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 20);
                    g.DrawString($"{info} ({progressVal.ToString()}%)", cellStyle.Font, foreColorBrush, cellBounds.X+5 /*+ (cellBounds.Width / 2) - 5*/, cellBounds.Y + 4);
                }
                else if(value!=null)
                {
                    g.DrawString(info, cellStyle.Font, foreColorBrush, cellBounds.X, cellBounds.Y + 4);
                }
            }
            catch (Exception e) { }

        }


    }
}
    
