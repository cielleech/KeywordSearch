using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace KeyWordSerch
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

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            bool IsCreated =  false;

            using (Mutex instance = new Mutex(true, "KeyWordSerch", out IsCreated))
            {
                instance.WaitOne();
                if (IsCreated)
                {
                    string d = "";
                    if (PubConst.BeginTimeMode == 0)
                    {
                        d = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        d = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    int temp_time = Convert.ToInt32(PubConst.Timedifference) * -1;
                    PubConst.SerchBeginDate = DateTime.Parse(d + " " + PubConst.QuantityBeginTime).AddHours(temp_time);
                    PubConst.SerchEndDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + PubConst.QuantityEndTime).AddHours(temp_time);
                    Application.Run(new FormSerch());
                    instance.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("已经启动了一个程序，请先退出！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
            }
            //Application.Restart();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.CreateLog("Error", ((Exception)e.ExceptionObject).ToString());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.CreateLog("Error", e.Exception.ToString());
        }
    }
}