//-----------------------------------------------------------------
//
// @(#)$Id: ProccessControl.cs,v 1.0 2014/08/29 10:48:22 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 10:48:22 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using HtmlAgilityPack;
using KeywordSearch.Model;
using KeyWordSerch.Data;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;
using KeywordSearch.Domain.Service;

namespace KeyWordSerch
{
    public partial class ProccessControl : UserControl
    {
        WebProxy proxy;

        public WebProxy Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }

        public bool IsRunning
        {
            get
            {
                return searchThread == null ? false : searchThread.ThreadState != ThreadState.Stopped && searchThread.ThreadState != ThreadState.Aborted;
            }
        }
        public event EventHandler SearchSuccess = null;
        public event EventHandler SearchFailure = null;
        public event EventHandler SearchComplete = null;
        public event EventHandler SearchAllComplete = null;
        Thread searchThread = null;
        public ProccessControl()
        {
            InitializeComponent();
        }

        public DataTable dt_color = new DataTable();


        public virtual void OnSearchComplete(object sender, EventArgs e)
        {
            if (SearchComplete != null)
            {
                SearchComplete(sender, e);
            }
        }
        public virtual void OnSearchSuccess(object sender, EventArgs e)
        {
            if (SearchSuccess != null)
            {
                SearchSuccess(sender, e);
            }
        }
        public virtual void OnSearchFailure(object sender, EventArgs e)
        {
            StatisticsService.Instance.Add(proxy.Address.ToString());
            if (SearchFailure != null)
            {
                SearchFailure(sender, e);
            }
        }

        private void OnSearchAllComplete(object sender, EventArgs e)
        {
            if (null != SearchAllComplete)
            {
                SearchAllComplete(sender, e);
            }
        }

        void SetText(string Title)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                lKeyWord.Text = string.Format("KeyWord：{0}", Title);
            }));
        }

        void SetValue(int MaxValue)
        {
            SetValue(MaxValue, 0);
        }
        void SetValue(int MaxValue, int MinValue)
        {

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                progressBar1.PositionMax = MaxValue;
                progressBar1.Position = MinValue;
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
            if (searchThread != null)
            {
                if (searchThread.ThreadState != ThreadState.Stopped)
                    searchThread.Abort();
            }
        }

        public void Start(DateTime date)
        {
            this.loadingCircle1.Color = Color.FromArgb(10, 150, 10);
            this.loadingCircle1.Active = true;
            this.lMsg.Text = "";
            this.lKeyWord.Text = "";
            this.progressBar1.Text = "";
            this.progressBar1.Position = 0;
            searchThread = new Thread(new ParameterizedThreadStart(StartSearch));
            searchThread.IsBackground = true;
            searchThread.Start(date);
        }

        void StartSearch(object ODate)
        {
            DateTime SerchDate = Convert.ToDateTime(ODate);
            bool isCheck = false;
            while (true)
            {
                if (!isCheck)
                {
                    isCheck = true;
                    if (proxy != null)
                    {
                        SetLogText("正在验证代理IP的有效性,请稍后 ...");
                        if (!HttpHelper.CheckPro(proxy))
                        {
                            SetLogText("代理IP设置不正确 ...");
                            this.BeginInvoke(new MethodInvoker(delegate()
                            {
                                this.loadingCircle1.Active = false;
                                this.loadingCircle1.Color = Color.DarkGray;
                            }));

                            break;
                        }
                    }

                }

                string keyWord = KeyWords.GetKeyWord();

                if (keyWord == null)
                {
                    SetLogText("关键字搜索完毕 ...");
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.loadingCircle1.Active = false;
                        this.loadingCircle1.Color = Color.DarkGray;
                    }));
                    
                    break;
                }
                SetValue(0, 0);
                SetPercent("");

                SearchKeyword(keyWord, SerchDate);
                OnSearchComplete(this.Name + "|" + keyWord, EventArgs.Empty);
            }

            OnSearchAllComplete(this, EventArgs.Empty);
        }

        void SetPercent(string Msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
             {
                 this.progressBar1.Text = Msg;
             }));
        }

