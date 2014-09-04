//-----------------------------------------------------------------
//
// @(#)$Id: PubConst.cs,v 1.0 2014/08/29 9:53:21 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 9:53:21 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;

namespace KeywordSearch.Utility
{
    public class PubConst
    {
        // 密钥
        public static String DESKey = System.Configuration.ConfigurationManager.AppSettings["DES.Key"];

        // 向量
        public static String DESIv = System.Configuration.ConfigurationManager.AppSettings["DES.Iv"];

        // Email
        public static String EmailAddress = System.Configuration.ConfigurationManager.AppSettings["Email.Address"];

        // Password
        public static String EmailPassword = System.Configuration.ConfigurationManager.AppSettings["Email.Password"];

        // Recipient
        public static String EmailRecipient = System.Configuration.ConfigurationManager.AppSettings["Email.Recipient"];

        // Host
        public static String EmailHost = System.Configuration.ConfigurationManager.AppSettings["Email.Host"];

        // Port
        public static int EmailPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Email.Port"]);
    }
}