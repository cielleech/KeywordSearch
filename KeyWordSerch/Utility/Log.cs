using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KeyWordSerch
{
    public class Log
    {
        public static void CreateLog(string keyWord, string Msg)
        {
            string logpath = Application.StartupPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
            string fullpath = logpath + "\\" + replace(keyWord) + ".txt";
            if (!Directory.Exists(logpath))
            {
                Directory.CreateDirectory(logpath);
            }
            if (!File.Exists(fullpath))
            {
                File.Create(fullpath).Close();
            }
            using (StreamWriter sw = new StreamWriter(fullpath, true, Encoding.UTF8))
            {
                sw.WriteLine("¡¾" + DateTime.Now.ToString() + "¡¿ " + Msg + "\r\n");
                sw.Close();
            }
        }

        static string replace(string k)
        {
            k = k.Replace("\\", "&1");
            k = k.Replace("/", "&2");
            k = k.Replace("*", "&3");
            k = k.Replace("?", "&4");
            k = k.Replace(":", "&5");
            k = k.Replace("\"", "&6");
            k = k.Replace("|", "&7");
            k = k.Replace("<", "&8");
            k = k.Replace(">", "&9");
            return k;
        }
    }
}
