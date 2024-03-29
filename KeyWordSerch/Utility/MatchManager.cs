using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using KeyWordSerch.Data;

namespace KeyWordSerch
{
    public class MatchManager
    {

        //string regexPostAge = "<span id=\"fshippingCost\" class=\"vi-is1-sh-srvcCost vi-is1-hideElem vi-is1-showElem\">(.*?)(\\d*.\\d*)</span>";
        //string regexSoldListUrl = "(available / <a href=\"(.*?)\">(.*?) sold</a>)|(<span style=\"float: left; padding:3px 0 0 0;\"> / <a href=\"(.*?)\">(.*?) sold</a></span></div>)";
        //string regexSellerInfo = "Visit Shop:+.+<a href=\"(.*?)\"><img src=\"http://q.ebaystatic.com/aw/pics/s.gif\" height=\"1\" width=\"1\" alt=\"eBay Shops\" class=\"strImgSpr\">(.*?)</a>";
        //string regexItemNumber = "Item number: (.*?)</span>";
        //string regexLocation = "<div class=\"sh-DlvryDtl\">Item location:(.*?)</div>";

        // 2014-09-03 lichunhua
        // 修改Url
        public const String eBaySearchUrl = "http://www.ebay.co.uk/sch/i.html?LH_BIN=1&_nkw={0}&rt=nc&_dmd=1";
        //public const string ebaySerchUrl = "http://www.ebay.co.uk/sch/i.html?LH_BIN=1&LH_PrefLoc=0&_nkw={0}&_LH_MIL=1&_dlg=1&_dmpt=UK_Light_Bulbs&_ds=1&_vc=1&_samilow=2";

        const string regexItems = @"<div class=\""divider g-nav\"">\s*?Optimise(.*?)<table border=\""0\"" cellpadding=\""0\"" cellspacing=\""0\"" width=\""100%\"" class=\""pgbc\"">";
        //const string regexItemUrl = "(<div class=\"ittl\">|<wbr/>)<a href=\"(.*?)\" class=\"vip\" title='(.*?)' itemprop=\"name\">(.*?)</a>\r\n\0*(<img|</div>)";
        const string regexItemUrl = @"(<div class=""ittl"">|<wbr/>)\s*?<a href=""(.*?)"" class=""vip"" title='(.*?)' itemprop=""name"">(<strong>)?\s*?(.*?)(</strong>)?\s*?</a>\s*?(<img|</div>)";
        //const string regexItemSoldPrice = "<(td|div) class=\"(prc g-b|g-b|prc conprices g-b|prc conprices )\">(.*?)(\\d*,\\d*.\\d*|\\d*.\\d*)(</div></td>|</div>|</td>)<td class=\"ship ship(.*?| (fee|fshp|))\">(Free|Not specified|(.*?)(\\d*.\\d*))</td>";
        const string regexItemSoldPrice = @"<td class='(prc|prc conprices)'>\t*?<div class=""g-b"" itemprop=""price"">(.*?)(\d*,\d*.\d*|\d*.\d*)</div>	*?<span class=""ship"">(<span class='tfsp'>Free</span>|Collection only: Free|Postage not specified<br/>|<span class=""fee"">	*?(.*?)(\d*\.\d*).*?</span>)	*?</span></td>";
        const string regexLocation = "Location:.*?<span.*?>(.*?)</span>";
        const string regexItemNumber = "Item:&nbsp;<span class=\"v\">(.*?)</span>";
        const string regexSellerUserId = "Seller user ID:&nbsp;<span class=\"v\">(.*?)</span>";

        //public const string regexSoldListUrl = "(available / <a href=\"(.*?)\">(.*?) sold</a>)|(<span style=\"float: left; padding:3px 0 0 0;\"> / <a href=\"(.*?)\">(.*?) sold</a></span></div>)";
        public const string regexSoldListUrl = " / <a href=\"(.*?)\">(.*?) sold</a></span></div>";
        public const string regexSellerInfo = "Visit Shop:+.+<a href=\"(.*?)\"><img src=\"http://q.ebaystatic.com/aw/pics/s.gif\" height=\"1\" width=\"1\" alt=\"eBay Shops\" class=\"strImgSpr\"></img>(.*?)</a>";

        const string regexSalePrice = "<td align=\"left\" nowrap valign=(\"top\"|\"middle\") class=\"contentValueFont\">(.*?)(\\d*\\.\\d*)</td>";
        const string regexQuantity = "<td align=\"middle\" valign=(\"top\"|\"middle\") class=\"contentValueFont\">(.*?)</td>";
        const string regexSoldTime = "<td align=\"left\" valign=(\"top\"|\"middle\") class=\"contentValueFont\">(.*?)</td>";
        //const string regexColor = "Colour: <b>([^<]*)</b><br></td>";
        //const string regexColor = "class=\"variationContentValueFont\">([^<]*)<b>([^<]*)</b><br></td>";
        const string regexColor = "class=\"variationContentValueFont\">(.*?)</b><br></td>";
        const string regexColorPrice = "class=\"contentValueFont\">£([^<]*)</td>";
        const string regexStandbyPrice = "approximately £([0-9]*[.][0-9]*)";

        public static void MatchItemSold(string soldListSource, ref MatchCollection matchSoldPrice, ref MatchCollection matchQuantity, ref MatchCollection matchSoldDate, ref MatchCollection matchColor, ref MatchCollection matchColorPrice, ref MatchCollection matchStandbuPrice)
        {
            matchSoldPrice = Regex.Matches(soldListSource, regexSalePrice);
            matchQuantity = Regex.Matches(soldListSource, regexQuantity);
            matchSoldDate = Regex.Matches(soldListSource, regexSoldTime);
            matchColor = Regex.Matches(soldListSource, regexColor);
            matchColorPrice = Regex.Matches(soldListSource, regexColorPrice);
            matchStandbuPrice = Regex.Matches(soldListSource, regexStandbyPrice);

        }

        public static void MatchItemDetail(string itemDetailSource, ref MatchCollection matchSoldList, ref MatchCollection matchSeller)
        {
            matchSoldList = Regex.Matches(itemDetailSource, regexSoldListUrl);
            matchSeller = Regex.Matches(itemDetailSource, regexSellerInfo);
        }

        public static void MatchItems(string Source, ref MatchCollection matchUrl, ref MatchCollection matchSoldPrice, ref MatchCollection matchLocation,
           ref MatchCollection matchItemNumber, ref MatchCollection matchSellerId)
        {

            matchUrl = Regex.Matches(Source, regexItemUrl);
            matchSoldPrice = Regex.Matches(Source, regexItemSoldPrice);
            matchLocation = Regex.Matches(Source, regexLocation);
            matchItemNumber = Regex.Matches(Source, regexItemNumber);
            matchSellerId = Regex.Matches(Source, regexSellerUserId);
        }
        public static void MatchItems(string Source, ref MatchCollection matchUrl, ref MatchCollection matchSoldPrice)
        {
            matchUrl = Regex.Matches(Source, regexItemUrl);
            matchSoldPrice = Regex.Matches(Source, regexItemSoldPrice);
        }

        public static void MatchAvailableItems(string serchResult, ref MatchCollection matchItems)
        {
            matchItems = Regex.Matches(serchResult, regexItems);
        }
    }
}
