using System;
using System.Linq;
using NathanPalmer.com.Core.Domain;
using NathanPalmer.com.Core.Domain.Model;
using NHibernate.Linq;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;

namespace NathanPalmer.com.Infrastructure.DataAccess.Impl
{
    public class FluentNHibernateTagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public FluentNHibernateTagRepository(ISessionBuilder SessionBuilder) : base(SessionBuilder)
        {
        }

        public Tag Get(int ID)
        {
            return (from t in GetSession().Linq<Tag>()
                    where t.ID == ID
                    select t).Single();
        }

        public Tag GetByName(string Name)
        {
            return (from t in GetSession().Linq<Tag>()
                    where t.Name == Name
                    select t).FirstOrDefault();
        }

        public IQueryable<Tag> GetRecent(int Count)
        {
            throw new NotImplementedException();
        }
    }
}