//-----------------------------------------------------------------
//
// @(#)$Id: FormSerch.cs,v 1.0 2014/08/29 10:47:55 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 10:47:55 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
using KeywordSearch.Model;
using KeyWordSerch.Data;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;
using KeywordSearch.Domain.Service;

namespace KeyWordSerch
{
    public partial class FormSerch : FormBase
    {
        private object o = new object();
        private int m_iCompletedCount;

        SpanCount sc = new SpanCount();
        public FormSerch()
        {
            InitializeComponent();
            m_iCompletedCount = 0;
        }
        int completeCount = 0;
        int totalCount = 0;
        private void BtnStart_Click(object sender, EventArgs e)
        {
            ResetKeyWord();
            Start();
        }

        void Start()
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

            int maxThread = PubConst.MaxThread;
            this.BtnStart.Enabled = false;
            this.BtnSet.Enabled = false;
            if (KeyWords.GetCount() == 0)
            {
                if (listKeyWords.Items.Count > 0)
                {
                    foreach (object o in listKeyWords.Items)
                    {
                        KeyWords.AddKeyWords(o.ToString());
                    }
                }
                else
                {
                    if (listFailureKeyWords.Items.Count > 0)
                    {
                        if (MessageBox.Show("是否重新搜索失败keyWord?", "请确认?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i < listFailureKeyWords.Items.Count; i++)
                            {
                                KeyWords.AddKeyWords(listFailureKeyWords.Items[i].ToString());
                                listKeyWords.Items.Add(listFailureKeyWords.Items[i].ToString());
                                listFailureKeyWords.Items.RemoveAt(i);
                                i--;
                            }
                        }
                        else
                        {
                            this.BtnStart.Enabled = true;
                            this.BtnSet.Enabled = true;
                            return;

                        }
                    }
                    else
                    {
                        this.BtnStart.Enabled = true;
                        this.BtnSet.Enabled = true;
                        return;

                    }
                }
            }

#if DEBUG
            //String a = KeyWords.GetKeyWord();
            //String b = KeyWords.GetKeyWord();

            //KeyWords.Clear();
            //KeyWords.AddKeyWords(a);
            //KeyWords.AddKeyWords(b);
#endif

            sc.Reset();
            completeCount = 0;
            m_iCompletedCount = 0;
            totalCount = KeyWords.GetCount();
            timer1.Enabled = true;
            timer2.Enabled = true;
            this.lCount.Text = completeCount + "/" + totalCount;
            this.lFreeCount.Text = (totalCount - completeCount).ToString();
            lContent.Text = "关键字正在搜索中 ...";
            lNextTime.Text = "自动搜索任务开始 ...";

            if (maxThread > 0)
            {
                string ip1 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Ip1"];
                if (!string.IsNullOrEmpty(ip1))
                {
                    string port1 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Port1"];

                    WebProxy wp = new WebProxy(ip1, Convert.ToInt32(port1));
                    proccessControl1.Proxy = wp;
                }

                proccessControl1.Start(DateTime.Now.AddDays(-1));
                maxThread--;
            }
            else
            {
                return;
            }
            if (maxThread > 0)
            {
                string ip2 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Ip2"];
                if (!string.IsNullOrEmpty(ip2))
                {
                    string port2 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Port2"];

                    WebProxy wp = new WebProxy(ip2, Convert.ToInt32(port2));
                    proccessControl2.Proxy = wp;
                }
                proccessControl2.Start(DateTime.Now.AddDays(-1));
                maxThread--;
            }
            else
            {
                return;
            }
            if (maxThread > 0)
            {
                string ip3 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Ip3"];
                if (!string.IsNullOrEmpty(ip3))
                {
                    string port3 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Port3"];

                    WebProxy wp = new WebProxy(ip3, Convert.ToInt32(port3));
                    proccessControl3.Proxy = wp;
                }
                proccessControl3.Start(DateTime.Now.AddDays(-1));
                maxThread--;
            }
            else
            {
                return;
            }
            if (maxThread > 0)
            {
                string ip4 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Ip4"];
                if (!string.IsNullOrEmpty(ip4))
                {
                    string port4 = System.Configuration.ConfigurationManager.AppSettings["Proxy.Port4"];

                    WebProxy wp = new WebProxy(ip4, Convert.ToInt32(port4));
                    proccessControl4.Proxy = wp;
                }
                proccessControl4.Start(DateTime.Now.AddDays(-1));
                maxThread--;
            }
            else
            {
                return;
            }
        }

