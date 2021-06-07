//namespace Storm.Component
//{
//    using System;
//    using System.Drawing;
//    using System.Drawing.Design;
//    using System.Drawing.Imaging;
//    using System.Drawing.Drawing2D;
//    using System.Drawing.Text;

//    using System.Collections;
//    using System.ComponentModel;
//    using System.ComponentModel.Design;
//    using System.Globalization;
//    using System.Runtime.CompilerServices;
//    using System.Windows.Forms;
//    using System.Drawing.Design;

//    /// <summary>
//    /// GRAPanel extened panel for Gradient, Rounding, and Alpha the panel.
//    /// </summary>
//    public class GRAPanel : Panel
//    {
//        private static ArrayList __ENCList = new ArrayList();
//        private bool bBorder;
//        private bool bGradient;
//        private bool bGrayscale;
//        private bool bRoundCorners;
//        private Color clBorder;
//        private ColorWithAlphaCollection clGradient;
//        private Corners eCorners;
//        private ImagePositions eImagePosition;
//        private LinearGradientMode gmMode;
//        private int iCornerRadius;
//        private int iImageAlpha;
//        private System.Drawing.Image imImage;
//        private Padding pdContent;
//        private Padding pdImage;
//        private float snOffset;
//        private Size szGradient;
//        private Size szImageSize;
//        private WrapMode wmWrap;

//        public GRAPanel()
//        {
//            base.FontChanged += new EventHandler(AlphaGradientPanel_FontChanged);
//            base.PaddingChanged += new EventHandler(AlphaGradientPanel_PaddingChanged);
//            base.Paint += new PaintEventHandler(AlphaGradientPanel_Paint);
//            ArrayList VBt_refL0 = __ENCList;
//            lock (VBt_refL0)
//            {
//                __ENCList.Add(new WeakReference(this));
//            }
//            bRoundCorners = true;
//            eCorners = Corners.All;
//            clBorder = SystemColors.ActiveBorder;
//            bGradient = true;
//            bBorder = true;
//            iCornerRadius = 20;
//            gmMode = LinearGradientMode.Vertical;
//            eImagePosition = ImagePositions.BottomRight;
//            szImageSize = new Size(0x30, 0x30);
//            iImageAlpha = 0x4b;
//            pdImage = new Padding(5);
//            pdContent = new Padding(0);
//            bGrayscale = false;
//            wmWrap = WrapMode.Tile;
//            snOffset = 1f;
//            clGradient = new ColorWithAlphaCollection(this);
//            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
//            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
//            SetStyle(ControlStyles.ResizeRedraw, true);
//            BackColor = Color.Transparent;
//        }

//        private void AlphaGradientPanel_FontChanged(object sender, EventArgs e)
//        {
//            Invalidate();
//        }

//        private void AlphaGradientPanel_PaddingChanged(object sender, EventArgs e)
//        {
//            Invalidate();
//        }

