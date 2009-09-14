using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NathanPalmer.com.Core.Domain;
using NathanPalmer.com.Core.Domain.Model;
using NHibernate.Linq;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;

namespace NathanPalmer.com.Infrastructure.DataAccess.Impl
{
    public class FluentNHibernatePostRepository : RepositoryBase<Post>, IPostRepository 
    {
        public FluentNHibernatePostRepository(ISessionBuilder SessionBuilder) : base(SessionBuilder)
        {
        }

        public Post Get(int ID)
        {
            return (from p in GetSession().Linq<Post>()
                    where p.ID == ID
                    select p).Single();
        }

        public IQueryable<Post> GetRecent(int Count)
        {
            return (from p in GetSession().Linq<Post>()
                    orderby p.DateCreated descending
                    select p).AsQueryable();
        }
    }
}
