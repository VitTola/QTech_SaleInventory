using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component.Components
{
    public class DataGridViewTextImageColumn : DataGridViewTextBoxColumn
    {
        public ImageList ImageList { get; set; } = new ImageList();

        public DataGridViewTextImageColumn()
        {
            this.CellTemplate = new DataGridViewTextImageCell();
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
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewTextImageCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewTextImageCell");
                }
                base.CellTemplate = value;
            }
        }

        private DataGridViewTextImageCell TextAndImageCellTemplate
        {
            get { return this.CellTemplate as DataGridViewTextImageCell; }
        }
    }

    public class DataGridViewTextImageCell : DataGridViewTextBoxCell
    {
        public DataGridViewTextImageCell() : base()
        {
              
        }
        
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            //MessageBox.Show($"{ValueType.Name}, is enum = {ValueType.IsEnum}");
            if (ValueType.IsEnum)
            {
                value = Enum.Parse(ValueType, value.ToString());
            }
            if (value is Enum @enum)
            {
                return ResourceHelper.Translate(@enum);
            }
            
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
        Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        object value, object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            var imageList = OwningTextAndImageColumn.ImageList;
            if ((imageList?.Images?.Count??0)>0)
            {
                imageList.TransparentColor = cellStyle.SelectionBackColor;
                cellStyle.Padding = new Padding(imageList.ImageSize.Width, InheritedStyle.Padding.Top,
                    InheritedStyle.Padding.Right,
                    InheritedStyle.Padding.Bottom);
            }

            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
               value, formattedValue, errorText, cellStyle,
               advancedBorderStyle, paintParts);

            if (ValueType.IsEnum)
            {
                value = Enum.Parse(ValueType, value?.ToString());
            }
            
            var key = value?.ToString()??string.Empty;
            if (imageList.Images?.ContainsKey(key)==true)
            {
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();
                graphics.SetClip(cellBounds);
                Point imageLocation = new Point(cellBounds.Location.X, cellBounds.Location.Y + (cellBounds.Height - imageList.ImageSize.Height) / 2);
                imageList.Draw(graphics,imageLocation, imageList.Images.IndexOfKey(key));
                graphics.EndContainer(container);
            } 
        }

        private DataGridViewTextImageColumn OwningTextAndImageColumn
        {
            get { return this.OwningColumn as DataGridViewTextImageColumn; }
        }

        public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle inheritedCellStyle, int rowIndex, bool includeColors)
        {
            //if ((OwningTextAndImageColumn.ImageList?.Images?.Count??0)>0)
            //{
            //    OwningTextAndImageColumn.ImageList.TransparentColor = inheritedCellStyle.SelectionBackColor;
            //    this.Style.Padding = new Padding(OwningTextAndImageColumn.ImageList.ImageSize.Width, inheritedCellStyle.Padding.Top,
            //        inheritedCellStyle.Padding.Right,
            //        inheritedCellStyle.Padding.Bottom);
            //} 
            return base.GetInheritedStyle(inheritedCellStyle, rowIndex, includeColors);
        }



    }

}
