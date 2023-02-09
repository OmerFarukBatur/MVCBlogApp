using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Confession
{
    public interface IConfessionWriteRepository : IWriteRepository<E.Confession>
    {
    }
}