//        private void AlphaGradientPanel_Paint(object sender, PaintEventArgs e)
//        {
//            Brush brBrush;
//            Rectangle rcClient = new Rectangle(ContentPadding.Left, ContentPadding.Top, (Width - ContentPadding.Right) - ContentPadding.Left, (Height - ContentPadding.Bottom) - ContentPadding.Top);
//            if (Gradient)
//            {
//                Rectangle rcBrush;
//                Size VBt_structN7 = new Size(0, 0);
//                if (!(GradientSize == VBt_structN7))
//                {
//                    rcBrush = new Rectangle(0, 0, GradientSize.Width, GradientSize.Height);
//                }
//                else
//                {
//                    rcBrush = rcClient;
//                }
//                if (Colors.Count > 1)
//                {
//                    brBrush = new LinearGradientBrush(rcBrush, Color.White, Color.White, GradientMode);
//                    LinearGradientBrush VBt_refL0 = (LinearGradientBrush)brBrush;
//                    if (GradientWrapMode == WrapMode.Clamp)
//                    {
//                        GradientWrapMode = WrapMode.Tile;
//                    }
//                    VBt_refL0.WrapMode = GradientWrapMode;
//                    VBt_refL0.SetSigmaBellShape(snOffset);
//                    ColorBlend cb = new ColorBlend(Colors.Count);
//                    int VBt_i4L0 = Colors.Count - 1;
//                    for (int i = 0; i <= VBt_i4L0; i++)
//                    {
//                        cb.Positions[i] = (1f / ((float)(cb.Positions.Length - 1))) * i;
//                        cb.Colors[i] = Color.FromArgb(Colors[i].Alpha, Colors[i].Color.R, Colors[i].Color.G, Colors[i].Color.B);
//                    }
//                    VBt_refL0.InterpolationColors = cb;
//                    VBt_refL0 = null;
//                }
//                else
//                {
//                    brBrush = new SolidBrush(Color.Transparent);
//                    e.Graphics.DrawString("[GRADIENT] Not enough color (at least 2 needed)", SystemFonts.DialogFont, Brushes.Black, (float)5f, (float)5f);
//                }
//            }
//            else if (Colors.Count > 0)
//            {
//                ColorWithAlpha cwa = Colors[0];
//                brBrush = new SolidBrush(Color.FromArgb(cwa.Alpha, cwa.Color.R, cwa.Color.G, cwa.Color.B));
//            }
//            else
//            {
//                brBrush = new SolidBrush(Color.Transparent);
//                e.Graphics.DrawString("[SOLID] Not enough color (at least 1 needed)", SystemFonts.DialogFont, Brushes.Black, (float)5f, (float)5f);
//            }
//            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
//            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
//            e.Graphics.CompositingMode = CompositingMode.SourceOver;
//            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
//            Rectangle rcBorder = new Rectangle(rcClient.X, rcClient.Y, rcClient.Width - 1, rcClient.Height - 1);
//            Rectangle rcContent = rcClient;
//            if (Rounded)
//            {
//                e.Graphics.FillPath(brBrush, DrawingHelper.RoundedRect(rcContent, iCornerRadius, Corners));
//                if (Border)
//                {
//                    e.Graphics.DrawPath(new Pen(BorderColor), DrawingHelper.RoundedRect(rcBorder, iCornerRadius, Corners));
//                }
//            }
//            else
//            {
//                e.Graphics.FillRectangle(brBrush, rcContent);
//                if (Border)
//                {
//                    e.Graphics.DrawRectangle(new Pen(BorderColor), rcBorder);
//                }
//            }
//            if (Image != null)
//            {
//                ColorMatrix clrMatrix;
//                Rectangle rcImage = new Rectangle();
//                Bitmap btBitmap = (Bitmap)Image;
//                float[][] arArray = new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, (float)(((double)ImageAlpha) / 100.0), 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } };
//                if (Grayscale)
//                {
//                    clrMatrix = new ColorMatrix(new float[][] { new float[] { 0.299f, 0.299f, 0.299f, 0f, 0f }, new float[] { 0.587f, 0.587f, 0.587f, 0f, 0f }, new float[] { 0.114f, 0.114f, 0.114f, 0f, 0f }, new float[] { 0f, 0f, 0f, (float)(((double)ImageAlpha) / 100.0), 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });
//                }
//                else
//                {
//                    clrMatrix = new ColorMatrix(new float[][] { new float[] { 1f, 0f, 0f, 0f, 0f }, new float[] { 0f, 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 1f, 0f, 0f }, new float[] { 0f, 0f, 0f, (float)(((double)ImageAlpha) / 100.0), 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });
//                }
//                ImageAttributes imgAttributes = new ImageAttributes();
//                imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
//                switch (ImagePosition)
//                {
//                    case ImagePositions.Center:
//                        rcImage = new Rectangle((int)Math.Round((double)((((double)(rcContent.Width - ImageSize.Width)) / 2.0) + ContentPadding.Left)), (int)Math.Round((double)((((double)(rcContent.Height - ImageSize.Height)) / 2.0) + ContentPadding.Top)), ImageSize.Width, ImageSize.Height);
//                        break;

