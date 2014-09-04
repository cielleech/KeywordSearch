using System;
using System.Collections.Generic;
using System.Text;

namespace KeyWordSerch
{
    public class SpanCount
    {
        int hour;

        public int Hour
        {
            get { return hour; }
        }
        int min;

        public int Min
        {
            get { return min; }
        }
        int send;

        public int Send
        {
            get { return send; }
        }

        public void Add(int s)
        {
            send++;
            if (send >= 60)
            {
                min++;
                send = 0;
                if (min >= 60)
                {
                    hour++;
                    min = 0;
                }
            }
        }

        public void Reset()
        {
            hour = 0;
            min = 0;
            send = 0;
        }
        public override string ToString()
        {
            return string.Format("{0:0#}:{1:0#}:{2:0#}", hour, min, send);
        }
    }
}
