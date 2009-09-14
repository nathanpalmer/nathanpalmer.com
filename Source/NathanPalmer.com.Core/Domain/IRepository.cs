using System.Linq;

namespace NathanPalmer.com.Core.Domain
{
    public interface IRepository<T>
    {
        T Get(int ID);
        IQueryable<T> GetRecent(int Count);
    }
}