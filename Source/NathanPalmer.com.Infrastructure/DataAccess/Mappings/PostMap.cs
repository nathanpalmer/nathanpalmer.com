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
            Id(x => x.ID);

            Map(x => x.DateCreated);
            Map(x => x.Subject);
            Map(x => x.Body).CustomSqlType("text");
        }
    }
}