        DateTime AutoSerchTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        private void FormSerch_Load(object sender, EventArgs e)
        {
            ResetKeyWord();

            string[] times = PubConst.SerchTime.Split(':');
            int h = Convert.ToInt32(times[0]);
            int m = Convert.ToInt32(times[1]);

            AutoSerchTime = AutoSerchTime.AddHours(h).AddMinutes(m);

            proccessControl1.SearchComplete += new EventHandler(OnSerchComplete);
            proccessControl2.SearchComplete += new EventHandler(OnSerchComplete);
            proccessControl3.SearchComplete += new EventHandler(OnSerchComplete);
            proccessControl4.SearchComplete += new EventHandler(OnSerchComplete);

            proccessControl1.SearchSuccess += new EventHandler(OnSerchSuccess);
            proccessControl2.SearchSuccess += new EventHandler(OnSerchSuccess);
            proccessControl3.SearchSuccess += new EventHandler(OnSerchSuccess);
            proccessControl4.SearchSuccess += new EventHandler(OnSerchSuccess);


            proccessControl1.SearchFailure += new EventHandler(OnSerchFailure);
            proccessControl2.SearchFailure += new EventHandler(OnSerchFailure);
            proccessControl3.SearchFailure += new EventHandler(OnSerchFailure);
            proccessControl4.SearchFailure += new EventHandler(OnSerchFailure);

            proccessControl1.SearchAllComplete += new EventHandler(OnSearchAllComplete);
            proccessControl2.SearchAllComplete += new EventHandler(OnSearchAllComplete);
            proccessControl3.SearchAllComplete += new EventHandler(OnSearchAllComplete);
            proccessControl4.SearchAllComplete += new EventHandler(OnSearchAllComplete);

            proccessDetailControl1.SerchComplete += new EventHandler(OnDetailCompleteChanged);

        }

        private void ResetKeyWord()
        {
            KeyWords.Clear();
            listKeyWords.Items.Clear();
            listFailureKeyWords.Items.Clear();
            T_KeyWordsContextTableAdapter keyAdapter = new T_KeyWordsContextTableAdapter();
            keyAdapter.InitKeywords();
            DataTable table = keyAdapter.GetData(DateTime.Now.ToString("yyyyMMdd"));
            foreach (DataRow row in table.Rows)
            {
                string k = row[0].ToString();
                KeyWords.AddKeyWords(k);
                listKeyWords.Items.Add(k);
            }

            DataManager dm = new DataManager();
            table = dm.GetFailureKeyWord(DateTime.Now.ToString("yyyyMMdd"));
            foreach (DataRow row in table.Rows)
            {
                string k = row[0].ToString();
                listFailureKeyWords.Items.Add(k);
            }
        }

