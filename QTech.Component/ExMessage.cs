using Storm.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Storm.Domain;
using EasyServer.Domain.Exceptions;
using EasyServer.Domain;

namespace QTech.Component
{
    public partial class ExMessage : ExDialog
    {
        
        public ExMessage()
        {
            InitializeComponent();
            //ResourceHelper.ApplyResource(flowLayoutPanel1); 
            EventHandler eh = new EventHandler(tb_Changed);
            lblMessage.TextChanged += eh;
            lblMessage.ClientSizeChanged += eh;
        }
        private bool busy = false;
        private Action<ExMessage> _action;
        public DialogResult ShowDialog(string message, string title, MessageBoxButtons button, MessageBoxIcon icon,
            Action<ExMessage> action = null, bool isFocusYes = false)
        {
            // MAKE SURE ALL BUTTON ARE HIDE.
            foreach (Control btn in flowLayoutPanel1.Controls)
            {
                if (btn is Button)
                {
                    btn.Hide();
                }
            }
            lblMessage.Text = message;
            
            Text = title;

            // BUTTON SETTING.
            switch (button)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    btnAbort.Show();
                    btnRetry.Show();
                    btnIgnore.Show();
                    break;
                case MessageBoxButtons.OK:
                    btnOK.Show();
                    break;
                case MessageBoxButtons.OKCancel:
                    btnOK.Show();
                    btnCancel.Show();
                    break;
                case MessageBoxButtons.RetryCancel:
                    btnRetry.Show();
                    btnCancel.Show();
                    break;
                case MessageBoxButtons.YesNo:
                    btnYes.Show();
                    btnNo.Show();
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnYes.Show();
                    btnNo.Show();
                    btnCancel.Show();
                    break;
            }

            // ICON SETTING.
            if (icon == MessageBoxIcon.Asterisk) pictureBox.Image = SystemIcons.Asterisk.ToBitmap();
            else if (icon == MessageBoxIcon.Error) pictureBox.Image = SystemIcons.Error.ToBitmap();
            else if (icon == MessageBoxIcon.Exclamation) pictureBox.Image = SystemIcons.Exclamation.ToBitmap();
            else if (icon == MessageBoxIcon.Hand) pictureBox.Image = SystemIcons.Hand.ToBitmap();
            else if (icon == MessageBoxIcon.Information) pictureBox.Image = SystemIcons.Information.ToBitmap();
            else if (icon == MessageBoxIcon.None) pictureBox.Image = null;
            else if (icon == MessageBoxIcon.Question) pictureBox.Image = SystemIcons.Question.ToBitmap();
            else if (icon == MessageBoxIcon.Stop) pictureBox.Image = SystemIcons.Error.ToBitmap();
            else if (icon == MessageBoxIcon.Warning) pictureBox.Image = SystemIcons.Warning.ToBitmap(); 
            action?.Invoke(this);
            if (isFocusYes)
            {
                this.ActiveControl = btnYes;
            }
            return base.ShowDialog();
        }

         

        void tb_Changed(object sender, EventArgs e)
        {
            if (busy) return;
            busy = true;
            TextBox tb = sender as TextBox;
            Size tS = TextRenderer.MeasureText(tb.Text, tb.Font);
            bool Hsb = tb.ClientSize.Height < tS.Height + Convert.ToInt32(tb.Font.Size);
            bool Vsb = tb.ClientSize.Width < tS.Width;

            if (Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Both;
            else if (!Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.None;
            else if (Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.Horizontal;
            else if (!Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Vertical;

            sender = tb as object;
            busy = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape && btnCancel.Visible)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if(keyData== Keys.Escape && btnNo.Visible)
            {
                this.DialogResult = DialogResult.No;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
    public class MsgBox
    {
        public static DialogResult ShowDialog(string message, string title, MessageBoxButtons button, MessageBoxIcon icon,Action<ExMessage> action =null, bool isFocusYes = false)
        {
            return (new ExMessage()).ShowDialog(message, title, button, icon,action, isFocusYes);
        }

        public static DialogResult ShowInformation(string message, string title)
        {
            return ShowDialog(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowInformation(string message)
        {
            return ShowDialog(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string message, string title, bool isFocusYes = false)
        {
            return ShowDialog(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, null, isFocusYes);
        }

        public static DialogResult ShowWarning(string message, string title,Action<ExMessage> action =null)
        {
            return ShowDialog(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning,action);
        }

        public static DialogResult ShowError(string message, string title)
        {
            return ShowDialog(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(Exception ex)
        { 
            return ShowError(ex, ErrResx.Error);
        }
        public static DialogResult ShowError(Exception ex, string title)
        {
            var showEx = ex;
            if (ex is InfoMessage info)
            {
                LogError(info);
                return ShowInformation(info.Message, title);
            }
            else if (ex is LogicException logic)
            {
                LogError(logic);
                return ShowInformation(logic.Message, title);
            }
            else if (ex is FluentException fluent)
            {
                var lineMessage = new List<string>(); 
                foreach (var item in fluent.Model.Errors)
                {
                    lineMessage.AddRange(item.Value.Select(x => x.Replace(item.Key, ResourceHelper.Translate(item.Key))).ToArray()); 
                }
                var fluentExp = new FluentException(string.Join(Environment.NewLine, lineMessage.ToArray()),fluent.Model);
                LogError(fluentExp);
                return ShowInformation(fluentExp.Message, title);
            }
            else
            {
                var message = ex.Message;

                if (ex.InnerException != null)
                {
                    showEx = ex.InnerException;
                }
                LogError(showEx);
                return ShowError(message, title);
            } 
        }

        public static void LogError(Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("\r\nException   : {0}", ex.Message ?? "N/A");
            str.AppendFormat("\r\nSource      : {0}", ex.Source ?? "N/A");
            str.AppendFormat("\r\nStackTrace  : {0}", ex.StackTrace ?? "N/A");
            str.AppendFormat("\r\nDate        : {0}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt"));
            str.AppendFormat("\r\n*****************************************************\r\n");
            System.IO.File.AppendAllText(Application.StartupPath + "/error.txt", str.ToString());
        }
    } 
}
