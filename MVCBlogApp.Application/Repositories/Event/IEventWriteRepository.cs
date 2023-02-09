using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Event
{
    public interface IEventWriteRepository : IWriteRepository<E.Event>
    {
    }
}