//                    case ImagePositions.TopLeft:
//                        rcImage = new Rectangle(ContentPadding.Left + ImagePadding.Left, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
//                        break;

//                    case ImagePositions.TopRight:
//                        rcImage = new Rectangle(((ContentPadding.Right + rcContent.Width) - ImageSize.Width) - ImagePadding.Right, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
//                        break;

//                    case ImagePositions.BottomLeft:
//                        rcImage = new Rectangle(ContentPadding.Right + ImagePadding.Left, ((rcContent.Height - ImageSize.Height) - ImagePadding.Bottom) + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
//                        break;

//                    case ImagePositions.BottomRight:
//                        rcImage = new Rectangle(((ContentPadding.Right + rcContent.Width) - ImageSize.Width) - ImagePadding.Right, ((ContentPadding.Top + rcContent.Height) - ImageSize.Height) - ImagePadding.Bottom, ImageSize.Width, ImageSize.Height);
//                        break;
//                }
//                e.Graphics.DrawImage(btBitmap, rcImage, 0, 0, btBitmap.Width, btBitmap.Height, GraphicsUnit.Pixel, imgAttributes);
//            }
//        }

//        [Category("Borders")]
//        public bool Border
//        {
//            get
//            {
//                return bBorder;
//            }
//            set
//            {
//                bBorder = value;
//                Invalidate();
//            }
//        }

//        [Category("Borders")]
//        public Color BorderColor
//        {
//            get
//            {
//                return clBorder;
//            }
//            set
//            {
//                clBorder = value;
//                Invalidate();
//            }
//        }

//        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Content")]
//        public ColorWithAlphaCollection Colors
//        {
//            get
//            {
//                return clGradient;
//            }
//        }

//        [Category("Content")]
//        public Padding ContentPadding
//        {
//            get
//            {
//                return pdContent;
//            }
//            set
//            {
//                pdContent = value;
//                Invalidate();
//            }
//        }

//        [Category("Borders")]
//        public int CornerRadius
//        {
//            get
//            {
//                return iCornerRadius;
//            }
//            set
//            {
//                iCornerRadius = value;
//                Invalidate();
//            }
//        }

//        [Category("Borders")]
//        public Corners Corners
//        {
//            get
//            {
//                return eCorners;
//            }
//            set
//            {
//                eCorners = value;
//                Invalidate();
//            }
//        }

//        [Category("Content")]
//        public bool Gradient
//        {
//            get
//            {
//                return bGradient;
//            }
//            set
//            {
//                bGradient = value;
//                Invalidate();
//            }
//        }

//        [Category("Content")]
//        public LinearGradientMode GradientMode
//        {
//            get
//            {
//                return gmMode;
//            }
//            set
//            {
//                gmMode = value;
//                Invalidate();
//            }
//        }

//        [Category("Content")]
//        public float GradientOffset
//        {
//            get
//            {
//                return snOffset;
//            }
//            set
//            {
//                snOffset = value;
//                Invalidate();
//            }
//        }

//        [Category("Content")]
//        public Size GradientSize
//        {
//            get
//            {
//                return szGradient;
//            }
//            set
//            {
//                szGradient = value;
//                Invalidate();
//            }
//        }

