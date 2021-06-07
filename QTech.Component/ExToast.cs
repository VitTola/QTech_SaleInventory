using QTech.Component.Properties;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExToast : ExDialog
    {
         
        public ExToast()
        {
            InitializeComponent();
            img.Image = _toastImage;
            img.SizeMode = PictureBoxSizeMode.Zoom;
            _dismissTimer.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds / 100;
            _flyOutTimer.Interval = 5;
            _flyInTimer.Interval = 5;

            InitFlyOut = new Lazy<bool>(() =>
            {
                Flyout();
                return true;
            });
        }

        Image _toastImage = Resources.oone_64;
        Timer _flyInTimer = new Timer();
        Timer _dismissTimer = new Timer();
        Timer _flyOutTimer = new Timer();
        bool _isFlyout;

        public Image ToastImage
        {
            get
            {
                return _toastImage;
            }
            set
            {
                _toastImage = value;
                img.Image = _toastImage;
            }
        }

        public int Duration { get; set; }
        public string Message { get => label1.Text; set => label1.Text = value; }

        private void ExToast_Load(object sender, EventArgs e)
        {
            var w = Screen.FromHandle(Handle).WorkingArea.Width;
            var h = Screen.FromHandle(Handle).WorkingArea.Height;
            var x = w;
            var y = h - this.Height;
            SetDesktopLocation(x, y-5); 
            flyIn();    
        }

        private void flyIn()
        {
            var w = Screen.FromHandle(Handle).WorkingArea.Width;             
            _flyInTimer.Tick +=(sender, e)=>{
                var newX = Location.X - 10;
                if (newX < w - this.Width)
                {
                    _flyInTimer.Stop();
                    SetDesktopLocation(newX + 5, this.Location.Y);
                    this.FormClosing += exToast_FormClosing;

                    this.MouseEnter += exToast_MouseHover;
                    this.container.MouseEnter += exToast_MouseHover;
                    this.img.MouseEnter += exToast_MouseHover;
                    this.label1.MouseEnter += exToast_MouseHover;
                    this.MouseLeave += exToast_MouseLeave;
                    this.container.MouseLeave += exToast_MouseLeave;
                    this.img.MouseLeave += exToast_MouseLeave;
                    this.label1.MouseLeave += exToast_MouseLeave;
                     
                    new DebounceDispatcher().Debounce(Duration, p => { delayDismiss(); });
                    return;
                }
                SetDesktopLocation(newX, this.Location.Y);
            };
            _flyInTimer.Start();
        }
         
        private void exToast_MouseLeave(object sender, EventArgs e)
        {
            if (!_isFlyout)
            {
                _dismissTimer.Start();
            }
        }

        private void exToast_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity!=0)
            {
                _isFlyout = InitFlyOut.Value;
                e.Cancel = true;
                return;
            }
            this.Dispose(true);
        }

        private void exToast_MouseHover(object sender, EventArgs e)
        {
            if (!_isFlyout)
            {
                _dismissTimer.Stop();
                this.Opacity = 1;
            }
        }

        public void delayDismiss()
        { 
            
            _dismissTimer.Tick += (sender, e) =>
            {
                if (this.Opacity <= 0.0)
                {
                    _dismissTimer.Stop();
                    Opacity = 0;
                    this.Close();
                    return;
                }
                if (Opacity<=0.6)
                {
                    _isFlyout= InitFlyOut.Value;
                }
                var opacity = this.Opacity - 0.01;
                this.Opacity = opacity > 0 ? opacity : 0;
            };
            _dismissTimer.Start();
        }

        public Lazy<bool> InitFlyOut;
        public void Flyout()
        {
            if (_isFlyout)
            {
                return;
            }

            _flyInTimer.Stop();
            var w = Screen.FromHandle(Handle).WorkingArea.Width;
            var h = Screen.FromHandle(Handle).WorkingArea.Height;
            SetDesktopLocation(w-this.Width - 5, h -this.Height- 5);
            _flyOutTimer.Tick += (sender, e) =>
            {
                var newX = Location.X + 10;
                if (newX >= w)
                {
                    _flyOutTimer.Stop();
                    SetDesktopLocation(w, this.Location.Y);
                    Opacity = 0;
                    this.Close();
                    return;
                }
                SetDesktopLocation(newX, this.Location.Y);
            };
            _flyOutTimer.Start();
        }
         
    }

    public class ToastManager
    {
        protected static Lazy<ToastManager> _instance = new Lazy<ToastManager>(() => new ToastManager()); 
        public static ToastManager Instance => _instance.Value;

        public ExToast Current { get; set; }
        DebounceDispatcher _dispatcher = new DebounceDispatcher();

        public void ShowToast(string msg, string title = "", Image image = null, Duration duration = Duration.Short)
        {

            var toast = new ExToast()
            {
                TopMost = true,
                Message = msg,
                Duration = (int)TimeSpan.FromSeconds((int)duration).TotalMilliseconds
            };
            if (image != null)
            {
                toast.ToastImage = image;
            }
            if (!string.IsNullOrEmpty(title))
            {
                toast.Text = title;
            }
            ShowToast(toast);

        }

        private void ShowToast(ExToast toast)
        {
            if (Current !=null)
            {
                if (!Current.IsDisposed)
                {
                    Current.Flyout();
                    _dispatcher.Debounce((int)TimeSpan.FromSeconds(1).TotalMilliseconds, p =>
                    {
                        Current = toast; 
                        Current.Show();
                    });
                    return;
                }
                Current = toast;
                Current.Show();
            }
            else
            {
                Current = toast; 
                Current.Show();
            } 
        }



        public enum Duration
        {
            Short = 2,
            Long = 5
        }
    }

}
