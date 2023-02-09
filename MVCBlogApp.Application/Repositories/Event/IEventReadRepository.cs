using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Repositories.Event
{
    public interface IEventReadRepository : IReadRepository<E.Event>
    {
    }
}
