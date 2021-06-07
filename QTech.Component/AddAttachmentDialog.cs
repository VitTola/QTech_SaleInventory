

namespace QTech.Component
{
    public partial class AddAttachmentDialog : ExDialog//, IDialog
    {
        //private string _fullPath;
        //private string _extension;

        //public FileObject FileObject { get; set; }
        //public GeneralProcess Flag { get; set; }
        //public Storm.Base.Logics.Media Media { get; set; }
        //public List<Domain.Models.Lookup> AttachmentTypes { get; set; } = new List<Lookup>();


        //public AddAttachmentDialog(Storm.Base.Logics.Media media, GeneralProcess flag, List<Domain.Models.Lookup> attachmentTypes)
        //{
        //    InitializeComponent();
        //    Flag = flag;
        //    Media = media;
        //    Text = Flag.GetTextDialog(Resources.Attachments);
        //    AttachmentTypes = attachmentTypes;
        //    Bind();
        //    InitEvent();
        //    Read();
        //}
        
        //public void Bind()
        //{
        //    _lblAttachmentName.Text = ResourceHelper.Translate(Resources.AttachmentName);
        //    _lblAttachementType.Text = ResourceHelper.Translate(Resources.AttachementType);
        //    //
        //    //cboAttachmentType.DataSourceFn = p => LookupAPI.Instance.Search(p).ToDropDownItemModelList();
        //    //cboAttachmentType.SearchParamFn = () => new LookupSearch() { LookupGroupId = Domain.Enums.LookupType.AttachmentType };
        //    cboAttachmentType.SetLookUpDataSource(AttachmentTypes);
        //    if (AttachmentTypes.Any())
        //    {
        //        cboAttachmentType.SelectedIndex = 0;
        //    } 
        //}

        //public void InitEvent()
        //{
        //    txtFileName.RegisterPrimaryInputWith(txtNote);
        //    cboAttachmentType.RegisterEnglishInput();
        //    txtFileName.RegisterKeyEnterNextControlWith(cboAttachmentType, txtNote);
        //}

        //public bool InValid()
        //{
        //    if (!string.IsNullOrEmpty(_fullPath))
        //    {
        //        if (!txtFileName.IsValidRequired(_lblAttachmentName.Text) |
        //            !cboAttachmentType.IsSelected())
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //public void Read()
        //{
        //    txtFileName.Text = Media.Name ?? string.Empty;
        //    cboAttachmentType.SelectedValue = Media?.MediaTypeId ?? 0;
        //    txtNote.Text = Media.Note ?? string.Empty;
        //    _extension = Path.GetExtension(Media.Name);
        //    //_fullPath = (Flag == GeneralProcess.Add) ? Media.Path : " - ";
        //    _fullPath = Media.Path;
        //    var dispalyPath = (_fullPath.Length <= 45) ? _fullPath : $"{_fullPath.Substring(0, 45)}...";
        //    _lblFilePath.Text = $"File Path: {dispalyPath}";
        //    //Tool tip for file path
        //    ToolTip toolTip = new ToolTip();
        //    toolTip.ShowAlways = true;
        //    toolTip.SetToolTip(_lblFilePath, _fullPath);
        //}

        //public void Write()
        //{
        //    var fileName = $"{Path.GetFileNameWithoutExtension(txtFileName.Text)}{_extension}";

        //    if (Flag == GeneralProcess.Add)
        //    {
        //        FileObject = new FileObject();
        //        FileObject.FileName = fileName;
        //        FileObject.MediaTypeId = (int)cboAttachmentType.SelectedValue;
        //        FileObject.Note = txtNote.Text;
        //        FileObject.File = _fullPath;
        //    }
        //    else if (Flag == GeneralProcess.Update)
        //    {
        //        Media.Name = fileName;
        //        Media.MediaTypeId = (int)cboAttachmentType.SelectedValue;
        //        Media.Note = txtNote.Text;
        //    }
        //}

        //public async void Save()
        //{
        //    if (Flag == GeneralProcess.View)
        //    {
        //        this.Close();
        //        return;
        //    }

        //    if (Flag == GeneralProcess.Add && string.IsNullOrEmpty(_fullPath))
        //    {
        //        this.Close();
        //        return;
        //    }

        //    if (InValid()) return;

        //    Write();

        //    if (Flag == GeneralProcess.Update)
        //    {
        //        Media = await btnSave.RunAsync(() =>
        //        {
        //            return MediaAPI.Instance.Edit(this.Media);
        //        });
        //    }

        //    DialogResult = DialogResult.OK;
        //}

        //public void ViewChangeLog()
        //{
            
        //}
        
        ////private void picBrowse_Click(object sender, EventArgs e)
        ////{
        ////    OpenFileDialog dialog = new OpenFileDialog();
        ////    dialog.Filter = "All Files|*.*" +
        ////                 "|Word Documents|*.doc;*.docx|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" +
        ////                 "|Image|*.jpg;*.jpeg;*.png;";

        ////    if (dialog.ShowDialog() == DialogResult.OK)
        ////    {
        ////        _fullPath = dialog.FileName;
        ////        _extension = Path.GetExtension(_fullPath);
        ////        txtFileName.Text = Path.GetFileName(_fullPath);
        ////        lblFilePath.Text = $"File Path: {_fullPath}";
        ////    }
        ////}

        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    Save();
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        
        //private void txtFileName_TextChanged(object sender, EventArgs e)
        //{

        //}
        
    }
}
