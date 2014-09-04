using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace KeyWordSerch
{
    public static class KeyWords
    {
        static object o = new object();
        static Queue keyWordQueue = new Queue();

        public static void AddKeyWords(string KeyWord)
        {
            lock (o)
            {
                keyWordQueue.Enqueue(KeyWord);
            }
        }

        public static int GetCount()
        {
            lock (o)
            {
                return keyWordQueue.Count;
            }
        }
        public static string GetKeyWord()
        {
            lock (o)
            {
                if (keyWordQueue.Count > 0)
                {
                    object key = keyWordQueue.Dequeue();
                    return key.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Clear()
        {
            keyWordQueue.Clear();
        }

    }
}
