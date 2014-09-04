//-----------------------------------------------------------------
//
// @(#)$Id: ISessionStorage.cs,v 1.0 2014/07/11 11:12:24 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 11:12:24 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using NHibernate;

namespace KeywordSearch.Infrastructure.Framework.Hbm
{
    public interface ISessionStorage
    {
        ISession Get();

        void Set(ISession session);
    }
}