//-----------------------------------------------------------------
//
// @(#)$Id: RepositoryException.cs,v 1.0 2014/07/11 11:11:55 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 11:11:55 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;

namespace KeywordSearch.Infrastructure.Framework.Repository
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, Exception ex)
            : base(message, ex) { }
    }
}
