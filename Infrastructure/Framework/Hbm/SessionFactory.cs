//-----------------------------------------------------------------
//
// @(#)$Id: SessionFactory.cs,v 1.0 2014/07/11 11:09:14 lichunhua Exp $
// @(#)$Author: lichunhua  $
// @(#)$Date: 2014/07/11 11:09:14 $
// @(#)$Description:
//
//
//
//                 All Rights Reserved.
//-----------------------------------------------------------------
using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using KeywordSearch.Infrastructure.Framework.Hbm.Impl;
using log4net;

namespace KeywordSearch.Infrastructure.Framework.Hbm
{
    /// <summary>
    /// Base session factory class
    /// </summary>
    public abstract class SessionFactory
    {
        private static ILog logger = LogManager.GetLogger(typeof(SessionFactory));

        protected static ISessionFactory sessionFactory;
        protected static ISessionStorage sessionStorage;

        /// 
        /// Summary:
        ///   Constructor
        static SessionFactory() {
            try {
                sessionStorage = new StaticSessionStorage();
                Configuration cfg = new Configuration().Configure();
                sessionFactory = cfg.BuildSessionFactory();
            }
            catch (System.Exception ex) {
                logger.Error(ex.Message);
            }
        }


        /// 
        /// Summary:
        ///   Create a hibernate session
        ///   
        /// Returns:
        ///   a ISession object
        public static ISession CreateSession()
        {
            lock (sessionFactory)
            {
                ISession session = sessionStorage.Get();
                if (session == null)
                {
                    session = sessionFactory.OpenSession();
                    sessionStorage.Set(session);
                }
                return session;
            }
        }

        public static void CloseSession()
        {
            ISession session = sessionStorage.Get();
            if (session != null && session.IsOpen)
            {
                session.Close();
                sessionStorage.Set(null);
            }
        }
    }


    [Serializable]
    public class EmptyInterceptor : IInterceptor
    {
        //前面省略n行代码
        public virtual SqlString OnPrepareStatement(SqlString sql) {

            return sql;

        }


        public void AfterTransactionBegin(ITransaction tx) {
            //throw new NotImplementedException();  
        }

        public void AfterTransactionCompletion(ITransaction tx) {
            //throw new NotImplementedException();  
        }

        public void BeforeTransactionCompletion(ITransaction tx) {
            //throw new NotImplementedException();  
        }

        public int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types) {
            //throw new NotImplementedException();  
            return null;
        }

        public object GetEntity(string entityName, object id) {
            //throw new NotImplementedException();  
            return null;
        }

        public string GetEntityName(object entity) {
            //throw new NotImplementedException();  
            return "";
        }

        public object Instantiate(string entityName, EntityMode entityMode, object id) {
            //throw new NotImplementedException();  
            return null;
        }

        public bool? IsTransient(object entity) {
            //throw new NotImplementedException();  
            return true;
        }

        public void OnCollectionRecreate(object collection, object key) {
            //throw new NotImplementedException();  
        }

        public void OnCollectionRemove(object collection, object key) {
            //throw new NotImplementedException();  
        }

        public void OnCollectionUpdate(object collection, object key) {
            //throw new NotImplementedException();  
        }

        public void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types) {
            //throw new NotImplementedException();  
        }

        public bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types) {
            //throw new NotImplementedException();  
            return true;
        }

        public bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types) {
            //throw new NotImplementedException();  
            return true;
        }

        public bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types) {
            //throw new NotImplementedException();  
            return true;
        }

        public void PostFlush(System.Collections.ICollection entities) {
            //throw new NotImplementedException();  
        }

        public void PreFlush(System.Collections.ICollection entities) {
            //throw new NotImplementedException();  
        }

        public void SetSession(ISession session) {
            //throw new NotImplementedException();  
        }
    }
    public class MyInterceptor : EmptyInterceptor
    {

        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql) {
            Console.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);

        }

    }   
}