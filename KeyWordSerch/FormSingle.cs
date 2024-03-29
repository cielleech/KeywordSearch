using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Threading;
using System.Diagnostics;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;

namespace KeyWordSerch
{
    public partial class FormSingle : FormBase
    {
        string SerchDate;
        int GetMaxCount = 1;
        int GetNumber = 0;
        public FormSingle()
        {
            InitializeComponent();
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            if (IsRuning())
            {
                MessageBox.Show("正在搜索,请稍后 ...");
                return;
            }
            txtLog.Clear();
            if (cbbKeyWords.Text.Length == 0)
            {
                MessageBox.Show("请输入关键字");
                return;
            }
            this.btnMatch.Enabled = false;
            GetMaxCount = (int)nudRank.Value;
            GetNumber = (int)nudGetNumber.Value;
            SerchDate = dateTimePicker1.Value.ToString("yyyyMMdd");

            serchThread = new Thread(new ParameterizedThreadStart(StartSerchItems));
            serchThread.Start(cbbKeyWords.Text);
        }

        Thread serchThread = null;
        bool IsRuning()
        {
            return serchThread == null ? false : serchThread.ThreadState != System.Threading.ThreadState.Stopped && serchThread.ThreadState != System.Threading.ThreadState.Aborted;
        }

        void StartSerchItems(object keyWords)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AppendText("本次查询开始时间：《" + DateTime.Now.ToString() + "》...");

            AppendText("本次查询关键字：《" + keyWords.ToString() + "》...");

