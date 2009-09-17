using NathanPalmer.com.Core.Domain.Model;

namespace NathanPalmer.com.Core.Domain
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetByName(string Name);
    }
}