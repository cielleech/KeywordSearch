using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace KeyWordSerch
{
    public class PubConst
    {
        public static readonly int MaxThread = Convert.ToInt32(ConfigurationManager.AppSettings["MaxThread"]);
        public static readonly int RankQuantity = Convert.ToInt32(ConfigurationManager.AppSettings["RankQuantity"]);
        public static readonly int GetRankQuantity = Convert.ToInt32(ConfigurationManager.AppSettings["GetRankQuantity"]);
        public static readonly int GetSalesQuantity = Convert.ToInt32(ConfigurationManager.AppSettings["GetSalesQuantity"]);
        public static readonly string SerchTime = ConfigurationManager.AppSettings["AutoSerchTime"];
        public static readonly int BeginTimeMode = Convert.ToInt32(ConfigurationManager.AppSettings["BeginTimeMode"]);
        public static readonly string QuantityBeginTime = ConfigurationManager.AppSettings["QuantityBeginTime"];
        public static readonly string QuantityEndTime = ConfigurationManager.AppSettings["QuantityEndTime"];
        public static readonly string Timedifference = ConfigurationManager.AppSettings["Timedifference"];
        /// <summary>
        /// 0为自动 1为手动
        /// </summary>
        public static readonly int SerchMode = Convert.ToInt32(ConfigurationManager.AppSettings["SerchMode"]);
        public static readonly int Level = Convert.ToInt32(ConfigurationManager.AppSettings["Level"]);
        public static readonly int MinValue = Convert.ToInt32(Convert.ToDecimal(ConfigurationManager.AppSettings["MinValue"]) * 1000);
        public static readonly int MaxValue = Convert.ToInt32(Convert.ToDecimal(ConfigurationManager.AppSettings["MaxValue"]) * 1000);

        public static DateTime SerchBeginDate = DateTime.Now;
        public static DateTime SerchEndDate = DateTime.Now;
        // Database connection string
        public static readonly String MMSConnectionString = ConfigurationManager.ConnectionStrings["MMSConnectionString"].ConnectionString;
    }
}
