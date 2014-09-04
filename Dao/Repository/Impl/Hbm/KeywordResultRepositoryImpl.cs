//-----------------------------------------------------------------
//
// @(#)$Id: KeywordResultRepositoryImpl.cs,v 1.0 2014/08/25 16:27:37 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/25 16:27:37 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using KeywordSearch.Infrastructure.Framework.Repository.Impl;
using KeywordSearch.Model;
using NHibernate.Criterion;

namespace KeywordSearch.Dao.Repository.Hbm.Impl
{
    public class KeywordResultRepositoryImpl : RepositoryHbmImpl<KeywordResult>, IKeywordResultRepository
    {
        public IList<KeywordResult> GetKeywordResults(String dayID, String itemID, String keyword) {
            return Session.CreateCriteria(typeof(KeywordResult))
                .Add(Expression.Eq("DayID", dayID))
                .Add(Expression.Eq("ItemID", itemID))
                .Add(Expression.Eq("Keyword", keyword))
                .List<KeywordResult>();
        }
    }
}
