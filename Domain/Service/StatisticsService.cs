using System;
using System.Collections.Generic;
using KeywordSearch.Model;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using KeywordSearch.Utility;

namespace KeywordSearch.Domain.Service
{
    public class StatisticsService
    {
        private Dictionary<String, ProxyFailure> failures;

        private static StatisticsService instance;

        public static StatisticsService Instance {
            get {
                return instance == null ? instance = new StatisticsService() : instance;
            }
        }

        
        //
        // Summary:
        //   Constructor
        public StatisticsService() {
            failures = new Dictionary<String, ProxyFailure>();
        }

        //
        // Summary:
        //   Add the failure count of a ip
        //
        // Parameters:
        //   ip:
        //     the failed ip
        public void Add(String ip) {
            if (failures.ContainsKey(ip))
                failures[ip].Count += 1;
            else
                failures.Add(ip, new ProxyFailure() { IP = ip, Count = 1 });
        }

        //
        // Summary:
        //   Send the the proxy statistics report
        //
        // Returns:
        //   If success, return true; else false.
        public Boolean SendReport() {
            String host = PubConst.EmailHost;
            int port = PubConst.EmailPort;
            String email = EncryptHelper.Decode(PubConst.EmailAddress);
            String password = EncryptHelper.Decode(PubConst.EmailPassword);
            String recipients = PubConst.EmailRecipient;
            String subject = DateTime.Now.ToString("yyyy-MM-dd") + "代理统计报告";
            String body = CreateReport();

            SmtpClient client = new SmtpClient(host, port);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, password);

            try {
                client.Send(email, recipients, subject, body);
            }
            catch (System.Exception ex) {
                System.Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        //
        // Summary:
        //   Create the proxy statistics report
        //
        // Returns:
        //   return the report.
        private String CreateReport() {
            StringBuilder builder = new StringBuilder();

            builder.Append(String.Format("{0}关键字抓取代理统计报告:\n", DateTime.Now.ToString("yyyy-MM-dd")));

            foreach (ProxyFailure failure in failures.Values) {
                builder.Append(String.Format("IP: {0}, 失败次数: {1}\n", failure.IP, failure.Count));
            }

            return builder.ToString();
        }
    }
}