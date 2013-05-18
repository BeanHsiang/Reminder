using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Reminder
{
    public partial class PopWin : Form
    {
        private static readonly TimeSpan StartTime = DateTime.Now.TimeOfDay;//计时起始时间
        private static readonly TimeSpan EndTime = new TimeSpan(23, 0, 0);
        private const int Interval = 40;//间隔时间:分钟
        delegate void PopupDelete();
        Point p;
        private Point StartPoint;
        private PopupDelete d;

        public PopWin()
        {
            InitializeComponent();
        }

        private void PopWin_Load(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;
            //this.WindowState = FormWindowState.Minimized;
            if (!backgroundWorker1.IsBusy)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
            notifyIcon1.ShowBalloonTip(1000);
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void PopWin_Activated(object sender, EventArgs e)
        {
            p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            d = new PopupDelete(ShowReminder);
        }


        internal void ShowReminder()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(d);
            }
            else
            {
                //this.TopMost = true;
                //    this.PointToScreen(p);
                //    this.Location = p;

                //this.WindowState = FormWindowState.Normal;

                //for (var i = 0; i <= 100; i += 20)
                //{
                //    //this.Location = new Point(this.Location.X, this.Location.Y - 1);
                //    //this.Refresh();
                //    this.Opacity = i;
                //    Thread.Sleep(500);//将线程沉睡时间调的越小升起的越快
                //}

                //for (var i = 100; i > 0; i -= 20)
                //{
                //    //this.Location = new Point(this.Location.X, this.Location.Y - 1);
                //    //this.Refresh();
                //    this.Opacity = i;
                //    Thread.Sleep(500);//将线程沉睡时间调的越小升起的越快
                //}
                //Thread.Sleep(Interval * 1000);
                this.Show();
                this.Refresh();
                Thread tr = new Thread(() =>
                {
                    Thread.Sleep(5000);
                    this.Hide();
                });
                tr.Start();
                //GC.Collect();
                //this.WindowState = FormWindowState.Minimized;

            }
        }



        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //TimeSpan nextTime = DateTime.Now.AddSeconds((int)Math.Round((Interval - (DateTime.Now.TimeOfDay - StartTime).TotalSeconds % Interval))).TimeOfDay;
            //TimeSpan intervalTime = new TimeSpan(0, 0, (int)Interval);
            //this.WindowState = FormWindowState.Minimized;
            //Thread.Sleep(Interval * 1000);
            //this.Hide();
            //this.WindowState = FormWindowState.Normal;
            while (!backgroundWorker1.CancellationPending)
            {
                //if (DateTime.Now.TimeOfDay >= nextTime)
                //{
                //    nextTime = nextTime + intervalTime;
                //    ShowReminder();
                //}
                Thread.Sleep(Interval * 60000);
                ShowReminder();
                //this.Show();
                //this.Visible = true;
                //this.ShowInTaskbar = true;
                //this.Refresh();
                //Thread.Sleep(2000);
                //this.Visible = false;
                //this.ShowInTaskbar = false;
                //this.Hide();
            }
            e.Cancel = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            if (this.Visible)
            {
                this.Visible = false;
                //this.ShowInTaskbar = false;
                //this.Show();
            }
            else
            {
                //this.Hide();
                this.Visible = true;
                //this.ShowInTaskbar = true;
            }
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.Interrupt();
            this.backgroundWorker1.CancelAsync();
        }
    }
}