#if DEBUG
        private void SearchKeyword(String strKeyword, DateTime dteSearchDate)
        {
            SetText(strKeyword);
            String strUrl = String.Format(MatchManager.eBaySearchUrl, HttpUtility.UrlEncode(strKeyword.ToString(), UTF8Encoding.UTF8));
            SetLog(strKeyword, strKeyword + ": 开始搜索一级信息 ...");
            int iTryCount = 1;
            while (iTryCount++ < 4)
            {
                String strSearchResult = HttpHelper.GetString(strUrl, "", proxy, Encoding.UTF8);

                if (String.IsNullOrEmpty(strSearchResult))
                {
                    SetLog(strKeyword, String.Format("{0}:一级信息搜索失败, 2秒后重试, 重试第<< {1} >>次 ...", strKeyword, iTryCount));
                    searchThread.Join(2000);
                    continue;
                }

                SetLog(strKeyword, strKeyword + ": 一级信息搜索成功 ...");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(strSearchResult);

                if (!PubClass.IsNumber(strKeyword)) {
                    if (GetItems(doc, strKeyword, dteSearchDate)) {
                        OnSearchSuccess(strKeyword, EventArgs.Empty);
                        InsertLog(strKeyword, true);
                        return;
                    }
                    else {
                        continue;
                    }
                }
                else
                {
                    KeywordResult m = new KeywordResult();
                    m.DayID = dteSearchDate.ToString("yyyy-MM-dd");
                    m.Keyword = strKeyword;
                    m.SearchDateTime = DateTime.Now;
                    m.ItemTitle = "";
                    m.ItemUrl = "http://www.ebay.co.uk/itm/" + strKeyword;
                    m.ItemID = strKeyword;
                    m.Rank = 0;
                    m.SellerShopUrl = "";
                    m.SellerID = "";
                    m.Flag = 1;

                    bool matchSuccess = false;

                    // Title
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//h1[@class=\"it-ttl\"][@itemprop=\"name\"][@id=\"itemTitle\"]");
                    if (null != node)
                    {
                        String strItemTitle = HttpUtility.HtmlDecode(node.InnerText);
                        matchSuccess = true;

                        m.Flag = 3;
                        m.ItemTitle = strItemTitle;
                    }

                    // Price
                    Boolean bResult = false;
                    node = doc.DocumentNode.SelectSingleNode("//span[@itemprop=\"price\"]");
                    if (null != node)
                    {
                        Match matPrice = Regex.Match(node.InnerText.Replace(",", ""), "[0-9]+\\.[0-9]*");
                        if (matPrice.Success)
                        {
                            m.SalePrice = Decimal.Parse(matPrice.Value);
                            bResult = true;
                        }
                    }
                    if (!bResult)
                    {
                        Log.CreateLog("Error", "KeyWord：" + strKeyword + "\r\nItem：" + strKeyword + "\r\nSalePrice：search failed");
                    }

                    // Seller shop url
                    node = doc.DocumentNode.SelectSingleNode("//a[@href][span[@class=\"mbg-nw\"]]");
                    m.SellerShopUrl = (null == node) ? null : node.Attributes["href"].Value;

                    // Seller ID
                    node = doc.DocumentNode.SelectSingleNode("//a[@href]/span[@class=\"mbg-nw\"]");
                    m.SellerID = (null == node) ? null : node.InnerText;

                    // Location
                    node = doc.DocumentNode.SelectSingleNode("//div[@class=\"sh-loc\"]");//Item location:(.*?)</div>");
                    if (null != node)
                    {
                        Match matLocation = Regex.Match(node.InnerText, "Item location:(.*)");
                        m.Location = matLocation.Success ? matLocation.Groups[1].Value : null;
                    }

                    // Postage
                    node = doc.DocumentNode.SelectSingleNode("//span[@id=\"fshippingCost\"]//span[@class]");
                    if (null != node)
                    {
                        Match matPostage = Regex.Match(node.InnerText, "[0-9]+\\.[0-9]*");
                        m.Postage = matPostage.Success ? Decimal.Parse(matPostage.Value) : 0;
                    }

                    // Item sold quantity
                    node = doc.DocumentNode.SelectSingleNode("//span[@class='qtyTxt']//a[@href]");
                    if (null != node)
                    {
                        Match matSoldQuantity = Regex.Match(node.InnerText, "[0-9]+");
                        m.ItemSoldQuantity = matSoldQuantity.Success ? Int32.Parse(matSoldQuantity.Value) : 0;
                        GetItemSold(strKeyword, m.ItemTitle, 1, HttpUtility.HtmlDecode(node.Attributes["href"].Value), ref m);
                    }

                    if (matchSuccess)
                    {
                        OnSearchSuccess(strKeyword, EventArgs.Empty);

                        int dt_count = dt_color.Rows.Count;
                        //int dt_count = dt_color.Rows.Count > 0 ? dt_color.Rows.Count : 0;
                        if (dt_count > 1 && m.Flag == 3 && m.ItemSoldByDay != 0)
                        {
                            for (int k = 0; k < dt_count; k++)
                            {
                                m.Color = dt_color.Rows[k][0].ToString();
                                m.ColorPrice = Convert.ToDecimal(dt_color.Rows[k][2]);
                                m.ColorSold = Convert.ToInt32(dt_color.Rows[k][1]);

                                DataManager dm = new DataManager();
                                dm.AddMode_color(m, strKeyword, dteSearchDate.ToString("yyyy-MM-dd"));
                            }
                        }
                        else
                        {
                            if (m.ItemSoldByDay == 0)
                            {
                                m.Color = "";
                            }
                            m.ColorSold = m.ItemSoldByDay;
                            DataManager dm = new DataManager();
                            dm.AddMode(m, strKeyword, dteSearchDate.ToString("yyyy-MM-dd"));
                        }

                    }
                    else
                    {
                        OnSearchFailure(strKeyword, EventArgs.Empty);
                    }
                    InsertLog(strKeyword, matchSuccess);
                    return;
                }
            }
            OnSearchFailure(strKeyword, EventArgs.Empty);
            SetLog(strKeyword, strKeyword + "：一级信息搜索失败 ...");
            InsertLog(strKeyword, false);         
        }

