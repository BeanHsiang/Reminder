using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Reminder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PopWin frm = new PopWin();
            Application.Run(frm);
            //HideOnStartupApplicationContext context = new HideOnStartupApplicationContext(new PopWin());
            //Application.Run(context);
        }
    }

    //internal class HideOnStartupApplicationContext : ApplicationContext
    //{
    //    private Form mainFormInternal;

    //    // 构造函数，主窗体被存储在mainFormInternal
    //    public HideOnStartupApplicationContext(Form mainForm)
    //    {
    //        this.mainFormInternal = mainForm;

    //        this.mainFormInternal.Closed += new EventHandler(mainFormInternal_Closed);
    //    }

    //    // 当主窗体被关闭时，退出应用程序
    //    void mainFormInternal_Closed(object sender, EventArgs e)
    //    {
    //        this.mainFormInternal.Close();
    //        Application.Exit();
    //    }
    //}
}
