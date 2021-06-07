using System;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExTabBar : UserControl
    {
        private enum ItemMarginSetting
        {
            Left = 1,
            Right = 1,
            Bottom = 0,
            Top = 3
        }

        private FlowDirection _defaultDirection = FlowDirection.RightToLeft;
       // private Color _defaultBackColor = Color.Silver;
        private Font _defaultFont = new Font(new FontFamily("Khmer OS System"), 8);

        public ExTabBar()
        {
            InitializeComponent();
            ApplyPanelSetting();
        }

        public FlowDirection FlowDirection
        {
            get
            {
                return _body.FlowDirection;
            }
            set
            {
                _body.FlowDirection = _defaultDirection;
                if (value != _defaultDirection)
                {
                    _body.FlowDirection = value;
                }
            }
        }
        private void ApplyPanelSetting()
        {
            _body.FlowDirection = _defaultDirection;
           // _body.BackColor = _defaultBackColor;
            _body.Padding = new Padding(left: 1, right: 1, bottom: 0, top: 2);
            _body.Height = 27;
            //_body.AutoScroll = true;
            _body.AutoSize = true;
        }

        private Tuple<int, int> GetAllChildWidthAndHeight()
        {
            int childHeight = 0;
            int allChildWidth = 0;
            foreach (Control child in _body.Controls)
            {
                if (childHeight == 0) childHeight = child.Height;
                var width = child.Width;
                allChildWidth = allChildWidth + width;
            }

            return new Tuple<int, int>(childHeight, allChildWidth);
        }

        private int GetTotalRow(int allChildWidth)
        {
            var maxRowWidth = _body.Width;
            int rowCount = 1;
            bool shouldStop = false;
            int tmpWidth = allChildWidth;
            while (shouldStop != true)
            {
                tmpWidth = tmpWidth - maxRowWidth;
                if (tmpWidth < 0 || 
                    tmpWidth == 0 || 
                    tmpWidth < maxRowWidth)
                {
                    shouldStop = true;
                }
                rowCount++;
            }

            return rowCount;
        }

        public void CheckBodyHeight()
        {
            var childWidthAndHieght = GetAllChildWidthAndHeight();
            var allChildWidth = childWidthAndHieght.Item2;
            var childHeight = childWidthAndHieght.Item1;
            
            int totalRows = GetTotalRow(allChildWidth);
            var height = ((childHeight -1) * totalRows);
            Height = _body.Height = height;
        }

        public void AddTabItem(ExTabItem tabItem)
        {
            ////Margin
            tabItem.Margin = new Padding()
            {
                Left = (int)ItemMarginSetting.Left,
                Top = (int)ItemMarginSetting.Top,
                Right = (int)ItemMarginSetting.Right,
                Bottom = (int)ItemMarginSetting.Bottom
            };
            tabItem.Font = _defaultFont;
            tabItem.TextAlignment = ContentAlignment.MiddleCenter;
            tabItem.Dock = DockStyle.Bottom;
            var width = (tabItem.Text.Length + (tabItem.Image?.Size.Width ?? 16));
            tabItem.Width = (width * 2) + (width * 2) + 5;
            //tabItem.Height = (tabItem.Font.Size > (tabItem.Image?.Height ?? 0)) ?
            //    (int)tabItem.Font.Size + 9 : (tabItem.Image?.Height ?? 0) + 9;
            tabItem.Height = 25;

            _body.Controls.Add(tabItem);
            //CheckBodyHeight();
        }
    }
}
