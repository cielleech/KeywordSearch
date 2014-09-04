//-----------------------------------------------------------------
//
// @(#)$Id: Class1.cs,v 1.0 2014/08/25 16:35:06 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/25 16:35:06 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using KeywordSearch.Dao.Repository;
using KeywordSearch.Model;

namespace KeywordSearch.Domain
{
    public class KeywordService
    {
        public static Boolean SaveKeywordResult(KeywordResult result) {
            IKeywordResultRepository repository = new Dao.Repository.Hbm.Impl.KeywordResultRepositoryImpl();

            IList<KeywordResult> results = repository.GetKeywordResults(result.DayID, result.ItemID, result.Keyword);

            if (results.Count == 0) {
                repository.Save(result);
            }
            return true;
        }
    }
}
