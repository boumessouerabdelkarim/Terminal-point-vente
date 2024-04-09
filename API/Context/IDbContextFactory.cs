

using Core.Entities;

namespace API.Context
{
    public interface IDbContextFactory
    {
        TPVDbContext DbContext { get; }
    }
}
