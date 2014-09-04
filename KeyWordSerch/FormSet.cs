using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace KeyWordSerch
{
    public partial class FormSet : FormBase
    {
        public FormSet()
        {
            InitializeComponent();
        }

        private void BtnVerfiy1_Click(object sender, EventArgs e)
        {
            WebProxy proxy = GetProxy(txtIp1.Text.Trim(), txtPort1.Text.Trim());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool s = HttpHelper.GetString(proxy);
            sw.Stop();
            if (s)
            {
                lTime1.Text = sw.Elapsed.ToString();
            }
            else
            {
                lTime1.Text = "代理IP无效";
            }
        }


        WebProxy GetProxy(string Ip, string Port)
        {
            if (string.IsNullOrEmpty(Ip))
            {
                MessageBox.Show("Ip未设置");
                return null;
            }
            if (string.IsNullOrEmpty(Port))
            {
                MessageBox.Show("端口未设置");
                return null;
            }
            int port = 0;
            bool val = int.TryParse(Port, out port);
            if (!val)
            {
                MessageBox.Show("端口格式不正确");
                return null;
            }
            IPAddress ip = null;
            val = IPAddress.TryParse(Ip, out ip);
            if (!val)
            {
                MessageBox.Show("Ip格式不正确");
                return null;
            }
            WebProxy proxy = new WebProxy(Ip, port);
            return proxy;
        }

        private void BtnVerfiy2_Click(object sender, EventArgs e)
        {
            WebProxy proxy = GetProxy(txtIp2.Text.Trim(), txtPort2.Text.Trim());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool s = HttpHelper.GetString(proxy);
            sw.Stop();
            if (s)
            {
                lTime2.Text = sw.Elapsed.ToString();
            }
            else
            {
                lTime2.Text = "代理IP无效";

            }
        }

        private void BtnVerfiy3_Click(object sender, EventArgs e)
        {
            WebProxy proxy = GetProxy(txtIp3.Text.Trim(), txtPort3.Text.Trim());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool s = HttpHelper.GetString(proxy);
            sw.Stop();
            if (s)
            {
                lTime3.Text = sw.Elapsed.ToString();
            }
            else
            {
                lTime3.Text = "代理IP无效";

            }
        }

        private void BtnVerfiy4_Click(object sender, EventArgs e)
        {
            WebProxy proxy = GetProxy(txtIp4.Text.Trim(), txtPort4.Text.Trim());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool s = HttpHelper.GetString(proxy);
            sw.Stop();
            if (s)
            {
                lTime4.Text = sw.Elapsed.ToString();
            }
            else
            {
                lTime4.Text = "代理IP无效";

            }
        }

        private void BtnVerfiy5_Click(object sender, EventArgs e)
        {
            WebProxy proxy = GetProxy(txtIp5.Text.Trim(), txtPort5.Text.Trim());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool s = HttpHelper.GetString(proxy);
            sw.Stop();
            if (s)
            {
                lTime5.Text = sw.Elapsed.ToString();
            }
            else
            {
                lTime5.Text = "代理IP无效";

            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (r_today.Checked)
            {
                if (dtpbegindate.Value.Hour > dtpenddate.Value.Hour)
                {
                    MessageBox.Show("销量搜索起始日期不能大于终止日期");
                    return;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("Proxy.Ip1");
            config.AppSettings.Settings.Add("Proxy.Ip1", txtIp1.Text);
            config.AppSettings.Settings.Remove("Proxy.Port1");
            config.AppSettings.Settings.Add("Proxy.Port1", txtPort1.Text);


            config.AppSettings.Settings.Remove("Proxy.Ip2");
            config.AppSettings.Settings.Add("Proxy.Ip2", txtIp2.Text);
            config.AppSettings.Settings.Remove("Proxy.Port2");
            config.AppSettings.Settings.Add("Proxy.Port2", txtPort2.Text);



            config.AppSettings.Settings.Remove("Proxy.Ip3");
            config.AppSettings.Settings.Add("Proxy.Ip3", txtIp3.Text);
            config.AppSettings.Settings.Remove("Proxy.Port3");
            config.AppSettings.Settings.Add("Proxy.Port3", txtPort3.Text);


            config.AppSettings.Settings.Remove("Proxy.Ip4");
            config.AppSettings.Settings.Add("Proxy.Ip4", txtIp4.Text);
            config.AppSettings.Settings.Remove("Proxy.Port4");
            config.AppSettings.Settings.Add("Proxy.Port4", txtPort4.Text);


            config.AppSettings.Settings.Remove("Proxy.ItemIp");
            config.AppSettings.Settings.Add("Proxy.ItemIp", txtIp5.Text);
            config.AppSettings.Settings.Remove("Proxy.ItemPort");
            config.AppSettings.Settings.Add("Proxy.ItemPort", txtPort5.Text);



            config.AppSettings.Settings.Remove("MaxThread");
            config.AppSettings.Settings.Add("MaxThread", nupThreadCount.Value.ToString("#0"));


            config.AppSettings.Settings.Remove("MinValue");
            config.AppSettings.Settings.Add("MinValue", txtThreadSleepMin.Text);


            config.AppSettings.Settings.Remove("MaxValue");
            config.AppSettings.Settings.Add("MaxValue", txtThreadSleepMax.Text);

            config.AppSettings.Settings.Remove("Level");
            config.AppSettings.Settings.Add("Level", nudSerchLevel.Value.ToString("#0"));


            config.AppSettings.Settings.Remove("ReTry");
            config.AppSettings.Settings.Add("ReTry", txtSerchCount.Text);


            config.AppSettings.Settings.Remove("RankQuantity");
            config.AppSettings.Settings.Add("RankQuantity", txtRankMinQuantity.Text);


            config.AppSettings.Settings.Remove("GetRankQuantity");
            config.AppSettings.Settings.Add("GetRankQuantity", txtRank.Text);

            config.AppSettings.Settings.Remove("GetSalesQuantity");
            config.AppSettings.Settings.Add("GetSalesQuantity", txtSalequantity.Text);

            config.AppSettings.Settings.Remove("SerchMode");
            config.AppSettings.Settings.Add("SerchMode", r_auto.Checked ? "0" : "1");

            config.AppSettings.Settings.Remove("AutoSerchTime");
            config.AppSettings.Settings.Add("AutoSerchTime", dateTimePicker1.Value.ToString("HH:mm"));


            config.AppSettings.Settings.Remove("BeginTimeMode");
            config.AppSettings.Settings.Add("BeginTimeMode", r_priviousday.Checked ? "0" : "1");


            config.AppSettings.Settings.Remove("QuantityBeginTime");
            config.AppSettings.Settings.Add("QuantityBeginTime", dtpbegindate.Value.ToString("HH:mm"));


            config.AppSettings.Settings.Remove("QuantityEndTime");
            config.AppSettings.Settings.Add("QuantityEndTime", dtpenddate.Value.ToString("HH:mm"));

            config.AppSettings.Settings.Remove("Timedifference");
            config.AppSettings.Settings.Add("Timedifference", nudtimedifference.Value.ToString("#0")); //时差

            config.AppSettings.Settings.Remove("PersonInCharge");
            config.AppSettings.Settings.Add("PersonInCharge", m_cmbPersonInCharge.Text);
            try
            {
                config.Save();
            }
            catch
            {
                MessageBox.Show("保存失败!");
                return;
            }
            if (MessageBox.Show(
                "配置已更改,是否重启以应用更改?",
                "请确认...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)
                == DialogResult.Yes
                )
            {
                Application.ExitThread();
                Application.Restart();
            }
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            this.txtIp1.Text = ConfigurationManager.AppSettings["Proxy.Ip1"];
            this.txtIp2.Text = ConfigurationManager.AppSettings["Proxy.Ip2"];
            this.txtIp3.Text = ConfigurationManager.AppSettings["Proxy.Ip3"];
            this.txtIp4.Text = ConfigurationManager.AppSettings["Proxy.Ip4"];
            this.txtIp5.Text = ConfigurationManager.AppSettings["Proxy.ItemIp"];

            this.txtPort1.Text = ConfigurationManager.AppSettings["Proxy.Port1"];
            this.txtPort2.Text = ConfigurationManager.AppSettings["Proxy.Port2"];
            this.txtPort3.Text = ConfigurationManager.AppSettings["Proxy.Port3"];
            this.txtPort4.Text = ConfigurationManager.AppSettings["Proxy.Port4"];
            this.txtPort5.Text = ConfigurationManager.AppSettings["Proxy.ItemPort"];

            this.nudSerchLevel.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["Level"]);
            this.nupThreadCount.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["MaxThread"]);
            this.txtRankMinQuantity.Text = ConfigurationManager.AppSettings["RankQuantity"];
            this.txtRank.Text = ConfigurationManager.AppSettings["GetRankQuantity"];
            this.txtSerchCount.Text = ConfigurationManager.AppSettings["ReTry"];
            this.txtThreadSleepMax.Text = ConfigurationManager.AppSettings["MaxValue"];
            this.txtThreadSleepMin.Text = ConfigurationManager.AppSettings["MinValue"];
            this.txtSalequantity.Text = ConfigurationManager.AppSettings["GetSalesQuantity"];
            this.nudtimedifference.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["Timedifference"]);//时差
            this.dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + PubConst.SerchTime);

            this.dtpbegindate.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + PubConst.QuantityBeginTime);
            this.dtpenddate.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + PubConst.QuantityEndTime);
            if (PubConst.SerchMode == 0)
            {
                this.r_auto.Checked = true;
            }
            else if (PubConst.SerchMode == 1)
            {
                this.r_hand.Checked = true;
            }

            if (PubConst.BeginTimeMode == 0)
            {
                this.r_priviousday.Checked = true;
            }
            else if (PubConst.SerchMode == 1)
            {
                this.r_today.Checked = true;
            }

            // 载入负责人
            
            //String connectString = "Data Source=192.168.1.14,5678;Initial Catalog=pro_req;Persist Security Info=True;User ID=sa;Password=rootsoft";

            //System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectString);
            //connection.Open();

            //System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(SqlPersonInCharge, connectString);
            //DataTable dataTable = new DataTable();

            //adapter.Fill(dataTable);

            //this.m_cmbPersonInCharge.Items.Add("All");
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    this.m_cmbPersonInCharge.Items.Add(row["PersonInCharge"]);
            //}
            //this.m_cmbPersonInCharge.Text = ConfigurationManager.AppSettings["PersonInCharge"];

            //connection.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const String SqlPersonInCharge = @"SELECT DISTINCT [Group] AS PersonInCharge
    FROM [pro_req].[dbo].[Keyword] AS tbKeyword
        , [pro_req].[dbo].[pro_saler_group] AS tbSalerGroup
    WHERE tbKeyword.PersonInCharge =  tbSalerGroup.Saler";
     
    }
}