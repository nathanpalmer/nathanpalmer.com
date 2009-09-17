using FluentNHibernate.Mapping;
using NathanPalmer.com.Core.Domain.Model;

namespace NathanPalmer.com.Infrastructure.DataAccess.Mappings
{
    public class PostTagMap : ClassMap<PostTag>
    {
        public PostTagMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();

            References(x => x.Post, "PostID");
            References(x => x.Tag, "TagID");

            //CompositeId()
            //    .KeyProperty(x => x.Post, "PostID")
            //    .KeyReference(x => x.Tag, "TagID");
        }
    }
}