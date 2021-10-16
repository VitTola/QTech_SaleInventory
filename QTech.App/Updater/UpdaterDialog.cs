﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Base.Helpers;
using QTech.Db.Logics;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Db;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using System.IO.Compression;
using System.Windows.Threading;
using System.Web.Services.Protocols;

namespace QTech.Forms
{
    public partial class UpdaterDialog : ExDialog
    {

        private string[] _userLoggedIn = Properties.Settings.Default.USER_LOGGED_IN?
                                                 .Cast<string>().ToArray() ?? new string[0];

        public UpdaterDialog(string version, string link, long _fileSize)
        {
            InitializeComponent();
            _lblrootname.Name = "";
            _lblDownloaded.Text = "0.00MB(0.00%)";
            _lblFileSize.Text = "0.00MB";
            _lblTransferRate.Text = "0.00kb/s";
            AppVersion = version;
            LinkDownload = link;
            this._fileSize = _fileSize;
            btnUpdate_Click();

        }

        private readonly MyWebClient _client = new MyWebClient();
        private readonly Stopwatch _sw = new Stopwatch();
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;
        private long _fileSize;
        int percentage = 0;

        public string LinkDownload { get; set; }
        public string AppVersion { get; set; }
        public string ExtractPath => Application.StartupPath + string.Format("\\FileUpdate\\{0}", string.Concat(AppVersion, ".zip"));

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnUpdate_Click()
        {
            try
            {
                _client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                var downloadLink = new Uri(LinkDownload);
                _sw.Start();
                if (!Directory.Exists(Application.StartupPath + "/FileUpdate"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "/FileUpdate");
                }
                _client.Credentials = new NetworkCredential("Tola", "T123@tiger");
                _client.DownloadFileAsync(downloadLink, ExtractPath);
                _lblrootname.Text = Path.GetFileName(downloadLink.LocalPath);
                _lblVersion.Text = string.Format(BaseResource.Version, AppVersion);
            }
            catch (Exception ex)
            {
                if (MsgBox.ShowError(ex.Message, "") == DialogResult.OK)
                {
                    Environment.ExitCode = 1;
                    Close();
                }
            }
        }

        private bool Extract()
        {
            try
            {
                //KillProcess("QTech");
                var archive = ZipFile.OpenRead(ExtractPath);
                // get the root directory
                var root = AppVersion;
                var result = from curr in archive.Entries
                             where Path.GetDirectoryName(curr.FullName) != archive.Entries[0]?.FullName
                             where !string.IsNullOrEmpty(curr.Name)
                             select curr;

                var removeEntity = result?.FirstOrDefault(x => x.Name.EndsWith("RemoveNames.txt"));
                if (removeEntity != null)
                {
                    removeEntity.ExtractToFile(Path.Combine(Application.StartupPath, "RemoveNames.txt"), overwrite: true);
                }

                // remove old file
                var removePathName = Path.Combine(Application.StartupPath, "RemoveNames.txt");
                if (File.Exists(removePathName))
                {
                    var removeFilenames = File.ReadAllLines(removePathName).ToList();
                    if (removeFilenames.Any())
                    {
                        var folders = removeFilenames.Where(x => x.StartsWith("*") && x.EndsWith("*"));
                        if (folders?.Any() == true)
                        {
                            foreach (var folder in folders)
                            {
                                var folderName = folder.TrimStart('*').TrimEnd('*');
                                if (string.IsNullOrEmpty(folderName))
                                {
                                    continue;
                                }
                                var fullFolderPath = Path.Combine(Application.StartupPath, folderName);
                                if (Directory.Exists(fullFolderPath))
                                {
                                    Directory.Delete(fullFolderPath, recursive: true);
                                }
                            }
                        }

                        foreach (var fielName in removeFilenames)
                        {
                            var fullFileName = Path.Combine(Application.StartupPath, fielName);
                            if (File.Exists(fullFileName))
                            {
                                File.Delete(fullFileName);
                            }
                        }
                        // remove content from text
                        File.WriteAllText(removePathName, "");
                    }
                }

                foreach (var entry in result)
                {
                    var filePath = (Application.StartupPath + @"\" + entry.FullName.Replace(root, "")).Replace("/", "\\").Replace("\\\\", "\\");
                    var path = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    entry.ExtractToFile(filePath, true);
                }
                return true;
            }
            catch (Exception)
            {
                // rollback version here
                return false;
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var fileSize = _fileSize / 1024d / 1024d;
            var downloadCompleted = e.BytesReceived / 1024d / 1024d;
            var transferRate = e.BytesReceived / 1024d / _sw.Elapsed.TotalSeconds;
            percentage = (int)((e.BytesReceived * 100) / _fileSize);
            progressBar.Value = percentage;
            _lblFileSize.Text = $"{ fileSize:N2}MB";
            _lblDownloaded.Text = $"{downloadCompleted:N2}MB ({percentage}%)";
            _lblTransferRate.Text = $"{transferRate:N2}kb/s";
            if (e.TotalBytesToReceive == _fileSize)
            {
                Completed();
            }

        }

        private void Completed()
        {
            _sw.Reset();
            if (Extract())
            {
                System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "QTech.exe"));
            }
            Application.Exit();
        }

        private void KillProcess(string processName)
        {
            foreach (var process in System.Diagnostics.Process.GetProcessesByName(processName).ToList())
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }
        private void digheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }
        private void _bClose_Click(object sender, EventArgs e)
        {
            Environment.ExitCode = 1;
            Close();
        }
    }

    internal class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            FtpWebRequest req = (FtpWebRequest)base.GetWebRequest(address);
            req.UsePassive = false;
            return req;
        }

    }
}

