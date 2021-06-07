

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    [DefaultEvent("UrlChanged")]
    public partial class ExProfilePicture : UserControl
    {
        string _url = null;

        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                SetPictureName();
                SetProfilePicture();
            }
        }

        public string PictureName { get; set; }
        public Guid PictureGuid { get; set; }
     //   public Media Media { get; private set; }

        public event EventHandler UrlChanged;

        [Category("Data")]
        [Browsable(true)]
        public Image Placeholder
        {
            get
            {
                return this.profilePicture.InitialImage;
            }
            set
            {
                this.profilePicture.InitialImage = value;
                SetProfilePicture();
            }
        }

        private bool _canRemove = true;
        public bool CanRemove
        {
            get
            {
                return _canRemove;
            }
            set
            {
                _canRemove = value;
                picRemove.Enabled = _canRemove;
            }
        }
        private bool _canUpload = true;
        public bool CanUpload
        {
            get
            {
                return _canUpload;
            }
            set
            {
                _canUpload = value;
                picEdit.Enabled = profilePicture.Enabled = _canUpload;
            }
        }
        private bool _canDownload = true;
        public bool CanDownload
        {
            get
            {
                return _canDownload;
            }
            set
            {
                _canDownload = value;
                picDownload.Enabled = _canDownload;
            }
        }

        public ExProfilePicture()
        {
            InitializeComponent();
        }

        public virtual void OnUrlChanged(EventArgs e)
        {
            if (UrlChanged != null)
            {
                UrlChanged(this, e);
            }
        }

        private void SetPictureName()
        {
            if (!string.IsNullOrEmpty(this.PictureName))
            {
                var splittedString = this.Url.Split('/');
                var fileName = splittedString.LastOrDefault();

                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }

                fileName = System.Net.WebUtility.UrlDecode(fileName);
                fileName = fileName.Replace("_", "");
                this.PictureName = fileName;
            }
        }

        public async void SetProfilePicture()
        {
            if (string.IsNullOrEmpty(this.Url))
            {
                profilePicture.Image = Placeholder ?? Properties.Resources.photoPlaceHolder;
                return;
            }
            try
            {
                await Task.Run(() => profilePicture.Load(Url));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }

        //private async void profilePicture_Click(object sender, EventArgs e)
        //{
        //    string selectedPath = "";

        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        selectedPath = dialog.FileName;
        //    }

        //    if (!string.IsNullOrEmpty(selectedPath))
        //    {
        //        profilePicture.ImageLocation = selectedPath;
        //        await picEdit.ExecuteAsync(() =>
        //        {
        //            FileObject fileObj = new FileObject()
        //            {
        //                File = selectedPath,
        //                FileName = Path.GetFileName(selectedPath),
        //                MediaTypeId = 1,
        //                Note = $"Profile / Indentification Picture"
        //            };

        //            Media media = null;
        //            try
        //            {
        //                media = MediaAPI.Instance.UploadFile(fileObj);
        //            }
        //            catch (Exception ex)
        //            {
        //                picEdit.PostExecute();
        //                throw new Exception(ex.Message);
        //            }
                    
        //            if (media == null)
        //            {
        //                return;
        //            }

        //            this.Url = media.Url;
        //            this.PictureName = media.Name;
        //            this.PictureGuid = media.Id;
        //            Media = media;
        //            OnUrlChanged(EventArgs.Empty);
        //        });
        //    }
        //}

        //private async void picDownload_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(Url)) { return; }

        //    string selectedPath = "";
        //    var defaultFileName = (!string.IsNullOrEmpty(PictureName)) ? PictureName : "image.jpg";
        //    defaultFileName = System.Net.WebUtility.UrlDecode(defaultFileName);
        //    var t = new Thread(() =>
        //    {
        //        var browseDialog = new SaveFileDialog();
        //        browseDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
        //        browseDialog.FileName = defaultFileName;
        //        if (browseDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            selectedPath = browseDialog.FileName;
        //        }
        //    });

        //    t.SetApartmentState(ApartmentState.STA);
        //    t.Start();
        //    t.Join();

        //    if (!string.IsNullOrEmpty(selectedPath))
        //    {
        //        await picDownload.ExecuteAsync(() =>
        //        {
        //            MediaAPI.Instance.DownLoad(this.Url, selectedPath);
        //        });

        //        System.Diagnostics.Process.Start(selectedPath);
        //    }
        //}

        //private async void picRemove_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.Url)) return;
        //    bool isRemove = false;

        //    var result = MsgBox.ShowQuestion(string.Format(EDomain.Resources.AreYouSureYouWantToRemoveThisImage, "រូបភាព"),
        //        Base.Helpers.GeneralProcess.Remove.GetTextDialog("រូបភាព"));

        //    if (result == DialogResult.Yes)
        //    {
        //        isRemove = true;
        //    }

        //    if (isRemove)
        //    {
        //        try
        //        {
        //            await picRemove.ExecuteAsync(() =>
        //            {
        //                MediaAPI.Instance.RemoveUrl(this.Url);

        //                this.Url = string.Empty;
        //                this.PictureName = string.Empty;
        //                this.PictureGuid = Guid.Empty;
        //                SetProfilePicture();
        //                OnUrlChanged(EventArgs.Empty);
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}

        //public void PropertyEnable(bool enable)
        //{
        //    this.Enabled = true;
        //    profilePicture.Enabled = picDownload.Enabled = true;
        //    picEdit.Enabled = picRemove.Enabled = enable;
        //}

        public void ApplyAuthorizeEnable(bool canUpload, bool canDownload, bool canRemove, bool setEnable)
        {
            this.Enabled = true;
            CanDownload = setEnable ? canDownload : setEnable;
            CanUpload = setEnable ? canUpload : setEnable;
            CanRemove = setEnable ? canRemove : setEnable;
        }
    }
}
