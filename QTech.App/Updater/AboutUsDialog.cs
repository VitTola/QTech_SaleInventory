using QTech.Base.Helpers;
using QTech.Component;
using QTech.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public QTech.Base.OutFaceModels.Version AppVersion { get; set; } = new Base.OutFaceModels.Version();
        private void InitEvent()
        {
            Text = string.Empty;
            MinimizeBox = MaximizeBox = false;
            CenterToScreen();
            
        }
        private async void ApplySetting()
        {
           
        }
        
        private void lblVersion_Click(object sender, EventArgs e)
        {
            //if (MsgBox.ShowQuestion(Resources.IsUpdate, "") == DialogResult.Yes)
            //{
            //    CopyUserConfig(AppVersion);
            //    try
            //    {
            //        System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Updater.exe"), GetUpdateVersion().ToString());
            //        var args = $"{AppVersion.AppVersion} {AppVersion.Url}";
            //        System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Updater.exe"), args);
            //        Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MsgBox.ShowError(ex);
            //    }
            //}
        }
        
        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new UpdaterDialog("", "").ShowDialog();

        }
    }
}
