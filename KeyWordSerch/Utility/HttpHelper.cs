using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;

namespace KeyWordSerch
{
    public class HttpHelper
    {
        public static string GetString(string url, string referer, WebProxy proxy, Encoding _Encoding)
        {
            int tryMax = 5;

            while (tryMax > 0)
            {
                try
                {
                    Thread.Sleep(new Random().Next(PubConst.MinValue, PubConst.MaxValue));

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpWebRequest.Headers.Add("Cookie: cid=GEMn4OKPQZUgyGrd%231448401178; npii=bcguid/ffa9799613b0a54be7256555fdf6ed7055e7c23c^tguid/8e21f5b31460a5e026702350ffffe1d555e7c23c^; JSESSIONID=0D1031C758C497FDB5ECC930051E4AA2; ns1=BAQAAAUgZ6WGhAAaAAKUADVXn2wgxMTA1NzM0MTkyLzA7ANgAZ1Xn2whjOTl8NjAxXjE0MDUwNzMzMzQ3ODNeWTJ4aGRXUXVjUzVzWldVPV4wXjN8Mnw1fDR8MTF8N3wxfDQyfDQzfDEwXjFeNF40XjNeMTJeMTJeMl4xXjFeMF4xXjBeMV42NDQyNDU5MDc12+2nH/zayVBWo/ZOdpw0a73Efvo*; s=CgAD4ACBUB/kIMzk1MmVjNGQxNDgwYTZhOTI3ZmU1NGQ1ZmZmYWJjYWYA7gCRVAf5CDMGaHR0cDovL3d3dy5lYmF5LmNvLnVrL3NjaC9pLmh0bWw/X2Zyb209UjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJTdDUjQwJl9zYWNhdD0wJl9ua3c9TUFTSyZydD1uYyZfZG1kPTImTEhfQklOPTGM7cF+; nonsession=BAQAAAUgZ6WGhAAaAAJ0ACFXn2wgwMDAwMDAwMQCqAAFV59sIMAFkAANV59sIIzhhAAgAHFQuNIgxNDA4OTUxNTIweDMwMTE1NTU3MjcwNngzeDJZADMAC1Xn2whzdzE4MVNRLEdCUgDLAAFUBq6QNgBAAAtV59sIY2xhdWQucS5sZWUAEAALVefbCGNsYXVkLnEubGVlAMoAIF1sqQg4ZTIxZjViMzE0NjBhNWUwMjY3MDIzNTBmZmZmZTFkNQDzACJV59sIJDIkL3pGb1pZZUskdTBXNnlmR2FNRFNVMEhlQndyZU41MQFNABhV59sINTM5OTIwMTEuMy4xLjAuMTMwLjAuMC4xAAQAC1V6U5FjbGF1ZC5xLmxlZQFMABdV59sINTNiZmI3YjYuMy4xLjcuNzEuNi4wLjIAnAA4VefbCG5ZK3NIWjJQckJtZGo2d1ZuWStzRVoyUHJBMmRqNkFGa0llbUM1U0RxQTZkajZ4OW5ZK3NlUT094IXI/hqwOF3z7uxtxsLew5wZ+no*; lucky9=3640166; ds2=sotr/b7pQ5zQMz1Rl^ssts/1409722339607^; dp1=bkms/in57c90e88^u1f/cielleech55e7db08^tzo/-1e057c90ee3^idm/15407cdfc^pcid/144840117855e7db08^u1p/Y2xhdWQucS5sZWU*55e7db08^bl/GB57c90e88^expt/000140506975497654b0437a^pbf/#1800e000e000008180c200000457c90ee3^cq/157c90e93^; ebay=%5Esbf%3D%2341c000000000e0000100020%5Ejs%3D1%5Epsi%3DA%2FmwJjsY*%5E");
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Referer = referer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; .NET4.0C; .NET4.0E)";
                    httpWebRequest.Method = "Get";

                    if (proxy != null)
                    {
                        httpWebRequest.UseDefaultCredentials = true;
                        httpWebRequest.Proxy = proxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (Stream responseStream = httpWebResponse.GetResponseStream())
                    {
                        if (_Encoding == null)
                            _Encoding = Encoding.Default;
                        using (StreamReader streamReader = new StreamReader(responseStream, _Encoding))
                        {
                            string result = streamReader.ReadToEnd();
                            httpWebResponse.Close();
                            return result;
                        }
                    }
                }
                catch
                {
                    tryMax--;
                    if (tryMax > 0)
                    {
                        continue;
                    }
                    break;
                }
            }
            return null;
        }
        public static bool CheckPro(WebProxy proxy)
        {
            if (proxy == null)
                return true;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.ebay.co.uk/");

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Referer = "";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; .NET4.0C; .NET4.0E)";
            httpWebRequest.Method = "Get";

