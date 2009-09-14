using System;
using NHibernate;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;
using Tarantino.Infrastructure.Commons.DataAccess.Repositories;

namespace NathanPalmer.com.Infrastructure.DataAccess.Impl
{
    public class RepositoryBase<T> : RepositoryBase
    {
        public RepositoryBase(ISessionBuilder SessionBuilder)
            : base(SessionBuilder)
        {
        }

        public virtual T GetById(Guid ID)
        {
            return GetById(ID);
        }

        public virtual void Save(T Entity)
        {
            using (ISession session = GetSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(Entity);
                tx.Commit();
            }
        }

        //public virtual T[] Get(int ID)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual T[] GetAll()
        //{
        //    return GetAll().ToArray();
        //}

        //public T[] GetRecent(int Count)
        //{
        //    return base.GetSession()
        //        .CreateCriteria(typeof(T))
        //        .SetFetchSize(Count)
        //        .List<T>()
        //        .ToArray();
        //}

        public virtual void Delete(T Entity)
        {
            using (ISession session = GetSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(Entity);
                tx.Commit();
            }
        }
    }
}