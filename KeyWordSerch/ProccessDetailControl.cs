using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using KeyWordSerch.Data;
using System.Threading;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;
using System.Net;
using KeywordSearch.Model;

namespace KeyWordSerch
{
    public partial class ProccessDetailControl : UserControl
    {

        public DataTable dt_color;

        WebProxy proxy;

        public WebProxy Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }

        List<KeywordResult> list = new List<KeywordResult>();
        public bool IsRunning
        {
            get { return serchThread == null ? false : serchThread.ThreadState != ThreadState.Stopped && serchThread.ThreadState != ThreadState.Aborted; }
        }
        public event EventHandler SerchComplete = null;
        public virtual void OnSerchComplete(object sender, EventArgs e)
        {
            if (SerchComplete != null)
            {
                SerchComplete(sender, e);
            }
        }
        Thread serchThread = null;
        public ProccessDetailControl()
        {
            InitializeComponent();
        }

        void SetValue(int MaxValue)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                progressBar1.PositionMax = MaxValue;
                progressBar1.Position = 0;
            }));
        }
        void SetLog(string keyWord, string Msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                Log.CreateLog(keyWord, Msg);
                lMsg.Text = Msg;

            }));
        }

        void SetLogText(string Msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                lMsg.Text = Msg;

            }));
        }

        void IncValue()
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                progressBar1.Position += 1;
            }));
        }


        public void Stop()
        {
            if (serchThread != null)
            {
                if (serchThread.ThreadState != ThreadState.Stopped)
                    serchThread.Abort();
            }
        }

        public void Start(List<KeywordResult> list)
        {
            this.loadingCircle1.Color = Color.FromArgb(10, 150, 10);
            this.loadingCircle1.Active = true;
            this.progressBar1.Position = 0;
            this.progressBar1.Text = "";
            this.lMsg.Text = "";
            serchThread = new Thread(new ParameterizedThreadStart(StartSearch)); ;
            serchThread.IsBackground = true;
            serchThread.Start(list);
        }

        void StartSearch(object list)
        {
            if (proxy != null)
            {
                SetLogText("正在验证代理IP的有效性,请稍后 ...");
                if (!HttpHelper.CheckPro(proxy))
                {
                    SetLog("ItemDetail", "代理IP设置不正确 ...");
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.loadingCircle1.Active = false;
                        this.loadingCircle1.Color = Color.DarkGray;
                    }));
                    return;
                }
            }


            List<KeywordResult> itemlist = list as List<KeywordResult>;
            int index = 1;
            SetValue(itemlist.Count - 1);
            foreach (KeywordResult m in itemlist)
            {
                SetPercent(index + "/" + itemlist.Count);
                KeywordResult itemNew = Copy(m);
                if (PubConst.Level == 3)
                {
                    if (string.IsNullOrEmpty(m.ItemUrl))
                        continue;
                    GetItemDetail(m.Keyword, m.ItemTitle, m.ItemUrl, m.SearchDateTime.AddDays(-1).ToString("yyyyMMdd"), ref itemNew);
                }
                else if (PubConst.Level == 2)
                {
                    GetItemSold(m.Keyword, m.ItemTitle, "http://offer.ebay.co.uk/ws/eBayISAPI.dll?ViewBidsLogin&_trksid=p4340.l2564&rt=nc&item=" + m.ItemID, ref itemNew);
                }
                itemNew.RetryCount += 1;

                DataManager dm = new DataManager();
                dm.UpdateMode(itemNew);

                IncValue();
                index++;
            }
            this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.loadingCircle1.Active = false;
                        this.loadingCircle1.Color = Color.DarkGray;

                    }));
            SetLog("ItemDetail", "搜索完毕 ...");
            OnSerchComplete(null, EventArgs.Empty);
        }

        KeywordResult Copy(KeywordResult m)
        {
            KeywordResult itemNew = new KeywordResult();
            itemNew.DayID = m.DayID;
            itemNew.Flag = m.Flag;
            itemNew.Key = m.Key;
            itemNew.ItemTitle = m.ItemTitle;
            itemNew.ItemID = m.ItemID;
            itemNew.ItemSoldByDay = m.ItemSoldByDay;
            itemNew.ItemSoldQuantity = m.ItemSoldQuantity;
            itemNew.ItemUrl = m.ItemUrl;
            itemNew.Keyword = m.Keyword;
            itemNew.Location = m.Location;
            itemNew.Postage = m.Postage;
            itemNew.SalePrice = m.SalePrice;
            itemNew.SellerID = m.SellerID;
            itemNew.SellerShopUrl = m.SellerShopUrl;
            itemNew.SearchDateTime = m.SearchDateTime;
            itemNew.RetryCount = m.RetryCount;
            itemNew.Rank = m.Rank;
            return itemNew;

        }
        void SetPercent(string Msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
             {
                 this.progressBar1.Text = Msg;
             }));
        }

        void GetItemDetail(string keyWord, string ItemTitle, string ItemDetailUrl, string SerchDate, ref KeywordResult m)
        {
            SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索明细资料 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {
                string itemDetailSource = HttpHelper.GetString(ItemDetailUrl, "", proxy, Encoding.UTF8);
                if (string.IsNullOrEmpty(itemDetailSource))
                {
                    SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索明细资料失败,2秒后重试,重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    serchThread.Join(2000);
                    continue;
                }

                SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索明细资料成功 ...");

                SetLog("ItemDetail", "Item：《" + ItemTitle + "》 开始匹配明细资料 ...");
                MatchCollection matchSoldList = null;
                MatchCollection matchSeller = null;
                MatchManager.MatchItemDetail(itemDetailSource, ref matchSoldList, ref matchSeller);
                if (matchSeller.Count > 0)
                {
                    m.Flag = 2;
                    m.SellerShopUrl = matchSeller[0].Groups[1].Value;
                    m.SellerID = matchSeller[0].Groups[2].Value;
                }
                if (matchSoldList.Count > 0)
                {
                    m.Flag = 2;
                    string soldListUrl = matchSoldList[0].Groups[1].Value;
                    int itemSoldQuantity = 0;
                    if (int.TryParse(matchSoldList[0].Groups[2].Value.Replace(",", ""), out itemSoldQuantity))
                    {
                        m.ItemSoldQuantity = itemSoldQuantity;
                    }
                    else
                    {

                        Log.CreateLog("Error", "KeyWord：" + keyWord + "\r\nItem：" + m.ItemID + "\r\nItemSoldQuantity：" + matchSoldList[0].Groups[2].Value);
                    }
                    GetItemSold(keyWord, ItemTitle, HttpUtility.HtmlDecode(soldListUrl), ref m);
                }
                else
                {
                    m.ItemSoldQuantity = 0;
                    SetLog("ItemDetail", "Item：《" + ItemTitle + "》 没有找到销售地址 ...");
                }
                return;
            }
            SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索明细资料失败 ...");
        }

        void GetItemSold(string keyWord, string ItemTitle, string SoldListUrl, ref KeywordResult m)
        {
            SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索销售列表 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {
                string soldListSource = HttpHelper.GetString(SoldListUrl, "", proxy, Encoding.UTF8);
                if (string.IsNullOrEmpty(soldListSource))
                {
                    SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索销售失败,2秒后重试,重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    serchThread.Join(2000);
                    continue;
                }
                SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索销售成功 ...");
                SetLog("ItemDetail", "Item：《" + ItemTitle + "》 匹配销售信息 ...");
                MatchCollection matchSoldPrice = null;
                MatchCollection matchQuantity = null;
                MatchCollection matchSoldDate = null;
                MatchCollection matchColor = null;
                MatchCollection matchColorPrice = null;
                MatchCollection matchStandbyPrice = null;

                MatchManager.MatchItemSold(soldListSource, ref matchSoldPrice, ref matchQuantity, ref matchSoldDate, ref matchColor, ref matchColorPrice, ref matchStandbyPrice);

                if (matchSoldPrice.Count > 0 && matchSoldDate.Count == matchQuantity.Count && matchSoldPrice.Count <= matchQuantity.Count)
                {
                    SetLog("ItemDetail", "Item：《" + ItemTitle + "》 销售信息匹配成功 ...");
                    int totalQuantity = 0;

                    int dt_count = 0;
                    dt_color = new DataTable("color_quan");
                    dt_color.Columns.Add("pro_color", System.Type.GetType("System.String"));//颜色
                    dt_color.Columns.Add("pro_quan", System.Type.GetType("System.Int32"));//各颜色的数量
                    dt_color.Columns.Add("pro_price", System.Type.GetType("System.Double"));//各颜色的价格
                    for (int i = 0; i < matchSoldPrice.Count; i++)
                    {
                        string quantity = matchQuantity[i].Groups[2].Value;
                        string soldTime = matchSoldDate[i].Groups[2].Value;
                        //m.Color = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";
                        string Mcolor = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";
                        Mcolor = Mcolor.Replace(@"</b><br>", ";");
                        Mcolor = Mcolor.Replace(@"<b>", "");
                        Mcolor = Mcolor.Replace(@"&amp;", "&");
                        m.Color = Mcolor;
                        //m.Color = matchColor.Count > 0 ? matchColor[i].Groups[2].Value : "";
                        string standbyprice = matchStandbyPrice.Count == 1 ? matchStandbyPrice[0].Groups[1].Value : m.SalePrice.ToString();
                        string colorprice = matchColorPrice.Count > 0 ? matchColorPrice[i].Groups[1].Value : standbyprice;//颜色的价格
                        DateTime sTime = DateTimeHelper.GetDate(soldTime);
                        if (PubClass.IsValidDate(sTime))
                        {
                            int q = 0;
                            if (int.TryParse(quantity.Replace(",", ""), out q))
                            {
                                totalQuantity += q;

                                dt_count = dt_color.Rows.Count;
                                int temp_sign = 0;
                                int quantity_temp = 0;
                                Int32.TryParse(quantity, out quantity_temp);
                                for (int k = 0; k < dt_count; k++)
                                {
                                    if (dt_color.Rows[k][0].ToString() == m.Color)
                                    {
                                        dt_color.Rows[k][1] = Convert.ToInt32(dt_color.Rows[k][1]) + quantity_temp;
                                        temp_sign = 1;
                                        break;
                                    }
                                }
                                if (temp_sign == 0)
                                {
                                    DataRow dr = dt_color.NewRow();
                                    dr[0] = m.Color;
                                    dr[1] = quantity_temp;
                                    dr[2] = colorprice;
                                    dt_color.Rows.Add(dr);
                                }
                            }
                            else
                            {

                                Log.CreateLog("Error", "KeyWord：" + keyWord + "\r\nItem：" + m.ItemID + "\r\nDayTotalQuantity：" + quantity);
                            }
                        }
                    }
                    m.ItemSoldByDay = totalQuantity;
                    m.Flag = 3;
                }
                else
                {
                    if (soldListSource.Contains("Enter a verification code to continue"))
                    {
                        SetLog("ItemDetail", "Item：《" + ItemTitle + "》 需要验证码,跳过 ...");
                    }
                    else
                    {
                        SetLog("ItemDetail", "Item：《" + ItemTitle + "》 销售信息匹配失败 ...");
                    }
                }
                return;
            }
            SetLog("ItemDetail", "Item：《" + ItemTitle + "》 搜索销售失败 ...");
        }
    }
}
