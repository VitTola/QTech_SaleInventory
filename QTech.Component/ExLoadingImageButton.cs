using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    public class ExLoadingImageButton : PictureBox
    {
        public bool Executing { get; set; }

        private Image _loadingImage;
        [Category("Image")]
        [Browsable(true)]
        public Image LoadingImage
        {
            get { return _loadingImage; }
            set { _loadingImage = value; }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        public void PostExecute()
        {
            Executing = false;
            Image = InitialImage;
        }

        public void PreExecute()
        {
            Executing = true;
            InitialImage = Image;
            Image = _loadingImage;
        }

        public async Task ExecuteAsync(Action action)
        {
            try
            {
                PreExecute();

                await Task.Run(() =>
                {
                    action();
                });

                PostExecute();
            }
            catch (Exception ex)
            {
                PostExecute();
                MsgBox.ShowError(ex);
            }
        }
        
        protected override void OnClick(EventArgs e)
        {
            if (Executing) return;

            base.OnClick(e);
        }
    }
}
