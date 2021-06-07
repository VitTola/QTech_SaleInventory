using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QTech.Component
{
    public static class UI
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        public static bool IS_INIT_PDF = true;

        public enum OSVersion
        {
            Windows7,
            Higher
        }
         
        public static OSVersion OS
        {
            get
            {
                var winVer = Environment.OSVersion.Version;
                if (winVer.Major <= 6)
                {
                    if (winVer.Minor <= 1)
                    {
                        return OSVersion.Windows7;
                    }
                    else
                    {
                        return OSVersion.Higher;
                    }
                }
                else
                {
                    return OSVersion.Higher;
                }
            }
        }



        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        internal static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        internal static GraphicsPath GetRoundRectangle(Rectangle rectangle, int radius)
        {
            //int radius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - radius - diminisher, rectangle.Y, radius, radius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - radius - diminisher, rectangle.Y + rectangle.Height - radius - diminisher, radius, radius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius - diminisher, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
         
        // PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool repaint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        #region Language
        static InputLanguage _primaryLanguage = null;
        static InputLanguage _englishLanguage = null;
        /// <summary>
        /// Get Khmer Keyboard
        /// </summary>
        public static InputLanguage Primary
        {
            get
            {
                if (_primaryLanguage == null)
                {
                    _primaryLanguage = InputLanguage.InstalledInputLanguages[0];
                    for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                    {
                        if (InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower().Contains("khmer") || InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower().Contains("cambodian"))
                        {
                            _primaryLanguage = InputLanguage.InstalledInputLanguages[i];
                            break;
                        }
                    }
                }
                return _primaryLanguage;
            }
        }

        /// <summary>
        /// Get English Keyboard
        /// </summary>
        public static InputLanguage English
        {
            get
            {
                if (_englishLanguage == null)
                {
                    _englishLanguage = InputLanguage.InstalledInputLanguages[0];
                    for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                    {
                        if (InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower().Contains("us") || InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower().Contains("united states"))
                        {
                            _englishLanguage = InputLanguage.InstalledInputLanguages[i];
                            break;
                        }
                    }
                }
                return _englishLanguage;
            }
        }
        #endregion Language
    }
}