            AppendText("开始获取关键字结果集 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {

                string url = string.Format(MatchManager.eBaySearchUrl, HttpUtility.UrlEncode(keyWords.ToString(), UTF8Encoding.UTF8));

                AppendText("查询Url：" + url);

                string serchResult = HttpHelper.GetString(url, "", null, Encoding.UTF8);

                if (string.IsNullOrEmpty(serchResult))
                {
                    AppendText("获取关键字结果集失败,2秒后重试,正在重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    serchThread.Join(2000);
                    continue;
                }

                AppendText("首页信息获取成功 ...");

                if (!PubClass.IsNumber(keyWords.ToString()))
                {

                    AppendText("开始匹配一级信息 ...");

                    MatchCollection matchTables = null;
                    serchResult = serchResult.Replace("\r", "");
                    serchResult = serchResult.Replace("\n", "");
                    MatchManager.MatchAvailableItems(serchResult, ref matchTables);
                    string restul = serchResult;
                    if (matchTables.Count > 0)
                    {
                        AppendText("一级信息匹配成功,进入第二级查询 ...");
                        restul = matchTables[0].Groups[0].Value;
                    }
                    GetItemList(restul);
                }
                else
                {
                    string regexPostAge = "<span id=\"fshippingCost\" class=\"vi-is1-sh-srvcCost vi-is1-hideElem vi-is1-showElem\">(.*?)(\\d*.\\d*)</span>";
                    string regexLocation = "<div class=\"sh-ItemLoc\">Item location:(.*?)</div>";
                    string regexTitle = "h1 class=\"vi-is1-titleH1\">(.*?)</h1>";
                    string regexSalePrice = "itemprop=\"price\"(( class=\"vi-is1-prcp-eu\")|(.*?))[>](.*?)(\\d*.\\d*)</span>";
                    MatchCollection matchPostAge = Regex.Matches(serchResult, regexPostAge);
                    MatchCollection matchSoldList = Regex.Matches(serchResult, MatchManager.regexSoldListUrl);
                    MatchCollection matchSeller = Regex.Matches(serchResult, MatchManager.regexSellerInfo);
                    MatchCollection matchLocation = Regex.Matches(serchResult, regexLocation);
                    MatchCollection matchTitle = Regex.Matches(serchResult, regexTitle);
                    MatchCollection matchPrice = Regex.Matches(serchResult, regexSalePrice);
                    string itemTitle = "";
                    if (matchTitle.Count > 0)
                    {
                        itemTitle = matchTitle[0].Groups[1].Value;
                        if (itemTitle.Contains("itemprop"))
                        {
                            Match m = Regex.Match(itemTitle, "[>](.*?)[</]");
                            if (m.Success)
                            {
                                itemTitle = HttpUtility.HtmlDecode(m.Groups[1].Value);
                            }
                        }

                        AppendText("ItemTitle：" + itemTitle);
                    }
                    if (matchPrice.Count > 0)
                    {
                        string salePrice = matchPrice[0].Groups[5].Value;
                        AppendText("SalePrice：" + salePrice);
                    }
                    if (matchSeller.Count > 0)
                    {
                        string sellerShopUrl = matchSeller[0].Groups[1].Value;
                        string sellerId = matchSeller[0].Groups[2].Value;
                        AppendText("SellerId：" + sellerId);
                        AppendText("SellerShopUrl：" + sellerShopUrl);
                    }
                    if (matchLocation.Count > 0)
                    {
                        string location = matchLocation[0].Groups[1].Value;
                        AppendText("Location：" + location);
                    }
                    if (matchPostAge.Count > 0)
                    {
                        string postAge = matchPostAge[0].Groups[2].Value;
                        AppendText("PostAge：" + postAge);
                    }
                    if (matchSoldList.Count > 0)
                    {
                        string soldListUrl = matchSoldList[0].Groups[1].Value;
                        string totalSoldQuantity = matchSoldList[0].Groups[2].Value;
                        soldListUrl = HttpUtility.HtmlDecode(soldListUrl);
                        AppendText("SoldListUrl：" + soldListUrl);
                        AppendText("TotalSoldQuantity：" + totalSoldQuantity);

                        GetItemSold(soldListUrl);
                    }
                }
                sw.Stop();
                AppendText("本次查询时间：《" + sw.Elapsed.ToString() + "》");
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.btnMatch.Enabled = true;
                }));
                return;
            }
        }

        void GetItemList(string ItemTableSource)
        {
            AppendText("开始匹配二级信息 ...");
            MatchCollection matchUrl = null;
            MatchCollection matchSoldPrice = null;

            MatchManager.MatchItems(ItemTableSource, ref matchUrl, ref matchSoldPrice);

            if (matchUrl.Count > 0 && matchUrl.Count == matchSoldPrice.Count)
            {
                AppendText("二级信息匹配成功 ...");
                int index = matchUrl.Count;
                int beginIndex = 0;
                AppendText("总数：《" + matchUrl.Count + "》");

                if (GetNumber > 0)
                {
                    GetNumber -= 1;
                    if (GetNumber <= index)
                    {
                        beginIndex = GetNumber;
                        index = GetNumber + 1;
                        AppendText("取第《" + beginIndex + "》条记录 ...");
                    }
                    else
                    {
                        AppendText("没有第《" + beginIndex + "》条 ...", Color.Red);
                        return;
                    }

                }
                else
                {
                    if (index > GetMaxCount)
                    {
                        index = GetMaxCount;
                        AppendText("总数大于《" + GetMaxCount + "》,取前《" + index + "》条记录");
                    }
                }
                AppendText("\r\n");

                for (int i = beginIndex; i < index; i++)
                {
                    string itemName = matchUrl[i].Groups[3].Value;
                    string itemUrl = matchUrl[i].Groups[2].Value;
                    string priceSource = matchSoldPrice[i].Groups[4].Value;

                    AppendText("================================================================================================================");
                    AppendText("*                                                                                                              *");
                    AppendText("*  Item" + i + ":      " + itemName.PadRight(96, ' ') + "*");
                    AppendText("*                                                                                                              *");
                    AppendText("================================================================================================================");

                    AppendText("ItemUrl：" + itemUrl);
                    AppendText("ItemSoldPric：" + priceSource);

                    GetItemDetail(itemUrl);

                    AppendText("\r\n");
                }
            }
            else
            {
                AppendText("二级信息匹配失败,结束 ...");
            }
        }

        void GetItemDetail(string ItemDetailUrl)
        {
            AppendText("开始获取Item明细资料 ...");
            string itemDetailSource = HttpHelper.GetString(ItemDetailUrl, "", null, Encoding.UTF8);

            if (string.IsNullOrEmpty(itemDetailSource))
            {
                AppendText("获取Item明细资料失败 ...");
                return;
            }
            AppendText("获取Item明细资料成功 ...");

            string regexPostAge = "<span id=\"fshippingCost\" class=\"vi-is1-sh-srvcCost vi-is1-hideElem vi-is1-showElem\">(.*?)(\\d*.\\d*)</span>";
            string regexItemNumber = "Item number: (.*?)</span>";
            string regexLocation = "<div class=\"sh-ItemLoc\">Item location:(.*?)</div>";
            AppendText("开始匹配运费等信息 ...");
            MatchCollection matchPostAge = Regex.Matches(itemDetailSource, regexPostAge);
            MatchCollection matchSoldList = Regex.Matches(itemDetailSource, MatchManager.regexSoldListUrl);
            MatchCollection matchSeller = Regex.Matches(itemDetailSource, MatchManager.regexSellerInfo);
            MatchCollection matchItemNumber = Regex.Matches(itemDetailSource, regexItemNumber);
            MatchCollection matchLocation = Regex.Matches(itemDetailSource, regexLocation);

            AppendText("匹配结果 ...");
            if (matchSeller.Count > 0)
            {
                string sellerShopUrl = matchSeller[0].Groups[1].Value;
                string sellerId = matchSeller[0].Groups[2].Value;
                AppendText("SellerId：" + sellerId);
                AppendText("SellerShopUrl：" + sellerShopUrl);
            }
            if (matchLocation.Count > 0)
            {
                string Location = matchLocation[0].Groups[1].Value;
                AppendText("Location：" + Location);
            }
            if (matchItemNumber.Count > 0)
            {
                string ItemNumber = matchItemNumber[0].Groups[1].Value;
                AppendText("ItemNumber：" + ItemNumber);
            }
            if (matchPostAge.Count > 0)
            {
                string pos = matchPostAge[0].Groups[2].Value;
                AppendText("PostAge：" + pos);

            }
            else
            {
                AppendText("PostAge：Not Found..");
            }
            if (matchSoldList.Count > 0)
            {
                string soldListUrl = matchSoldList[0].Groups[1].Value;
                string totalSoldQuantity = matchSoldList[0].Groups[2].Value;
                soldListUrl = HttpUtility.HtmlDecode(soldListUrl);
                AppendText("SoldListUrl：" + soldListUrl);
                AppendText("TotalSoldQuantity：" + totalSoldQuantity);
                GetItemSold(soldListUrl);
            }
            else
            {
                AppendText("SoldUrl：无,结束 ...");
            }
        }

        /*<td align="left" valign="top" class="onheadNav"><a href="http://offer.ebay.co.uk/ws/eBayISAPI.dll?ViewBidderProfile&amp;mode=1&amp;item=180642126872&amp;aid=s***e&amp;eu=V3vNncx74TOobWg%2B8niKOQFrywC0Q4je&amp;view=&amp;ssPageName=PageBidderProfileViewBids_None_ViewLink&amp;frmPage=992"> s***e</a><img src="http://pics.ebaystatic.com/aw/pics/s.gif" width="4" border="0" alt=" ">( <a id="feedBackScoreDiv3">115</a><img align="absmiddle" border="0" height="25" width="25" alt="Feedback score is 100 to 499" title="Feedback score is 100 to 499" src="http://pics.ebaystatic.com/aw/pics/uk/icon/iconTealStar_25x25.gif">)<span> </span></td>
        <td align="left" nowrap valign="top" style="padding-left:10px;" class="variationContentValueFont">GU10 Replacement Wattage: <b>45w Repacement Bulb 60 Led 3w</b><br>Choose Colour: <b>White</b><br></td>
        <td align="left" nowrap valign="top" class="contentValueFont">£4.49</td>
        <td align="middle" valign="top" class="contentValueFont">1</td>
        <td align="left" valign="top" class="contentValueFont">20-Dec-11 10:34:57 GMT</td>
        */
        /*
        <td align="left" nowrap valign="middle" class="contentValueFont">£7.50</td>
        <td align="middle" valign="middle" class="contentValueFont">1</td>
        <td align="left" valign="middle" class="contentValueFont">19-Dec-11 14:41:13 GMT</td>
        */
        void GetItemSold(string SoldListUrl)
        {
            AppendText("开始获取销售记录资料 ...");

            string soldListSource = HttpHelper.GetString(SoldListUrl, "", null, Encoding.UTF8);
            if (string.IsNullOrEmpty(soldListSource))
            {
                AppendText("获取销售记录资料失败 ...");
                return;
            }

            AppendText("销售记录资料获取成功 ...");

            AppendText("开始匹配销售记录资料 ...");
            MatchCollection matchSoldPrice = null;
            MatchCollection matchQuantity = null;
            MatchCollection matchSoldDate = null;
            MatchCollection matchColor = null;
            MatchCollection matchColorPrice = null;
            MatchCollection matchStandbyPrice = null;

            MatchManager.MatchItemSold(soldListSource, ref matchSoldPrice, ref matchQuantity, ref matchSoldDate, ref matchColor, ref matchColorPrice, ref matchStandbyPrice);

            if (matchSoldPrice.Count > 0 && matchSoldDate.Count == matchQuantity.Count && matchSoldPrice.Count <= matchQuantity.Count)
            {
                AppendText("销售记录资料匹配成功 ...");
                int totalQuantity = 0;
                int queryDayQuantity = 0;
                int dt_count = 0;
                DataTable dt_color = new DataTable("color_quan");
                dt_color.Columns.Add("pro_color", System.Type.GetType("System.String"));
                dt_color.Columns.Add("pro_quan", System.Type.GetType("System.Int32"));//取各颜色的数量


                for (int i = 0; i < matchSoldPrice.Count; i++)
                {
                    string salePrice = matchSoldPrice[i].Groups[3].Value;
                    string quantity = matchQuantity[i].Groups[2].Value;
                    string soldTime = matchSoldDate[i].Groups[2].Value;
                    //string color = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";
                    string Mcolor = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";
                    Mcolor = Mcolor.Replace(@"</b><br>", ";");
                    Mcolor = Mcolor.Replace(@"<b>", "");
                    Mcolor = Mcolor.Replace(@"&amp;", "&");
                    string color = Mcolor;
                    //string color = matchColor.Count > 0 ? matchColor[i].Groups[2].Value : "";
                    totalQuantity += Convert.ToInt32(quantity);
                    DateTime sTime = DateTimeHelper.GetDate(soldTime);

                    if (PubClass.IsValidDate(sTime))
                    {
                        AppendText(string.Format("SoldPrice：{0,6}      SoldQuantity：{1,3}       SoldDate：{2,24}     {3}", salePrice, quantity, sTime.ToString(), color), Color.Blue);
                        queryDayQuantity += Convert.ToInt32(quantity);
                        dt_count = dt_color.Rows.Count;
                        int temp_sign = 0;
                        int quantity_temp = 0;
                        Int32.TryParse(quantity, out quantity_temp);
                        for (int k = 0; k < dt_count; k++)
                        {
                            if (dt_color.Rows[k][0].ToString() == color)
                            {
                                dt_color.Rows[k][1] = Convert.ToInt32(dt_color.Rows[k][1]) + quantity_temp;
                                temp_sign = 1;
                                break;
                            }
                        }
                        if (temp_sign == 0)
                        {
                            DataRow dr = dt_color.NewRow();
                            dr[0] = color;
                            dr[1] = quantity_temp;
                            dt_color.Rows.Add(dr);
                        }

                    }
                    else
                    {
                        AppendText(string.Format("SoldPrice：{0,6}      SoldQuantity：{1,3}       SoldDate：{2,24}     {3}", salePrice, quantity, sTime.ToString(), color));
                    }
                }
                AppendText("------------------------------------------------------------------------------------------------------------------", Color.Red);
                for (int j = 0; j < dt_color.Rows.Count; j++)
                {
                    AppendText(string.Format("         TotalQuantity:{0,4}        QueryDaySold:{1,4}        ColorSold:{2,4}", totalQuantity, queryDayQuantity, dt_color.Rows[j][1]) + "           " + dt_color.Rows[j][0], Color.Red);
                }
            }
            else
            {
                AppendText("销售记录资料匹配失败 ...");
            }
        }

        void AppendText(string Msg)
        {

            AppendText(Msg, Color.Green);
        }

        void AppendText(string Msg, Color color)
        {

            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke(new MethodInvoker(delegate()
                {
                    txtLog.SelectionStart = txtLog.Text.Length;
                    txtLog.SelectionColor = color;
                    txtLog.AppendText(Msg);
                    txtLog.AppendText("\r\n");

                }));

            }
            else
            {
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.SelectionColor = color;
                txtLog.AppendText(Msg);
                txtLog.AppendText("\r\n");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsRuning())
            {

                DialogResult val = MessageBox.Show("正在搜索,是关闭线程?", "请确认...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (val == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    serchThread.Abort();
                }
            }
        }

        private void txtLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string target = e.LinkText;
            System.Diagnostics.Process.Start(target);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);

            T_KeyWordsTableAdapter keyAdapter = new T_KeyWordsTableAdapter();
            DataTable table = keyAdapter.GetData();
            cbbKeyWords.DataSource = keyAdapter.GetData();
            cbbKeyWords.DisplayMember = "KeyWords";
            cbbKeyWords.ValueMember = "KeyWords";
            this.cbbKeyWords.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbbKeyWords.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
}