//        [Category("Content")]
//        public WrapMode GradientWrapMode
//        {
//            get
//            {
//                return wmWrap;
//            }
//            set
//            {
//                wmWrap = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public bool Grayscale
//        {
//            get
//            {
//                return bGrayscale;
//            }
//            set
//            {
//                bGrayscale = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public System.Drawing.Image Image
//        {
//            get
//            {
//                return imImage;
//            }
//            set
//            {
//                imImage = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public int ImageAlpha
//        {
//            get
//            {
//                return iImageAlpha;
//            }
//            set
//            {
//                iImageAlpha = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public Padding ImagePadding
//        {
//            get
//            {
//                return pdImage;
//            }
//            set
//            {
//                pdImage = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public ImagePositions ImagePosition
//        {
//            get
//            {
//                return eImagePosition;
//            }
//            set
//            {
//                eImagePosition = value;
//                Invalidate();
//            }
//        }

//        [Category("Image")]
//        public Size ImageSize
//        {
//            get
//            {
//                return szImageSize;
//            }
//            set
//            {
//                szImageSize = value;
//                Invalidate();
//            }
//        }

//        [Category("Borders")]
//        public bool Rounded
//        {
//            get
//            {
//                return bRoundCorners;
//            }
//            set
//            {
//                bRoundCorners = value;
//                Invalidate();
//            }
//        }
//    }


//    public class DrawingHelper
//    {
//        public static GraphicsPath RoundedRect(Rectangle rect, int cornerradius, Corners roundedcorners)
//        {
//            RectangleF VBt_structS0 = new RectangleF((float)rect.Left, (float)rect.Top, (float)rect.Width, (float)rect.Height);
//            return RoundedRect(VBt_structS0, cornerradius, roundedcorners);
//        }

//        public static GraphicsPath RoundedRect(RectangleF rect, int cornerradius, Corners roundedcorners)
//        {
//            RectangleF VBt_structS0;
//            PointF VBt_structS1;
//            PointF VBt_structS2;
//            GraphicsPath p = new GraphicsPath();
//            float x = rect.X;
//            float y = rect.Y;
//            float w = rect.Width;
//            float h = rect.Height;
//            int r = cornerradius;
//            p.StartFigure();
//            if ((roundedcorners & Corners.TopLeft) > Corners.None)
//            {
//                VBt_structS0 = new RectangleF(x, y, (float)(2 * r), (float)(2 * r));
//                p.AddArc(VBt_structS0, 180f, 90f);
//            }
//            else
//            {
//                VBt_structS1 = new PointF(x, y + r);
//                VBt_structS2 = new PointF(x, y);
//                p.AddLine(VBt_structS1, VBt_structS2);
//                VBt_structS2 = new PointF(x, y);
//                VBt_structS1 = new PointF(x + r, y);
//                p.AddLine(VBt_structS2, VBt_structS1);
//            }
//            VBt_structS2 = new PointF(x + r, y);
//            VBt_structS1 = new PointF((x + w) - r, y);
//            p.AddLine(VBt_structS2, VBt_structS1);
//            if ((roundedcorners & Corners.TopRight) > Corners.None)
//            {
//                VBt_structS0 = new RectangleF((x + w) - (2 * r), y, (float)(2 * r), (float)(2 * r));
//                p.AddArc(VBt_structS0, 270f, 90f);
//            }
//            else
//            {
//                VBt_structS2 = new PointF((x + w) - r, y);
//                VBt_structS1 = new PointF(x + w, y);
//                p.AddLine(VBt_structS2, VBt_structS1);
//                VBt_structS2 = new PointF(x + w, y);
//                VBt_structS1 = new PointF(x + w, y + r);
//                p.AddLine(VBt_structS2, VBt_structS1);
//            }
//            VBt_structS2 = new PointF(x + w, y + r);
//            VBt_structS1 = new PointF(x + w, (y + h) - r);
//            p.AddLine(VBt_structS2, VBt_structS1);
//            if ((roundedcorners & Corners.BottomRight) > Corners.None)
//            {
//                VBt_structS0 = new RectangleF((x + w) - (2 * r), (y + h) - (2 * r), (float)(2 * r), (float)(2 * r));
//                p.AddArc(VBt_structS0, 0f, 90f);
//            }
//            else
//            {
//                VBt_structS2 = new PointF(x + w, (y + h) - r);
//                VBt_structS1 = new PointF(x + w, y + h);
//                p.AddLine(VBt_structS2, VBt_structS1);
//                VBt_structS2 = new PointF(x + w, y + h);
//                VBt_structS1 = new PointF((x + w) - r, y + h);
//                p.AddLine(VBt_structS2, VBt_structS1);
//            }
//            VBt_structS2 = new PointF((x + w) - r, y + h);
//            VBt_structS1 = new PointF(x + r, y + h);
//            p.AddLine(VBt_structS2, VBt_structS1);
//            if ((roundedcorners & Corners.BottomLeft) > Corners.None)
//            {
//                VBt_structS0 = new RectangleF(x, (y + h) - (2 * r), (float)(2 * r), (float)(2 * r));
//                p.AddArc(VBt_structS0, 90f, 90f);
//            }
//            else
//            {
//                VBt_structS2 = new PointF(x + r, y + h);
//                VBt_structS1 = new PointF(x, y + h);
//                p.AddLine(VBt_structS2, VBt_structS1);
//                VBt_structS2 = new PointF(x, y + h);
//                VBt_structS1 = new PointF(x, (y + h) - r);
//                p.AddLine(VBt_structS2, VBt_structS1);
//            }
//            VBt_structS2 = new PointF(x, (y + h) - r);
//            VBt_structS1 = new PointF(x, y + r);
//            p.AddLine(VBt_structS2, VBt_structS1);
//            p.CloseFigure();
//            return p;
//        }