#else


        void SearchKeyword(string KeyWord, DateTime SerchDate)
        {
            SetText(KeyWord);
            string url = string.Format(MatchManager.ebaySerchUrl, HttpUtility.UrlEncode(KeyWord.ToString(), UTF8Encoding.UTF8));
            SetLog(KeyWord, KeyWord + "：开始搜索一级信息 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {
                string serchResult = HttpHelper.GetString(url, "", proxy, Encoding.UTF8);

                if (string.IsNullOrEmpty(serchResult))
                {
                    SetLog(KeyWord, KeyWord + "：一级信息搜索失败,2秒后重试,重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    serchThread.Join(2000);
                    continue;
                }
                SetLog(KeyWord, KeyWord + "：一级信息搜索成功 ...");

                bool isItemId = PubClass.IsNumber(KeyWord);
                if (!isItemId)
                {
                    SetLog(KeyWord, KeyWord + "：开始匹配一级信息 ...");
                    MatchCollection matchItems = null;
                    serchResult = serchResult.Replace("\n", "");
                    serchResult = serchResult.Replace("\r", "");
                    MatchManager.MatchAvailableItems(serchResult, ref matchItems);
                    string matchresult = serchResult;
                    if (matchItems.Count > 0)
                    {
                        SetLog(KeyWord, KeyWord + "：一级信息匹配成功 ...");
                        matchresult = matchItems[0].Groups[0].Value;

                    }
                    bool matchSuccess = false;
#if DEBUG
                    GetItems(url, KeyWord, SerchDate);
                    matchSuccess = true;
#else
                    GetItems(matchresult, KeyWord, SerchDate, ref matchSuccess);
#endif
                    if (matchSuccess)
                    {
                        OnSearchSuccess(KeyWord, EventArgs.Empty);
                    }
                    else
                    {
                        OnSearchFailure(KeyWord, EventArgs.Empty);
                    }
                    InsertLog(KeyWord, matchSuccess);
                    return;
                }
                else
                {
                    SearchItem m = new SearchItem();
                    m.DayId = SerchDate.ToString("yyyy-MM-dd");
                    m.KeyWord = KeyWord;
                    m.SerchDateTime = DateTime.Now;
                    m.ItemTitle = "";
                    m.ItemUrl = "http://www.ebay.co.uk/itm/" + KeyWord;
                    m.ItemNumber = KeyWord;
                    m.Rank = 0;
                    m.SellerShopUrl = "";
                    m.SellerId = "";
                    m.Flag = 1;


                    bool matchSuccess = false;
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
                    if (matchTitle.Count > 0)
                    {
                        string itemTitle = matchTitle[0].Groups[1].Value;
                        matchSuccess = true;
                        if (itemTitle.Contains("itemprop"))
                        {
                            Match match = Regex.Match(itemTitle, "[>](.*?)[</]");
                            if (match.Success)
                            {
                                itemTitle = HttpUtility.HtmlDecode(match.Groups[1].Value);
                            }
                        }

                        m.Flag = 3;
                        m.ItemTitle = itemTitle;
                    }
                    if (matchPrice.Count > 0)
                    {
                        decimal saleprice = 0m;
                        if (decimal.TryParse(matchPrice[0].Groups[5].Value.Replace(",", ""), out saleprice))
                        {
                            m.SalePrice = saleprice;
                        }
                        else
                        {
                            Log.CreateLog("Error", "KeyWord：" + KeyWord + "\r\nItem：" + KeyWord + "\r\nSalePrice：" + matchPrice[0].Groups[5].Value);
                        }
                    }
                    if (matchSeller.Count > 0)
                    {
                        m.SellerShopUrl = matchSeller[0].Groups[1].Value;
                        m.SellerId = matchSeller[0].Groups[2].Value;
                    }
                    if (matchLocation.Count > 0)
                    {
                        m.Location = matchLocation[0].Groups[1].Value;
                    }
                    if (matchPostAge.Count > 0)
                    {
                        decimal posage = 0m;
                        if (decimal.TryParse(matchPostAge[0].Groups[2].Value, out posage))
                        {
                            m.PostAge = posage;
                        }
                        else
                        {
                            Log.CreateLog("Error", "KeyWord：" + KeyWord + "\r\nItem：" + KeyWord + "\r\nPosAge：" + matchPostAge[0].Groups[2].Value);
                        }
                    }
                    if (matchSoldList.Count > 0)
                    {
                        string soldListUrl = matchSoldList[0].Groups[1].Value;
                        string totalSoldQuantity = matchSoldList[0].Groups[2].Value;
                        int soldQuantity = 0;
                        if (int.TryParse(totalSoldQuantity.Replace(",", ""), out soldQuantity))
                        {
                            m.ItemSoldQuantity = soldQuantity;
                        }
                        else
                        {
                            Log.CreateLog("Error", "KeyWord：" + KeyWord + "\r\nItem：" + KeyWord + "\r\nTotalSoldQuantity：" + totalSoldQuantity);
                        }
                        GetItemSold(KeyWord, m.ItemTitle, 1, HttpUtility.HtmlDecode(soldListUrl), ref m);
                    }
                    if (matchSuccess)
                    {
                        OnSearchSuccess(KeyWord, EventArgs.Empty);

                        int dt_count = dt_color.Rows.Count;
                        //int dt_count = dt_color.Rows.Count > 0 ? dt_color.Rows.Count : 0;
                        if (dt_count > 1 && m.Flag == 3 && m.ItemSoldByDay != 0)
                        {
                            for (int k = 0; k < dt_count; k++)
                            {
                                m.Color = dt_color.Rows[k][0].ToString();
                                m.ColorPrice = Convert.ToDecimal(dt_color.Rows[k][2]);
                                m.ColorSold = Convert.ToInt32(dt_color.Rows[k][1]);

                                DataManager dm = new DataManager();
                                dm.AddMode_color(m, KeyWord, SerchDate.ToString("yyyy-MM-dd"));
                            }
                        }
                        else
                        {
                            if (m.ItemSoldByDay == 0)
                            {
                                m.Color = "";
                            }
                            m.ColorSold = m.ItemSoldByDay;
                            DataManager dm = new DataManager();
                            dm.AddMode(m, KeyWord, SerchDate.ToString("yyyy-MM-dd"));
                        }

                    }
                    else
                    {
                        OnSearchFailure(KeyWord, EventArgs.Empty);
                    }
                    InsertLog(KeyWord, matchSuccess);
                    return;
                }
            }
            OnSearchFailure(KeyWord, EventArgs.Empty);
            SetLog(KeyWord, KeyWord + "：一级信息搜索失败 ...");
            InsertLog(KeyWord, false);
        }

#endif

        void InsertLog(string keyWord, bool Flag)
        {
            try
            {
                T_LogTableAdapter logAdapter = new T_LogTableAdapter();
                logAdapter.Insert(DateTime.Now, keyWord, Flag);
            }
            catch
            {
            }
        }



#if DEBUG
        private Boolean GetItems(HtmlAgilityPack.HtmlDocument doc, String strKeyword, DateTime dteSearchDate)
        {
            SetLog(strKeyword, strKeyword + ": 开始匹配一级信息 ...");
            HtmlNode nodeDivider = doc.DocumentNode.SelectSingleNode("//a[@id=\"mainContent\"]");

            if (null != nodeDivider)
            {
                SetLog(strKeyword, strKeyword + "：一级信息匹配成功 ...");
            }

            HtmlNodeCollection items = (null == nodeDivider) ?
                doc.DocumentNode.SelectNodes("//table[@r][@class][@itemprop][@itemscope][@itemtype]") :
                nodeDivider.SelectNodes("following::table[@r][@class][@itemprop][@itemscope][@itemtype]");

            if (null == items || items.Count == 0)
            {
                Log.CreateLog("Error", "KeyWord：" + strKeyword + "\r\nSearch result：there is no data");
                return false;
            }

            SetLog(strKeyword, strKeyword + "：搜索列表匹配成功 ...");
            SetValue(items.Count - 1);

            foreach(HtmlNode item in items)
            {
                int idx = items.GetNodeIndex(item);            
                HtmlNode node = null;

                SetPercent(idx + 1 + "/" + items.Count);

                KeywordResult cSearchItem = new KeywordResult();
                cSearchItem.DayID = dteSearchDate.ToString("yyyy-MM-dd");
                cSearchItem.Keyword = strKeyword;
                cSearchItem.SearchDateTime = DateTime.Now;

                // Item title
                node = item.SelectSingleNode(".//a[@href][@class=\"vip \"][@title][@itemprop=\"name\"]");
                //node = item.SelectSingleNode("")
                if (null != node)
                {
                    cSearchItem.ItemTitle = HttpUtility.HtmlDecode(node.Attributes["title"].Value);
                    cSearchItem.ItemUrl = node.Attributes["href"].Value;
                }

                // Item number
                node = item.SelectSingleNode(".//div[@class=\"s1\"][text()=\"Item:&nbsp;\"]/span[@class=\"v\"]");
                cSearchItem.ItemID = (null == node) ? null : node.InnerText;

                // Seller ID
                node = item.SelectSingleNode(".//div[@class=\"s1\"][text()=\"Seller user ID:&nbsp;\"]/span[@class=\"v\"]");
                cSearchItem.SellerID = (null == node) ? null : node.InnerText;

                // Price
                Boolean bRet = false;
                node = item.SelectSingleNode(".//div[@class=\"g-b\"][@itemprop=\"price\"]");

                if (null != node)
                {
                    Match matPrice = Regex.Match(node.InnerText.Replace(",", ""), "[0-9]+\\.[0-9]*");
                    if (matPrice.Success)
                    {
                        cSearchItem.SalePrice = Decimal.Parse(matPrice.Value);
                        bRet = true;
                    }
                }
                if (!bRet)
                {
                    Log.CreateLog("Error", "KeyWord：" + strKeyword + "\r\nItem：" + cSearchItem.ItemID + "\r\nSoldPrice：search failed");
                }

                // Postage
                node = item.SelectSingleNode(".//span[@class=\"ship\"]");
                if (null != node)
                {
                    Match matPostage = Regex.Match(node.InnerText.Replace(",", ""), "[0-9]+\\.[0-9]*");
                    cSearchItem.Postage = matPostage.Success ? Decimal.Parse(matPostage.Value) : 0;
                }
                else
                {
                    Log.CreateLog("Error", "KeyWord：" + strKeyword + "\r\nItem：" + cSearchItem.ItemID + "\r\nPostAge：search failed");
                }

                // Location
                node = item.SelectSingleNode(".//div[@class=\"s2 distLoc\"]/span");
                cSearchItem.Location = (null == node) ? null : node.InnerText;
                cSearchItem.Rank = idx + 1;

                // Seller's shop url
                node = item.SelectSingleNode(".//div[@class=\"s1\"][text()=\"Shop:&nbsp;\"]/span[@class=\"v\"]/a[@href]");
                cSearchItem.SellerShopUrl = (null == node) ? null : node.Attributes["href"].Value;
                cSearchItem.Flag = 1;

                if (idx < PubConst.GetSalesQuantity)
                {
                    if (PubConst.Level == 3)
                    {
                        GetItemDetail(strKeyword, cSearchItem.ItemTitle, idx + 1, cSearchItem.ItemUrl, ref cSearchItem);
                    }
                    else if (PubConst.Level == 2)
                    {
                        GetItemSold(strKeyword, cSearchItem.ItemTitle, idx + 1, "http://offer.ebay.co.uk/ws/eBayISAPI.dll?ViewBidsLogin&_trksid=p4340.l2564&rt=nc&item=" + cSearchItem.ItemID, ref cSearchItem);
                    }
                }
                else
                {
                    cSearchItem.Flag = 9;
                }
                IncValue();


                KeywordSearch.Domain.KeywordService.SaveKeywordResult(cSearchItem);
            }

            return true;
        }
#else

        void GetItems(string Source, string KeyWord, DateTime SerchDate, ref bool MatchSuccess)
        {
            SetLog(KeyWord, KeyWord + "：开始匹配搜索列表 ...");
            MatchCollection matchUrl = null;
            MatchCollection matchSoldPrice = null;
            MatchCollection matchLocation = null;
            MatchCollection matchItemNumber = null;
            MatchCollection matchSellerId = null;

            MatchManager.MatchItems(Source, ref matchUrl, ref matchSoldPrice, ref matchLocation, ref matchItemNumber, ref matchSellerId);

            int index = matchUrl.Count;
            if (index >= PubConst.GetRankQuantity)
            {
                index = PubConst.GetRankQuantity;
            }

            if (index > 0
                && matchUrl.Count == matchSoldPrice.Count
                && matchUrl.Count == matchLocation.Count
                && matchUrl.Count == matchItemNumber.Count
                && matchUrl.Count == matchSellerId.Count)
            {
                SetLog(KeyWord, KeyWord + "：搜索列表匹配成功 ...");


                SetValue(index - 1);

                for (int i = 0; i < index; i++)
                {
                    SetPercent(i + 1 + "/" + index);
                    SearchItem m = new SearchItem();
                    m.DayId = SerchDate.ToString("yyyy-MM-dd");
                    m.KeyWord = KeyWord;
                    m.SerchDateTime = DateTime.Now;
                    m.ItemTitle = HttpUtility.HtmlDecode(matchUrl[i].Groups[3].Value);
                    m.ItemUrl = matchUrl[i].Groups[2].Value;
                    m.ItemNumber = matchItemNumber[i].Groups[1].Value;
                    decimal saleprice = 0m;
                    if (decimal.TryParse(matchSoldPrice[i].Groups[3].Value.Replace(",", ""), out saleprice))
                    {
                        m.SalePrice = saleprice;
                    }
                    else
                    {

                        Log.CreateLog("Error", "KeyWord：" + KeyWord + "\r\nItem：" + m.ItemNumber + "\r\nSoldPrice：" + matchSoldPrice[i].Groups[3].Value);
                    }
                    decimal posage = 0m;
                    if (decimal.TryParse(matchSoldPrice[i].Groups[5].Value == "" ? "0" : matchSoldPrice[i].Groups[5].Value.Replace(",", ""), out posage))
                    {
                        m.PostAge = posage;
                    }
                    else
                    {

                        Log.CreateLog("Error", "KeyWord：" + KeyWord + "\r\nItem：" + m.ItemNumber + "\r\nPostAge：" + matchSoldPrice[i].Groups[4].Value == "" ? "0" : matchSoldPrice[i].Groups[4].Value);
                    }
                    m.SellerId = matchSellerId[i].Groups[1].Value;
                    m.Location = matchLocation[i].Groups[1].Value;
                    m.Rank = i + 1;
                    m.SellerShopUrl = "";
                    m.Flag = 1;
                    if (i < PubConst.GetSalesQuantity)
                    {
                        if (PubConst.Level == 3)
                        {
                            GetItemDetail(KeyWord, m.ItemTitle, i + 1, m.ItemUrl, ref m);
                        }
                        else if (PubConst.Level == 2)
                        {
                            GetItemSold(KeyWord, m.ItemTitle, i + 1, "http://offer.ebay.co.uk/ws/eBayISAPI.dll?ViewBidsLogin&_trksid=p4340.l2564&rt=nc&item=" + m.ItemNumber, ref m);
                        }
                    }
                    else
                    {
                        m.Flag = 9;
                    }
                    IncValue();

                    int dt_count = dt_color.Rows.Count;
                    //int dt_count = dt_color.Rows.Count > 0 ? dt_color.Rows.Count : 0;
                    if (dt_count > 1 && m.Flag == 3 && m.ItemSoldByDay != 0)
                    {
                        for (int k = 0; k < dt_count; k++)
                        {
                            m.Color = dt_color.Rows[k][0].ToString();
                            m.ColorPrice = Convert.ToDecimal(dt_color.Rows[k][2]);
                            m.ColorSold = Convert.ToInt32(dt_color.Rows[k][1]);

                            DataManager dm = new DataManager();
                            dm.AddMode_color(m, KeyWord, SerchDate.ToString("yyyy-MM-dd"));
                        }
                    }
                    else
                    {
                        if (m.ItemSoldByDay == 0)
                        {
                            m.Color = "";
                        }
                        m.ColorSold = m.ItemSoldByDay;
                        DataManager dm = new DataManager();
                        dm.AddMode(m, KeyWord, SerchDate.ToString("yyyy-MM-dd"));
                    }

                }
                MatchSuccess = true;
            }
            else
            {
                MatchSuccess = false;
                SetLog(KeyWord, KeyWord + "：搜索列表匹配失败 ...");
            }
        }
#endif

        void GetItemDetail(string keyWord, string ItemTitle, int index, string ItemDetailUrl, ref KeywordResult m)
        {

            SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索明细资料 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {
                string itemDetailSource = HttpHelper.GetString(ItemDetailUrl, "", proxy, Encoding.UTF8);
                if (string.IsNullOrEmpty(itemDetailSource))
                {
                    SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索明细资料失败,2秒后重试,重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    searchThread.Join(2000);
                    continue;
                }

                SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索明细资料成功 ...");

                SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 开始匹配明细资料 ...");
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
                    string totalSoldQuantity = matchSoldList[0].Groups[2].Value;
                    int itemSoldQuantity = 0;
                    if (int.TryParse(totalSoldQuantity.Replace(",", ""), out itemSoldQuantity))
                    {
                        m.ItemSoldQuantity = itemSoldQuantity;
                    }
                    else
                    {

                        Log.CreateLog("Error", "KeyWord：" + keyWord + "\r\nItem：" + m.ItemID + "\r\nItemSoldQuantity：" + totalSoldQuantity);
                    }
                    GetItemSold(keyWord, ItemTitle, index, HttpUtility.HtmlDecode(soldListUrl), ref m);
                }
                else
                {
                    m.ItemSoldQuantity = 0;
                    SetLog("ItemDetail", "Item：《" + ItemTitle + "》 没有找到销售地址 ...");
                }
                return;
            }
            SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索明细资料失败 ...");
        }



        void GetItemSold(string keyWord, string ItemTitle, int index, string SoldListUrl, ref KeywordResult m)
        {
            SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索销售列表 ...");
            int tryCount = 1;
            while (tryCount < 4)
            {
                string soldListSource = HttpHelper.GetString(SoldListUrl, "", proxy, Encoding.UTF8);
                if (string.IsNullOrEmpty(soldListSource))
                {
                    SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索销售失败,2秒后重试,重试第《" + tryCount + "》次 ...");
                    tryCount++;
                    searchThread.Join(2000);
                    continue;
                }
                SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索销售成功 ...");

                SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 匹配销售信息 ...");
                MatchCollection matchSoldPrice = null;
                MatchCollection matchQuantity = null;
                MatchCollection matchSoldDate = null;
                MatchCollection matchColor = null;
                MatchCollection matchColorPrice = null;
                MatchCollection matchStandbyPrice = null;

                MatchManager.MatchItemSold(soldListSource, ref matchSoldPrice, ref matchQuantity, ref matchSoldDate, ref matchColor, ref matchColorPrice, ref matchStandbyPrice);

                if (matchSoldPrice.Count > 0 && matchSoldDate.Count == matchQuantity.Count && matchSoldPrice.Count <= matchQuantity.Count)
                {
                    SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 销售信息匹配成功 ...");
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
                        //string colorprice = matchColorPrice.Count > 0 ? matchColorPrice[i].Groups[1].Value : m.SalePrice.ToString();//颜色的价格
                        string standbyprice = matchStandbyPrice.Count == 1 ? matchStandbyPrice[0].Groups[1].Value : m.SalePrice.ToString();
                        string colorprice = matchColorPrice.Count > 0 ? matchColorPrice[i].Groups[1].Value : standbyprice;//颜色的价格
                        //m.Color = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";   
                        string Mcolor = matchColor.Count > 0 ? matchColor[i].Groups[1].Value : "";
                        Mcolor = Mcolor.Replace(@"</b><br>", ";");
                        Mcolor = Mcolor.Replace(@"<b>", "");
                        Mcolor = Mcolor.Replace(@"&amp;", "&");
                        m.Color = Mcolor;
                        //m.Color = matchColor.Count > 0 ? matchColor[i].Groups[2].Value : "";
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
            SetLog(keyWord, "Item" + index + "：《" + ItemTitle + "》 搜索销售失败 ...");
        }
    }
}
