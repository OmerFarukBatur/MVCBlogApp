using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Status
{
    public interface IStatusWriteRepository : IWriteRepository<E.Status>
    {
    }
}