//        public static GraphicsPath RoundedRect(Point location, Size size, int cornerradius, Corners roundedcorners)
//        {
//            RectangleF VBt_structS0 = new RectangleF((float)location.X, (float)location.Y, (float)size.Width, (float)size.Height);
//            return RoundedRect(VBt_structS0, cornerradius, roundedcorners);
//        }

//        public static GraphicsPath RoundedRect(PointF location, SizeF size, int cornerradius, Corners roundedcorners)
//        {
//            RectangleF VBt_structS0 = new RectangleF(location.X, location.Y, size.Width, size.Height);
//            return RoundedRect(VBt_structS0, cornerradius, roundedcorners);
//        }

//        public static GraphicsPath RoundedRect(int x, int y, int width, int height, int cornerradius, Corners roundedcorners)
//        {
//            RectangleF VBt_structS0 = new RectangleF((float)x, (float)y, (float)width, (float)height);
//            return RoundedRect(VBt_structS0, cornerradius, roundedcorners);
//        }
//    }


//    [Flags]
//    public enum Corners
//    {
//        All = 15,
//        AllxBottomRight = 7,
//        BottomLeft = 4,
//        BottomRight = 8,
//        BRBL = 12,
//        None = 0,
//        TLBL = 5,
//        TLBR = 9,
//        TopLeft = 1,
//        TopRight = 2,
//        TRBL = 6,
//        TRBR = 10,
//        TRTL = 3
//    }

//    [Flags]
//    public enum ImagePositions
//    {
//        Center,
//        TopLeft,
//        TopRight,
//        BottomLeft,
//        BottomRight
//    }





//    [Serializable, TypeConverter(typeof(ColorWithAlphaTypeConverter)), DesignTimeVisible(false), ToolboxItem(false)]
//    public class ColorWithAlpha : Component
//    {
//        private static ArrayList __ENCList = new ArrayList();
//        private System.Drawing.Color clColor;
//        private Control ctlParent;
//        private int iAlpha;

//        public ColorWithAlpha()
//        {
//            ArrayList VBt_refL0 = __ENCList;
//            lock (VBt_refL0)
//            {
//                __ENCList.Add(new WeakReference(this));
//            }
//            clColor = SystemColors.Control;
//            iAlpha = 0xff;
//            Invalidate();
//        }

//        public void Invalidate()
//        {
//            if (Parent != null)
//            {
//                Parent.Invalidate();
//            }
//        }

