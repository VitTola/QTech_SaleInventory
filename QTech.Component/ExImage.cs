using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExImage : UserControl
    {
        public ExImage()
        {
            InitializeComponent();
            body.WrapContents = false;
        }

        private void InitImage()
        {
            body.Controls.Clear();
            for (int i = 0; i < 10; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Size = new Size(65, 74);
                picture.ImageLocation = @"C:\Users\Sothea\Pictures\data-security-icons.jpg";
                picture.Margin = new Padding(2,1,1,1);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Anchor = AnchorStyles.Bottom;
                picture.Anchor = AnchorStyles.Top;
                picture.Anchor = AnchorStyles.Left;
                picture.Anchor = AnchorStyles.Right;
                body.Controls.Add(picture);
            }
        }
    }
}
