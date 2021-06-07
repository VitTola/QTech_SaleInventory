using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("OnValueChanged")]
    public partial class ExFile : UserControl//, IAsyncTask
    {
        //public enum ValueChangedType
        //{
        //    Upload = 1,
        //    Remove
        //}

        //public ValueChangedType _valueChangedType;
        //public ValueChangedType ValueChangeType { get { return _valueChangedType; } }

        //#region Event
        //public void OnUploadedFile(object sender, EventArgs e)
        //{
        //    _valueChangedType = ValueChangedType.Upload;
        //    ValueChanged(e);
        //}
        
        //public void OnRemovedFile(object sender ,EventArgs e)
        //{
        //    lblMsgRowNotFound.Visible = string.IsNullOrEmpty(GetValue());
        //    _valueChangedType = ValueChangedType.Remove;
        //    ValueChanged(e);
        //}

        //[Browsable(true)]
        //public event EventHandler OnValueChanged;
        //public virtual void ValueChanged(EventArgs e)
        //{
        //    if (OnValueChanged != null) OnValueChanged(this, e);
        //}
        //#endregion

        //#region Property
        //private List<ExFileItem> _exFileItems = new List<ExFileItem>();
        //public enum MenuStyles
        //{
        //    TopHeader = 1,
        //    LeftPanel,
        //    InGridView
        //}

        //private bool _enableState;

        //private MenuStyles _menuStyle;
        //[Browsable(true)]
        //public MenuStyles MenuStyle
        //{
        //    get { return _menuStyle; }
        //    set
        //    {
        //        _menuStyle = value;
        //        ChangeMenuPosition();
        //    }
        //}

        //private void ChangeMenuPosition()
        //{
        //    switch (MenuStyle)
        //    {
        //        case MenuStyles.TopHeader:
        //            topFlowLayout.Visible = true;
        //            leftFlowLayout.Visible = picAdd.Visible = false;
        //            break;
        //        case MenuStyles.LeftPanel:
        //            leftFlowLayout.Visible = true;
        //            topFlowLayout.Visible = picAdd.Visible = false;
        //            break;
        //        case MenuStyles.InGridView:
        //            //picAdd.Visible = true;
        //            //leftFlowLayout.Visible = topFlowLayout.Visible = false;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        
        //private bool _showContainerBorder;
        //[Browsable(true)]
        //public bool ShowContainerBorder
        //{
        //    get { return _showContainerBorder; }
        //    set
        //    {
        //        _showContainerBorder = value;
        //        if (value == true)
        //        {
        //            mainContainerLayout.BorderStyle = BorderStyle.FixedSingle;
        //        }
        //        else
        //        {
        //            mainContainerLayout.BorderStyle = BorderStyle.None;
        //        }
        //    }
        //}
        
        //private List<Guid> _guidList = new List<Guid>();
        //private List<Base.Logics.Media> _mediaList = new List<Base.Logics.Media>();

        //private List<Lookup> _attachmentTypes = new List<Lookup>();

        //public bool CanAdd { get; set; } = true;
        //public bool CanEdit { get; set; } = true;
        //public bool CanRemove { get; set; } = true;
        //public bool CanView { get; set; } = true;
        //#endregion

        //public ExFile()
        //{
        //    InitializeComponent();
        //    ResourceHelper.ApplyResource(this);
        //    MenuStyle = MenuStyles.LeftPanel;
        //    ShowContainerBorder = true;
        //    //
        //    InitEvent();
        //}

        //protected override /*async*/ void OnLoad(EventArgs e)
        //{
        //    //Check Enable
        //    if (!this.Enabled)
        //    {
        //        this.Enabled = true;
        //        _btnAdd.Enabled = lblAdd.Enabled = picAdd.Enabled = false;
        //    }
            
        //    //if (!DesignMode)
        //    //{
        //    //    await LoadAttachementType();
        //    //}
            
        //    base.OnLoad(e);
        //}
        
        //private async Task LoadAttachementType()
        //{
        //    if (!_attachmentTypes.Any())
        //    {
        //        _attachmentTypes =
        //        await this.RunAsync(()=> LookupAPI.Instance.Search(
        //        new LookupSearch()
        //        {
        //            LookupGroupId = Domain.Enums.LookupType.AttachmentType
        //        }));
        //    }
        //}
 
        //private void InitEvent()
        //{
        //    picAdd.Click += addButton_Click;
        //    lblAdd.Click += addButton_Click;
        //    _btnAdd.Click += addButton_Click;
        //}
        
        //public async Task SetValueAsync(string value)
        //{
            
        //    _guidList.Clear();
        //    _mediaList.Clear();
        //    _exFileItems.Clear();

        //    if (string.IsNullOrEmpty(value))
        //    {
        //        if (mainContainerLayout.Controls.Count > 0)
        //        {
        //            this.mainContainerLayout.Controls.Clear();
        //        }
        //        lblMsgRowNotFound.Visible = true;

        //        return;
        //    }
            
        //    var idLists = value.Split(';').ToList().Where(x => x != string.Empty).ToList();
        //    _guidList = idLists.ConvertAll(Guid.Parse);
        //    await LoadFile();
        //}

        //public string GetValue()
        //{
        //    if (IsLoading && !_guidList.Any())
        //    {
        //        return string.Empty;
        //    }
        //    else if (IsLoading && _guidList.Any())
        //    {
        //        return string.Join(";", _guidList);
        //    }

        //    _guidList.Clear();

        //    foreach (var child in mainContainerLayout.Controls)
        //    {
        //        if (child.GetType() == typeof(ExFileItem))
        //        {
        //            var item = (ExFileItem)child;
        //            if (item.IsFailUploading != true && item.IsLoading != true)
        //            {
        //                _guidList.Add(item.Media.Id);
        //            }
        //        }
        //    }

        //    if (!_guidList.Any()) return string.Empty;

        //    return string.Join(";", _guidList);
        //}

        //public async Task LoadFile()
        //{
        //    mainContainerLayout.Controls.Clear(); 
        //    List<Base.Logics.Media> medias = new List<Base.Logics.Media>();
        //    await LoadAttachementType();
        //    await this.RunAsync(async () =>
        //    {
        //        medias = (!_mediaList.Any()) ? GetMedias() : _mediaList;
        //        foreach (Base.Logics.Media media in medias)
        //        {
        //            await CreateExFileItem(media);
        //        }
                
        //        return 0;
        //    });

        //    lblMsgRowNotFound.Visible = !_exFileItems.Any();
        //    mainContainerLayout.Controls.AddRange(_exFileItems.ToArray());

        //    //Loop through control one more time to set enable on file item
        //    if (mainContainerLayout.Controls.Count > 0)
        //    {
        //        foreach (var item in mainContainerLayout.Controls)
        //        {
        //            if (item.GetType() == typeof(ExFileItem))
        //            {
        //                var file = (ExFileItem)item;
        //                file.Enabled = true;
        //                file.CanEdit = (_enableState) ? CanEdit : _enableState;
        //                file.CanRemove = (_enableState) ? CanRemove : _enableState;
        //                file.CanView = this.CanView;
        //            }
        //        }
        //    }
        //}

        //private List<Base.Logics.Media> GetMedias()
        //{
        //    if (_guidList == null) _guidList = new List<Guid>();

        //    var listMedia = new List<Base.Logics.Media>();

        //    _guidList.ForEach(x =>
        //    {
        //        try
        //        {
        //            var media = MediaAPI.Instance.Find(x);

        //            if (media != null) listMedia.Add(media);
        //        }
        //        catch { /*Ignore Error*/ }
        //    });

        //    return listMedia;
        //}

        //private async Task<ExFileItem> CreateExFileItem(Base.Logics.Media media)
        //{
        //    ExFileItem item = new ExFileItem();
        //    await LoadAttachementType();
        //    item.AttachmentTypeName = _attachmentTypes.FirstOrDefault(x => x.ValueInt == media.MediaTypeId)?.Name ?? "-";
        //    item.AttachmentTypes = _attachmentTypes;
        //    item.Media = media;
        //    item.Dock = DockStyle.Top;
        //    item.Margin = new Padding(2);
        //    item.RemoveComplete += OnRemovedFile;
        //    item.UploadComplete += OnUploadedFile;
        //    item.CanEdit = CanEdit;
        //    item.CanRemove = CanRemove;
            
        //    _exFileItems.Add(item);
        //    return item;
        //}

        //private async void addButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.Filter = "All Files|*.doc;*.docx;*.xls;*.csv;*.xls;*.xlsx;*.xlr;*.ppt;*.jpg;*.jpeg;*.png;*.pdf;*.mp4;*.avi;*.mov" +
        //                 "|Word Documents|*.doc;*.docx"+
        //                 "|Excel Worksheets|*.xls;*.csv;*.xls;*.xlsx;*.xlr" +
        //                 "|PowerPoint Presentations|*.ppt" +
        //                 "|Image|*.jpg;*.jpeg;*.png"+
        //                 "|PDF|*.pdf"+
        //                 "|Videos|*.mp4;*.avi;*.mov;";

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        Storm.Base.Logics.Media media = new Base.Logics.Media();
        //        media.Name = Path.GetFileName(dialog.FileName);
        //        media.Path = dialog.FileName;
        //        //
        //        await LoadAttachementType();
        //        if (_attachmentTypes == null) return;
        //        if (!_attachmentTypes.Any()) return;
        //        AddAttachmentDialog dig = new AddAttachmentDialog(media, Base.Helpers.GeneralProcess.Add, _attachmentTypes);
        //        if (dig.ShowDialog() == DialogResult.OK)
        //        {
        //            lblMsgRowNotFound.Visible = false;

        //            var fileObject = dig.FileObject;
        //            Storm.Base.Logics.Media mediaFile = new Base.Logics.Media()
        //            {
        //                Name = fileObject.FileName,
        //                UploadBy = ShareAPI.Instance.FormalUserName,
        //                MediaTypeId = fileObject.MediaTypeId,
        //                Size = new FileInfo(fileObject.File).Length,
        //                UploadDate = DateTime.Now,
        //                Note = fileObject.Note
        //            };
        //            ExFileItem fileItem = await CreateExFileItem(mediaFile);
        //            mainContainerLayout.Controls.Add(fileItem);
        //            await fileItem.StartUpload(fileObject);
        //        }
                
        //    }
        //}

        //private async void onAddDialog_Close(object sender, EventArgs e)
        //{
        //    var dialog = (AddAttachmentDialog)sender;
        //    if (dialog.DialogResult == DialogResult.OK)
        //    {
        //        lblMsgRowNotFound.Visible = false;

        //        var fileObject = dialog.FileObject;
        //        Storm.Base.Logics.Media media = new Base.Logics.Media()
        //        {
        //            Name = fileObject.FileName,
        //            UploadBy = ShareAPI.Instance.FormalUserName,
        //            MediaTypeId = fileObject.MediaTypeId,
        //            Size = new FileInfo(fileObject.File).Length,
        //            UploadDate = DateTime.Now,
        //            Note = fileObject.Note
        //        };
        //        ExFileItem fileItem = await CreateExFileItem(media);
        //        mainContainerLayout.Controls.Add(fileItem);
        //        await fileItem.StartUpload(fileObject);
        //    }
        //}
        
        //#region DgvRunAsync
        //public bool IsLoading { get; set; }
        //public bool Executing { get => IsLoading; set => IsLoading = value; }
        //public void PreExecute(bool block = false)
        //{
        //    //IsLoading = true;
        //    if (block)
        //    {
        //        Enabled = false;
        //    }
        //    Executing = true;
        //    lblMsgRowNotFound.Visible = false;
        //    picDgvLoading.Visible = true;
        //}

        //public void PostExecute(bool block = false)
        //{
        //    //IsLoading = false;
        //    if (block)
        //    {
        //        Enabled = true;
        //    }
        //    Executing = false;
        //    picDgvLoading.Visible = false;
        //}
        //#endregion
        
        //public bool AnyUploading()
        //{
        //    bool anyUploading = false;

        //    foreach(var control in this.mainContainerLayout.Controls)
        //    {
        //        if (control.GetType() == typeof(ExFileItem))
        //        {
        //            var item = (ExFileItem)control;
        //            if (item.IsLoading)
        //            {
        //                anyUploading = true;
        //                break;
        //            }
        //        }
        //    }

        //    return anyUploading;
        //}

        //public bool AnyFailUpload()
        //{
        //    bool anyFailUpload = false;

        //    foreach (var control in this.mainContainerLayout.Controls)
        //    {
        //        if (control.GetType() == typeof(ExFileItem))
        //        {
        //            var item = (ExFileItem) control;
        //            if (item.IsFailUploading)
        //            {
        //                anyFailUpload = true;
        //                break;
        //            }
        //        }
        //    }

        //    return anyFailUpload;
        //}

        //public void PropertyEnable(bool enable)
        //{
        //    //this.Enabled = true;
        //    //_btnAdd.Enabled = lblAdd.Enabled = picAdd.Enabled = enable;
        //    //if (mainContainerLayout.Controls.Count > 0)
        //    //{
        //    //    foreach (var item in mainContainerLayout.Controls)
        //    //    {
        //    //        if (item.GetType() == typeof(ExFileItem))
        //    //        {
        //    //            var file = (ExFileItem)item;
        //    //            file.Enabled = true;
        //    //            file.CanEdit = file.CanRemove = enable;
        //    //        }
        //    //    }
        //    //}
        //}

        //public void ApplyAuthorizeEnable(bool canView = true, bool canAdd = true, bool canEdit = true, bool canRemove = true, bool setEnable = true)
        //{
        //    _enableState = setEnable;
        //    CanView = canView;
        //    CanAdd = canAdd;
        //    CanEdit = canEdit;
        //    CanRemove = canRemove;

        //    _btnAdd.Enabled = lblAdd.Enabled = picAdd.Enabled = (_enableState) ? canAdd : _enableState;
        //    if (mainContainerLayout.Controls.Count > 0)
        //    {
        //        foreach (var control in mainContainerLayout.Controls)
        //        {
        //            if (control is ExFileItem exFile)
        //            {
        //                exFile.Enabled = true;
        //                exFile.CanView = canView; 
        //                exFile.CanEdit = (_enableState) ? canEdit : _enableState;
        //                exFile.CanRemove = (_enableState) ? canRemove : _enableState;
        //            }
        //        }
        //    }
        //}
    }
}
