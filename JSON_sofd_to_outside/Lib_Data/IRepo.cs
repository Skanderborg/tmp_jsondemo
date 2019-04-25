using System.Linq;

namespace Lib_Data
{
    public interface IRepo<IEntity>
    {
        IQueryable<IEntity> Query { get; }
    }
}
