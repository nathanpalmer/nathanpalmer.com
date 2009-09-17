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
        private readonly ITagRepository tagRepository;

        public FluentNHibernatePostRepository(ISessionBuilder SessionBuilder, ITagRepository TagRepository) : base(SessionBuilder)
        {
            tagRepository = TagRepository;
        }

        public override void Save(Post Entity)
        {
            for (int index = 0; index < Entity.Tags.Count; index++)
            {
                var tag = Entity.Tags[index];
                if (tag.ID == null)
                {
                    var tagRepo = tagRepository.GetByName(tag.Name);
                    if (tagRepo != null)
                    {
                        Entity.Tags[index] = tagRepo;
                        continue;
                    }

                    tagRepository.Save(tag);
                }
            }

            base.Save(Entity);
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
