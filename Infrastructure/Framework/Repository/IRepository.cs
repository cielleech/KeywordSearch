//-----------------------------------------------------------------
//
// @(#)$Id: IRepository.cs,v 1.0 2014/07/11 10:58:32 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 10:58:32 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using KeywordSearch.Infrastructure.Domain;

namespace KeywordSearch.Infrastructure.Framework.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        /*
         * 根据主键载入主体, 延迟加载
         */
        T Load(object akey);

        /*
         * 根据主键载入实体
         */
        T Get(object akey);

        /*
         * 获取所有实体
         */
        IList<T> GetAll();

        /*
         * 保存实体
         */
        void Save(T entity);

        ///
        /// Summary:
        ///   Save the entity by merge 
        ///   
        /// Parameters:
        ///   entity:
        ///     the entity to save
        void Merge(T entity);

        /*
         * 更新实体
         */
        void Update(T entity);

        /*
         * 删除实体
         */
        void Delete(T entity);
    }
}
