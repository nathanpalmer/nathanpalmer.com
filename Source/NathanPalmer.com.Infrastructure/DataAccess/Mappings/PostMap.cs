using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NathanPalmer.com.Core.Domain.Model;

namespace NathanPalmer.com.Infrastructure.DataAccess.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();

            Map(x => x.DateCreated)
                .Not.Nullable();
            Map(x => x.Subject)
                .Not.Nullable();
            Map(x => x.Body)
                .CustomSqlType("text")
                .Not.Nullable();

            //References(x => x.Tags).Class<PostTag>().Cascade.All();

            HasMany(x => x.Tags)
                .Cascade.All();

            Not.LazyLoad();

            //HasManyToMany(x => x.Tags)
            //    .AsBag()
            //    .Table("PostTag")
            //    .ParentKeyColumn("PostID")
            //    .ChildKeyColumn("TagID")
            //    .ForeignKeyConstraintNames("PostID", "TagID")
            //    .Cascade.All();
        }
    }
}
