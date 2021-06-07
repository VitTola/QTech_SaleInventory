
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExFileItem : UserControl
    {
        //#region Event
        //public EventHandler RemoveComplete;
        //public virtual void OnRemoveComplete(EventArgs e)
        //{
        //    if (RemoveComplete != null)
        //    {
        //        RemoveComplete(this, e);
        //    }
        //}

        //public EventHandler UploadComplete;
        //public virtual void OnUploadComplete(EventArgs e)
        //{
        //    if (UploadComplete != null)
        //    {
        //        UploadComplete(this, e);
        //    }
        //}

        //public EventHandler EditComplete;
        //public virtual void OnEditComplete(EventArgs e)
        //{
        //    if (EditComplete != null)
        //    {
        //        EditComplete(this, e);
        //    }
        //}
        //#endregion

        //#region Properties
        //private Base.Logics.Media _media;
        //public string AttachmentTypeName { get; set; }
        //public List<Domain.Models.Lookup> AttachmentTypes { get; set; }
        //public bool IsLoading { get; private set; }
        //private bool _isFailUpload = false;
        //string _uploadFailText = "";
        //public bool IsFailUploading
        //{
        //    get { return _isFailUpload; }
        //    private set
        //    {
        //        _isFailUpload = this.picRetry.Visible = value;
        //        lblName.Enabled = !value;
        //        SetFileUI();
        //    }
        //}
        //private Base.Logics.FileObject _fileObject { get; set; }

        //public Base.Logics.Media Media
        //{
        //    get { return _media; }
        //    set
        //    {
        //        _media = value;
        //        SetFileUI();
        //        picFileType.Image = SwitchPictureBaseOnFileType();
        //    }
        //}
        //private bool _canRemove = true;
        //public bool CanRemove
        //{
        //    get
        //    {
        //        return _canRemove;
        //    }
        //    set
        //    {
        //        _canRemove = value;
        //        picRemove.Enabled = _canRemove;
        //    }
        //}
        //private bool _canEdit = true;
        //public bool CanEdit
        //{
        //    get
        //    {
        //        return _canEdit;
        //    }
        //    set
        //    {
        //        _canEdit = value;
        //        picEdit.Enabled = _canEdit;
        //    }
        //}
        //private bool _canView = true;
        //public bool CanView
        //{
        //    get
        //    {
        //        return _canView;
        //    }
        //    set
        //    {
        //        _canView = value;
        //        lblName.Enabled = _canView;
        //    }
        //}
        //#endregion

        //public ExFileItem()
        //{
        //    InitializeComponent();
        //    InitEvent();
        //    lblInfo.AutoEllipsis = true;
        //}

        //private void InitEvent()
        //{
        //    picRemove.Click += picRemove_Click;
        //    picEdit.Click += picEdit_Click;
        //    lblName.Click += _lblName_LinkClicked;
        //    picRetry.Click += picRetry_Click;
        //}

        //private void SetFileUI(string execptionText = "")
        //{
        //    lblName.Text = (Media.Name.Length <= 50) ? Media.Name : $"{Media.Name.Substring(0, 50)}...";
        //    lblInfo.ForeColor = (IsFailUploading) ? Color.Red : Color.Gray;
        //    //Sub string Note
        //    string Note = (string.IsNullOrEmpty(Media.Note)) ?
        //        " - " :
        //        (Media?.Note.Length <= 35) ? Media?.Note ?? string.Empty : $"{Media?.Note?.Substring(0, 35) ?? string.Empty}...";
        //    lblInfo.Text = (IsFailUploading) ?
        //            Resources.UploadFail + _uploadFailText :
        //            $"{Resources.AttachementType}: {AttachmentTypeName}; " +
        //            $"{Resources.Size}: {ConvertFileSize(Media.Size)}; " +
        //            $"{Resources.UploadBy}: {Media.UploadBy}; " +
        //            $"{Resources.Note}: {Note};";

        //    lblDate.Text = (IsFailUploading) ?
        //        $"-" :
        //        $"{Media.UploadDate.ToShortDateString()}";
        //}

        //private async void picRemove_Click(object sender, EventArgs e)
        //{
        //    if (IsLoading)
        //    {
        //        return;
        //    }

        //    bool isRemove = false;

        //    var result = MsgBox.ShowQuestion(string.Format(Resources.AreYouSureYouWantToRemoveThisAttachement_, this.Media.Name),
        //        GeneralProcess.Remove.GetTextDialog(this.Media.Name));

        //    if (result == DialogResult.Yes)
        //    {
        //        isRemove = true;

        //        if (IsFailUploading)
        //        {
        //            Parent.Controls.Remove(this);
        //            this.Dispose();
        //            //this.OnRemoveComplete(e);
        //            return;
        //        }
        //    }

        //    if (isRemove)
        //    {
        //        await this.picRemove.ExecuteAsync(() =>
        //        {
        //            MediaAPI.Instance.RemoveUrl(Media.Url);
        //        });

        //        Parent.Controls.Remove(this);
        //        this.Dispose();
        //        this.OnRemoveComplete(e);
        //    }
        //}

        //private void picEdit_Click(object sender, EventArgs e)
        //{
        //    if (IsLoading || IsFailUploading)
        //    {
        //        return;
        //    }

        //    if (AttachmentTypes == null)
        //    {
        //        return;
        //    }

        //    if (!AttachmentTypes.Any())
        //    {
        //        return;
        //    }

        //    AddAttachmentDialog dialog = new AddAttachmentDialog(this.Media, GeneralProcess.Update, AttachmentTypes);
        //    dialog.AttachmentTypes = this.AttachmentTypes;

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        var media = dialog.Media;
        //        this.AttachmentTypeName = AttachmentTypes.FirstOrDefault(x => x.ValueInt == media.MediaTypeId)?.Name ?? "Not Found";
        //        this.Media = media;
        //        //
        //        if (this.EditComplete != null)
        //        {
        //            this.EditComplete(this, e);
        //        }
        //    }
        //}

        //private async void _lblName_LinkClicked(object sender, EventArgs e)
        //{
        //    await DownLoadFile();
        //}

        //#region Start Upload File
        //private void PreUploadDownload()
        //{
        //    picRetry.Visible = false;
        //    picLoading.Visible = true;
        //    IsLoading = true;
        //}

        //private void PostUploadDownload()
        //{
        //    picLoading.Visible = false;
        //    IsLoading = false;
        //}

        //bool _isEverError = false;
        //public async Task StartUpload(FileObject fileObject)
        //{
        //    PreUploadDownload();

        //    _fileObject = fileObject;

        //    Media media = null;

        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            media = MediaAPI.Instance.UploadFile(fileObject);
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _uploadFailText = ex.Message;
        //    }

        //    if (media == null)
        //    {
        //        IsFailUploading = true;
        //        PostUploadDownload();
        //        return;
        //    }
        //    else
        //    {
        //        this._media = media;
        //        IsFailUploading = false;
        //        PostUploadDownload();
        //        this.OnUploadComplete(EventArgs.Empty);
        //        return;
        //    }

        //}
        //#endregion

        //#region Download File
        //public async Task DownLoadFile()
        //{
        //    //if (this.IsFailUploading == true || this.IsLoading == true) { return; }

        //    string selectedPath = "";
        //    var defaultFileName = (!string.IsNullOrEmpty(Media.Name)) ? Media.Name : "File.file";

        //    //defaultFileName = System.Net.WebUtility.UrlDecode(defaultFileName);
        //    //var t = new Thread((ThreadStart)(() =>
        //    //{
        //    //    var browseDialog = new SaveFileDialog();
        //    //    browseDialog.FileName = defaultFileName;
        //    //    if (browseDialog.ShowDialog() == DialogResult.OK)
        //    //    {

        //    //        selectedPath = browseDialog.FileName;
        //    //    }
        //    //}));

        //    //t.SetApartmentState(ApartmentState.STA);
        //    //t.Start();
        //    //t.Join();

        //    //if (!string.IsNullOrEmpty(selectedPath))
        //    //{

        //    PreUploadDownload();

        //    await Task.Run(() =>
        //    {
        //        //var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "OneBilling", DateTime.Now.ToString("dd/MM/yyyy").Replace("/","_"));
        //        //if (!Directory.Exists(folder))
        //        //{
        //        //    Directory.CreateDirectory(folder);
        //        //}
        //        //selectedPath = Path.Combine(folder, defaultFileName);
        //        //int i = 0;
        //        //while (File.Exists(selectedPath))
        //        //{
        //        //    i++;
        //        //    var newFileName = defaultFileName;
        //        //    newFileName = $"{Path.GetFileNameWithoutExtension(defaultFileName)}({i}){Path.GetExtension(defaultFileName)}";
        //        //    selectedPath = Path.Combine(folder, newFileName);
        //        //}
        //        var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "OneBilling", DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "_"));
        //        selectedPath = MediaAPI.RenameDuplicateFileName(folder, defaultFileName);
        //        MediaAPI.Instance.DownLoad(Media.Url, selectedPath);
        //    });

        //    System.Diagnostics.Process.Start(selectedPath);
        //    PostUploadDownload();
        //    //}
        //}
        //#endregion

        //private async void picRetry_Click(object sender, EventArgs e)
        //{
        //    if (IsFailUploading == true)
        //    {
        //        await StartUpload(this._fileObject);
        //    }
        //}

        //public string ConvertFileSize(decimal len)
        //{
        //    string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        //    int order = 0;
        //    while (len >= 1024 && order < sizes.Length - 1)
        //    {
        //        order++;
        //        len = len / 1024;
        //    }

        //    // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
        //    // show a single decimal place, and no space.
        //    return String.Format("{0:0.##} {1}", len, sizes[order]);
        //}

        //#region Switch Picture
        //public Image SwitchPictureBaseOnFileType()
        //{
        //    if (Media != null)
        //    {
        //        var extension = Path.GetExtension(this.Media.Name);
        //        extension = extension.ToLower();
        //        //JPG Image
        //        if (extension == ".jpg" ||
        //            extension == ".jpeg")
        //        {
        //            return Storm.Component.Properties.Resources.jpg;
        //        }
        //        //PNG Image
        //        else if (extension == ".png")
        //        {
        //            return Storm.Component.Properties.Resources.png;
        //        }
        //        //Microsoft Word
        //        else if (extension == ".doc" ||
        //            extension == ".docx")
        //        {
        //            return Storm.Component.Properties.Resources.doc;
        //        }
        //        //Spread Sheet, Excel
        //        else if (extension == ".xls" ||
        //            extension == ".csv" ||
        //            extension == ".xlr" ||
        //            extension == ".xls" ||
        //            extension == ".xlsx")
        //        {
        //            return Storm.Component.Properties.Resources.xls;
        //        }
        //        //Power Point
        //        else if (extension == ".ppt" ||
        //            extension == ".pptx")
        //        {
        //            return Storm.Component.Properties.Resources.ppt;
        //        }
        //        //PDF
        //        else if (extension == ".pdf")
        //        {
        //            return Storm.Component.Properties.Resources.pdf;
        //        }
        //        //Video (mp4)
        //        else if (extension == ".mp4"
        //            || extension == ".mov")
        //        {
        //            return Storm.Component.Properties.Resources.mp4;
        //        }
        //        //Video (avi)
        //        else if (extension == ".avi")
        //        {
        //            return Storm.Component.Properties.Resources.avi;
        //        }
        //    }

        //    return Storm.Component.Properties.Resources.unknown_file;
        //}
        //#endregion

    }
}
