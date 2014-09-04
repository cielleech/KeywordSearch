//-----------------------------------------------------------------
//
// @(#)$Id: HttpSessionStorage.cs,v 1.0 2014/07/11 11:12:12 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 11:12:12 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Web;
using NHibernate;

namespace KeywordSearch.Infrastructure.Framework.Hbm.Impl
{
    public class HttpSessionStorage : ISessionStorage
    {
        public ISession Get()
        {
            return HttpContext.Current.Items["OIGHibernate"] as ISession;
        }

        public void Set(ISession session)
        {
            if (session == null)
                HttpContext.Current.Items.Remove("OIGHibernate");
            else
                HttpContext.Current.Items.Add("OIGHibernate", session);
        }
    }
}