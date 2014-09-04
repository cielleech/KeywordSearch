//-----------------------------------------------------------------
//
// @(#)$Id: KeywordResult.cs,v 1.0 2014/08/25 16:13:10 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/08/25 16:13:10 $
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
    /// <summary>
    /// Keyword result model
    /// </summary>
    public class KeywordResult : EntityBase
    {
        /// <summary>
        /// Keyword
        /// </summary>
        public virtual String Keyword { get; set; }

        /// <summary>
        /// Rank
        /// </summary>
        public virtual int Rank { get; set; }

        /// <summary>
        /// Seller id
        /// </summary>
        public virtual String SellerID { get; set; }

        /// <summary>
        /// Day id
        /// </summary>
        public virtual String DayID { get; set; }
        
        /// <summary>
        /// Item title
        /// </summary>
        public virtual String ItemTitle { get; set; }

        /// <summary>
        /// Item number
        /// </summary>
        public virtual String ItemID { get; set; }

        /// <summary>
        /// Item url
        /// </summary>
        public virtual String ItemUrl { get; set; }
        
        /// <summary>
        /// Seller url
        /// </summary>
        public virtual String SellerShopUrl { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public virtual String Location { get; set; }
        
        /// <summary>
        /// Sale price
        /// </summary>
        public virtual decimal SalePrice { get; set; }
            
        /// <summary>
        /// Itemd sold quantity
        /// </summary>
        public virtual int ItemSoldQuantity { get; set; }
        
        /// <summary>
        /// Postage
        /// </summary>
        public virtual decimal Postage { get; set; }
        
        /// <summary>
        /// Search datetime
        /// </summary>
        public virtual DateTime SearchDateTime { get; set; }
        
        /// <summary>
        /// Item sold quantity daily
        /// </summary>
        public virtual int ItemSoldByDay { get; set; }
            
        /// <summary>
        /// Flag
        /// </summary>
        public virtual int Flag { get; set; }

        /// <summary>
        /// Retry count
        /// </summary>
        public virtual int RetryCount { get; set; }
            
        /// <summary>
        /// Color
        /// </summary>
        public virtual String Color { get; set; }

        /// <summary>
        /// Price for color
        /// </summary>
        public virtual decimal ColorPrice { get; set; }

        /// <summary>
        /// Quantity for color sold
        /// </summary>
        public virtual int ColorSold { get; set; }
    }
}
