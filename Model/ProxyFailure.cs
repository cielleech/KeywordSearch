//-----------------------------------------------------------------
//
// @(#)$Id: EmailEntity.cs,v 1.0 2014/08/29 11:01:40 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/29 11:01:40 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using KeywordSearch.Infrastructure.Domain;

namespace KeywordSearch.Model
{
    public class ProxyFailure : EntityBase
    {
        public virtual String IP { get; set; }

        public virtual int Count { get; set; }
    }
}
