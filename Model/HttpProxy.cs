//-----------------------------------------------------------------
//
// @(#)$Id: HttpProxy.cs,v 1.0 2014/08/29 18:07:53 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 18:07:53 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;

namespace KeywordSearch.Model
{
    public class HttpProxy
    {
        //
        // Summary:
        //   Constructor
        public HttpProxy() {

        }

        //
        // Summary:
        //   Constructor
        public HttpProxy(String ip, int port) {
            this.IP = ip;
            this.Port = port;
        }

        /// <summary>
        /// Ip
        /// </summary>
        public virtual String IP { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
    }
}