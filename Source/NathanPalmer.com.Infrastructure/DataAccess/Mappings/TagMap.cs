using FluentNHibernate.Mapping;
using NathanPalmer.com.Core.Domain.Model;

namespace NathanPalmer.com.Infrastructure.DataAccess.Mappings
{
    public class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();

            Map(x => x.Name)
                .Unique();
        }
    }
}