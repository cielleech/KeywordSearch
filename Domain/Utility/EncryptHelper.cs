//-----------------------------------------------------------------
//
// @(#)$Id: CodeHelper.cs,v 1.0 2014/08/29 9:30:19 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 9:30:19 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;

namespace KeywordSearch.Utility
{
    /// <summary>
    /// Encode and decode string
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data) {
            String key = PubConst.DESKey;
            String iv = PubConst.DESIv;

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();

            string strRet = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            return strRet;
        }

        /// <summary>  
        /// 解密  
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        public static string Decode(string data) {
            String key = PubConst.DESKey;
            String iv = PubConst.DESIv;
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;

            try {
                data.Replace("_%_", "/");
                data.Replace("-%-", "#");
                byEnc = Convert.FromBase64String(data);

            }
            catch {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }  
    }
}