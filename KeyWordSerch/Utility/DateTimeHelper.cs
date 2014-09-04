using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace KeyWordSerch
{
    public class DateTimeHelper
    {
        public static string ToGMTString(DateTime dt)
        {
            return dt.ToUniversalTime().ToString("r");
        }
        public static string ToGMTFormat(DateTime dt)
        {
            return dt.ToString("r") + dt.ToString("zzz").Replace(":", "");
        }
        public static DateTime GetDate(string gmt)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                string pattern = "";
                if (gmt.IndexOf("+0") != -1)
                {
                    gmt = gmt.Replace("GMT", "");
                    pattern = "ddd, dd MMM yyyy HH':'mm':'ss zzz";
                    return DateTime.ParseExact(gmt, pattern, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                if (gmt.ToUpper().IndexOf("GMT") != -1)
                {
                    pattern = "dd-MMM-yy HH':'mm':'ss 'GMT'";
                    return DateTime.ParseExact(gmt, pattern, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                if (gmt.ToUpper().IndexOf("BST") != -1)
                {
                    pattern = "dd-MMM-yy HH':'mm':'ss 'BST'";
                    return DateTime.ParseExact(gmt, pattern, new CultureInfo("en-GB"));
                }
            }
            catch
            {
            }
            return dt;

        }
    }
}
