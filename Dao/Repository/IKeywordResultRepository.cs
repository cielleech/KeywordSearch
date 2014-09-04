//-----------------------------------------------------------------
//
// @(#)$Id: IKeywordResultRepository.cs,v 1.0 2014/08/25 16:26:41 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/25 16:26:41 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using KeywordSearch.Infrastructure.Framework.Repository;
using KeywordSearch.Model;

namespace KeywordSearch.Dao.Repository
{
    public interface IKeywordResultRepository : IRepository<KeywordResult>
    {
        IList<KeywordResult> GetKeywordResults(String dayID, String ItemID, String keyword);
    }
}
