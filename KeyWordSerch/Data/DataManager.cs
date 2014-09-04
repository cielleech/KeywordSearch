using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;
using KeywordSearch.Model;

namespace KeyWordSerch.Data
{
    public class DataManager
    {
        private static object o = new object();

        public void AddList(List<KeywordResult> list, string keyWord, string DayId)
        {
            lock (o)
            {
                try
                {
                    T_ItemSerchResultTableAdapter itemAdapter = new T_ItemSerchResultTableAdapter();
                    itemAdapter.Connection.Open();
                    foreach (KeywordResult mode in list)
                    {
                        int count = itemAdapter.AlreadySerch(mode.DayID, mode.ItemID, mode.Keyword, mode.Color).Value;
                        if (count > 0)
                            continue;
                        itemAdapter.Insert(mode.DayID, mode.ItemTitle, mode.Keyword, mode.ItemID, mode.ItemUrl, mode.SellerID,
                            mode.SellerShopUrl, mode.Location, mode.SalePrice, mode.ItemSoldQuantity, mode.Postage, mode.SearchDateTime, mode.ItemSoldByDay, mode.Flag, mode.RetryCount, mode.Rank, mode.Color, mode.ColorSold);
                    }
                    itemAdapter.Connection.Close();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void AddMode(KeywordResult mode, string keyWord, string DayId)
        {
            lock (o)
            {
                try
                {
                    T_ItemSerchResultTableAdapter itemAdapter = new T_ItemSerchResultTableAdapter();
                    itemAdapter.Connection.Open();
                    int count = itemAdapter.AlreadySerch(mode.DayID, mode.ItemID, mode.Keyword, mode.Color).Value;
                    if (count == 0)
                    {

                        itemAdapter.Insert(mode.DayID, mode.ItemTitle, mode.Keyword, mode.ItemID, mode.ItemUrl, mode.SellerID,
                            mode.SellerShopUrl, mode.Location, mode.SalePrice, mode.ItemSoldQuantity, mode.Postage, mode.SearchDateTime, mode.ItemSoldByDay, mode.Flag, mode.RetryCount, mode.Rank, mode.Color, mode.ColorSold);

                    }
                    itemAdapter.Connection.Close();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void AddMode_color(KeywordResult mode, string keyWord, string DayId)
        {
            lock (o)
            {
                try
                {
                    T_ItemSerchResultTableAdapter itemAdapter = new T_ItemSerchResultTableAdapter();
                    itemAdapter.Connection.Open();
                    int count = itemAdapter.AlreadySerch(mode.DayID, mode.ItemID, mode.Keyword, mode.Color).Value;
                    if (count == 0)
                    {
                        itemAdapter.Insert(mode.DayID, mode.ItemTitle, mode.Keyword, mode.ItemID, mode.ItemUrl, mode.SellerID,
                            mode.SellerShopUrl, mode.Location, mode.ColorPrice, mode.ItemSoldQuantity, mode.Postage, mode.SearchDateTime, mode.ItemSoldByDay, mode.Flag, mode.RetryCount, mode.Rank, mode.Color, mode.ColorSold);
                    }
                    itemAdapter.Connection.Close();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void UpdateMode(KeywordResult mode)
        {
            lock (o)
            {
                try
                {
                    T_ItemSerchResultTableAdapter itemAdapter = new T_ItemSerchResultTableAdapter();
                    itemAdapter.Update(mode.DayID, mode.ItemTitle, mode.Keyword, mode.ItemID, mode.ItemUrl, mode.SellerID,
                        mode.SellerShopUrl, mode.Location, mode.SalePrice, mode.ItemSoldQuantity, mode.Postage, mode.SearchDateTime, mode.ItemSoldByDay, mode.Flag, mode.RetryCount, mode.Rank, mode.Color, mode.ColorSold, Convert.ToInt32(mode.Key));
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<KeywordResult> GetList()
        {
            T_ItemSerchResultTableAdapter itemAdapter = new T_ItemSerchResultTableAdapter();
            SerchItemsDataSet.T_ItemSerchResultDataTable table = itemAdapter.GetDataByFlag(DateTime.Now.ToString("yyyyMMdd"),
                Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ReTry"]));
            List<KeywordResult> list = new List<KeywordResult>();
            foreach (SerchItemsDataSet.T_ItemSerchResultRow r in table.Rows)
            {
                KeywordResult mode = new KeywordResult();
                mode.DayID = r.DayId;
                mode.Flag = r.Flag;
                mode.Key = r.Id;
                mode.ItemID = r.ItemNumber;
                mode.ItemSoldByDay = r.ItemSoldByDay;
                mode.ItemSoldQuantity = r.ItemSoldQuantity;
                mode.ItemTitle = r.ItemTitle;
                mode.ItemUrl = r.ItemUrl;
                mode.Keyword = r.KeyWord;
                mode.Location = r.Location;
                mode.Postage = r.Postage;
                mode.SalePrice = r.SalePrice;
                mode.SellerID = r.SellerId;
                mode.SellerShopUrl = r.SellerShopUrl;
                mode.SearchDateTime = r.SerchDateTime;
                mode.Rank = r.Rank;
                list.Add(mode);
            }
            return list;

        }

        public DataTable GetRank(string DateTime)
        {
            string cmdText = @"select count(r2.itemnumber) + 1 as rank, 
            r1.itemnumber,r1.itemtitle,r1.quantity,r1.DayId as SoldDate from
            ((
            Select DayId,ItemNumber,ItemTitle,Color,max(ItemSoldByDay) as quantity
            From ItemSerchResult where DayId =@rankdate And ItemSoldByDay >= @Quantity
            Group By  DayId, ItemTitle,ItemNumber,Color
            ) r1 
            left outer join
            (
            Select DayId,ItemNumber,ItemTitle,Color,max(ItemSoldByDay) as quantity
            From ItemSerchResult where DayId = @rankdate And ItemSoldByDay >= @Quantity
            Group By  DayId, ItemTitle,ItemNumber,Color
            ) r2 on r2.quantity > r1.quantity)
            group by r1.DayId,r1.itemnumber,r1.itemtitle,r1.quantity,r1.Color
            order by r1.quantity desc";

            OleDbParameter[] ps = {
                new OleDbParameter("@rankdate", OleDbType.VarChar) ,
                new OleDbParameter("@Quantity", OleDbType.Integer) 
            };
            ps[0].Value = DateTime;
            ps[1].Value = PubConst.RankQuantity;
            try
            {
                return AccessHelper.ExecuteDataTable(cmdText, ps);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFailureKeyWord(string d)
        {
            string cmdText = @"Select Distinct  KeyWord
                     FROM      Log 
                     WHERE  format(completedate,'yyyyMMdd') = @d and flag = False
                    And KeyWord Not In
                    (Select Distinct   KeyWord
                     FROM      Log 
                     WHERE  format(completedate,'yyyyMMdd') = @d and flag = True)";

            OleDbParameter p = new OleDbParameter("@d", OleDbType.VarChar);
            p.Value = d;
            try
            {
                return AccessHelper.ExecuteDataTable(cmdText, p);
            }
            catch
            {
                throw;
            }
        }
    }
}