            if (proxy != null)
            {
                httpWebRequest.UseDefaultCredentials = true;
                httpWebRequest.Proxy = proxy;
            }
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        string result = streamReader.ReadToEnd();
                        httpWebResponse.Close();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetString(WebProxy proxy)
        {
            if (proxy == null)
                return false;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.ebay.co.uk/");

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Referer = "";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Headers.Add("Cookie:ds2=alss/0.gu10%2B21%2Bled%2Bbulb%2Blight%2Bwarm4ef41511^sotr/bpMzz0Ezzzzz^ssts/1324532919226^; ebay=%5Ecv%3D15555%5Elvmn%3D0%7C0%7C%5Ejs%3D1%5Elrtjs%3D0.6%5Esbf%3D%23a0000100000%5Ecos%3D1%5Epsi%3DASDFvlEQ*%5Essjs%3D1%5E; cssg=64477baf1340a5a922418ee1ff2fbbb2; s=CgAD4ACBO9BURNjQ0NzdiYWYxMzQwYTVhOTIyNDE4ZWUxZmYyZmJiYjIBSgAXTvQVETRlZjJjMzkxLjMuMS4zLjkxLjUuMC4yAO4ApU70FREzBmh0dHA6Ly93d3cuZWJheS5jby51azo4MC9zY2gvaS5odG1sP0xIX0JJTj0xJkxIX1ByZWZMb2M9MCZfbmt3PWd1MTArMjErbGVkK2J1bGIrbGlnaHQrd2FybSZfTEhfTUlMPTEmX2RsZz0xJl9kbXB0PVVLX0xpZ2h0X0J1bGJzJl9kcz0xJl92Yz0xJl9zYW1pbG93PTImX3NhbWloaT05OTm0yPPT; dp1=bvrvi/3%7C0%7C330649460149%7C180642126872%7C170666742431%7C4efff291^mpc/0%7C34efff291^kms/in52b52a91^pbf/%2364000081804200000450d3f711^tzo/-1e052b52a91^u1p/QEBfX0BAX19AQA**50d3f711^idm/14ef2ea33^; npii=btguid/5e00562b1330a0aa16e402a4fffeea6050d3ce02^cguid/3f2557ed1330a47a43c1bdb1fededdbb50d3ce02^; lucky9=2893180; nonsession=CgAAIABxPGlCRMTMyNDUzMjYyNXgzMzA2NDk0NjAxNDl4M3gyWQDKACBYWMURNWUwMDU2MmIxMzMwYTBhYTE2ZTQwMmE0ZmZmZWVhNjAAywACTvLKmTExAUwAF1DT9xE0ZWYyYzM5MS4zLjEuMy45NC4wLjAuMqDTuVE*; ns1=BAQAAATRjETIDAAaAANgAU1DT9xFjNzl8NjAxXjEzMjQ1MjIzNzczOTheXjBeM3wyfDV8NHwxMXw3fDF8OXw0Ml4xXjJeNF4zXjEyXjEyXjJeMV4xXjBeMV4wXjBeMjE0NzQ5MTUyM5SrvyF6rBHM467SiyCR0jfedAcg; cid=KZKi0FGr");
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; .NET4.0C; .NET4.0E)";
            httpWebRequest.Method = "Get";

            if (proxy != null)
            {
                httpWebRequest.UseDefaultCredentials = true;
                httpWebRequest.Proxy = proxy;
            }
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        string result = streamReader.ReadToEnd();
                        httpWebResponse.Close();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}