        void OnSerchSuccess(object sender, EventArgs e)
        {
            lock (this)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                                                   {
                                                       string count = this.lSuccessCount.Text;
                                                       int sCount = Convert.ToInt32(count);
                                                       lSuccessCount.Text = (sCount + 1).ToString();
                                                   }));
            }
        }
        void OnSerchFailure(object sender, EventArgs e)
        {
            lock (this)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                                                   {
                                                       string count = this.lFailureCount.Text;
                                                       string k = sender.ToString();
                                                       listFailureKeyWords.Items.Add(k);
                                                       int fCount = Convert.ToInt32(count);
                                                       lFailureCount.Text = (fCount + 1).ToString();
                                                   }));
            }
        }
        void OnSerchComplete(object sender, EventArgs e)
        {
            lock (this)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                                                   {
                                                       completeCount++;

                                                       string s = sender.ToString();
                                                       int index = s.IndexOf("|");
                                                       string k = s.Substring(index + 1, s.Length - index - 1);
                                                       string threadName = s.Substring(0, index);

                                                       listKeyWords.Items.Remove(k);
                                                       this.lCount.Text = completeCount + "/" + totalCount;
                                                       this.lFreeCount.Text = (totalCount - completeCount).ToString();
                                                   }));
            }
        }

        private void OnSearchAllComplete(object sender, EventArgs e)
        {
            lock(o)
            {         
                this.BeginInvoke(new MethodInvoker(delegate()
                                                   {
                                                       m_iCompletedCount++;

                                                       if (m_iCompletedCount == PubConst.MaxThread)
                                                       {
                                                           StatisticsService.Instance.SendReport();
                                                           ShowComplete();
                                                       }
                                                   }
                                                   )
                                 );
            }
        }

        void ShowComplete()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            this.notifyIcon1.Text = "搜索完毕...\r\n完成：" + lCount.Text + "\r\n成功：" + lSuccessCount.Text + "\r\n失败：" + lFailureCount.Text + "\r\n剩余：" + lFreeCount.Text + "\r\n用时：" + lTime.Text;
            if (0 != Convert.ToDecimal(lSuccessCount.Text == "" ? "0" : lSuccessCount.Text))
                lContent.Text = "搜索完毕,平均用时：" + ((sc.Hour * 60m + sc.Min * 1m + sc.Send * 1m / 60m) / Convert.ToDecimal(lSuccessCount.Text == "" ? "0" : lSuccessCount.Text)).ToString("#0.0") + " 分/个 ...";
            this.BtnStart.Enabled = true;
            this.BtnSet.Enabled = true;
            this.notifyIcon1.Icon = KeyWordSerch.Properties.Resources.frm;
            this.notifyIcon1.ShowBalloonTip(5 * 1000, "KeyWord", "所有关键字搜索完毕...", ToolTipIcon.Info);
            if (PubConst.SerchMode == 0)
            {
                timer3.Enabled = true;
                //AutoSerchTime = AutoSerchTime.AddDays(1);
            }
        }
        void OnDetailCompleteChanged(object sender, EventArgs e)
        {
            lock (this)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                                                   {
                                                       this.btnContinue.Enabled = true;
                                                       this.notifyIcon1.ShowBalloonTip(5 * 1000, "KeyWord", "二级搜索完毕...", ToolTipIcon.Info);
                                                   }));
            }
        }

        private void FormSerch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            CloseAll();
            e.Cancel = true;
        }

        private void BtnViewResult_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormView")
                {
                    f.Activate();
                    return;
                }
            }

            FormView frm = new FormView();
            frm.Show();
        }

        private void BtnSingle_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormSingle")
                {
                    f.Activate();
                    return;
                }
            }

            FormSingle frm = new FormSingle();
            frm.Show();
        }

        void CloseAll()
        {
            int oCount = Application.OpenForms.Count;
            for (int i = 0; i < oCount; i++)
            {
                if (Application.OpenForms[i].Name == this.Name)
                {
                    continue;
                }
                Application.OpenForms[i].Close();
                i--;
                oCount--;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sc.Add(1);
            lTime.Text = sc.ToString();
            this.notifyIcon1.Text = "搜索正在进行中...\r\n完成：" + lCount.Text + "\r\n成功：" + lSuccessCount.Text + "\r\n失败：" + lFailureCount.Text + "\r\n剩余：" + lFreeCount.Text + "\r\n用时：" + lTime.Text;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            DataManager dm = new DataManager();
            List<KeywordResult> list = dm.GetList();
            this.btnContinue.Enabled = false;
            string itemIp = System.Configuration.ConfigurationManager.AppSettings["Proxy.ItemIp"];
            if (!string.IsNullOrEmpty(itemIp))
            {
                string itemPort = System.Configuration.ConfigurationManager.AppSettings["Proxy.ItemPort"];

                WebProxy wp = new WebProxy(itemIp, Convert.ToInt32(itemPort));
                proccessDetailControl1.Proxy = wp;
            }
            proccessDetailControl1.Start(list);
        }

        private void BtnRank_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormRank")
                {
                    f.Activate();
                    return;
                }
            }
            FormRank frm = new FormRank();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (proccessControl1.IsRunning
                || proccessControl2.IsRunning
                || proccessControl3.IsRunning
                || proccessControl4.IsRunning
                || proccessDetailControl1.IsRunning
                )
            {
                DialogResult val = MessageBox.Show("正在搜索,是关闭线程?", "请确认...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (val == DialogResult.No)
                {
                    return;
                }
                else
                {
                    proccessControl1.Stop();
                    proccessControl2.Stop();
                    proccessControl3.Stop();
                    proccessControl4.Stop();
                    proccessDetailControl1.Stop();
                    Application.ExitThread();
                }
            }
            else
            {
                DialogResult val = MessageBox.Show("确认退出?", "请确认...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (val == DialogResult.No)
                {
                    return;
                }
                else
                {
                    Application.ExitThread();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.Activate();
            }
            else
            {
                this.Activate();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.Activate();
            }
            else
            {
                this.Activate();
            }
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormSet")
                {
                    f.Activate();
                    return;
                }
            }
            FormSet frm = new FormSet();
            frm.Show();
        }

        int scCount = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (scCount == 0)
            {
                this.notifyIcon1.Icon = KeyWordSerch.Properties.Resources.running;
                scCount++;
            }
            else
            {
                this.notifyIcon1.Icon = KeyWordSerch.Properties.Resources.frm;
                scCount--;
            }
        }

        private void FormSerch_Shown(object sender, EventArgs e)
        {
           
            if (PubConst.SerchMode == 0)
            {
                if (DateTime.Now > AutoSerchTime && DateTime.Now < AutoSerchTime.AddDays(1))
                {
                    //if (listKeyWords.Items.Count > 0)
                    //{
                    //    BtnStart_Click(BtnStart, new EventArgs());
                    //}
                    //else
                    //{
                    AutoSerchTime = AutoSerchTime.AddDays(1);
                    timer3.Enabled = true;
                    //}
                }
                else
                {
                    timer3.Enabled = true;
                }
            }           
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").Trim() == AutoSerchTime.ToString("yyyy-MM-dd hh:mm:ss").Trim())
            {
                timer3.Enabled = false;    
                //ResetKeyWord();
                BtnStart_Click(BtnStart, new EventArgs());
                AutoSerchTime = AutoSerchTime.AddDays(1);
                        
                
            }
            else
            {
                TimeSpan ts = AutoSerchTime.Subtract(DateTime.Now);
                lNextTime.Text = string.Format("距离下次搜索还剩 {0:0#}:{1:0#}:{2:0#}", ts.Hours, ts.Minutes, ts.Seconds) + " 秒";
            }
        }
    }
}