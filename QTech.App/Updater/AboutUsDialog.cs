using QTech.Base.Helpers;
using QTech.Component;
using QTech.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Updater
{
    public partial class AboutUsDialog : ExDialog
    {
        public AboutUsDialog()
        {
            InitializeComponent();
            InitEvent();
        }
        string filePath = string.Empty;
        string nextVersion = string.Empty;
        long fileSize;

        public QTech.Base.OutFaceModels.Version AppVersion { get; set; } = new Base.OutFaceModels.Version();
        private void InitEvent()
        {
            Text = string.Empty;
            MinimizeBox = MaximizeBox = false;
            CenterToScreen();
        }
        private void ApplySetting()
        {
            _lblVersion.Text = string.Empty;
            if (CheckIfFileExistsOnServer())
            {
                _lblVersion.Text = $"ទាញយកជំនាន់កម្មវិធីថ្មី {nextVersion}";
            }

        }
        private bool CheckIfFileExistsOnServer()
        {
            bool exist = false;
            nextVersion = GetNextVersion();
            filePath = $"{ShareValue.AppDownloadLink}{nextVersion}.zip";

            var request = (FtpWebRequest)WebRequest.Create(filePath);
            request.Credentials = new NetworkCredential("Tola", "T123@tiger");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                fileSize = response.ContentLength;
                exist = true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    exist = false;
            }
            return exist;
        }
        private string GetNextVersion()
        {
            var subVersions = ShareValue.CurrentAppVersion.Split('.');
            int first = int.Parse(subVersions[0]);
            int second = int.Parse(subVersions[1]);
            int third = int.Parse(subVersions[2]);
            if (third < 9)
            {
                return $"v{first}.{second}.{third + 1}";
            }
            else if (third == 9)
            {
                return $"v{first}.{second + 1}.0";
            }
            else if (third == 9 && second < 9)
            {
                return $"v{first}.{second + 1}.0";
            }
            else if (third == 9 && second == 9)
            {
                return $"v{first + 1}.0.0";
            }
            return string.Empty;
        }
        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new UpdaterDialog(nextVersion, filePath, fileSize).ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutUsDialog_Load(object sender, EventArgs e)
        {
            ApplySetting();
        }
    }
}
