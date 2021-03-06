using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QTech.Component
{
    public delegate void Process();

    public partial class Runner : Form
    {
        private static Runner instance = null;
        public static Runner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Runner();
                }
                return instance;
            }
        }

        public static void Run(Process process, string display)
        {
            Instance.Text = display;
            Instance.Start(process);

            if (Instance.Error != null)
            {
                MsgBox.ShowError(Instance.Error);
            }
        }

        public static void Run(Process process)
        {
            Run(process, string.Format("Procesing...", ""));
        }

        public static void RunNewThread(Process process, string display)
        {
            Instance.Text = display;
            Instance.StartNewThread(process);

            if (Instance.Error != null)
            {
                MsgBox.ShowError(Instance.Error);
            }
        }

        public static void RunNewThread(Process process)
        {
            RunNewThread(process, string.Format("Processing...", ""));
        }


        Exception error;
        Process process;

        public Runner()
        {
            InitializeComponent();
        }

        public Exception Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
            }
        }

        public override string Text
        {
            get
            {
                if (lblDisplay != null)
                {
                    return string.Concat( lblDisplay.Text+"       ");
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (lblDisplay != null)
                {
                    // this.lblDisplay.Text = value;
                    setText(value);
                }
            }
        }
        private delegate void stringFunc(string text);
        private void setText(string value)
        {
            if (lblDisplay.InvokeRequired)
            {
                lblDisplay.Invoke(new stringFunc(setText), value);
                return;
            }
            lblDisplay.Text = value;
        }



        public void StartNewThread(Process p)
        {
            // log proces to start when timer tick.
            process = p;

            // start tick the timer.
            timerNewThread.Start();

            // show dialog waiting.
            ShowDialog();
        }

        private void timerNewThread_Tick(object sender, EventArgs e)
        {
            // stop timmer to make sure no process invoke once.
            timerNewThread.Stop();

            // error = null mean no error occur while process.
            error = null;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate(object s1, DoWorkEventArgs e1)
            {
                try
                {
                    process();
                    e1.Result = true;
                }
                catch (Exception ex)
                {
                    // error != null mean there are error
                    // occur when execute the last process().
                    error = ex;

                    // hide dialog
                    e1.Result = false;
                }
            };
            worker.RunWorkerCompleted += delegate(object s1, RunWorkerCompletedEventArgs e1)
            {
                Close();
                //if (!(bool)e1.Result)
                //{ 
                //    MessageBox.Show(this.error.Message, "ERROR");
                //}
            };
            worker.RunWorkerAsync();
        }




        public void Start(Process p)
        {
            // log proces to start when timer tick.
            process = p;

            // start tick the timer.
            timer.Start();

            // show dialog waiting.
            ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // catch all exception here to make sure 
            // the runner form will close even the process
            // encounter any error that was not caught.
            try
            {
                // stop timmer to make sure no process invoke once.
                timer.Stop();

                // exception = null mean no error occur while process.
                error = null;

                // do proces.
                process();

                // if no error occur hide dialog waiting.
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // error != null mean there are error
                // occur when execute the last process().
                error = ex;

                // hide dialog
                Hide();

                //// show error form.
                //MessageBox.Show( ex.Message,"ERROR");
            }
        } 
    } 
}