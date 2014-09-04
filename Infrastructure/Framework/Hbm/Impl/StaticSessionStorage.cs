//-----------------------------------------------------------------
//
// @(#)$Id: StaticSessionStorage.cs,v 1.0 2014/07/11 15:00:50 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 15:00:50 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Web;
using NHibernate;
using NHibernate.Impl;

namespace KeywordSearch.Infrastructure.Framework.Hbm.Impl
{
    public class StaticSessionStorage : ISessionStorage
    {
        [ThreadStatic]
        private static ISession session = null;

        public ISession Get() {
            return session;
        }

        public void Set(ISession aSession) {
            session = aSession;
        }
    }
}