//        public int Alpha
//        {
//            get
//            {
//                return iAlpha;
//            }
//            set
//            {
//                iAlpha = value;
//                Invalidate();
//            }
//        }

//        public System.Drawing.Color Color
//        {
//            get
//            {
//                return clColor;
//            }
//            set
//            {
//                clColor = value;
//                Invalidate();
//            }
//        }

//        [Browsable(false)]
//        public Control Parent
//        {
//            get
//            {
//                return ctlParent;
//            }
//            set
//            {
//                ctlParent = value;
//            }
//        }
//    }


//    [Serializable, ToolboxItem(false), Editor(typeof(ColorWithAlphaCollectionEditor), typeof(UITypeEditor)), DesignTimeVisible(false), TypeConverter(typeof(ColorWithAlphaCollectionConverter))]
//    public class ColorWithAlphaCollection : CollectionBase, ICustomTypeDescriptor
//    {
//        private Control ctlParent;

//        public ColorWithAlphaCollection()
//        {
//        }

//        public ColorWithAlphaCollection(Control ParentControl)
//        {
//            Parent = ParentControl;
//        }

//        public ColorWithAlpha Add(ColorWithAlpha value)
//        {
//            List.Add(value);
//            return value;
//        }

//        public new void Clear()
//        {
//            base.Clear();
//        }

//        public bool Contains(ColorWithAlpha value)
//        {
//            return List.Contains(value);
//        }

//        public AttributeCollection GetAttributes()
//        {
//            return TypeDescriptor.GetAttributes(this, true);
//        }

//        public string GetClassName()
//        {
//            return TypeDescriptor.GetClassName(this, true);
//        }

//        public string GetComponentName()
//        {
//            return TypeDescriptor.GetComponentName(this, true);
//        }

//        public TypeConverter GetConverter()
//        {
//            return TypeDescriptor.GetConverter(this, true);
//        }

//        public EventDescriptor GetDefaultEvent()
//        {
//            return TypeDescriptor.GetDefaultEvent(this, true);
//        }

//        public PropertyDescriptor GetDefaultProperty()
//        {
//            return TypeDescriptor.GetDefaultProperty(this, true);
//        }

//        public object GetEditor(System.Type editorBaseType)
//        {
//            return TypeDescriptor.GetEditor(this, editorBaseType, true);
//        }

//        public EventDescriptorCollection GetEvents()
//        {
//            return TypeDescriptor.GetEvents(this, true);
//        }

//        public EventDescriptorCollection GetEvents(Attribute[] attributes)
//        {
//            return TypeDescriptor.GetEvents(this, attributes, true);
//        }

//        public PropertyDescriptorCollection GetProperties()
//        {
//            return null;
//        }

//        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
//        {
//            PropertyDescriptorCollection pdcProperties = new PropertyDescriptorCollection(null);
//            int VBt_i4L0 = List.Count - 1;
//            for (int i = 0; i <= VBt_i4L0; i++)
//            {
//                ColorWithAlphaCollectionPropertyDescriptor pdProperty = new ColorWithAlphaCollectionPropertyDescriptor(this, i);
//                pdcProperties.Add(pdProperty);
//            }
//            return pdcProperties;
//        }

//        public object GetPropertyOwner(PropertyDescriptor pd)
//        {
//            return this;
//        }

//        public int IndexOf(ColorWithAlpha value)
//        {
//            return List.IndexOf(value);
//        }

//        public void Insert(int index, ColorWithAlpha value)
//        {
//            List.Insert(index, value);
//        }

//        protected override void OnInsert(int index, object value)
//        {
//            ((ColorWithAlpha)value).Parent = Parent;
//            base.OnInsert(index, RuntimeHelpers.GetObjectValue(value));
//        }

