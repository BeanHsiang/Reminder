using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Reminder
{
    public partial class PopWin : Form
    {
        private static readonly TimeSpan StartTime = DateTime.Now.TimeOfDay;//计时起始时间
        private static readonly TimeSpan EndTime = new TimeSpan(23, 0, 0);
        private const int Interval = 30;//间隔时间:分钟
        Point p;
        private Timer timer;

        public PopWin()
        {
            InitializeComponent();
        }

        private void PopWin_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.timer = new Timer();
            this.timer.Interval = Interval * 60000;
            this.timer.Tick += new EventHandler(ShowReminder);
            this.timer.Start();
        }

        private void PopWin_Activated(object sender, EventArgs e)
        {
            p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            //d = new PopupDelete(ShowReminder);
        }


        internal void ShowReminder(Object myObject, EventArgs myEventArgs)
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
            var tr = new Thread(() =>
            {
                Thread.Sleep(5000);
                this.Hide();
            });
            tr.Start();
        }



        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
            this.timer.Stop();
            this.timer.Start();
        }
    }
}
