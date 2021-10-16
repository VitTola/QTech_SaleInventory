
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

namespace Updater
{
    public partial class AboutUsDialog : Form
    {
        public AboutUsDialog()
        {
            InitializeComponent();
            InitEvent();
        }
        string filePath = string.Empty;
        string nextVersion = string.Empty;
        long fileSize;
        public string AppDownloadLink { get; set; } = "ftp://54.255.194.247/QTech_Sale/";
        public  string CurrentAppVersion { get; set; }

        public Version AppVersion { get; set; } = new Version();
        private void InitEvent()
        {
            Text = string.Empty;
            MinimizeBox = MaximizeBox = false;
            CenterToScreen();
            AppDownloadLink = StaticVar.AppDownloadLink;
            CurrentAppVersion = StaticVar.CurrentAppVersion;
        }

        bool exist = false;
        private async Task CheckIfFileExistsOnServer()
        {
            _lblVersion.Text = string.Empty;

            var result = await Task.Run(() =>
            {
                nextVersion = GetNextVersion();
                filePath = $"{AppDownloadLink}{nextVersion}.zip";

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
            });
        }
        private async void SetVersionText()
        {
            await CheckIfFileExistsOnServer();

            if (exist)
            {
                _lblVersion.Text = $"ទាញយកជំនាន់កម្មវិធីថ្មី {nextVersion}";
            }
        }

        private string GetNextVersion()
        {

            var subVersions = StaticVar.CurrentAppVersion.Split('.');
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
            SetVersionText();
        }
    }
}