//        protected override void OnSet(int index, object oldValue, object newValue)
//        {
//            ((ColorWithAlpha)newValue).Parent = Parent;
//            base.OnSet(index, RuntimeHelpers.GetObjectValue(oldValue), RuntimeHelpers.GetObjectValue(newValue));
//        }

//        public void Remove(ColorWithAlpha value)
//        {
//            List.Remove(value);
//        }

//        public ColorWithAlpha this[int Index]
//        {
//            get
//            {
//                return (ColorWithAlpha)List[Index];
//            }
//        }

//        [Browsable(false)]
//        public Control Parent
//        {
//            get
//            {
//                return ctlParent;
//            }
//            set
//            {
//                ctlParent = value;
//            }
//        }
//    }

//    public class ColorWithAlphaCollectionConverter : ExpandableObjectConverter
//    {
//        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
//        {
//            return ((destType == typeof(string)) || base.CanConvertTo(context, destType));
//        }

//        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
//        {
//            if (destType == typeof(string))
//            {
//                return ((ColorWithAlphaCollection)value).Count.ToString() + " colors";
//            }
//            return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destType);
//        }
//    }

//    internal class ColorWithAlphaCollectionEditor : CollectionEditor
//    {
//        private CollectionEditor.CollectionForm cfForm;

//        public ColorWithAlphaCollectionEditor(Type Type)
//            : base(Type)
//        {
//        }

//        protected override CollectionEditor.CollectionForm CreateCollectionForm()
//        {
//            cfForm = base.CreateCollectionForm();
//            return cfForm;
//        }

//        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
//        {
//            if ((((cfForm != null) && cfForm.Visible) ? 1 : 0) != 0)
//            {
//                return new ColorWithAlphaCollectionEditor(CollectionType);
//            }
//            return base.EditValue(context, provider, RuntimeHelpers.GetObjectValue(value));
//        }
//    }

//    public class ColorWithAlphaCollectionPropertyDescriptor : PropertyDescriptor
//    {
//        private ColorWithAlphaCollection _Collection;
//        private int _Index;

//        public ColorWithAlphaCollectionPropertyDescriptor(ColorWithAlphaCollection Collection, int Index)
//            : base("#" + Index.ToString(), null)
//        {
//            _Collection = null;
//            _Index = -1;
//            _Collection = Collection;
//            _Index = Index;
//        }

//        public override bool CanResetValue(object component)
//        {
//            return true;
//        }

//        public override object GetValue(object component)
//        {
//            return _Collection[_Index];
//        }

//        public override void ResetValue(object component)
//        {
//        }

//        public override void SetValue(object component, object value)
//        {
//        }

//        public override bool ShouldSerializeValue(object component)
//        {
//            return true;
//        }

//        public override AttributeCollection Attributes
//        {
//            get
//            {
//                return new AttributeCollection(null);
//            }
//        }

//        public override Type ComponentType
//        {
//            get
//            {
//                return _Collection.GetType();
//            }
//        }

//        public override string Description
//        {
//            get
//            {
//                return "Defines a color with an alpha level (0-255). 0 being transparent and 255 being full opaque";
//            }
//        }

//        public override string DisplayName
//        {
//            get
//            {
//                ColorWithAlpha item = _Collection[_Index];
//                return ("Color " + _Index.ToString());
//            }
//        }

//        public override bool IsReadOnly
//        {
//            get
//            {
//                return false;
//            }
//        }

//        public override string Name
//        {
//            get
//            {
//                return ("#" + _Index.ToString());
//            }
//        }

//        public override Type PropertyType
//        {
//            get
//            {
//                return _Collection[_Index].GetType();
//            }
//        }
//    }

//    public class ColorWithAlphaTypeConverter : ExpandableObjectConverter
//    {
//        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
//        {
//            return ((destType == typeof(string)) || base.CanConvertTo(context, destType));
//        }

//        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
//        {
//            if (destType == typeof(string))
//            {
//                return "My color";
//            }
//            return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destType);
//        }
//    }
//}

