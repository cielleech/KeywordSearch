//-----------------------------------------------------------------
//
// @(#)$Id: RepositoryHbmImpl.cs,v 1.0 2014/07/11 11:11:42 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 11:11:42 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NHibernate;
using KeywordSearch.Infrastructure.Domain;
using KeywordSearch.Infrastructure.Framework.Hbm;

namespace KeywordSearch.Infrastructure.Framework.Repository.Impl
{
    public abstract class RepositoryHbmImpl<T> : IRepository<T> where T : EntityBase
    {
        protected virtual ISession Session {
            get {
                return SessionFactory.CreateSession();
            }
        }

        /*
         * 根据主键延时载入实体
         */
        public virtual T Load(object akey) {
            try {
                T result = Session.Load<T>(akey);

                if (result == null)
                    throw new RepositoryException("返回实体为空");

                return result;
            }
            catch (System.Exception ex) {
                throw new RepositoryException("获取实体失败", ex);
            }
        }

        /*
         * 根据主键载入实体
         */
        public virtual T Get(object akey) {
            try {
                T result = Session.Get<T>(akey);

                if (result == null)
                    throw new RepositoryException("返回实体为空");

                return result;
            }
            catch (System.Exception ex) {
                throw new RepositoryException("获取实体失败", ex);
            }
        }

        /*
         * 获取所有实体
         */
        public virtual IList<T> GetAll() {
            try {
                return Session.CreateCriteria<T>().List<T>();
            }
            catch (System.Exception ex) {
                throw new RepositoryException("获取实体失败", ex);
            }
        }

        /*
         * 保存实体
         */
        public virtual void Save(T entity) {
            try {
                Session.SaveOrUpdate(entity);
                Session.Flush();
            }
            catch (System.Exception ex) {
                throw new RepositoryException("保存实体失败", ex);
            }
        }

        ///
        /// Summary:
        ///   Save the entity by merge 
        ///   
        /// Parameters:
        ///   entity:
        ///     the entity to save
        public virtual void Merge(T entity) {
            try {
                Session.Merge(entity);
                Session.Flush();
            }
            catch (System.Exception ex) {
                throw new RepositoryException("保存实体失败", ex);
            }
        }

        /*
         * 更新实体
         */
        public virtual void Update(T entity) {
            try {
                Session.Update(entity);
                Session.Flush();
            }
            catch (System.Exception ex) {
                throw new RepositoryException("更新实体失败", ex);
            }
        }

        /*
         * 删除实体
         */
        public virtual void Delete(T entity) {
            try {
                Session.Delete(entity);
                Session.Flush();
            }
            catch (System.Exception ex) {
                throw new RepositoryException("删除实体失败", ex);
            }
        }
    }
}
